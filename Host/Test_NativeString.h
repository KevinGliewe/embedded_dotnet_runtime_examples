#pragma once

#include "Common.h"

namespace Test_NativeString
{
	// begin-snippet: Test_NativeString_RetArgs_CPP 
	struct RetArgs
	{
		bool (*CallbackAnsi)(const char*);
		bool (*CallbackWide)(const wchar_t*);
	};
	// end-snippet
	
	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;
		
		typedef bool (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(void*);

		{ // Ansi
			// begin-snippet: Test_NativeString_Ansi_CPP

			auto fpTest_NativeString_Ansi = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeString"),
				STR("Test_NativeString_Ansi")
			);

			bool success = fpTest_NativeString_Ansi((void*)"Hello Ansi");
			LogTest(success, L"Test_NativeString_Ansi");

			// end-snippet
			ret &= success;
		}

		{ // Wide
			// begin-snippet: Test_NativeString_Wide_CPP

			auto fpTest_NativeString_Wide = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeString"),
				STR("Test_NativeString_Wide")
			);

			bool success = fpTest_NativeString_Wide((void*)L"Hello ❤");
			LogTest(success, L"Test_NativeString_Wide");

			// end-snippet
			ret &= success;
		}

		{ // function pointer
			// begin-snippet: Test_NativeString_FunctionPointer_CPP

			typedef void (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn2)(void*);
			
			auto fpTest_NativeString_FunctionPointer = (custom_entry_point_fn2)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeString"),
				STR("Test_NativeString_FunctionPointer")
			);

			RetArgs retArgs;
			fpTest_NativeString_FunctionPointer(&retArgs);

			{ // Ansi
				bool success = retArgs.CallbackAnsi("Hello Ansi");
				LogTest(success, L"Test_NativeString_FunctionPointer.CallbackAnsi");

				ret &= success;
			}
			
			{ // Wide
				bool success = retArgs.CallbackWide(L"Hello ❤");
				LogTest(success, L"Test_NativeString_FunctionPointer.CallbackWide");

				ret &= success;
			}

			// end-snippet
		}

		return ret;
	}
}
