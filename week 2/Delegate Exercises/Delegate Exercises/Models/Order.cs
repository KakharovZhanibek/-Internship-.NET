using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Exercises.Models
{
    public class Order
    {
        public Guid OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public int ClientId { get; set; }
    }
}
