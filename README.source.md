
<div align="center">
  <h1>Embedded .NET Runtime</h1>
  <a href="https://github.com/KevinGliewe/dotnet_runtime_test/actions"><img alt="Build and Test" src="https://github.com/KevinGliewe/dotnet_runtime_test/workflows/Build%20and%20Test/badge.svg?branch=master"/></a>
</div>

This repo contains a project with examples for using a embedded .NET runtime in a C++ application using [dotnet_runtime](https://github.com/KevinGliewe/dotnet_runtime).

<!--ts-->
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

snippet: InitRuntimeAndLib

---

## Managed component-entrypoint

### Native

snippet: Test_ManagedEntryPoint_Args_CPP

snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CPP

### Managed

snippet: Test_ManagedEntryPoint_Args_CS

> Component-entrypoints always have this signature: `static int <NAME>(IntPtr, int)`

snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CS

---

## Managed custom-entrypoint

### Native

snippet: Test_ManagedEntryPoint_Args_CPP

snippet: Test_ManagedEntryPoint_CustomEntryPoint_CPP

### Managed

snippet: Test_ManagedEntryPoint_Args_CS

> Custom-entrypoints can only return [blittable types](https://en.wikipedia.org/wiki/Blittable_types)

snippet: Test_ManagedEntryPoint_CustomEntryPoint_CS

---

## Managed function-pointer to instance method

### Native

snippet: Test_ManagedFunctionPointer_Typedef_managed_callback_fn_CPP

snippet: Test_ManagedFunctionPointer_Instance_CPP

### Managed

snippet: Test_ManagedFunctionPointer_FunctionPointerCallbackDelegate_CS

snippet: Test_ManagedFunctionPointer_Instance_CS

---

## Managed function-pointer to static function

### Native

snippet: Test_ManagedFunctionPointer_Typedef_managed_callback_fn_CPP

snippet: Test_ManagedFunctionPointer_Static_CPP

### Managed

snippet: Test_ManagedFunctionPointer_FunctionPointerCallbackDelegate_CS

snippet: Test_ManagedFunctionPointer_Static_CS

---

## Return managed ASCII string

### Native

snippet: Test_ManagedString_Ansi_CPP

### Managed

snippet: Test_ManagedString_Ansi_CS

What does CString do?
 1. Apends a `\0` character on the end of the string.
 2. Converts the string into ANSI encoding.
 3. Allocate memory for native access using [`Marshal.AllocHGlobal`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.allochglobal?view=net-5.0).
 4. Copy the encoded string into the allocated memory.

---

## Return managed wide string

> The encoding depends on the platform. For windows systems it is UTF16 and for posix systems it is UTF32.

### Native

snippet: Test_ManagedString_Wide_CPP

### Managed

What does CString do?
 1. Determins the correct encoding for the current platform. (UTF16 or UTF32)
 2. Apends a `\0` character on the end of the string.
 3. Converts the string into the propper encoding.
 4. Allocate memory for native access using [`Marshal.AllocHGlobal`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.allochglobal?view=net-5.0).
 5. Copy the encoded string into the allocated memory.

snippet: Test_ManagedString_Wide_CS

---

## Usage of unsafe managed code to access native objects

### Native

snippet: Test_ManagedUnsafe_CPP

### Managed

snippet: Test_ManagedUnsafe_CS

---

## Native arrays using fixed struct member

### Native

snippet: Test_NativeArray_Args_CPP

snippet: Test_NativeArray_Args_Data_CPP

snippet: Test_NativeArray_StructFixed_CPP

### Managed

snippet: Test_NativeArray_StructFixed_CS

---

## Native arrays using pointer

### Native

snippet: Test_NativeArray_ArgumentFixed_CPP

### Managed

snippet: Test_NativeArray_ArgumentFixed_CS

---

## Native arrays using pointer

### Native

snippet: Test_NativeArray_ArgumentFixed_FunctionPointer_CPP

### Managed

snippet: Test_NativeArray_ArgumentFixed_FunctionPointer_CS

---

## Calling checked native function pointer

### Native

snippet: Test_NativeFunctionPointer_CallbackFunc_CPP

snippet: Test_NativeFunctionPointer_CallbackPointer_CPP

snippet: Test_NativeFunctionPointer_CallbackFunc_Checked_CPP

### Managed

snippet: Test_NativeFunctionPointer_Checked_CS

---

## Calling unchecked native function pointer

### Native

snippet: Test_NativeFunctionPointer_CallbackFunc_CPP

snippet: Test_NativeFunctionPointer_CallbackPointer_CPP

snippet: Test_NativeFunctionPointer_CallbackFunc_Unchecked_CPP

### Managed

snippet: Test_NativeFunctionPointer_Unchecked_CS

---

## Native ASCII string

### Native

snippet: Test_NativeString_Ansi_CPP

### Managed

snippet: Test_NativeString_Ansi_CS

---

## Native Wide string

### Native

snippet: Test_NativeString_Wide_CPP

### Managed

snippet: Test_NativeString_Wide_CS

---

## Native string to managed function pointer

### Native

snippet: Test_NativeString_FunctionPointer_CPP

### Managed

snippet: Test_NativeString_FunctionPointer_CPP

# LICENSE

dotnet_runtime_test is licensed under MIT license. See [LICENSE](./LICENSE) for more details.


<!--
### Managed custom-entrypoint

#### Native

-snippet: ToDo

#### Managed

-snippet: ToDo
-->