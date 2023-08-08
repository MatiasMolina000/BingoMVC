## Caso de Uso

<table style="border: 2px solid">
    <thead">
        <tr>
            <td><strong>Caso de uso:</strong></td>
            <td>Blanquear clave</td>
            <td><strong>Identificador:</strong></td>
            <td>CU_3</td>
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
            <td colspan="3">Acceso al usuario, si este ha olvidado su contrsaeña permitiendole modificarla por una nueva.</td>
        </tr>
        <tr>
            <td>Precondición:</td>
            <td colspan="3">El usuario debe estar dado de alta en la base de datos.</td>
        </tr>
        <tr>
            <td rowspan="2">Post-condición</td>
            <td colspan="1">Éxito:</td>
            <td colspan="3">El usuario recibe un correo con la clave para poder acceder a su cuenta.</td>
        </tr>
        <tr>
            <td colspan="1">Fracaso:</td>
            <td colspan="3">El usuario no existe en la base de datos o las credenciales son inválidas.</td>
        </tr>
    </thead>
	<tbody style="border-bottom: 2px solid;border-top: 2px solid">
		<tr>
            <td align="center" colspan="2">Curso Normal</td>
            <td align="center" colspan="2">Curso Alternativo</td>
        </tr>
        <tr>
            <td colspan="2">1. El usuario selecciona la opción "Reset Password" de la venta de Logueo.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">2. El sistema muestra la ventana de solicitud de reseteo de clave.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">3. El usuario ingresa su "usuario" y "correo electrónico"</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">4. El usuario selecciona la opción "Reset"</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">5. El sistema le indica al usuario que se ha enviado un correo con su calve blanqueada</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">6.a. "Envío exitoso." El usuario ingresa al correo de confirmación en su casilla de correos y copia la clave de acceso.</td>
            <td colspan="2">6.b. "Envío fallido." El usuario vuelve a solicitar el envío del correo con una nueva clave. (Retorno al curso normal).</td>
        </tr>
        <tr>
            <td colspan="2">7. El usuario vuelve a la ventana de logueo e ingresa con su correo y la clave que recibió por correo.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">8. El sistema lo redirecciona al menú principal y muestra un mensaje de bienvenida.</td>
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