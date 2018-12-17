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
            var record = new Record(StringConstants.Briefing);
            var recordValue = new MultipleRecords();
            var briefingFileRecord = new Record(StringConstants.BriefingFile);
            briefingFileRecord.Value = new SingleValue(briefing.FileName);
            recordValue.Records.Add(StringConstants.BriefingFile, briefingFileRecord);
            record.Value = recordValue;
            return record;
        }
    }
}
