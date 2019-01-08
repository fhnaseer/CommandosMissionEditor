using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class LoadMissionPage : Page
    {
        public LoadMissionViewModel ViewModel { get; } = new LoadMissionViewModel();

        public LoadMissionPage()
        {
            InitializeComponent();
        }
    }
}
