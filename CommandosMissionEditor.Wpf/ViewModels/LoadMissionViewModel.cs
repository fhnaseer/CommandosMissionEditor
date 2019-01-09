using Commandos.IO.Files;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.ViewModels
{
    public class LoadMissionViewModel : LoadMissionViewModelBase
    {
        public override void LoadMission()
        {
            Mission = MisFileSerializer.ReadMisFile(MissionFilePath);
        }
    }
}
