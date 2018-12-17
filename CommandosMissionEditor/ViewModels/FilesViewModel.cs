using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class FilesViewModel : MissionViewModelBase
    {
        public FilesViewModel(Mission mission) : base(mission)
        {
        }

        internal FilesViewModel() : base(null)
        {
        }

        public override string TabName => "Files";
    }
}
