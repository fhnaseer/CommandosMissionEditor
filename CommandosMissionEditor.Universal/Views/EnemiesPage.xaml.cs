using CommandosMissionEditor.Universal.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace CommandosMissionEditor.Universal.Views
{
    public sealed partial class EnemiesPage
    {
        public EnemiesViewModel ViewModel { get; } = new EnemiesViewModel();

        public EnemiesPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
        }

        private void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            // Workaround for Issue https://github.com/Microsoft/WindowsTemplateStudio/issues/2774
            // Using EventTriggerBehavior does not work on WinUI NavigationView ItemInvoked event in Release mode.
            ViewModel.ItemInvokedCommand.Execute(args);
        }
    }
}
