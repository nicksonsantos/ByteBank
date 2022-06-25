using ByteBank.ImportacaoExportacao.Modelos;

namespace ByteBank.ImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //TesteInicialLeituraDeArquivo();

            //LidandoComFileStreamDiretamente();

            //UsarStreamReader();

            //CriarArquivo();

            //CriarArquivoComWriter();

            //TestaEscrita();

            //LeituraBinaria();

            //StreamDoConsole();

            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");
            Console.WriteLine("Arquivo escrevendoComAClasseFile.txt criado!");

            var bytesArquivo = File.ReadAllBytes("contas.txt");
            Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");

            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);
        }

        static void TesteInicialLeituraDeArquivo()
        {
            Console.WriteLine("TesteInicialLeituraDeArquivo()\n");
            string enderecoDoArquivo = "contas.txt";

            List<ContaCorrente> listaContas = new List<ContaCorrente>();

            try
            {
                IEnumerable<string> linhas = File.ReadLines(enderecoDoArquivo);

                foreach (string linha in linhas)
                {
                    listaContas.Add(ConverterStringParaContaCorrente(linha));
                }

                Console.WriteLine(listaContas.ExibeListaContas());
                Console.WriteLine(ContaCorrente.TotalContaCorrente);
            }
            catch
            {
                throw;
            }

        }

    }
}