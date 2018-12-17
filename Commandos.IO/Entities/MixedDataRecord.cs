using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class MixedDataRecord : RecordData
    {
        private List<RecordData> _data;
        public IList<RecordData> Data => _data ?? (_data = new List<RecordData>());
    }
}
