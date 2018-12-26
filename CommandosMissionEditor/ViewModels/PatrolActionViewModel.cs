using System.Windows.Input;
using Commandos.Model.Characters.Enemies.Actions;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class PatrolActionViewModel : MissionViewModelBase
    {
        public PatrolActionViewModel(Mission mission) : base(mission)
        {
        }

        internal PatrolActionViewModel() : base(null) { }

        public override string TabName => "Actions";

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
            SelectedEnemyRoute.Actions.Remove(SelectedEnemyAction);
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
            SelectedEnemyRoute.Actions.Add(CurrentEnemyAction);
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
