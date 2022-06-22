using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Desenvolvedor nickson2 = new Desenvolvedor("Nickson", "123654987-11", 10000);
            Console.WriteLine("Salario: " + nickson2.Salario);
            Console.WriteLine("Total de funcionarios: " + Funcionario.TotalDeFuncionarios);
            Designer mv = new Designer("Marcos Vinicius", "123654987-11", 10000);
            Console.WriteLine("Total de funcionarios: " + Funcionario.TotalDeFuncionarios);
            Console.WriteLine();

            Cliente nickson = new Cliente("Nickson", "123456789-88", "Desenvolvedor");
            ContaCorrente conta = new ContaCorrente(nickson, "123", 1597, "Santander");
            conta.Depositar(1000);
            conta.Sacar(500);
            conta.ExibeInformacoes();
            Console.WriteLine();

            DateTime dataFimPagamento = new DateTime(2022, 9, 5);
            DateTime dataCorrente = DateTime.Today;
            TimeSpan diferencaData = dataFimPagamento - dataCorrente;
            //Utilizando a minha função
            string mensagem = "Vencimento em " + GetIntervaloDeTempoLegivel(diferencaData);
            Console.WriteLine(mensagem);

            //Agora utilizando Humanizer
            mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferencaData);
            Console.WriteLine(mensagem);
            Console.WriteLine();

            // pagina?argumentos
            // 012345678

            string url = "pagina?argumentos";
            string argumentos = url.Substring(7);
            Console.WriteLine(argumentos);


            Console.ReadLine();
        }

        static string GetIntervaloDeTempoLegivel(TimeSpan timeSpan)
        {
            int intervaloEmDias = timeSpan.Days;
            int quantidadeMeses = intervaloEmDias / 30;
            int quantidadeSemanas = (intervaloEmDias % 30) / 7;
            int quantidadeDias = quantidadeSemanas % 7;
            string mesOuMeses;
            string semanaOuSemanas;
            string diaOuDias;

            if (quantidadeMeses == 1)
                mesOuMeses = " mes, ";
            mesOuMeses = " meses, ";

            if (quantidadeSemanas == 1)
                semanaOuSemanas = " semana e ";
            semanaOuSemanas = " semanas e ";

            if (quantidadeDias == 1)
                diaOuDias = " dia ";
            diaOuDias = " dias ";

            return quantidadeMeses + mesOuMeses + quantidadeSemanas + semanaOuSemanas + quantidadeDias + diaOuDias;
        }
    }
}