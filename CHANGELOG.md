# Changelog

Todas as alterações notáveis a este projeto serão documentadas neste arquivo.

> O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/) e este projeto adere ao [Versionamento Semântico](https://semver.org/lang/pt-BR/).

---

## [Unreleased]

## [1.2.0] - 2025-09-13

### Added

- **`Booking/`**: Adicionado novo projeto de desafio `Booking`.
  - **Motivo**: Implementar um sistema de console para gerenciamento de reservas de hotel, aplicando conceitos de POO, coleções e tratamento de exceções.
  - **Alteração**: Criado o projeto `Booking` com as classes `Pessoa`, `Suite` e `Reserva`. Implementada a lógica de negócio para cadastro de hóspedes, validação de capacidade e cálculo de diárias com desconto.
- **`Booking.Tests/`**: Adicionado projeto de testes unitários para o `Booking`.
  - **Motivo**: Garantir a qualidade e a robustez da lógica de negócio do sistema de hospedagem.
  - **Alteração**: Criado o projeto `Booking.Tests` com xUnit e implementados testes para a classe `Reserva`, cobrindo cenários de sucesso, exceções e regras de desconto.
- **`.github/workflows/dotnet-ci.yml`**: Adicionada etapa de coleta e publicação de cobertura de código (Code Coverage).
  - **Motivo**: Fornecer uma métrica visual da qualidade dos testes e garantir que a lógica de negócio crítica esteja sendo validada.
  - **Alteração**: O workflow de CI agora executa os testes com o `coverlet` para gerar um relatório de cobertura e o envia para o serviço Coveralls.io. Um badge de cobertura foi adicionado ao `README.md` principal.

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
