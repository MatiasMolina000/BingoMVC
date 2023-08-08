## Caso de Uso

<table style="border: 2px solid">
    <thead">
        <tr>
            <td><strong>Caso de uso:</strong></td>
            <td>Validar correo</td>
            <td><strong>Identificador:</strong></td>
            <td>CU_2</td>
        <tr>
        <tr>
            <td colspan="2"><strong>Nivel de caso de uso:</strong></td>
            <td colspan="2">Usuario final</td>
        </tr>
        <tr>
            <td><strong>Prioridad:</strong></td>
            <td colspan="3">Media</td>
        </tr>
        <tr>
            <td><strong>Complejidad:</strong></td>
            <td colspan="3">Media</td>
        </tr>
        <tr>
            <td><strong>Actor Principal:</strong></td>
            <td>Usuario final</td>
            <td><strong>Actor Secundario:</strong></td>
            <td>No aplica</td>
        </tr>
        <tr>
            <td>Objetivo:</td>
            <td colspan="3">Alta del usuario.</td>
        </tr>
        <tr>
            <td>Precondición:</td>
            <td colspan="3">El usuario debe habrese registrado por primera y única vez en la base de datos.</td>
        </tr>
        <tr>
            <td rowspan="2">Post-condición</td>
            <td colspan="1">Éxito:</td>
            <td colspan="3">El usuario tiene validado su correo.</td>
        </tr>
        <tr>
            <td colspan="1">Fracaso:</td>
            <td colspan="3">El usuario no posee un correo validado.</td>
        </tr>
    </thead>
	<tbody style="border-bottom: 2px solid;border-top: 2px solid">
		<tr>
            <td align="center" colspan="2">Curso Normal</td>
            <td align="center" colspan="2">Curso Alternativo</td>
        </tr>
        <tr>
            <td colspan="2">1. El caso de uso comienza cuando el usuario finaliza el registro y se le indica revisar su correo</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">2.a. "Envío exitoso." El usuario ingresa al correo de confirmación en su casilla de correos y copia la clave de acceso. La misma con la que se registró.</td>
            <td colspan="2">2.b. "Envío fallido." El usuario vuelve a solicitar el envío del correo con una nueva clave. (Retorno al curso normal).</td>
        </tr>
        <tr>
            <td colspan="2">3. El usuario vuelve a la ventana de logueo e ingresa con su correo y la clave que recibió por correo.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">4. El sistema lo redirecciona al menú principal y muestra un mensaje de bienvenida.</td>
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
            <td colspan="4">Los usuarios que no completan el proceso de validación de correo electrónico serán dados de baja de la base de datos para liberar acceso a otros usuarios.</td>
        </tr>
    </tfooter>
</table>