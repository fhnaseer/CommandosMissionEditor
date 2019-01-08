using CommandosMissionEditor.Universal.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class CameraPage
    {
        public CameraViewModel ViewModel { get; } = new CameraViewModel();

        public CameraPage()
        {
            InitializeComponent();
        }
    }
}
