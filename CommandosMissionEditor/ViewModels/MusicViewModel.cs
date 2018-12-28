using System.Collections.ObjectModel;
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

        public override void LoadDefaultItem()
        {
            foreach (var item in ItemCollection)
                if (item.Environment == Mission.Music.StartingMusicEnvironment)
                    DefaultItem = item;
        }

        public override void UpdateDefaultItem()
        {
            Mission.Music.StartingMusicEnvironment = DefaultItem.Environment;
        }

        public override void ClearItem()
        {
            SelectedItem.MusicFileName = string.Empty;
            SelectedItem.Environment = string.Empty;
        }
    }
}
