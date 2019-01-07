using System.Collections.Generic;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class PatrolsViewModel : MissionCollectionViewModelBase
    {
        public PatrolsViewModel(Mission mission) : base(mission)
        {
        }

        internal PatrolsViewModel() : base(null) { }

        public override string TabName => "Patrols";

        public override IList<MissionViewModelBase> GetViewModelCollection()
        {
            return new List<MissionViewModelBase>{
                new AddEnemyPatrolViewModel(Mission, Mission.World.Patrols),
                new AddEnemyRouteViewModel(Mission, CharacterType.EnemyPatrol, Mission.World.Patrols),
                new AddEnemyActionViewModel(Mission, CharacterType.EnemyPatrol, Mission.World.Patrols)
            };
        }
    }
}
