using CommandosMissionEditor.Universal.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class LoadMissionPage
    {
        public LoadMissionViewModel ViewModel { get; } = new LoadMissionViewModel();

        public LoadMissionPage()
        {
            InitializeComponent();
        }
    }
}
