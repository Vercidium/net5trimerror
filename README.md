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

When running the published exe:
```
bin\Release\net5.0-windows\win7-x64\publish\net5trimerror.exe
```

This produces the output:
```
[net5trimerror] Begin
CimSession.Create
System.TypeInitializationException: The type initializer for 'Microsoft.Management.Infrastructure.Native.ApplicationMethods' threw an exception.
 ---> System.TypeLoadException: Could not load type 'System.Runtime.CompilerServices.CallConvCdecl' from assembly 'System.Runtime.CompilerServices.VisualC, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'.
   at malloc(UInt64 )
   at MI_CLI_malloc_core(UInt64 length)
   at Microsoft.Management.Infrastructure.Native.ApplicationMethods.InitializeCore(InstanceHandle& errorDetails, ApplicationHandle& applicationHandle)
   at Microsoft.Management.Infrastructure.Native.ApplicationMethods..cctor()
   --- End of inner exception stack trace ---
   at Microsoft.Management.Infrastructure.Native.ApplicationMethods.Initialize(InstanceHandle& errorDetails, ApplicationHandle& applicationHandle)
   at Microsoft.Management.Infrastructure.Internal.CimApplication.GetApplicationHandle()
   at System.Lazy`1.ViaFactory(LazyThreadSafetyMode mode)
   at System.Lazy`1.ExecutionAndPublication(LazyHelper executionAndPublication, Boolean useDefaultConstructor)
   at System.Lazy`1.CreateValue()
   at System.Lazy`1.get_Value()
   at Microsoft.Management.Infrastructure.Internal.CimApplication.get_Handle()
   at Microsoft.Management.Infrastructure.CimSession.Create(String computerName, CimSessionOptions sessionOptions)
   at net5trimerror.Helper.GetDedicatedGPUName() in C:\Users\Tesseract\Projects\net5trimerror\Helper.cs:line 16
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
