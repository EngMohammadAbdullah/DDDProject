using Meubilair.Core;
using Meubilair.Core.DomainBase;
using Meubilair.Core.EntityFactoryFramework;
using Meubilair.Core.RepositoryFramework;
using Meubilair.Model.Orders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Repositories.Orders
{
    public  class OrderFactory : IEntityFactory<Order>
    {
        // Dictionary to enforce the singleton pattern
        private static readonly Dictionary<string, object> repositories = new Dictionary<string, object>();

        public static class FieldNames
        {

            public const string OrderId = "OrderID";
            public const string OrderNumber = "OrderNumber";
            public const string OrderDate = "OrderDate";
            public const string CustomerId = "CustomerID";

        }




        public Order BuildEntity(IDataReader reader)
        {
            Order order =
                new Order(reader[FieldNames.OrderId].ToString());
            return order;
        }
    }
}
