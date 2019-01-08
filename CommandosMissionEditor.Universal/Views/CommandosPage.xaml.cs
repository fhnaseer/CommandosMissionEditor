using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class CommandosPage : Page
    {
        public CommandosViewModel ViewModel { get; } = new CommandosViewModel();

        public CommandosPage()
        {
            InitializeComponent();
        }
    }
}
