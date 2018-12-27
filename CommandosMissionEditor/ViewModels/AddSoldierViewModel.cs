using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class AddSoldierViewModel : MissionViewModelBase
    {
        public AddSoldierViewModel(Mission mission) : base(mission)
        {
        }

        internal AddSoldierViewModel() : base(null) { }

        public override string TabName => "Soldiers";
    }
}
