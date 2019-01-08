using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class SaveMissionPage : Page
    {
        public SaveMissionViewModel ViewModel { get; } = new SaveMissionViewModel();

        public SaveMissionPage()
        {
            InitializeComponent();
        }
    }
}
