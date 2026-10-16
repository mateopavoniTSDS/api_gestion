# api_gestion (backend)

API en ASP.NET Core (.NET 9) con MySQL. Login con BCrypt y JWT.

## Correr

1. Tener MySQL corriendo (es MySQL, no SQL Server). Con Docker:

```bash
docker run -d --name mysql-tp -e MYSQL_ROOT_PASSWORD=1234 -e MYSQL_DATABASE=api_gestion -p 3306:3306 mysql:8
```

2. Copiar la config y completar la conexión y `Jwt:Key`:

```bash
cp api_gestion/appsettings.example.json api_gestion/appsettings.json
```

3. Crear las tablas y levantar:

```bash
dotnet ef database update --project dao_library --startup-project api_gestion
dotnet run --project api_gestion
```

Queda en `http://localhost:5224`.

## Migraciones

```bash
dotnet ef migrations add NombreMigracion --project dao_library --startup-project api_gestion
dotnet ef database update --project dao_library --startup-project api_gestion
```

Al hacer pull, el resto solo corre `database update`.
