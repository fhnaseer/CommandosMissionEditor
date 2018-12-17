using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        private readonly Mission _mission;

        public MapViewModel(Mission mission)
        {
            _mission = mission;
        }

        internal MapViewModel() { }

        private List<MissionViewModelBase> _missionViewModels;
        public IList<MissionViewModelBase> MissionViewModels
        {
            get
            {
                return _missionViewModels ?? (_missionViewModels = new List<MissionViewModelBase>{
                    new FilesViewModel(_mission),
                    new MusicViewModel(_mission),
                    new CameraViewModel(_mission)
                });
            }
        }

        private MissionViewModelBase _selectedMissionViewModel;
        public MissionViewModelBase SelectedMissionViewModel
        {
            get => _selectedMissionViewModel ?? (_selectedMissionViewModel = MissionViewModels.FirstOrDefault());
            set
            {
                _selectedMissionViewModel = value;
                OnPropertyChanged(nameof(SelectedMissionViewModel));
            }
        }


        private ICommand _saveMissionCommand;
        public ICommand SaveMissionCommand => _saveMissionCommand ?? (_saveMissionCommand = new RelayCommand(SaveMission));

        internal void SaveMission()
        {

        }
    }
}
