# Revisión del modelo de base de datos.

Este documento tiene por finalidad exponer el análisis del modelo actual respecto de los objetivos pactados en el README.md de la rama main del repositorio.


## Diagrama de Entidad Relación del modelo actual.

### Diagrama actual
![Descripción de la imagen](Documentacion/Activos/Diagramas/Entidad_Relacion/ModeloDatos_Actual.jpg "Modelo de datos actual")


### Estudio
<table>
    <thead>
        <tr>
            <th>Item</th>
            <th>Observación</th>
            <th>Solución propuesta</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Dinámica de juego</td>
            <td>Ne se respeta el modelo solicitado para el almacenamiento.</td>
            <td>Reemplazo en esquema <strong>dbo</strong> de entidades:<br>- "HistorialCartones" por "Partidas"<br>- "HistorialBolillero" por "Bolillero"
            </td>
        </tr>
              <tr>
            <td>Construcción de los cartones</td>
            <td>Posibles cartones duplicados.</td>
            <td>Se incluye atributo "Numeros" en entidad "Cartones" para el control de repetición en los cartones de una misma partida.</td>
        </tr>
        <tr>
            <td>Información almacenable</td>
            <td>Ne se respeta el modelo solicitado para el almacenamiento.</td>
            <td>Tablas solicitadas "HistorialBolillero" e "HistorialCartones":<br>- Nuevo esquema, <strong>Historial</strong> donde se incluyen.<br>- Procedimiento ETL/Tarea Programada para su llenado desde modelo <strong>dbo</strong>.</td>
        </tr>
        <tr>
            <td>Reporte: "Mis partidas jugadas"</td>
            <td>Se puede pre procesar los datos en otro esquema.</td>
            <td>- Nuevo esquema <strong>Replica</strong>.<br>- ETL para el llenado de la tabla "Partidas".</td>
        </tr>
        <tr>
            <td>Reporte: "Partidas general"</td>
            <td>Se puede pre procesar los datos en otro esquema.</td>
            <td>Tablas solicitadas "HistorialBolillero" e "HistorialCartones":<br>- Nuevo esquema, <strong>Historial</strong> donde se incluyen.<br>- Procedimiento ETL/Tarea Programada para su llenado desde modelo <strong>dbo</strong>.</td>
        </tr>
        <tr>
            <td>Reporte: "Histórico exitoso (números ganadores y su probabilidad)"</td>
            <td>Se puede pre procesar los datos en otro esquema.</td>
            <td>- Nuevo esquema <strong>Replica</strong>.<br>- ETL para el llenado de la tabla "Bolillero"*.</td>
        </tr>
        <tr>
            <td>Dashboard: "Mis partidas jugadas"</td>
            <td>Se puede pre procesar los datos en otro esquema.</td>
            <td>- Nuevo esquema <strong>Replica</strong>.<br>- ETL para el llenado de la tabla "Partidas".</tr>
        <tr>
            <td>Dashboard: "Números más jugados"</td>
            <td>Se puede pre procesar los datos en otro esquema.</td>
            <td>Tablas solicitadas "HistorialBolillero" e "HistorialCartones":<br>- Nuevo esquema, <strong>Historial</strong> donde se incluyen.<br>- Procedimiento ETL/Tarea Programada para su llenado desde modelo <strong>dbo</strong>.</td>
        </tr>
        <tr>
            <td>Dashboard: "Números con mayor éxito"</td>
            <td>Se puede pre procesar los datos en otro esquema.</td>
            <td>- Nuevo esquema <strong>Replica</strong>.<br>- ETL para el llenado de las tablas "Partidas" y "Bolillero".</td>
        </tr>
        <tr>
            <td>Dashboard: "Histórico exitoso (números ganadores y su probabilidad)"</td>
            <td>Se puede pre procesar los datos en otro esquema.</td>
            <td>- Nuevo esquema <strong>Replica</strong>.<br>- ETL para el llenado de las tablas "Partidas" y "Bolillero".</td>
        </tr>
        <tr>
            <td>Esquema de roles para usuarios</td>
            <td>Solo se utiliza el nombre del Rol.</td>
            <td>Se prescinde de:<br>- La entidad "AspNetRoleClaims".<br>- Los atributos "NormalizedNames" y "ConcurrencyStamp" de la entidad "AspNetRoles".</td>
        </tr>
        <tr>
            <td>Logeo y registro</td>
            <td>Solo se implementan los datos Id, Nombre, Email, Contrasenia y FechaAlta.</td>
            <td>Se cambia entidad "AspNetUser" por "Usuarios" con atributos referentes a los implementados.</td>
        </tr>
        <tr>
            <td>Validación de correos electrónicos</td>
            <td>Solo se implementan los datos Id, Nombre, Email, Contrasenia y FechaAlta.</td>
            <td>Se cambia entidad "AspNetUser" por "Usuarios" con atributos referentes a los implementados.</td>
        </tr>
        <tr>
            <td>Blanqueo de claves</td>
            <td>Solo se implementan los datos Id, Nombre, Email, Contrasenia y FechaAlta.</td>
            <td>Se cambia entidad "AspNetUser" por "Usuarios" con atributos referentes a los implementados.</td>
        </tr>
    </tbody>
</table>

### Diagrama nuevo
Proximamente...
