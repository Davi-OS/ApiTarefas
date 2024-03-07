# Projeto de Gerenciamento de Tarefas com Minimal API em .NET

Bem-vindo ao repositório do projeto de gerenciamento de tarefas com Minimal API em .NET! Este projeto tem como objetivo fornecer um exemplo prático de como criar e entender uma Minimal API em .NET para gerenciar tarefas de usuário. A aplicação permite realizar operações CRUD na memória local do navegador usando o Entity Framework.

## Funcionalidades

1. **Minimal API em .NET**: O projeto utiliza a abordagem Minimal API para criar endpoints simples e eficientes, facilitando a compreensão e implementação.

2. **Gerenciamento de Tarefas**: A API possibilita o gerenciamento de tarefas para um usuário, incluindo a criação, leitura, atualização e exclusão de registros.

3. **Memória Local do Navegador**: As tarefas são armazenadas na memória local do navegador, proporcionando uma experiência leve e sem a necessidade de um banco de dados externo.

4. **Entity Framework**: Mesmo utilizando a memória local, o Entity Framework é empregado para simplificar a manipulação dos dados e fornecer uma interface consistente para as operações CRUD.

5. **Swagger para Teste de Endpoints**: O projeto inclui a integração do Swagger, permitindo a visualização e interação com os endpoints da API de forma fácil e documentada.

## Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas antes de executar o projeto:

- Visual Studio (ou Visual Studio Code) com suporte a desenvolvimento .NET.
- Um navegador web compatível.

## Configuração

1. Clone o repositório para sua máquina local.
   ```
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
   ```

2. Abra o projeto no Visual Studio ou Visual Studio Code.

3. Execute o projeto.

4. Abra o navegador e acesse o Swagger para testar e interagir com os endpoints da API:
   ```
   https://localhost:PORTA/swagger
   ```

## Endpoints da API

A API oferece os seguintes endpoints principais:

- `GET /api/tarefas`: Obtém a lista de todas as tarefas do usuário.
- `GET /api/tarefas/{id}`: Obtém detalhes de uma tarefa específica.
- `POST /api/tarefas`: Cria uma nova tarefa.
- `PUT /api/tarefas/{id}`: Atualiza os detalhes de uma tarefa existente.
- `DELETE /api/tarefas/{id}`: Exclui uma tarefa.

--- 
