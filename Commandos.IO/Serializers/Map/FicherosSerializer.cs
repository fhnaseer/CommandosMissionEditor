using Commandos.IO.Entities;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public class FicherosSerializer : RecordSerializerBase<Ficheros>
    {
        public const string Ficheros = ".FICHEROS";
        public const string FicherosStrFile = ".STR";

        public override string RecordName => Ficheros;

        public override Ficheros Serialize(MultipleRecords multipleRecords)
        {
            return new Ficheros
            {
                FileName = multipleRecords.GetStringValue(FicherosStrFile)
            };
        }

        public override string GetMultipleRecordString(Ficheros input) => $"[ {FicherosStrFile} {input.FileName} ]";
    }
}
