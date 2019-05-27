using Meubilair.Core.EntityFactoryFramework;
using Meubilair.Model.Customers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Repositories.Customers
{
    public class CustomerFactory : IEntityFactory<Customer>
    {
        internal static class FieldNames
        {

            public const string CustomerId = "CustomerID";
            public const string CustomerName = "CustomerName";

        }
        public Customer BuildEntity(IDataReader reader)
        {
            Customer customer = new Customer(reader[FieldNames.CustomerId]);
            customer.FirstName = reader[FieldNames.CustomerName].ToString();
            return customer;
        }
    }
}
