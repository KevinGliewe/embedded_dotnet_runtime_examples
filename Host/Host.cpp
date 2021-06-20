// Host.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include <iostream>

# define DOTNET_RUNTIME_VERSION "5.0.3"

#include "dotnet_runtime.h"
#include <fstream>

#define STR DOTNET_RUNTIME_STR
#define DIR_SEPARATOR DOTNET_RUNTIME_DIR_SEPARATOR

#ifdef WIN32
# define FEXPORT __declspec(dllexport)
#else
# define FEXPORT // empty
#endif
using wstring_t = std::basic_string<wchar_t>;
struct lib_args
{
    const char_t *message;
    int number;
    void* fpCallback;
    char returnMsg[512];
    wstring_t setMsg;
};


extern "C"
{
    void FEXPORT ExeFn( const wchar_t* msg )
    {
        std::wcout << L"Hello from C++ " << msg << std::endl;
    }
}

extern "C"
{
    void FEXPORT SetArgsMsg(lib_args* args, const wchar_t* msg )
    {
        //std::wcout << L"SetArgsMsg \"" << msg << "\"" << std::endl;

        args->setMsg = wstring_t(msg);
    }
}

int CallbackFunc(int i)
{
    std::cout << "Callback called with i=" << i << std::endl;
    return i * 2;
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
            STR("from host!"),
            i
        };

        hello(&args, sizeof(args));

        std::wcout << (wchar_t*)&args.returnMsg << std::endl;

        std::wcout << args.setMsg.c_str() << std::endl;
        std::cout << "args.number = " << args.number << std::endl;
        std::cout << "args.fpCallback = " << args.fpCallback << std::endl;
        std::cout << "args.fpCallback(1) = " << ((int (*)(int ))args.fpCallback)(1) << std::endl;
    }


    // Custom entry point

    typedef void (CORECLR_DELEGATE_CALLTYPE *custom_entry_point_fn)(lib_args args);

    auto custom = (custom_entry_point_fn)lib.GetCustomEntrypoint(
        STR("LibNamespace.LibClass"),
        STR("CustomEntryPointUnmanaged")
    );

    lib_args args
    {
        STR("from host!"),
        -1
    };
    custom(args);

    std::cout << "args.number = " << args.number << std::endl;

    auto functionPointerCallback = lib.GetComponentEntrypoint(
        STR("LibNamespace.LibClass"),
        STR("FunctionPointerCallback")
    );

    functionPointerCallback((void*)&CallbackFunc, sizeof(int));

    return EXIT_SUCCESS;
}