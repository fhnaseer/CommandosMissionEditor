using System;
using System.Collections.ObjectModel;
using System.Windows;
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

        public override ObservableCollection<EnemyAction> ItemCollection => SelectedEnemyRoute?.Actions;

        public override void OnSelectedItemChanged()
        {
            OnPropertyChanged(nameof(IsMoveAction));
            OnPropertyChanged(nameof(IsRotateAction));
            OnPropertyChanged(nameof(IsPauseAction));
        }

        public Visibility IsMoveAction => SelectedItem is MoveAction ? Visibility.Visible : Visibility.Collapsed;
        public Visibility IsRotateAction => SelectedItem is RotateAction ? Visibility.Visible : Visibility.Collapsed;
        public Visibility IsPauseAction => SelectedItem is PauseAction ? Visibility.Visible : Visibility.Collapsed;

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

        private ObservableCollection<EnemyAction> _actionTypes;
        public ObservableCollection<EnemyAction> ActionTypes => _actionTypes ?? (_actionTypes = new ObservableCollection<EnemyAction>
        {
            new MoveAction(),
            new RotateAction(),
            new PauseAction(),
            new EnterDoorAction(),
            new LieDownAction(),
            new GetUpAction(),
            new KneelDownAction(),
            new DiveInAction(),
            new DiveOutAction()
        });

        private EnemyAction _selectedActionType;
        public EnemyAction SelectedActionType
        {
            get => _selectedActionType;
            set
            {
                _selectedActionType = value;
                OnPropertyChanged(nameof(SelectedActionType));
            }
        }

        internal override void AddItem()
        {
            var action = Activator.CreateInstance(SelectedActionType.GetType()) as EnemyAction;
            ItemCollection.Add(action);
            SelectedItem = action;
        }
    }
}
