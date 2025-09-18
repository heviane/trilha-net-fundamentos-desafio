using System;

namespace SmartPhone.Models
{
    /// <summary>
    /// Representa um smartphone da marca Nokia.
    /// </summary>
    public class Nokia : Smartphone
    {
        /// <summary>
        /// Cria uma nova instância de um Nokia.
        /// </summary>
        /// <param name="numero">O número de telefone.</param>
        /// <param name="modelo">O modelo do aparelho.</param>
        /// <param name="imei">O código IMEI do aparelho.</param>
        /// <param name="memoria">A capacidade de memória em GB.</param>
        public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {
        }

        /// <summary>
        /// Sobrescreve o método para instalar um aplicativo, simulando o processo em um Nokia.
        /// </summary>
        /// <param name="nomeApp">O nome do aplicativo a ser instalado.</param>
        public override void InstalarAplicativo(string nomeApp)
        {
            Console.WriteLine($"Instalando o aplicativo \"{nomeApp}\" no Nokia.");
        }
    }
}
