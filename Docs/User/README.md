Documentación de Usuario :

Introducción

Esta aplicación de Aves te permite llevar un inventario de aves con información general sobre su alimentación y su clasificación.

Requisitos del Sistema

-Está disponible para dispositivos móviles con los siguientes requisitos mínimos:

Sistema operativo: iOS 8.0 o posterior / Android 5.0 o posterior.

-Conexión al api.


Instalación


iOS (iPhone)
(Solo en Mac OS)
-Cargar el proyecto de GitHub 

-Abrir la solución con Visual Studio

-Ejecutar la aplicación en el simulador

-Asegurar de que el Iphone del simulador tenga acceso a la red de la Api o conexión a internet, en caso de que la Api este expuesta a internet.

Android

-Cargar el proyecto de GitHub

-Ejecutar en simulador o conectar dispositivo físico para ejecutarlo ahí.

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

Guía de Usuario


Pantalla de inicio


Al abrir la aplicación podrás ver la pantalla del listado de aves, debes dar click en Add bird para que se te redirija a la pantalla donde podrás dar de alta registros de aves.
El listado de aves contará con dos botones, los cuales te permitirán Editar o Eliminar el registro seleccionado.

Pantalla de Add bird/Update bird

En esta pantalla podrás agregar un registro o editar un registro existente.


Soporte


Si experimentas algún problema con la aplicación, deseas obtener asistencia adicional o realizar preguntas puedes comunicarte al correo: AnakinHernandezDev@gmail.com
