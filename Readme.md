1er Proyecto de Programación. Facultad de Matemática y Computación. Universidad de La Habana. Curso 2023.

Victor Hugo Pacheco Fonseca C113


Moogle es un buscador como cualquier otro. Su tarea es encontrar archivos .txt correspondientes a la búsqueda realizada dentro de una carpeta que sirve de base de datos. Para brindar mayor exactitud a la consulta, el proyecto cuenta con un corrector de palabras, por ejemplo si el usuario escribió incorrectamente alguna palabra.


Ejecucion del proyecto

Debe colocar los documentos en los que quiere desarrollar la búsqueda, en la carpeta
Content, en formato `.txt`. 

Este proyecto está desarrollado para la versión objetivo de .NET Core 6.0. Para ejecutarlo debe ir a la ruta en la que está ubicada el proyecto y ejecutar en la terminal de Linux:
make dev

Si está en Windows, debe poder hacer lo mismo desde la terminal del WSL (Windows Subsystem for Linux), en caso contrario puede ejecutar:
dotnet watch run --project MoogleServer

En caso de modificar el contenido durante la ejecucion, se debe volver a ejecutar el proyecto.


