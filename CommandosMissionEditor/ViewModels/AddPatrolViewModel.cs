using System.Collections.ObjectModel;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddPatrolViewModel : AddItemViewModelBase<EnemyPatrol>
    {
        public AddPatrolViewModel(Mission mission) : base(mission)
        {
        }

        internal AddPatrolViewModel() : base(null) { }

        public override string TabName => "Patrols";

        public override ObservableCollection<EnemyPatrol> ItemCollection => Mission.World.EnemyPatrols;
    }
}
