using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class Record : RecordValueBase
    {
        public string Name { get; set; }

        public RecordValueBase Value { get; set; }

        public override string ToString() => $"{Name} {Value.ToString()}";
    }

    public class SingleRecord : RecordValueBase
    {
        public string Value { get; set; }

        public override string ToString() => Value;
    }

    public class MultipleRecord : RecordValueBase
    {
        private List<Record> _records;
        public IList<Record> Records => _records ?? (_records = new List<Record>());
    }

    public class MixedRecords : RecordValueBase
    {
        private List<RecordValueBase> _values;
        public IList<RecordValueBase> Values => _values ?? (_values = new List<RecordValueBase>());
    }
}
