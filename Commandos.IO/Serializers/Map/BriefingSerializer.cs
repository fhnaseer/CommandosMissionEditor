using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class BriefingSerializer
    {
        public static Briefing GetBriefing(MultipleRecords multipleRecords)
        {
            return new Briefing
            {
                FileName = multipleRecords.GetStringValue(StringConstants.BriefingFile)
            };
        }

        public static Record GetRecord(Briefing briefing)
        {
            var record = RecordExtensions.GetMultipleDataRecord(StringConstants.Briefing);
            var fileRecord = RecordExtensions.GetSingleDataRecord(StringConstants.BriefingFile, briefing.FileName);
            ((MultipleRecords)record.Data).Records.Add(StringConstants.BriefingFile, fileRecord);
            return record;
        }
    }
}
