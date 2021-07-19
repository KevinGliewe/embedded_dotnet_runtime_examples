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
			// begin-snippet: Test_ManagedString_Ansi_CPP

			auto fpTest_ManagedString_Ansi = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedString"),
				STR("Test_ManagedString_Ansi")
			);

			char* str = (char*)fpTest_ManagedString_Ansi();

			// Compare the ASCII strings
			bool success = cmp(str, (char*)"Hello Ansi");
			
			LogTest(success, L"Test_ManagedString_Ansi");

			// end-snippet
			ret &= success;
		}

		{ // Wide
			// begin-snippet: Test_ManagedString_Wide_CPP
			
			auto fpTest_ManagedString_Wide = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_ManagedString"),
				STR("Test_ManagedString_Wide")
			);

			wchar_t* str = (wchar_t*)fpTest_ManagedString_Wide();

			// Compare the wide strings
			bool success = cmp(str, (wchar_t*)L"Hello ❤");
			
			LogTest(success, L"Test_ManagedString_Wide");

			// end-snippet
			ret &= success;
		}

		return ret;
	}
}
