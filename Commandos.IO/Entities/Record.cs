using System.Globalization;

namespace Commandos.IO.Entities
{
    public class Record : RecordValueBase
    {
        public string Name { get; set; }

        public RecordValueBase Value { get; set; }

        public override string ToString() => $"{Name} {Value.ToString()}";
    }

    public static class RecordExtensions
    {
        public static MultipleRecords GetMultipleRecords(this Record record)
        {
            return (MultipleRecords)record.Value;
        }

        public static string GetStringValue(this Record record)
        {
            return ((SingleValue)record.Value).Value;
        }

        public static double GetDoubleValue(this Record record)
        {
            return double.Parse(((SingleValue)record.Value).Value, CultureInfo.CurrentCulture);
        }

        public static int GetIntegerValue(this Record record)
        {
            return int.Parse(((SingleValue)record.Value).Value, CultureInfo.CurrentCulture);
        }
    }
}
