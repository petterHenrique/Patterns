using System;
using System.Collections.Generic;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Buscando o controle remoto =====");

            //var commandoLuz = new CommandLuz() { 
            //    Forca = "250wh",
            //    TipoLuz = "Incandesente"
            //};

            //var commandoTv = new CommandTv()
            //{
            //    MarcaTv = "LG",
            //    TipoTv = "PLASMA"
            //};

            //var executarLuz = new LigarLuz();
            //executarLuz.Execute(commandoLuz);

            //var executarTv = new LigarTv();
            //executarTv.Execute(commandoTv);


            var pedido = new PedidoGeradoCommand
            {
                IdPedido = 1,
                IdCliente = 1,
                produtos = new List<string>() { "1", "2" }
            };


            //_servicoPedido.saveChanges();

            var commandoPedido = new PedidoHandler();
            commandoPedido.Execute(pedido);
        }
    }


    public class PedidoGeradoCommand
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public List<string> produtos { get; set; }
    }

    public class PedidoHandler : ICommand<PedidoGeradoCommand>
    {
        public void Execute(PedidoGeradoCommand command)
        {
            Console.WriteLine("Disparar relatório de pedido email");

            Console.WriteLine("Envia notificação push de venda");
        }
    }

    public class LigarLuz : ICommand<CommandLuz>
    {
        public void Execute(CommandLuz command)
        {
            Console.WriteLine("Tipo Da luz é " + command.TipoLuz + " Força da luz é " + command.Forca);
        }
    }

    public class LigarTv : ICommand<CommandTv>
    {
        public void Execute(CommandTv command)
        {
            Console.WriteLine("Marca da TV é "+command.MarcaTv + " Tipo da TV é "+ command.TipoTv);
        }
    }

    public interface ICommand<T>
    {
        void Execute(T command);
    }

    public class CommandLuz
    {
        public CommandLuz() { }
        public string TipoLuz { get; set; }
        public string Forca { get; set; }
    }

    public class CommandTv
    {
        public CommandTv()
        {

        }
        public string TipoTv { get; set; }
        public string MarcaTv { get; set; }
    }
}
