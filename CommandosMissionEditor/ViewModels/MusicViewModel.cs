﻿using System.Collections.ObjectModel;
using Commandos.Model.Common;
using Commandos.Model.Map;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.ViewModels
{
    public class MusicViewModel : AddItemViewModelBase<BackgroundMusic>
    {
        public MusicViewModel()
        {
            LoadDefaultItem();
        }

        public override string TabName => "Music";

        public override ObservableCollection<BackgroundMusic> ItemCollection => Mission?.Music.BackgroundMusics;

        public override void LoadDefaultItem()
        {
            if (ItemCollection is null) return;
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
