#pragma once

#include "Common.h"

namespace Test_ManagedFunctionPointer
{
	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		// begin-snippet: Test_ManagedFunctionPointer_Typedef_managed_callback_fn_CPP
		typedef int (*managed_callback_fn)(int);
		// end-snippet

		{ // instance
			// begin-snippet: Test_ManagedFunctionPointer_Instance_CPP

			typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(int);

			// Get the managed entry point
			auto fpTest_ManagedFunctionPointer_Instance = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedFunctionPointer"),
				STR("Test_ManagedFunctionPointer_Instance")
			);

			// Get the function pointer to the managed method
			managed_callback_fn managedCallback = (managed_callback_fn)fpTest_ManagedFunctionPointer_Instance(2);
			
			bool success = managedCallback(6) == 8;
			
			LogTest(success, L"Test_ManagedFunctionPointer_Instance");

			// end-snippet
			ret &= success;
		}

		{ // static
			// begin-snippet: Test_ManagedFunctionPointer_Static_CPP

			typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)();
			
			// Get the managed entry point
			auto fpTest_ManagedFunctionPointer_Static = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedFunctionPointer"),
				STR("Test_ManagedFunctionPointer_Static")
			);

			// Get the function pointer to the managed function
			managed_callback_fn managedCallback = (managed_callback_fn)fpTest_ManagedFunctionPointer_Static();

			bool success = managedCallback(5) == 8;

			LogTest(success, L"Test_ManagedFunctionPointer_Static");

			// end-snippet
			ret &= success;
		}

		return ret;
	}
}
