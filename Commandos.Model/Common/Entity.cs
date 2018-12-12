using System.Collections.Generic;

namespace Commandos.Model.Common
{
    public abstract class Entity
    {
        public abstract string Name { get; }
    }

    public abstract class SingleValueEntity<T> : Entity
    {
        public virtual T Value { get; set; }
    }

    public abstract class MultipleDataEntity<T> : Entity
    {
        public abstract IList<T> Values { get; }
    }
}
