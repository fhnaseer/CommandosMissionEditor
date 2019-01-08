using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class FilesPage : Page
    {
        public FilesViewModel ViewModel { get; } = new FilesViewModel();

        public FilesPage()
        {
            InitializeComponent();
        }
    }
}
