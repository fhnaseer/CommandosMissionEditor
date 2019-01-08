using CommandosMissionEditor.Universal.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class AddEnemyPage
    {
        public AddEnemyViewModel ViewModel { get; } = new AddEnemyViewModel();

        public AddEnemyPage()
        {
            InitializeComponent();
        }
    }
}
