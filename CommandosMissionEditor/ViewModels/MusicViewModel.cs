using System.Windows.Input;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace CommandosMissionEditor.ViewModels
{
    public class MusicViewModel : MissionViewModelBase
    {
        public MusicViewModel(Mission mission) : base(mission)
        {
        }

        internal MusicViewModel() : base(null)
        {
        }

        public override string TabName => "Music";


        private BackgroundMusic _selectedBackgroundMusic;
        public BackgroundMusic SelectedBackgroundMusic
        {
            get => _selectedBackgroundMusic;
            set
            {
                _selectedBackgroundMusic = value;
                OnPropertyChanged(nameof(SelectedBackgroundMusic));
            }
        }


        private string _musicFileName;
        public string MusicFileName
        {
            get => _musicFileName;
            set
            {
                _musicFileName = value;
                OnPropertyChanged(nameof(MusicFileName));
            }
        }


        private string _envirionment;
        public string Envirionment
        {
            get => _envirionment;
            set
            {
                _envirionment = value;
                OnPropertyChanged(nameof(Envirionment));
            }
        }

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

        private ICommand _addMusicCommand;
        public ICommand AddMusicCommand => _addMusicCommand ?? (_addMusicCommand = new RelayCommand(AddMusic, CanAddMusic));

        internal bool CanAddMusic() { return !string.IsNullOrWhiteSpace(MusicFileName) && !string.IsNullOrWhiteSpace(Envirionment); }

        internal void AddMusic()
        {
            Mission.Music.BackgroundMusics.Add(new BackgroundMusic { MusicFileName = MusicFileName, Environment = Envirionment });
            OnPropertyChanged(nameof(Mission.Music.BackgroundMusics));
        }


        private ICommand _removeMusicCommand;
        public ICommand RemoveMusicCommand => _removeMusicCommand ?? (_removeMusicCommand = new RelayCommand(RemoveMusic, CanRemoveMusic));

        internal bool CanRemoveMusic() { return SelectedBackgroundMusic != null; }

        internal void RemoveMusic()
        {
            Mission.Music.BackgroundMusics.Remove(SelectedBackgroundMusic);
            OnPropertyChanged(nameof(Mission.Music.BackgroundMusics));
            SelectedBackgroundMusic = null;
        }
    }
}
