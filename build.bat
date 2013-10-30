@echo off
::Env
if %PROCESSOR_ARCHITECTURE%==x86 (
	set MSBuild="%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
) else (
	set MSBUILD="%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"
)

::Clean
rm -rf bin
rm -rf obj

::Build
%MSBUILD% Flog.fsproj /p:Configuration=Release /p:TargetFrameworkVersion=v4.5.1

::Test
%MSBUILD% example/example.fsproj /p:Configuration=Release /p:TargetFrameworkVersion=v4.5.1
example\bin\Release\example_2012.exe

::Clean test
rm -rf example\bin
rm -rf example\obj