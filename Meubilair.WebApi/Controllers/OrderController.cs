using Meubilair.Model.Customers;
using Meubilair.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Meubilair.WebApi.Controllers
{
    public class OrderController : ApiController
    {


        public IList<Order> Get()
        {
            var dd  = OrderService.GetAllOrders();

            return OrderService.GetAllOrders();

        }
        
    }
}
