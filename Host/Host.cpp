// Host.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include <iostream>

#include "dotnet_runtime.h"
#include <fstream>

#define STR DOTNET_RUNTIME_STR
#define DIR_SEPARATOR DOTNET_RUNTIME_DIR_SEPARATOR

struct lib_args
{
    char_t *returnMsg;
    const char_t *message;
    int number;
    string_t setMsg;
};


extern "C"
{
    void __declspec( dllexport ) ExeFn( const char_t* msg )
    {
        std::wcout << L"Hello from C++ " << msg << std::endl;
    }
}

extern "C"
{
    void __declspec( dllexport ) SetArgsMsg(lib_args* args, const char_t* msg )
    {
        std::wcout << L"SetArgsMsg " << msg << std::endl;
        args->setMsg = string_t(msg);
    }
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

    std::cout << "sizeof(lib_args) = " << sizeof(lib_args) << std::endl;

    for(int i = 0; i < argc; i++)
        std::wcout << "argv[" << i << "] = " << argv[i] << std::endl;

    if(argc < 2)
        return 1;

    string_t root_path = string_t(argv[1]) + STR("dotnet_runtime") DIR_SEPARATOR;
    //string_t hostfxr_path = L"C:\\Program Files\\dotnet\\host\\fxr\\5.0.3\\hostfxr.dll";//root_path + DOTNET_RUNTIME_PATH_HOSTFXR;
    string_t hostfxr_path = root_path + DOTNET_RUNTIME_PATH_HOSTFXR;

    string_t lib_path = string_t(argv[1]) +
        DIR_SEPARATOR
        STR("bin")
        DIR_SEPARATOR
        STR("Lib")
        DIR_SEPARATOR
        STR("net5.0")
        DIR_SEPARATOR;

    string_t libDll_path = lib_path + STR("Lib.dll");
    string_t libRuntimeconfig_path = lib_path + STR("Lib.runtimeconfig.json");


    std::wcout << "root_path             = " << root_path << std::endl;
    std::wcout << "hostfxr_path          = " << hostfxr_path << std::endl;
    std::wcout << "lib_path              = " << lib_path << std::endl;
    std::wcout << "libDll_path           = " << libDll_path << std::endl;
    std::wcout << "libRuntimeconfig_path = " << libRuntimeconfig_path << std::endl;

    assert(exists(hostfxr_path));
    assert(exists(libDll_path));
    assert(exists(libRuntimeconfig_path));

    void* host_handle = dotnet_runtime::get_host_handle();

    std::wcout << "host_handle           = " << host_handle << std::endl;


    // Init runtime and lib

    auto runtime = dotnet_runtime::Runtime(hostfxr_path, libRuntimeconfig_path);

    auto lib = dotnet_runtime::Library(&runtime, libDll_path, STR("Lib"));


    // Set host handle for callback

    auto setHostHandle = lib.GetComponentEntrypoint(
        STR("LibNamespace.LibClass"),
        STR("SetHostHandle")
    );
    setHostHandle(host_handle, sizeof(host_handle));


    // Component entry point

    auto hello = lib.GetComponentEntrypoint(
        STR("LibNamespace.LibClass"),
        STR("Hello")
    );

    for (int i = 0; i < 3; ++i)
    {
        lib_args args
        {
            nullptr,
            STR("from host!"),
            i
        };

        hello(&args, sizeof(args));

        if(args.returnMsg)
        {
            std::wcout << args.returnMsg << std::endl;
        }

        std::wcout << args.setMsg << std::endl;
        std::cout << "args.number = " << args.number << std::endl;
    }


    // Custom entry point

    typedef void (CORECLR_DELEGATE_CALLTYPE *custom_entry_point_fn)(lib_args args);

    auto custom = (custom_entry_point_fn)lib.GetCustomEntrypoint(
        STR("LibNamespace.LibClass"),
        STR("CustomEntryPointUnmanaged")
    );

    lib_args args
    {
        nullptr,
        STR("from host!"),
        -1
    };
    custom(args);

    std::cout << "args.number = " << args.number << std::endl;

    return EXIT_SUCCESS;
}