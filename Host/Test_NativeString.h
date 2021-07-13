#pragma once

#include "Common.h"

namespace Test_NativeString
{
	struct RetArgs
	{
		bool (*CallbackAnsi)(const char*);
		bool (*CallbackWide)(const wchar_t*);
	};
	
	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;
		
		typedef bool (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(void*);

		{ // Ansi

			auto fpTest_NativeString_Ansi = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeString"),
				STR("Test_NativeString_Ansi")
			);

			bool success = fpTest_NativeString_Ansi((void*)"Hello Ansi");
			LogTest(success, "Test_NativeString_Ansi");

			ret &= success;
		}

		{ // Wide

			auto fpTest_NativeString_Wide = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeString"),
				STR("Test_NativeString_Wide")
			);

			bool success = fpTest_NativeString_Wide((void*)L"Hello ❤");
			LogTest(success, "Test_NativeString_Wide");

			ret &= success;
		}

		{ // function pointer
			typedef void (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn2)(void*);
			
			auto fpTest_NativeString_FunctionPointer = (custom_entry_point_fn2)a_lib.GetCustomEntrypoint(
				STR("LibNamespace.Test_NativeString"),
				STR("Test_NativeString_FunctionPointer")
			);

			RetArgs retArgs;
			fpTest_NativeString_FunctionPointer(&retArgs);

			{ // Ansi
				bool success = retArgs.CallbackAnsi("Hello Ansi");
				LogTest(success, "Test_NativeString_FunctionPointer.CallbackAnsi");

				ret &= success;
			}
			
			{ // Wide
				bool success = retArgs.CallbackWide(L"Hello ❤");
				LogTest(success, "Test_NativeString_FunctionPointer.CallbackWide");

				ret &= success;
			}
		}

		return ret;
	}
}
