namespace ATC_
{
    class Program
    {
        static void Main(string[] args)
        {

            int opcao = 0;
            do
            {
                Menu.MostrarMenu();
                opcao = Menu.ObterOpcaoUsuario();              
            } while (opcao != Menu.SairOpcao);
            
        }      
    }
}

   
 
