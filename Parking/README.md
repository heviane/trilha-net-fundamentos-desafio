 # 🅿️ Estacionamento de veículos

<p align="center">
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/actions/workflows/dotnet-ci.yml"><img alt="Build Status" src="https://github.com/heviane/trilha-net-fundamentos-desafio/actions/workflows/dotnet-ci.yml/badge.svg" /></a>
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/releases"><img alt="Latest Release" src="https://img.shields.io/github/v/release/heviane/trilha-net-fundamentos-desafio?style=flat-square&color=success" /></a>
  <a href="../LICENSE"><img alt="License" src="https://img.shields.io/github/license/heviane/trilha-net-fundamentos-desafio?style=flat-square&color=blue" /></a>
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/issues"><img alt="GitHub issues" src="https://img.shields.io/github/issues/heviane/trilha-net-fundamentos-desafio?style=flat-square&color=blueviolet" /></a>
  <img alt="Contributions Welcome" src="https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat-square" />
</p>

## 📋 Descrição do projeto

Este projeto é uma aplicação de console em .NET que simula um sistema de gerenciamento de estacionamento. Desenvolvido como um desafio prático, ele aplica conceitos fundamentais de C# e da plataforma .NET, incluindo programação orientada a objetos, manipulação de coleções e interação com o usuário via terminal.

O sistema permite realizar operações essenciais como registrar a entrada de veículos, processar a saída com cálculo de custos e listar os veículos presentes, servindo como uma base sólida para a implementação de funcionalidades mais avançadas.

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

<!-- 
## Layout ou Deploy da Aplicação :dash:

> Link do deploy da aplicação. Exemplo com netlify: https://certificates-for-everyone-womakerscode.netlify.app/

...

Se ainda não houver deploy, insira capturas de tela da aplicação ou gifs
-->

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
cd Parking
dotnet run
```

### Rodar a aplicação com Docker

Com o Docker instalado e executando, você pode construir e executar a aplicação em um ambiente containerizado, garantindo consistência e isolamento.

```bash
# construa a imagem Docker: 
docker build -t parking-app .

# Execute o container de forma interativa:
# Flag -it para alocar um terminal interativo, essencial para uma aplicação de console
# Flag --rm para remover o container automaticamente após a sua execução.
docker run -it --rm parking-app
```

<!-- TODO: Dica: clone o próprio projeto e verfique se o passo a passo funciona. -->

## 🧪 Como rodar os testes

Para garantir a qualidade e o correto funcionamento do projeto, a aplicação conta com uma suíte de testes unitários. As instruções detalhadas para executar os testes estão disponíveis no [README do projeto de testes](../Parking.Tests/README.md#4-como-executar-os-testes-).

## :octocat: Desenvolvedores e Contribuintes

| [<img width="80px" align="center" src="https://avatars.githubusercontent.com/heviane"/><br><sub>Heviane Bastos</sub>](https://github.com/heviane) |
| :---: |

## 📜 Licença

The [MIT License](../LICENSE) (MIT)

Copyright :copyright: 2025 - Estacionamento de veículos
