using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class OpenMissionPage : Page
    {
        public OpenMissionViewModel ViewModel { get; } = new OpenMissionViewModel();

        public OpenMissionPage()
        {
            InitializeComponent();
        }
    }
}
