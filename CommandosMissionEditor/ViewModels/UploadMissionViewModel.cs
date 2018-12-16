using System.Windows.Input;
using Commandos.IO.Files;

namespace CommandosMissionEditor.ViewModels
{
    public class UploadMissionViewModel : ViewModelBase
    {
        private string _missionFilePath = @"D:\Code\TestFiles\5G1A.MIS";
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
            var mission = MisFileReader.ReadMisFile(MissionFilePath);
            var window = new MainWindow();
            window.Content = new MapViewModel(mission);
            window.Show();
        }
    }
}
