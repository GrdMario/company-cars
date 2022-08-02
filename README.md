
## Start project

- setup mssql database with docker - https://hub.docker.com/_/microsoft-mssql-server

- git clone https://github.com/GrdMario/company-cars.git

- Right click on Company.Cars project

- Select Manage User Secrets - this will open secrets.json file

- Add following to secrets.json

```
{
  "MssqlSettings:ConnectionString": "Server=localhost;Database=CarsService;User Id=SA;Password=yourStrong(!)Password;",
}
```

- Update Database

Command description:
```
dotnet ef database update --project [ProjectName] -- [Arg0] [Arg1] [Arg2]

ProjectName - path to a infrastructure project
Arg0 - name of Key in app.settings.json
Arg1 - secrets.json unique id found in Company.Cars.csproj
Arg3- path to startup project
```

Run:
```
dotnet ef database update --project src\Infrastructure\Company.Cars.Infrastructure.Database.Mssql -- MssqlSettings:ConnectionString cce98938-947d-45b7-86fe-161ef15f8c52 C:\Users\Mario\source\tutorials\Company.Cars\src\Company.Cars
```

- Clean solution
- Build solution
- Start service

If for some reason you are not getting swagger endpoint, try to rebuilding it again.

## Run Migrations
dotnet ef migrations add InitialCreate --project src\Infrastructure\Company.Cars.Infrastructure.Database.Mssql -- MssqlSettings:ConnectionString cce98938-947d-45b7-86fe-161ef15f8c52 C:\Users\Mario\source\tutorials\Company.Cars\src\Company.Cars
