
11.04.2023 13:23

https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli


dotnet add package Microsoft.EntityFrameworkCore.Sqlite

dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update


--------------
Visual Studio
--------------
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate
Update-Database


12.04.2023 17:32
----------------