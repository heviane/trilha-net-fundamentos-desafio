using System;

namespace SmartPhone.Models
{
    // Classe Nokia herdando de Smartphone.
    public class Nokia : Smartphone
    {
        public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {
        }

        // Método "InstalarAplicativo" sobrescrito.
        public override void InstalarAplicativo(string nomeApp)
        {
            Console.WriteLine($"Instalando o aplicativo \"{nomeApp}\" no Nokia.");
        }
    }
}
