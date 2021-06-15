using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using GCore.NativeInterop;

namespace LibNamespace
{
    public static class LibClass
    {
        private static IntPtr s_hostHandle = IntPtr.Zero;

        private static int s_CallCount = 1;

        private static InstanceTest instanceTest = new InstanceTest();


        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct LibArgs
        {
            public IntPtr Message;
            public int Number;
            public IntPtr FpCallbackX;
            public IntPtr FpCallbackY;

            public fixed byte ReturnMsg[512];
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
                //pArgs->FpCallback = Marshal.GetFunctionPointerForDelegate(new FunctionPinterCallbackXDelegate(FunctionPinterCallbackX));
                pArgs->FpCallbackX = Marshal.GetFunctionPointerForDelegate(new FunctionPinterCallbackXDelegate(instanceTest.FunctionPinterCallbackX));
                pArgs->FpCallbackY =
                    Marshal.GetFunctionPointerForDelegate(new FunctionPinterCallbackYDelegate(FunctionPinterCallbackY));
                var dest = IntPtr.Add( arg, (int)Marshal.OffsetOf(typeof(LibArgs), nameof(LibArgs.ReturnMsg)));

                var bytes = StringToWCHAR_T("Returned from C#");
                if(bytes.Length > 512)
                    throw new Exception("String is bigger than 512 bytes!");
                Marshal.Copy(bytes, 0, (IntPtr)dest, bytes.Length);
            }

            // Does not work!
            libArgs.Number += 10;

            SetArgsMsg(arg, StringToWCHAR_T("SetArgsMsg() from C#"));

            return 0;
        }

        public delegate int FunctionPinterCallbackXDelegate(int a);
        public delegate int FunctionPinterCallbackYDelegate(Pointer6<int> a, int size);

        public static int FunctionPinterCallbackX(int a) {
            Console.WriteLine("FunctionPinterCallback");
            return a + 1;
        }

        public static int FunctionPinterCallbackY(Pointer6<int> a, int size)
        {
            int sum = 0;

            Console.WriteLine($"a.P = {a.Ptr}, a.IsValid = {a.IsValid}, size = {size}");
            for (int i = 0; i < size; i++)
            {
                var a_ix = a.GetElement(i);
                sum += a_ix;
                Console.WriteLine($"a[{i}] = {a_ix}");
            }

            Console.WriteLine(string.Join(", ", a));

            return sum;
        }

        public static int FunctionPointerCallback(IntPtr arg, int argLength)
        {
            unsafe
            {
                unchecked
                {
                    var callbackFuncPtr = (delegate * unmanaged[Cdecl] < int, int >)arg;
                    var ret = callbackFuncPtr(21);
                    Console.WriteLine("Pointer Callback returned: " + ret);
                }
            }

            {
                var callbackFuncDelegate =
                    (FunctionPinterCallbackXDelegate) Marshal.GetDelegateForFunctionPointer(arg,
                        typeof(FunctionPinterCallbackXDelegate));
                var ret = callbackFuncDelegate(7);
                Console.WriteLine("Delegate Callback returned: " + ret);
            }

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
                ExeFn(StringToWCHAR_T("C#"));
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
        public static extern void ExeFn(byte[] msg);

        [DllImport("*")]
        public static extern void SetArgsMsg(IntPtr args, byte[] msg);

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

        static byte[] StringToWCHAR_T(string s) {
            var encoding =
                Environment.OSVersion.Platform == PlatformID.Unix
                ? System.Text.Encoding.UTF32
                : System.Text.Encoding.Unicode; // UTF-16

            return encoding.GetBytes(s + '\0');
        }

        class InstanceTest
        {
            public int Val = 66;
            public int FunctionPinterCallbackX(int a) {
                Console.WriteLine("InstanceTest.FunctionPinterCallback");
                return a + Val;
            }

        }
    }
}
