using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace LibNamespace
{
    public static class Test_ManagedEntryPoint
    {
        // begin-snippet: Test_ManagedEntryPoint_Args_CS
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Args
        {
            public int Number1;
            public int Number2;
        }
        // end-snippet

        // begin-snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CS
        public static int Test_ComponentEntryPoint(IntPtr arg, int argLength)
        {
            if (argLength < Marshal.SizeOf(typeof(Args)))
            {
                return 1;
            }

            Args args = Marshal.PtrToStructure<Args>(arg);

            return args.Number1 + args.Number2;
        }
        // end-snippet

        // begin-snippet: Test_ManagedEntryPoint_CustomEntryPoint_CS
        [UnmanagedCallersOnly]
        public static int Test_CustomEntryPoint(Args args)
        {
            return args.Number1 + args.Number2;
        }
        // end-snippet
    }
}