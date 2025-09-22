# 🏨 Sistema de Hospedagem

<p align="center">
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/actions/workflows/dotnet-ci.yml"><img alt="Build Status" src="https://img.shields.io/github/actions/workflow/status/heviane/trilha-net-fundamentos-desafio/dotnet-ci.yml?branch=main&style=for-the-badge&label=CI"></a>
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/releases"><img alt="Latest Release" src="https://img.shields.io/github/v/release/heviane/trilha-net-fundamentos-desafio?style=for-the-badge&color=success"></a>
  <a href="../LICENSE"><img alt="License" src="https://img.shields.io/github/license/heviane/trilha-net-fundamentos-desafio?style=for-the-badge&color=blue"></a>
  <a href="../.github/CONTRIBUTING.md"><img alt="Contributions Welcome" src="https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=for-the-badge"></a>
</p>

## 📋 Descrição do projeto

Este projeto é uma aplicação de console em .NET que simula um sistema de reservas de hotel. Desenvolvido como um desafio prático, ele aplica conceitos fundamentais de C# e da plataforma .NET, incluindo programação orientada a objetos, manipulação de coleções e tratamento de exceções.

O sistema permite gerenciar suítes, hóspedes e reservas, calculando o valor total da estadia com base em regras de negócio, como descontos por longa permanência.

---

> **Nota:** Este projeto foi desenvolvido a partir de um desafio de código proposto pela [Digital Innovation One (DIO)](https://www.dio.me/). O repositório base, com a estrutura inicial, pode ser encontrado em [digitalinnovationone/trilha-net-explorando-desafio](https://github.com/digitalinnovationone/trilha-net-explorando-desafio).

---

## ✨ Funcionalidades

A aplicação oferece as seguintes funcionalidades essenciais para a gestão de reservas de um hotel:

- **Cadastrar Suíte**:
  - Permite definir um tipo de suíte, sua capacidade máxima de hóspedes e o valor da diária.

- **Cadastrar Hóspedes**:
  - Permite registrar uma lista de hóspedes para uma reserva.
  - Valida se a quantidade de hóspedes não excede a capacidade da suíte.

- **Criar Reserva**:
  - Associa os hóspedes e a suíte a uma reserva com uma quantidade definida de dias.

- **Calcular Valor da Diária**:
  - Calcula e exibe o valor total a ser pago pela estadia.
  - Aplica um desconto de 10% para reservas com 10 ou mais dias de duração.

## Guias Úteis

- **Como rodar a aplicação:**

```bash
## Clone o projeto:
git clone git@github.com:heviane/trilha-net-fundamentos-desafio.git
## Entre na pasta do projeto:
cd trilha-net-fundamentos-desafio/src/console/Apps/Booking
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

The [MIT License](../../../../LICENSE) (MIT)

Copyright :copyright: 2025 - Sistema de Hospedagem
