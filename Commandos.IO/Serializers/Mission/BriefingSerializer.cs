using Commandos.IO.Entities;
using Commandos.IO.Files;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Mission
{
    public static class BriefingSerializer
    {
        public static Briefing GetBriefing(Record record)
        {
            var briefingRecord = record.GetMultipleRecords();
            briefingRecord.Records.TryGetValue(StringConstants.BriefingFile, out Record briefingFile);
            return new Briefing
            {
                FileName = briefingFile?.GetStringValue()
            };
        }
    }
}
