## Caso de Uso

<table style="border: 2px solid">
    <thead">
        <tr>
            <td><strong>Caso de uso:</strong></td>
            <td>Modificar de datos personales</td>
            <td><strong>Identificador:</strong></td>
            <td>CU_5</td>
        <tr>
        <tr>
            <td colspan="2"><strong>Nivel de caso de uso:</strong></td>
            <td colspan="2">Usuario final</td>
        </tr>
        <tr>
            <td><strong>Prioridad:</strong></td>
            <td colspan="3">Baja</td>
        </tr>
        <tr>
            <td><strong>Complejidad:</strong></td>
            <td colspan="3">Baja</td>
        </tr>
        <tr>
            <td><strong>Actor Principal:</strong></td>
            <td>Usuario final</td>
            <td><strong>Actor Secundario:</strong></td>
            <td>No aplica</td>
        </tr>
        <tr>
            <td>Objetivo:</td>
            <td colspan="3">El usuario puede actualizar sus datos.</td>
        </tr>
        <tr>
            <td>Precondición:</td>
            <td colspan="3">El usuario debe estar dado de alta en la base de datos y tener validado su correo.</td>
        </tr>
        <tr>
            <td rowspan="2">Post-condición</td>
            <td colspan="1">Éxito:</td>
            <td colspan="3">Los datos del usuario se actualizan según se solicitó.</td>
        </tr>
        <tr>
            <td colspan="1">Fracaso:</td>
            <td colspan="3">Los datos del usuario ya existen para otro usuario.</td>
        </tr>
    </thead>
	<tbody style="border-bottom: 2px solid;border-top: 2px solid">
		<tr>
            <td align="center" colspan="2">Curso Normal</td>
            <td align="center" colspan="2">Curso Alternativo</td>
        </tr>
        <tr>
            <td colspan="2">1. El usuario selecciona la opción "My account" del menú principal.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">2. El sistema muestra una pantalla con los datos del usuario.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">3.a. El usuario elije la opción "Change" de algún dato que no corresponde al correo.</td>
            <td colspan="2">3.b. El usuario elije la opción "Change" correspondiente al correo.</td>
        </tr>
        <tr>
            <td colspan="2">4.a. El sistema muestra un pequeño formulario con el campo.</td>
            <td colspan="2">4.b. Idem al paso del curso normal</td>
        </tr>
        <tr>
            <td colspan="2">5.a. El usuario realiza ingresa el nuevo dato.</td>
            <td colspan="2">5.b. Idem al paso del curso normal</td>
        </tr>
        <tr>
            <td colspan="2">6.a. El usuario selecciona la opción "Save".</td>
            <td colspan="2">6.b. Idem al paso del curso normal</td>
        </tr>
        <tr>
            <td colspan="2">7.a. El sistema muestra un mensaje del correcto cambio del campo.</td>
            <td colspan="2">7.b. El caso de uso continúa en el CU_2.</td>
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