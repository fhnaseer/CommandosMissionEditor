using Commandos.IO.Files;
using CommandosMissionEditor.Universal.Helpers;

namespace CommandosMissionEditor.ViewModels
{
    public class SaveMissionViewModel : SaveMissionViewModelBase
    {
        public override void SaveMission()
        {
            MisFileSerializer.WriteMisFile(MissionName, Mission);
        }
    }
}
