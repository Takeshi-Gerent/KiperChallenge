
# Desafio Kipper

**Demanda**

*Você foi contratado para desenvolver uma aplicação web de ​gestão de condomínio. O seu contratante te forneceu a seguinte orientação:*
>Preciso de um sistema web que me permita realizar o cadastro de apartamentos e os seus moradores. Cada apartamento possui um número, um bloco e vários moradores, sendo que deve ser obrigatório ao menos um morador. 
O morador possui as seguintes informações: Nome completo, data de nascimento, telefone, cpf e e-mail.

- Eu devo poder incluir, alterar e excluir livremente os registros de apartamento e moradores.

- Deve existir um mecanismo de busca que me permita encontrar todos os moradores de determinado apartamento, bem como a busca específica por informações do morador.

- Deve existir um mecanismo de login e senha para que o sistema possa ser acessado

## Diagrama ER

![ER](https://mermaid.ink/img/eyJjb2RlIjoiY2xhc3NEaWFncmFtXG5BcGFydG1lbnQgXCIxXCIgLS0-IFwiMS4uKlwiIER3ZWxsZXJcbmNsYXNzIEFwYXJ0bWVudCB7XG4gaW50IElkXG4gaW50IE51bWJlclxuIHZhcmNoYXJ-NX4gQmxvY2tcbn1cbmNsYXNzIER3ZWxsZXIge1xuIGludCBJZFxuIHZhcmNoYXJ-NDB-IE5hbWVcbiBkYXRldGltZSBCaXJ0aERhdGVcbiB2YXJjaGFyfjE1fiBUZWxlcGhvbmVcbiB2YXJjaGFyfjE1fiBDUEZcbiB2YXJjaGFyfjQwfiBFbWFpbFxufVxuY2xhc3MgVXNlciB7XG4gaW50IElkXG4gdmFyY2hhcn4yMH4gVXNlck5hbWUgXG4gdmFyY2hhcn4yMH4gUGFzc3dvcmRcbn1cbiIsIm1lcm1haWQiOnsidGhlbWUiOiJkZWZhdWx0In0sInVwZGF0ZUVkaXRvciI6ZmFsc2V9)

## Projeto

> git clone https://github.com/Takeshi-Gerent/KiperChallenge.git  
`cd KiperChallenge\src`


## DOCKER

> Bridge network  
`docker network create -d bridge kiperchallengenetwork`

> Iniciar MySql  
`docker-compose -f infra.yml up -d`

> Criar a base de dados  
`docker-compose -f database.yml up -d`

> *"Subir"* as aplicações  
`docker-compose up -d --build`

## Aplicação

> Web  
`Endereços: http://localhost:3001`  
`Usuario:admin; Senha:password`

> Backend  
`Auth.Api: http://localhost:5080/info`  
`Condominium.Api: http://localhost:5081/info`
