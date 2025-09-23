# Roadmap and planning

Acompanhamento de roteiro e plano de estudos!

## Roadmap

- Testes
  - Análise de Cobertura com Coverlet e ReportGenerator:
    - [X] Localmente
    - [ ] Integrado ao workflow de CI no GitHub Actions

- DevOps
  - **CD - Continuous Deployment (Implantação Contínua)**: Basicamente, pegaria os artefatos gerados pela Entrega Contínua e os implantaria automaticamente em um ambiente de produção sem qualquer intervenção humana.
    - Para uma **aplicação console** distribuída, a **Integração e Entrega Contínuas** já são suficientes.
    - Para uma **aplicação web**, poderia ser publicar a nova versão automaticamente em um servidor na nuvem (como Azure App Service ou AWS).
    - Para uma **aplicação desktop**, poderia ser publicar em uma loja de aplicativos.
