<div align="center">

# 🚗 API Concesionario de Autos

### RESTful API para la gestión integral de un concesionario de vehículos

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-6.4.0-85EA2D?style=for-the-badge&logo=swagger&logoColor=white)

</div>

---

## 📋 Sobre el Proyecto

**Car Dealer API** es una API RESTful construida con **ASP.NET Core 8.0** que permite gestionar el inventario completo de un concesionario de autos. Soporta operaciones CRUD sobre vehículos, con modelado de datos relacional, mapeo automático de objetos, validación de datos y documentación interactiva via Swagger.

---

## 🏗️ Arquitectura y Patrones de Diseño

### Arquitectura en Capas (Layered Architecture)

```
┌─────────────────────────────────────────────────────┐
│                  PRESENTATION                       │
│              Controllers (API Routes)               │
├─────────────────────────────────────────────────────┤
│                 BUSINESS LOGIC                      │
│            Services (Domain Operations)             │
├─────────────────────────────────────────────────────┤
│                   DATA ACCESS                       │
│          DbContext + Entity Framework Core          │
├─────────────────────────────────────────────────────┤
│                    DATABASE                         │
│                   SQL Server                        │
└─────────────────────────────────────────────────────┘
```

### Patrones Implementados

| Patrón | Descripción | Ubicación |
|--------|-------------|-----------|
| **DTO (Data Transfer Object)** | Desacopla las entidades de dominio de los contratos expuestos por la API | `Models/*/Dto/` |
| **Dependency Injection** | Inyección de servicios Scoped en el contenedor de IoC | `Program.cs` |
| **Repository Pattern** | Acceso a datos centralizado a través del `ApplicationDbContext` | `Config/ApplicationDbContext.cs` |
| **Service Layer** | Encapsula la lógica de negocio separada del controlador | `Services/` |
| **Custom Exception Handling** | Excepciones HTTP personalizadas con códigos de estado | `Utils/HttpError.cs` |
| **Model Validation** | Validación declarativa con Data Annotations en DTOs | `Models/*/Dto/` |
| **Object Mapping** | Mapeo automático entre entidades y DTOs con AutoMapper | `Config/Mapping.cs` |
| **Seed Data** | Datos iniciales cargados vía `OnModelCreating` | `ApplicationDbContext.cs` |

---

## 🗂️ Estructura del Proyecto

```
API_autos/
├── Config/
│   ├── ApplicationDbContext.cs    # Contexto EF Core + Seed Data
│   └── Mapping.cs                # Perfil de AutoMapper
├── Controllers/
│   ├── AutoController.cs         # CRUD completo /api/cars
│   ├── TipoAutoControllers.cs    # Listado /api/tiposAutos
│   ├── CondicionesController.cs  # Listado /api/condiciones
│   └── ModeloController.cs       # Listado /api/modelos
├── Models/
│   ├── Auto/                     # Entidad principal + DTOs
│   ├── Tipo_Auto/                # Tipos: Sedan, SUV, Pickup...
│   ├── Marcas/                   # Marcas: Toyota, Ford, Honda...
│   ├── Modelos/                  # Modelos: Corolla, Hilux...
│   ├── Estado/                   # Estado: Disponible / Vendido
│   ├── Es0Km/                    # Condición: 0KM / Usado
│   └── Provincia/                # Provincias
├── Services/
│   ├── AutoServices.cs           # Lógica de negocio de autos
│   ├── TipoAutoServices.cs       # Lógica de tipos de auto
│   ├── EstadoServices.cs         # Lógica de estados
│   ├── CondicionesServices.cs    # Lógica de condiciones
│   └── ModeloServices.cs         # Lógica de modelos
├── Utils/
│   ├── HttpError.cs              # Excepción personalizada HTTP
│   ├── HttpMessage.cs            # Modelo de respuesta de mensaje
│   └── ValidationErrorResponse.cs # Respuesta de errores de validación
├── Migrations/                   # Migraciones de EF Core
└── Program.cs                    # Entry point + configuración DI
```

