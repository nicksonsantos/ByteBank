using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.ImportacaoExportacao.Modelos
{
    public class ContaCorrente
    {
        public int Numero { get; }
        public int Agencia { get; }
        public double Saldo { get; private set; }
        public Cliente Titular { get; set; }
        public static int TotalContaCorrente { get; private set; }

        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
            TotalContaCorrente++;
        }
        public ContaCorrente(int numero, int agencia, double saldo, Cliente titular)
        {
            Agencia = agencia;
            Numero = numero;
            Saldo = saldo;
            Titular = titular;
            TotalContaCorrente++;
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor de deposito deve ser maior que zero.", nameof(valor));
            }

            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor de saque deve ser maior que zero.", nameof(valor));
            }

            if(valor > Saldo)
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }

            Saldo += valor;
        }

        public override string ToString()
        {
            string informacoesConta = string.Empty;

            informacoesConta += $"Número da conta: {Numero}, ag. {Agencia} - ";
            informacoesConta += $"Saldo R$ {String.Format("{0:0.00}", Saldo)} - ";
            informacoesConta += $"Titular da conta: {Titular}\n";

            return informacoesConta;
        }
    }
}
