using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Desenvolvedor nickson = new Desenvolvedor("Nickson", "123654987-11", 10000);

            Console.WriteLine("Total de funcionarios: " + Funcionario.TotalDeFuncionarios);

            Designer mv = new Designer("Marcos Vinicius", "123654987-11", 10000);

            Console.WriteLine("Total de funcionarios: " + Funcionario.TotalDeFuncionarios);
            Console.WriteLine();

            Cliente nickson1 = new Cliente("Nickson", "123456789-88", "Desenvolvedor");
            Cliente nickson2 = new Cliente("Nickson", "123456789-88", "Desenvolvedor");

            bool comparacao = nickson1 == nickson2 ? true : false;
            Console.WriteLine("nickson1 = nickson2 ? " + comparacao);

            comparacao = nickson1.Equals(nickson2);
            Console.WriteLine("nickson1 = nickson2 ? " + comparacao);
            Console.WriteLine();

            ContaCorrente conta = new ContaCorrente(nickson1, "123", 1597, "Santander");
            comparacao = nickson1.Equals(conta);
            Console.WriteLine("nickson1 = conta ? " + comparacao);

            conta.Depositar(1000);
            conta.Sacar(500);
            Console.WriteLine(conta);

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

            int indiceInterrogacao = url.IndexOf("?");
            Console.WriteLine("indiceInterrogacao: " + indiceInterrogacao);
            string argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(argumentos);
            Console.WriteLine();

            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extratorValorDeArgumentosURL = new ExtratorValorDeArgumentosURL(urlParametros);

            string valorMoedaOrigem = extratorValorDeArgumentosURL.GetValor("moedaOrigem");
            Console.WriteLine("Valor de moedaOrigem: " + valorMoedaOrigem);
            string valorMoedaDestino = extratorValorDeArgumentosURL.GetValor("moedaDestino");
            Console.WriteLine("Valor de moedaDestino: " + valorMoedaDestino);
            Console.WriteLine(extratorValorDeArgumentosURL.GetValor("VALOR"));
            Console.WriteLine();

            string urlTeste = "https://www.bytebank.com/cambio";
            
            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTeste.EndsWith("cambio/"));
            Console.WriteLine(urlTeste.Contains("Bytebank"));
            Console.WriteLine();

            // string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // string padrao = "[0-9]{4,5}[-][0-9]{4}";
            // string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string textoDeTeste = "Meu nome é Guilherme, me ligue em 4784-4546";

            Match resultado = Regex.Match(textoDeTeste, padrao);
            Console.WriteLine(resultado.Value);
            Console.WriteLine();

                        

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