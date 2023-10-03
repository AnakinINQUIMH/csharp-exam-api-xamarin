Documentación de Implementación 


Requisitos de Hardware

Para la API:

-Al menos 1 GB de RAM

-Espacio en disco suficiente para almacenar registros de la base de datos

-Conexión a una red

Para la APP:

-Espacio en suficiente de almacenamiento

Requisitos de Software

Para la API:

-Sistema operativo Windows

Para la APP:

-Sistema operativo Android 5.0 o superior/ iOS 8.0 o superior

Configuración del Entorno

-Descargar las dependencias y componentes necesarios

-Configura la base de datos Microsoft SQL SERVER 

Implementación del Software

-Transfiere el código fuente de la aplicación desde el repositorio de control de versiones.

-Configura la conexión a la base de datos de la api en appSettings.json

-Configura las variables de entorno necesarias (claves secretas, configuración de base de datos, etc.).

-Configura la URL base , a la cual se conectara la App en DataBaseService.cs

-Para implementar la APP en iOS, se puede hacer de una manera simular que para Android:

    -Desde una MAC descargar o clorar el repositorio de GitHub: https://github.com/AnakinINQUIMH/csharp-exam-api-xamarin.git
    -Abrir la solución con Visual Studio
    -Asegurarse de tener instalado las dependencias necesarias.
    -Ejecutar en Simulador (Asegurarse de que el dispositivo simulado tenga acceso a la red local donde se encuentra la api o conexión a internet en caso de que la api está expuesta a la red)

Tambien se puede hacer desde Visual Studio de Windows, solo tienes que configurar tu VisualStudio para que tenga conexión a la Mac mediante la red local, y configurar la Mac para que permita esta conexión.

Monitoreo y Mantenimiento


-Monitorea el rendimiento del servidor, el uso de recursos y las métricas de la aplicación.

-Realiza copias de seguridad regulares de la base de datos.

-Aplica actualizaciones de seguridad para el sistema operativo y las bibliotecas utilizadas.

-Escalabilidad y Rendimiento


Para manejar un aumento en el tráfico, considere la implementación de equilibrio de carga.
