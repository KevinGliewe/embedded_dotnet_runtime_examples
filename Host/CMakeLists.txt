cmake_minimum_required(VERSION 3.17)
project(Host)

set(CMAKE_CXX_STANDARD 14)

include_directories("../dotnet_runtime/includes")

add_executable(Host
        Host.cpp)
