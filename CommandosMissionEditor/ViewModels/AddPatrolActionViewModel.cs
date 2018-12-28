using System.Collections.ObjectModel;
using Commandos.Model.Characters.Enemies.Actions;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddPatrolActionViewModel : AddItemViewModelBase<EnemyAction>
    {
        public AddPatrolActionViewModel(Mission mission) : base(mission)
        {
        }

        internal AddPatrolActionViewModel() : base(null) { }

        public override string TabName => "Actions";

        public override ObservableCollection<EnemyAction> ItemCollection => SelectedEnemyRoute.Actions;

        private EnemyPatrol _selectedEnemyPatrol;
        public EnemyPatrol SelectedEnemyPatrol
        {
            get => _selectedEnemyPatrol;
            set
            {
                _selectedEnemyPatrol = value;
                OnPropertyChanged(nameof(SelectedEnemyPatrol));
                SelectedEnemyRoute = null;
            }
        }

        private EnemyRoute _selectedEnemyRoute;
        public EnemyRoute SelectedEnemyRoute
        {
            get => _selectedEnemyRoute;
            set
            {
                _selectedEnemyRoute = value;
                OnPropertyChanged(nameof(SelectedEnemyRoute));
                OnPropertyChanged(nameof(ItemCollection));
            }
        }

        public override void ClearItem()
        {

        }
    }
}
