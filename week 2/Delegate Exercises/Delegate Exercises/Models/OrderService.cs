using Delegate_Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Exercises.Models
{
    public class OrderService
    {
        public List<Order> orderList = new List<Order>();
        public Dictionary<ClientType, Func<int, double>> typeDiscounts = new Dictionary<ClientType, Func<int, double>>();
        public OrderService()
        {
            typeDiscounts.Add(ClientType.NewClient, CalculateDiscountForNewClient);
            typeDiscounts.Add(ClientType.PermanentBigOrders, CalculateDiscountForPermanentBigOrdersClient);
            typeDiscounts.Add(ClientType.PermanentSmallOrders, CalculateDiscountForPermanentSmallOrdersClient);
        }
        public void MakeOrder(Client client, int price)
        {
            Order order = new Order();

            order.Date = DateTime.Now.Date;
            order.ClientId = client.ClientId;
            order.OrderNumber = Guid.NewGuid();
            order.Sum = typeDiscounts[client.Type](price);
            
            orderList.Add(order);
        }
        private double CalculateDiscountForPermanentBigOrdersClient(int price)
        {
            int discount = 0;
            if (price >= 100000)
                discount = 15;
            else
                discount = 10;

            return (double)price - price * discount / 100;
        }
        private double CalculateDiscountForPermanentSmallOrdersClient(int price)
        {
            int discount = 5;
            return (double)price - price * discount / 100;
        }
        private double CalculateDiscountForNewClient(int price)
        {
            int discount = 0;
            return (double)price - price * discount / 100;
        }

    }

}
