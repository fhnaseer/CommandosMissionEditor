using Commandos.IO.Entities;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class FicherosSerializer
    {
        public const string Ficheros = ".FICHEROS";
        public const string FicherosStrFile = ".STR";

        public static Ficheros GetFicheros(MultipleRecords multipleRecords)
        {
            return new Ficheros
            {
                FileName = multipleRecords.GetStringValue(FicherosStrFile)
            };
        }

        public static Record GetRecord(Ficheros ficheros)
        {
            var record = RecordExtensions.GetMultipleDataRecord(Ficheros);
            var fileRecord = RecordExtensions.GetSingleDataRecord(FicherosStrFile, ficheros.FileName);
            ((MultipleRecords)record.Data).Records.Add(FicherosStrFile, fileRecord);
            return record;
        }
    }
}
