setlocal

set MsBuild="%SystemRoot:"=%\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe"
set NuGet="packages\NuGet.CommandLine.2.8.6\tools\NuGet.exe"

%MsBuild% NClone.sln /t:Clean,Build /m:2 /p:Configuration=NET45
%MsBuild% NClone.sln /t:Clean,Build /m:2 /p:Configuration=NET40
%NuGet% pack NClone.nuspec