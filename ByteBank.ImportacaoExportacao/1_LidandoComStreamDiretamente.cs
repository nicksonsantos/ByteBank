using ByteBank.ImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.ImportacaoExportacao
{
    partial class Program
    {
        static void LidandoComFileStreamDiretamente()
        {
            string arquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(arquivo, FileMode.Open))
            {
                var buffer = new byte[1024];

                fluxoDoArquivo.Read(buffer, 0, buffer.Length);

                var quantidadeBytesLidos = -1;

                do
                {
                    quantidadeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, quantidadeBytesLidos);
                } while (quantidadeBytesLidos != 0);

            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var encoding = new UTF8Encoding();
            var texto = encoding.GetString(buffer, 0, bytesLidos);

            Console.Write(texto);
        }

        static void TesteInicialLeituraDeArquivo()
        {
            Console.WriteLine("TesteInicialLeituraDeArquivo()\n");
            string enderecoDoArquivo = "contas.txt";

            List<ContaCorrente> listaContas = new List<ContaCorrente>();

            try
            {
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
                }
                Console.WriteLine(listaContas.ExibeListaContas());
                Console.WriteLine(ContaCorrente.TotalContaCorrente);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}