# xUnit Testing



## Commands to create the solution (Example): 
("https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test")

* dotnet new sln -o unit-testing-using-dotnet-test
* cd unit-testing-using-dotnet-test
* dotnet new classlib -o PrimeService
* ren .\PrimeService\Class1.cs PrimeService.cs // Renaming Class1.cs to PrimeService.cs
* dotnet sln add ./PrimeService/PrimeService.csproj
* dotnet new xunit -o PrimeService.Tests
* dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj
* dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj