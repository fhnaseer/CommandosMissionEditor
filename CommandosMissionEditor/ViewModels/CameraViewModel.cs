using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class CameraViewModel : MissionViewModelBase
    {
        public CameraViewModel(Mission mission) : base(mission)
        {
        }

        internal CameraViewModel() : base(null) { }

        public override string TabName => "Camera";
    }
}
