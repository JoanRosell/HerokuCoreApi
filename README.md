# HerokuCoreApi
En este repo se encuentra una pequeña demo de una API escrita en .NET Core 5.0 desplegada sobre Heroku. Para poder desplegar la API en Heroku se ha usado Docker.

## 🧪 Probar la API
Para probar la API se recomienda usar [Postman](https://www.postman.com/). En este repo se provee una Postman Collection con un conjunto de tests sencillos para probar los distintos endpoints y la gestión de excepciones. La Postman Collection se encuentra [aquí](https://github.com/JoanRosell/HerokuCoreApi/blob/main/HerokuCoreApi/Postman/).

En esta Collection hay definidas dos variables globales:
- `local_url` : para pruebas en entorno de desarrollo local. Se espera que la API corra sobre Kestrel en el puerto 5001.
- `heroku_url` : para pruebas de la API en producción.

## 🚀 Desplegar la API en Heroku
Para desplegar la API se deben seguir estos pasos:
### 1 - Crear una app en Heroku
Lo primero es crear una aplicación en Heroku especificando un nombre y región.

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
**IMPORTANTE: ejecutar estos comandos desde el directorio de la solución.**

Finalmente vamos a construir la imagen y a desplegar el contenedor con dos comandos:
```bash
$ heroku container:push web --recursive -a your-app-name
```
```bash
$ heroku container:release web -a your-app-name
```

### 5 - Comprobar el estado del dyno revisando los logs
Para acceder a los logs en tiempo real de nuestra aplicación ejecutaremos el siguiente comando:
```bash
$ heroku logs --tail -a your-app-name
```

Si todo ha ido bien deberíamos ver los logs de Kestrel arrancando y quedando a la escucha.
