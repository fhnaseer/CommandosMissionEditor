using CommandosMissionEditor.ViewModels;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class FilesPage
    {
        public FilesViewModel ViewModel { get; } = new FilesViewModel();

        public FilesPage()
        {
            InitializeComponent();
        }
    }
}
