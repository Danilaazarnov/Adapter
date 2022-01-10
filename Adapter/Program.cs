using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {

            Man man = new Man();
            Car car = new Car();
            man.Travel(car);
            Par par = new Par();
            // используем адаптер
            ITransport parTransport = new HelToTransportAdapter(par);
            man.Travel(parTransport);
            Console.Read();
        }
    }
    interface ITransport
    {
        void Man();
    }

    class Car : ITransport
    {
        public void Man()
        {
            Console.WriteLine("Машина едет по дороге до воды");
        }
    }
    class Man
    {
        public void Travel(ITransport transport)
        {
            transport.Man();
        }
    }
    // интерфейс вертолета
    interface IPar
    {
        void Move();
    }
    class Par : IPar
    {
        public void Move()
        {
            Console.WriteLine("Паром переплывает через реку");
        }
    }
    // Адаптер от Hel к ITransport
    class HelToTransportAdapter : ITransport
    {
        Par par;
        public HelToTransportAdapter(Par c)
        {
            par = c;
        }

        public void Man()
        {
            par.Move();
        }
    }
}