using Meubilair.Core.DomainBase;
using Meubilair.Model.Addresses;
using Meubilair.Model.Customers;
using Meubilair.Model.Payments;
using Meubilair.Model.Products;
using System;
using System.Collections.Generic;

namespace Meubilair.Model.Orders
{
    public class Order : EntityBase
    {

        private float orderNumber { get; set; }
        private DateTime _date { get; set; }
        private Address deliveryAddress { get; set; }
        private object customerID;
        private IList<Product> products;
        private IList<Payment> payments;
        private Customer customer;
        public float OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public Address DeliveryAddress { get; set; }


        public Order(object customerKey)
        {
            this.customerID = customerKey;

        }

        public Order(Customer customer)
        {
            this.customer = customer;
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set { this.customer = value; }
        }

        public IList<Product> Products { get; set; }
        public IList<Payment> Payments { get; set; }
        //public Delivery Delivery { get; set; }
        //public DeliveryType DeliveryType { get; set; }

    }
}
