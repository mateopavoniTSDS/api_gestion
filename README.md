# api_gestion (backend)

API en ASP.NET Core (.NET 9) con MySQL. Login con BCrypt y JWT.

## Preparar el entorno

1. Instalar MySQL Server y MySQL Workbench (es MySQL, no SQL Server), o usar Docker:

```bash
docker run -d --name mysql-tp -e MYSQL_ROOT_PASSWORD=1234 -e MYSQL_DATABASE=api_gestion -p 3306:3306 mysql:8
```

   Si no se usa Docker, crear el esquema `api_gestion` desde Workbench.

2. Instalar la herramienta de EF una sola vez (el mismo comando la actualiza):

```bash
dotnet tool install --global dotnet-ef
```

3. Copiar la config y completar la conexión y `Jwt:Key`:

```bash
cp api_gestion/appsettings.example.json api_gestion/appsettings.json
```

## Correr

```bash
dotnet ef database update --project dao_library --startup-project api_gestion
dotnet run --project api_gestion
```

Queda en `http://localhost:5224`.

## Migraciones

Si cambia una entidad, crear la migración con un nombre que tenga sentido y aplicarla:

```bash
dotnet ef migrations add NombreMigracion --project dao_library --startup-project api_gestion
dotnet ef database update --project dao_library --startup-project api_gestion
```

La migración se genera solo en una máquina. Si sale bien, se hace commit y push y se avisa al equipo. Los demás hacen pull y corren `database update`: no tienen la fila nueva en `__efmigrationshistory` hasta que lo corren, pero sí los archivos `.cs`.

### Error de tablas que ya existen

Si se borran los archivos de `Migrations` y se vuelve a correr la migración inicial, da error de que las tablas ya existen. Se arregla en Workbench borrando la fila de `__efmigrationshistory` y las tablas del esquema. Es un atajo solo para desarrollo, nunca en producción.

## Abstract Factory

El acceso a datos de `User` se crea con `IDAOFactory` (carpeta `dao_library/Factory`). Hay dos familias: `EFDAOFactory` (Entity Framework y MySQL) y `MockDAOFactory` (datos en memoria, con el usuario `admin@email.com` / `123456`). `UserController` solo conoce `IDAOFactory` e `IDAOUser`.

Para cambiar de familia se usa `DataSource` en `appsettings.json` (o la variable de entorno `DataSource`): `"EF"` (por defecto) o `"Mock"`.

```bash
DataSource=Mock dotnet run --project api_gestion
```

1. `DAOFactory` no debería crear directamente `EFDAOUser` porque quedaría atada a Entity Framework y no se podría intercambiar con Mock; cada fábrica concreta decide qué familia crea.
2. Si `EFDAOFactory` devolviera un exportador de notas PDF o de asistencias Excel, se rompería la coherencia de la familia: una fábrica de acceso a datos tiene que crear solo productos de acceso a datos, y el cliente recibiría objetos que no son intercambiables con los de Mock.
3. Habría que agregar una fábrica nueva (por ejemplo `SqlDAOFactory`) con su `SqlDAOUser` y registrarla en `Program.cs`; no se modifican `IDAOFactory` ni los controllers.
4. El controller depende solo de la abstracción y no sabe qué familia usa: se cambia entre EF y Mock (y se facilitan las pruebas) modificando solo el registro, con bajo acoplamiento.
