#pragma once

#include "Common.h"

namespace Test_ManagedFunctionPointer
{
	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		typedef int (*managed_callback_fn)(int);

		{ // instance

			typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(int);

			
			auto fpTest_ManagedFunctionPointer_Instance = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedFunctionPointer"),
				STR("Test_ManagedFunctionPointer_Instance")
			);

			managed_callback_fn managedCallback = (managed_callback_fn)fpTest_ManagedFunctionPointer_Instance(2);
			
			bool success = managedCallback(6) == 8;
			
			LogTest(success, L"Test_ManagedFunctionPointer_Instance");

			ret &= success;
		}

		{ // static

			typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)();
			
			auto fpTest_ManagedFunctionPointer_Static = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedFunctionPointer"),
				STR("Test_ManagedFunctionPointer_Static")
			);

			managed_callback_fn managedCallback = (managed_callback_fn)fpTest_ManagedFunctionPointer_Static();

			bool success = managedCallback(5) == 8;

			LogTest(success, L"Test_ManagedFunctionPointer_Static");

			ret &= success;
		}

		return ret;
	}
}
