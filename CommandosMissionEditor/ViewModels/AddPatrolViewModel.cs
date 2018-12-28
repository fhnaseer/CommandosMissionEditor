using System.Collections.ObjectModel;
using Commandos.Model.Common;
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

        public override void ClearItem()
        {
            SelectedItem.TokenId = string.Empty;
            SelectedItem.Position = new Position();
            SelectedItem.Area = string.Empty;
            SelectedItem.Angle = string.Empty;
            SelectedItem.ColumnsCount = string.Empty;
            SelectedItem.RowsCount = string.Empty;
            SelectedItem.SoldiersFileName = string.Empty;
            SelectedItem.LeaderFileName = string.Empty;
        }
    }
}
