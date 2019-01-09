using CommandosMissionEditor.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class AddEnemyActionPage
    {
        public AddEnemyActionViewModel ViewModel { get; } = new AddEnemyActionViewModel();

        public AddEnemyActionPage()
        {
            InitializeComponent();
        }
    }
}
