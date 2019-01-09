using System;
using Commandos.IO.Files;
using CommandosMissionEditor.ViewModels;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public abstract class LoadMissionViewModel : LoadMissionViewModelBase
    {
        public async override void LoadMission()
        {
            var openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            openPicker.FileTypeFilter.Add(".mis");
            var file = await openPicker.PickSingleFileAsync();
            MissionFilePath = file.Path;
            var lines = await FileIO.ReadLinesAsync(file);
            Mission = MisFileSerializer.ReadMisFile(lines);
        }
    }
}
