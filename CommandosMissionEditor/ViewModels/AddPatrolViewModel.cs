using System.Windows.Input;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddPatrolViewModel : MissionViewModelBase
    {
        public AddPatrolViewModel(Mission mission) : base(mission)
        {
        }

        internal AddPatrolViewModel() : base(null) { }

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
        public ICommand AddPatrolCommand => _addPatrolCommand ?? (_addPatrolCommand = new RelayCommand(AddPatrol, () => !ReferenceEquals(SelectedEnemyPatrol, CurrentEnemyPatrol)));

        internal void AddPatrol()
        {
            Mission.World.EnemyPatrols.Add(CurrentEnemyPatrol);
            CurrentEnemyPatrol = new EnemyPatrol();
        }

        private ICommand _clearPatrolCommand;
        public ICommand ClearPatrolCommand => _clearPatrolCommand ?? (_clearPatrolCommand = new RelayCommand(ClearPatrol));

        internal void ClearPatrol()
        {
            CurrentEnemyPatrol = new EnemyPatrol();
        }
    }
}
