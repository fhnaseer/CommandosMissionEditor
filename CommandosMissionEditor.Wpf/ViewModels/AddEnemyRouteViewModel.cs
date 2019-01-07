using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.Common;
using Commandos.Model.EnemyActions;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddEnemyRouteViewModel : AddEnemyViewModelBase<EnemyRoute>
    {
        public AddEnemyRouteViewModel(Mission mission, CharacterType characterType, ObservableCollection<EnemyCharacter> enemyCharacters) : base(mission, characterType, enemyCharacters)
        {
        }

        internal AddEnemyRouteViewModel() : base(null, CharacterType.Soldier, null) { }

        public override string TabName => "Routes";

        public override ObservableCollection<EnemyRoute> ItemCollection => SelectedEnemy?.Routes;

        public override void LoadDefaultItem()
        {
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
            SelectedEnemy.DefaultRoute = DefaultItem.RouteName;
        }

        private EnemyRoute _eventRoute;
        public EnemyRoute EventRoute
        {
            get => _eventRoute;
            set
            {
                _eventRoute = value;
                SelectedEnemy.EventRoute = _eventRoute.RouteName;
                OnPropertyChanged(nameof(EventRoute));
            }
        }

        private EnemyCharacter _selectedEnemy;
        public EnemyCharacter SelectedEnemy
        {
            get => _selectedEnemy;
            set
            {
                _selectedEnemy = value;
                OnPropertyChanged(nameof(SelectedEnemy));
                OnPropertyChanged(nameof(ItemCollection));
                OnPropertyChanged(nameof(DefaultItem));
            }
        }
    }
}
