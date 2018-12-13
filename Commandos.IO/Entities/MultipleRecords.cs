using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class MultipleRecords : TokenBase
    {
        private List<TokenBase> _values;
        public IList<TokenBase> Values => _values ?? (_values = new List<TokenBase>());
    }
}
