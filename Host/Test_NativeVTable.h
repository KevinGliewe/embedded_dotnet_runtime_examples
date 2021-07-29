#pragma once

#include "Common.h"


namespace Test_NativeVTable
{
	// begin-snippet: Test_NativeVTable_Class_CPP
	class ClassLayout
	{
	private:
		int m_iTest = 0;
	public:
		virtual void AddOne() { this->m_iTest += 1; }
		virtual void AddTwo() { this->m_iTest += 2; }

		int GetTest() { return m_iTest; }
	};
	// end-snippet
	

	bool Run(dotnet_runtime::Library& a_lib)
	{
		bool ret = true;
		bool success = false;
		
		typedef void (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(void*);

		auto fpTest_NativeVTable_Call = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
			STR("LibNamespace.Test_NativeVTable"),
			STR("Test_NativeVTable_Call")
		);

		// begin-snippet: Test_NativeVTable_Call_CPP
		ClassLayout* instance = new ClassLayout();

		// Calls AddOne and AddTwo, then overwrites VTable
		fpTest_NativeVTable_Call((void*)instance);
		// end-snippet

		success = instance->GetTest() == 3;
		LogTest(success, L"Test_NativeVTable_Call.ManagedCall");

		ret &= success;


		instance->AddOne(); // Calls delegate_SubOne
		instance->AddTwo(); // Calls delegate_SubOne

		success = instance->GetTest() == 1;
		LogTest(success, L"Test_NativeVTable_Call.ManagedOverwrite");

		ret &= success;

		return ret;
	}
}