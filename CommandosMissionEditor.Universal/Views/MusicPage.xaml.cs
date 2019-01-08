using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class MusicPage : Page
    {
        public MusicViewModel ViewModel { get; } = new MusicViewModel();

        public MusicPage()
        {
            InitializeComponent();
        }
    }
}
