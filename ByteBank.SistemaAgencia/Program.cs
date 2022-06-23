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
            // Alura - Curso de C# parte 5: bibliotecas DLLs, documentação e usando o NuGet

            DateTime dataFimPagamento = new DateTime(2022, 9, 5);
            DateTime dataCorrente = DateTime.Today;
            TimeSpan diferencaData = dataFimPagamento - dataCorrente;
            //Utilizando a minha função
            string mensagem = "Vencimento em " + GetIntervaloDeTempoLegivel(diferencaData);
            Console.WriteLine(mensagem);

            //Agora utilizando Humanizer
            mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferencaData);
            Console.WriteLine(mensagem + "\n");

            // Alura - Curso de C# parte 6: Strings, expressões regulares e a classe Object

            TestaStrings();

            TestaRegex();

            TestaObjects();

            // Alura - Curso de C# parte 7: Array e tipos genéricos

            TestaArrayInt();

            TestaArrayContaCorrente();

            TestaListaContaCorrente();

            TestaListaDeObject();

            TestaLista();

            Console.ReadLine();
        }

        static void FimDoBloco()
        {
            Console.WriteLine("Fim da função, aperte enter para prosseguir.");
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

        static void TestaStrings()
        {
            Console.WriteLine("Função TestaStrings()");

            // pagina?argumentos
            // 012345678
            string url = "pagina?argumentos";

            int indiceInterrogacao = url.IndexOf("?");
            Console.WriteLine("indiceInterrogacao: " + indiceInterrogacao);
            string argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(argumentos + "\n");

            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extratorValorDeArgumentosURL = new ExtratorValorDeArgumentosURL(urlParametros);

            string valorMoedaOrigem = extratorValorDeArgumentosURL.GetValor("moedaOrigem");
            Console.WriteLine("Valor de moedaOrigem: " + valorMoedaOrigem);
            string valorMoedaDestino = extratorValorDeArgumentosURL.GetValor("moedaDestino");
            Console.WriteLine("Valor de moedaDestino: " + valorMoedaDestino);
            Console.WriteLine(extratorValorDeArgumentosURL.GetValor("VALOR") + "\n");

            string urlTeste = "https://www.bytebank.com/cambio";

            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTeste.EndsWith("cambio/"));
            Console.WriteLine(urlTeste.Contains("Bytebank") + "\n");

            FimDoBloco();
        }

        static void TestaRegex()
        {
            Console.WriteLine("Função TestaRegex()");

            // string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // string padrao = "[0-9]{4,5}[-][0-9]{4}";
            // string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string textoDeTeste = "Meu nome é Guilherme, me ligue em 4784-4546";

            Match resultado = Regex.Match(textoDeTeste, padrao);
            Console.WriteLine(resultado.Value + "\n");

            FimDoBloco();
        }

        static void TestaObjects()
        {
            Console.WriteLine("Função TestaObjects()");

            Desenvolvedor nickson = new Desenvolvedor("Nickson", "123654987-11", 10000);

            Console.WriteLine("Total de funcionarios: " + Funcionario.TotalDeFuncionarios);

            Designer mv = new Designer("Marcos Vinicius", "123654987-11", 10000);
            // Teste para verificar se a propriedade TotalDeFuncionarios também é incrementada na instanciação de classes que herdam Funcionario
            Console.WriteLine("Total de funcionarios: " + Funcionario.TotalDeFuncionarios + "\n");

            Cliente nickson1 = new Cliente("Nickson", "123456789-88", "Desenvolvedor");
            Cliente nickson2 = new Cliente("Nickson", "123456789-88", "Desenvolvedor");

            bool comparacao = nickson1 == nickson2 ? true : false;
            Console.WriteLine("nickson1 = nickson2 ? " + comparacao);

            comparacao = nickson1.Equals(nickson2);
            Console.WriteLine("nickson1 = nickson2 ? " + comparacao + "\n");

            ContaCorrente conta = new ContaCorrente(nickson1, "123", 1597, "Santander");

            // Testa novo método .Equals() da classe ContaCorrente
            comparacao = nickson1.Equals(conta);
            Console.WriteLine("nickson1 = conta ? " + comparacao);

            conta.Depositar(1000);
            conta.Sacar(500);

            // Testa novo método .ToString() da classe ContaCorrente
            Console.WriteLine(conta);

            FimDoBloco();
        }

        static void TestaArrayInt()
        {
            Console.WriteLine("Função TestaArrayInt()");

            Random rnd = new Random();

            int tamanhoVetor = rnd.Next(1, 20);

            int[] idades = new int[tamanhoVetor];

            for (int indice = 0; indice < tamanhoVetor; indice++)
            {
                idades[indice] = rnd.Next(1, 120);
            }

            int acumulador = 0;

            for (int indice = 0; indice < tamanhoVetor; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array no indice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            double media = acumulador / tamanhoVetor;

            Console.WriteLine($"Total média = {media}\n");

            FimDoBloco();
        }

        static void TestaArrayContaCorrente()
        {
            Console.WriteLine("Função TestaArrayContaCorrente()");

            Random rnd = new Random();

            Cliente[] clientes = new Cliente[3];

            Cliente neymar = new Cliente("Neymar", "123", "Jogador de Futebol");
            Cliente messi = new Cliente("Messi", "456", "Jogador de Futebol");
            Cliente cr7 = new Cliente("Cristiano Ronaldo", "789", "Jogador de Futebol");
            
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(neymar, "0001", rnd.Next(), "ByteBank01"),
                new ContaCorrente(messi, "0002", rnd.Next(), "ByteBank01"),
                new ContaCorrente(cr7, "0003", rnd.Next(), "ByteBank01")
            };

            for (int indice = 0; indice < clientes.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Conta}");
            }

            FimDoBloco();
        }

        static void TestaListaContaCorrente()
        {
            Console.WriteLine("Função TestaListaContaCorrente()");

            Random rnd = new Random();

            Cliente neymar = new Cliente("Neymar", "123", "Jogador de Futebol");
            Cliente messi = new Cliente("Messi", "456", "Jogador de Futebol");
            Cliente cr7 = new Cliente("Cristiano Ronaldo", "789", "Jogador de Futebol");
            Cliente john = new Cliente("John", "642", "Empresário");
            Cliente textor = new Cliente("Textor", "971", "Cozinheiro");
            Cliente toro = new Cliente("Toro", "135", "Jogador de Futebol");

            // Lista 1 inicializada com tamanho 3
            ListaDeContaCorrente listaDeContaCorrente1 = new ListaDeContaCorrente(3);
            Console.WriteLine("Lista 1");
            listaDeContaCorrente1.Adicionar(new ContaCorrente(neymar, "0001", rnd.Next(), "ByteBank01"));
            listaDeContaCorrente1.Adicionar(new ContaCorrente(messi, "0002", rnd.Next(), "ByteBank01"));
            listaDeContaCorrente1.Adicionar(new ContaCorrente(cr7, "0003", rnd.Next(), "ByteBank01"));
            Console.WriteLine();

            ContaCorrente contaDoMessi = new ContaCorrente(messi, "0002", 1, "ByteBank01");
            // Lista 2 inicializada sem parametro, logo, inicializa com espaço 1 como definimos no construtor
            ListaDeContaCorrente listaDeContaCorrente2 = new ListaDeContaCorrente();
            Console.WriteLine("Lista 2");
            listaDeContaCorrente2.Adicionar(new ContaCorrente(neymar, "0001", 1, "ByteBank01"));
            listaDeContaCorrente2.Adicionar(contaDoMessi);
            listaDeContaCorrente2.Adicionar(new ContaCorrente(cr7, "0003", 1, "ByteBank01"));
            Console.WriteLine();

            Console.WriteLine("Lista 2:");
            Console.WriteLine(listaDeContaCorrente2 + "\n");

            Console.WriteLine("A conta do Messi está no indice: " + listaDeContaCorrente2.Encontra(contaDoMessi) + "\n");
            
            Console.WriteLine("Removendo a conta do Messi\n");
            listaDeContaCorrente2.Remover(contaDoMessi);

            Console.WriteLine("Lista 2");
            Console.WriteLine(listaDeContaCorrente2);

            listaDeContaCorrente2.Adicionar(contaDoMessi);

            Console.WriteLine(listaDeContaCorrente2 + "\n");

            for (int i = 0; i < listaDeContaCorrente2.Tamanho; i++)
            {
                ContaCorrente conta = listaDeContaCorrente2[i];
                Console.WriteLine($"{conta.Conta}/{conta.NumeroAgencia}");
            }
            Console.WriteLine();

            listaDeContaCorrente2.AdicionarVarios
            (
                new ContaCorrente(john, "987", rnd.Next(), "ByteBank01"),
                new ContaCorrente(textor, "644", rnd.Next(), "ByteBank01"),
                new ContaCorrente(toro, "428", rnd.Next(), "ByteBank01")
            );
            Console.WriteLine();
            Console.WriteLine("Lista 2:");
            Console.WriteLine(listaDeContaCorrente2);     

            FimDoBloco();
        }

        static void TestaListaDeObject()
        {
            Console.WriteLine("Função TestaListaDeObject()");

            Random rnd = new Random();

            ListaDeObject listaDeIdades = new ListaDeObject();

            for (int i = 0; i < rnd.Next(1, 20); i++)
            {
                listaDeIdades.Adicionar(rnd.Next(1, 120));
            }

            listaDeIdades.Adicionar("nickson");

            listaDeIdades.AdicionarVarios(7, 13, 28);

            Console.WriteLine(listaDeIdades);

            FimDoBloco();

        }

        static void TestaLista()
        {
            Console.WriteLine("Função TestaLista()");

            Lista<int> idades = new Lista<int>();
            idades.Adicionar(5);
            idades.AdicionarVarios(13, 17, 24, 78);
            Console.WriteLine(idades);

            for (int i = 0; i < idades.Tamanho; i++)
            {
                int idadeAtual = idades[i];
                Console.WriteLine("Idade: " + idadeAtual);
            }

            FimDoBloco();
        }
    }
}