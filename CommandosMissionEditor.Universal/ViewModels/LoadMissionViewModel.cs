using System;
using System.Windows.Input;
using Commandos.IO.Files;
using CommandosMissionEditor.Universal.Helpers;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class LoadMissionViewModel : ViewModelBase
    {
        public LoadMissionViewModel()
        {
        }

        private string _missionFilePath;
        public string MissionFilePath
        {
            get => _missionFilePath;
            set => Set(ref _missionFilePath, value);
        }

        private ICommand _loadMissionCommand;
        public ICommand LoadMissionCommand => _loadMissionCommand ?? (_loadMissionCommand = new RelayCommand(LoadMission));

        internal async void LoadMission()
        {
            var openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            openPicker.FileTypeFilter.Add(".mis");
            StorageFile file = await openPicker.PickSingleFileAsync();
            MissionFilePath = file.Path;
            var lines = await FileIO.ReadLinesAsync(file);
            Mission = MisFileSerializer.ReadMisFile(lines);
        }
    }
}
