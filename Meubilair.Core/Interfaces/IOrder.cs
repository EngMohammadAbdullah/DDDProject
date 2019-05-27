using Meubilair.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Interfaces
{
    public interface IOrder
    {
        Order Get(Order order);
        void Add(Order order);
        void Delete(Order order);
        void Update(Order order);
        IEnumerable<Order> GetOrders();

    }
}
