using CommandosMissionEditor.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class AddEnemyPatrolPage
    {
        public AddEnemyPatrolViewModel ViewModel { get; } = new AddEnemyPatrolViewModel();

        public AddEnemyPatrolPage()
        {
            InitializeComponent();
        }
    }
}
