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

        private EnemyPatrol _selectedEnemyPatrol;
        public EnemyPatrol SelectedEnemyPatrol
        {
            get => _selectedEnemyPatrol;
            set
            {
                _selectedEnemyPatrol = value;
                OnPropertyChanged(nameof(SelectedEnemyPatrol));
                OnPropertyChanged(nameof(ItemCollection));
            }
        }
    }
}
