using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Define uma Conta Corrente do banco ByteBank.
    /// </summary>
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

        /// <summary>
        /// Cria uma instância de Conta Corrente com os argumentos utilizados.
        /// </summary>
        /// <param name="titular"> Representa o valor da propriedade <see cref="Cliente"> e deve ser uma instância de Cliente</param>
        /// <param name="conta"> Representa o valor da propriedade <see cref="Conta"> e não pode ser uma string vazia</param>
        /// <param name="numeroAgencia"> Representa o valor da propriedade <see cref="NumeroAgencia"> e deve possuir um valor maior que zero</param>
        /// <param name="nomeAgencia"> Representa o valor da propriedade <see cref="NomeAgencia"> e não pode ser uma string vazia</param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>
        /// </summary>
        /// <param name="valor"> Representa o valor do saque, deve ser maior que zero e menor que o <see cref="Saldo"/></param>
        /// <exception cref="ValorNegativoException"> Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/></exception>
        /// <exception cref="SaldoInsuficienteException"> Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/></exception>
        public void Sacar(double valor)
        {
            if (ValorNegativo(valor))
            {
                throw new ValorNegativoException("Valor negativo informado");
            }
            if (FundosInsuficientes(valor))
            {
                throw new SaldoInsuficienteException("Saldo insuficiente");
            }

            Saldo = Saldo - valor;
        }
        public bool ValorNegativo(double valor)
        {
            if (valor < 0)
                return true;

            return false;
        }

        private bool FundosInsuficientes(double valor)
        {
            if (Saldo < valor)
                return true;

            return false;
        }        

    }
}
