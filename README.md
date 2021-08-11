# MikhailCortes-PruebaTecnica
Repositorio de Mikhail Cortes para la prueba técnica de Geta Club


Muchas gracias por tomarse el tiempo de revisar mi trabajo, espero que sea de su agrado, me gustaría mucho que me dieran retroalimentación para seguir mejorando.

De lo que se me pidió para la prueba, lo siguiente está implementado:

3 Scenas; Menu, Loading y Gameplay

Circuito de carreras con 2 Checkpoints, de igual manera estos funcionan como método de obtención de tiempo adicional

Contador inverso de tiempo, al llegar a 0 se llega a un estado de fallo, El estado de fallo también se consigue al caer de la pista

Controles de la nave con WASD y Barra espaciadora para hacer Drift

El Juego cuenta y guarda la cantidad de veces que se completo el circuito, también mantiene el récord de menor tiempo

Plataforma de incremento de velocidad, Plataforma de Salto y Hazzard que lanza el vehículo en una dirección aleatoria

En el menu principal se puede elegir entre 3 vehículos diferentes


Assets descargados de la tienda:

https://assetstore.unity.com/packages/vfx/shaders/ultimate-10-shaders-168611
Para la implementación de la mayoría de los materiales

https://assetstore.unity.com/packages/3d/environments/sci-fi/planet-earth-free-23399
Como elemento decorativo

https://assetstore.unity.com/packages/vfx/particles/particle-collection-skj-2016-free-samples-72399
Como VFX para el vehículo

https://assetstore.unity.com/packages/2d/textures-materials/deep-space-skybox-pack-11056
Para los Skybox en Menu y Gameplay


Sonidos:

https://freesound.org/people/OwlStorm/sounds/404772/
Incremento de Velocidad

https://freesound.org/people/Havana_White/sounds/565261/
Musica de Fondo

Lap https://freesound.org/people/JustInvoke/sounds/446142/
Al completar una vuelta

https://freesound.org/people/NicknameLarry/sounds/492072/
Al cruzar un checkpoint

Hazz https://freesound.org/people/MATRIXXX_/sounds/453061/
Al chocar con un Hazzard

https://freesound.org/people/cabled_mess/sounds/371276/
Al saltar


Áreas de oportunidad:
Al tener solo un día para realizar la prueba, hubo muchas cosas que por desgracia no logre incluir, como por ejemplo:

El editor de pista hubiese sido algo un poco complicado, la unica forma en la que me lo imagino es desarrollado la pista de manera 100% modular, de esa manera podría crear una matriz 3D de espacios donde el jugador podría crear instancias de prefabs, esto también implica una manera de guardar la pista más eficiente que la que yo estoy acostumbrado a usar (PlayerPref)

El modo de juego tipo subway surfer, hubiese hecho 3 carriles waypoints para hacer que la nave los siguiera usando NavMesh, pero creo que este modo de juego hubiese necesitado un diseño de pista diferente al que yo hice para hacerlo más divertido

El vehiculo no rota al bajar o subir pendientes, esto lo hubiese podido lograr con RayCast y la normal del piso debajo del vehículo

La cámara no tiene un script de seguimiento apropiado, solo es un Child del player

El vehiculo no cuenta con animaciones apropiadas para la acción que se encuentra realizando

Falta un método para reiniciar a demanda del jugador, en general creo que necesita un menu dentro de Gameplay

No hay manera de cambiar el color de los materiales del Vehiculo

----------------------------------------------------------------

Muchas gracias por tomarme en cuenta, espero escuchar de ustedes pronto. Mis mejores deseos.
