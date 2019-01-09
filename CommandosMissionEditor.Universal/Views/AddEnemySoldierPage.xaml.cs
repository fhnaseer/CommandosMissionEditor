using CommandosMissionEditor.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class AddEnemySoldierPage
    {
        public AddEnemySoldierViewModel ViewModel { get; } = new AddEnemySoldierViewModel();

        public AddEnemySoldierPage()
        {
            InitializeComponent();
        }
    }
}
