@echo off
::Env
if %PROCESSOR_ARCHITECTURE%==x86 (
	set MSBuild="%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
) else (
	set MSBUILD=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe
)

::Clean
rm -rf bin
rm -rf obj

::Build
%MSBUILD% Flog-2012.fsproj /p:TargetFramework=net45 /p:Configuration=Release

::Test
%MSBUILD% example/example-2012.fsproj /p:TargetFramework=net40 /p:Configuration=Release
example\bin\Release\example_2012.exe

::Clean test
rm -rf example\bin
rm -rf example\obj