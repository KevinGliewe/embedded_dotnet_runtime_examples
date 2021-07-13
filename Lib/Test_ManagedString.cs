using System;
using System.Runtime.InteropServices;
using GCore.NativeInterop;

namespace LibNamespace
{
    public class Test_ManagedString
    {
        public static readonly CString HelloAnsi = new CString("Hello Ansi");
        public static readonly CString HelloWide = new CString("Hello ❤", CEncoding.Wide);

        [UnmanagedCallersOnly]
        public static IntPtr Test_ManagedString_Ansi()
        {
            return HelloAnsi.Ptr;
        }

        [UnmanagedCallersOnly]
        public static IntPtr Test_ManagedString_Wide()
        {
            return HelloWide.Ptr;
        }
    }
}