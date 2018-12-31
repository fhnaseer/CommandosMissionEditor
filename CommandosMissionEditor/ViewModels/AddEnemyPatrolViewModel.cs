using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddEnemyPatrolViewModel : AddEnemyViewModelBase<EnemyCharacter>
    {
        public AddEnemyPatrolViewModel(Mission mission, ObservableCollection<EnemyCharacter> enemyCharacters) : base(mission, CharacterType.EnemyPatrol, enemyCharacters)
        {
        }

        internal AddEnemyPatrolViewModel() : base(null, CharacterType.EnemyPatrol, null) { }

        public override ObservableCollection<EnemyCharacter> ItemCollection => Enemies;
    }
}
