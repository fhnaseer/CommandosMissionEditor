using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.EnemyActions;
using Commandos.Model.Map;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.ViewModels
{
    public class AddEnemyRouteViewModel : AddItemViewModelBase<EnemyRoute>
    {
        public override string TabName => "Routes";

        public ObservableCollection<EnemyCharacter> Enemies => Mission.GetEnemies();

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
    }
}
