#pragma once

#include "Common.h"

namespace Test_ManagedEntryPoint
{
	struct args
	{
		int number1;
		int number2;
	};
	
	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		args _args {1, 2};

		{ // COMPONENT entry point
			
			auto fpTest_ComponentEntryPoint = a_lib.GetComponentEntrypoint(
				STR("LibNamespace.Test_ManagedEntryPoint"),
				STR("Test_ComponentEntryPoint")
			);

			bool success = fpTest_ComponentEntryPoint(&_args, sizeof(_args)) == 3;
			LogTest(success, "Test_ComponentEntryPoint");

			ret &= success;
		}
		

		{ // CUSTOM entry point

			typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(args);
			
			auto fpTest_CustomEntryPoint = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedEntryPoint"),
				STR("Test_CustomEntryPoint")
			);

			bool success = fpTest_CustomEntryPoint(_args) == 3;
			LogTest(success, "Test_CustomEntryPoint");

			ret &= success;
		}
		

		return ret;
	}
}