# 🚀 Guia de Criação de Releases

<p align="center">
  <img src="https://img.shields.io/badge/Versioning-SemVer-blue?style=for-the-badge" alt="Semantic Versioning">
  <img src="https://img.shields.io/badge/Automation-GitHub_Actions-purple?style=for-the-badge" alt="GitHub Actions">
</p>

Este documento detalha o processo para criar e publicar uma nova versão dos projetos neste repositório. O processo é automatizado através do GitHub Actions e é disparado pela criação de uma nova **tag Git**.

## Versionamento Semântico (SemVer)

Este projeto segue o [Versionamento Semântico](https://semver.org/lang/pt-BR/). As versões são no formato `MAJOR.MINOR.PATCH`:

- **MAJOR**: Incrementado para mudanças incompatíveis (quebram a API).
- **MINOR**: Incrementado para adicionar funcionalidades de forma retrocompatível.
- **PATCH**: Incrementado para correções de bugs retrocompatíveis.

---

## Passo a Passo para Criar uma Nova Release

Siga estes passos cuidadosamente para garantir que a release seja gerada corretamente.

### 1. Prepare a Branch `main`

Certifique-se de que todas as alterações, novas funcionalidades e correções de bugs que devem fazer parte da nova versão já foram mescladas na branch `main`.

### 2. Atualize o `CHANGELOG.md`

Este é um passo crucial. Abra o arquivo `CHANGELOG.md` e mova todas as alterações da seção `[Unreleased]` para uma nova seção de versão.

**Exemplo**:

```diff
--- a/CHANGELOG.md
+++ b/CHANGELOG.md
@@ -8,10 +8,13 @@
 
 ## [Unreleased]
 
-## [1.5.0] - 2025-09-16
+
+## [1.5.0] - 2025-09-16
+
 ### Added
 
 - **`NewChallenge/`**: Adicionado novo projeto de desafio.

```

### 3. Crie uma Tag Git Anotada

Crie uma tag Git que corresponda à nova versão definida no `CHANGELOG.md`. É importante que a tag seja **anotada** (`-a`) para incluir uma mensagem. O nome da tag deve começar com `v`.

```bash
# Exemplo para a versão 1.5.0
git tag -a v1.5.0 -m "Release v1.5.0: Adiciona o desafio NewChallenge"
```

### 4. Envie a Tag para o GitHub

Envie a tag recém-criada para o repositório remoto. Este é o comando que **dispara o workflow de automação de release**.

```bash
# Envia a tag específica
git push origin v1.5.0

# Ou, para enviar todas as suas tags locais
git push origin --tags
```

### 5. Verifique a Release no GitHub

Após enviar a tag, navegue até a seção **Releases** do repositório no GitHub. Você verá um novo workflow em execução. Ao final, uma nova release será criada, contendo os artefatos de build (executáveis) de todos os projetos configurados.

> **Pronto!** Você publicou uma nova versão com sucesso.
