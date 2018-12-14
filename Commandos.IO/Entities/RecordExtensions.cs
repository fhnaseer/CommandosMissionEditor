using System.Globalization;

namespace Commandos.IO.Entities
{
    internal static class RecordExtensions
    {
        public static MultipleRecords GetMultipleRecord(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record.Value as MultipleRecords;
            return null;
        }

        public static Record GetRecord(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record;
            return null;
        }

        public static MixedValues GetMixedValues(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record.Value as MixedValues;
            return null;
        }

        public static MixedValues GetMixedValues(this MixedValues mixedValues, int indexNumber)
        {
            var values = mixedValues.Values;
            return ((MixedValues)values[indexNumber]);
        }

        public static string GetStringValue(this MixedValues mixedValues, int indexNumber)
        {
            var values = mixedValues.Values;
            return ((SingleValue)values[indexNumber]).Value;
        }

        public static double GetDoubleValue(this MixedValues mixedValues, int indexNumber)
        {
            return double.Parse(mixedValues.GetStringValue(indexNumber), CultureInfo.CurrentCulture);
        }

        public static int GetIntegerValue(this MixedValues mixedValues, int indexNumber)
        {
            return int.Parse(mixedValues.GetStringValue(indexNumber), CultureInfo.CurrentCulture);
        }

        public static string GetStringValue(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record.GetStringValue();
            return null;
        }

        public static double GetDoubleValue(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record.GetDoubleValue();
            return 0;
        }

        public static int GetIntegerValue(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record.GetIntegerValue();
            return 0;
        }

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
