using Meubilair.Core.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Model.Customers
{
    public class Customer : Person
    {


        public Customer() : this(null)
        {

        }

        public Customer(object key) : base(key)
        {

        }
    }
}
