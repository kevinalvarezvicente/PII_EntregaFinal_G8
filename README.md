# PII_Defensa_Glass

Los clientes (profesores) han decidido agregar una nueva funcionalidad al juego. Desean que en cualquier momento de la partida un jugador pueda ejecutar un comando en el bot para solicitar la cantidad de disparos que han tocado el agua, así como de los que han impactado en barcos.

Te pedimos que programes la nueva funcionalidad implementando una o más clases que sumen la cantidad de disparos de ambos jugadores al agua, por un lado, y a barcos, por otro, utilizando los patrones y principios aprendidos en el curso. 
Luego agrega el comando al bot para mostrar el resultado que obtienes utilizando esas clases

También deberás programar los casos de prueba correspondientes a las nuevas clases

Se encuentra los métodos en la clase ShotCounter, WaterShotCounter, ShipShotCounter.

La funcionalidad se encuentra implementada en la clase Game ya que esta es la clase Experta en la información de la partida.

Los casos de prueba correspondientes a las nuevas clases se encuentran en ShotsTests. Se debe correr solos porque hace unmatch con los demas. 

El comando al bot para mostrar el resultado que se obtiene utilizando esas clases: Se añade en MakeShotHandler
 

## Guía para correr el código

Para una ejecución exitosa se deberán de tener ciertos paquetes en su ordenador en el directorio C:\Users\<Su usuario>\.nuget\packages. Dichos paquetes con las versiones correspondientes están localizadas en  la carpeta “docs” de nuestro repositorio en Github. La carpeta que contiene dichos paquetes es llamada “PaquetesUtilizados” y se deberá copiar su interior en el directorio mencionado anteriormente.

Por último pero no menos importante se deberá copiar y pegar el archivo llamado “appsettings.json” en la siguiente ubicación dentro de su ordenador “PII_EntregaFinal_G8\src\Program\bin\Debug\net6.0 ”. Esto se debe a que el archivo al ser subido al repositorio es ignorado por GitHub por lo cual debe de ser añadido manualmente en cada ordenador al ejecutar el proyecto. Cabe recalcar que el ignorar este archivo por parte de Github no es aleatorio y fue configurado previamente con el fin de evitar que el token de seguridad de nuestro chatbot pueda ser accedido y extraído por personas mal intencionadas. Por cualquier otra consulta acerca de la ejecución de nuestro proyecto se agradece la comunicación con los desarrolladores que estarán disponible para usted las 24 hs.

## Guía clave para comunicarse con @paco_pii_G8_bot

1. Escribir "Hola" al comenzar
2. Seguir las instrucciones e indicaciones al pie de la letra del bot y aguardar por las respuestas de este, el encontrará a un usuario para que se pueda jugar. Tenga paciencia.
3. Al momento de posicionar las naves se debe poner por orden de como aparece en el mensaje.
4. Disfrutar del juego :)


## Informacion acerca del Bot
Identificador del Bot: 898174738

El token del TelegramBot es:  5193142034:AAFHGchgSiw5oq5ba9gV19F4b8_Zn44MAfA

Bot Username: @paco_pii_G8_bot

[Comunicación directa con el Bot a través de éste link](https://web.telegram.org/k/#@paco_pii_G8_bot)

