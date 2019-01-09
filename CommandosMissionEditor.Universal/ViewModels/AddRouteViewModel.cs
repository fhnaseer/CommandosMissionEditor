using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.EnemyActions;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class AddRouteViewModel : AddItemViewModelBase<EnemyRoute>
    {
        public ObservableCollection<EnemyCharacter> Enemies => Mission.GetEnemies();

        public override ObservableCollection<EnemyRoute> ItemCollection => SelectedEnemy?.Routes;

        public override void LoadDefaultItem()
        {
            OnPropertyChanged(nameof(ItemCollection));
            if (ItemCollection is null) return;
            foreach (var item in ItemCollection)
            {
                if (item.RouteName == SelectedEnemy.DefaultRoute)
                    DefaultItem = item;
                if (item.RouteName == SelectedEnemy.EventRoute)
                    EventRoute = item;
            }
        }

        public override void OnDefaultItemChanged()
        {
            SelectedEnemy.DefaultRoute = DefaultItem?.RouteName;
        }

        private EnemyRoute _eventRoute;
        public EnemyRoute EventRoute
        {
            get => _eventRoute;
            set
            {
                Set(ref _eventRoute, value);
                SelectedEnemy.EventRoute = _eventRoute?.RouteName;
            }
        }

        private EnemyCharacter _selectedEnemy;
        public EnemyCharacter SelectedEnemy
        {
            get => _selectedEnemy;
            set
            {
                Set(ref _selectedEnemy, value);
                LoadDefaultItem();
                OnPropertyChanged(nameof(ItemCollection));
                SelectedItem = new EnemyRoute();
            }
        }
    }
}
