using System.Collections.ObjectModel;
using Commandos.Model.Characters.Enemies.Actions;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddPatrolRouteViewModel : AddItemViewModelBase<EnemyRoute>
    {
        public AddPatrolRouteViewModel(Mission mission) : base(mission)
        {
        }

        internal AddPatrolRouteViewModel() : base(null) { }

        public override string TabName => "Routes";

        public override ObservableCollection<EnemyRoute> ItemCollection => SelectedEnemyPatrol.Routes;

        public override void LoadDefaultItem()
        {
            foreach (var item in ItemCollection)
            {
                if (item.RouteName == SelectedEnemyPatrol.DefaultRoute)
                    DefaultItem = item;
                if (item.RouteName == SelectedEnemyPatrol.EventRoute)
                    EventRoute = item;
            }
        }

        public override void UpdateDefaultItem()
        {
            SelectedEnemyPatrol.DefaultRoute = DefaultItem.RouteName;
        }

        private EnemyRoute _eventRoute;
        public EnemyRoute EventRoute
        {
            get => _eventRoute;
            set
            {
                _eventRoute = value;
                SelectedEnemyPatrol.EventRoute = _eventRoute.RouteName;
                OnPropertyChanged(nameof(EventRoute));
            }
        }

        private EnemyPatrol _selectedEnemyPatrol;
        public EnemyPatrol SelectedEnemyPatrol
        {
            get => _selectedEnemyPatrol;
            set
            {
                _selectedEnemyPatrol = value;
                OnPropertyChanged(nameof(SelectedEnemyPatrol));
                OnPropertyChanged(nameof(ItemCollection));
                OnPropertyChanged(nameof(DefaultItem));
            }
        }

        public override void ClearItem()
        {
            SelectedItem.RouteName = string.Empty;
            SelectedItem.Speed = string.Empty;
            SelectedItem.ActionRepeatType = string.Empty;
        }
    }
}
