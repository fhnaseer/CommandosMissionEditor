using Commandos.Model.Map;

namespace Commandos.IO.Serializers
{
    public static class MissionSerializer
    {
        public static Mission ToMission(string[] tokens)
        {
            var mission = new Mission();
            mission.Camera = CameraSerializer.ToCamera(tokens, 0);
            mission.MsbFileName = EntitySerializer.ToStringValue(tokens, StringConstants.MsbFile, 0);
            return mission;
        }
    }
}
