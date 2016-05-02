REM REM rebuild solution
REM msbuild.exe %~dp0\..\FioSdkCsharp.sln /p:Configuration=Release 
REM 
REM REM delete old packages
REM rd package
REM rd build
REM 
REM REM create folders for target frameworks
REM if not exist build mkdir build
REM if not exist package\lib\net45 mkdir package\lib\net45
REM if not exist package\lib\net451 mkdir package\lib\net451
REM if not exist package\lib\net452 mkdir package\lib\net452
REM if not exist package\lib\net46 mkdir package\lib\net46
REM if not exist package\lib\uap10.0 mkdir package\lib\uap10.0
REM 
REM REM copy assemblies to package folder
REM copy %~dp0\..\Src\FioSdkCsharp\bin\Release\FioSdkCsharp.dll package\lib\net45
REM copy %~dp0\..\Src\FioSdkCsharp.Net451\bin\Release\FioSdkCsharp.dll package\lib\net451
REM copy %~dp0\..\Src\FioSdkCsharp.Net452\bin\Release\FioSdkCsharp.dll package\lib\net452
REM copy %~dp0\..\Src\FioSdkCsharp.Net46\bin\Release\FioSdkCsharp.dll package\lib\net46
REM copy %~dp0\..\Src\FioSdkCsharp.Uap100\bin\Release\FioSdkCsharp.dll package\lib\uap10.0
REM 
REM REM update nuget
REM nuget.exe update -self
REM 
REM REM create package
REM nuget.exe pack package.nuspec -BasePath package -Output build