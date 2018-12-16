using System.Windows;
using CommandosMissionEditor.ViewModels;

namespace CommandosMissionEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = new UploadMissionViewModel();
        }
    }
}
