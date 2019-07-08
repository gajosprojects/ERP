# Guia de instalação

## Levantando o ambiente

### Intalações principais

- [VS Code](https://goo.gl/J7Gdge)
- [ASP Net Core SDK](https://goo.gl/8D2pPQ)
- [SQL Server](https://goo.gl/bymzKj)
- [SSMS](https://goo.gl/Z1wDEC) ou [Azure Data Studio](https://docs.microsoft.com/pt-br/sql/azure-data-studio/download?view=sql-server-2017)
- [Git](https://goo.gl/s99fT2)
- [Commander *(Opcional)*](https://goo.gl/RdV6Mq)

### Instalações secudárias

#### Visual Studio Code Extensions
- C# - *Microsoft*
- C# Extensions - *jchannon*
- IntelliSense for CSS class names in HTML - *Zignd*
- vscode-icons - *Roberto Huertas*
- vscode-solution-explorer - *Fernando Escolar*
- .NET Core Test Explorer - *Jun Han*
- Git Blame - *Wade Anderson*
- GitLens - Git supercharged *Eric Amodio*
- Trello Viewer - *Ho-Wan*
- TODO Highlight *(Opcional)* - *Wayou Liu*
- Dracula Official *(Opcional)* - *Dracula Theme*

## Iniciando o projeto

Com o SDK instalado teremos todo ferramental a nossa disposição.

- Abra um terminal e faça um clone do projeto
- Vá até a pasta do projeto e dê o comando abaixo para que abra a pasta atual no VSCode.
```sh 
$ code .
```
- Após a abertura do projeto, no terminal envie o comando abaixo para que todas as dependências dos projetos sejam baixadas.
```sh 
$ dotnet restore
``` 
- Envie o comando para validar se está tudo correto.
```sh 
$ dotnet build
``` 
- Caso todos os passos tenham sido feitos corretamente e não existam erros no projeto rode o comando abaixo para rodar o projeto.
```sh 
$ dotnet run
``` 