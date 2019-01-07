using System.Collections.Generic;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class SoldiersViewModel : MissionCollectionViewModelBase
    {
        public SoldiersViewModel(Mission mission) : base(mission)
        {
        }

        internal SoldiersViewModel() : base(null) { }

        public override string TabName => "Soldiers";

        public override IList<MissionViewModelBase> GetViewModelCollection()
        {
            return new List<MissionViewModelBase>{
                new AddEnemySoldierViewModel(Mission, Mission.World.MissionObjects.Soldiers),
                new AddEnemyRouteViewModel(Mission, CharacterType.Soldier, Mission.World.MissionObjects.Soldiers),
                new AddEnemyActionViewModel(Mission, CharacterType.Soldier, Mission.World.MissionObjects.Soldiers)
            };
        }
    }
}
