using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;

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
            public static extern int dladdr(IntPtr handle, IntPtr dl_info);
        }

        public class WindowsDefinitions
        {
            [DllImport("kernel32", SetLastError = true)]
            public static extern IntPtr LoadLibraryW([MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

            [DllImport("kernel32", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FreeLibrary(IntPtr hModule);

            [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
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
    }
}