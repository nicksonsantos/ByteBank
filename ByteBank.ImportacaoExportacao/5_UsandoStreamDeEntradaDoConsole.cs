namespace ByteBank.ImportacaoExportacao
{
    partial class Program
    {
        static void StreamDoConsole()
        {
            using (var fluxoDeEntrada = Console.OpenStandardInput())
            using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024]; // 1 kb

                while (true)
                {
                    var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                    fs.Write(buffer, 0, bytesLidos);
                    fs.Flush();

                    Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
                }
            }
        }
    }
}