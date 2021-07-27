#pragma once

#include "Common.h"

// begin-snippet: Test_NativeExport_Export_CPP
extern "C"
{
	int FEXPORT Test_NativeExport_ExternC(int number)
	{
		return number * 4;
	}
}
// end-snippet

namespace Test_NativeExport
{

	bool Run(dotnet_runtime::Library& a_lib)
	{

		typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(void*, int);

		auto fpTest_NativeExport_Call = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
			STR("LibNamespace.Test_NativeExport"),
			STR("Test_NativeExport_Call")
		);

		// begin-snippet: Test_NativeExport_Call_CPP
		void* host_handle = dotnet_runtime::get_host_handle();
		return fpTest_NativeExport_Call(host_handle, 4) == 16;
		// end-snippet
	}
}