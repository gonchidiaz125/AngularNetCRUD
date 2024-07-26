# CRUD/ABM con Angular 13 + Web API con Net Core 

## Herramientas requeridas

- Visual Studio .Net (probado con Community version 2022)
- Visual Studio Code
- Node.js
- SQL Server / SQL Server Management Studio


## Instalación y ejecución

- Clonar repositorio de github  ` https://github.com/gonchidiaz125/AngularNetCRUD`

- Crear la Base de datos SQL Server
   
  1. Abrir SQL Management Studio
  2. Conectarse al servidor local y abrir una query
  3. Abrir y ejecutar el script de creación de base de datos:

      https://github.com/gonchidiaz125/AngularNetCRUD/blob/main/SqlServer/AngularNetCRUD%20DB%20creation%20script.sql  

  4. Revisar que la base de datos "AngularNetCRUD" haya sido creada conteniendo una tabla "Productos".

- Backend
   1. Abrir Visual Studio 
   2. Abrir la solución "AngularNetCrudWebApi.sln"
   3. Ejecutar la solución

   Se mostrará la página web de Swagger con la documentación de la API.
   Si al probar un endpoint falla la conexión a la base de datos:
   a. Revisar que la base de datos "AngularNetCRUD" haya sido creada conteniendo una tabla "Productos".
   b. Revisar la cadena de conexión en la clase RepositorioDeProductos.cs, ya que el nombre del servidor SQL local puede ser distinto en diferentes computadoras:

       string connectionString = "Server=localhost;Database=AngularNetCRUD;Trusted_Connection=True;MultipleActiveResultSets=true";

 

- Front-end

    Importante: Antes de ejecutar el front-end debemos tener corriendo la solucion .Net de API


   1. Abrir Visual Studio Code
   2. Abrir la carpeta "Frontend" ubicada dentro de la carpeta principal del repositorio
   3. Abrir una terminalgit 
   4. Ejecutar
            
            npm i

   5. Ejecutar la aplicación 

            ng serve
            (o npx ng serve)
           

    Normalmente el sitio web se publica en:

            http://localhost:4200/

    El Front-end espera que la API esté publicada en:

            https://localhost:7260/api/Productos

    En caso de que de un error al conectarse al back-end, revisar en que puerto está siendo ejecutada la API .Net y actualizar la URL en el archivo Producto.service.ts

            url:string = "https://localhost:7260/api/Productos";
    

