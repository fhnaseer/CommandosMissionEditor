using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class EnemiesPage : Page
    {
        public EnemiesViewModel ViewModel { get; } = new EnemiesViewModel();

        public EnemiesPage()
        {
            InitializeComponent();
        }
    }
}
