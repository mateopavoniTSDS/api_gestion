# api_gestion (backend)

API en ASP.NET Core + PostgreSQL. Login con hash BCrypt y token JWT.

## Correr

```bash
cd api_gestion
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=api_gestion;Username=postgres;Password=postgres"
dotnet user-secrets set "Jwt:Key" "una-clave-larga-cualquiera"
dotnet ef database update --project ../dao_library --startup-project .
dotnet run
```

Queda en `http://localhost:5224` (Swagger en `/swagger`).

## Probar el login

No hay usuarios cargados de antemano. Primero se crea uno:

```bash
curl -X POST http://localhost:5224/User -H "Content-Type: application/json" \
  -d '{"name":"Daniel","dni":"12345678","email":"daniel@email.com","password":"123456"}'
```

Y se loguea con esos mismos datos:

```bash
curl -X POST http://localhost:5224/User/login -H "Content-Type: application/json" \
  -d '{"email":"daniel@email.com","password":"123456"}'
```

Responde `{ "token": "..." }`, o `401` si la contraseña está mal.

Frontend: [api_gestion-frontend](https://github.com/mateopavoniTSDS/api_gestion-frontend).
