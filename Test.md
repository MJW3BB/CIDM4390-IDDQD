# xUnit Testing
1. implement the following code, with proper names for files
2. inside the unit-testing-using-dotnet-test file, run <dotnet test>
3. the program will run the tests and verify if the email input is proper


### Commands to create the solution (Example): 
("https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test")

* dotnet new sln -o unit-testing-using-dotnet-test
* cd unit-testing-using-dotnet-test
* dotnet new classlib -o PrimeService
* ren .\PrimeService\Class1.cs PrimeService.cs // Renaming Class1.cs to PrimeService.cs
* dotnet sln add ./PrimeService/PrimeService.csproj
* dotnet new xunit -o PrimeService.Tests
* dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj
* dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj