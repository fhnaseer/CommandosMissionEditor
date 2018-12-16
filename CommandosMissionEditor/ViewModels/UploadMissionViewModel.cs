using System.Windows.Input;

namespace CommandosMissionEditor.ViewModels
{
    public class UploadMissionViewModel : ViewModelBase
    {
        private string _missionFilePath;
        public string MissionFilePath
        {
            get => _missionFilePath;
            set
            {
                _missionFilePath = value;
                OnPropertyChanged(nameof(MissionFilePath));
            }
        }

        private ICommand _loadMissionCommand;
        public ICommand LoadMissionCommand => _loadMissionCommand ?? (_loadMissionCommand = new RelayCommand(LoadMission));

        internal void LoadMission()
        {
        }
    }
}
