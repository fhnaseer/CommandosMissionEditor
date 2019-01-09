using System.Collections.ObjectModel;
using Commandos.Model.Map;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class AddPatrolViewModel : AddItemViewModelBase<EnemyPatrol>
    {
        public override ObservableCollection<EnemyPatrol> ItemCollection => Mission.World.Patrols;
    }
}
