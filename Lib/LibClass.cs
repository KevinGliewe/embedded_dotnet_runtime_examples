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
        public struct string_t
        {
            public IntPtr i0;
            public IntPtr i1;
            public IntPtr i2;
            public IntPtr i3;
            public IntPtr i4;
            public IntPtr i5;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LibArgs
        {
            public IntPtr ReturnMsg;
            public IntPtr Message;
            public int Number;
            //public string_t SetMsg;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct LibArgsHostHandle
        {
            public IntPtr HostHandle;
        }

        public static int  SetHostHandle(IntPtr arg, int argLength)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => {
                Console.WriteLine($"Unhandled Exception: " + args.ExceptionObject);
            };

            s_hostHandle = arg;
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

            unsafe
            {
                var pArgs = (LibArgs*) arg;
                pArgs->Number *= 2;
                // Memory leak!?!
                pArgs->ReturnMsg = Marshal.StringToBSTR($"Returned from C#");
            }

            // Does not work!
            libArgs.Number += 10;

            SetArgsMsg(arg, "SetArgsMsg() from C#");

            return 0;
        }

        public delegate void CustomEntryPointDelegate(LibArgs libArgs);
        public static void CustomEntryPoint(LibArgs libArgs) {
            Console.WriteLine($"Hello, world! from {nameof(CustomEntryPoint)} in {nameof(LibClass)}");
            PrintLibArgs(libArgs);
            
            // Does not work!
            // libArgs.Number = 42;
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

            // Does not work!
            libArgs.Number = 42;
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

        [DllImport("*")]
        public static extern void SetArgsMsg(IntPtr args, [MarshalAs(UnmanagedType.BStr)] string msg);

        private static IntPtr ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath) {
            Console.WriteLine($"ImportResolver({libraryName})");
            
            IntPtr libHandle = IntPtr.Zero;
            if (libraryName == "*")
            {
                Console.WriteLine("Used host handle " + string.Format("{0:X8}", s_hostHandle) + " for " + libraryName);
                libHandle =  s_hostHandle;
            }
            else
            {
                libHandle = NativeLibrary.Load(libraryName, assembly, searchPath);
            }
            return libHandle;
        }
    }
}
