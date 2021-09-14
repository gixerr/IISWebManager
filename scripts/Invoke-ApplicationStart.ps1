$ApiLocation = '../src/IISWebManager.Api'
Set-Location $PSScriptRoot
Set-Location $ApiLocation
dotnet restore
dotnet build
dotnet run