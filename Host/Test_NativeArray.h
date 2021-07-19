#pragma once

#include "Common.h"

namespace Test_NativeArray
{
	// begin-snippet: Test_NativeArray_Args_CPP
	struct args
	{
		int Arr[8];
		int Multiplier;
	};
	// end-snippet

	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		// begin-snippet: Test_NativeArray_Args_Data_CPP
		args _args{
			1, 2, 3, 4, 5, 6, 7, 8, // Arr[8]
			2 // Multiplier
		};
		// end-snippet

		{ // StructFixed
			// begin-snippet: Test_NativeArray_StructFixed_CPP

			typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(args);
			
			auto fpTest_NativeArray_StructFixed = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeArray"),
				STR("Test_NativeArray_StructFixed")
			);

			bool success = fpTest_NativeArray_StructFixed(_args) == 72;
			LogTest(success, L"Test_NativeArray_StructFixed");

			// end-snippet
			ret &= success;
		}


		{ // ArgumentFixed
			// begin-snippet: Test_NativeArray_ArgumentFixed_CPP

			typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(int[], int);

			auto fpTest_NativeArray_ArgumentFixed = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeArray"),
				STR("Test_NativeArray_ArgumentFixed")
			);

			bool success = fpTest_NativeArray_ArgumentFixed(_args.Arr, _args.Multiplier) == 72;
			LogTest(success, L"Test_NativeArray_ArgumentFixed");

			// end-snippet
			ret &= success;
		}

		{ // ArgumentFixed FunctionPointer
			// begin-snippet: Test_NativeArray_ArgumentFixed_FunctionPointer_CPP

			typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)();
			typedef int (*managed_callback_fn)(int[], int);

			auto fpTest_NativeArray_ArgumentFixed_FunctionPointer = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeArray"),
				STR("Test_NativeArray_ArgumentFixed_FunctionPointer")
			);

			managed_callback_fn callback = (managed_callback_fn)fpTest_NativeArray_ArgumentFixed_FunctionPointer();

			bool success = callback(_args.Arr, _args.Multiplier) == 72;
			LogTest(success, L"Test_NativeArray_ArgumentFixed_FunctionPointer");

			// end-snippet
			ret &= success;
		}


		return ret;
	}
}
