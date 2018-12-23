using Commandos.IO.Entities;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public class BriefingSerializer : RecordSerializerBase<Briefing>
    {
        public const string Briefing = ".BRIEFING";
        public const string BriefingFile = ".INICIAL";

        public override string RecordName => Briefing;

        public override Briefing Serialize(Record record)
        {
            var multipleRecords = record.GetMultipleRecords();
            return new Briefing
            {
                FileName = multipleRecords.GetStringValue(BriefingFile)
            };
        }

        public override string GetMultipleRecordString(Briefing briefing) => $"[ {BriefingFile} {briefing.FileName} ]";
    }
}
