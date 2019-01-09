using System;
using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.EnemyActions;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class AddActionViewModel : AddItemViewModelBase<EnemyAction>
    {
        public ObservableCollection<EnemyCharacter> Enemies => Mission.GetEnemies();

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
            set => Set(ref _selectedEnemy, value);
        }

        private EnemyRoute _selectedEnemyRoute;
        public EnemyRoute SelectedEnemyRoute
        {
            get => _selectedEnemyRoute;
            set
            {
                Set(ref _selectedEnemyRoute, value);
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
            set => Set(ref _selectedActionType, value);
        }

        internal override void AddItem()
        {
            var action = Activator.CreateInstance(SelectedActionType.GetType()) as EnemyAction;
            ItemCollection.Add(action);
            SelectedItem = action;
        }
    }
}
