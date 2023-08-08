# Definición genera de procesos.

Este documento tiene por finalidad exponer el análisis de los procesos definidos en el apartado requerimientos del README.md de la rama main del repositorio.

## Itos
| N° | Descripción |
|----|-------------|
|1|Descripción-Logeo y registro|
|2|Descripción-Validación de correos electrónicos|
|3|Descripción-Blanqueo de claves|
|4|Dinámica de juego|
|5|Descripción-Sección para administración del usuario|
|6|Descripción-Diseño de reportes|
|7|Descripción-Diseño de Dashboard informativo|

## Listado de casos de uso
| Id | Ito | Caso de Uso | Descripción | Prioridad | Complejidad |
|----|-----|-------------|-------------|-----------|-------------|
|**CU_1_1**|1|**Loguear**|Login de usuario en aplicación web|Alta|Baja|
|**CU_1_2**|1|**Registrar usuario**|Registro único y por primera vez del usuario|Alta|Media|
|**CU_2**|2|**Validar correo**|Confrimación del correo por parte del usuario|Media|Media|
|**CU_3**|3|**Blanquear clave**|Cambio de contraseña por parte del usuario|Baja|Baja|
|**CU_4**|4|**Jugar**|Proceso central según la dinámica de juego en el requerimiento|Alta|Alta|
|**CU_5**|5|**Modificar de datos personales**|Modificacion, por parte del usuario, de sus datos|Baja|Baja|
|**CU_6**|6|**Ver reporte**|Acceso a los reportes|Baja|Media|
|**CU_7**|7|**Ver dashboard**|Acceso al tablero de infromación|Baja|Alta|