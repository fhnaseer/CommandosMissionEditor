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
                new AddEnemySoldierViewModel(Mission),
                new AddEnemyRouteViewModel(Mission),
                new AddEnemyActionViewModel(Mission)
            };
        }
    }
}
