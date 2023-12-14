using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATC_
{
    public static class Menu
    {
        public const int IncluirOpcao = 1;
        public const int AlterarOpcao = 2;
        public const int ExcluirOpcao = 3;
        public const int RelatoriosOpcao = 4;
        public const int SairOpcao = 5;
        public static void MostrarMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine($"{IncluirOpcao}. Inclusão de conta");
            Console.WriteLine($"{AlterarOpcao}. Alteração de saldo");
            Console.WriteLine($"{ExcluirOpcao}. Exclusão de conta");
            Console.WriteLine($"{RelatoriosOpcao}. Relatórios gerenciais");
            Console.WriteLine($"{SairOpcao}. Sair");
        }

        public static int ObterOpcaoUsuario()
        {
            Console.Write("Escolha uma opção: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
