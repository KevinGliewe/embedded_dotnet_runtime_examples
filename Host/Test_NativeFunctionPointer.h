#pragma once

#include "Common.h"


namespace Test_NativeFunctionPointer
{

	int FEXPORT CallbackFunc(int i)
	{
		return i * 2;
	}

	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(void*, int);

		void* fpNativeCallback = (void*)&CallbackFunc;

		{ // checked function pointer to delegate

			auto fpTest_NativeFunctionPointer_Checked = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeFunctionPointer"),
				STR("Test_NativeFunctionPointer_Checked")
			);

			bool success = fpTest_NativeFunctionPointer_Checked(fpNativeCallback, 4) == 8;
			LogTest(success, L"Test_NativeFunctionPointer_Checked");

			ret &= success;
		}

		{ // unchecked function pointer call

			auto fpTest_NativeFunctionPointer_Unchecked = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeFunctionPointer"),
				STR("Test_NativeFunctionPointer_Unchecked")
			);

			bool success = fpTest_NativeFunctionPointer_Unchecked(fpNativeCallback, 4) == 8;
			LogTest(success, L"Test_NativeFunctionPointer_Unchecked");

			ret &= success;
		}

		return ret;
	}
}