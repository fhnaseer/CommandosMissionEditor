using System.Collections.ObjectModel;
using Commandos.Model.Characters.Enemies;

namespace Commandos.Model.Map
{
    public class World
    {
        public string GscFileName { get; set; }

        public Administration Administration { get; set; }

        public MissionObjects MissionObjects { get; set; }

        private ObservableCollection<Soldier> _soldiers;
        public ObservableCollection<Soldier> Soldiers => _soldiers ?? (_soldiers = new ObservableCollection<Soldier>());

        private ObservableCollection<EnemyPatrol> _enemyPatrols;
#pragma warning disable CA2227 // Collection properties should be read only
        public ObservableCollection<EnemyPatrol> EnemyPatrols
#pragma warning restore CA2227 // Collection properties should be read only
        {
            get => _enemyPatrols ?? (_enemyPatrols = new ObservableCollection<EnemyPatrol>());
            set => _enemyPatrols = value;
        }

        public SpecialAreas SpecialAreas { get; set; }

        public SoundAreas SoundAreas { get; set; }
    }
}
