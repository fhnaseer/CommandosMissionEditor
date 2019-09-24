using Commandos.IO.Serializers.Files;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.Wpf.ViewModels
{
    public class LoadMissionViewModel : LoadMissionViewModelBase
    {
        public override void LoadMission()
        {
            Mission = MisFileSerializer.ReadMisFile(MissionFilePath);
        }
    }
}
