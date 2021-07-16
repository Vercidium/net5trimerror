## Success on dotnet build

Run these commands to build a non-published Release build:
```
dotnet build -c Release -f net5.0-windows --no-incremental
dotnet "bin\Release\net5.0-windows\win7-x64\net5trimerror.dll"
```

This produces the output:
```
[net5trimerror] Begin
CimSession.Create
QueryInstances
CimInstanceProperties
finally
NVIDIA GeForce GTX 960
[net5trimerror] End
```

## Error on dotnet publish with -p:PublishTrimmed=true

Run these commands to build and published a trimmed Release build:
```
dotnet build -c Release -f net5.0-windows --no-incremental
dotnet publish -c Release -r win7-x64 -f net5.0-windows --self-contained true -p:PublishTrimmed=true /bl
dotnet "bin\Release\net5.0-windows\win7-x64\publish\net5trimerror.dll"
```

This produces the output:
```
[net5trimerror] Begin
CimSession.Create
System.IO.FileNotFoundException: Could not load file or assembly 'System.Runtime.Handles, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'. The system cannot find the file specified.
File name: 'System.Runtime.Handles, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
   at Microsoft.Management.Infrastructure.CimSession.Create(String computerName, CimSessionOptions sessionOptions)
   at net5trimerror.Helper.GetDedicatedGPUName() in C:\Users\Tesseract\Projects\net5trimerror\Helper.cs:line 16

[net5trimerror] End
```


## Success on dotnet publish without -p:PublishTrimmed

Run these commands to build and published a non-trimmed Release build:
```
dotnet build -c Release -f net5.0-windows --no-incremental
dotnet publish -c Release -r win7-x64 -f net5.0-windows --self-contained true /bl
dotnet "bin\Release\net5.0-windows\win7-x64\publish\net5trimerror.dll"
```

This produces the output:
```
[net5trimerror] Begin
CimSession.Create
QueryInstances
CimInstanceProperties
finally
NVIDIA GeForce GTX 960
[net5trimerror] End
```
