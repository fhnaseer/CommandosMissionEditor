using System.Collections.Generic;
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
                new AddEnemyItemViewModel(Mission, Commandos.Model.Common.CharacterType.EnemyPatrol, Mission.World.Patrols),
                new AddEnemyRouteViewModel(Mission, Commandos.Model.Common.CharacterType.EnemyPatrol, Mission.World.Patrols),
                new AddEnemyActionViewModel(Mission, Commandos.Model.Common.CharacterType.EnemyPatrol, Mission.World.Patrols)
            };
        }
    }
}
