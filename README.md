# WebApiBaguer 👕 3 Layers

🚀 **Bienvenidos a este proyecto donde vamos a usar la arquitectura de 3 capas: `Api`, `Core` y `Infrastructure`.**

## 🎯 Objetivo

Desarrollar una aplicación completa para el control de empleados de una tienda.

## 📂 Estructura

- **Api:** Esta carpeta contiene el punto de entrada de la API web, los controladores y las configuraciones de enrutamiento.

- **Core:** Esta carpeta contiene las entidades y las interfaces. 

- **Infrastructure:** En esta carpeta encontrará la capa de persistencia, donde definirá los contextos de su base de datos, repositorios y configuraciones de migración.

- **FrontEnd:** Aqui encontraremos el diseño de la aplicación web

## Base de Datos 🏬
[![Base de datos-2024-05-24-031504.png](https://i.postimg.cc/X7RnfYxC/Captura-de-pantalla-2024-05-24-031504.png)](https://postimg.cc/BXCWssrS)

## 🛠 Skills

C#, .NETCore, JWT, HTML, CSS, JS, Bootstrap

## 📖 Como usar el proyecto.

1. Si no tienes instalado EF, recuerda instalarlo con el siguiente comando: dotnet tool install --global dotnet-ef
   
2. Puedes crear la base de datos uatomaticamente, las configuraciones están aqui:
   ```bash
   .\API\appsettings.json
   ```

4. Comando de migración:
```bash
   dotnet ef migrations add InitialCreate --project ./Infrastructure/ --startup-project ./API/ --output-dir ./Data/Migrations
```
6. Ejcución de la migracion:
```bash
   dotnet ef database update --project .\Infrastructure\ --startup-project .\API\
```
8. Ejecucion del API:
```bash
  dotnet run --project .\API\
```

## EndPoints 🤖: 

### Ruta

`localhost:5000/api/usuarios/register`

### Esquema de la solicitud

```json
{
  "nombre": "tuNombre",
  "username": "tuUsername",
  "password": "Tucontraseña"
}
```
Este endpoint permite la creación del usuario.

### Ruta

`localhost:5000/api/usuarios/addrole`

### Esquema de la solicitud

```json
{
  "username" : "nombreUsuario",
  "password" : "Tucontraseña!",
  "role" : "ElRoldelEmpleado"
}
```
Este endpoint permite añadir un rol a un empleado.

### Ruta

`localhost:5000/api/usuarios/token`

### Esquema de la solicitud

```json
{
  "username" : "nombreUsuario",
  "password" : "Tucontraseña"
}
```
Este endpoint permite generar un JWT.



## 📚 Recursos adicionales.

- [Official ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)
- [Architectural Patterns for .NET Applications](https://docs.microsoft.com/dotnet/architecture/)
- [Best Practices Guide for ASP.NET Core](https://dotnet.microsoft.com/learn/web/aspnet-best-practices)
- [ASP.NET Core Web API Development Tutorial](https://docs.microsoft.com/aspnet/core/tutorials/first-web-api)

## ✍️ Autores

- [@rolando-r](https://www.github.com/rolando-r)
