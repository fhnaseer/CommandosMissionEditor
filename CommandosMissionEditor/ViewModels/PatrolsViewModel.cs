using System.Windows.Input;
using Commandos.Model.Characters.Enemies.Actions;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class PatrolsViewModel : MissionViewModelBase
    {
        public PatrolsViewModel(Mission mission) : base(mission)
        {
        }

        internal PatrolsViewModel() : base(null) { }

        public override string TabName => "Patrols";

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

        private EnemyPatrol _currentEnemyPatrol = new EnemyPatrol();
        public EnemyPatrol CurrentEnemyPatrol
        {
            get => _currentEnemyPatrol;
            set
            {
                _currentEnemyPatrol = value;
                OnPropertyChanged(nameof(CurrentEnemyPatrol));
            }
        }

        private ICommand _removeSelectedPatrolCommand;
        public ICommand RemoveSelectedPatrolCommand => _removeSelectedPatrolCommand ?? (_removeSelectedPatrolCommand = new RelayCommand(RemoveSelectedPatrol, CanRemoveSelectedPatrol));

        internal bool CanRemoveSelectedPatrol() { return SelectedEnemyPatrol != null; }

        internal void RemoveSelectedPatrol()
        {
            Mission.World.EnemyPatrols.Remove(SelectedEnemyPatrol);
            SelectedEnemyPatrol = null;
        }

        private ICommand _editSelectedPatrolCommand;
        public ICommand EditSelectedPatrolCommand => _editSelectedPatrolCommand ?? (_editSelectedPatrolCommand = new RelayCommand(EditSelectedPatrol, CanRemoveSelectedPatrol));

        internal void EditSelectedPatrol()
        {
            CurrentEnemyPatrol = SelectedEnemyPatrol;
        }

        private ICommand _addPatrolCommand;
        public ICommand AddPatrolCommand => _addPatrolCommand ?? (_addPatrolCommand = new RelayCommand(AddPatrol));

        internal void AddPatrol()
        {
            Mission.World.EnemyPatrols.Add(CurrentEnemyPatrol);
            CurrentEnemyPatrol = new EnemyPatrol();
            CurrentEnemyRoute = new EnemyRoute();
            SelectedEnemyAction = null;
        }

        private ICommand _clearPatrolCommand;
        public ICommand ClearPatrolCommand => _clearPatrolCommand ?? (_clearPatrolCommand = new RelayCommand(ClearPatrol));

        internal void ClearPatrol()
        {
            CurrentEnemyPatrol = new EnemyPatrol();
            CurrentEnemyRoute = new EnemyRoute();
            SelectedEnemyAction = null;
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
            CurrentEnemyPatrol.Routes.Remove(SelectedEnemyRoute);
            SelectedEnemyRoute = new EnemyRoute();
            SelectedEnemyAction = null;
        }

        private ICommand _editSelectedRouteCommand;
        public ICommand EditSelectedRouteCommand => _editSelectedRouteCommand ?? (_editSelectedRouteCommand = new RelayCommand(EditSelectedRoute, CanRemoveSelectedRoute));

        internal void EditSelectedRoute()
        {
            CurrentEnemyRoute = SelectedEnemyRoute;
            SelectedEnemyAction = null;
        }

        private ICommand _addRouteCommand;
        public ICommand AddRouteCommand => _addRouteCommand ?? (_addRouteCommand = new RelayCommand(AddRoute));

        internal void AddRoute()
        {
            CurrentEnemyPatrol.Routes.Add(CurrentEnemyRoute);
            CurrentEnemyRoute = new EnemyRoute();
            CurrentEnemyRoute = null;
        }

        private ICommand _clearRouteCommand;
        public ICommand ClearRouteCommand => _clearRouteCommand ?? (_clearRouteCommand = new RelayCommand(ClearRoute));

        internal void ClearRoute()
        {
            CurrentEnemyRoute = new EnemyRoute();
        }

        private EnemyAction _selectedEnemyAction;
        public EnemyAction SelectedEnemyAction
        {
            get => _selectedEnemyAction;
            set
            {
                _selectedEnemyAction = value;
                OnPropertyChanged(nameof(SelectedEnemyAction));
            }
        }

        private EnemyAction _currentEnemyAction;// = new EnemyAction();
        public EnemyAction CurrentEnemyAction
        {
            get => _currentEnemyAction;
            set
            {
                _currentEnemyAction = value;
                OnPropertyChanged(nameof(CurrentEnemyAction));
            }
        }

        private ICommand _removeSelectedActionCommand;
        public ICommand RemoveSelectedActionCommand => _removeSelectedActionCommand ?? (_removeSelectedActionCommand = new RelayCommand(RemoveSelectedAction, CanRemoveSelectedAction));

        internal bool CanRemoveSelectedAction() { return SelectedEnemyAction != null; }

        internal void RemoveSelectedAction()
        {
            CurrentEnemyRoute.Actions.Remove(SelectedEnemyAction);
            SelectedEnemyAction = null;
        }

        private ICommand _editSelectedActionCommand;
        public ICommand EditSelectedActionCommand => _editSelectedActionCommand ?? (_editSelectedActionCommand = new RelayCommand(EditSelectedAction, CanRemoveSelectedAction));

        internal void EditSelectedAction()
        {
            CurrentEnemyAction = SelectedEnemyAction;
        }

        private ICommand _addActionCommand;
        public ICommand AddActionCommand => _addActionCommand ?? (_addActionCommand = new RelayCommand(AddAction));

        internal void AddAction()
        {
            CurrentEnemyRoute.Actions.Add(CurrentEnemyAction);
            SelectedEnemyAction = null;
        }

        private ICommand _clearActionCommand;
        public ICommand ClearActionCommand => _clearActionCommand ?? (_clearActionCommand = new RelayCommand(ClearAction));

        internal void ClearAction()
        {
            //CurrentEnemyAction = new EnemyAction();
        }
    }
}
