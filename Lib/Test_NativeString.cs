using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using GCore.NativeInterop;

namespace LibNamespace
{
    public static class Test_NativeString
    {

        [UnmanagedCallersOnly]
        public static int Test_NativeString_Ansi(IntPtr stringPtr)
        {
            return CEncoding.Ascii.GetString(stringPtr) == "Hello Ansi" ? 1 : 0;
        }

        [UnmanagedCallersOnly]
        public static int Test_NativeString_Wide(IntPtr stringPtr)
        {
            return CEncoding.Wide.GetString(stringPtr) == "Hello ❤" ? 1 : 0;
        }

        // ---------------------------------------------------------------------------------------------

        public delegate bool FunctionPointerCallbackAnsiDelegate(NativeString nstr);
        public delegate bool FunctionPointerCallbackWideDelegate(NativeWString nstr);

        public static FunctionPointerCallbackAnsiDelegate FunctionPointerCallbackAnsiDelegateInstance =
            new FunctionPointerCallbackAnsiDelegate(CallbackAnsi);

        public static FunctionPointerCallbackWideDelegate FunctionPointerCallbackWideDelegateInstance =
            new FunctionPointerCallbackWideDelegate(CallbackWide);

        public static bool CallbackAnsi(NativeString nstr) => nstr.ToString() == "Hello Ansi";
        public static bool CallbackWide(NativeWString nstr) => nstr.ToString() == "Hello ❤";

        [StructLayout(LayoutKind.Sequential)]
        public struct RetArgs
        {
            public IntPtr CallbackAnsi;
            public IntPtr CallbackWide;
        }

        [UnmanagedCallersOnly]
        public static void Test_NativeString_FunctionPointer(IntPtr retArgsPtr)
        {
            unsafe
            {
                RetArgs* retArgs = (RetArgs*)retArgsPtr;
                retArgs->CallbackAnsi =
                    Marshal.GetFunctionPointerForDelegate(FunctionPointerCallbackAnsiDelegateInstance);
                retArgs->CallbackWide =
                    Marshal.GetFunctionPointerForDelegate(FunctionPointerCallbackWideDelegateInstance);
            }
        }
    }
}