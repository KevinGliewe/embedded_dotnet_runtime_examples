using System;
using System.Linq;
using System.Runtime.InteropServices;
using GCore.NativeInterop;

namespace LibNamespace
{
    public static class Test_NativeArray
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Args
        {
            public fixed int Arr[8];
            public int Multiplier;
        }

        [UnmanagedCallersOnly]
        public static unsafe int Test_NativeArray_StructFixed(Args args)
        {
            int ret = 0;

            for(int i = 0; i < 8; i++)
            {
                ret += args.Arr[i] * args.Multiplier;
            }

            return ret;
        }

        // ----------------------------------------------------------------------------------------------------

        [UnmanagedCallersOnly]
        public static int Test_NativeArray_ArgumentFixed(IntPtr arrPtr, int multiplier)
        {
            // ArrPointer as argument does not work here!

            ArrPointer8<int> arr = new ArrPointer8<int>(arrPtr);

            return arr.Sum(el => el * multiplier); ;
        }

        // ----------------------------------------------------------------------------------------------------


        public delegate int FunctionPointerCallbackDelegate(ArrPointer8<int> arr, int multiplier);

        public static FunctionPointerCallbackDelegate FunctionPointerCallbackDelegateInstance =
            new FunctionPointerCallbackDelegate(Callback);

        public static int Callback(ArrPointer8<int> arr, int multiplier) => arr.Sum(el => el * multiplier);

        [UnmanagedCallersOnly]
        public static IntPtr Test_NativeArray_ArgumentFixed_FunctionPointer()
        {
            return Marshal.GetFunctionPointerForDelegate(FunctionPointerCallbackDelegateInstance);
        }
    }
}