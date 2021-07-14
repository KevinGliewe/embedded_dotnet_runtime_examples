#pragma once

#include "Common.h"

namespace Test_ManagedUnsafe
{
	struct Args
	{
		int number1;
		int number2;
		int sum;
		char returnMsg[128];
	};


	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		typedef void (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(void*);

		auto fpTest_ManagedUnsafe_Struct = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
			STR("LibNamespace.Test_ManagedUnsafe"),
			STR("Test_ManagedUnsafe_Struct")
		);

		Args args;
		args.number1 = 1;
		args.number2 = 2;

		fpTest_ManagedUnsafe_Struct(&args);

		{ //sum
			bool success = args.sum == 3;
			LogTest(success, L"Test_ManagedUnsafe_Struct.Sum");
			ret &= success;
		}

		{ // ReturnMsg
			bool success = cmp(args.returnMsg, (char*)"Hello Ansi");
			LogTest(success, L"Test_ManagedUnsafe_Struct.ReturnMsg");
			ret &= success;
		}

		

		return ret;
	}
}
