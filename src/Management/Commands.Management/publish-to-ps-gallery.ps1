$ErrorActionPreference = 'Stop'
				         
$Params = @{    
	Name = 'PSaru.Management'
    NuGetApiKey= '7e501adc-c834-4f46-b54d-878241ab8647'
    ProjectUri='https://github.com/big-data-for-humans/psaru/'
    ReleaseNotes = 'Initial prototype'
}

Publish-Module @Params


