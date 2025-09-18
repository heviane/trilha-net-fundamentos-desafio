# 🅿️ Estacionamento de Veículos

<p align="center">
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/actions/workflows/dotnet-ci.yml"><img alt="Build Status" src="https://img.shields.io/github/actions/workflow/status/heviane/trilha-net-fundamentos-desafio/dotnet-ci.yml?branch=main&style=for-the-badge&label=CI"></a>
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/releases"><img alt="Latest Release" src="https://img.shields.io/github/v/release/heviane/trilha-net-fundamentos-desafio?style=for-the-badge&color=success"></a>
  <a href="../LICENSE"><img alt="License" src="https://img.shields.io/github/license/heviane/trilha-net-fundamentos-desafio?style=for-the-badge&color=blue"></a>
  <a href="../.github/CONTRIBUTING.md"><img alt="Contributions Welcome" src="https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=for-the-badge"></a>
</p>

## 📋 Descrição do projeto

Este projeto é uma aplicação de console em .NET que simula um sistema de gerenciamento de estacionamento. Desenvolvido como um desafio prático, ele aplica conceitos fundamentais de C# e da plataforma .NET, incluindo programação orientada a objetos, manipulação de coleções e interação com o usuário via terminal.

O sistema permite realizar operações essenciais como registrar a entrada de veículos, processar a saída com cálculo de custos e listar os veículos presentes, servindo como uma base sólida para a implementação de funcionalidades mais avançadas.

---

> **Nota:** Este projeto foi desenvolvido a partir de um desafio de código proposto pela [Digital Innovation One (DIO)](https://www.dio.me/). O repositório base, com a estrutura inicial, pode ser encontrado em [digitalinnovationone/trilha-net-fundamentos-desafio](https://github.com/digitalinnovationone/trilha-net-fundamentos-desafio).

---

## ✨ Funcionalidades

A aplicação oferece as seguintes funcionalidades essenciais para a gestão de um estacionamento:

- **Cadastrar Veículo**:
  - Permite registrar um novo veículo no estacionamento através de sua placa.
  - Inclui uma validação para impedir o cadastro de placas duplicadas, garantindo a integridade dos dados.

- **Remover Veículo e Calcular Custo**:
  - Remove um veículo registrado do estacionamento.
  - Solicita a quantidade de horas que o veículo permaneceu estacionado.
  - Calcula e exibe o valor total a ser pago, com base no preço inicial e no preço por hora definidos no início da execução.

- **Listar Veículos**:
  - Exibe uma lista com as placas de todos os veículos que estão atualmente no estacionamento.

## Guias Úteis

- **Como rodar a aplicação:**

```bash
## Clone o projeto:
git clone git@github.com:heviane/trilha-net-fundamentos-desafio.git
## Entre na pasta do projeto:
cd trilha-net-fundamentos-desafio/Parking
## Execute a aplicação:
dotnet run
```

- **[Guia de Conteinerização com Docker](../.github/DOCKER_GUIDE.md)**
- **[Guia de Testes com xUnit e Coverlet](../.github/TESTING_GUIDE.md)**
- **[Guia de Criação de Releases](../.github/RELEASING_GUIDE.md)**

## :octocat: Desenvolvedores e Contribuintes

| [<img width="80px" align="center" src="https://avatars.githubusercontent.com/heviane"/><br><sub>Heviane Bastos</sub>](https://github.com/heviane) |
| :---: |

## 📜 Licença

The [MIT License](../LICENSE) (MIT)

Copyright :copyright: 2025 - Estacionamento de veículos
