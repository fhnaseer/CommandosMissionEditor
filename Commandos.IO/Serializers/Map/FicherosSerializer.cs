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
            var record = new Record(StringConstants.Ficheros);
            var recordValue = new MultipleRecords();
            var briefingFileRecord = new Record(StringConstants.FicherosStrFile);
            briefingFileRecord.Value = new SingleValue(ficheros.FileName);
            recordValue.Records.Add(StringConstants.FicherosStrFile, briefingFileRecord);
            record.Value = recordValue;
            return record;
        }
    }
}
