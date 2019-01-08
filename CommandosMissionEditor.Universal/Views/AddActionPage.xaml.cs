using CommandosMissionEditor.Universal.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class AddActionPage
    {
        public AddActionViewModel ViewModel { get; } = new AddActionViewModel();

        public AddActionPage()
        {
            InitializeComponent();
        }
    }
}
