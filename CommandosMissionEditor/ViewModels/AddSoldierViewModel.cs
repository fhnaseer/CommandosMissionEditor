using System.Collections.ObjectModel;
using Commandos.Model.Characters;
using Commandos.Model.Characters.Enemies;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddSoldierViewModel : AddEnemyViewModelBase<EnemyCharacter>
    {
        public AddSoldierViewModel(Mission mission, CharacterType characterType, ObservableCollection<EnemyCharacter> enemyCharacters) : base(mission, characterType, enemyCharacters)
        {
            PopulateSoldierTypes();
        }

        internal AddSoldierViewModel() : base(null, CharacterType.Soldier, null) { }

        public override ObservableCollection<EnemyCharacter> ItemCollection => Enemies;

        private ObservableCollection<EnemyCategory> _soldierCategories;
        public ObservableCollection<EnemyCategory> SoldierCategories => _soldierCategories ?? (_soldierCategories = new ObservableCollection<EnemyCategory>
        {
            EnemyCategory.Worker,
            EnemyCategory.Gunman,
            EnemyCategory.Rifleman,
            EnemyCategory.SubMachineGunner
        });

        private EnemyCategory _selectedSoldierCategory;
        public EnemyCategory SelectedSoldierCategory
        {
            get => _selectedSoldierCategory;
            set
            {
                _selectedSoldierCategory = value;
                PopulateSoldierTypes();
                OnPropertyChanged(nameof(SelectedSoldierCategory));
            }
        }

        private void PopulateSoldierTypes()
        {
            SoldierTypes.Clear();
            if (SelectedSoldierCategory == EnemyCategory.Worker)
            {
                SoldierTypes.Add(new BlueMechanicGerman());
                SoldierTypes.Add(new BlueSoldierGerman());
                SoldierTypes.Add(new MechanicGerman());
                SoldierTypes.Add(new UnderwearSoldierGerman());
                SoldierTypes.Add(new TowelSoldierGerman());
                SoldierTypes.Add(new WorkerGerman());
                SoldierTypes.Add(new AtomicWorkerJapanese());
                SoldierTypes.Add(new JailerJapanese());
                SoldierTypes.Add(new MechanicJapanese());
                SoldierTypes.Add(new UnderwearSoldierJapanese());
                SoldierTypes.Add(new TowelSoldierJapanese());
                SoldierTypes.Add(new WorkerJapanese());
                SoldierTypes.Add(new BigHatWorkerBlackJapanese());
                SoldierTypes.Add(new BigHatWorkerGreenJapanese());
                SoldierTypes.Add(new BigHatWorkerWhiteJapanese());
            }
            else if (SelectedSoldierCategory == EnemyCategory.Gunman)
            {
                SoldierTypes.Add(new OfficerAssistantGerman());
                SoldierTypes.Add(new GunSoldier1German());
                SoldierTypes.Add(new GunSoldier2German());
                SoldierTypes.Add(new GunSoldier3German());
                SoldierTypes.Add(new GunSoldier4German());
                SoldierTypes.Add(new GunSoldierTorchGerman());
                SoldierTypes.Add(new JailerGerman());
                SoldierTypes.Add(new SniperGunGerman());
                SoldierTypes.Add(new CannonierJapanese());
                SoldierTypes.Add(new GunSoldierJapanese());
                SoldierTypes.Add(new GunSoldierBackpackJapanese());
                SoldierTypes.Add(new JailerGunJapanese());
                SoldierTypes.Add(new PilotJapanese());
                SoldierTypes.Add(new SailorBlueJapanese());
                SoldierTypes.Add(new SailorWhiteJapanese());
                SoldierTypes.Add(new ScoutJapanese());
                SoldierTypes.Add(new TorturerJapanese());
            }
            else if (SelectedSoldierCategory == EnemyCategory.Rifleman)
            {
                SoldierTypes.Add(new Rifleman1German());
                SoldierTypes.Add(new Rifleman2German());
                SoldierTypes.Add(new Rifleman3German());
                SoldierTypes.Add(new Rifleman4German());
                SoldierTypes.Add(new RiflemanArcticGerman());
                SoldierTypes.Add(new RiflemanJapanese());
                SoldierTypes.Add(new RiflemanBackpackJapanese());
            }
            else if (SelectedSoldierCategory == EnemyCategory.SubMachineGunner)
            {
                SoldierTypes.Add(new SubmachineGunnerGerman());
                SoldierTypes.Add(new SubmachineGunnerArcticGerman());
            }
        }

        private ObservableCollection<EnemySoldier> _soldierTypes;
        public ObservableCollection<EnemySoldier> SoldierTypes => _soldierTypes ?? (_soldierTypes = new ObservableCollection<EnemySoldier>());

        private EnemySoldier _selectedSoldierType;
        public EnemySoldier SelectedSoldierType
        {
            get => _selectedSoldierType;
            set
            {
                _selectedSoldierType = value;
                OnPropertyChanged(nameof(SelectedSoldierType));
            }
        }
    }
}
