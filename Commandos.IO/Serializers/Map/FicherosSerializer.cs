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
    }
}
