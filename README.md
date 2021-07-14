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

# Build and Run

## Windows

### Requirements

 * Visual Studio 2019
 * .NET 5 SDK

### Steps

 1. Clone this repository recursively using
    `git clone --recursive git@github.com:KevinGliewe/dotnet_runtime_test.git`
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

## Examples

### Load and initialize .NET runtime

<!-- snippet: InitRuntimeAndLib -->
<a id='snippet-initruntimeandlib'></a>
```cpp
// Init runtime and lib

auto runtime = dotnet_runtime::Runtime(hostfxr_path, libRuntimeconfig_path);

auto lib = dotnet_runtime::Library(&runtime, libDll_path, STR("Lib"));
```
<sup><a href='/Host/Host.cpp#L85-L91' title='Snippet source file'>snippet source</a> | <a href='#snippet-initruntimeandlib' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

### Managed component-entrypoint

#### Native

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

#### Managed

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
    if (argLength < System.Runtime.InteropServices.Marshal.SizeOf(typeof(Args)))
    {
        return 1;
    }

    Args args = Marshal.PtrToStructure<Args>(arg);

    return args.Number1 + args.Number2;
}
```
<sup><a href='/Lib/Test_ManagedEntryPoint.cs#L18-L30' title='Snippet source file'>snippet source</a> | <a href='#snippet-test_managedentrypoint_componententrypoint_cs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

### Managed custom-entrypoint

#### Native

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

#### Managed

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

> Custom-entrypoints can only return [blittable types](https://en.wikipedia.org/wiki/Blittable_types)

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

## LICENSE

dotnet_runtime_test is licensed under MIT license. See [LICENSE](./LICENSE) for more details.
