using Meubilair.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Guid DeliveryId { get; set; }
        public Address DeliveryAddress { get; set; }
        public Delivery Delivery { get; set; }
        public DeliveryType DeliveryType { get; set; }

    }
}
