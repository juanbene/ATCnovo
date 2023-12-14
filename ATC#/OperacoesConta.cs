using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATC_
{
    public static class OperacoesConta
    {
        public static int ExecutarOperacao(int opcao, List<Conta> contas)
        {
            switch (opcao)
            {
                case Menu.IncluirOpcao:
                    IncluirConta(contas);
                    break;
                case Menu.AlterarOpcao:
                    AlterarSaldo(contas);
                    break;
                case Menu.ExcluirOpcao:
                    ExcluirConta(contas);
                    break;
                case Menu.RelatoriosOpcao:
                    RelatoriosGerenciais(contas);
                    break;
                case Menu.SairOpcao:
                    Console.WriteLine("Saindo do programa.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
            return opcao;
        }
        static int IncluirConta(List<Conta> contas)
        {
            try
            {
                Console.WriteLine("\nInclusão de Conta:");
                Console.Write("Número da conta: ");
                int id = int.Parse(Console.ReadLine());
                if (contas.Any(c => c.Id == id))
                {
                    Console.WriteLine("Erro: Já existe uma conta com esse número.");
                }
                Console.Write("Nome do correntista: ");
                string nome = Console.ReadLine();
                Console.Write("Saldo inicial: ");
                double saldo = double.Parse(Console.ReadLine());
                contas.Add(new Conta(id, nome, saldo));
                Console.WriteLine("Conta incluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao incluir conta: {ex.Message}");
            }
            return -1;
        }
        static void AlterarSaldo(List<Conta> contas)
            {
                try
                {
                    Console.WriteLine("\nAlteração de Saldo:");
                    Console.Write("Número da conta: ");
                    int id = int.Parse(Console.ReadLine());
                    Conta conta = contas.Find(c => c.Id == id);
                    if (conta == null)
                    {
                        Console.WriteLine("Erro: Conta não encontrada.");
                        return;
                    }
                    Console.Write("Digite o valor do saldo (crédito ou débito): ");
                    double valor = double.Parse(Console.ReadLine());
                    Console.Write("Crédito (C) ou Débito (D)? ");
                    char operacao = char.ToUpper(Console.ReadKey().KeyChar);
                    if (operacao == 'C')
                    {
                        conta.Creditar(valor);
                        Console.WriteLine("\nCrédito realizado com sucesso!");
                    }
                    else if (operacao == 'D')
                    {
                        conta.Debitar(valor);
                        Console.WriteLine("\nDébito realizado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\nOperação inválida. Escolha C para crédito ou D para débito.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao alterar saldo: {ex.Message}");
                }
            }
            static void ExcluirConta(List<Conta> contas)
            {
                try
                {
                    Console.WriteLine("\nExclusão de Conta:");
                    Console.Write("Número da conta: ");
                    int id = int.Parse(Console.ReadLine());
                    Conta conta = contas.Find(c => c.Id == id);
                    if (conta == null)
                    {
                        Console.WriteLine("Erro: Conta não encontrada.");
                        return;
                    }
                    if (conta.Saldo != 0)
                    {
                        Console.WriteLine("Erro: O saldo da conta não é zero. Não é possível excluir.");
                        return;
                    }
                    contas.Remove(conta);
                    Console.WriteLine("Conta excluída com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao excluir conta: {ex.Message}");
                }
            }
            static void RelatoriosGerenciais(List<Conta> contas)
            {
                try
                {

                    Console.WriteLine("\nRelatórios Gerenciais:");
                    Console.WriteLine("1. Listar clientes com saldo negativo");
                    Console.WriteLine("2. Listar clientes com saldo acima de um determinado valor");
                    Console.WriteLine("3. Listar todas as contas");
                    Console.Write("Escolha a opção desejada: ");
                    int opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            ListarClientesComSaldoNegativo(contas);
                            break;
                        case 2:
                            ListarClientesComSaldoAcimaDe(contas);
                            break;
                        case 3:
                            ListarTodasAsContas(contas);
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro nos relatórios gerenciais: {ex.Message}");
                }
            }

            static void ListarClientesComSaldoNegativo(List<Conta> contas)
            {
                var clientesComSaldoNegativo = contas.Where(c => c.Saldo < 0);
                if (clientesComSaldoNegativo.Any())
                {
                    Console.WriteLine("\nClientes com saldo negativo:");
                    foreach (var cliente in clientesComSaldoNegativo)
                    {
                        Console.WriteLine(cliente);
                    }
                }
                else
                {
                    Console.WriteLine("Não há clientes com saldo negativo.");
                }
            }

            static void ListarClientesComSaldoAcimaDe(List<Conta> contas)
            {
                try
                {
                    Console.Write("\nInforme o valor para listar clientes com saldo acima de: ");
                    double valorLimite = double.Parse(Console.ReadLine());
                    var clientesComSaldoAcimaDe = contas.Where(c => c.Saldo > valorLimite);
                    if (clientesComSaldoAcimaDe.Any())
                    {
                        Console.WriteLine($"\nClientes com saldo acima de R$ {valorLimite:F2}:");
                        foreach (var cliente in clientesComSaldoAcimaDe)
                        {
                            Console.WriteLine(cliente);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Não há clientes com saldo acima de R$ {valorLimite:F2}.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao listar clientes com saldo acima de: {ex.Message}");
                }
            }

            static void ListarTodasAsContas(List<Conta> contas)
            {
                if (contas.Any())
                {
                    Console.WriteLine("\nTodas as contas:");
                    foreach (var conta in contas)
                    {
                        Console.WriteLine(conta);
                    }
                }
                else
                {
                    Console.WriteLine("Não há contas cadastradas.");
                }
            }
            
        
    }   
}

