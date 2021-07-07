param([String]$ConfigurationName,[String]$SolutionDir, [String]$TargetDir, [String]$TargetName, [String]$AddInFileName, [Int32]$RevitRelease)

# Echo input variables
Write-Host "SolutionDir=$SolutionDir" 
Write-Host "ConfigurationName=$ConfigurationName" 
Write-Host "TargetDir=$TargetDir"
Write-Host "TargetName=$TargetName"
Write-Host "AddInFileName=$AddInFileName"
Write-Host "RevitRelease=$RevitRelease"

$TargetPath = "$TargetDir\$TargetName.dll"

#Sign the Assembly
#$certThumb = "0000000000000000000000000000000000000000"
#signtool sign /v /t http://timestamp.digicert.com /sha1 $certThumb $TargetPath

#Copy and repath assembly location in addin manifest if debugging
If ($ConfigurationName -eq "Debug") {
    
    $srcAddinFilePath = "$TargetDir\$AddInFileName"

    $addinFolder = "$env:APPDATA\Autodesk\REVIT\Addins\$RevitRelease"
    $addinFilePath = "$addinFolder\$ConfigurationName - $AddInFileName"

	Write-Host "srcAddinFilePath=$srcAddinFilePath"
	Write-Host "addinFilePath=$addinFilePath"

    $replace = "<Assembly>"
    $replaceWith = "<Assembly>$TargetDir"	
    ((Get-Content -literalPath $srcAddinFilePath) -replace $replace, $replaceWith) | Set-Content -Path $addinFilePath
}