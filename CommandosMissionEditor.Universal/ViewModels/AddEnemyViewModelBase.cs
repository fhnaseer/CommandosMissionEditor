//using System.Collections.ObjectModel;
//using Commandos.Model.Characters;
//using Commandos.Model.Common;

//namespace CommandosMissionEditor.Universal.ViewModels
//{
//    public abstract class AddEnemyViewModelBase<T> : AddItemViewModelBase<T> where T : new()
//    {
//        private readonly CharacterType _characterType;

//        public AddEnemyViewModelBase(CharacterType characterType)
//        {
//            _characterType = characterType;
//        }

//        internal AddEnemyViewModelBase() { }

//        //public override string TabName => _characterType == CharacterType.Soldier ? "Soldiers" : "Patrols";

//        public string CollectionName => _characterType == CharacterType.Soldier ? "Soldiers" : "Patrols";

//        public bool IsPatrolMode => _characterType == CharacterType.EnemyPatrol;

//        public bool IsSolderMode => _characterType == CharacterType.Soldier;

//        public abstract ObservableCollection<EnemyCharacter> Enemies { get; }
//    }
//}
