using System.Collections.Generic;
using System.Windows.Input;
using Commandos.IO.Files;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class EditMissionViewModel : MissionCollectionViewModelBase
    {
        public EditMissionViewModel(Mission mission) : base(mission) { }

        internal EditMissionViewModel() : base(null) { }

        public override string TabName => "Mission";

        public override IList<MissionViewModelBase> GetViewModelCollection()
        {
            return new List<MissionViewModelBase>{
                new FilesViewModel(Mission),
                new MusicViewModel(Mission),
                new CameraViewModel(Mission),
                new CommandosViewModel(Mission),
                new PatrolsViewModel(Mission),
                new SoldiersViewModel(Mission)
            };
        }

        private string _saveFilePath = "D:/Test.mis";
        public string SaveFilePath
        {
            get => _saveFilePath;
            set
            {
                _saveFilePath = value;
                OnPropertyChanged(nameof(SaveFilePath));
            }
        }

        private ICommand _saveMissionCommand;
        public ICommand SaveMissionCommand => _saveMissionCommand ?? (_saveMissionCommand = new RelayCommand(SaveMission));

        internal void SaveMission()
        {
            MisFileSerializer.WriteMisFile(SaveFilePath, Mission);
        }
    }
}
