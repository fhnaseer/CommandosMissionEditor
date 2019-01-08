using CommandosMissionEditor.Universal.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class AddCommandoPage
    {
        public AddCommandoViewModel ViewModel { get; } = new AddCommandoViewModel();

        public AddCommandoPage()
        {
            InitializeComponent();
        }
    }
}
