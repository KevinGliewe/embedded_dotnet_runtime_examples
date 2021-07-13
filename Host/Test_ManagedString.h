#pragma once

#pragma once

#include "Common.h"

namespace Test_ManagedString
{
	
	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;

		typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)();

		{ // Ansi

			auto fpTest_ManagedString_Ansi = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedString"),
				STR("Test_ManagedString_Ansi")
			);

			char* str = (char*)fpTest_ManagedString_Ansi();
			bool success = cmp(str, (char*)"Hello Ansi");
			
			LogTest(success, "Test_ManagedString_Ansi");

			ret &= success;
		}

		{ // Wide

			auto fpTest_ManagedString_Wide = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedString"),
				STR("Test_ManagedString_Wide")
			);

			wchar_t* str = (wchar_t*)fpTest_ManagedString_Wide();
			bool success = cmp(str, (wchar_t*)L"Hello ❤");
			LogTest(success, "Test_ManagedString_Wide");

			ret &= success;
		}

		return ret;
	}
}
