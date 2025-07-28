# School Management System Setup Instructions

## Required Environment Variables and Secrets

Before running the project, create the following files (not included in the repo):

- `SchoolManagementSystem.API/appsettings.json`
- `SchoolManagementSystem.API/appsettings.Development.json`

Add this connection string (edit as needed for your environment):

```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=school_db;Username=postgres;Password=yourpassword"
}
```

## Default Credentials
- PostgreSQL Username: `postgres`
- PostgreSQL Password: `yourpassword`
- PostgreSQL Database: `school_db`

## Docker
If using Docker, the default container is started with:
- Username: `postgres`
- Password: `yourpassword`
- Database: `school_db`
- Port: `5432`

## After Cloning
1. Create the config files above with your own secrets.
2. Run EF Core migrations to set up the database schema:
   ```
   dotnet ef database update --project SchoolManagementSystem.Infrastructure/ --startup-project SchoolManagementSystem.API/
   ```
3. Start the API:
   ```
   dotnet run --project SchoolManagementSystem.API/
   ```
