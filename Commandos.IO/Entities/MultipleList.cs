using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class MultipleList : TokenBase
    {
        private List<MultipleValues> _values;
        public IList<MultipleValues> Values => _values ?? (_values = new List<MultipleValues>());
    }
}
