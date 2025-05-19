$ErrorActionPreference = "Stop"

dotnet new sln -n TDDWorkshop

$exercises = @(
    @{ Name = "01-EmailValidator"; Lib = "EmailValidator"; Test = "EmailValidator.Tests" },
    @{ Name = "02-Refactoring"; Lib = "LegacyCode"; Test = "LegacyCode.Tests" },
    @{ Name = "03-BugFix"; Lib = "BuggyLibrary"; Test = "BuggyLibrary.Tests" },
    @{ Name = "04-PromoCalculator"; Lib = "PromoCalculator"; Test = "PromoCalculator.Tests" }
)

foreach ($ex in $exercises) {
    $libPath = "$($ex.Name)/$($ex.Lib)"
    $testPath = "$($ex.Name)/$($ex.Test)"

    dotnet new classlib -o $libPath
    dotnet new xunit -o $testPath

    dotnet add $testPath reference $libPath

    dotnet sln add "$libPath/$($ex.Lib).csproj"
    dotnet sln add "$testPath/$($ex.Test).csproj"
}

Write-Host "✅ Soluzione e progetti creati! Ora puoi aprire 'TDDWorkshop.sln' in Visual Studio."
