Servicios de autenticación: debe contener mínimo los endpoints para login y registrar usuarios.

Para logear hay una tabla de usuarios en bd. Se genera un token con las apis get TokenLogin ingresando el correo asociado al usuario y su clave.
El token generado está encriptado usando una sintaxis de fecha correo y la clave en HASHBYTES solo para prueba y ejemplo.
Hay una cuenta de administrador asociado a mi correo, esa se puede usar para probar el rol de Administrador o generar una directamente en bd.

Para logear se usa el token generado en la api anterior y luego llamar a la api loginByToken

El Administrador puede generar nuevos usuarios con la api userInsert. Las claves quedan encriptadas para seguridad y temas del token de validación para login de usuarios.

● Servicios de localización: considerando la estructura País, región y comuna se debe permitir un CRUD básico para
cada estructura. (País puede tener varias regiones, y una región puede tener varias comunas)

Se pueden agregar países, regiones o comunas respetando el orden indicado en cuanto a la relación. Esto se ve reflejado en las tablas de bd donde hay tablas que generan dicha relación entre país-región, región-comuna.

o Los GETS son de libre consumo para cualquier sistema

En general los usuarios, de la tabla Usuario, pueden logear y llamar a estas apis.

o Los POST, PUTS, DELETE estarán sometidos a validación de rol, solo administrador.

El administrador tiene que validar su token de usuario y además hay una validación en estas apis que si tiene rol de administrador tiene permisos para llamar a las apis señaladas.

● Servicios de ayudas sociales: Están asignados por comuna y solo a los residentes de dichas comunas

Hay una tabla relacional de ServicioComuna donde se asocia la tabla Servicio y la tabla Comuna. Hay una tabla o entidad Persona donde tiene asociada un id de comuna asociada a la entidad o tabla Comuna y señalado anteriormente la comuna tiene asociado el servicio correspondiente.

o A una persona no se le puede asignar más de una vez con el mismo servicio social el mismo año.

Hay una entidad o tabla de ServicioPersona donde queda registrado el servicio o beneficio asociado a esa persona y año que se entrega el servicio o beneficio.

o El administrador puede ver personas y los servicios asignados, le puede asignar alguna ayuda social.

El Administrador puede usar la api pública GetAsignacionByRut. Para asignar está la api ServicioAsignar.

o Una persona puede obtener sus ayudas sociales asignados por año y el último vigente.

El controller de Servicio tiene la apis GetAsignacionByRut donde se puede consultar por rut asociado a la persona. No pide validación de login. Hay un store procedure que trae esta consulta agrupado por año y ordenado por año.

o El administrador puede obtener las ayudas sociales asignadas a un usuario.
El Administrador usa GetAsignacion. 

o El administrador puede crear nuevas ayudas sociales para las comunas o regiones. Si se crea en una
región se asigna a todas las comunas de esta.

Api CreateServicioComuna. Si llena la comuna entonces se crea un servicio o beneficio asociado a esa comuna. Si llena el campo de región entonces se generan los servicios o beneficios a todas las comunas asociadas a esa región. Esto está establecido a través de una tabla relacional de ServicioComuna y las tablas de región y comuna.

● Logging: Debe registrar cada acción de un usuario, quien hizo que y a qué hora. Un administrador puede rescatar
esta información cuando desee escogiendo el día.

Hay una función que se llama cuando se hace validaciones de token de usuario y cuando se llama a alguna api en particular. Queda todo guardado en la tabla log_bitacora y el Administrador puede usar una api llamada GetLogsByRut para obtener los datos de los logs generados por un usuario en particular.


Observaciones:

Están las entidades de Persona y Usuario, las dejé distinto ya que no se especificaba muy bien el tema de si eran la misma entidad. Los usuarios los tomé como parte del sistema interno y que están a nivel de manejo de un sistema interno. Las personas las veo como la entidad a donde se a apunta el beneficio o servicio. Para temas de login o validación entiendo que pueden ser a mismo nivel y diferenciar por roles de usuario a una persona de un usuario pero por temas de funcionalidad a corto plazo y practicidad lo dejé como se muestra.

Para querys grandes o con un poco de lógica por el tema de las tablas relaciones se dejaron las llamadas de la siguiente manera:

Si tiene mucha lógica o querys con join o "más elaboradas" se generaron procedimientos de almacenado.

Para querys más cortas o puntuales se generó una tabla con querys con parámetros. Se respeta el tema de generar la lista de parámetros separados con caracteres y como recomienda Microsoft.

Los parámetros para probar, ver las querys en las base de datos y tabla apiquery. En general se usa para un parámetro la sintaxis de @parametro:valorDeParametro. Si se quiere enviar más de uno hay que agregar el símbolo |.

Para usar las apis generar token de login con getTokenLogin y luego logear con loginByToken.

La base de datos está en SQL Server y va una copia completa tipo backup .BAK.

La conección a la bd va en el web.config del proyecto.

En general se usaron datos básicos de prueba, pero está toda la lógica relacional de las tablas de base de datos funcional según los requerimientos.


