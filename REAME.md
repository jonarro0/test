# 🌟 Configuración de Gitpod

## 📁 Archivo de Configuración de Gitpod

El archivo de configuración de Gitpod, `.gitpod.yml`, se encuentra en la raíz del proyecto y es crucial para personalizar tu entorno de desarrollo en la nube. A través de este archivo, puedes configurar diversos aspectos de Gitpod, como la instalación de extensiones, la instalación de paquetes, la ejecución de comandos al iniciar el entorno de desarrollo, y más.

```yaml
image:
  file: .gitpod.Dockerfile

tasks:
  - name: Terminal 1
    init: echo "Iniciando Terminal 1"
    openMode: tab-after
  - name: Terminal 2
    init: echo "Iniciando Terminal 2"
    openMode: tab-after
  - name: Terminal 3
    init: echo "Iniciando Terminal 3"
    openMode: tab-after
  - name: Terminal 4
    init: echo "Iniciando Terminal 4"
    openMode: tab-after
  - name: Terminal 5
    init: echo "Iniciando Terminal 5"
    openMode: tab-after
  - name: Terminal 6
    init: echo "Iniciando Terminal 6"
    openMode: tab-after
  - name: Terminal 7
    init: echo "Iniciando Terminal 7"
    openMode: tab-after
  - name: Terminal 8
    init: echo "Iniciando Terminal 8"
    openMode: tab-after
  - name: Run sqlserver
    init: docker-compose -f docker/sqlserver/docker-compose.yaml up -d

vscode:
  extensions:
    - ms-dotnettools.vscode-dotnet-runtime
```

Este archivo configura la creación de múltiples terminales y el despliegue de un contenedor Docker con SQL Server.

### 🖥️ Creación de Múltiples Terminales

Para habilitar la creación de múltiples terminales, es esencial utilizar la instrucción `openMode` con el valor `tab-after`. Esto asegura que cada terminal se abra en una nueva pestaña, lo cual es más conveniente en este caso. Otros valores de `openMode` como `split-right`, `split-bottom`, `split-left`, y `split-top` dividen la pantalla en diferentes secciones, pero abrir nuevas pestañas proporciona un entorno de trabajo más ordenado.

```yaml
  - name: Terminal 1
    init: echo "Iniciando Terminal 1"
    openMode: tab-after
```

### 🛠️ Configuración del Motor de Base de Datos SQL Server

Para configurar y desplegar un contenedor con SQL Server, se utiliza el siguiente comando dentro del archivo `.gitpod.yml`:

```yaml
  - name: Run sqlserver
    init: docker-compose -f docker/sqlserver/docker-compose.yaml up -d
```

Este comando ejecuta el archivo `docker-compose.yaml` ubicado en la carpeta `docker/sqlserver/`, el cual despliega el contenedor de SQL Server.

### 🔌 Configuración de Extensiones de VS Code

Para añadir extensiones de VS Code en tu entorno de Gitpod, se utiliza la siguiente instrucción en el archivo `.gitpod.yml`:

```yaml
vscode:
  extensions:
    - ms-dotnettools.vscode-dotnet-runtime
```

En este caso, se instala la extensión `ms-dotnettools.vscode-dotnet-runtime`, que facilita el trabajo con proyectos de .NET en VS Code.

### 📄 Creación del Archivo `docker-compose.yaml`

Para desplegar el contenedor de SQL Server, debes crear un archivo `docker-compose.yaml` en la carpeta `docker/sqlserver/` con el siguiente contenido:

```yaml
services:
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2019-CU16-GDR1-ubuntu-20.04
    container_name: smart-workers-sqlserver
    ports:
      - "1433:1433"
    volumes:
      - ~/apps/mssql/data:/var/lib/mssqlql/data
    environment:
      SA_PASSWORD: "mssql1Ipw" # cambiar por una contraseña segura
      ACCEPT_EULA: "Y"
```

Este archivo define un servicio `sqlserver` que utiliza la imagen `mcr.microsoft.com/mssql/server:2019-CU16-GDR1-ubuntu-20.04`. El contenedor mapea el puerto `1433` del contenedor al puerto `1433` del host, asegurando la persistencia de datos mediante un volumen. Además, establece la contraseña del usuario `sa` y acepta el acuerdo de licencia de Microsoft. 

💡 **Nota:** Recuerda cambiar la contraseña `SA_PASSWORD` por una más segura antes de desplegar en producción.