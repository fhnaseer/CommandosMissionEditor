using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class MixedValues : RecordValueBase
    {
        private List<RecordValueBase> _values;
        public IList<RecordValueBase> Values => _values ?? (_values = new List<RecordValueBase>());
    }
}
