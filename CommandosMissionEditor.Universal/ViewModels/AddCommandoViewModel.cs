using System.Windows.Input;
using CommandosMissionEditor.Universal.Helpers;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class AddCommandoViewModel : ViewModelBase
    {

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(Add));

        internal void Add()
        {
        }
    }
}
