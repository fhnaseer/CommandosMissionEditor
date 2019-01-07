using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class CameraPage : Page
    {
        public CameraViewModel ViewModel { get; } = new CameraViewModel();

        public CameraPage()
        {
            InitializeComponent();
        }
    }
}
