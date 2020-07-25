[CmdletBinding()]
param (
    $PathTestAssemblies
)

$thePathTestAssemblies = $PathTestAssemblies

dotnet tool install dotnet-reportgenerator-globaltool --tool-path . --version 4.0.12
dotnet tool install coverlet.console --tool-path . --version 1.4.1
mkdir .\CoverageReport
$unitTestFile = gci -Recurse | ?{ $_.FullName -like $($thePathTestAssemblies) }

Write-Host "-*-*-*-*-*-*-*-*-*-*-*-*"
Write-Host $unitTestFile
Write-Host "-*-*-*-*-*-*-*-*-*-*-*-*"

$coverlet = "$pwd\coverlet.exe"
& $coverlet $unitTestFile.FullName --target "dotnet" --targetargs "vstest $($unitTestFile.FullName) --logger:trx" --format "cobertura"

%{ &"$pwd\reportgenerator.exe" "-reports:**/coverage.cobertura.xml" "-targetdir:CoverageReport" "-reportstypes:HtmlInline_AzurePipelines;Cobertura" }
