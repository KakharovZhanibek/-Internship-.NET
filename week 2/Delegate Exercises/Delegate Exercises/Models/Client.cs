using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Exercises.Models
{
    public enum ClientType
    {
        NewClient,
        PermanentBigOrders,
        PermanentSmallOrders
    }
    public class Client
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public ClientType Type { get; set; }
        public string Address { get; set; }
    }
}
