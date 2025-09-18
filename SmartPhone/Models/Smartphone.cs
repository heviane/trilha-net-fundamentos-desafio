using System;

namespace SmartPhone.Models
{
    public abstract class Smartphone
    {
        public string Numero { get; set; }
        // Propriedades implementadas de acordo com o diagrama de classes.
        public string Modelo { get; }
        public string IMEI { get; }
        public int Memoria { get; }

        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            // Parâmetros do construtor passados para as propriedades.
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
        }

        public void Ligar()
        {
            Console.WriteLine("Ligando...");
        }

        public void ReceberLigacao()
        {
            Console.WriteLine("Recebendo ligação...");
        }

        public abstract void InstalarAplicativo(string nomeApp);
    }
}
