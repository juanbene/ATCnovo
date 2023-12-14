using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATC_
{
    public class Conta
    {
        public int Id { get; }
        public string Nome { get; }
        private double saldo;
        public double Saldo
        {
            get
            {
                return saldo;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("O saldo não pode ser negativo.");
                }
                saldo = value;
            }
        }
        public Conta(int id, string nome, double saldoInicial)
        {
            Id = id;
            Nome = nome;
            Saldo = saldoInicial;
        }

        public void Creditar(double valor)
        {
            Saldo += valor;
        }

        public void Debitar(double valor)
        {
            if (valor > Saldo)
            {
                throw new ArgumentException("Saldo insuficiente.");
            }
            Saldo -= valor;
        }
    }
}
