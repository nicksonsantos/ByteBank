using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public abstract class Funcionario
    {
        private double _salario;
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Salario { get => _salario; protected set { if (value > 0) _salario = value; } }

        public static int TotalDeFuncionarios { get; set; }

        public Funcionario(string nome, string cpf, double salario)
        {
            Nome = nome;
            Cpf = cpf;
            Salario = salario;
            TotalDeFuncionarios++;
        }

        public abstract void AumentarSalario();

        public abstract double GetBonificacao();

    }
}
