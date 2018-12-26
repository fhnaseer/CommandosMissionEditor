using System.Collections.Generic;
using System.Windows.Input;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class EditMissionViewModel : ViewModelBase
    {
        private readonly Mission _mission;

        public EditMissionViewModel(Mission mission)
        {
            _mission = mission;
        }

        internal EditMissionViewModel() { }

        private List<MissionViewModelBase> _missionViewModels;
        public IList<MissionViewModelBase> MissionViewModels
        {
            get
            {
                return _missionViewModels ?? (_missionViewModels = new List<MissionViewModelBase>{
                    new FilesViewModel(_mission),
                    new MusicViewModel(_mission),
                    new CameraViewModel(_mission),
                    new PatrolsViewModel(_mission)
                });
            }
        }

        private ICommand _saveMissionCommand;
        public ICommand SaveMissionCommand => _saveMissionCommand ?? (_saveMissionCommand = new RelayCommand(SaveMission));

        internal void SaveMission()
        {

        }
    }
}
