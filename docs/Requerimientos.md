<h2 align=center>📝 Requerements</h3>

<br>

<section>

### 👾 Dinámica de juego
- El juego presenta cuatro cartones diferentes generados aleatoriamente.
- La aplicación tendrá un único botón llamado **“Lanzar Bolilla”** que generará automáticamente un número del 1 al 90 y lo mostrará en el texto **_Bolilla_** de la pantalla.
- A su vez, luego de cada lanzamiento se deberá verificar si el nuevo número existe en algunos de los cartones y de existir, se deberá pintar ese número en el cartón con color Rojo.
- En el momento que uno o más cartones lleguen al estado **_Cartón Lleno_**, es decir que todos los números del cartón estén en Rojo, se finalizara el juego y se mostrará el cartón o los cartones que hayan ganado en el texto **“Cartón Ganador”**.

</section>

<br>

<section>

### 🔨 Construcción de los cartones
- Cartón de 3 filas por 9 columnas.
- El cartón debe tener 15 números y 12 espacios en blanco.
- Cada fila debe tener 5 números.
- Cada columna debe tener 1 o 2 números. 
- Ningún número puede repetirse. 
- La primer columna contiene los números del 1 al 9, la segunda del 10 al 19, la tercera del 20 al 29, así sucesivamente hasta la última columna la cual contiene del 80 al 90.

</section>

<br>

<section>

### 💾 Información almacenable
- Una tabla llamada __HistorialBolillero__ que almacenará cada numero que se genere. Se almacenará la fecha y hora y el número de bolilla que se juega.
- Una tabla llamada __HistorialCartones__ donde se guardará el número de Cartón o Cartones ganadores.
- La tabla HistorialCartones contará con 5 campos: Uno con fecha y hora y luego 4 campos (_Carton1, Carton2, Carton3 y Carton4_) que admitan null donde se guarde el o los cartones ganadores. Ejemplo: Si resultaron ganadores los cartones 3 y 1, se guardarán datos en el campo Fecha y hora con la hora actual y el número 3 en el campo Carton1 y el número 1 en el campo Carton2.

</section>

<br>

<footer align="center">
    <hr>

### ◀️ [Return](../README.md)

</footer>