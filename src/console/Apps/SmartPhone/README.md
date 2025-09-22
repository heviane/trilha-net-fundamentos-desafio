# 📱 Sistema de Smartphone

<p align="center">
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/actions/workflows/dotnet-ci.yml"><img alt="Build Status" src="https://img.shields.io/github/actions/workflow/status/heviane/trilha-net-fundamentos-desafio/dotnet-ci.yml?branch=main&style=for-the-badge&label=CI"></a>
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/releases"><img alt="Latest Release" src="https://img.shields.io/github/v/release/heviane/trilha-net-fundamentos-desafio?style=for-the-badge&color=success"></a>
  <a href="../LICENSE"><img alt="License" src="https://img.shields.io/github/license/heviane/trilha-net-fundamentos-desafio?style=for-the-badge&color=blue"></a>
  <a href="../.github/CONTRIBUTING.md"><img alt="Contributions Welcome" src="https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=for-the-badge"></a>
</p>

## 📋 Descrição do projeto

Este projeto é uma aplicação de console em .NET que demonstra conceitos de Programação Orientada a Objetos (POO), como abstração, herança e polimorfismo, através da simulação de diferentes modelos de smartphones.

O sistema modela um `Smartphone` genérico e cria especializações como `Nokia` e `Iphone`, cada um com comportamentos específicos, destacando a flexibilidade e o reuso de código proporcionados pela POO.

---

> **Nota:** Este projeto foi desenvolvido a partir de um desafio de código proposto pela [Digital Innovation One (DIO)](https://www.dio.me/). O repositório base, com a estrutura inicial, pode ser encontrado em [digitalinnovationone/trilha-net-poo-desafio](https://github.com/digitalinnovationone/trilha-net-poo-desafio).

---

## ✨ Funcionalidades

A aplicação demonstra os seguintes conceitos e funcionalidades:

- **Abstração e Herança**:
  - Utiliza uma classe base abstrata `Smartphone` com propriedades e métodos comuns (como `Ligar` e `ReceberLigacao`).
  - Fornece classes filhas `Nokia` e `Iphone` que herdam da classe base.

- **Polimorfismo**:
  - Demonstra o polimorfismo através da sobrescrita do método `InstalarAplicativo`, que tem um comportamento específico para cada modelo de smartphone.

## Guias Úteis

- **Como rodar a aplicação:**

```bash
## Clone o projeto:
git clone git@github.com:heviane/trilha-net-fundamentos-desafio.git
## Entre na pasta do projeto:
cd trilha-net-fundamentos-desafio/src/console/Apps/SmartPhone 
## Execute a aplicação
dotnet run 
```

- **[Guia de Conteinerização com Docker](../.github/DOCKER_GUIDE.md)**
- **[Guia de Testes com xUnit e Coverlet](../.github/TESTING_GUIDE.md)**
- **[Guia de Criação de Releases](../.github/RELEASING_GUIDE.md)**

## :octocat: Desenvolvedores e Contribuintes

| <img width="80px" align="center" src="https://avatars.githubusercontent.com/heviane"/><br><sub>Heviane Bastos</sub> |
| :---: |

## 📜 Licença

The [MIT License](../../../../LICENSE) (MIT)

Copyright :copyright: 2025 - Estacionamento de veículos
