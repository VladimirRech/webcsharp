# Links

1. [Instalando .Net Core no Manjaro](https://www.how2shout.com/linux/how-to-install-net-core-on-manjaro-linux/)
6. [Instalando .Net Core no Manjaro By Microsoft](https://dotnet.microsoft.com/en-us/download)
2. [Padrão de nomenclatura - Stack Overflow](https://stackoverflow.com/questions/62951664/microservices-naming-convention-with-api-and-background-workers-messagebus-sche)
3. [Referência Microsoft](https://docs.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming)
4. [Create microservices with .NET and ASP.NET Core](https://docs.microsoft.com/en-us/learn/paths/create-microservices-with-dotnet/)
5. [Implement a microservice domain model with .NET](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/net-core-microservice-domain-model)
1. **[Creating a simple data-driven CRUD microservice](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/data-driven-crud-microservice)**
1. [Install Docker](https://docs.docker.com/desktop/install/linux-install/)
1. [Install Docker on Arch based Linux](https://docs.docker.com/desktop/install/archlinux/)
1. [Install SQL Server Manjaro](https://forum.manjaro.org/t/how-do-i-install-microsoft-sql-server/84888/3)
1. [Instructions to install Docker-desktop on Arch based Linux](https://docs.docker.com/desktop/install/archlinux/)
1. [Config Docker daemon](https://docs.docker.com/config/daemon/)
1. [How to install .NET core SDK with ASP.NET on Manjaro Linux](https://dev.to/alexandrunastase/how-to-install-net-core-sdk-with-asp-net-on-manjaro-linux-1m34)
1. [Post in ASP.NET Core REST API](https://www.pragimtech.com/blog/blazor/post-in-aspnet-core-rest-api/)
1. [Install Entity Framework](https://docs.microsoft.com/en-us/ef/core/get-started/overview/install)
1. [Controller action return types in ASP.NET Core web API](https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0)
1. [Updating Related Data with the Entity Framework in an ASP.NET MVC Application (6 of 10)](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application)
1. [ASP.NET Core - Return 500 (Internal Server Error) or any other Status Code from API](https://www.abhith.net/blog/aspnet-core-return-500-internal-server-error-or-any-other-status-code-from-api/)
1. [Passing Input Parameters to .NET Core Web API Actions](https://thecodeblogger.com/2021/06/01/passing-input-parameters-to-net-core-web-api-actions/)
1. [Working with entity states](https://docs.microsoft.com/en-us/ef/ef6/saving/change-tracking/entity-state)

# Comandos de manutenção - Manjaro/Arch

## Lista sdk instalado
```shell
$ dotnet --list-sdks
```

## Lista runtime instalado
```shell
$ dotnet --list-runtimes
```

## Instalar sdk
```shell
$ pamac install dotnet-sdk   
```

## Instalar runtimes
```shell
$ pamac install dotnet-runtime
```

# Sobre Docker Desktop
A instalação no Arch Linux deve seguir dois passos principais:

1. Instalação do runtime que pode ser feito via terminal.
2. Instalação do desktop - um tutorial completo pode ser encontrado neste [link](https://docs.docker.com/desktop/install/archlinux/)

## Instalação do runtime via terminal
```shell
$ pamac install docker
```

Após a instalação de todos os pacotes deve aparecer na interface gráfica ou, se preferir, verifique no terminal com o utilitário `pamac`:
```shell
$ pamac list | grep -i "docker"
docker                                   1:20.10.17-1                  community  168,1 MB
docker-desktop                           4.11.1-84025                             1,2 GB
```

Antes de rodar qualquer build é necessário inicializar o daemon do Docker no Linux, caso deseje rodar manualmente:
```shell
$ sudo dockerd &
```

> **Nota**: o aplicativo **Docker Desktop** é *experimental* para o Arch Linux, o que significa que está sujeito a instabilidades e funcionalidades não suportadas.

# Passos para instalar Microsoft SQL Server
Guia de [referência](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-setup?view=sql-server-ver16) para Arch/Majaro.

Resumidamente, basta rodar o comando à seguir e ir respondendo às questões do assistente:
```shell
$ pamac install mssql-server mssql-tools
$ pamac build mssql-server mssql-tools
```

Pasta de referência onde arquivos estão instalados: /opt

Porém, os passos acima não foram suficientes para a instalação bem sucedida, sendo assim, usei outros:

* Gerenciador gráfico de pacotes
  1. Instalar `mssql-server`
  2. Instalar `mssql-tools`
  3. No prompt, inicializar a configuração rodando `sudo /opt/mssql/bin/mssql-conf setup`
    * Escolher edição: escolhida Express
    * Escolher idioma: inglẽs
    * Senha do administrador: *********
4. Com isto, o console informou que o SQL Server foi iniciado.

---
# Criando dotnet API vazia sem Visual Studio
#### Comandos de referência

* **dotnet new**: para criar novo projeto
* **dotnet new --list**: para listar projetos disponíveis.
* **Exemplo**: `dotnet new webapi -n <nome do projeto>`

É necessário ter o aspnet.core instalado para rodar.
Comando:
```shell
$ sudo pamac install aspnet-runtime 
```
Não é necessário reiniciar.

----

# Instalando Entity Framework
Para instalar é necessário rodar os seguintes comandos:
```shell
$ dotnet add package Microsoft.EntityFrameworkCore.SqlServer
$ dotnet add package Microsoft.EntityFrameworkCore
$ dotnet add package Microsoft.EntityFrameworkCore.Tools
```

Link de [tutorial](https://www.c-sharpcorner.com/article/building-asp-net-web-api-in-net-core-with-entity-framework/).

* Para funcionar tem de colocar referência à `Microsoft.Extensions.Configurations`.
* Adicionar um construtor que receba a string de conexão no DbContext.

Links para ajudar a resolver problemas com o Entity no DotNet Core:

1. [Projeto no Git com várias partes prontsas](https://github.com/kerminator-dev/Country-Info/blob/main/src/CountryInfo/CountryInfoAPI/Controllers/BaseController.cs)
2. [Configurando connection string](https://www.c-sharpcorner.com/blogs/setting-connection-strings-in-net-core-web-api-with-multiple-tenant-sql-db2)
3. [Store and read connection string](https://www.connectionstrings.com/store-and-read-connection-string-in-appsettings-json/)
4. [Tutorial asp.net core](https://www.connectionstrings.com/store-and-read-connection-string-in-appsettings-json/)
5. [Resolvendo problemas com a exception System.PlatformNotSupportedException: Strings.PlatformNotSupported_DataSqlClient on Linux after migrating to .NET 6](https://docs.microsoft.com/en-us/answers/questions/655201/systemplatformnotsupportedexception-stringsplatfor.html)

#### Problemas com EF no Linux
No projeto foi necessário informar na string de conexão o usuário e a senha. A autenticação integrada não funcionou (por conta de estar rodando sob o Linux). A API fechava ao realizar a requisição.

#### Outros comandos úteis:
Rodando api para que tenha compatibilidade com o Linux Manjaro:
```shell
$  dotnet run --arch x64 --os linux
``` 

Estes comandos podem ser inseridos como argumentos de inicialização do modo DEBUG no arquivo `launch.json`, abaixo um exemplo:
```json
{
    "version": "0.2.0",
    "configurations": [

        {
          ...
            "program": "${workspaceFolder}/src/study-schedule-api/bin/Debug/net6.0/study-schedule-api.dll",
            "args": ["--arch", "x64", "--os", "linux"],
            ...
```