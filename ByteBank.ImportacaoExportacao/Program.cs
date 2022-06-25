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

            LeituraBinaria();
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