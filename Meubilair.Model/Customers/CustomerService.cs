using Meubilair.Core;
using Meubilair.Core.RepositoryFramework;
using Meubilair.Repositories.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Model.Customers
{
    public class CustomerService
    {
        private static ICustomerRepository repository;
        private static IUnitOfWork unitOfWork;
        static CustomerService()
        {
            CustomerService.unitOfWork = new UnitOfWork();
            CustomerService.repository = RepositoryFactory.GetRepository<ICustomerRepository, Customer>(CustomerService.unitOfWork);
        }

        public static Customer GetCustomer(object customerKey)
        {
            return CustomerService.repository.FindBy(customerKey);
        }

        public static IList<Customer> GetAllCustomers()
        {
            IList<Customer> list = new List<Customer>();
            list.Add(new Customer() { FirstName = "Mohamed" });
            list.Add(new Customer() { FirstName = "Hasan" });
            return list;
            //return repository.FindAll();
        }

        public static void SaveCustomer(Customer selectedCustomer)
        {
            CustomerService.repository[selectedCustomer.Key] = selectedCustomer;
            CustomerService.unitOfWork.Commit();
        }
    }
}
