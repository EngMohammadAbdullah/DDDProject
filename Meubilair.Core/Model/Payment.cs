using Meubilair.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Model
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime Date { get; set; }
        public Order Order { get; set; }
        public decimal Amount { get; set; }

    }
}
