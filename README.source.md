
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

snippet: InitRuntimeAndLib

### Managed component-entrypoint

#### Native

snippet: Test_ManagedEntryPoint_Args_CPP

snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CPP

#### Managed

snippet: Test_ManagedEntryPoint_Args_CS

> Component-entrypoints always have this signature: `static int <NAME>(IntPtr, int)`

snippet: Test_ManagedEntryPoint_ComponentEntryPoint_CS

### Managed custom-entrypoint

#### Native

snippet: Test_ManagedEntryPoint_Args_CPP

snippet: Test_ManagedEntryPoint_CustomEntryPoint_CPP

#### Managed

snippet: Test_ManagedEntryPoint_Args_CS

> Custom-entrypoints can only return [blittable types](https://en.wikipedia.org/wiki/Blittable_types)

snippet: Test_ManagedEntryPoint_CustomEntryPoint_CS

## LICENSE

dotnet_runtime_test is licensed under MIT license. See [LICENSE](./LICENSE) for more details.