using CommandosMissionEditor.Universal.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class AddPatrolPage
    {
        public AddPatrolViewModel ViewModel { get; } = new AddPatrolViewModel();

        public AddPatrolPage()
        {
            InitializeComponent();
        }
    }
}
