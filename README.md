Usando las herramientas de programación que mas conoces debes crear una aplicación de citas para mantenimiento de vehículos para esto:

El usuario indica un numero de placa de vehículo. Ejemplo LOGIC123
El sistema te recupera todas las citas que tienes para esa placa.
Ejemplo: No tiene citas
Ejemplo:
 
5-Abril-2022 9:30 am ATENDIDA

3-Mayo-2022 9:30 am PROGRAMADA

El usuario puede solicitar una nueva cita (por ejemplo con un botón)
El sistema le solicitar un fecha y hora de atención (es buena idea que se usen un control de calendario y horas definidas en periodos de 30 minutos, por ejemplo 8:00,  8:30 … hasta las 14:00)
El usuario guarda la cita (por ejemplo con un botón)
El sistema crea un registro en la tabla de citas con el numero de placa, fecha y hora solicitada con el estado PROGRAMADA
 

El diseño visual y la forma de interactuar con el sistema queda a tu criterio.

Es indispensable que la solución tenga al menos 2 componentes un front-end en la tecnología que conoces y un back-end (APIs) escrito en C#

 

Todos los datos deben guardarse en un base  de datos de 1 o 2 tablas máximo. Tu puedes escoger el motor de base de datos que mas conoces (mysql, sql, …)

 

Envíame tu código y las capturas del funcionamiento de las pantallas en un documento Word puedes enviármelo en ZIP o punto extra si lo subes a GIT


Cualquier pregunta me haces saber por chat, espero tu respuesta entre 2 a 4 horas a partir de la recepción de este email


Explicación

El Ejecutar el programa se vera de la siguiente manera

![image](https://user-images.githubusercontent.com/52641606/164873366-91d4749d-9d3e-4392-bc8a-4a2f696ba72e.png)

Se debera ingresar a la pestaña Vehiculos

![image](https://user-images.githubusercontent.com/52641606/164873389-967a567e-f80e-468f-9a49-50af484897bd.png)

El Usuario podra registrar nuevas placas, estas deberan contar con maximo de 6 caracteres

![image](https://user-images.githubusercontent.com/52641606/164873406-af794451-6e8c-468d-89dd-36bb845b44d3.png)

En los detalles podremos ver las citas Agendadas

![image](https://user-images.githubusercontent.com/52641606/164873417-6de51d82-a0a2-4e18-996b-8ee1bd6eae89.png)

Y agendar nuevas citas en la pestaña de Nueva Cita

![image](https://user-images.githubusercontent.com/52641606/164873437-9f038ee3-9ff3-4909-b6d9-486e3356bbc3.png)

Los estados y horas se configuraron con un Seeder dentro del Software, en caso de requerir mas estados se debera añadir dentro de esta pestaña,

![image](https://user-images.githubusercontent.com/52641606/164873459-dea5423c-15da-4c77-b8f2-7864b730af82.png)

La base de Datos contiene 4 tablas BDD (SQL SERVER)

![image](https://user-images.githubusercontent.com/52641606/164873502-357a450c-8054-43ed-b28e-19e757c39777.png)


Se realizo una arquitectura monolitica con el patron MVC lenguaje C# y metodologia Code First.

Muchas Gracias


