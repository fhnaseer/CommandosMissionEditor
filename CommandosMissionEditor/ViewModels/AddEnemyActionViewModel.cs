using System;
using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.EnemyActions;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddEnemyActionViewModel : AddItemViewModelBase<EnemyAction>
    {
        public AddEnemyActionViewModel(Mission mission) : base(mission)
        {
        }

        internal AddEnemyActionViewModel() : base(null) { }

        public override string TabName => "Actions";

        public string CollectionName { get; set; } = "Enemies";


        public override ObservableCollection<EnemyAction> ItemCollection => SelectedEnemyRoute?.Actions;

        public override void OnSelectedItemChanged()
        {
            OnPropertyChanged(nameof(IsMoveAction));
            OnPropertyChanged(nameof(IsRotateAction));
            OnPropertyChanged(nameof(IsPauseAction));
        }

        public bool IsMoveAction => SelectedItem is MoveAction;
        public bool IsRotateAction => SelectedItem is RotateAction;
        public bool IsPauseAction => SelectedItem is PauseAction;

        private EnemyCharacter _selectedEnemy;
        public EnemyCharacter SelectedEnemy
        {
            get => _selectedEnemy;
            set
            {
                _selectedEnemy = value;
                OnPropertyChanged(nameof(SelectedEnemy));
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
