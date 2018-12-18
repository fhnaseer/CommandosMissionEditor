using Commandos.IO.Entities;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class BriefingSerializer
    {
        public const string Briefing = ".BRIEFING";
        public const string BriefingFile = ".INICIAL";

        public static Briefing GetBriefing(MultipleRecords multipleRecords)
        {
            return new Briefing
            {
                FileName = multipleRecords.GetStringValue(BriefingFile)
            };
        }

        public static Record GetRecord(Briefing briefing)
        {
            var record = RecordExtensions.GetMultipleDataRecord(Briefing);
            var fileRecord = RecordExtensions.GetSingleDataRecord(BriefingFile, briefing.FileName);
            ((MultipleRecords)record.Data).Records.Add(BriefingFile, fileRecord);
            return record;
        }
    }
}
