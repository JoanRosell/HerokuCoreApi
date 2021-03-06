# HerokuCoreApi
En este repo se encuentra una peque帽a demo de una API escrita en .NET Core 5.0 desplegada sobre Heroku. Para poder desplegar la API en Heroku se ha usado Docker.

## 馃И Probar la API
Para probar la API se recomienda usar [Postman](https://www.postman.com/). En este repo se provee una Postman Collection con un conjunto de tests sencillos para probar los distintos endpoints y la gesti贸n de excepciones. La Postman Collection se encuentra [aqu铆](https://github.com/JoanRosell/HerokuCoreApi/blob/main/HerokuCoreApi/Postman/).

En esta Collection hay definidas dos variables globales:
- `local_url` : para pruebas en entorno de desarrollo local. Se espera que la API corra sobre Kestrel en el puerto 5001.
- `heroku_url` : para pruebas de la API en producci贸n.

## 馃殌 Desplegar la API en Heroku
Para desplegar la API se deben seguir estos pasos:
### 1 - Crear una app en Heroku
Lo primero es crear una aplicaci贸n en Heroku especificando un nombre y regi贸n.

### 2 - Instalar Heroku CLI
En el caso de que sea necesario, instalarse Heroku CLI.

### 3 - Autenticarse en Heroku CLI
Una vez tengamos Heroku CLI tenemos que autenticarnos en Heroku y el container registry de Heroku. Para hacer esto ejecutaremos los siguientes comandos:

```bash
$ heroku login
```
```bash
$ heroku container:login
```

### 4 - Construir imagen y desplegar contenedor
**IMPORTANTE: ejecutar estos comandos desde el directorio de la soluci贸n.**

Finalmente vamos a construir la imagen y a desplegar el contenedor con dos comandos:
```bash
$ heroku container:push web --recursive -a your-app-name
```
```bash
$ heroku container:release web -a your-app-name
```

### 5 - Comprobar el estado del dyno revisando los logs
Para acceder a los logs en tiempo real de nuestra aplicaci贸n ejecutaremos el siguiente comando:
```bash
$ heroku logs --tail -a your-app-name
```

Si todo ha ido bien deber铆amos ver los logs de Kestrel arrancando y quedando a la escucha.
