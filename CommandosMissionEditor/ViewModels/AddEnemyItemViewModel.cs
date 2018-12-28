using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddEnemyItemViewModel : AddEnemyViewModelBase<EnemyCharacter>
    {
        public AddEnemyItemViewModel(Mission mission, CharacterType characterType, ObservableCollection<EnemyCharacter> enemyCharacters) : base(mission, characterType, enemyCharacters)
        {
        }

        internal AddEnemyItemViewModel() : base(null, CharacterType.Soldier, null) { }

        public override ObservableCollection<EnemyCharacter> ItemCollection => Enemies;
    }
}
