using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace LibNamespace
{
    public static class Test_ManagedEntryPoint
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Args
        {
            public int Number1;
            public int Number2;
        }

        public static int Test_ComponentEntryPoint(IntPtr arg, int argLength)
        {
            if (argLength < System.Runtime.InteropServices.Marshal.SizeOf(typeof(Args)))
            {
                return 1;
            }

            Args args = Marshal.PtrToStructure<Args>(arg);

            return args.Number1 + args.Number2;
        }

        [UnmanagedCallersOnly]
        public static int Test_CustomEntryPoint(Args args)
        {
            return args.Number1 + args.Number2;
        }
    }
}