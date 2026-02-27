# Docker Deployment Guide

## 🐳 Imágenes Docker Publicadas

Las imágenes Docker han sido publicadas exitosamente en Docker Hub con el tag `v1`:

### Backend .NET 8 API
- **Imagen**: `wilinvestiga/user-management-backend:v1`
- **Size**: 322MB (91.2MB compressed)
- **Digest**: `sha256:9336ec21f891561b39bdf603a8c23c0ac36ac44a9f49fc7bbde7a79dbead4d0b`

### Frontend Angular + Nginx
- **Imagen**: `wilinvestiga/user-management-frontend:v1`
- **Size**: 91.5MB (26.1MB compressed)
- **Digest**: `sha256:7d2f4e7bb4316d1ffea486592cf6b8334399141d1a69d1a633914b6c248689ac`

## 🚀 Pull y Ejecución

### Pull de las imágenes
```bash
# Backend
docker pull wilinvestiga/user-management-backend:v1

# Frontend
docker pull wilinvestiga/user-management-frontend:v1
```

### Ejecución con Docker Compose (usando imágenes publicadas)
```bash
# Crear docker-compose.production.yml
version: '3.8'

services:
  backend:
    image: wilinvestiga/user-management-backend:v1
    container_name: user-management-api
    ports:
      - "5000:80"
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ASPNETCORE_URLS=http://+:80
    networks:
      - user-management-network
    restart: unless-stopped

  frontend:
    image: wilinvestiga/user-management-frontend:v1
    container_name: user-management-frontend
    ports:
      - "4200:80"
    depends_on:
      - backend
    networks:
      - user-management-network
    restart: unless-stopped

networks:
  user-management-network:
    driver: bridge
```

### Iniciar servicios
```bash
docker-compose -f docker-compose.production.yml up -d
```

## 📋 Acceso a la Aplicación

- **Frontend**: http://localhost:4200
- **Backend API**: http://localhost:5000/api/users
- **API a través de frontend**: http://localhost:4200/api/users

## 🔍 Verificación

```bash
# Ver imágenes locales
docker images | grep wilinvestiga

# Ver contenedores en ejecución
docker ps

# Probar API
curl http://localhost:5000/api/users
curl http://localhost:4200/api/users
```

## 📦 Características de las Imágenes

- **Multi-stage builds** para optimización de tamaño
- **Base images oficiales** (.NET 8, Node.js 20 Alpine, Nginx Alpine)
- **Configuración de producción** lista para deploy
- **Networking Docker** para comunicación entre servicios
- **Proxy nginx** configurado para API calls

---
**Publicado por**: @wilinvestiga  
**Versión**: v1.0.0  
**Fecha**: Febrero 2026
