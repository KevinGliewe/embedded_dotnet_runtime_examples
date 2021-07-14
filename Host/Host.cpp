// Host.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include <iostream>
#include <fstream>

# define DOTNET_RUNTIME_VERSION "5.0.3"

#include "Common.h"

#include "Test_ManagedEntryPoint.h"
#include "Test_NativeFunctionPointer.h"
#include "Test_ManagedFunctionPointer.h"
#include "Test_DllImport.h"
#include "Test_NativeArray.h"
#include "Test_NativeString.h"
#include "Test_ManagedString.h"
#include "Test_ManagedUnsafe.h"


#define RUN_TEST(TESTNAME) \
	try { \
		bool result = TESTNAME::Run(lib); \
        std::wcout << (result ? "OK" : "ERR"); \
	    std::wcout << L"\t" << #TESTNAME << std::endl; \
        success &= result;\
	} catch (const std::exception& e) { \
		std::wcout << "Exception during " << #TESTNAME << " '" << e.what() << "'\n"; \
	}


inline bool exists (string_t name) {
    std::ifstream f(name.c_str());
    return f.good();
}



#if defined(_WIN32)
int __cdecl wmain(int argc, wchar_t *argv[])
#else
int main(int argc, char *argv[])
#endif
{

    for(int i = 0; i < argc; i++)
        std::wcout << "argv[" << i << "] = " << argv[i] << std::endl;

    string_t root_repo =
            argc > 1 ?
                argv[1] :
                STR("/Users/kevingliewe/Documents/prog/dotnet/dotnet_runtime_test/");

    string_t root_path = root_repo + STR("dotnet_runtime") DIR_SEPARATOR;
    //string_t hostfxr_path = L"C:\\Program Files\\dotnet\\host\\fxr\\5.0.3\\hostfxr.dll";//root_path + DOTNET_RUNTIME_PATH_HOSTFXR;
    string_t hostfxr_path = root_path + DOTNET_RUNTIME_PATH_HOSTFXR;

    string_t lib_path = root_repo +
        DIR_SEPARATOR
        STR("bin")
        DIR_SEPARATOR
        STR("Lib")
        DIR_SEPARATOR
        STR("net5.0")
        DIR_SEPARATOR;

    string_t libDll_path = lib_path + STR("Lib.dll");
    string_t libRuntimeconfig_path = lib_path + STR("Lib.runtimeconfig.json");


    std::wcout << "root_path             = " << root_path.c_str() << std::endl;
    std::wcout << "hostfxr_path          = " << hostfxr_path.c_str() << std::endl;
    std::wcout << "lib_path              = " << lib_path.c_str() << std::endl;
    std::wcout << "libDll_path           = " << libDll_path.c_str() << std::endl;
    std::wcout << "libRuntimeconfig_path = " << libRuntimeconfig_path.c_str() << std::endl;

    assert(exists(hostfxr_path));
    assert(exists(libDll_path));
    assert(exists(libRuntimeconfig_path));

    void* host_handle = dotnet_runtime::get_host_handle();

    std::wcout << "host_handle           = " << host_handle << std::endl;

    // begin-snippet: InitRuntimeAndLib
    // Init runtime and lib

    auto runtime = dotnet_runtime::Runtime(hostfxr_path, libRuntimeconfig_path);

    auto lib = dotnet_runtime::Library(&runtime, libDll_path, STR("Lib"));
    // end-snippet

    // Running tests

    bool success = true;
    RUN_TEST(Test_ManagedEntryPoint);
    RUN_TEST(Test_NativeFunctionPointer);
    RUN_TEST(Test_ManagedFunctionPointer);
    RUN_TEST(Test_NativeArray);
    RUN_TEST(Test_NativeString);
    RUN_TEST(Test_ManagedString);
    RUN_TEST(Test_ManagedUnsafe);
	
#ifdef WIN32
    RUN_TEST(Test_DllImport);
#endif
	

    std::wcout << "Success: " << (success ? "true" : "false") << std::endl;

    return success ? EXIT_SUCCESS : EXIT_FAILURE;
}