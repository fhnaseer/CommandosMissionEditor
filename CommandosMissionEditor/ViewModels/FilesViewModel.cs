using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class FilesViewModel : MissionViewModelBase
    {
        public FilesViewModel(Mission mission) : base(mission)
        {
        }

        public override string TabName => "Files";
    }
}
