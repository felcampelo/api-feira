# API Feira - Felipe Campêlo

Pré-Requisitos para rodar o projeto:

- Visual Studio 2022 (Community/Professional/Enterprise);
- Sql Server 2014 ou superior;
- Sql Server Management Studio;

Índice: 

1. Setup do Projeto
2. Estrutura do Projeto 
3. Exemplos de Chamadas e Respostas



1. Setup do Projeto

Após clonar o repositório deste projeto na máquina, clique e abra o arquivo de solução chamado "fair.api.sln". É necessário antes de mais nada criar o banco de dados, a tabela e executar a carga dos dados que serão consumidos pela aplicação.
Para tal, no projeto "fair.api", existe uma pasta chamada "Datasource" e uma outra chamada "Script". 

Na pasta "Datasource", temos o arquivo .csv com os dados a serem importados, e na pasta script, o script sql que irá fazer a carga dos dados contidos no .csv

![image](https://user-images.githubusercontent.com/16122433/196055722-142bf50b-c272-4a71-92e0-f75076894bc5.png)

Passos para a carga dos dados:

1 - Conecte na instância de banco de dados do sql server configurada em sua máquina utilizando o Sql Server Management Studio;
2 - Abra o arquivo "Script Carga Feiras.sql" no Management Studio. Antes de executar o script, você deve trocar o path referente ao arquivo .csv, informando o path aonde o arquivo se encontra em sua máquina:

![image](https://user-images.githubusercontent.com/16122433/196055969-db51c088-5f07-4c56-a106-d4b226935eda.png)

Após preencher o path de acordo com o local aonde o arquivo se encontra em sua máquina, nada mais deve ser alterado. Agora basta apertar f5 para rodar o script. 
O script irá criar o banco de dados, a tabela e irá dar a carga dos dados contidos no .csv. Após essa etapa, precisamos agora revisar as strings de conexão na aplicação.


De volta ao projeto fair.api, abra o arquivo "appsettings.json". Caso o seu sql server esteja configurado com autenticação por usuário e senha, você deve alterar a string de conexão com as respectivas credenciais. Caso se conecte ao banco usando autenticação windows, nada precisa ser feito, como mostrado na imagem abaixo:

![image](https://user-images.githubusercontent.com/16122433/196056135-5afcf520-9d2f-46f4-a439-80c670aaa9c6.png)


2. Estrutura do Projeto

O Projeto foi construído utilizando-se o Asp.Net Core 6 (.net 6), Entity Framework 6, com base na arquitetura limpa (Clean Architecture), utilizando o pattern de repositórios e repositório base (Repository/Base Repository), visando respeitar aos princípios SOLID e com cobertura de testes/código documentado. 
Utilizou-se também para a construção de logs estruturados o Serilog.

O projeto foi dividido em 6 camadas:

fair.api:
- Camada que contém as api's/controllers que são expostas para serem consumidas.

fair.application:
- Camada que contém as regras de negócio, bem como os objetos de transferência (Data Transfer Objects - DTO).

fair.domain: 
- Camada que contém as entidades do nosso domínio, bem como interfaces dos repositórios

fair.infra:
- Camada que contém  o mapeamento das entidades (Contexto do EF), bem como as implementações dos repositórios e repositório base.

fair.ioc
- Camada responsável por registrar as injeções de dependência da aplicação;

fair.tests
- Camada responsável por executar os testes da aplicação.









