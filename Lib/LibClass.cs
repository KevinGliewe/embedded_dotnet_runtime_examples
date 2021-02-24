using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LibNamespace
{
    public static class LibClass
    {
        private static IntPtr s_hostHandle = IntPtr.Zero;

        private static int s_CallCount = 1;

        [StructLayout(LayoutKind.Sequential)]
        public struct LibArgs
        {
            public IntPtr Message;
            public int Number;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct LibArgsHostHandle
        {
            public IntPtr HostHandle;
        }

        public static int  SetHostHandle(IntPtr arg, int argLength)
        {
            if (argLength < System.Runtime.InteropServices.Marshal.SizeOf(typeof(LibArgsHostHandle))) {
                Console.WriteLine("argLength < System.Runtime.InteropServices.Marshal.SizeOf(typeof(LibArgsHostHandle))");
                return 1;
            }

            var libArgs = Marshal.PtrToStructure<LibArgsHostHandle>(arg);

            s_hostHandle = libArgs.HostHandle;
            Console.WriteLine("HostHandle: " + string.Format("{0:X8}", s_hostHandle));

            NativeLibrary.SetDllImportResolver(typeof(LibClass).Assembly, ImportResolver);

            return 0;
        }

        public static int Hello(IntPtr arg, int argLength) {
            if (argLength < System.Runtime.InteropServices.Marshal.SizeOf(typeof(LibArgs))) {
                return 1;
            }

            LibArgs libArgs = Marshal.PtrToStructure<LibArgs>(arg);
            Console.WriteLine($"Hello, world! from {nameof(LibClass)} [count: {s_CallCount++}]");
            PrintLibArgs(libArgs);
            return 0;
        }

        public delegate void CustomEntryPointDelegate(LibArgs libArgs);
        public static void CustomEntryPoint(LibArgs libArgs) {
            Console.WriteLine($"Hello, world! from {nameof(CustomEntryPoint)} in {nameof(LibClass)}");
            PrintLibArgs(libArgs);
        }

#if NET5_0
        [UnmanagedCallersOnly]
        public static void CustomEntryPointUnmanaged(LibArgs libArgs)
        {
            CustomEntryPoint(libArgs);
            try
            {
                ExeFn("C#");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
#endif

        private static void PrintLibArgs(LibArgs libArgs) {
            string message = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? Marshal.PtrToStringUni(libArgs.Message)
                : Marshal.PtrToStringUTF8(libArgs.Message);

            Console.WriteLine($"-- message: {message}");
            Console.WriteLine($"-- number: {libArgs.Number}");
        }

        [DllImport("*")]
        public static extern void ExeFn([MarshalAs(UnmanagedType.BStr)] string msg);

        private static IntPtr ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath) {
            Console.WriteLine($"ImportResolver({libraryName})");
            
            IntPtr libHandle = IntPtr.Zero;
            if (libraryName == "*")
            {
                Console.WriteLine("Use host handle " + s_hostHandle);
                return s_hostHandle;
            }
            return libHandle;
        }
    }
}
