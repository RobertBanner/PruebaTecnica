# Proyecto_Cliente
**Proyecto Cliente API**

***DB*****

- Tabla creada en SQLite, llamada "**ClientSqlite**". Va la copia de la misma con algunos registros de prueba y sino está se crea uno desde cero.

***Campos:***

Id,

Rut,

FirstName,

LastName,

Address,

City,

PhoneNumber



***Errores y Logs***

- Manejo de excepciones con la clase AppException en Helpers.

- Manejo de Errores con la clase MiddlewareErrorHandler en Helpers.

- Gestor de logs para cuando se haga en Create o Update de cliente. Se guardará un archivo en la ruta C:\Logs.
  


***POSTMAN***

- Va incluído la colección de postman llamado API Client.postman_collection para ejecutarlo en localhost. Por defecto *https://localhost:7029/*
  


***APIS:***

- Crear nuevo cliente *https://localhost:7029/api/Client*

- Actualizar cliente *https://localhost:7029/api/Client/{id}*

- Listar todos los clientes *https://localhost:7029/api/Client*

- Listar o buscar un cliente en específico *https://localhost:7029/api/Client/{id}*

