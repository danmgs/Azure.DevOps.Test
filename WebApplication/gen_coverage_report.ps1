dotnet tool install dotnet-reportgenerator-globaltool --tool-path . --version 4.0.12
dotnet tool install coverlet.console --tool-path . --version 1.4.1
mkdir .\CoverageReport
$unitTestFile = gci -Recurse | ?{ $_.FullName -like "*bin\Release\*NUnit.Tests.dll" }

Write-Host "1-*-*-*-*-*-*-*-*-*-*-*-*"
Write-Host $unitTestFile
Write-Host $unitTestFile.FullName
Write-Host "1-*-*-*-*-*-*-*-*-*-*-*-*"

Write-Host "2-*-*-*-*-*-*-*-*-*-*-*-*"
Write-Host $coverlet $unitTestFile.FullName --target "dotnet" --targetargs "vstest $($unitTestFile.FullName) --logger:trx" --format "cobertura"  --exclude "[xunit.]"
Write-Host "2-*-*-*-*-*-*-*-*-*-*-*-*"

$coverlet = "$pwd\coverlet.exe"
& $coverlet $unitTestFile.FullName --target "dotnet" --targetargs "vstest $($unitTestFile.FullName) --logger:trx" --format "cobertura"

Write-Host "3-*-*-*-*-*-*-*-*-*-*-*-*"
Write-Host "$pwd\reportgenerator.exe" "-reports:$($_.FullName)" "-targetdir:CoverageReport" "-reportstypes:HTMLInline;HTMLChart" 
Write-Host "3-*-*-*-*-*-*-*-*-*-*-*-*"

%{ &"$pwd\reportgenerator.exe" "-reports:**/coverage.cobertura.xml" "-targetdir:CoverageReport" "-reportstypes:HTMLInline;HTMLChart" }

