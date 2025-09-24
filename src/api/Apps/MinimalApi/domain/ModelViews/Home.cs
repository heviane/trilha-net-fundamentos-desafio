namespace MinimalApi.Domain.ModelViews
{
    /// <summary>
    /// ModelView para a rota principal, contendo a mensagem de boas-vindas e o link para a documentação.
    /// </summary>
    /// <param name="Message">Mensagem de boas-vindas.</param>
    /// <param name="Doc">URL completa para a documentação do Swagger.</param>
    public record Home(string Message, string Doc);
}
