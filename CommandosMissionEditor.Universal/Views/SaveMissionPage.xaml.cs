using CommandosMissionEditor.Universal.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class SaveMissionPage
    {
        public SaveMissionViewModel ViewModel { get; } = new SaveMissionViewModel();

        public SaveMissionPage()
        {
            InitializeComponent();
        }
    }
}
