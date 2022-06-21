using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente nickson = new Cliente("Nickson", "123456789-88", "Desenvolvedor");
            ContaCorrente conta = new ContaCorrente(nickson, "123", 1597, "Santander");
            conta.ExibeInformacoes();

            Desenvolvedor nickson2 = new Desenvolvedor("Nickson", "123654987-11", 10000);
            Console.WriteLine("Salario: "+nickson2.Salario);
            Console.WriteLine("Total de funcionarios: " + Funcionario.TotalDeFuncionarios);

            Designer mv = new Designer("Marcos Vinicius", "123654987-11", 10000);
            Console.WriteLine("Total de funcionarios: " + Funcionario.TotalDeFuncionarios);

        }
    }
}