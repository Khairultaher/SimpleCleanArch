
# EF Migrations
```
dotnet ef migrations add "initial" --project Source\SimpleCleanArch.Infrastructure --startup-project Source\SimpleCleanArch.API --output-dir Persistence\Migrations
dotnet ef database update --project Source\SimpleCleanArch.Infrastructure --startup-project Source\SimpleCleanArch.API
```
