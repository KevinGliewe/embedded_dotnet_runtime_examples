#pragma once

#include "Common.h"

// begin-snippet: Test_DllImport_Export_CPP
extern "C"
{
	int FEXPORT Test_DllImport_ExternC(int number)
	{
		return number * 2;
	}
}
// end-snippet

namespace Test_DllImport
{

	bool Run(dotnet_runtime::Library& a_lib)
	{

		typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(void*, int);

		auto fpTest_DllImport_Call = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
			STR("LibNamespace.Test_DllImport"),
			STR("Test_DllImport_Call")
		);

		// begin-snippet: Test_DllImport_Call_CPP
		void* host_handle = dotnet_runtime::get_host_handle();
		return fpTest_DllImport_Call(host_handle, 4) == 8;
		// end-snippet
	}
}