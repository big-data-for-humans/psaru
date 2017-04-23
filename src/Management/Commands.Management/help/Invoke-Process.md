---
external help file: Orca.Management.dll-Help.xml
online version: 
schema: 2.0.0
---

# Invoke-Process

## SYNOPSIS

Starts and waits for an external process, similar to *Start-Process -Wait* or 
*Start-Process | Wait-Process*. If the external process returns an non-zero
exit code an this will write to the error stream reporting any data written to 
standard error allowing execution to be controlled by the current setting of 
$ErrorActionPreference. In addition, any data the external process writes to standard out
is written to the output stream during execution.

## SYNTAX

### WithPositionalArgs (Default)
```
Invoke-Process [-FilePath] <String> [[-Argument1] <String>] [[-Argument2] <String>] [[-Argument3] <String>]
 [[-Argument4] <String>] [[-Argument5] <String>] [[-Argument6] <String>] [[-Argument7] <String>]
 [[-Argument8] <String>] [[-Argument9] <String>] [-WorkingDirectory <String>]
```

### WithArgumentList
```
Invoke-Process [-FilePath] <String> [[-ArgumentList] <String[]>] [-WorkingDirectory <String>]
```

## DESCRIPTION

Starts and waits for an external process, similar to *Start-Process -Wait* or 
*Start-Process | Wait-Process*. If the external process returns an non-zero
exit code an this will write to the error stream reporting any data written to 
standard error. In addition, any data the external process writes to standard out
is written to the output stream during execution.

<!-- expand -->

## EXAMPLES

### Example 1 - Execute an external process

```PowerShell
PS C:\> Invoke-Process whoami
example\username
PS C:\> 
```

### Example 2 - Execute an external process with a positional argument

```PowerShell
PS C:\> Invoke-Process whoami /UPN
username@example.com
PS C:\>
```

### Example 3 - Execute an external process with multiple positional arguments

```PowerShell
PS C:\> Invoke-Process whoami /USER /FO CSV /NH
"example\username","S-0-00-0-0000000000-0000000000-0000000000-000000000"
PS C:\>
```                                                                                                                                                                                                                                                                                                                     

### Example 4 - Execute an external process using an array of arguments

```PowerShell
PS C:\> Invoke-Process whoami /USER, /FO, CSV, /NH
"example\username","S-0-00-0-0000000000-0000000000-0000000000-000000000"
PS C:\>
```

```PowerShell
PS C:\> $ArgumentList = '/USER', '/FO', 'CSV', '/NH'
PS C:\> Invoke-Process whoami $ArgumentList
"example\username","S-0-00-0-0000000000-0000000000-0000000000-000000000"
PS C:\> 
```

### Example 5 - Execute an external process with invalid argumnets

```PowerShell
PS C:\> whoami /UPN /BadArgument
ERROR: Invalid argument/option - '/BadArgument'.
Type "WHOAMI /?" for usage.
PS C:\> $error
PS C:\>
```

```PowerShell
PS C:\> Invoke-Process whoami /UPN /BadArgument
Invoke-Process : Process exited with non-zero exit code. Details: ERROR: Invalid argument/option - '/BadArgument'.
Type "WHOAMI /?" for usage.
At line:1 char:1
+ Invoke-Process whoami /BadArgument
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : FromStdErr: (whoami:String) [Invoke-Process], Exception
    + FullyQualifiedErrorId : InvokeProcessError,Orca.Management.ProcessCommand

PS C:\>
```                                                                                                                                                                                                                                                                                                                     

### Example X - Execute an external process that fails with a non-zero exit code

```PowerShell
PS C:\> Invoke-Process git status
Invoke-Process : Process exited with non-zero exit code '128'. Details: fatal: Not a git repository (or any of the parent directories): .git
At line:1 char:1
+ Invoke-Process git status
+ ~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : FromStdErr: (git:String) [Invoke-Process], Exception
    + FullyQualifiedErrorId : InvokeProcessError,Orca.Management.ProcessCommand

PS C:\>

```
### Example X - Execute an external process that fails with a non-zero exit code

```PowerShell

PS C:\> $Credential = Get-Credential -Message 'Database credentials'
PS C:\> $ArgumentList = @(    
>>>    'customers','IN', 'D:\example\customers.txt',
>>>    '-S', 'example-server.database.windows.net',
>>>    '-d', 'example',
>>>    '-U', $Credential.UserName,
>>>    '-P', $Credential.GetNetworkCredential().Password
>>>    '-c',
>>>    '-t', ',',
>>>    '-b', 10000,
>>>    '-m', 1,
>>>    '-F', 2  # has header
>>>)

PS C:\> Invoke-Process bcp -ArgumentList $ArgumentList
Invoke-Process : Process exited with non-zero exit code '1'. Details: 
At line:1 char:1
+ Invoke-Process bcp -ArgumentList $ArgumentList
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : FromStdErr: (bcp:String) [Invoke-Process], Exception
    + FullyQualifiedErrorId : InvokeProcessError,Orca.Management.ProcessCommand
 

Starting copy...
10 rows sent to SQL Server. Total sent: 10
10 rows sent to SQL Server. Total sent: 20
...
10 rows sent to SQL Server. Total sent: 990
SQLState = 22005, NativeError = 0
Error = [Microsoft][ODBC Driver 13 for SQL Server]Invalid character value for cast specification

999 rows copied.
Network packet size (bytes): 4096
Clock Time (ms.) Total     : 640    Average : (1560.94 rows per sec.)
PS C:\> Do-ImportantStuff if the above line workls

PS C:\>

```

## PARAMETERS

### -Argument1

First positional argument for the process being invoked.

```yaml
Type: String
Parameter Sets: WithPositionalArgs
Aliases: Arg1

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Argument2

Second positional argument for the process being invoked.

```yaml
Type: String
Parameter Sets: WithPositionalArgs
Aliases: Arg2

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Argument3

Third positional argument for the process being invoked.

```yaml
Type: String
Parameter Sets: WithPositionalArgs
Aliases: Arg3

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Argument4

Fourth positional argument for the process being invoked.

```yaml
Type: String
Parameter Sets: WithPositionalArgs
Aliases: Arg4

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Argument5

Fifth positional argument for the process being invoked.

```yaml
Type: String
Parameter Sets: WithPositionalArgs
Aliases: Arg5

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Argument6

Sixth positional argument for the process being invoked.

```yaml
Type: String
Parameter Sets: WithPositionalArgs
Aliases: Arg6

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Argument7

Seventh positional argument for the process being invoked.

```yaml
Type: String
Parameter Sets: WithPositionalArgs
Aliases: Arg7

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Argument8

Eighth positional argument for the process being invoked.

```yaml
Type: String
Parameter Sets: WithPositionalArgs
Aliases: Arg8

Required: False
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Argument9

Ninth positional argument for the process being invoked.

```yaml
Type: String
Parameter Sets: WithPositionalArgs
Aliases: Arg9

Required: False
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArgumentList
{{Fill ArgumentList Description}}

```yaml
Type: String[]
Parameter Sets: WithArgumentList
Aliases: Args

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilePath
{{Fill FilePath Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: PSPath

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkingDirectory
{{Fill WorkingDirectory Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### System.Object

## NOTES

For processes requirung more than 9 arguments use the ArgumenstList paramater. Argument/Value pairs count as 2 arguments

```PowerShell
PS C:\> Invoke-Process this /arg=1  # using 1 arguments
PS C:\> Invoke-Process that /arg 1  # using 2 arguments

```
## RELATED LINKS

