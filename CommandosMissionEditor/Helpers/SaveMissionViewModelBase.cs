using System.Windows.Input;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.Universal.Helpers
{
    public abstract class SaveMissionViewModelBase : ViewModelBase
    {
        public override string TabName => "Save Mission";

        private string _missionName;
        public string MissionName
        {
            get => _missionName;
            set => Set(ref _missionName, value);
        }

        private ICommand _saveMissionCommand;
        public ICommand SaveMissionCommand => _saveMissionCommand ?? (_saveMissionCommand = new RelayCommand(SaveMission));

        public abstract void SaveMission();
        //{
        //    var savePicker = new FileSavePicker();
        //    savePicker.SuggestedStartLocation = PickerLocationId.Downloads;
        //    savePicker.FileTypeChoices.Add("Commandos Mission File", new List<string>() { ".mis" });
        //    savePicker.SuggestedFileName = MissionName;
        //    var file = await savePicker.PickSaveFileAsync();
        //    if (file != null)
        //    {
        //        var lines = MisFileSerializer.GetMisFileText(Mission);
        //        await Windows.Storage.FileIO.WriteLinesAsync(file, lines);
        //    }
        //}
    }
}
