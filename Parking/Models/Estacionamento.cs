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

        public bool AdicionarVeiculo(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                return false;
            }

            if (veiculos.Any(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                // Veículo já existe, não adiciona.
                return false;
            }

            veiculos.Add(placa);
            return true;
        }

        public decimal RemoverVeiculo(string placa, int horas)
        {
            if (!VeiculoExiste(placa))
            {
                throw new InvalidOperationException("Veículo não encontrado. Confira se digitou a placa corretamente.");
            }

            if (horas <= 0)
            {
                throw new ArgumentException("A quantidade de horas deve ser um valor positivo.", nameof(horas));
            }

            decimal valorTotal = precoInicial + precoPorHora * horas;

            veiculos.RemoveAll(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase));

            return valorTotal;
        }

        public IReadOnlyList<string> ListarVeiculos()
        {
            // Retorna uma cópia somente leitura da lista para evitar modificações externas.
            return veiculos.AsReadOnly();
        }

        /// <summary>
        /// Verifica se um veículo, identificado pela placa, já está no estacionamento.
        /// A verificação não diferencia maiúsculas de minúsculas.
        /// </summary>
        /// <param name="placa">A placa do veículo a ser verificada.</param>
        /// <returns>Retorna `true` se o veículo estiver estacionado, caso contrário, `false`.</returns>
        public bool VeiculoExiste(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                return false;
            }
            return veiculos.Any(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase));
        }
    }
}
