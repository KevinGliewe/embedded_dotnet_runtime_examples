#pragma once

#include "Common.h"

namespace Test_NativeArray
{
	struct args
	{
		int Arr[8];
		int Multiplier;
	};

	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		args _args{
			1, 2, 3, 4, 5, 6, 7, 8,
			2
		};

		{ // StructFixed

			typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(args);
			
			auto fpTest_NativeArray_StructFixed = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeArray"),
				STR("Test_NativeArray_StructFixed")
			);

			bool success = fpTest_NativeArray_StructFixed(_args) == 72;
			LogTest(success, "Test_NativeArray_StructFixed");

			ret &= success;
		}


		{ // ArgumentFixed

			typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(int[], int);

			auto fpTest_NativeArray_ArgumentFixed = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeArray"),
				STR("Test_NativeArray_ArgumentFixed")
			);

			bool success = fpTest_NativeArray_ArgumentFixed(_args.Arr, _args.Multiplier) == 72;
			LogTest(success, "Test_NativeArray_ArgumentFixed");

			ret &= success;
		}

		{ // ArgumentFixed FunctionPointer

			typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)();
			typedef int (*managed_callback_fn)(int[], int);

			auto fpTest_NativeArray_ArgumentFixed_FunctionPointer = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeArray"),
				STR("Test_NativeArray_ArgumentFixed_FunctionPointer")
			);

			managed_callback_fn callback = (managed_callback_fn)fpTest_NativeArray_ArgumentFixed_FunctionPointer();

			bool success = callback(_args.Arr, _args.Multiplier) == 72;
			LogTest(success, "Test_NativeArray_ArgumentFixed_FunctionPointer");

			ret &= success;
		}


		return ret;
	}
}
