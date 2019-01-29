using System;
using Commandos.IO.Files;
using CommandosMissionEditor.Helpers;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class LoadMissionViewModel : LoadMissionViewModelBase
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

            if (file != null)
            {
                MissionFilePath = file.Path;
                var lines = await FileIO.ReadLinesAsync(file);
                Mission = MisFileSerializer.ReadMisFile(lines);
            }
        }
    }
}
