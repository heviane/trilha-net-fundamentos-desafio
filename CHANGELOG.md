# Changelog

Todas as alterações notáveis a este projeto serão documentadas neste arquivo.

> O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/) e este projeto adere ao [Versionamento Semântico](https://semver.org/lang/pt-BR/).

---

## [Unreleased]

### Added

- ...

### Changed

- ...

### Removed

- ...

## [1.0.0] - 2025-09-11

### Added

- **`Parking/Models/Estacionamento.cs`**: Implementadas as funcionalidades centrais do sistema de estacionamento.
  - **`AdicionarVeiculo`**: Adicionado método para registrar a placa de um novo veículo na lista.
  - **`RemoverVeiculo`**: Adicionado método para remover um veículo, solicitar as horas de permanência e calcular o custo total.
  - **`ListarVeiculos`**: Adicionado método para exibir a lista de todos os veículos estacionados.

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
