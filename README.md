<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /README.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->


<div align="center">
  <h1>Embedded .NET Runtime</h1>
  <a href="https://github.com/KevinGliewe/dotnet_runtime_test/actions"><img alt="Build and Test" src="https://github.com/KevinGliewe/dotnet_runtime_test/workflows/Build%20and%20Test/badge.svg?branch=master"/></a>
</div>

This repo contains a project with examples for using a embedded .NET runtime in a C++ application using [dotnet_runtime](https://github.com/KevinGliewe/dotnet_runtime).

<!--ts-->
* [Embedded .NET Runtime](#embedded-net-runtime)
* [Build and Run](#build-and-run)
   * [Windows](#windows)
      * [Requirements](#requirements)
      * [Steps](#steps)
      * [What happens during the build?](#what-happens-during-the-build)
   * [Linux](#linux)
      * [Requirements](#requirements-1)
      * [Steps](#steps-1)
      * [What happens during the build?](#what-happens-during-the-build-1)
* [Examples](#examples)
   * [Load and initialize .NET runtime](#load-and-initialize-net-runtime)
   * [Managed component-entrypoint](#managed-component-entrypoint)
   * [Managed custom-entrypoint](#managed-custom-entrypoint)
   * [Managed function-pointer to instance method](#managed-function-pointer-to-instance-method)
   * [Managed function-pointer to static function](#managed-function-pointer-to-static-function)
   * [Return managed ASCII string](#return-managed-ascii-string)
   * [Return managed wide string](#return-managed-wide-string)
   * [Usage of unsafe managed code to access native objects](#usage-of-unsafe-managed-code-to-access-native-objects)
   * [Native arrays using fixed struct member](#native-arrays-using-fixed-struct-member)
   * [Native arrays using pointer](#native-arrays-using-pointer)
   * [Native arrays using ArrPointerX on function-pointer](#native-arrays-using-arrpointerx-on-function-pointer)
   * [Calling checked native function pointer](#calling-checked-native-function-pointer)
   * [Calling unchecked native function pointer](#calling-unchecked-native-function-pointer)
   * [Native ASCII string](#native-ascii-string)
   * [Native Wide string](#native-wide-string)
   * [Native string to managed function pointer](#native-string-to-managed-function-pointer)
* [LICENSE](#license)
<!--te-->

# Build and Run

## Windows

### Requirements

 * Visual Studio 2019
 * .NET 5 SDK

### Steps

 1. Clone this repository recursively using
    `git clone --recursive git@github.com:KevinGliewe/embedded_dotnet_runtime_examples.git`
 2. Run `build_run.bat`

### What happens during the build?
 
 * Import `VsDevCmd.bat`
 * Install dotnet tool [`runtimedl`](https://github.com/KevinGliewe/dotnet_runtime/tree/runtimedl-tool)
 * Download the propper .NET 5 runtime for your system using [`runtimedl`](https://github.com/KevinGliewe/dotnet_runtime/tree/runtimedl-tool)
 * Build `Lib` and `Host` using MSBuild
 * Run `Host`

## Linux

### Requirements

 * CMake 3.16 or newer
 * .NET 5 SDK

### Steps

 1. Clone this repository recursively using
    `git clone --recursive git@github.com:KevinGliewe/dotnet_runtime_test.git`
 2. Run `sh build_run.sh`

### What happens during the build?

 * Install dotnet tool [`runtimedl`](https://github.com/KevinGliewe/dotnet_runtime/tree/runtimedl-tool)
 * Download the propper .NET 5 runtime for your system using [`runtimedl`](https://github.com/KevinGliewe/dotnet_runtime/tree/runtimedl-tool)
 * Build `Lib` using .NET 5 SDK
 * Create makefile using CMake
 * Build `Host` using make
 * Run `Host`

# Examples

## Load and initialize .NET runtime

<!-- snippet: InitRuntimeAndLib -->
<a id='snippet-initruntimeandlib'></a>
```cpp
// Init runtime and lib

auto runtime = dotnet_runtime::Runtime(hostfxr_path, libRuntimeconfig_path);

auto lib = dotnet_runtime::Library(&runtime, libDll_path, STR("Lib"));
```
<sup><a href='/Host/Host.cpp#L85-L91' title='Snippet source file'>snippet source</a> | <a href='#snippet-initruntimeandlib' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Managed component-entrypoint

> Entrypoints can only use [blittable types](https://en.wikipedia.org/wiki/Blittable_types)

**Native**

<!-- snippet: Test_ManagedEntryPoint_Args_CPP -->
<a id='snippet-test_managedentrypoint_args_cpp'></a>
```h
struct args
{
	int number1;
	int number2;
};
```
<sup><a href='/Host/Test_ManagedEntryPoint.h#L7-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedentrypoint_args_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CPP -->
<a id='snippet-test_managedentrypoint_componententrypoint_cpp'></a>
```h
auto fpTest_ComponentEntryPoint = a_lib.GetComponentEntrypoint(
	STR("LibNamespace.Test_ManagedEntryPoint"),
	STR("Test_ComponentEntryPoint")
);

bool success = fpTest_ComponentEntryPoint(&_args, sizeof(_args)) == 3;
LogTest(success, L"Test_ComponentEntryPoint");
```
<sup><a href='/Host/Test_ManagedEntryPoint.h#L24-L34' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedentrypoint_componententrypoint_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_ManagedEntryPoint_Args_CS -->
<a id='snippet-test_managedentrypoint_args_cs'></a>
```cs
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Args
{
    public int Number1;
    public int Number2;
}
```
<sup><a href='/Lib/Test_ManagedEntryPoint.cs#L9-L16' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedentrypoint_args_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

> Component-entrypoints always have this signature: `static int <NAME>(IntPtr, int)`

<!-- snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CS -->
<a id='snippet-test_managedentrypoint_componententrypoint_cs'></a>
```cs
public static int Test_ComponentEntryPoint(IntPtr arg, int argLength)
{
    if (argLength < Marshal.SizeOf(typeof(Args)))
    {
        return 1;
    }

    Args args = Marshal.PtrToStructure<Args>(arg);

    return args.Number1 + args.Number2;
}
```
<sup><a href='/Lib/Test_ManagedEntryPoint.cs#L18-L30' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedentrypoint_componententrypoint_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Managed custom-entrypoint

> Entrypoints can only use [blittable types](https://en.wikipedia.org/wiki/Blittable_types)

**Native**

<!-- snippet: Test_ManagedEntryPoint_Args_CPP -->
<a id='snippet-test_managedentrypoint_args_cpp'></a>
```h
struct args
{
	int number1;
	int number2;
};
```
<sup><a href='/Host/Test_ManagedEntryPoint.h#L7-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedentrypoint_args_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_ManagedEntryPoint_CustomEntryPoint_CPP -->
<a id='snippet-test_managedentrypoint_customentrypoint_cpp'></a>
```h
typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(args);

auto fpTest_CustomEntryPoint = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_ManagedEntryPoint"),
	STR("Test_CustomEntryPoint")
);

bool success = fpTest_CustomEntryPoint(_args) == 3;
LogTest(success, L"Test_CustomEntryPoint");
```
<sup><a href='/Host/Test_ManagedEntryPoint.h#L40-L52' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedentrypoint_customentrypoint_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_ManagedEntryPoint_Args_CS -->
<a id='snippet-test_managedentrypoint_args_cs'></a>
```cs
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Args
{
    public int Number1;
    public int Number2;
}
```
<sup><a href='/Lib/Test_ManagedEntryPoint.cs#L9-L16' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedentrypoint_args_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_ManagedEntryPoint_CustomEntryPoint_CS -->
<a id='snippet-test_managedentrypoint_customentrypoint_cs'></a>
```cs
[UnmanagedCallersOnly]
public static int Test_CustomEntryPoint(Args args)
{
    return args.Number1 + args.Number2;
}
```
<sup><a href='/Lib/Test_ManagedEntryPoint.cs#L32-L38' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedentrypoint_customentrypoint_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Managed function-pointer to instance method

**Native**

<!-- snippet: Test_ManagedFunctionPointer_Typedef_managed_callback_fn_CPP -->
<a id='snippet-test_managedfunctionpointer_typedef_managed_callback_fn_cpp'></a>
```h
typedef int (*managed_callback_fn)(int);
```
<sup><a href='/Host/Test_ManagedFunctionPointer.h#L11-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedfunctionpointer_typedef_managed_callback_fn_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_ManagedFunctionPointer_Instance_CPP -->
<a id='snippet-test_managedfunctionpointer_instance_cpp'></a>
```h
typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(int);

// Get the managed entry point
auto fpTest_ManagedFunctionPointer_Instance = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_ManagedFunctionPointer"),
	STR("Test_ManagedFunctionPointer_Instance")
);

// Get the function pointer to the managed method
managed_callback_fn managedCallback = (managed_callback_fn)fpTest_ManagedFunctionPointer_Instance(2);

bool success = managedCallback(6) == 8;

LogTest(success, L"Test_ManagedFunctionPointer_Instance");
```
<sup><a href='/Host/Test_ManagedFunctionPointer.h#L16-L33' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedfunctionpointer_instance_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_ManagedFunctionPointer_FunctionPointerCallbackDelegate_CS -->
<a id='snippet-test_managedfunctionpointer_functionpointercallbackdelegate_cs'></a>
```cs
public delegate int FunctionPointerCallbackDelegate(int a);
```
<sup><a href='/Lib/Test_ManagedFunctionPointer.cs#L8-L10' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedfunctionpointer_functionpointercallbackdelegate_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_ManagedFunctionPointer_Instance_CS -->
<a id='snippet-test_managedfunctionpointer_instance_cs'></a>
```cs
public class CallableObject
{
    public FunctionPointerCallbackDelegate CallbackDelegate;
    public IntPtr CallbackFunctionPointer;

    private int Member;

    public int Callback(int i) => i + Member;

    public CallableObject(int member)
    {
        Member = member;
        CallbackDelegate = new FunctionPointerCallbackDelegate(Callback);
        CallbackFunctionPointer = Marshal.GetFunctionPointerForDelegate(CallbackDelegate);
    }

}

public static CallableObject CallableObjectInstance;

// Enty point for unmanaged code
[UnmanagedCallersOnly]
public static IntPtr Test_ManagedFunctionPointer_Instance(int member)
{
    CallableObjectInstance = new CallableObject(member);
    return CallableObjectInstance.CallbackFunctionPointer;
}
```
<sup><a href='/Lib/Test_ManagedFunctionPointer.cs#L13-L44' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedfunctionpointer_instance_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Managed function-pointer to static function

**Native**

<!-- snippet: Test_ManagedFunctionPointer_Typedef_managed_callback_fn_CPP -->
<a id='snippet-test_managedfunctionpointer_typedef_managed_callback_fn_cpp'></a>
```h
typedef int (*managed_callback_fn)(int);
```
<sup><a href='/Host/Test_ManagedFunctionPointer.h#L11-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedfunctionpointer_typedef_managed_callback_fn_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_ManagedFunctionPointer_Static_CPP -->
<a id='snippet-test_managedfunctionpointer_static_cpp'></a>
```h
typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)();

// Get the managed entry point
auto fpTest_ManagedFunctionPointer_Static = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_ManagedFunctionPointer"),
	STR("Test_ManagedFunctionPointer_Static")
);

// Get the function pointer to the managed function
managed_callback_fn managedCallback = (managed_callback_fn)fpTest_ManagedFunctionPointer_Static();

bool success = managedCallback(5) == 8;

LogTest(success, L"Test_ManagedFunctionPointer_Static");
```
<sup><a href='/Host/Test_ManagedFunctionPointer.h#L38-L55' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedfunctionpointer_static_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_ManagedFunctionPointer_FunctionPointerCallbackDelegate_CS -->
<a id='snippet-test_managedfunctionpointer_functionpointercallbackdelegate_cs'></a>
```cs
public delegate int FunctionPointerCallbackDelegate(int a);
```
<sup><a href='/Lib/Test_ManagedFunctionPointer.cs#L8-L10' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedfunctionpointer_functionpointercallbackdelegate_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_ManagedFunctionPointer_Static_CS -->
<a id='snippet-test_managedfunctionpointer_static_cs'></a>
```cs
public static FunctionPointerCallbackDelegate FunctionPointerCallbackDelegateStatic = new FunctionPointerCallbackDelegate(Callback);

public static int Callback(int i) => i + 3;

// Enty point for unmanaged code
[UnmanagedCallersOnly]
public static IntPtr Test_ManagedFunctionPointer_Static()
{
    return Marshal.GetFunctionPointerForDelegate(FunctionPointerCallbackDelegateStatic);
}
```
<sup><a href='/Lib/Test_ManagedFunctionPointer.cs#L46-L60' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedfunctionpointer_static_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Return managed ASCII string

**Native**

<!-- snippet: Test_ManagedString_Ansi_CPP -->
<a id='snippet-test_managedstring_ansi_cpp'></a>
```h
auto fpTest_ManagedString_Ansi = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_ManagedString"),
	STR("Test_ManagedString_Ansi")
);

char* str = (char*)fpTest_ManagedString_Ansi();

// Compare the ASCII strings
bool success = cmp(str, (char*)"Hello Ansi");

LogTest(success, L"Test_ManagedString_Ansi");
```
<sup><a href='/Host/Test_ManagedString.h#L17-L31' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedstring_ansi_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_ManagedString_Ansi_CS -->
<a id='snippet-test_managedstring_ansi_cs'></a>
```cs
public static readonly CString HelloAnsi = new CString("Hello Ansi");

[UnmanagedCallersOnly]
public static IntPtr Test_ManagedString_Ansi()
{
    return HelloAnsi.Ptr;
}
```
<sup><a href='/Lib/Test_ManagedString.cs#L9-L17' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedstring_ansi_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

What does CString do?
 1. Apends a `\0` character on the end of the string.
 2. Converts the string into ANSI encoding.
 3. Allocate memory for native access using [`Marshal.AllocHGlobal`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.allochglobal?view=net-5.0).
 4. Copy the encoded string into the allocated memory.

---

## Return managed wide string

> The encoding depends on the platform. For windows systems it is UTF16 and for posix systems it is UTF32.

**Native**

<!-- snippet: Test_ManagedString_Wide_CPP -->
<a id='snippet-test_managedstring_wide_cpp'></a>
```h
auto fpTest_ManagedString_Wide = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_ManagedString"),
	STR("Test_ManagedString_Wide")
);

wchar_t* str = (wchar_t*)fpTest_ManagedString_Wide();

// Compare the wide strings
bool success = cmp(str, (wchar_t*)L"Hello ❤");

LogTest(success, L"Test_ManagedString_Wide");
```
<sup><a href='/Host/Test_ManagedString.h#L36-L50' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedstring_wide_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

What does CString do?
 1. Determins the correct encoding for the current platform. (UTF16 or UTF32)
 2. Apends a `\0` character on the end of the string.
 3. Converts the string into the propper encoding.
 4. Allocate memory for native access using [`Marshal.AllocHGlobal`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.allochglobal?view=net-5.0).
 5. Copy the encoded string into the allocated memory.

<!-- snippet: Test_ManagedString_Wide_CS -->
<a id='snippet-test_managedstring_wide_cs'></a>
```cs
public static readonly CString HelloWide = new CString("Hello ❤", CEncoding.Wide);

[UnmanagedCallersOnly]
public static IntPtr Test_ManagedString_Wide()
{
    return HelloWide.Ptr;
}
```
<sup><a href='/Lib/Test_ManagedString.cs#L19-L27' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedstring_wide_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Usage of unsafe managed code to access native objects

**Native**

<!-- snippet: Test_ManagedUnsafe_CPP -->
<a id='snippet-test_managedunsafe_cpp'></a>
```h
struct Args
{
	int number1;
	int number2;
	int sum;
	char returnMsg[128];
};

bool Run(dotnet_runtime::Library& a_lib)
{
	bool ret = true;

	typedef void (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(void*);

	auto fpTest_ManagedUnsafe_Struct = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
		STR("LibNamespace.Test_ManagedUnsafe"),
		STR("Test_ManagedUnsafe_Struct")
	);

	Args args;
	args.number1 = 1;
	args.number2 = 2;

	fpTest_ManagedUnsafe_Struct(&args);

	{ //sum
		bool success = args.sum == 3;
		LogTest(success, L"Test_ManagedUnsafe_Struct.Sum");
		ret &= success;
	}

	{ // ReturnMsg
		bool success = cmp(args.returnMsg, (char*)"Hello Ansi");
		LogTest(success, L"Test_ManagedUnsafe_Struct.ReturnMsg");
		ret &= success;
	}
	return ret;
}
```
<sup><a href='/Host/Test_ManagedUnsafe.h#L7-L47' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedunsafe_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_ManagedUnsafe_CS -->
<a id='snippet-test_managedunsafe_cs'></a>
```cs
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Args
{
    public int Number1;
    public int number2;
    public int Sum;
    public fixed byte ReturnMsg[128];
}

[UnmanagedCallersOnly]
public static void Test_ManagedUnsafe_Struct(IntPtr ptr)
{
    unsafe
    {
        Args* args = (Args*) ptr;

        args->Sum = args->Number1 + args->number2;

        // Get the memory offset of Args.ReturnMsg
        var destReturnMsg = IntPtr.Add(ptr, (int)Marshal.OffsetOf(typeof(Args), nameof(Args.ReturnMsg)));

        var data = CEncoding.Ascii.GetBytes("Hello Ansi");

        // Copy the data to the unmanaged memory
        Marshal.Copy(data, 0, (IntPtr)destReturnMsg, data.Length);
    }
}
```
<sup><a href='/Lib/Test_ManagedUnsafe.cs#L9-L37' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedunsafe_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Native arrays using fixed struct member

**Native**

<!-- snippet: Test_NativeArray_Args_CPP -->
<a id='snippet-test_nativearray_args_cpp'></a>
```h
struct args
{
	int Arr[8];
	int Multiplier;
};
```
<sup><a href='/Host/Test_NativeArray.h#L7-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativearray_args_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_NativeArray_Args_Data_CPP -->
<a id='snippet-test_nativearray_args_data_cpp'></a>
```h
args _args{
	1, 2, 3, 4, 5, 6, 7, 8, // Arr[8]
	2 // Multiplier
};
```
<sup><a href='/Host/Test_NativeArray.h#L19-L24' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativearray_args_data_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_NativeArray_StructFixed_CPP -->
<a id='snippet-test_nativearray_structfixed_cpp'></a>
```h
typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(args);

auto fpTest_NativeArray_StructFixed = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_NativeArray"),
	STR("Test_NativeArray_StructFixed")
);

bool success = fpTest_NativeArray_StructFixed(_args) == 72;
LogTest(success, L"Test_NativeArray_StructFixed");
```
<sup><a href='/Host/Test_NativeArray.h#L27-L39' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativearray_structfixed_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_NativeArray_StructFixed_CS -->
<a id='snippet-test_nativearray_structfixed_cs'></a>
```cs
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Args
{
    public fixed int Arr[8];
    public int Multiplier;
}

[UnmanagedCallersOnly]
public static unsafe int Test_NativeArray_StructFixed(Args args)
{
    int ret = 0;

    for(int i = 0; i < 8; i++)
    {
        ret += args.Arr[i] * args.Multiplier;
    }

    return ret;
}
```
<sup><a href='/Lib/Test_NativeArray.cs#L10-L31' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativearray_structfixed_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Native arrays using pointer

**Native**

<!-- snippet: Test_NativeArray_ArgumentFixed_CPP -->
<a id='snippet-test_nativearray_argumentfixed_cpp'></a>
```h
typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(int[], int);

auto fpTest_NativeArray_ArgumentFixed = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_NativeArray"),
	STR("Test_NativeArray_ArgumentFixed")
);

bool success = fpTest_NativeArray_ArgumentFixed(_args.Arr, _args.Multiplier) == 72;
LogTest(success, L"Test_NativeArray_ArgumentFixed");
```
<sup><a href='/Host/Test_NativeArray.h#L45-L57' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativearray_argumentfixed_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_NativeArray_ArgumentFixed_CS -->
<a id='snippet-test_nativearray_argumentfixed_cs'></a>
```cs
[UnmanagedCallersOnly]
public static int Test_NativeArray_ArgumentFixed(IntPtr arrPtr, int multiplier)
{
    // ArrPointer as argument does not work here!

    ArrPointer8<int> arr = new ArrPointer8<int>(arrPtr);

    return arr.Sum(el => el * multiplier); ;
}
```
<sup><a href='/Lib/Test_NativeArray.cs#L33-L44' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativearray_argumentfixed_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Native arrays using ArrPointerX on function-pointer

**Native**

<!-- snippet: Test_NativeArray_ArgumentFixed_FunctionPointer_CPP -->
<a id='snippet-test_nativearray_argumentfixed_functionpointer_cpp'></a>
```h
typedef void* (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)();
typedef int (*managed_callback_fn)(int[], int);

auto fpTest_NativeArray_ArgumentFixed_FunctionPointer = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_NativeArray"),
	STR("Test_NativeArray_ArgumentFixed_FunctionPointer")
);

managed_callback_fn callback = (managed_callback_fn)fpTest_NativeArray_ArgumentFixed_FunctionPointer();

bool success = callback(_args.Arr, _args.Multiplier) == 72;
LogTest(success, L"Test_NativeArray_ArgumentFixed_FunctionPointer");
```
<sup><a href='/Host/Test_NativeArray.h#L62-L77' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativearray_argumentfixed_functionpointer_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_NativeArray_ArgumentFixed_FunctionPointer_CS -->
<a id='snippet-test_nativearray_argumentfixed_functionpointer_cs'></a>
```cs
public delegate int FunctionPointerCallbackDelegate(ArrPointer8<int> arr, int multiplier);

public static FunctionPointerCallbackDelegate FunctionPointerCallbackDelegateInstance =
    new FunctionPointerCallbackDelegate(Callback);

public static int Callback(ArrPointer8<int> arr, int multiplier) => arr.Sum(el => el * multiplier);

[UnmanagedCallersOnly]
public static IntPtr Test_NativeArray_ArgumentFixed_FunctionPointer()
{
    return Marshal.GetFunctionPointerForDelegate(FunctionPointerCallbackDelegateInstance);
}
```
<sup><a href='/Lib/Test_NativeArray.cs#L46-L59' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativearray_argumentfixed_functionpointer_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Calling checked native function pointer

**Native**

<!-- snippet: Test_NativeFunctionPointer_CallbackFunc_CPP -->
<a id='snippet-test_nativefunctionpointer_callbackfunc_cpp'></a>
```h
int FEXPORT CallbackFunc(int i)
{
	return i * 2;
}
```
<sup><a href='/Host/Test_NativeFunctionPointer.h#L8-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativefunctionpointer_callbackfunc_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_NativeFunctionPointer_CallbackPointer_CPP -->
<a id='snippet-test_nativefunctionpointer_callbackpointer_cpp'></a>
```h
void* fpNativeCallback = (void*)&CallbackFunc;
```
<sup><a href='/Host/Test_NativeFunctionPointer.h#L21-L23' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativefunctionpointer_callbackpointer_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_NativeFunctionPointer_CallbackFunc_Checked_CPP -->
<a id='snippet-test_nativefunctionpointer_callbackfunc_checked_cpp'></a>
```h
auto fpTest_NativeFunctionPointer_Checked = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_NativeFunctionPointer"),
	STR("Test_NativeFunctionPointer_Checked")
);

bool success = fpTest_NativeFunctionPointer_Checked(fpNativeCallback, 4) == 8;
LogTest(success, L"Test_NativeFunctionPointer_Checked");
```
<sup><a href='/Host/Test_NativeFunctionPointer.h#L26-L36' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativefunctionpointer_callbackfunc_checked_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_NativeFunctionPointer_Checked_CS -->
<a id='snippet-test_nativefunctionpointer_checked_cs'></a>
```cs
public delegate int FunctionPointerCallbackDelegate(int a);

[UnmanagedCallersOnly]
public static int Test_NativeFunctionPointer_Checked(IntPtr nativeFunctionPtr, int number)
{
    var callbackFuncDelegate =
        (FunctionPointerCallbackDelegate)Marshal.GetDelegateForFunctionPointer(nativeFunctionPtr,
            typeof(FunctionPointerCallbackDelegate));
    return callbackFuncDelegate(number);
}
```
<sup><a href='/Lib/Test_NativeFunctionPointer.cs#L8-L19' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativefunctionpointer_checked_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Calling unchecked native function pointer

**Native**

<!-- snippet: Test_NativeFunctionPointer_CallbackFunc_CPP -->
<a id='snippet-test_nativefunctionpointer_callbackfunc_cpp'></a>
```h
int FEXPORT CallbackFunc(int i)
{
	return i * 2;
}
```
<sup><a href='/Host/Test_NativeFunctionPointer.h#L8-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativefunctionpointer_callbackfunc_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_NativeFunctionPointer_CallbackPointer_CPP -->
<a id='snippet-test_nativefunctionpointer_callbackpointer_cpp'></a>
```h
void* fpNativeCallback = (void*)&CallbackFunc;
```
<sup><a href='/Host/Test_NativeFunctionPointer.h#L21-L23' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativefunctionpointer_callbackpointer_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_NativeFunctionPointer_CallbackFunc_Unchecked_CPP -->
<a id='snippet-test_nativefunctionpointer_callbackfunc_unchecked_cpp'></a>
```h
auto fpTest_NativeFunctionPointer_Unchecked = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_NativeFunctionPointer"),
	STR("Test_NativeFunctionPointer_Unchecked")
);

bool success = fpTest_NativeFunctionPointer_Unchecked(fpNativeCallback, 4) == 8;
LogTest(success, L"Test_NativeFunctionPointer_Unchecked");
```
<sup><a href='/Host/Test_NativeFunctionPointer.h#L41-L51' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativefunctionpointer_callbackfunc_unchecked_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_NativeFunctionPointer_Unchecked_CS -->
<a id='snippet-test_nativefunctionpointer_unchecked_cs'></a>
```cs
[UnmanagedCallersOnly]
public static int Test_NativeFunctionPointer_Unchecked(IntPtr nativeFunctionPtr, int number)
{
    unsafe
    {
        unchecked
        {
            var callbackFuncPtr = (delegate* unmanaged[Cdecl]<int, int>)nativeFunctionPtr;
            return callbackFuncPtr(number);
        }
    }
}
```
<sup><a href='/Lib/Test_NativeFunctionPointer.cs#L21-L34' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativefunctionpointer_unchecked_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Native ASCII string

**Native**

<!-- snippet: Test_NativeString_Ansi_CPP -->
<a id='snippet-test_nativestring_ansi_cpp'></a>
```h
auto fpTest_NativeString_Ansi = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_NativeString"),
	STR("Test_NativeString_Ansi")
);

bool success = fpTest_NativeString_Ansi((void*)"Hello Ansi");
LogTest(success, L"Test_NativeString_Ansi");
```
<sup><a href='/Host/Test_NativeString.h#L22-L32' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativestring_ansi_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_NativeString_Ansi_CS -->
<a id='snippet-test_nativestring_ansi_cs'></a>
```cs
[UnmanagedCallersOnly]
public static int Test_NativeString_Ansi(IntPtr stringPtr)
{
    return CEncoding.Ascii.GetString(stringPtr) == "Hello Ansi" ? 1 : 0;
}
```
<sup><a href='/Lib/Test_NativeString.cs#L12-L18' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativestring_ansi_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Native Wide string

**Native**

<!-- snippet: Test_NativeString_Wide_CPP -->
<a id='snippet-test_nativestring_wide_cpp'></a>
```h
auto fpTest_NativeString_Wide = (custom_entry_point_fn)a_lib.GetCustomEntrypoint(
	STR("LibNamespace.Test_NativeString"),
	STR("Test_NativeString_Wide")
);

bool success = fpTest_NativeString_Wide((void*)L"Hello ❤");
LogTest(success, L"Test_NativeString_Wide");
```
<sup><a href='/Host/Test_NativeString.h#L37-L47' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativestring_wide_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_NativeString_Wide_CS -->
<a id='snippet-test_nativestring_wide_cs'></a>
```cs
[UnmanagedCallersOnly]
public static int Test_NativeString_Wide(IntPtr stringPtr)
{
    return CEncoding.Wide.GetString(stringPtr) == "Hello ❤" ? 1 : 0;
}
```
<sup><a href='/Lib/Test_NativeString.cs#L20-L26' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativestring_wide_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

---

## Native string to managed function pointer

**Native**

<!-- snippet: Test_NativeString_RetArgs_CPP -->
<a id='snippet-test_nativestring_retargs_cpp'></a>
```h
struct RetArgs
{
	bool (*CallbackAnsi)(const char*);
	bool (*CallbackWide)(const wchar_t*);
};
```
<sup><a href='/Host/Test_NativeString.h#L7-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativestring_retargs_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: Test_NativeString_FunctionPointer_CPP -->
<a id='snippet-test_nativestring_functionpointer_cpp'></a>
```h
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
```
<sup><a href='/Host/Test_NativeString.h#L52-L78' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativestring_functionpointer_cpp' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

**Managed**

<!-- snippet: Test_NativeString_FunctionPointer_CS -->
<a id='snippet-test_nativestring_functionpointer_cs'></a>
```cs
public delegate bool FunctionPointerCallbackAnsiDelegate(NativeString nstr);
public delegate bool FunctionPointerCallbackWideDelegate(NativeWString nstr);

public static FunctionPointerCallbackAnsiDelegate FunctionPointerCallbackAnsiDelegateInstance =
    new FunctionPointerCallbackAnsiDelegate(CallbackAnsi);

public static FunctionPointerCallbackWideDelegate FunctionPointerCallbackWideDelegateInstance =
    new FunctionPointerCallbackWideDelegate(CallbackWide);

public static bool CallbackAnsi(NativeString nstr) => nstr.ToString() == "Hello Ansi";
public static bool CallbackWide(NativeWString nstr) => nstr.ToString() == "Hello ❤";

[StructLayout(LayoutKind.Sequential)]
public struct RetArgs
{
    public IntPtr CallbackAnsi;
    public IntPtr CallbackWide;
}

[UnmanagedCallersOnly]
public static void Test_NativeString_FunctionPointer(IntPtr retArgsPtr)
{
    unsafe
    {
        RetArgs* retArgs = (RetArgs*)retArgsPtr;
        retArgs->CallbackAnsi =
            Marshal.GetFunctionPointerForDelegate(FunctionPointerCallbackAnsiDelegateInstance);
        retArgs->CallbackWide =
            Marshal.GetFunctionPointerForDelegate(FunctionPointerCallbackWideDelegateInstance);
    }
}
```
<sup><a href='/Lib/Test_NativeString.cs#L29-L62' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_nativestring_functionpointer_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

# LICENSE

dotnet_runtime_test is licensed under MIT license. See [LICENSE](./LICENSE) for more details.


<!--
**Managed** custom-entrypoint

#**Native**

-snippet: ToDo

#**Managed**

-snippet: ToDo
-->
