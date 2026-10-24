# Sistema de Gestión Escolar

Aplicación web desarrollada con ASP.NET Core MVC (.NET 10), Entity Framework Core y SQL Server Express para la Evaluación formativa (Tarea y Feedback) de la Unidad 1 de Programación Integrativa para la Integración de Tecnologías (Grupo 1).

## Integrantes y entidades

| Integrante | Entidad desarrollada |
|---|---|
| David Iván Granada Pachacama | Libro |
| John Steven Guanotoa Díaz | Maestro |
| Dylan Joel López Morales | Aula |
| Shaffik Samir Samandé Mujica | Estudiante |
| Ronny Adrián Sánchez García | Materia |

## Requisitos

- Visual Studio 2026 Community
- .NET 10
- SQL Server 2025 Express (instancia `localhost\SQLEXPRESS`)
- SSMS 22

## Pasos para ejecutar el proyecto

1. Clonar el repositorio y abrir `GestionEscolar.sln` en Visual Studio.
2. Verificar la cadena de conexión en `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "GestionEscolarContext": "Server=localhost\\SQLEXPRESS;Database=GestionEscolarDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. Abrir **Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes** y ejecutar:

   ```powershell
   Update-Database
   ```

4. Ejecutar la aplicación (F5) y usar el menú principal para acceder al CRUD de cada entidad: Libros, Maestros, Aulas, Estudiantes y Materias.
