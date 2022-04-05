using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Salvando Pedido =======");

            var typeOrderSistemRequest = TypeServiceOrder._api;

            IServiceOrder _serviceOrder = null;

            switch (typeOrderSistemRequest)
            {
                case TypeServiceOrder._api:
                    _serviceOrder = new OrderApi();
                    break;
                case TypeServiceOrder._crm:
                    _serviceOrder = new OrderCrm();
                    break;
                case TypeServiceOrder._internal:
                    _serviceOrder = new OrderInternal();
                    break;
                default:
                    break;
            }

            _serviceOrder.save();
            _serviceOrder.delete();
        }
    }
    public class OrderCrm : IServiceOrder
    {
        public void delete()
        {
            Console.WriteLine("Deletou o pedido no CRM");
        }

        public void save()
        {
            Console.WriteLine("Salvou o pedido no CRM");
        }
    }
    public class OrderInternal : IServiceOrder
    {
        public void delete()
        {
            Console.WriteLine("Deletou o pedido no banco de dados do sistema");
        }

        public void save()
        {
            Console.WriteLine("Salvou o pedido no banco de dados do sistema");
        }
    }

    public class OrderApi : IServiceOrder
    {
        public void delete()
        {
            Console.WriteLine("Deletou o pedido via api");
        }

        public void save()
        {
            Console.WriteLine("Enviou o pedido via api");
        }
    }

    public class OrderService
    {
        public readonly IServiceOrder _serviceOrder;
        public OrderService(IServiceOrder serviceOrder)
        {
            _serviceOrder = serviceOrder;
        }



    }



    public enum TypeServiceOrder
    {
        _api = 1,
        _internal = 2,
        _crm = 3
    }

    public interface IServiceOrder
    {
        void save();
        void delete();
    }

}
