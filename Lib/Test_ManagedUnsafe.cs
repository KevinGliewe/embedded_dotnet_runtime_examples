using System;
using System.Runtime.InteropServices;
using GCore.NativeInterop;

namespace LibNamespace
{
    public static class Test_ManagedUnsafe
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Args
        {
            public int Number1;
            public int number2;
            public int Sum;
            public fixed byte ReturnMsg[128];
        }

        [UnmanagedCallersOnly]
        public static void Test_ManagedUnsafe_Struct(IntPtr ptr)
        {
            unsafe
            {
                Args* args = (Args*) ptr;

                args->Sum = args->Number1 + args->number2;

                var destReturnMsg = IntPtr.Add(ptr, (int)Marshal.OffsetOf(typeof(Args), nameof(Args.ReturnMsg)));
                var data = CEncoding.Ascii.GetBytes("Hello Ansi");
                Marshal.Copy(data, 0, (IntPtr)destReturnMsg, data.Length);
            }
        }
        
    }
}