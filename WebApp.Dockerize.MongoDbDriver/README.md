# MongoDB Driver Dockerized Application

Esta aplicación .NET 8 Web API con MongoDB está completamente dockerizada y lista para usar.

## Requisitos Previos

- Docker Desktop instalado
- Docker Compose disponible

## Instrucciones de Uso

### Opción 1: Ejecutar con Docker Compose (Recomendado)

```bash
# Desde el directorio raíz del proyecto
cd WebApp.Dockerize.MongoDbDriver
docker-compose up --build
```

Esto iniciará:
- La aplicación .NET en el puerto 8080
- MongoDB en el puerto 27017

### Opción 2: Ejecutar solo la aplicación (requiere MongoDB externo)

```bash
# Construir la imagen
cd WebApp.Dockerize.MongoDbDriver.230
docker build -t webapp-mongodriver .

# Ejecutar el contenedor
docker run -p 8080:8080 webapp-mongodriver
```

## URLs de Acceso

Una vez que los contenedores estén ejecutándose:

- **API**: http://localhost:8080
- **Swagger UI**: http://localhost:8080/swagger
- **MongoDB**: mongodb://localhost:27017

## Endpoints Disponibles

- `GET /api/test` - Verificar conectividad con MongoDB
- `GET /api/test/databases` - Listar bases de datos disponibles

## Variables de Entorno

La aplicación utiliza las siguientes variables de entorno:

- `ConnectionStrings__MongoDB`: Cadena de conexión a MongoDB
- `ASPNETCORE_ENVIRONMENT`: Entorno de ejecución (Development/Production)

## Desarrollo Local

Para desarrollo sin Docker:

1. Asegúrate de tener MongoDB ejecutándose localmente
2. Ejecuta `dotnet run` desde el directorio del proyecto
3. La aplicación estará disponible en http://localhost:5000

## Estructura de Docker

- **Dockerfile**: Multi-stage build optimizado para producción
- **docker-compose.yml**: Orquestación de servicios con MongoDB
- **.dockerignore**: Exclusiones para optimizar el build
