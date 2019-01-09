using System;
using System.Collections.Generic;
using Commandos.IO.Files;
using CommandosMissionEditor.Universal.Helpers;
using Windows.Storage.Pickers;

namespace CommandosMissionEditor.Universal.ViewModels
{
    public class SaveMissionViewModel : SaveMissionViewModelBase
    {
        public async override void SaveMission()
        {
            var savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.Downloads;
            savePicker.FileTypeChoices.Add("Commandos Mission File", new List<string>() { ".mis" });
            savePicker.SuggestedFileName = MissionName;
            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                var lines = MisFileSerializer.GetMisFileText(Mission);
                await Windows.Storage.FileIO.WriteLinesAsync(file, lines);
            }
        }
    }
}
