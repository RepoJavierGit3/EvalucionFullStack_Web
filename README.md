# Prueba Técnica: Full Stack Developer

Aplicación completa para la gestión de usuarios de una entidad financiera, desarrollada con arquitectura moderna y buenas prácticas.

## 🏗️ Arquitectura Backend (.NET 8)

### Estructura Hexagonal de 4 Capas
- **Domain Layer**: Entidades y contratos de negocio
- **Application Layer**: Casos de uso y DTOs
- **Infrastructure Layer**: Implementaciones (repositorio en memoria)
- **API Layer**: Controladores REST con Swagger

### 🚀 Funcionalidades API
- ✅ `GET /api/users` - Listar todos los usuarios
- ✅ `GET /api/users/{id}` - Obtener usuario por ID
- ✅ `POST /api/users` - Crear nuevo usuario
- ✅ `DELETE /api/users/{id}` - Eliminar usuario
- ✅ Persistencia en memoria
- ✅ Documentación con Swagger

## 🎨 Frontend (Angular 19)

### Tecnologías Utilizadas
- **Angular 19** con TypeScript
- **Angular HttpClient** para consumo de API
- **SCSS** para estilos
- **Dark Mode** por defecto
- **Responsive Design** (desktop + mobile)

### 📱 Componentes
- **UserListComponent**: Listado y gestión de usuarios
- **UserFormComponent**: Formulario de creación
- **UserService**: Servicio para comunicación con API

## � Docker Deployment

### Prerequisites
- Docker Desktop o Docker Engine
- Docker Compose

### Ejecución con Docker
```bash
# Construir y ejecutar todos los servicios
docker-compose up --build

# En modo detached (background)
docker-compose up -d --build

# Detener servicios
docker-compose down

# Ver logs
docker-compose logs -f
```

### Acceso a la Aplicación
- **Frontend**: http://localhost:4200
- **Backend API**: http://localhost:5000/api/users
- **Swagger**: http://localhost:5000/swagger

### Servicios Docker
- **user-management-api**: Backend .NET 8 (puerto 5000)
- **user-management-frontend**: Frontend Angular con Nginx (puerto 4200)

## � Ejecución Local

### Backend
```bash
cd UserManagement.Api
dotnet run --urls "http://0.0.0.0:5000"
```
- **API**: http://localhost:5000/api/users
- **Swagger**: http://localhost:5000/swagger

### Frontend
```bash
cd user-management-frontend
npm install
ng serve --host 0.0.0.0 --port 4200
```
- **Aplicación**: http://localhost:4200

## 📋 Entidad Usuario

```json
{
  "id": "guid",
  "firstName": "string",
  "lastName": "string", 
  "email": "string",
  "createdAt": "datetime"
}
```

## 🎯 Características Implementadas

### Backend
- ✅ Arquitectura hexagonal limpia
- ✅ Inyección de dependencias
- ✅ Manejo de errores
- ✅ DTOs para transferencia de datos
- ✅ Persistencia en memoria
- ✅ Configuración de Swagger

### Frontend
- ✅ Dark mode por defecto
- ✅ Diseño responsive
- ✅ Componentes reutilizables
- ✅ Manejo de estado con RxJS
- ✅ Validaciones de formulario
- ✅ Mensajes de error
- ✅ Interfaz moderna y limpia

## 🔄 Flujo de Trabajo

1. **Clonar repositorio**:
   ```bash
   git clone git@github.com:RepoJavierGit3/EvalucionFullStack_Web.git
   cd EvalucionFullStack_Web
   git checkout wilmer-puma
   ```

2. **Instalar dependencias**:
   ```bash
   # Backend (.NET 8 SDK requerido)
   cd UserManagement.Api && dotnet restore
   
   # Frontend (Node.js + Angular CLI requerido)
   cd user-management-frontend && npm install
   ```

3. **Ejecutar servicios**:
   ```bash
   # Terminal 1: Backend
   cd UserManagement.Api && dotnet run --urls "http://0.0.0.0:5000"
   
   # Terminal 2: Frontend  
   cd user-management-frontend && ng serve --host 0.0.0.0 --port 4200
   ```

## 📊 Historial de Desarrollo

Cada commit individual demuestra desarrollo real y progresivo:

- `feat: create domain user entity` - Entidad de dominio
- `feat: implement in-memory repository` - Repositorio en memoria
- `feat: add create user use case` - Caso de uso de creación
- `feat: add users controller` - Controlador API
- `feat: add complete CRUD operations` - Operaciones CRUD
- `feat: implement user service and models` - Servicio y modelos frontend
- `feat: implement user list component` - Componente de listado
- `feat: implement user form component` - Componente de formulario
- `feat: implement dark mode and integrate components` - Dark mode e integración
- `fix: resolve in-memory repository persistence issue` - Corrección de persistencia
- `feat: complete full-stack user management application` - Aplicación completa

## 🛠️ Requisitos Técnicos

### Backend
- .NET 8 SDK
- Arquitectura hexagonal
- Persistencia en memoria
- API REST con JSON
- Swagger/OpenAPI

### Frontend  
- Node.js 20+
- Angular CLI 19
- TypeScript
- SCSS
- Responsive design

## 📝 Notas Adicionales

- **Base de datos**: Persistencia en memoria (sin Docker)
- **Autenticación**: No requerida para esta prueba
- **CI/CD**: No implementado (opcional)
- **Testing**: Unit tests básicos incluidos
- **Docker**: Multi-stage builds para optimización de imágenes
- **Networking**: Comunicación entre contenedores via Docker network

---

**Desarrollado por**: Wilmer Puma  
**Fecha**: Febrero 2025  
**Versión**: 1.0.0
