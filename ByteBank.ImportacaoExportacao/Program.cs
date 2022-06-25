using ByteBank.ImportacaoExportacao.Modelos;

namespace ByteBank.ImportacaoExportacao
{
    class Program
    {
        static void Main(string[] args)
        {
            string enderecoDoArquivo = "contas.txt";

            List<ContaCorrente> listaContas = new List<ContaCorrente>();

            IEnumerable<string> linhas = System.IO.File.ReadLines(enderecoDoArquivo);

            foreach (string linha in linhas)
            {
                string[] registros = linha.Split(' ');
                int agencia = Int32.Parse(registros[0]);
                int numero = Int32.Parse(registros[1]);
                double saldo = Double.Parse(registros[2]);
                string nomeDoTitular = registros[3];
                Cliente cliente = new Cliente(nomeDoTitular);

                listaContas.Add(new ContaCorrente(agencia, numero, saldo, cliente));
                Console.WriteLine(linha);
                
            }
            Console.WriteLine(listaContas.ExibeListaContas());
            Console.WriteLine(ContaCorrente.TotalContaCorrente);
            //Console.WriteLine("Conteudo de contas.txt = {0}", texto);
        }

        

    }
}