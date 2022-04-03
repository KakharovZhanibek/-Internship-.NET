using Delegate_Exercises.Models;
using System;

namespace Delegate_Exercises
{
    class Program
    {
        delegate void Message();
        static void Main(string[] args)
        {
            Client client1 = new Client() 
            { 
                ClientId=123,
                Address="st. 123",
                FullName="Nick",
                Type=ClientType.PermanentBigOrders
            };
            Client client2 = new Client()
            {
                ClientId = 777,
                Address = "st. 777",
                FullName = "Johny",
                Type = ClientType.PermanentSmallOrders
            };

            OrderService orderService = new OrderService();

            orderService.MakeOrder(client1, 154800);
            orderService.MakeOrder(client1, 97800);
            orderService.MakeOrder(client2, 46300);

            foreach (var item in orderService.orderList)
            {
                Console.WriteLine(item.Sum);
            }
        }
    }
}
