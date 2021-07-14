#pragma once

#include <iostream>
#include "dotnet_runtime.h"

#ifdef WIN32
# define FEXPORT __declspec(dllexport)
#else
# define FEXPORT // empty
#endif

#define STR DOTNET_RUNTIME_STR
#define DIR_SEPARATOR DOTNET_RUNTIME_DIR_SEPARATOR

using wstring_t = std::basic_string<wchar_t>;

inline void LogTest(bool success, std::wstring name)
{
	std::wcout << (success ? "OK" : "ERR");
	std::wcout << L"\t" << name << std::endl;
}

template<typename T>
bool cmp(T* s1, T* s2)
{
	int i = 0;
	while (true)
	{
		T sc1 = s1[i];
		T sc2 = s2[i];

		if (sc1 != sc2)
			return false;

		if (sc1 == 0)
			return true;

		i++;
	}
}