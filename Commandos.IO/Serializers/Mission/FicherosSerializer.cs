using Commandos.IO.Entities;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Mission
{
    public static class FicherosSerializer
    {
        public static Ficheros GetFicheros(Record record)
        {
            var ficherosRecord = record.GetMultipleRecords();
            ficherosRecord.Records.TryGetValue(StringConstants.FicherosStrFile, out Record ficherosFile);
            return new Ficheros
            {
                FileName = ficherosFile?.GetStringValue()
            };
        }
    }
}
