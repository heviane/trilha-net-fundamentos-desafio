# Melhores Práticas

## Architecture

### Separação de Responsabilidades (SoC)

A comunidade consolidou alguns padrões que promovem a Separação de Responsabilidades (SoC).
A abordagem mais popular e recomendada atualmente é uma variação da Clean Architecture (ou Arquitetura Limpa/Onion Architecture).

### Clean Architecture/Onion Architecture (Abordagem mais popular)

Ela promove a separação do código em camadas, onde cada camada tem uma responsabilidade específica.
Isso ajuda a manter o código organizado, facilita a manutenção e promove a testabilidade.

A ideia central é organizar o projeto em camadas, onde as dependências apontam sempre para o "centro" (o domínio), que é a parte mais estável e importante da sua aplicação.

As camadas recomendadas são:

- **Domain**: Contém as entidades de negócio e interfaces dos serviços.
- **Application**: Contém a lógica de aplicação, como serviços que implementam as interfaces do domínio.
- **Infrastructure**: Contém a implementação dos serviços, como acesso a banco de dados, serviços externos, etc.
- **API**: Contém a configuração da aplicação, rotas e middleware.

Cada camada deve depender apenas das camadas internas, promovendo a inversão de dependência.
Isso significa que a camada de API depende da camada de Application, que depende da camada de Domain e assim por diante.

#### Estrutura do Projeto

```plaintext
/src/api/Apps/MinimalApi/
│
├── 1. Domain/
│   ├── Entities/
│   │   └── Vehicle.cs
│   │   └── Administrator.cs
│   ├── DTOs/
│   │   └── LoginDTO.cs
│   ├── Interfaces/
│   │   └── IServiceVehicle.cs
│   │   └── IServiceAdministrator.cs
│   └── Enums/
│
├── 2. Application/ (ou Services/)
│   └── VehicleService.cs
│   └── AdministratorService.cs
│
├── 3. Infrastructure/
│   ├── Db/
│   │   └── DbContexto.cs
│   ├── Repositories/
│   │   └── VehicleRepository.cs
│   └── Auth/
│       └── TokenService.cs
│
├── 4. Presentation/ (ou a raiz do projeto de API)
│   ├── Endpoints/
│   │   └── VehicleEndpoints.cs
│   ├── Middlewares/
│   └── Program.cs
│
└── MinimalApi.csproj
```

- Domain (O Coração da Aplicação)

O que contém? Entidades (Vehicle), DTOs, Enums e, crucialmente, as interfaces dos seus serviços e repositórios (IServiceVehicle).
Regra de Ouro: Esta camada não depende de nenhuma outra. Ela não sabe o que é um banco de dados, uma API ou qualquer detalhe de infraestrutura. É puro C# com a lógica e as regras de negócio centrais.

- Application (Os Casos de Uso)

O que contém? As implementações concretas das suas interfaces de serviço (ServiceVehicle). Esta camada orquestra o fluxo de dados, chama os métodos do domínio e utiliza as interfaces da infraestrutura para realizar operações.
Dependências: Depende apenas do Domain.

- Infrastructure (Os Detalhes Técnicos)

O que contém? Tudo o que interage com o "mundo exterior": acesso ao banco de dados (Entity Framework Core, DbContexto), chamadas a outras APIs, serviços de envio de e-mail, geração de tokens, etc.
Dependências: Depende do Application e do Domain para implementar as interfaces e manipular as entidades.

- Presentation (A Camada de Entrada)

O que contém? A "casca" da sua aplicação. No seu caso, é a Minimal API: o Program.cs, a definição dos endpoints, middlewares, etc.
Responsabilidade: Receber requisições HTTP, chamar os serviços da camada de Application e retornar as respostas. É aqui que a Injeção de Dependência é configurada para "conectar" todas as camadas.

### Vertical Slice Architecture (Abordagem Alternativa Moderna)

Abordagem que está ganhando muita popularidade, especialmente com Minimal APIs, é a **Arquitetura de Fatias Verticais**.

Em vez de *agrupar por camada técnica (Controllers, Services, Repositories)*, você *agrupa por funcionalidade*.

```plaintext
/Features/
│
├── Vehicles/
│   ├── GetVehicleById.cs  // Contém o endpoint, a lógica e a query, tudo em um só lugar
│   ├── CreateVehicle.cs
│   └── ...
│
└── Administrators/
    └── Login.cs
```

- Vantagem: Altíssima coesão. Tudo relacionado a uma funcionalidade fica junto, facilitando a manutenção e a adição de novas features sem tocar em outras partes do código.
- Desvantagem: Pode levar a alguma duplicação de código se não for bem gerenciado.

### Conclusão sobre Arquitetura

A estrutura baseada na Clean Architecture, é o padrão ouro para a maioria dos projetos .NET.
Ela oferece um equilíbrio fantástico entre organização, testabilidade e escalabilidade.

## Codificação

Boas práticas de codificação, como:

- Utilizar injeção de dependência para gerenciar dependências entre classes.
- Utilizar DTOs (Data Transfer Objects) para transferir dados entre camadas.
- Implementar tratamento de erros e logging adequado.
- Escrever testes automatizados para garantir a qualidade do código.

### Nomes dos Diretórios do Projeto

É uma forte convenção e uma ótima prática no ecossistema .NET que os nomes dos diretórios comecem com letra maiúscula (PascalCase), especialmente quando eles representam namespaces.

> **PRONTO!** Seguindo essas práticas, você pode criar uma aplicação Minimal API bem estruturada, fácil de manter e escalável.
