# Changelog

Todas as alterações notáveis a este projeto serão documentadas neste arquivo.

> O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/) e este projeto adere ao [Versionamento Semântico](https://semver.org/lang/pt-BR/).

---

## [Unreleased]

## [1.6.0] - 2024-10-27

### Added

- **`src/console/Apps/HelloWorld/`**: Adicionado novo projeto de desafio `HelloWorld` para servir como exemplo e validar a nova estrutura de automação.

### Changed

- **`.github/workflows/release-automation.yml`**: Refatorado o workflow para usar uma matriz de estratégia (`strategy: matrix`).
  - **Motivo**: Eliminar a duplicação de código, facilitar a adição de novos projetos e otimizar o tempo de execução do pipeline através de builds paralelos.
  - **Alteração**: O workflow foi dividido em dois jobs: `build` (que executa em paralelo para cada projeto) e `release` (que agrupa os artefatos).
- **`Estrutura de Pastas`**: Refatorada a organização dos projetos para separar aplicações por tipo.
  - **Motivo**: Melhorar a escalabilidade e a organização do repositório, preparando-o para futuros projetos de API e Web.
  - **Alteração**: Os projetos de console foram movidos da raiz para a nova estrutura `src/console/Apps/`. A estrutura `src/api/Apps/` foi criada para acomodar futuras APIs.

## [1.5.0] - 2025-09-18

### Added

- **`.github/`**: Adicionados guias de desenvolvimento centralizados.
  - **Motivo**: Criar uma fonte única de verdade para padronizar processos de engenharia, garantir consistência e facilitar a integração de novos contribuidores.
  - **Alteração**: Criados os guias `NEW_CHALLENGE_GUIDE.md`, `DOCKER_GUIDE.md`, `TESTING_GUIDE.md` e `RELEASING_GUIDE.md`.

- **`SmartPhone.Tests/`**: Adicionada análise de cobertura de testes com Coverlet e ReportGenerator.
  - **Motivo**: Medir a eficácia dos testes unitários e garantir que toda a lógica de negócio crítica seja validada, visando 100% de cobertura.
  - **Alteração**: Adicionado o pacote `coverlet.collector`, criado o arquivo `coveragesettings.runsettings` para excluir o `Program.cs` da análise, e atualizada a documentação com os comandos para gerar o relatório.

- **`SmartPhone/Models/`**: Adicionada documentação de código com XML Comments.
  - **Motivo**: Melhorar a clareza, a manutenibilidade e habilitar o suporte do IntelliSense.
  - **Alteração**: Todas as classes públicas (`Smartphone`, `Nokia`, `Iphone`), métodos e propriedades foram documentados.

### Changed

- **`README.md`s**: Refatorados todos os `README.md`s para remover conteúdo duplicado e apontar para os guias centralizados.
  - **Motivo**: Simplificar a manutenção, aplicar o princípio DRY e garantir consistência na documentação.
  - **Alteração**: Os `README.md`s dos projetos foram enxugados, e a documentação técnica foi consolidada nos guias da pasta `.github/`.

- **`SmartPhone.Tests/`**: Refatorados os testes unitários para usar `[Theory]`.
  - **Motivo**: Reduzir a duplicação de código, melhorar a manutenibilidade e seguir o princípio DRY (Don't Repeat Yourself).
  - **Alteração**: Os testes foram consolidados em testes parametrizados (`[Theory]`, `[MemberData]`, `[InlineData]`), tornando o código mais limpo e escalável.

## [1.4.0] - 2025-09-15

### Added

- **`SmartPhone/`**: Adicionado novo projeto de desafio `SmartPhone`.
  - **Motivo**: Implementar um sistema de console que abstrai o conceito de um smartphone, aplicando conceitos de POO como herança e polimorfismo.
  - **Alteração**: Criado o projeto `SmartPhone` com a classe base abstrata `Smartphone` e as implementações `Nokia` e `Iphone`.
- **`SmartPhone.Tests/`**: Adicionado projeto de testes unitários para o `SmartPhone`.
  - **Motivo**: Garantir a qualidade e o correto funcionamento das implementações do desafio.
- **`.github/NEW_CHALLENGE_GUIDE.md`**: Adicionado guia para novos contribuidores.
  - **Motivo**: Padronizar o processo de adição de novos desafios ao repositório, garantindo a consistência com os padrões de qualidade e automação.

### Changed

- **`Dockerfile`s**: Refatorados todos os `Dockerfile`s para simplificar e melhorar a manutenibilidade.
  - **Motivo**: O padrão anterior exigia a edição de todos os `Dockerfile`s a cada novo projeto, tornando o processo tedioso e propenso a erros.
  - **Alteração**: Os `Dockerfile`s agora copiam todo o código-fonte de uma vez (`COPY . .`), eliminando a necessidade de listar cada `.csproj` individualmente.
- **`README.md`s**: Atualizados os arquivos de documentação principal e dos projetos.
  - **Alteração**: Adicionada seção de créditos à DIO, corrigidos os comandos de build do Docker e incluído o novo projeto `SmartPhone` na documentação.
- **`.github/workflows/release-automation.yml`**: Atualizado o workflow de release.
  - **Alteração**: O workflow agora inclui o projeto `SmartPhone` no processo de build e empacotamento de artefatos para as releases.

## [1.3.0] - 2025-09-14

### Changed

- **`.github/workflows/release-automation.yml`**: Aprimorado o workflow para anexar artefatos de build.
  - **Motivo**: Fornecer executáveis prontos para uso (Linux, Windows, macOS) diretamente na página de release, melhorando a experiência do usuário final.
  - **Alteração**: O workflow agora inclui passos para compilar os projetos `Parking` e `Booking` em modo `Release`, empacotar os resultados em arquivos `.zip` e anexá-los à release do GitHub.

## [1.2.0] - 2025-09-13

### Added

- **`Booking/`**: Adicionado novo projeto de desafio `Booking`.
  - **Motivo**: Implementar um sistema de console para gerenciamento de reservas de hotel, aplicando conceitos de POO, coleções e tratamento de exceções.
  - **Alteração**: Criado o projeto `Booking` com as classes `Pessoa`, `Suite` e `Reserva`. Implementada a lógica de negócio para cadastro de hóspedes, validação de capacidade e cálculo de diárias com desconto.
- **`Booking.Tests/`**: Adicionado projeto de testes unitários para o `Booking`.
  - **Motivo**: Garantir a qualidade e a robustez da lógica de negócio do sistema de hospedagem.
  - **Alteração**: Criado o projeto `Booking.Tests` com xUnit e implementados testes para a classe `Reserva`, cobrindo cenários de sucesso, exceções e regras de desconto.

### Changed

- **`Parking/Dockerfile`**: Refatorado para seguir o padrão "solution-aware".
  - **Motivo**: Alinhar com as melhores práticas modernas, melhorar o cache de build do Docker e garantir consistência com outros projetos na solução.
  - **Alteração**: O `Dockerfile` agora usa a raiz do repositório como contexto, copia todos os arquivos `.csproj` e a solução `.sln` antes de restaurar as dependências, otimizando a velocidade de build. O comando de build no `Parking/README.md` foi atualizado para refletir essa mudança.

## [1.1.0] - 2025-09-12

### Added

- **`Parking/`**: Adicionada containerização com **Docker** para a aplicação.
  - **Motivo**: Garantir um ambiente de execução consistente, portátil e simplificar o setup para novos desenvolvedores.
  - **Alteração**: Criados os arquivos `Dockerfile` (com build multi-stage) e `.dockerignore` para otimizar a construção da imagem.

- **`Parking.Tests/`**: Adicionado projeto de testes unitários com **xUnit**.
  - **Motivo**: Garantir a qualidade, robustez e manutenibilidade da lógica de negócio.
  - **Alteração**: Criado o projeto `Parking.Tests` e implementados testes para os métodos `AdicionarVeiculo` e `RemoverVeiculo`, cobrindo cenários de sucesso e de erro.

- **`.github/workflows/`**: Adicionado workflow de **Integração Contínua (CI)** com **GitHub Actions**.
  - **Motivo**: Automatizar a compilação e a execução dos testes a cada `push` ou `pull request`, garantindo a qualidade do código e fornecendo feedback rápido sobre as alterações.
  - **Alteração**: Criado o arquivo `dotnet-ci.yml` que configura o ambiente .NET, restaura dependências, compila o projeto e executa a suíte de testes.

### Changed

- **`Parking/Models/Estacionamento.cs`**: Refatorada a classe para ser testável (Separação de Responsabilidades).
  - **Motivo**: Desacoplar a lógica de negócio da interface de usuário (Console) para permitir a criação de testes unitários automatizados.
  - **Alteração**: Os métodos agora recebem dados como parâmetros e comunicam erros através de retornos (`bool`) ou exceções (`InvalidOperationException`, `ArgumentException`), em vez de interagir diretamente com o Console.

- **`Parking/Program.cs`**: Atualizado para consumir a classe `Estacionamento` refatorada.
  - **Impacto**: A camada de apresentação agora é responsável por capturar entradas do usuário, chamar a lógica de negócio e tratar os retornos/exceções para exibir mensagens apropriadas.

## [1.0.0] - 2025-09-11

### Added

- **`Parking/Models/Estacionamento.cs`**: Implementadas as funcionalidades centrais do sistema de estacionamento.
  - **`AdicionarVeiculo`**: Adicionado método para registrar a placa de um novo veículo na lista.
  - **`RemoverVeiculo`**: Adicionado método para remover um veículo, solicitar as horas de permanência e calcular o custo total.
  - **`ListarVeiculos`**: Adicionado método para exibir a lista de todos os veículos estacionados.

- **`.gitignore`**: Adicionado arquivo `.gitignore` na raiz do projeto.
  - **Motivo**: Manter o repositório limpo, ignorando arquivos gerados por build, IDEs e sistemas operacionais.
  - **Alteração**: Criado um arquivo `.gitignore` padrão para projetos .NET, incluindo a regra para `.DS_Store`.

### Changed

- **`Parking/Program.cs`**: A cultura da aplicação foi definida explicitamente para `pt-BR`.
  - **Vantagem**: Garante que a formatação de moeda (R$) e números (uso de vírgula como separador decimal) seja consistente e correta, independentemente das configurações regionais do sistema operacional do usuário.
  - **Impacto**: Aumenta a previsibilidade e o profissionalismo da saída do programa, evitando comportamentos inesperados em diferentes ambientes.

- **`Parking/Models/Estacionamento.cs`**: Refatorada a exibição do valor total para usar o formato de moeda sensível à cultura (`:C2`).
  - **Vantagem**: Remove o símbolo "R$" fixo do código e aproveita a configuração de cultura `pt-BR` para formatar a moeda automaticamente, tornando o código mais limpo e adaptável.

- **`Parking/Models/Estacionamento.cs`**: Refinada a validação de horas em `RemoverVeiculo`.
  - **Motivo**: Uma abordagem mais robusta é forçar o usuário a fornecer uma entrada válida desde o início, evitando assim cobranças indevidas.
  - **Alteração**: O loop de validação foi aprimorado para exigir que o usuário digite um número de horas estritamente maior que zero, melhorando a robustez e a clareza da interação.

- **`Parking/Models/Estacionamento.cs`**: Melhorada a integridade dos dados ao impedir o cadastro de veículos duplicados.
  - **Motivo**: A versão anterior permitia que a mesma placa fosse adicionada várias vezes, causando inconsistências.
  - **Alteração**: Foi implementada uma verificação para checar se o veículo já existe antes de adicioná-lo, informando o usuário em caso de duplicidade.

### Fixed

- **`Parking/Program.cs`**: Corrigida falha na lógica de negócio que permitia preços iguais a zero.
  - **Motivo**: A validação inicial permitia que os preços fossem configurados como `0`, o que resultaria em cobranças zeradas, invalidando o propósito comercial do sistema.
  - **Alteração**: A condição de validação foi ajustada para exigir que os preços sejam estritamente maiores que zero (`> 0`), garantindo a integridade da lógica de cobrança.

- **`Parking/Models/Estacionamento.cs`**: Aumentada a robustez e corrigidos bugs no método `RemoverVeiculo`.
  - **Validação de Horas**: A captura das horas de permanência foi refatorada com `int.TryParse` para prevenir quebras (`System.FormatException`) caso o usuário insira um valor não numérico.
  - **Remoção Consistente**: Corrigido bug onde a remoção da placa era sensível ao caso (`case-sensitive`), enquanto a verificação não era. A remoção agora é consistente e ignora maiúsculas/minúsculas, garantindo que o veículo seja sempre removido.

- **`Parking/Program.cs`**: A robusteza da aplicação foi melhorada ao refatorar a captura dos preços inicial e por hora.
  - **Motivo**: A implementação anterior com `Convert.ToDecimal` causava uma quebra (crash) no programa se o usuário digitasse um valor não numérico (ex: "abc").
  - **Alteração**: Foi implementado um loop `while` com `decimal.TryParse` para validar a entrada. O programa agora solicita repetidamente um valor válido até que um número positivo seja fornecido.
  - **Erros Prevenidos**: `System.FormatException` e a entrada de valores negativos para os preços.
