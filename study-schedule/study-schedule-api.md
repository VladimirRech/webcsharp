# Links

1. [Instalando .Net Core no Manjaro](https://www.how2shout.com/linux/how-to-install-net-core-on-manjaro-linux/)
6. [Instalando .Net Core no Manjaro By Microsoft](https://dotnet.microsoft.com/en-us/download)
2. [Padrão de nomenclatura - Stack Overflow](https://stackoverflow.com/questions/62951664/microservices-naming-convention-with-api-and-background-workers-messagebus-sche)
3. [Referência Microsoft](https://docs.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming)
4. [Create microservices with .NET and ASP.NET Core](https://docs.microsoft.com/en-us/learn/paths/create-microservices-with-dotnet/)
5. [Implement a microservice domain model with .NET](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/net-core-microservice-domain-model)
1. [Install Docker](https://docs.docker.com/desktop/install/linux-install/)
1. [Install Docker on Arch based Linux](https://docs.docker.com/desktop/install/archlinux/)

# Comandos de manutenção - Manjaro/Arch

## Lista sdk instalado
````shell
$ dotnet --list-sdks
````

## Lista runtime instalado
````shell
$ dotnet --list-runtimes
````

## Instalar sdk
````shell
$ pamac install dotnet-sdk   
````

## Instalar runtimes
````shell
$ pamac install dotnet-runtime
````

# Sobre Docker Desktop
A instalação no Arch Linux deve seguir dois passos principais:

1. Instalação do runtime que pode ser feito via terminal.
2. Instalação do desktop - um tutorial completo pode ser encontrado neste [link](https://docs.docker.com/desktop/install/archlinux/)

## Instalação do runtime via terminal
````shell
$ pamac install docker
````

Após a instalação de todos os pacotes deve aparecer na interface gráfica ou, se preferir, verifique no terminal com o utilitário `pamac`:
````shell
$ pamac list | grep -i "docker"
docker                                   1:20.10.17-1                  community  168,1 MB
docker-desktop                           4.11.1-84025                             1,2 GB
````

> **Nota**: o aplicativo **Docker Desktop** é *experimental* para o Arch Linux, o que significa que está sujeito a instabilidades e funcionalidades não suportadas.