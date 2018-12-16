using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class MusicViewModel : MissionViewModelBase
    {
        public MusicViewModel(Mission mission) : base(mission)
        {
        }

        public override string TabName => "Music";
    }
}
