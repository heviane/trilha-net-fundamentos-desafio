# DTO (Data Transfer Object)

DTO significa **Data Transfer Object** (Objeto de Transferência de Dados).

## O que é um DTO?

É um padrão de design usado para transferir dados entre diferentes partes de um sistema, especialmente entre camadas de uma aplicação.
DTOs são simples objetos que não contêm lógica de negócio, apenas propriedades para armazenar dados.

Eles são frequentemente usados para:

- Reduzir a quantidade de dados transferidos entre o cliente e o servidor.
- Evitar expor diretamente as entidades do domínio.

## Por que usar DTOs?

1. **Segurança**: Evita expor diretamente as entidades do domínio, o que pode levar a vulnerabilidades.
2. **Desempenho**: Permite transferir apenas os dados necessários, reduzindo a quantidade de dados trafegados.
3. **Flexibilidade**: Permite adaptar a estrutura dos dados para diferentes necessidades, como diferentes versões de uma API.
4. **Separação de preocupações**: Mantém a lógica de negócio separada da lógica de apresentação.

## Exemplo de DTO

```csharp
public class LoginDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
}
```

Sua sua única finalidade é servir como um "pacote" para transportar dados de um ponto a outro.

A classe LoginDTO modela os dados que a sua API espera receber no corpo (body) de uma requisição POST para o endpoint /login.
Quando um usuário tenta fazer login, ele envia um JSON com seu e-mail e senha.
A sua API pega esse JSON e o "deserializa" para um objeto do tipo LoginDTO, tornando mais fácil para o seu código C# manipular esses dados.
