using System;
using System.Runtime.InteropServices;

namespace LibNamespace
{
    public static class Test_ManagedFunctionPointer
    {
        public delegate int FunctionPointerCallbackDelegate(int a);


        #region Instance // -----------------------------------------------------------------------------------

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

        [UnmanagedCallersOnly]
        public static IntPtr Test_ManagedFunctionPointer_Instance(int member)
        {
            CallableObjectInstance = new CallableObject(member);
            return CallableObjectInstance.CallbackFunctionPointer;
        }


        #endregion // --------------------------------------------------------------------------------------------

        #region Static // ------------------------------------------------------------------------------------------

        public static FunctionPointerCallbackDelegate FunctionPointerCallbackDelegateStatic = new FunctionPointerCallbackDelegate(Callback);

        public static int Callback(int i) => i + 3;

        [UnmanagedCallersOnly]
        public static IntPtr Test_ManagedFunctionPointer_Static()
        {
            return Marshal.GetFunctionPointerForDelegate(FunctionPointerCallbackDelegateStatic);
        }


        #endregion // -------------------------------------------------------------------------------------------------

    }
}