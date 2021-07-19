using System;
using System.Runtime.InteropServices;
using GCore.NativeInterop;

namespace LibNamespace
{
    public static class Test_ManagedUnsafe
    {
        // begin-snippet: Test_ManagedUnsafe_CS
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

                // Get the memory offset of Args.ReturnMsg
                var destReturnMsg = IntPtr.Add(ptr, (int)Marshal.OffsetOf(typeof(Args), nameof(Args.ReturnMsg)));

                var data = CEncoding.Ascii.GetBytes("Hello Ansi");

                // Copy the data to the unmanaged memory
                Marshal.Copy(data, 0, (IntPtr)destReturnMsg, data.Length);
            }
        }
        // end-snippet
    }
}