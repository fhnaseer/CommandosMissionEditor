using System.Collections.ObjectModel;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddEnemyPatrolViewModel : AddItemViewModelBase<EnemyPatrol>
    {
        public AddEnemyPatrolViewModel(Mission mission) : base(mission)
        {
        }

        internal AddEnemyPatrolViewModel() : base(null) { }

        public override ObservableCollection<EnemyPatrol> ItemCollection => Mission.World.Patrols;

        public override string TabName => "Patrols";

        public string CollectionName { get; set; } = "Enemies";
    }
}
