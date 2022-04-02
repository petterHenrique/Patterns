using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Buscando o controle remoto =====");

            var controleRemotoInteligente = new ControleRemotoInteligente();

            controleRemotoInteligente.On(new LigarLuz());

            controleRemotoInteligente.On(new LigarTv());
        }
    }


    public class ControleRemotoInteligente // invoker
    {
        public ControleRemotoInteligente()
        {

        }

        public void On(ICommand command)
        {
            command.Execute();
        }
    }


    public class LigarLuz : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Ligou a luz");
        }
    }

    public class LigarTv : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Ligar a Tv");
        }
    }

    public interface ICommand
    {
        void Execute();
    }
}
