using CommandosMissionEditor.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class AddEnemyRoutePage
    {
        public AddEnemyRouteViewModel ViewModel { get; } = new AddEnemyRouteViewModel();

        public AddEnemyRoutePage()
        {
            InitializeComponent();
        }
    }
}
