using Meubilair.Infrastructure.UI;
using Meubilair.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Meubilair.Presentation.Views
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : Window, IView
    {
        public CustomersView()
        {
            InitializeComponent();
            this.DataContext = new CustomerViewModel(this);
        }
    }
}
