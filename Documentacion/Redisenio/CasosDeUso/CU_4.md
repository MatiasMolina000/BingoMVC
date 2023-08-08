## Caso de Uso

<table style="border: 2px solid">
    <thead">
        <tr>
            <td><strong>Caso de uso:</strong></td>
            <td>Jugar</td>
            <td><strong>Identificador:</strong></td>
            <td>CU_4</td>
        <tr>
        <tr>
            <td colspan="2"><strong>Nivel de caso de uso:</strong></td>
            <td colspan="2">Usuario final</td>
        </tr>
        <tr>
            <td><strong>Prioridad:</strong></td>
            <td colspan="3">Alta</td>
        </tr>
        <tr>
            <td><strong>Complejidad:</strong></td>
            <td colspan="3">Alta</td>
        </tr>
        <tr>
            <td><strong>Actor Principal:</strong></td>
            <td>Usuario final</td>
            <td><strong>Actor Secundario:</strong></td>
            <td>No aplica</td>
        </tr>
        <tr>
            <td>Objetivo:</td>
            <td colspan="3">Proceso central según la dinámica de juego en el requerimiento.</td>
        </tr>
        <tr>
            <td>Precondición:</td>
            <td colspan="3">El usuario debe estar dado de alta en la base de datos y tener validado su correo.</td>
        </tr>
        <tr>
            <td rowspan="2">Post-condición</td>
            <td colspan="1">Éxito:</td>
            <td colspan="3">El usuario recibe un mensaje de finalización del juego y los datos se podrán recuperar.</td>
        </tr>
        <tr>
            <td colspan="1">Fracaso:</td>
            <td colspan="3"></td>
        </tr>
    </thead>
	<tbody style="border-bottom: 2px solid;border-top: 2px solid">
		<tr>
            <td align="center" colspan="2">Curso Normal</td>
            <td align="center" colspan="2">Curso Alternativo</td>
        </tr>
        <tr>
            <td colspan="2">1. El usuario selecciona la opción "New Game" del menú principal.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">2. El sistema muestra en la ventana cuatro cartones, un botón y una sección para los números cantados.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">3. El usuario selecciona el botón "Cantar Número".</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">4. El sistema muestra un alerta con el número en pantalla y lo almacena en el apartado de números cantados.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">5.a. "Cohincidencia". El sistema muestra la cohincidencia con un remarcado en rojo en el número de cada carton correspondiente.</td>
            <td colspan="2">5.b. "No cohincidencia". El sistema no muestra ningún cambio en los cartones.</td>
        </tr>
        <tr>
            <td colspan="2">6. Se repiten los pasos 3, 4 y 5.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">7. "Cartón lleno". Con 15 cohincidencias en un mismo cartón con las bolillas cantadas, el sistema muestra un mensaje de Fin de partida con el número de cartón que se completó.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">8. El sistema redirecciona al usuario menú principal.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td align="center" colspan="4">Fin de caso de uso</td>
        </tr>
	</tbody>
    <tfooter>
        <tr>
            <td colspan="4">Observaciones:</td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
    </tfooter>
</table>