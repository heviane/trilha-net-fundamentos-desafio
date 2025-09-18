using System;

namespace SmartPhone.Models
{
    public abstract class Smartphone
    {
        /// <summary>
        /// O número de telefone do celular.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// O modelo específico do aparelho.
        /// </summary>
        public string Modelo { get; }

        /// <summary>
        /// O código IMEI (International Mobile Equipment Identity) único do aparelho.
        /// </summary>
        public string IMEI { get; }

        /// <summary>
        /// A capacidade de memória interna do aparelho, em Gigabytes (GB).
        /// </summary>
        public int Memoria { get; }

        /// <summary>
        /// Construtor para a classe Smartphone.
        /// </summary>
        /// <param name="numero">O número de telefone.</param>
        /// <param name="modelo">O modelo do aparelho.</param>
        /// <param name="imei">O código IMEI do aparelho.</param>
        /// <param name="memoria">A capacidade de memória em GB.</param>
        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
        }

        /// <summary>
        /// Simula o ato de ligar o smartphone.
        /// </summary>
        public void Ligar()
        {
            Console.WriteLine("Ligando...");
        }

        /// <summary>
        /// Simula o recebimento de uma ligação.
        /// </summary>
        public void ReceberLigacao()
        {
            Console.WriteLine("Recebendo ligação...");
        }

        /// <summary>
        /// Método abstrato para instalar um aplicativo. A implementação é específica para cada modelo de smartphone.
        /// </summary>
        /// <param name="nomeApp">O nome do aplicativo a ser instalado.</param>
        public abstract void InstalarAplicativo(string nomeApp);
    }
}
