using System;

using CommandosMissionEditor.Universal.ViewModels;

using Windows.UI.Xaml.Controls;

using WinUI = Microsoft.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
        }

        private void OnItemInvoked(WinUI.NavigationView sender, WinUI.NavigationViewItemInvokedEventArgs args)
        {
            // Workaround for Issue https://github.com/Microsoft/WindowsTemplateStudio/issues/2774
            // Using EventTriggerBehavior does not work on WinUI NavigationView ItemInvoked event in Release mode.
            ViewModel.ItemInvokedCommand.Execute(args);
        }
    }
}
