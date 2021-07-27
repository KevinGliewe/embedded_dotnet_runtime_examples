cmake_minimum_required(VERSION 3.16)
project(Host)

set(CMAKE_CXX_STANDARD 14)

set(THREADS_PREFER_PTHREAD_FLAG ON)
find_package(Threads REQUIRED)

include_directories("../dotnet_runtime/includes")

set(CMAKE_EXE_LINKER_FLAGS "-Wl,-export-dynamic")

add_executable(Host
        Host.cpp)

TARGET_LINK_LIBRARIES(Host 
        ${CMAKE_DL_LIBS}
        Threads::Threads)
