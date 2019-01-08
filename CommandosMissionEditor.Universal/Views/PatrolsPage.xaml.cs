using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class PatrolsPage : Page
    {
        public PatrolsViewModel ViewModel { get; } = new PatrolsViewModel();

        public PatrolsPage()
        {
            InitializeComponent();
        }
    }
}
