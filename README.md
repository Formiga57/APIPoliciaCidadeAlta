# Exercício de API .NET

Este exercício consiste em criar uma API em que sejam adicionados códigos penais, sendo necessária uma autenticação para consulta, inclusão, edição e visualização destes códigos.

## Relacionamento

O relacionamento de tabelas utilizado e também proposto para este exercício foi o seguinte:
![Relacionamento de tabelas](https://api.formiga57.xyz:2020/TXjpmGAbL8.png)

## JWT

Para autenticação foi utilizado o padrão Token JWT, não foi implementado um sistema de Refresh Token, baseando-se que para maior segurança deve-se evitar armazenar Tokens no cliente.

## Documentação Swagger

Também foi desenvolvido a documentação completa de uso da API utilizando o próprio Swagger oferecido pelo .NET Core
![Documentação do Swagger](https://api.formiga57.xyz:2020/AAjH0J9FZQ.png)

## FrontEnd em React Js

Não foi possível finalizar o desenvolvimento do front-end para melhor visualização da paginação da consulta.

# Como executar

## Inicialização da API

### SQL Server

É necessário ter o SQL Server instalado em seu dispositivo, desta maneira, você deve inserir o seu connection string no arquivo `appsettings.json`:

![Inserindo o Connection String](https://api.formiga57.xyz:2020/Nx90ZT5fos.png)

### Keys e Salt

Também é aconselhável alterar a Key geradora do JWT e o Salt gerador do hash de senhas no `appsettings.json`:

![Inserindo o Connection String](https://api.formiga57.xyz:2020/Nx90ZT5fos.png)

### Portas e URL's

Você pode também alterar as portas de execução da aplicação no arquivo `launchsettings.json` dentro da pasta `Properties` na pasta raiz da API.

### Restauração de Pacotes

Primeiramente, é necessário estar na pasta raiz da API .NET e inserir os comandos para restaurar os pacotes e inicializar o servidor:

<pre>
dotnet restore
dotnet build
dotnet run
</pre>

Após isto a API estará funcionando corretamente, mas vale lembrar que também pode se alterar o Cors no `Program.cs` caso deseje utilizar em outros lugares.
