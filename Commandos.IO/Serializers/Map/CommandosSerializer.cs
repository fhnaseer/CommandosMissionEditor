using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.Model.Characters.Commandos;

namespace Commandos.IO.Serializers.Map
{
    public static class CommandosSerializer //: RecordSerializerBase<Commando>
    {
        public const string GreenBeretToken = "COMANDO";
        public const string SniperToken = "FRANCOTIRADOR";
        public const string MarineToken = "LANCHERO";
        public const string SapperToken = "ARTIFICIERO";
        public const string DriverToken = "CONDUCTOR";
        public const string SpyToken = "ESPIA";
        public const string NatashaToken = "NATACHA";
        public const string ThiefToken = "RATERO";
        public const string WilsonToken = "WILSON";
        public const string WhiskyToken = "WHISKY";

        public static Commando Serialize(MultipleRecords multipleRecords)
        {
            throw new System.NotImplementedException();
        }

        public static string GetMultipleRecordString(Commando input)
        {
            throw new System.NotImplementedException();
        }

        public static bool IsCommado(MultipleRecords multipleRecords)
        {
            var tokenId = multipleRecords.GetStringValue(StringConstants.TokenId);
            switch (tokenId)
            {
                case GreenBeretToken:
                case SniperToken:
                case MarineToken:
                case SapperToken:
                case DriverToken:
                case SpyToken:
                case NatashaToken:
                case ThiefToken:
                case WilsonToken:
                case WhiskyToken:
                    return true;
                default:
                    return false;
            }
        }
    }
}
