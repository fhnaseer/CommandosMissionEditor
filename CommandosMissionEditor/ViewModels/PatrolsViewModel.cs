using System.Collections.Generic;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class PatrolsViewModel : MissionViewModelBase
    {
        public PatrolsViewModel(Mission mission) : base(mission)
        {
        }

        internal PatrolsViewModel() : base(null) { }

        public override string TabName => "Patrols";

        private List<MissionViewModelBase> _patrolsViewModels;
        public IList<MissionViewModelBase> PatrolsViewModels
        {
            get
            {
                return _patrolsViewModels ?? (_patrolsViewModels = new List<MissionViewModelBase>{
                    new AddPatrolViewModel(Mission),
                    new AddPatrolRouteViewModel(Mission),
                    new AddPatrolActionViewModel(Mission),
                });
            }
        }
    }
}
