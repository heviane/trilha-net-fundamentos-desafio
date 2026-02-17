# Notes

## Lab: Projeto Minimal Api

Criar uma API usando a técnica de Minimal API

- [X] Introdução
- [X] O que precisa ter instalado para começar
- [X] Definição do que teremos no projeto
- [X] Login (senha em texto simples no BD)
  - [X] Criando uma rota login para validação em memória
  - [X] Configurando o projeto com Entity Framework e tabela de Administradores
  - [X] Criando Seed para cadastrar administrador padrão
  - [X] Validando administrador com login e senha no banco de dados
- [X] Configurando modelo de veículos
- [X] Swagger
  - [X] Configurando Swagger na App
  - [X] Organizando rotas por contexto no Swagger
- [X] Criando rota Home respondendo por JSON
- [X] CRUD de Veículos
  - [X] POST criar veículo
  - [X] GET retornar uma lista de veiculos
  - [X] GET para retornar um veiculo por Id
  - [X] PUT para atualizar veiculo
  - [X] DELETE para deletar veiculo
  - [X] Criando validação ao cadastrar/atualizar veiculo
- [ ] Autenticação/Autorização de acesso
  - [X] Criando endpoints para administrador (POST, POST login, GET all, GET by id, DELETE)
    - [X] Criação de ModelView para não expor a senha nos retornos
    - [X] Criação do Attributo Perfil com o uso de Enum
  - [X] Configurando Token JWT no projeto
    - [X] Instalar o pacote do Token JWT: `dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --project src/api/Apps/MinimalApi`
    - [X] Configurar o `appsettings.json`
    - [X] Configurar no `Program.cs` as seções: Builder e App.
    - [X] Alterar todas as rotas no `Program.cs` para torna-las restritas, exceto home e login.
    - [X] Alterar endpoint /login para retornar um Token JWT. Token gerado testado em [https://www.jwt.io](https://www.jwt.io)
  - [X] Configurando Swagger para a passagem de token
    - [X] No `Program.cs` foi incluido a configuração necessária para passar o token no swagger, e configurado `AllowAnonymous()` para os endpoint `/` e `/Administrators/login`.
    - [X] Como testar? O token será gerado no `login`, copia e cola no botão `Authorize` no topo da página. Pronto, você estará autenticado.
  - [X] Criando autorizações de acesso para os perfis de Admin e User
    - [X] No `Program.cs` foi adicionado o ClaimTypes.Role na lista de Claims.
- [ ] Testes
  - [X] Refatorar o projeto para criar uma solution (sln) e um projeto de testes com o template `mstest`
  - [X] Criar testes de unidade para a entidade `Administrator`, validando a criação e o estado inicial do objeto.
  - [X] Criar teste de serviço para `ServiceAdministrator`, validando a funcionalidade de criação de um administrador em um banco de dados em memória.
    - `AdministratorServiceTest.cs` são excelentes testes de unidade/integração de serviço. Eles usam um banco de dados em memória para validar a lógica de negócio do seu `ServiceAdministrator` de forma rápida e isolada.
  - [ ] Criar testes de persistencia
  - [ ] Criar testes de request
- [ ] DevOps
  - [ ] Fazendo deploy da app
- [ ] Entendendo o desáfio

faltam 18 aulas em 23/09/2025.
faltam 20 aulas em 22/09/2025.
bootcamp termina em 11/10/2025.
