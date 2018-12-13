using System.Collections.Generic;

namespace Commandos.IO.Entities
{
    public class MultipleValues : TokenBase
    {
        private List<string> _values;
        public IList<string> Values => _values ?? (_values = new List<string>());
    }
}
