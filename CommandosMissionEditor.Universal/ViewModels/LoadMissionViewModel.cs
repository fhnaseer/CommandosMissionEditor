using System;
using System.Windows.Input;
using CommandosMissionEditor.Universal.Helpers;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class LoadMissionViewModel : Observable
    {
        public LoadMissionViewModel()
        {
        }

        private string _missionFilePath = @"D:\Code\TestFiles\TU01A.MIS";
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
            var text = await FileIO.ReadTextAsync(file);
        }
    }
}
