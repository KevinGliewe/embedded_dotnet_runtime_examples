#pragma once

#include "Common.h"

namespace Test_ManagedEntryPoint
{
	// begin-snippet: Test_ManagedEntryPoint_Args_CPP
	struct args
	{
		int number1;
		int number2;
	};
	// end-snippet
	
	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		std::wcout << "Test_ManagedEntryPoint: " << std::endl;

		args _args {1, 2};

		{ // COMPONENT entry point
			// begin-snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CPP

			auto fpTest_ComponentEntryPoint = a_lib.GetComponentEntrypoint(
				STR("LibNamespace.Test_ManagedEntryPoint"),
				STR("Test_ComponentEntryPoint")
			);

			bool success = fpTest_ComponentEntryPoint(&_args, sizeof(_args)) == 3;
			LogTest(success, L"Test_ComponentEntryPoint");

			// end-snippet
			ret &= success;
		}
		

		{ // CUSTOM entry point
			// begin-snippet: Test_ManagedEntryPoint_CustomEntryPoint_CPP			

			typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(args);
			
			auto fpTest_CustomEntryPoint = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedEntryPoint"),
				STR("Test_CustomEntryPoint")
			);

			bool success = fpTest_CustomEntryPoint(_args) == 3;
			LogTest(success, L"Test_CustomEntryPoint");

			// end-snippet
			ret &= success;
		}
		

		return ret;
	}
}