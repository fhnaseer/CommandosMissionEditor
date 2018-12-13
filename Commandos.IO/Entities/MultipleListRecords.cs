using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class MultipleListRecords : TokenBase
    {
        private List<MultipleRecords> _values;
        public IList<MultipleRecords> Values => _values ?? (_values = new List<MultipleRecords>());
    }
}
