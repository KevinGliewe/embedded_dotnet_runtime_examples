using System;
using System.Runtime.InteropServices;
using GCore.NativeInterop;

namespace LibNamespace
{
    public class Test_ManagedString
    {
        #region Test_ManagedString_Ansi_CS
        public static readonly CString HelloAnsi = new CString("Hello Ansi");

        [UnmanagedCallersOnly]
        public static IntPtr Test_ManagedString_Ansi()
        {
            return HelloAnsi.Ptr;
        }
        #endregion

        #region Test_ManagedString_Wide_CS
        public static readonly CString HelloWide = new CString("Hello ❤", CEncoding.Wide);

        [UnmanagedCallersOnly]
        public static IntPtr Test_ManagedString_Wide()
        {
            return HelloWide.Ptr;
        }
        #endregion
    }
}