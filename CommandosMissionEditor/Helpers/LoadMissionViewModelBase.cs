using System.Windows.Input;

namespace CommandosMissionEditor.Helpers
{
    public abstract class LoadMissionViewModelBase : ViewModelBase
    {
        public override string TabName => "Load Mission";

        private string _missionFilePath = @"D:\Code\TestFiles\TU01A.MIS";
        public string MissionFilePath
        {
            get => _missionFilePath;
            set => Set(ref _missionFilePath, value);
        }

        private ICommand _loadMissionCommand;
        public ICommand LoadMissionCommand => _loadMissionCommand ?? (_loadMissionCommand = new RelayCommand(LoadMission));

        public abstract void LoadMission();
    }
}
