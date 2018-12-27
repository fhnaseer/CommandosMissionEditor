using System.Collections.ObjectModel;
using System.Windows.Input;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{

    public class MusicViewModel : AddItemViewModelBase<BackgroundMusic>
    {
        public MusicViewModel(Mission mission) : base(mission)
        {
        }

        internal MusicViewModel() : base(null)
        {
        }

        public override string TabName => "Music";

        public override ObservableCollection<BackgroundMusic> ItemCollection => Mission.Music.BackgroundMusics;

        private string _startingMusicEnvironment;
        public string StartingMusicEnvironment
        {
            get => _startingMusicEnvironment;
            set
            {
                _startingMusicEnvironment = value;
                OnPropertyChanged(nameof(StartingMusicEnvironment));
            }
        }
    }
}
