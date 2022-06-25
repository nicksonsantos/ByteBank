using ByteBank.ImportacaoExportacao.Modelos;
using System.Text;

namespace ByteBank.ImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //TesteInicialLeituraDeArquivo();

            //LidandoComFileStreamDiretamente();

            string enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    Console.WriteLine(linha);
                }
            }
        }

        

    }
}