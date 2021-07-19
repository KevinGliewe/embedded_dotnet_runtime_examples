using System;
using System.Runtime.InteropServices;

namespace LibNamespace
{
    public static class Test_ManagedFunctionPointer
    {
        // begin-snippet: Test_ManagedFunctionPointer_FunctionPointerCallbackDelegate_CS
        public delegate int FunctionPointerCallbackDelegate(int a);
        // end-snippet


        #region Test_ManagedFunctionPointer_Instance_CS
        
        public class CallableObject
        {
            public FunctionPointerCallbackDelegate CallbackDelegate;
            public IntPtr CallbackFunctionPointer;

            private int Member;

            public int Callback(int i) => i + Member;

            public CallableObject(int member)
            {
                Member = member;
                CallbackDelegate = new FunctionPointerCallbackDelegate(Callback);
                CallbackFunctionPointer = Marshal.GetFunctionPointerForDelegate(CallbackDelegate);
            }

        }

        public static CallableObject CallableObjectInstance;

        // Enty point for unmanaged code
        [UnmanagedCallersOnly]
        public static IntPtr Test_ManagedFunctionPointer_Instance(int member)
        {
            CallableObjectInstance = new CallableObject(member);
            return CallableObjectInstance.CallbackFunctionPointer;
        }


        #endregion // Test_ManagedFunctionPointer_Instance_CS ----------------------------------------------------------

        #region Test_ManagedFunctionPointer_Static_CS

        public static FunctionPointerCallbackDelegate FunctionPointerCallbackDelegateStatic = new FunctionPointerCallbackDelegate(Callback);

        public static int Callback(int i) => i + 3;

        // Enty point for unmanaged code
        [UnmanagedCallersOnly]
        public static IntPtr Test_ManagedFunctionPointer_Static()
        {
            return Marshal.GetFunctionPointerForDelegate(FunctionPointerCallbackDelegateStatic);
        }


        #endregion // Test_ManagedFunctionPointer_Static_CS -------------------------------------------------------------

    }
}