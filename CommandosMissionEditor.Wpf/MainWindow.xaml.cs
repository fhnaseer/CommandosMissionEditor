using CommandosMissionEditor.Wpf.ViewModels;

namespace CommandosMissionEditor.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = new EditMissionViewModel();
        }
    }
}
