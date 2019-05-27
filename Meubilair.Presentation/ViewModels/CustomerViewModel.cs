using Meubilair.Infrastructure.UI;
using Meubilair.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Meubilair.Presentation.ViewModels
{
    public class CustomerViewModel : ViewModel
    {
        private static class Constants
        {
            public const string SelectedCustomerPropertyName = "SelectedCustomer";

        }

        private CollectionView customers;
        private DelegateCommand saveCommand;
        private DelegateCommand deleteCommand;
        private DelegateCommand newCommand;
        private IList<Customer> customerList;
        private DelegateCommand addOrder;
        private Customer selectedCustomer;


        public DelegateCommand SaveCommand
        {
            get
            {
                return this.saveCommand;
            }
        }

        public CollectionView Customers
        { get { return this.customers; } }

        public DelegateCommand NewCommand { get { return this.newCommand; } }
        public DelegateCommand AddOrderCommand
        {

            get { return this.addOrder; }
        }

        public Customer SelectedCustomer
        {
            get { return this.selectedCustomer; }
            set
            {
                if (this.selectedCustomer != value)
                {
                    this.selectedCustomer = value;
                    this.OnPropertyChanged(Constants.SelectedCustomerPropertyName);
                    this.saveCommand.IsEnabled = (this.selectedCustomer != null);

                }
            }
        }


        public CustomerViewModel() : this(null)
        {

        }
        public CustomerViewModel(IView view) : base(view)
        {
            this.customerList = CustomerService.GetAllCustomers();
            this.customers = new CollectionView(this.customerList);
            this.saveCommand = new DelegateCommand(
                this.SaveCommandHandler);
            this.deleteCommand = new DelegateCommand(
                this.DeleteCommandHandler);
            this.newCommand = new DelegateCommand(this.NewCommandHandler);
            this.SaveCommand.IsEnabled = false;
            this.addOrder = new DelegateCommand(this.AddOrder);
            this.selectedCustomer = null;
        }

        private void AddOrder(object sender, DelegateCommandEventArgs e)
        {
            var selectedCustomer = e.Parameter as Customer;
        }

        private void NewCommandHandler(object sender, DelegateCommandEventArgs e)
        {
            Customer customer = new Customer();
            customer.FirstName = "{Enter First Name}";
            this.customerList.Add(customer);
            this.customers.Refresh();
            this.customers.MoveCurrentToLast();
        }

        private void DeleteCommandHandler(object sender, DelegateCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveCommandHandler(object sender, DelegateCommandEventArgs e)
        {
            CustomerService.SaveCustomer(this.selectedCustomer);
        }
    }
}
