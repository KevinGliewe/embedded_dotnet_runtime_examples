
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

> Entrypoints can only use [blittable types](https://en.wikipedia.org/wiki/Blittable_types)

<details><summary>Native</summary>
<p>

snippet: Test_ManagedEntryPoint_Args_CPP

snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_ManagedEntryPoint_Args_CS

> Component-entrypoints always have this signature: `static int <NAME>(IntPtr, int)`

snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CS
</p>
</details>

---

## Managed custom-entrypoint

> Entrypoints can only use [blittable types](https://en.wikipedia.org/wiki/Blittable_types)

<details><summary>Native</summary>
<p>

snippet: Test_ManagedEntryPoint_Args_CPP

snippet: Test_ManagedEntryPoint_CustomEntryPoint_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_ManagedEntryPoint_Args_CS

snippet: Test_ManagedEntryPoint_CustomEntryPoint_CS
</p>
</details>

---

## Managed function-pointer to instance method

<details><summary>Native</summary>
<p>

snippet: Test_ManagedFunctionPointer_Typedef_managed_callback_fn_CPP

snippet: Test_ManagedFunctionPointer_Instance_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_ManagedFunctionPointer_FunctionPointerCallbackDelegate_CS

snippet: Test_ManagedFunctionPointer_Instance_CS
</p>
</details>
---

## Managed function-pointer to static function

<details><summary>Native</summary>
<p>

snippet: Test_ManagedFunctionPointer_Typedef_managed_callback_fn_CPP

snippet: Test_ManagedFunctionPointer_Static_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_ManagedFunctionPointer_FunctionPointerCallbackDelegate_CS

snippet: Test_ManagedFunctionPointer_Static_CS
</p>
</details>

---

## Return managed ASCII string

<details><summary>Native</summary>
<p>

snippet: Test_ManagedString_Ansi_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_ManagedString_Ansi_CS
</p>
</details>

What does CString do?
 1. Apends a `\0` character on the end of the string.
 2. Converts the string into ANSI encoding.
 3. Allocate memory for native access using [`Marshal.AllocHGlobal`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.allochglobal?view=net-5.0).
 4. Copy the encoded string into the allocated memory.

---

## Return managed wide string

> The encoding depends on the platform. For windows systems it is UTF16 and for posix systems it is UTF32.

<details><summary>Native</summary>
<p>

snippet: Test_ManagedString_Wide_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

What does CString do?
 1. Determins the correct encoding for the current platform. (UTF16 or UTF32)
 2. Apends a `\0` character on the end of the string.
 3. Converts the string into the propper encoding.
 4. Allocate memory for native access using [`Marshal.AllocHGlobal`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.allochglobal?view=net-5.0).
 5. Copy the encoded string into the allocated memory.

snippet: Test_ManagedString_Wide_CS
</p>
</details>

---

## Usage of unsafe managed code to access native objects

<details><summary>Native</summary>
<p>

snippet: Test_ManagedUnsafe_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_ManagedUnsafe_CS
</p>
</details>

---

## Native arrays using fixed struct member

<details><summary>Native</summary>
<p>

snippet: Test_NativeArray_Args_CPP

snippet: Test_NativeArray_Args_Data_CPP

snippet: Test_NativeArray_StructFixed_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_NativeArray_StructFixed_CS
</p>
</details>

---

## Native arrays using pointer

<details><summary>Native</summary>
<p>

snippet: Test_NativeArray_ArgumentFixed_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_NativeArray_ArgumentFixed_CS
</p>
</details>

---

## Native arrays using ArrPointerX on function-pointer

<details><summary>Native</summary>
<p>

snippet: Test_NativeArray_ArgumentFixed_FunctionPointer_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_NativeArray_ArgumentFixed_FunctionPointer_CS
</p>
</details>

---

## Calling checked native function pointer

<details><summary>Native</summary>
<p>

snippet: Test_NativeFunctionPointer_CallbackFunc_CPP

snippet: Test_NativeFunctionPointer_CallbackPointer_CPP

snippet: Test_NativeFunctionPointer_CallbackFunc_Checked_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_NativeFunctionPointer_Checked_CS
</p>
</details>

---

## Calling unchecked native function pointer

<details><summary>Native</summary>
<p>

snippet: Test_NativeFunctionPointer_CallbackFunc_CPP

snippet: Test_NativeFunctionPointer_CallbackPointer_CPP

snippet: Test_NativeFunctionPointer_CallbackFunc_Unchecked_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_NativeFunctionPointer_Unchecked_CS
</p>
</details>

---

## Native ASCII string

<details><summary>Native</summary>
<p>

snippet: Test_NativeString_Ansi_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_NativeString_Ansi_CS
</p>
</details>

---

## Native Wide string

<details><summary>Native</summary>
<p>

snippet: Test_NativeString_Wide_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_NativeString_Wide_CS
</p>
</details>

---

## Native string to managed function pointer

<details><summary>Native</summary>
<p>

snippet: Test_NativeString_RetArgs_CPP

snippet: Test_NativeString_FunctionPointer_CPP
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_NativeString_FunctionPointer_CS
</p>
</details>

---

## Calling native exported symbols using `DllExport`

<details><summary>Native</summary>
<p>

snippet: Test_DllImport_Export_CPP

snippet: Test_DllImport_Call_CPP

> For posix systems, use the `-export-dynamic` flag for the linker.
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_DllImport_CS
</p>
</details>

---

## Calling native exported symbols using `GetProcAddress`/`dlsym`

<details><summary>Native</summary>
<p>

snippet: Test_NativeExport_Export_CPP

snippet: Test_NativeExport_Call_CPP

> For posix systems, use the `-export-dynamic` flag for the linker.
</p>
</details>

<details><summary>Managed</summary>
<p>

snippet: Test_NativeExport_CS
</p>
</details>

# LICENSE

dotnet_runtime_test is licensed under MIT license. See [LICENSE](./LICENSE) for more details.


<!--
<details><summary>Managed</summary>
<p> custom-entrypoint

#<details><summary>Native</summary>
<p>

-snippet: ToDo

#<details><summary>Managed</summary>
<p>

-snippet: ToDo
-->