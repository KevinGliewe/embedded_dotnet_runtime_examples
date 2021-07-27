using System;
using System.Runtime.InteropServices;
using GCore.NativeInterop;
using LibNamespace;

namespace LibNamespace
{
    public static class Test_NativeExport
    {
        // begin-snippet: Test_NativeExport_CS
        public delegate int FunctionPointerCallbackDelegate(int a);

        [UnmanagedCallersOnly]
        public static int Test_NativeExport_Call(IntPtr moduleHandle, int number)
        {
            var exportedDelegate = ModuleLoader.GetExport<FunctionPointerCallbackDelegate>(moduleHandle, "Test_NativeExport_ExternC");
            int result = exportedDelegate(number);

            unsafe
            {
                unchecked
                {
                    var callbackFuncPtr = (delegate* unmanaged[Cdecl]<int, int>)ModuleLoader.GetExport(moduleHandle, "Test_NativeExport_ExternC");
                    result += callbackFuncPtr(number);
                }
            }

            return result / 2;
        }
        // end-snippet
    }
}