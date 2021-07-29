using System;
using System.Runtime.InteropServices;

namespace LibNamespace
{
    public static class Test_NativeVTable
    {
        #region Test_NativeVTable_Class_CS
        [StructLayout(LayoutKind.Sequential)]
        private struct ClassLayout
        {
            public IntPtr VTable;
            public int test;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ClassVTable
        {
            public IntPtr Method_AddOne;
            public IntPtr Method_AddTwo;
        }

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void MethodDelegate(IntPtr thisPtr);
        #endregion

        #region Test_NativeVTable_Overwrite_CS
        private static MethodDelegate delegate_SubOne = new MethodDelegate(thisPtr =>
        {
            unsafe
            {
                unchecked
                {
                    var instance = (ClassLayout*)thisPtr;
                    instance->test -= 1;
                }
            }
        });

        static IntPtr _overwrittenVTable = IntPtr.Zero;
        #endregion

        [UnmanagedCallersOnly]
        public static void Test_NativeVTable_Call(IntPtr classInstance)
        {

            {
                #region Test_NativeVTable_ManagedCall_CS

                ClassLayout instance = Marshal.PtrToStructure<ClassLayout>(classInstance);

                ClassVTable vTable = Marshal.PtrToStructure<ClassVTable>(instance.VTable);

                MethodDelegate method_AddOne =
                    Marshal.GetDelegateForFunctionPointer<MethodDelegate>(vTable.Method_AddOne);
                MethodDelegate method_AddTwo =
                    Marshal.GetDelegateForFunctionPointer<MethodDelegate>(vTable.Method_AddTwo);

                method_AddOne(classInstance);
                method_AddTwo(classInstance);

                #endregion
            }

            #region Test_NativeVTable_ManagedOverwrite_CS
            unsafe
            {
                unchecked
                {
                    // WARNING: vTable need to be freed at some point!
                    _overwrittenVTable = Marshal.AllocHGlobal(Marshal.SizeOf<ClassVTable>());

                    var vTable = (ClassVTable*)_overwrittenVTable;

                    vTable->Method_AddTwo = vTable->Method_AddOne =
                        Marshal.GetFunctionPointerForDelegate(delegate_SubOne);

                    var instance = (ClassLayout*) classInstance;
                    instance->VTable = (IntPtr)vTable;
                }
            }
            #endregion
        }
    }
}