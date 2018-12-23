namespace Commandos.Model.Common
{
    public abstract class MissionObject
    {
        public string TokenId { get; set; }

        public Position Position { get; set; }

        public string Area { get; set; }
    }
}
