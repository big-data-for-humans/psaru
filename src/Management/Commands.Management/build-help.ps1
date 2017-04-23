
param (
	[Parameter(Mandatory = $true)]
	[string]$Config
)

Import-Module -Name platyPS

New-ExternalHelp -Path .\Commands.Management\help -OutputPath .\Commands.Management\bin\$Config\en-us

