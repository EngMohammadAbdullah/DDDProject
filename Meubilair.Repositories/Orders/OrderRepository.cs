using Meubilair.Core;
using Meubilair.Core.RepositoryFramework;
using Meubilair.Model.Addresses;
using Meubilair.Model.Customers;
using Meubilair.Model.Orders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Meubilair.Repositories.Orders
{
    public class OrderRepository : SqlCeRepositoryBase<Order>, IOrderRepository
    {

        public OrderRepository() : this(null)
        {

        }

        public OrderRepository(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }
        public Model.Orders.Order this[object key]

        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Add(Order item)
        {


            Console.WriteLine(item.OrderNumber);
        }

        #region BuildChildCallbacks





        protected override void BuildChildCallbacks()
        {
            this.ChildCallbacks.Add(OrderFactory.FieldNames.CustomerId, this.AppendCustomer);

        }


        #endregion
        private void AppendCustomer(Order order, object childEntityKeyValue)
        {
            order.Customer = CustomerService.GetCustomer(childEntityKeyValue);
        }

        protected override string GetBaseQuery()
        {
            return "SELECT * FROM  [Order]";
        }

        protected override string GetBaseWhereClause()
        {


            return " WHERE OrderID = '{0}';";

        }

        protected override string GetEntityName()
        {
            return "Order";
        }

        protected override string GetKeyFieldName()
        {
            return OrderFactory.FieldNames.OrderId;
        }

        protected override void PersistNewItem(Order item)
        {
            StringBuilder builder = new StringBuilder(100);
            builder.Append(string.Format("INSERT INTO Order ({0},{1})",
                OrderFactory.FieldNames.OrderId,
                OrderFactory.FieldNames.OrderNumber));
            builder.Append(string.Format("VALUES ({0},{1});",
                 DataHelper.GetSqlValue(item.Key),
                 DataHelper.GetSqlValue(item.OrderNumber)
                ));
            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(builder.ToString()));
        }

        protected override void PersistUpdatedItem(Order item)
        {
            throw new NotImplementedException();
        }

        private void AppendAddresses(object _order)
        {

            Order order = _order as Order;
            //string sql = string.Format
            //    ("SELECT * FROM CompanyAddress WHERE CompanyID = '{0}'",
            //    order.Key);
            //using (IDataReader reader = this.ExecuteReader(sql))
            //{
            //    Address address = null;
            //    while (reader.Read())
            //    {
            //        address = AddressFactory.BuildAddress(reader);
            //        company.Addresses.Add(address);

            //    }
            //}
        }
    }
}
