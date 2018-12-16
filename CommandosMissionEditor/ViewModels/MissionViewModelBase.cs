using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public abstract class MissionViewModelBase : ViewModelBase
    {
        public MissionViewModelBase(Mission mission)
        {
            Mission = mission;
        }

        public Mission Mission { get; private set; }

        public abstract string TabName { get; }
    }
}
