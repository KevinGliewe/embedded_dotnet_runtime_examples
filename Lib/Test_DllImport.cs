using System;
using System.Reflection;
using System.Runtime.InteropServices;


namespace LibNamespace
{
    public static class Test_DllImport
    {
        private static IntPtr s_moduleHandle = IntPtr.Zero;

        private static IntPtr ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            return libraryName == "Test_DllImport_LibName" ? s_moduleHandle : NativeLibrary.Load(libraryName, assembly, searchPath);
        }

        [DllImport("Test_DllImport_LibName")]
        public static extern int Test_DllImport_ExternC(int number);

        [UnmanagedCallersOnly]
        public static int Test_DllImport_Call(IntPtr moduleHandle, int number)
        {
            s_moduleHandle = moduleHandle;
            NativeLibrary.SetDllImportResolver(typeof(Test_DllImport).Assembly, ImportResolver);

            return Test_DllImport_ExternC(number);
        }
    }
}