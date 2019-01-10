using System.Collections.Generic;

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

        public static MixedDataRecord GetMixedDataRecordTemp(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record.Data as MixedDataRecord;
            return null;
        }

        public static Record GetRecord(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record;
            return null;
        }

        public static IList<RecordData> GetMixedDataRecord(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return ((MixedDataRecord)record.Data).Records;
            return null;
        }

        public static MultipleRecords GetMultipleRecords(this MixedDataRecord mixedDataRecord, int indexNumber)
        {
            var values = mixedDataRecord.Records;
            return (MultipleRecords)values[indexNumber];
        }

        public static MixedDataRecord GetMixedDataRecord(this MixedDataRecord mixedDataRecord, int indexNumber)
        {
            var values = mixedDataRecord.Records;
            return ((MixedDataRecord)values[indexNumber]);
        }

        public static string GetStringValue(this MixedDataRecord mixedDataRecord, int indexNumber)
        {
            var values = mixedDataRecord.Records;
            return ((SingleDataRecord)values[indexNumber]).Data;
        }

        //public static double GetDoubleValue(this MixedDataRecord mixedDataRecord, int indexNumber)
        //{
        //    return double.Parse(mixedDataRecord.GetStringValue(indexNumber), CultureInfo.CurrentCulture);
        //}

        //public static int GetIntegerValue(this MixedDataRecord mixedDataRecord, int indexNumber)
        //{
        //    return int.Parse(mixedDataRecord.GetStringValue(indexNumber), CultureInfo.CurrentCulture);
        //}

        public static string GetStringValue(this MultipleRecords multipleRecords, string recordName)
        {
            if (multipleRecords.Records.TryGetValue(recordName, out Record record))
                return record.GetStringValue();
            return null;
        }

        //public static double GetDoubleValue(this MultipleRecords multipleRecords, string recordName)
        //{
        //    if (multipleRecords.Records.TryGetValue(recordName, out Record record))
        //        return record.GetDoubleValue();
        //    return 0;
        //}

        //public static int GetIntegerValue(this MultipleRecords multipleRecords, string recordName)
        //{
        //    if (multipleRecords.Records.TryGetValue(recordName, out Record record))
        //        return record.GetIntegerValue();
        //    return 0;
        //}

        public static MultipleRecords GetMultipleRecords(this Record record)
        {
            return (MultipleRecords)record.Data;
        }

        public static IList<RecordData> GetRecords(this Record record)
        {
            return ((MixedDataRecord)record.Data).Records;
        }

        public static string GetStringValue(this Record record)
        {
            return ((SingleDataRecord)record.Data).Data;
        }

        //public static double GetDoubleValue(this Record record)
        //{
        //    return double.Parse(((SingleDataRecord)record.Data).Data, CultureInfo.CurrentCulture);
        //}

        //public static int GetIntegerValue(this Record record)
        //{
        //    return int.Parse(((SingleDataRecord)record.Data).Data, CultureInfo.CurrentCulture);
        //}

        public static string GetStringValue(this RecordData recordData)
        {
            if (recordData is SingleDataRecord singleRecordData)
                return singleRecordData.Data;
            return null;
        }

        //public static double GetDoubleValue(this RecordData recordData)
        //{
        //    return double.Parse(((SingleDataRecord)recordData).Data, CultureInfo.CurrentCulture);
        //}

        //public static int GetIntegerValue(this RecordData recordData)
        //{
        //    return int.Parse(((SingleDataRecord)recordData).Data, CultureInfo.CurrentCulture);
        //}

        public static Record GetMultipleDataRecord(string name)
        {
            var record = new Record(name);
            record.Data = new MultipleRecords();
            return record;
        }

        public static Record GetMixedDataRecord(string name)
        {
            var record = new Record(name);
            record.Data = new MixedDataRecord();
            return record;
        }

        public static Record GetSingleDataRecord(string name, string data)
        {
            var record = new Record(name);
            var singleDataRecord = new SingleDataRecord(data);
            record.Data = singleDataRecord;
            return record;
        }

        public static void AddMultipleRecords(this MultipleRecords multipleRecords, string recordName, object recordData)
        {
            var abilitiesRecord = new Record();
            abilitiesRecord.Data = (MultipleRecords)recordData;
            abilitiesRecord.Name = recordName;
            multipleRecords.Records.Add(recordName, abilitiesRecord);
        }

        public static void AddMixedDataRecord(this MultipleRecords multipleRecords, string recordName, object recordData)
        {
            var abilitiesRecord = new Record();
            abilitiesRecord.Data = recordData as RecordData;
            abilitiesRecord.Name = recordName;
            multipleRecords.Records.Add(recordName, abilitiesRecord);
        }

        public static void AddSingleDataRecord(this MultipleRecords multipleRecords, string name, string data)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(data))
                return;

            var singleDataRecord = GetSingleDataRecord(name, data);
            multipleRecords.Records.Add(name, singleDataRecord);
        }

        public static void AddMixedDataRecord(this MultipleRecords multipleRecords, string name, Record data)
        {
            if (!string.IsNullOrWhiteSpace(name) && data != null)
                multipleRecords.Records.Add(name, data);
        }
    }
}
