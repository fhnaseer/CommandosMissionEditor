using CommandosMissionEditor.Universal.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class AddRoutePage
    {
        public AddRouteViewModel ViewModel { get; } = new AddRouteViewModel();

        public AddRoutePage()
        {
            InitializeComponent();
        }
    }
}
