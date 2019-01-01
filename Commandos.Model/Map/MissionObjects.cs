using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.Characters.Commandos;

namespace Commandos.Model.Map
{
    public class MissionObjects
    {
        private ObservableCollection<Commando> _commandos;
        public ObservableCollection<Commando> Commandos => _commandos ?? (_commandos = new ObservableCollection<Commando>());

        private ObservableCollection<EnemyCharacter> _soldiers;
        public ObservableCollection<EnemyCharacter> Soldiers => _soldiers ?? (_soldiers = new ObservableCollection<EnemyCharacter>());
    }
}
