using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class MultipleRecords : RecordData
    {
        private Dictionary<string, Record> _records;
        public IDictionary<string, Record> Records => _records ?? (_records = new Dictionary<string, Record>());
    }
}
