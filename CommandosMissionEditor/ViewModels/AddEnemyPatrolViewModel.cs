using System.Collections.ObjectModel;
using Commandos.Model.Characters.Enemies;
using Commandos.Model.Map;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.ViewModels
{
    public class AddEnemyPatrolViewModel : AddItemViewModelBase<EnemyPatrol>
    {
        public override string TabName => "Patrols";

        public override ObservableCollection<EnemyPatrol> ItemCollection => Mission.World.Patrols;
    }
}