---

## 🔧 Stack Tecnológico

| Tecnología | Versión | Propósito |
|------------|---------|-----------|
| **ASP.NET Core** | 8.0 | Framework web |
| **Entity Framework Core** | 9.0.7 | ORM / Data Access |
| **SQL Server** (LocalDB) | 2022 | Base de datos relacional |
| **AutoMapper** | 15.0.1 | Mapeo objeto-objeto |
| **Swashbuckle** | 6.4.0 | Documentación Swagger/OpenAPI |

---

## 🚀 Endpoints Disponibles

### Autos (`/api/cars`)

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/cars` | Obtener todos los autos |
| `GET` | `/api/cars/{id}` | Obtener un auto por ID |
| `POST` | `/api/cars` | Crear un nuevo auto |
| `PUT` | `/api/cars/{id}` | Actualizar un auto existente |
| `DELETE` | `/api/cars/{id}` | Eliminar un auto por ID |

### Recursos Auxiliares

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/tiposAutos` | Listar tipos de auto (Sedan, SUV, Pickup, Coupé, Hatchback, Convertible) |
| `GET` | `/api/condiciones` | Listar condiciones (0KM, Usado) |
| `GET` | `/api/modelos` | Listar modelos disponibles |

---

## 📦 Modelo de Datos

```
┌──────────────┐       ┌──────────────┐       ┌──────────────┐
│    Marca      │──1:N──│    Modelo     │       │  TipoDeAuto  │
│ (Toyota, Ford)│       │(Corolla, etc)│       │ (Sedan, SUV) │
└──────────────┘       └──────────────┘       └──────┬───────┘
                                                      │
┌──────────────┐       ┌──────────────┐              │
│    Estado     │──1:N──│     AUTO     │──N:1─────────┘
│(Disponible,  │       │  (Principal)  │
│  Vendido)    │       └──────┬───────┘
└──────────────┘              │
                       ┌──────┴───────┐
                  ┌────┴───┐    ┌─────┴────┐
                  │Condicion│    │ Provincia │
                  │(0KM,    │    │          │
                  │ Usado)  │    └──────────┘
                  └────────┘
```

---

## ⚙️ Configuración y Ejecución

### Prerequisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (recomendado) o VS Code

### Pasos

```bash
# Clonar el repositorio
git clone https://github.com/tu-usuario/API_car.git
cd API_car

# Restaurar paquetes
dotnet restore

# Aplicar migraciones
dotnet ef database update --project API_autos

# Ejecutar la API
dotnet run --project API_autos
```

La API estará disponible en: `https://localhost:5001` o `http://localhost:5000`

### Swagger UI

Al ejecutar en modo **Development**, Swagger está disponible en:

```
https://localhost:5001/swagger
```

---

## ✨ Características Destacadas

- **CRUD completo** con operaciones asíncronas (async/await)
- **Validación de datos** con mensajes de error personalizados en español
- **Manejo centralizado de errores** con códigos HTTP apropiados (404, 400, 500)
- **Seed data** precargado con marcas, modelos, tipos y condiciones de ejemplo
- **Documentación interactiva** via Swagger UI
- **CORS habilitado** para consumo desde cualquier origen
- **Serialización JSON** optimizada (ignorar ciclos, omitir valores null)
- **Response types documentados** en el controlador para generación precisa de Swagger

---

## 🧠 Conceptos Aplicados

- **SOLID Principles** — Separación de responsabilidades entre capas
- **DRY** — Reutilización de servicios (ej: `EstadoServices` dentro de `AutoServices`)
- **KISS** — Soluciones simples y directas
- **Clean Architecture** — Dependencias dirigidas hacia adentro (Controller → Service → DbContext)
- **Convention over Configuration** — Convenciones de ASP.NET Core para rutas y configuración

---

<div align="center">

**Desarrollado con 💻 y ☕ como proyecto de práctica en desarrollo de APIs con .NET**

</div>
