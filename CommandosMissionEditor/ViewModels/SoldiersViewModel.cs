using System.Collections.Generic;
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
                new AddEnemyItemViewModel(Mission, Commandos.Model.Common.CharacterType.Soldier, Mission.World.Soldiers),
                new AddEnemyRouteViewModel(Mission, Commandos.Model.Common.CharacterType.Soldier, Mission.World.Soldiers),
                new AddEnemyActionViewModel(Mission, Commandos.Model.Common.CharacterType.Soldier, Mission.World.Soldiers)
            };
        }
    }
}
