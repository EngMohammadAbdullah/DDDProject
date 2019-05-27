using Meubilair.Model.Customers;
using Meubilair.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Application
{
    public static class ApplicationProps
    {
        public static Customer CurrentCustomer { get; set; }
        public static IList<Product> CurrentSelectedProduct { get; set; }


    }
}
