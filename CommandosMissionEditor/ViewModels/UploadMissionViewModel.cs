using System.Windows.Input;
using Commandos.IO.Files;

namespace CommandosMissionEditor.ViewModels
{
    public class UploadMissionViewModel : ViewModelBase
    {
        private string _missionFilePath = @"D:\Code\TestFiles\TU01A.MIS";
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
            var mission = MisFileSerializer.ReadMisFile(MissionFilePath);
            var window = new MainWindow();
            window.Content = new EditMissionViewModel(mission);
            window.Show();
        }
    }
}
