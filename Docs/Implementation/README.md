Documentación de Implementación 


Requisitos de Hardware

Para la API:

-Al menos 1 GB de RAM

-Espacio de almacenamiento suficiente para guardar registros de la base de datos

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

-Puede utilizar IIS

-En caso de probar en red local, configurar Firewall

Implementación del Software

-Transfiere el código fuente de la aplicación desde el repositorio de control de versiones.

-Configura la conexión a la base de datos de la api en appSettings.json

-Configura las variables de entorno necesarias (claves secretas, configuración de base de datos, etc.).

-Configura la URL base , a la cual se conectara la App en DataBaseService.cs

-Para implementar la APP en iOS, se puede hacer de una manera similar a Android:

    -Desde una MAC descargar o clonar el repositorio de GitHub: https://github.com/AnakinINQUIMH/csharp-exam-api-xamarin.git
    -Abrir la solución con Visual Studio
    -Asegurarse de tener instalado las dependencias necesarias.
    -Ejecutar en Simulador (Asegurarse de que el dispositivo simulado tenga acceso a la red local donde se encuentra la api o conexión a internet en caso de que la api está expuesta a la red)


iOS desde Visual Studio para Windows

Requisitos previos:

-Una Mac con macOS instalado y configurado para desarrollo de iOS.

-Visual Studio instalado en una máquina con Windows.

-Ambas máquinas (Windows y Mac) deben estar en la misma red.

Pasos para configurar Xamarin.iOS en Visual Studio en Windows:

1.Configurar la Mac como host de compilación remota:

-Asegúrate de que la Mac esté encendida y conectada a la misma red que la máquina con Windows.

-Abre la aplicación "Preferencias del sistema" en la Mac y ve a "Compartir".

-Habilita "Compartir servicios de compilación" para permitir que otras máquinas en la red se conecten a la Mac para compilar.

-Asegúrate de que las opciones de desarrollo estén habilitadas en la Mac, como la depuración USB y la depuración remota.

2.Configurar Visual Studio en Windows:

-Abre Visual Studio en tu máquina con Windows.

-Ve a "Herramientas" > "Opciones".

-Expande "Proyectos y soluciones" y selecciona "Dispositivos y conexión remota".

-Haz clic en "Añadir cuenta" y sigue las instrucciones para agregar tu Mac como host remoto. Debes proporcionar la dirección IP o el nombre de host de la Mac y las credenciales de inicio de sesión de la Mac.

-Una vez que se haya configurado la conexión, deberías ver la Mac en la lista de dispositivos y conexiones remotas en Visual Studio.


3.Compilar y depurar:

-Haz clic en el botón "Iniciar depuración" en Visual Studio.

-Visual Studio se conectará a la Mac y compilará la aplicación en la Mac.

-La aplicación se ejecutará en el emulador de iOS o en el dispositivo físico conectado a la Mac.

-Puedes depurar la aplicación desde Visual Studio como lo harías con cualquier otra aplicación.


Monitoreo y Mantenimiento


-Monitorea el rendimiento del servidor, el uso de recursos y las métricas de la aplicación.

-Aplica actualizaciones de seguridad para el sistema operativo y las bibliotecas utilizadas.


Escalabilidad y Rendimiento


Para manejar un aumento en el tráfico, considere la implementación de equilibrio de carga.
