WHERE MSBuild
IF %ERRORLEVEL% NEQ 0 call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"

if exist %~dp0\dotnet_runtime\bin\windows\x64\dotnet.exe (
    echo Runtime already installed.
) else (
    echo Runtime not installed.
    Powershell -executionpolicy remotesigned -File  %~dp0\dotnet_runtime\scripts\download-runtime.ps1
)

MSBuild %~dp0\Host.sln /p:Configuration=Release /p:Platform=x64

%~dp0\x64\Release\Host.exe %~dp0
echo %ERRORLEVEL%
exit %ERRORLEVEL%