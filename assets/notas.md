# Creacion de proyecto
dotnet new web

# librerias usadas
- Entityframeworkcore version 6.0.3
- EntityFrameworkCore.InMemory version 6.0.3
- EntityFrameworkCore.SqlServer version 6.0.3

La propiedad virtual es una propiedad que se usa para indicar que una propiedad puede ser sobreescrita en una clase derivada. La propiedad virtual es una propiedad que se usa para indicar que una propiedad puede ser sobreescrita en una clase derivada.

- DbContext
La clase DbContext nos permite acceder a los datos de nuestra base de datos.

- DataAnnotation
Los dataannotation son atributos que nos permiten agregar validaciones a nuestras propiedades.

- [NoMapped]
El atributo NoMapped nos permite indicar que una propiedad no debe ser mapeada a una columna de la base de datos.

dotnet build -> compilar el proyecto
dotnet run -> ejecutar el proyecto

# Fluent API
Es una forma de configurar las entidades de nuestro modelo de datos.  sin la necesidad de usar dataannotation.
Es una forma avanzada de configurar las entidades de nuestro modelo de datos.
La configuracion de las entidades se realiza en el metodo OnModelCreating de la clase DbContext.

- ignore -> ignorar una propiedad
- HasKey -> indicar la llave primaria de una entidad
- HasMaxLength -> indicar el tamaño maximo de una propiedad
- HasColumnType -> indicar el tipo de dato de una propiedad
- HasIndex -> indicar un indice para una propiedad
- HasMany -> indicar una relacion de uno a muchos
- HasOne -> indicar una relacion de uno a uno
- HasData -> indicar datos por defecto para una entidad

# Migraciones ()
- Debemos instalar el paquete de ef core para poder usar las migraciones.
dotnet ef --- revisar comandos
instalacion de paquetes ---- dotnet tool install --global dotnet-ef
- dotnet tool install --global dotnet-ef
Es una funcionalidad que nos permite crear un script de base de datos a partir de nuestro modelo de datos.
Nos permite construir un versionado de nuestra base de datos.
- dotnet ef migrations add InitialCreate -> crear una migracion
- dotnet ef database update -> ejecutar la migracion
