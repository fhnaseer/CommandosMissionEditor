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
                new AddPatrolViewModel(Mission),
                new AddPatrolRouteViewModel(Mission),
                new AddPatrolActionViewModel(Mission),
            };
        }
    }
}
