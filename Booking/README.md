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

> **Nota sobre a Origem do Desafio**
>
> Este projeto foi desenvolvido a partir de um desafio de código proposto pela [Digital Innovation One (DIO)](https://www.dio.me/). O repositório base, com a estrutura inicial, pode ser encontrado em [digitalinnovationone/trilha-net-explorando-desafio](https://github.com/digitalinnovationone/trilha-net-explorando-desafio).

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

## 🛠️ Pré-requisitos

Para clonar e executar este projeto localmente, você precisará ter as seguintes ferramentas instaladas em sua máquina:

- **[.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download)**: Essencial para compilar e executar a aplicação e os testes.
- **[Git](https://git-scm.com/)**: Necessário para clonar o repositório.
- **[Docker](https://www.docker.com/products/docker-desktop/)**: Opcional, mas necessário para construir e executar a aplicação via container.

  ### Recomendado

  - Um editor de código como o **[Visual Studio Code](https://code.visualstudio.com/)** com a extensão [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## :arrow_forward: Como rodar a aplicação

No terminal, execute os comandos abaixo:

```bash
## Clone o projeto:
git clone git@github.com:heviane/trilha-net-fundamentos-desafio.git

## Entre na pasta do repositório:
cd trilha-net-fundamentos-desafio
```

### Rodar a aplicação sem Docker

```bash
cd Booking
dotnet run
```

### Rodar a aplicação com Docker

Com o Docker instalado e executando, você pode construir e executar a aplicação em um ambiente containerizado, garantindo consistência e isolamento.

**Importante**: Execute os comandos a partir da pasta raiz do repositório.

```bash
# Construa a imagem Docker especificando o Dockerfile do projeto:
docker build -t booking-app -f Booking/Dockerfile .

# Execute o container de forma interativa:
# Flag -it para alocar um terminal interativo, essencial para uma aplicação de console
# Flag --rm para remover o container automaticamente após a sua execução.
docker run -it --rm booking-app
```

<!-- TODO: Dica: clone o próprio projeto e verfique se o passo a passo funciona. -->

## 🧪 Como rodar os testes

Para garantir a qualidade e o correto funcionamento do projeto, a aplicação conta com uma suíte de testes unitários. As instruções detalhadas para executar os testes estão disponíveis no [README do projeto de testes](../Booking.Tests/README.md#4-como-executar-os-testes-).

## :octocat: Desenvolvedores e Contribuintes

| [<img width="80px" align="center" src="https://avatars.githubusercontent.com/heviane"/><br><sub>Heviane Bastos</sub>](https://github.com/heviane) |
| :---: |

## 📜 Licença

The [MIT License](../LICENSE) (MIT)

Copyright :copyright: 2025 - Sistema de Hospedagem
