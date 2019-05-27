using Meubilair.Core;
using Meubilair.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Repositories.Customers
{
    public class CustomerRepository : SqlCeRepositoryBase<Customer>,
        ICustomerRepository
    {

        public CustomerRepository() : this(null)
        {

        }
        public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        protected override void BuildChildCallbacks()
        {
        }

        protected override string GetBaseQuery()
        {
            return "SELECT * FROM Customer";
        }

        protected override string GetBaseWhereClause()
        {
            return " WHERE CustomerID = '{0}';";
        }

        protected override string GetEntityName()
        {
            return "Customer";
        }

        protected override string GetKeyFieldName()
        {
            return CustomerFactory.FieldNames.CustomerId;
        }

        protected override void PersistNewItem(Customer item)
        {
            throw new NotImplementedException();
        }


        protected override void PersistUpdatedItem(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
