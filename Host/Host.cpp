// Host.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include <iostream>

#include "dotnet_runtime.h"
#include <fstream>

extern "C"
{
    void __declspec( dllexport ) ExeFn( const char_t* msg )
    {
        std::wcout << L"Hello from C++ " << msg << std::endl;
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
    ExeFn(L"C++");

    for(int i = 0; i < argc; i++)
        std::wcout << "argv[" << i << "] = " << argv[i] << std::endl;

    if(argc < 2)
        return 1;

    string_t root_path = string_t(argv[1]) + DOTNET_RUNTIME_STR("dotnet_runtime") DOTNET_RUNTIME_DIR_SEPARATOR;
    //string_t hostfxr_path = L"C:\\Program Files\\dotnet\\host\\fxr\\5.0.3\\hostfxr.dll";//root_path + DOTNET_RUNTIME_PATH_HOSTFXR;
    string_t hostfxr_path = root_path + DOTNET_RUNTIME_PATH_HOSTFXR;

    string_t lib_path = string_t(argv[1]) +
        DOTNET_RUNTIME_DIR_SEPARATOR
        DOTNET_RUNTIME_STR("bin")
        DOTNET_RUNTIME_DIR_SEPARATOR
        DOTNET_RUNTIME_STR("Lib")
        DOTNET_RUNTIME_DIR_SEPARATOR
        DOTNET_RUNTIME_STR("net5.0")
        DOTNET_RUNTIME_DIR_SEPARATOR;

    string_t libDll_path = lib_path + DOTNET_RUNTIME_STR("Lib.dll");
    string_t libRuntimeconfig_path = lib_path + DOTNET_RUNTIME_STR("Lib.runtimeconfig.json");

    const char_t *dotnet_type = DOTNET_RUNTIME_STR("LibNamespace.LibClass, Lib");
    const char_t *dotnet_type_method = DOTNET_RUNTIME_STR("Hello");

    std::wcout << "root_path             = " << root_path << std::endl;
    std::wcout << "hostfxr_path          = " << hostfxr_path << std::endl;
    std::wcout << "lib_path              = " << lib_path << std::endl;
    std::wcout << "libDll_path           = " << libDll_path << std::endl;
    std::wcout << "libRuntimeconfig_path = " << libRuntimeconfig_path << std::endl;
    std::wcout << "dotnet_type           = " << dotnet_type << std::endl;
    std::wcout << "dotnet_type_method    = " << dotnet_type_method << std::endl;

    assert(exists(hostfxr_path));
    assert(exists(libDll_path));
    assert(exists(libRuntimeconfig_path));

    void* host_handle = dotnet_runtime::get_host_handle();

    std::wcout << "host_handle           = " << host_handle << std::endl;

    void* lib = dotnet_runtime::load_library(hostfxr_path);

    auto init_fptr = (hostfxr_initialize_for_runtime_config_fn)dotnet_runtime::get_export(lib, "hostfxr_initialize_for_runtime_config");
    auto get_delegate_fptr = (hostfxr_get_runtime_delegate_fn)dotnet_runtime::get_export(lib, "hostfxr_get_runtime_delegate");
    auto close_fptr = (hostfxr_close_fn)dotnet_runtime::get_export(lib, "hostfxr_close");

    hostfxr_handle cxt = nullptr;
    int rc = init_fptr(libRuntimeconfig_path.c_str(), nullptr, &cxt);
    if (rc != 0 || cxt == nullptr)
    {
        std::cerr << "Init failed: " << std::hex << std::showbase << rc << std::endl;
        close_fptr(cxt);
        return 1;
    }

    void *load_assembly_and_get_function_pointer_ = nullptr;

    // Get the load assembly function pointer
    rc = get_delegate_fptr(
        cxt,
        hdt_load_assembly_and_get_function_pointer,
        &load_assembly_and_get_function_pointer_);
    if (rc != 0 || load_assembly_and_get_function_pointer_ == nullptr)
        std::cerr << "Get delegate failed: " << std::hex << std::showbase << rc << std::endl;

    auto load_assembly_and_get_function_pointer = (load_assembly_and_get_function_pointer_fn)load_assembly_and_get_function_pointer_;

        // Function pointer to managed delegate
    component_entry_point_fn setHostHandle = nullptr;
    rc = load_assembly_and_get_function_pointer(
        libDll_path.c_str(),
        dotnet_type,
        DOTNET_RUNTIME_STR("SetHostHandle"),
        nullptr /*delegate_type_name*/,
        nullptr,
        (void**)&setHostHandle);
    assert(rc == 0 && setHostHandle != nullptr && "Failure: load_assembly_and_get_function_pointer()");

    {
        struct lib_args1
        {
            void* host_handle;
        };

        lib_args1 args
        {
            host_handle
        };

        setHostHandle(&args, sizeof(args));
    }

    // Function pointer to managed delegate
    component_entry_point_fn hello = nullptr;
    rc = load_assembly_and_get_function_pointer(
        libDll_path.c_str(),
        dotnet_type,
        dotnet_type_method,
        nullptr /*delegate_type_name*/,
        nullptr,
        (void**)&hello);

    assert(rc == 0 && hello != nullptr && "Failure: load_assembly_and_get_function_pointer()");
    
    struct lib_args
    {
        const char_t *message;
        int number;
    };
    for (int i = 0; i < 3; ++i)
    {
        // <SnippetCallManaged>
        lib_args args
        {
            DOTNET_RUNTIME_STR("from host!"),
            i
        };

        hello(&args, sizeof(args));
        // </SnippetCallManaged>
    }

    typedef void (CORECLR_DELEGATE_CALLTYPE *custom_entry_point_fn)(lib_args args);
    custom_entry_point_fn custom = nullptr;
    rc = load_assembly_and_get_function_pointer(
        libDll_path.c_str(),
        dotnet_type,
        DOTNET_RUNTIME_STR("CustomEntryPointUnmanaged") /*method_name*/,
        UNMANAGEDCALLERSONLY_METHOD,
        nullptr,
        (void**)&custom);
    assert(rc == 0 && custom != nullptr && "Failure: load_assembly_and_get_function_pointer()");

    lib_args args
    {
        DOTNET_RUNTIME_STR("from host!"),
        -1
    };
    custom(args);

    return EXIT_SUCCESS;
}