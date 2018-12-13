using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class MultipleRecords : RecordValueBase
    {
        private List<Record> _records;
        public IList<Record> Records => _records ?? (_records = new List<Record>());
    }
}
