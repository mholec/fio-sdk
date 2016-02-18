REM rebuild solution
msbuild.exe %~dp0\..\FioSdkCsharp.sln /p:Configuration=Release 

REM delete old packages
rd package
rd build

REM create folders for target frameworks
if not exist build mkdir build
if not exist package\lib\net45 mkdir package\lib\net45
if not exist package\lib\net451 mkdir package\lib\net451
if not exist package\lib\net452 mkdir package\lib\net452
if not exist package\lib\net46 mkdir package\lib\net46

REM copy assemblies to package folder
copy %~dp0\..\Src\FioSdkCsharp\bin\Release\FioSdkCsharp.dll package\lib\net45
copy %~dp0\..\Src\FioSdkCsharp.Net451\bin\Release\FioSdkCsharp.dll package\lib\net451
copy %~dp0\..\Src\FioSdkCsharp.Net452\bin\Release\FioSdkCsharp.dll package\lib\net452
copy %~dp0\..\Src\FioSdkCsharp.Net46\bin\Release\FioSdkCsharp.dll package\lib\net46

REM update nuget
nuget.exe update -self

REM create package
nuget.exe pack package.nuspec -BasePath package -Output build