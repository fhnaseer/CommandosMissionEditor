using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class MixedDataRecord : RecordData
    {
        private List<RecordData> _records;
        public IList<RecordData> Records => _records ?? (_records = new List<RecordData>());
    }
}
