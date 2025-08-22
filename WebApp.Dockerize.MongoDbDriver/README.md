# MongoDB Driver Dockerized Application

Esta aplicación .NET 8 Web API con MongoDB está completamente dockerizada y configurada con MongoDB Replica Set.

## Requisitos Previos

- Docker Desktop instalado
- Docker Compose disponible

## Configuración de MongoDB Replica Set

La aplicación utiliza MongoDB configurado como replica set (`rs0`) para alta disponibilidad y funcionalidades avanzadas como transacciones.

## Instrucciones de Uso

### Ejecutar con Docker Compose

```bash
# Desde el directorio raíz del proyecto
cd WebApp.Dockerize.MongoDbDriver
docker-compose up --build
```

Esto iniciará:
- **MongoDB** en modo replica set (`rs0`) en el puerto 27017
- **Servicio de inicialización** que configura automáticamente el replica set
- **webapp230** en el puerto 8080
- **webapp343** en el puerto 8081

### Proceso de Inicialización

1. MongoDB se inicia con `--replSet rs0`
2. El servicio `mongo-init` ejecuta el script de inicialización
3. Se configura el replica set con un solo miembro
4. Las aplicaciones se conectan al replica set una vez inicializado

## URLs de Acceso

- **webapp230 API**: http://localhost:8080
- **webapp230 Swagger**: http://localhost:8080/swagger
- **webapp343 API**: http://localhost:8081
- **webapp343 Swagger**: http://localhost:8081/swagger
- **MongoDB Replica Set**: mongodb://localhost:27017/test?replicaSet=rs0

## Configuración de Conexión

Las aplicaciones están configuradas con:
- **Connection String**: `mongodb://mongodb:27017/test?replicaSet=rs0`
- **Read Preference**: PrimaryPreferred
- **Timeouts**: 30 segundos para conexión y selección de servidor
- **Write Concern**: W1 (escritura confirmada en primario)

## Endpoints Disponibles

- `GET /api/test` - Verificar conectividad con MongoDB
- `GET /api/test/databases` - Listar bases de datos disponibles

## Ventajas del Replica Set

- **Transacciones**: Soporte completo para transacciones ACID
- **Alta disponibilidad**: Preparado para múltiples nodos
- **Consistencia**: Control granular de lectura/escritura
- **Oplog**: Registro de cambios para replicación

## Desarrollo Local

Para desarrollo sin Docker:
1. Instala MongoDB localmente
2. Configura un replica set local: `rs.initiate()`
3. Actualiza la connection string en `appsettings.json`
