using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Infrastructure.UI
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private IView view;
        private DelegateCommand cancelCommand;

        public ViewModel() : this(null)
        {

        }
        public ViewModel(IView view)
        {
            this.view = view;
            this.cancelCommand = new DelegateCommand(this.CancelCommandHandler);
        }

        private void CancelCommandHandler(object sender, DelegateCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        public DelegateCommand CancelCommand
        {
            get { return this.cancelCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void CancelCommandHandler(object sender, EventArgs e)
        {
            this.CloseView();
        }

        protected void CloseView()
        {
            if (this.view != null)
            {
                this.view.Close();
            }
        }
    }
}
