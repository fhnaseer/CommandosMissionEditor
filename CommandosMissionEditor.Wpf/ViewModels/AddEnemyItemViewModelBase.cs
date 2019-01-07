using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public abstract class AddEnemyViewModelBase<T> : AddItemViewModelBase<T> where T : new()
    {
        private readonly CharacterType _characterType;

        public AddEnemyViewModelBase(Mission mission, CharacterType characterType, ObservableCollection<EnemyCharacter> enemyCharacters) : base(mission)
        {
            Enemies = enemyCharacters;
            _characterType = characterType;
        }

        internal AddEnemyViewModelBase() : base(null) { }

        public override string TabName => _characterType == CharacterType.Soldier ? "Soldiers" : "Patrols";

        public string CollectionName => _characterType == CharacterType.Soldier ? "Soldiers" : "Patrols";

        public bool IsPatrolMode => _characterType == CharacterType.EnemyPatrol;

        public bool IsSolderMode => _characterType == CharacterType.Soldier;

        public ObservableCollection<EnemyCharacter> Enemies { get; }
    }
}
