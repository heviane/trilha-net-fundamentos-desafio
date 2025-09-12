# Estacionamento de veículos

<!--
<p align="center">
  <img src="https://img.shields.io/static/v1?label=react&message=framework&color=blue&style=for-the-badge&logo=REACT"/>
  <img src="https://img.shields.io/static/v1?label=Netlify&message=deploy&color=blue&style=for-the-badge&logo=netlify"/>
  <img src="http://img.shields.io/static/v1?label=License&message=MIT&color=green&style=for-the-badge"/>
  <img src="http://img.shields.io/static/v1?label=TESTES&message=%3E100&color=GREEN&style=for-the-badge"/>
  <img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>
</p>
 -->

> Status do Projeto: ✅ **v1.0.0 Concluída** | 🚧 **Próximos Passos em Desenvolvimento**

## Descrição do projeto

<p align="justify">
Sistema de estacionamento de veículos, usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo: adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.
</p>

## Funcionalidades

- :heavy_check_mark: Cadastrar veículo
- :heavy_check_mark: Remover veículo
- :heavy_check_mark: Cobrar valor do período de permanência
- :heavy_check_mark: Listar veículos

<!-- 
## Layout ou Deploy da Aplicação :dash:

> Link do deploy da aplicação. Exemplo com netlify: https://certificates-for-everyone-womakerscode.netlify.app/

...

Se ainda não houver deploy, insira capturas de tela da aplicação ou gifs
-->

## Pré-requisitos

:warning: [.NET 9.0](https://dotnet.microsoft.com/en-us/download)

## Como rodar a aplicação :arrow_forward:

No terminal, execute os comandos abaixo:

```bash
## Clone o projeto:
git clone git@github.com:heviane-studies/trilha-net-fundamentos-desafio.git

## Entre na pasta do projeto:
cd trilha-net-fundamentos-desafio/Parking 
```

### Rodar a aplicação sem Docker

```bash
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

<!--
## Como rodar os testes

Coloque um passo a passo para executar os testes

```bash
npm test, rspec, etc 
```

## Casos de Uso

Explique com mais detalhes como a sua aplicação poderia ser utilizada. O uso de **gifs** aqui seria bem interessante.

Exemplo: Caso a sua aplicação tenha alguma funcionalidade de login apresente neste tópico os dados necessários para acessá-la.

## JSON :floppy_disk:

### Usuários:

|name|email|password|token|avatar|
| -------- |-------- |-------- |-------- |-------- |
|Lais Lima|laislima98@hotmail.com|lais123|true|https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcS9-U_HbQAipum9lWln3APcBIwng7T46hdBA42EJv8Hf6Z4fDT3&usqp=CAU|

...

Se quiser, coloque uma amostra do banco de dados

## Iniciando/Configurando banco de dados

Se for necessário configurar algo antes de iniciar o banco de dados insira os comandos a serem executados

## Linguagens, dependencias e libs utilizadas :books:

- [React](https://pt-br.reactjs.org/docs/create-a-new-react-app.html)
- [React PDF](https://react-pdf.org/)

...

Liste as tecnologias utilizadas no projeto que **não** forem reconhecidas pelo Github

## Resolvendo Problemas :exclamation:

Em [issues](https://github.com/heviane-studies/trilha-net-fundamentos-desafio/issues) foram abertos alguns problemas gerados durante o desenvolvimento desse projeto e como foram resolvidos.
-->

## :memo: Próximos passos

- [x] Implementar o uso de **containers** com **Docker**.
  - Garante um ambiente de execução consistente, portátil e simplifica o setup para novos desenvolvedores.
  - Isola a aplicação e suas dependências, evitando conflitos com o ambiente da máquina hospedeira.
  - Utiliza um `Dockerfile` multi-stage para criar uma imagem final leve e otimizada, contendo apenas o necessário para a execução.
- [X] Implementar **projeto de testes unitários** com **XUnit**.
  - Garante a qualidade, robustez e manutenibilidade da lógica de negócio.
  - Facilita futuras manutenções e refatorações, garantindo que o comportamento esperado não seja quebrado.
  - Exigiu a refatoração da aplicação para separar responsabilidades (SoC), uma prática fundamental da arquitetura de software limpa.
- [X] Implementar **Integração Contínua (CI)** com **GitHub Actions**.
  - Garante que os testes sejam executados automaticamente toda vez que um novo código é enviado para o repositório (a cada `push` ou em cada `Pull Request`).
  - Impede código com bugs ou que quebre funcionalidades existentes seja integrado à branch principal (main).
  - Desenvolvedores e contribuidores sabem imediatamente se uma alteração causou um problema.
  - Criar um workflow que compila o projeto e executa o `dotnet test`.
- [ ] Implementar o uso de **banco de dados**
- [ ] Implementar **autenticação**
- [ ] Criar uma **versão web**
  - [ ] Designer: Identidade visual, design system, wireframe, protótipo, etc.
  - [ ] Frontend: User interface.
- [ ] Criar uma **versão mobile** para android.
- [ ] Criar uma **versão mobile** para ios.
- [ ] Criar uma **versão mobile** para tablet.
- [ ] Criar uma **versão mobile** para desktop.

## :octocat: Desenvolvedores e Contribuintes

| [<img src="https://heviane.github.io/image-gallery/Profile-heviane-v2.PNG" width=115><br><sub>Heviane Bastos</sub>](https://github.com/heviane) |
| :---: |

## Licença

The [MIT License](../LICENSE) (MIT)

Copyright :copyright: 2025 - Estacionamento de veículos
