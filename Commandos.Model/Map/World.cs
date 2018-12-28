using System.Collections.ObjectModel;
using Commandos.Model.Characters;

namespace Commandos.Model.Map
{
    public class World
    {
        public string GscFileName { get; set; }

        public Administration Administration { get; set; }

        public MissionObjects MissionObjects { get; set; }

        private ObservableCollection<EnemyCharacter> _soldiers;
        public ObservableCollection<EnemyCharacter> Soldiers => _soldiers ?? (_soldiers = new ObservableCollection<EnemyCharacter>());

        private ObservableCollection<EnemyCharacter> _patrols;
        public ObservableCollection<EnemyCharacter> Patrols => _patrols ?? (_patrols = new ObservableCollection<EnemyCharacter>());

        public SpecialAreas SpecialAreas { get; set; }

        public SoundAreas SoundAreas { get; set; }
    }
}
