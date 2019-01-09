using System.Collections.ObjectModel;
using Commandos.Model.Common;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class MusicViewModel : AddItemViewModelBase<BackgroundMusic>
    {
        public MusicViewModel()
        {
            LoadDefaultItem();
        }

        public override ObservableCollection<BackgroundMusic> ItemCollection => Mission.Music.BackgroundMusics;

        public override void LoadDefaultItem()
        {
            foreach (var item in ItemCollection)
                if (item.Environment == Mission.Music.StartingMusicEnvironment)
                    DefaultItem = item;
        }

        public override void OnDefaultItemChanged()
        {
            Mission.Music.StartingMusicEnvironment = DefaultItem.Environment;
        }
    }
}
