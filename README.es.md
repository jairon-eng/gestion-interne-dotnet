# Gestion Interne – Aplicación de gestión de equipos TI

🇫🇷 [Français](README.md) | 🇬🇧 [English](README.en.md) | 🇪🇸 Español

---

## Contexto

Este proyecto simula una aplicación interna utilizada en una empresa industrial
para gestionar equipos TI y registrar sus asignaciones a empleados o departamentos.

El enfoque está en la claridad, estabilidad y mantenibilidad,
más que en un diseño visual complejo.

---

## Objetivo del proyecto

Demostrar el desarrollo de una aplicación web interna basada en:

- Arquitectura MVC clara
- Base de datos relacional
- Coherencia de negocio (estados, asignaciones, fechas opcionales)
- Entorno reproducible utilizando Docker
- Separación adecuada de responsabilidades

El proyecto refleja un enfoque pragmático orientado a un entorno empresarial real.

---

## Funcionalidades

### Gestión de equipos
- Operaciones CRUD completas
- Catálogo de estados (Disponible, Asignado, En reparación)
- Fecha de compra opcional:
  - Muestra "Por definir" si no se registra
  - Validación que impide fechas futuras

### Gestión de asignaciones
- Operaciones CRUD completas
- Relación con equipos mediante clave foránea
- Catálogo de estados (Activo, Terminado, En espera)
- Fecha de finalización opcional:
  - Muestra "En espera de fecha de fin" si no se registra

### Interfaz
- Interfaz principal en francés
- Navegación coherente
- Páginas de Inicio y Confidencialidad adaptadas a contexto interno

---

## Tecnologías

- ASP.NET Core MVC (.NET 8)
- C#
- Entity Framework Core
- SQL Server
- Docker (base de datos en entorno local)
- Azure Data Studio (visualización y gestión de base de datos)
- Bootstrap (interfaz básica del template MVC)
- Git & GitHub

---

## Arquitectura

- Patrón MVC (Models, Views, Controllers)
- Inyección de dependencias nativa de ASP.NET Core
- Diseño relacional de base de datos
- Carga explícita de relaciones mediante Include()
- Validaciones de negocio mediante Data Annotations

La aplicación prioriza la claridad del código y su mantenibilidad.

---

## Ejecución local

### Requisitos

- .NET 8 SDK
- Docker Desktop

### 1. Iniciar SQL Server (Docker)

Iniciar el contenedor de SQL Server.

### 2. Verificar la cadena de conexión

Dentro de `appsettings.json` :

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=GestionInterneDb;User Id=sa;Password=StrongPassw0rd123;TrustServerCertificate=True;"
}
```

### 3. Aplicar migraciones

Ejecutar:

dotnet ef database update

### 4. Ejecutar la aplicación

Ejecutar:

dotnet run

---

## Alcance del proyecto

Este proyecto es intencionalmente simple con el fin de:

- Reflejar una aplicación interna realista
- Enfocarse en la estructura y claridad
- Evitar complejidad innecesaria

Puede ampliarse con:

- Autenticación
- Gestión de roles
- API REST
- Registro avanzado de eventos
- Despliegue en la nube

---

## Autor

Formación universitaria completada en Ingeniería en Sistemas (Guatemala).  
Proyecto desarrollado en el contexto de integración profesional al mercado TI de Québec.
