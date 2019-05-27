using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Infrastructure.UI
{
    public static class ViewFactory
    {
        public static IView GetView(string name)
        {
            string typeName = string.Empty;
            // TODO:  make this be configuration-based
            switch (name)
            {
                case "Orders":
                    typeName =     "Meubilair.Presentation.Views.Orders,Meubilair.Presentation";
                    break;
                case "Customers":
                    typeName = "Meubilair.Presentation.Views.CustomersView,Meubilair.Presentation";
                    break;
                default:
                    break;
            }
            return Activator.CreateInstance(Type.GetType(typeName)) as IView;
        }
    }
}
