namespace Parking.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            // Verifica se o veículo já está estacionado (ignorando maiúsculas/minúsculas)
            if (veiculos.Any(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"O veículo com a placa {placa} já está estacionado. Confira a lista de veículos.");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine("Veículo estacionado com sucesso!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                while (!int.TryParse(Console.ReadLine(), out horas) || horas <= 0)
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número de horas maior que zero:");
                }

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.RemoveAll(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:C2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
