using System.Collections.Generic;
using Commandos.Model.Common;

namespace Commandos.Model.Characters
{
    public class CommandoAbilities
    {
        private List<Ability> _basicAbilities;
        public IList<Ability> BasicAbilities => _basicAbilities ?? (_basicAbilities = new List<Ability>());

        private List<Ability> _specialAbilities;
        public IList<Ability> SpecialAbilities => _specialAbilities ?? (_specialAbilities = new List<Ability>());
    }
}
