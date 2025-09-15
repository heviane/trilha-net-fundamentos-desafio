# 🏨 Sistema de Hospedagem

<p align="center">
  <a href="https://github.com/heviane-studies/trilha-net-fundamentos-desafio/actions/workflows/dotnet-ci.yml"><img alt="Build Status" src="https://github.com/heviane-studies/trilha-net-fundamentos-desafio/actions/workflows/dotnet-ci.yml/badge.svg" /></a>
  <a href="https://github.com/heviane-studies/trilha-net-fundamentos-desafio/releases"><img alt="Latest Release" src="https://img.shields.io/github/v/release/heviane-studies/trilha-net-fundamentos-desafio?style=flat-square&color=success" /></a>
  <a href="../LICENSE"><img alt="License" src="https://img.shields.io/github/license/heviane-studies/trilha-net-fundamentos-desafio?style=flat-square&color=blue" /></a>
  <a href="https://github.com/heviane-studies/trilha-net-fundamentos-desafio/issues"><img alt="GitHub issues" src="https://img.shields.io/github/issues/heviane-studies/trilha-net-fundamentos-desafio?style=flat-square&color=blueviolet" /></a>
  <img alt="Contributions Welcome" src="https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat-square" />
</p>

## 📋 Descrição do projeto

Este projeto é uma aplicação de console em .NET que simula um sistema de reservas de hotel. Desenvolvido como um desafio prático, ele aplica conceitos fundamentais de C# e da plataforma .NET, incluindo programação orientada a objetos, manipulação de coleções e tratamento de exceções.

O sistema permite gerenciar suítes, hóspedes e reservas, calculando o valor total da estadia com base em regras de negócio, como descontos por longa permanência.

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

## 🛠️ Pré-requisitos

Para clonar e executar este projeto localmente, você precisará ter as seguintes ferramentas instaladas em sua máquina:

- **[.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download)**: Essencial para compilar e executar a aplicação e os testes.
- **[Git](https://git-scm.com/)**: Necessário para clonar o repositório.

  ### Recomendado

  - Um editor de código como o **[Visual Studio Code](https://code.visualstudio.com/)** com a extensão [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## :arrow_forward: Como rodar a aplicação

No terminal, execute os comandos abaixo:

```bash
## Clone o projeto:
git clone git@github.com:heviane-studies/trilha-net-fundamentos-desafio.git

## Entre na pasta do projeto:
cd trilha-net-fundamentos-desafio/Booking
```

### Rodar a aplicação

```bash
dotnet run
```

## 🧪 Como rodar os testes

Para garantir a qualidade e o correto funcionamento do projeto, a aplicação conta com uma suíte de testes unitários. As instruções detalhadas para executar os testes estão disponíveis no [**README do projeto de testes**](../Booking.Tests/README.md#4-como-executar-os-testes-).

## :memo: Próximos passos

- [ ] Implementar o uso de **containers** com **Docker**.
- [ ] Implementar **projeto de testes unitários** com **XUnit**.
- [ ] Implementar **Integração Contínua (CI)** com **GitHub Actions**.
- [ ] Implementar o uso de **banco de dados** para persistir as reservas.
- [ ] Criar um menu interativo no `Program.cs` para o usuário final.
- [ ] Criar uma **versão web** da aplicação.

## :octocat: Desenvolvedores e Contribuintes

| <img src="https://heviane.github.io/image-gallery/Profile-heviane-v2.PNG" width=115><br><sub>Heviane Bastos</sub> |
| :---: |

## 📜 Licença

The MIT License (MIT)

Copyright :copyright: 2025 - Sistema de Hospedagem
