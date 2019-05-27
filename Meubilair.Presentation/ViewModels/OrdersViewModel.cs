using Meubilair.Infrastructure.UI;
using Meubilair.Model.Customers;
using Meubilair.Model.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Meubilair.Presentation.ViewModels
{
    public class OrdersViewModel : ViewModel
    {

        private static class Constants
        {
            public const string CurrentOrderPropertyName = "CurrentOrder";

        }
        #region Private Fileds
        private CollectionView orders;
        private DelegateCommand saveOrderCommand;
        private DelegateCommand deleteOrderCommand;
        private DelegateCommand newOrderCommand;
        private IList<Order> orderList;
        private Order currentOrder;

        #endregion

        #region Constractors
        public OrdersViewModel() : this(null)
        {

        }

        public OrdersViewModel(IView view) : base(view)
        {

            this.orderList = OrderService.GetAllOrders();
            this.orders = new CollectionView(this.orderList);
            this.currentOrder = null;
            this.saveOrderCommand = new DelegateCommand(
                this.SaveOrderCommandHandler);
            this.deleteOrderCommand = new DelegateCommand(
                this.DeleteOrderCommandHandler);
            this.newOrderCommand = new DelegateCommand(this.NewOrderCommandHandler);
            this.SaveCommand.IsEnabled = false;

        }

        public CollectionView Orders
        {

            get { return this.orders; }
        }
        public Order CurrentOrder
        {

            get
            {
                return this.currentOrder;
            }

            set
            {

                if (this.currentOrder != value)
                {
                    this.currentOrder = value;
                    this.OnPropertyChanged(Constants.CurrentOrderPropertyName);

                    this.saveOrderCommand.IsEnabled =
                        (this.currentOrder != null);

                }
            }
        }
        private void NewOrderCommandHandler(object sender, DelegateCommandEventArgs e)
        {

            Order order = new Order(sender as Customer);
            this.orderList.Add(order);
            this.orders.Refresh();
            this.orders.MoveCurrentToLast();
        }

        private void DeleteOrderCommandHandler(object sender, DelegateCommandEventArgs e)
        {
            Order order = e.Parameter as Order;
            if (order != null)
            {
                this.orderList.Remove(order);
            }
        }

        private void SaveOrderCommandHandler(object sender, DelegateCommandEventArgs e)
        {
            Order order = e.Parameter as Order;
            if (order != null)
            {
                this.orderList.Add(order);
            }
        }
        #endregion


        #region Public Property


        public DelegateCommand NewCommand
        {
            get { return this.newOrderCommand; }
        }

        public DelegateCommand SaveCommand
        {
            get { return this.saveOrderCommand; }
        }
        //public IList<MenuItem> OrdersListMenu
        //{
        //    get { return this.ordersListMenu; }
        //}


        #endregion


        #region WepApi Methods

        public IList<Order> GetallOrders()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:59637/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            IList<Order> data;
            HttpResponseMessage response = client.GetAsync("/api/order", data,
                new JsonMediaTypeFormatter()).Result;



        }
        static HttpClient client = new HttpClient();
        static async Task RunAsync()
        {
            // Update port # in the following line.

            client.BaseAddress = new Uri("http://localhost:59637/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {


                // Get the product
                IList < Order > = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }


        #endregion




    }
}

