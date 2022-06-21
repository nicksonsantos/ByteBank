using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class ContaCorrente
    {
        
        public Cliente Cliente { get; private set; }
        public string Conta { get; private set; }
        public int NumeroAgencia { get; private set; }
        public string NomeAgencia { get; private set; }        
        public double Saldo { get; private set; }
        public static double TaxaOperacao { get; private set; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }
        public static int TotalDeContasCriadas { get; private set; }

        public ContaCorrente(Cliente titular, string conta, int numeroAgencia, string nomeAgencia)
        {
            if (titular == null)
            {
                throw new ArgumentException("O argumento titular não pode ser nulo", nameof(titular));
            }
            if (conta == null)
            {
                throw new ArgumentException();
            }
            if (numeroAgencia <= 0)
            {
                throw new ArgumentException("O argumento numeroAgencia não pode ser nulo", nameof(numeroAgencia));
            }
            if (nomeAgencia == null)
            {
                throw new ArgumentException("O argumento nomeAgencia não pode ser nulo", nameof(nomeAgencia));
            }
            Cliente = titular;
            Conta = conta;
            NumeroAgencia = numeroAgencia;
            NomeAgencia = nomeAgencia;
            titular.Conta = this;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Depositar(double valor)
        {
            Saldo = Saldo + valor;
        }

        public void ExibeInformacoes()
        {
            Console.WriteLine($"Titular da conta: {this.Cliente.Nome}");
            Console.WriteLine($"Número da conta: {this.Conta}");
            Console.WriteLine($"Agência: {this.NumeroAgencia}");
            Console.WriteLine($"Agência: {this.NomeAgencia}");
            Console.WriteLine($"Saldo R$ {String.Format("{0:0.00}", this.Saldo)}");
        }

        public void Sacar(double valor)
        {
            if (FundosInsuficientes(valor) || SaldoNegativo())
            {
                throw new SaldoInsuficienteException("Saldo insuficiente");
            }

            Saldo = Saldo - valor;
        }

        private bool FundosInsuficientes(double valor)
        {
            if (valor >= Saldo)
                return true;

            return false;
        }

        public bool SaldoNegativo()
        {
            if (this.Saldo < 0)
                return true;

            return false;
        }
        
        public void Transferir(double valor, ContaCorrente destino)
        {
            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            this.Saldo = this.Saldo - valor;
            destino.Saldo = destino.Saldo + valor;
        }

    }
}
