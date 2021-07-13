using System;
using System.Runtime.InteropServices;

namespace LibNamespace
{
    public static class Test_NativeFunctionPointer
    {

        public delegate int FunctionPointerCallbackDelegate(int a);

        [UnmanagedCallersOnly]
        public static int Test_NativeFunctionPointer_Checked(IntPtr nativeFunctionPtr, int number)
        {
            var callbackFuncDelegate =
                (FunctionPointerCallbackDelegate)Marshal.GetDelegateForFunctionPointer(nativeFunctionPtr,
                    typeof(FunctionPointerCallbackDelegate));
            return callbackFuncDelegate(number);
        }

        [UnmanagedCallersOnly]
        public static int Test_NativeFunctionPointer_Unchecked(IntPtr nativeFunctionPtr, int number)
        {
            unsafe
            {
                unchecked
                {
                    var callbackFuncPtr = (delegate* unmanaged[Cdecl]<int, int>)nativeFunctionPtr;
                    return callbackFuncPtr(number);
                }
            }
        }
    }
}