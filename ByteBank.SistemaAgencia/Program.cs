using ByteBank.Modelos;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente nickson = new Cliente("Nickson", "123456789-88", "Desenvolvedor");
            ContaCorrente conta = new ContaCorrente(nickson, "123", 1597, "Santander");

            conta.ExibeInformacoes();
        }
    }
}