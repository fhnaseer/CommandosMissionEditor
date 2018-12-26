using System.Windows.Input;
using Commandos.Model.Characters.Enemies.Actions;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddPatrolRouteViewModel : MissionViewModelBase
    {
        public AddPatrolRouteViewModel(Mission mission) : base(mission)
        {
        }

        internal AddPatrolRouteViewModel() : base(null) { }

        public override string TabName => "Routes";

        private EnemyPatrol _selectedEnemyPatrol;
        public EnemyPatrol SelectedEnemyPatrol
        {
            get => _selectedEnemyPatrol;
            set
            {
                _selectedEnemyPatrol = value;
                OnPropertyChanged(nameof(SelectedEnemyPatrol));
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
            }
        }

        private EnemyRoute _currentEnemyRoute = new EnemyRoute();
        public EnemyRoute CurrentEnemyRoute
        {
            get => _currentEnemyRoute;
            set
            {
                _currentEnemyRoute = value;
                OnPropertyChanged(nameof(CurrentEnemyRoute));
            }
        }

        private ICommand _removeSelectedRouteCommand;
        public ICommand RemoveSelectedRouteCommand => _removeSelectedRouteCommand ?? (_removeSelectedRouteCommand = new RelayCommand(RemoveSelectedRoute, CanRemoveSelectedRoute));

        internal bool CanRemoveSelectedRoute() { return SelectedEnemyRoute != null; }

        internal void RemoveSelectedRoute()
        {
            SelectedEnemyPatrol.Routes.Remove(SelectedEnemyRoute);
            SelectedEnemyRoute = new EnemyRoute();
        }

        private ICommand _editSelectedRouteCommand;
        public ICommand EditSelectedRouteCommand => _editSelectedRouteCommand ?? (_editSelectedRouteCommand = new RelayCommand(EditSelectedRoute, CanRemoveSelectedRoute));

        internal void EditSelectedRoute()
        {
            CurrentEnemyRoute = SelectedEnemyRoute;
        }

        private ICommand _addRouteCommand;
        public ICommand AddRouteCommand => _addRouteCommand ?? (_addRouteCommand = new RelayCommand(AddRoute, () => !ReferenceEquals(SelectedEnemyRoute, CurrentEnemyRoute)));

        internal void AddRoute()
        {
            SelectedEnemyPatrol.Routes.Add(CurrentEnemyRoute);
            CurrentEnemyRoute = new EnemyRoute();
        }

        private ICommand _clearRouteCommand;
        public ICommand ClearRouteCommand => _clearRouteCommand ?? (_clearRouteCommand = new RelayCommand(ClearRoute));

        internal void ClearRoute()
        {
            CurrentEnemyRoute = new EnemyRoute();
        }
    }
}
