using System;
using System.Runtime.InteropServices;
using GCore.NativeInterop;

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
        
        delegate void MethodDelegate(IntPtr thisPtr);
        #endregion

        #region Test_NativeVTable_Overwrite_CS
        // This delegate will be the new virtual method
        private static readonly unsafe MethodDelegate delegate_SubOne = new MethodDelegate(thisPtr =>
        {
            var instance = (ClassLayout*)thisPtr;
            instance->test -= 1;
        });

        // Create new unmanaged VTable instance
        private static readonly UnmanagedMemory<ClassVTable> OverwrittenVTable = new();
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
                // Get the new VTable
                var vTable = OverwrittenVTable.PtrElem;

                // Set the virtual methods with the new managed function pointer (Both the same for simplicity)
                vTable->Method_AddTwo = vTable->Method_AddOne =
                    Marshal.GetFunctionPointerForDelegate(delegate_SubOne);

                // Overwrite the VTable reference of the instance
                var instance = (ClassLayout*) classInstance;
                instance->VTable = (IntPtr) vTable;
            }
            #endregion
        }
    }
}