using System;
using System.Collections.ObjectModel;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Helpers;
using Commandos.Model.Characters.Commandos;

namespace Commandos.IO.Serializers.Map
{
    public static class CommandosSerializer
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

        public static Commando Serialize(MultipleRecords multipleRecords)
        {
            var commando = GetCommando(multipleRecords);
            if (commando == null) return null;
            SerializerHelper.PopulateCharacter(commando, multipleRecords);

            return commando;
        }

        public static string GetMultipleRecordString(Commando input)
        {
            throw new NotImplementedException();
        }

        private static Commando GetCommando(MultipleRecords multipleRecords)
        {
            var tokenId = multipleRecords.GetStringValue(StringConstants.TokenId);
            switch (tokenId)
            {
                case GreenBeretToken:
                    return new GreenBeret();
                case SniperToken:
                    return new Sniper();
                case MarineToken:
                    return new Marine();
                case SapperToken:
                    return new Sapper();
                case DriverToken:
                    return new Driver();
                case SpyToken:
                    return new Spy();
                case NatashaToken:
                    return new Natasha();
                case ThiefToken:
                    return new Thief();
                case WilsonToken:
                    return new Wilson();
                case WhiskyToken:
                    return new Whisky();
                default:
                    return null;
            }
        }

        internal static object GetCommandosRecordString(ObservableCollection<Commando> soldiers)
        {
            throw new NotImplementedException();
        }
    }
}
