using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace GCore.NativeInterop
{
    public class ModuleLoader
    {
        public static class PosixDefinitions
        {
            [Flags]
            public enum PosixFlags
            {
                RTLD_LAZY = (0 << 0), // Lazy function call binding.
                RTLD_NOW = (1 << 0), // Immediate function call binding.
                RTLD_GLOBAL = (1 << 1),
                RTLD_LOCAL = (1 << 2)
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct dl_info
            {
                public IntPtr dli_fbase;
                public IntPtr dli_fname;
                public IntPtr dli_saddr;
                public IntPtr dli_sname;
            }

            [DllImport("libdl", CharSet = CharSet.Ansi)]
            public static extern IntPtr dlopen(string filename, int flags);

            [DllImport("libdl")]
            public static extern int dlclose(IntPtr handle);

            [DllImport("libdl", CharSet = CharSet.Ansi)]
            public static extern IntPtr dlsym(IntPtr handle, string symbol);

            [DllImport("libdl")]
            public static extern int dladdr(IntPtr handle, ref dl_info dl_info);
        }

        public class WindowsDefinitions
        {
            [Flags]
            public enum WindowsFlags
            {
                GET_MODULE_HANDLE_EX_FLAG_PIN = 0x1,
                GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT = 0x2,
                GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS = 0x4
            }

            [DllImport("kernel32")]
            public static extern IntPtr LoadLibraryW([MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

            [DllImport("kernel32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FreeLibrary(IntPtr hModule);

            [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true)]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [DllImport("kernel32")]
            public static extern IntPtr GetModuleHandleW([MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

            [DllImport("kernel32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetModuleHandleExW(UInt32 dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string lpModuleName, ref IntPtr hModule);

            [DllImport("kernel32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetModuleHandleEx(UInt32 dwFlags, IntPtr lpModuleName, ref IntPtr hModule);

            [DllImport("kernel32")]
            public static extern UInt32 GetModuleFileNameW(IntPtr hModule, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpFilename, UInt32 nSize);
        }

        public static bool IsPosix => Environment.OSVersion.Platform switch
        {
            PlatformID.MacOSX => true,
            PlatformID.Unix => true,
            PlatformID.Other => true,
            _ => false
        };

        public static IntPtr LoadLibrary(string name)
        {
            if (IsPosix)
            {
                return PosixDefinitions.dlopen(name,
                    (int)(PosixDefinitions.PosixFlags.RTLD_LAZY | PosixDefinitions.PosixFlags.RTLD_LOCAL));
            }
            else
            {
                return WindowsDefinitions.LoadLibraryW(name);
            }
        }

        public static bool UnloadLibrary(IntPtr handle)
        {
            if (IsPosix)
            {
                return PosixDefinitions.dlclose(handle) == 0;
            }
            else
            {
                return WindowsDefinitions.FreeLibrary(handle);
            }
        }

        public static IntPtr GetExport(IntPtr handle, string name)
        {
            if (IsPosix)
            {
                return PosixDefinitions.dlsym(handle, name);
            }
            else
            {
                return WindowsDefinitions.GetProcAddress(handle, name);
            }
        }

        public static T GetExport<T>(IntPtr handle, string name) where T : Delegate
        {
            var fPtr = GetExport(handle, name);
            if (fPtr == IntPtr.Zero)
                throw new Exception($"Export '{name}' returned IntPtr.Zero for the handle {handle}!");
            return (T)Marshal.GetDelegateForFunctionPointer(fPtr, typeof(T));
        }

        public static string? GetModulePath(IntPtr handle)
        {
            if (IsPosix)
            {
                PosixDefinitions.dl_info dlInfo = new PosixDefinitions.dl_info();
                if (PosixDefinitions.dladdr(handle, ref dlInfo) == 0)
                    return null;
                if (dlInfo.dli_fname == IntPtr.Zero)
                    return null;
                /*Console.WriteLine($"dli_fname={dlInfo.dli_fname}");
                Console.WriteLine($"dli_fbase={dlInfo.dli_fbase}");
                Console.WriteLine($"dli_saddr={dlInfo.dli_saddr}");
                Console.WriteLine($"dli_sname={dlInfo.dli_sname}");*/
                return Encoding.ASCII.GetString(dlInfo.dli_fname) + " : " + Encoding.ASCII.GetString(dlInfo.dli_sname);
            }
            else
            {
                var sb = new StringBuilder(1024);
                WindowsDefinitions.GetModuleFileNameW(handle, sb, (uint)sb.Capacity);
                return sb.ToString();
            }
        }

        public static IntPtr GetHandle(IntPtr symbolPtr)
        {
            if (IsPosix)
            {
                PosixDefinitions.dl_info dlInfo = new PosixDefinitions.dl_info();
                if (PosixDefinitions.dladdr(symbolPtr, ref dlInfo) == 0)
                    return IntPtr.Zero;
                return dlInfo.dli_fbase;
            }
            else
            {
                IntPtr handle = IntPtr.Zero;
                WindowsDefinitions.GetModuleHandleEx(
                    (UInt32)(WindowsDefinitions.WindowsFlags.GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS |
                             WindowsDefinitions.WindowsFlags.GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT),
                    (IntPtr)symbolPtr,
                    ref handle
                );
                return handle;
            }
        }

        public static IntPtr GetHostHandle()
        {
            if (IsPosix)
            {
                return PosixDefinitions.dlopen(null,
                    (int) (PosixDefinitions.PosixFlags.RTLD_LAZY | PosixDefinitions.PosixFlags.RTLD_LOCAL));
            }
            else
            {
                return WindowsDefinitions.GetModuleHandleW(null);
            }
        }
    }
}