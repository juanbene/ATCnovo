using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATC_
{
    internal class GerenciarConta
    {
        public static List<Conta> CarregarContas()
        {
            try
            {
                string[] linhas = File.ReadAllLines("C:\\Users\\Administrador\\source\\repos\\ATC#\\ATC#\\conta.csv");
                return linhas.Select(CriarConta).ToList();

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Arquivo contas.csv não encontrado. Criando um novo arquivo.");
            }
            return new List<Conta>();
        }    

        static Conta CriarConta(string linha)
        {
            string[] dados = linha.Split(',');
            int id = int.Parse(dados[0]);
            string nome = dados[1];
            double saldo = double.Parse(dados[2]);
            return new Conta(id, nome, saldo);
        }
        
        static void SalvarContas(List<Conta> contas)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\Administrador\\source\\repos\\ATC#\\ATC#\\conta.csv"))
                {
                    foreach (Conta conta in contas)
                    {
                        writer.WriteLine($"{conta.Id},{conta.Nome},{conta.Saldo}");
                    }
                }
                Console.WriteLine("Dados gravados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar contas no arquivo: {ex.Message}");
            }
        }
    }
}
    


