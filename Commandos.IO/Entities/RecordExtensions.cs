using System.Globalization;

namespace Commandos.IO.Entities
{
    internal static class RecordExtensions
    {
        public static MultipleRecords GetMultipleRecord(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record.Data as MultipleRecords;
            return null;
        }

        public static Record GetRecord(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record;
            return null;
        }

        public static MixedDataRecord GetMixedDataRecord(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record.Data as MixedDataRecord;
            return null;
        }

        public static MixedDataRecord GetMixedDataRecord(this MixedDataRecord mixedDataRecord, int indexNumber)
        {
            var values = mixedDataRecord.Data;
            return ((MixedDataRecord)values[indexNumber]);
        }

        public static string GetStringValue(this MixedDataRecord mixedDataRecord, int indexNumber)
        {
            var values = mixedDataRecord.Data;
            return ((SingleDataRecord)values[indexNumber]).Data;
        }

        public static double GetDoubleValue(this MixedDataRecord mixedDataRecord, int indexNumber)
        {
            return double.Parse(mixedDataRecord.GetStringValue(indexNumber), CultureInfo.CurrentCulture);
        }

        public static int GetIntegerValue(this MixedDataRecord mixedDataRecord, int indexNumber)
        {
            return int.Parse(mixedDataRecord.GetStringValue(indexNumber), CultureInfo.CurrentCulture);
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
            return (MultipleRecords)record.Data;
        }

        public static string GetStringValue(this Record record)
        {
            return ((SingleDataRecord)record.Data).Data;
        }

        public static double GetDoubleValue(this Record record)
        {
            return double.Parse(((SingleDataRecord)record.Data).Data, CultureInfo.CurrentCulture);
        }

        public static int GetIntegerValue(this Record record)
        {
            return int.Parse(((SingleDataRecord)record.Data).Data, CultureInfo.CurrentCulture);
        }
    }
}
