using Commandos.IO.Serializers.Files;
using CommandosMissionEditor.Helpers;

namespace CommandosMissionEditor.Wpf.ViewModels
{
    public class SaveMissionViewModel : SaveMissionViewModelBase
    {
        public override void SaveMission()
        {
            MisFileSerializer.WriteMisFile(MissionName, Mission);
        }
    }
}
