using CommandosMissionEditor.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class MusicPage
    {
        public MusicViewModel ViewModel { get; } = new MusicViewModel();

        public MusicPage()
        {
            InitializeComponent();
        }
    }
}
