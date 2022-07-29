
## Run Migrations
dotnet ef migrations add InitialCreate --project src\Infrastructure\Company.Cars.Infrastructure.Database.Mssql -- MssqlSettings:ConnectionString cce98938-947d-45b7-86fe-161ef15f8c52 C:\Users\Mario\source\tutorials\Company.Cars\src\Company.Cars

## Update Database
dotnet ef database update --project src\Infrastructure\Company.Cars.Infrastructure.Database.Mssql -- MssqlSettings:ConnectionString cce98938-947d-45b7-86fe-161ef15f8c52 C:\Users\Mario\source\tutorials\Company.Cars\src\Company.Cars