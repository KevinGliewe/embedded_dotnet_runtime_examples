#pragma once

#include "Common.h"


namespace Test_NativeFunctionPointer
{
	// begin-snippet: Test_NativeFunctionPointer_CallbackFunc_CPP
	int FEXPORT CallbackFunc(int i)
	{
		return i * 2;
	}
	// end-snippet

	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(void*, int);

		// begin-snippet: Test_NativeFunctionPointer_CallbackPointer_CPP
		void* fpNativeCallback = (void*)&CallbackFunc;
		// end-snippet

		{ // checked function pointer to delegate
			// begin-snippet: Test_NativeFunctionPointer_CallbackFunc_Checked_CPP

			auto fpTest_NativeFunctionPointer_Checked = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeFunctionPointer"),
				STR("Test_NativeFunctionPointer_Checked")
			);

			bool success = fpTest_NativeFunctionPointer_Checked(fpNativeCallback, 4) == 8;
			LogTest(success, L"Test_NativeFunctionPointer_Checked");

			// end-snippet
			ret &= success;
		}

		{ // unchecked function pointer call
			// begin-snippet: Test_NativeFunctionPointer_CallbackFunc_Unchecked_CPP
			
			auto fpTest_NativeFunctionPointer_Unchecked = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeFunctionPointer"),
				STR("Test_NativeFunctionPointer_Unchecked")
			);

			bool success = fpTest_NativeFunctionPointer_Unchecked(fpNativeCallback, 4) == 8;
			LogTest(success, L"Test_NativeFunctionPointer_Unchecked");

			// end-snippet
			ret &= success;
		}

		return ret;
	}
}