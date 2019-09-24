using System.Windows.Input;

namespace CommandosMissionEditor.Helpers
{
    public abstract class SaveMissionViewModelBase : ViewModelBase
    {
        public override string TabName => "Save Mission";

        private string _missionName;
        public string MissionName
        {
            get => _missionName;
            set => Set(ref _missionName, value);
        }

        private ICommand _saveMissionCommand;
        public ICommand SaveMissionCommand => _saveMissionCommand ?? (_saveMissionCommand = new RelayCommand(SaveMission));

        public abstract void SaveMission();
    }
}
