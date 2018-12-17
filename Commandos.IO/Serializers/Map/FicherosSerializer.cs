using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class FicherosSerializer
    {
        public static Ficheros GetFicheros(MultipleRecords multipleRecords)
        {
            return new Ficheros
            {
                FileName = multipleRecords.GetStringValue(StringConstants.FicherosStrFile)
            };
        }

        public static Record GetRecord(Ficheros ficheros)
        {
            var record = RecordExtensions.GetMultipleDataRecord(StringConstants.Ficheros);
            var fileRecord = RecordExtensions.GetSingleDataRecord(StringConstants.FicherosStrFile, ficheros.FileName);
            ((MultipleRecords)record.Data).Records.Add(StringConstants.FicherosStrFile, fileRecord);
            return record;
        }
    }
}
