# ViajaFácil SGV: App de Gestión de Viajes

## Descripción
**ViajaFácil SGV** es una aplicación de escritorio desarrollada para gestionar de forma eficiente los elementos clave de un sistema de viajes, incluyendo el registro de transportes, la creación de reservas, el manejo de destinos y la administración básica de clientes. El sistema está diseñado para facilitar la organización de viajes desde una interfaz de consola clara y funcional.

## Requerimientos Funcionales

### 1. Gestión de Transportes
La aplicación debe permitir registrar y administrar los medios de transporte disponibles. Esto incluye:

- Agregar nuevos transportes con detalles como tipo, compañía, capacidad y precio por unidad.
- Editar transportes existentes.
- Eliminar transportes registrados.
- Listar todos los transportes almacenados.

### 2. Gestión de Clientes
El sistema debe permitir gestionar información básica de los clientes. Esto incluye:

- Registrar nuevos clientes con nombre, número de teléfono, correo electrónico y dirección.
- Editar la información de un cliente.
- Eliminar clientes del sistema.
- Consultar la lista de clientes.

### 3. Gestión de Destinos
El sistema debe permitir almacenar y administrar los destinos de viaje. Esto incluye:

- Registrar nuevos destinos con nombre, país y descripción opcional.
- Modificar información de destinos existentes.
- Eliminar destinos del sistema.
- Listar todos los destinos disponibles.

### 4. Gestión de Reservas
La aplicación debe permitir a los usuarios registrar y visualizar las reservas realizadas. Esto incluye:

- Crear una nueva reserva asociando un cliente, un destino y un transporte.
- Definir la cantidad de personas y la fecha del viaje.
- Modificar o eliminar una reserva existente.
- Listar todas las reservas registradas.

## Requerimientos No Funcionales

### 1. Seguridad de los Datos
- El sistema debe validar correctamente la entrada de datos para evitar errores de almacenamiento.
- La aplicación debe manejar los datos de forma segura a nivel local, sin acceso no autorizado al archivo o base de datos.
- Se deben utilizar excepciones controladas para evitar fallos inesperados.

### 2. Facilidad de Uso
- La interfaz por consola debe ser clara, con menús ordenados y textos explicativos para cada opción.
- El sistema debe guiar al usuario durante la introducción de datos, evitando confusión.
- La navegación debe ser intuitiva incluso sin conocimientos técnicos avanzados.

### 3. Rendimiento y Mantenibilidad
- El sistema debe responder rápidamente a las acciones del usuario.
- El código debe estar organizado por capas (entidades, servicios, repositorios, vistas) para facilitar su mantenimiento y escalabilidad futura.
