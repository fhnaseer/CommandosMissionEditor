using System.Collections.Generic;

namespace Commandos.Model
{
    public abstract class Entity
    {
        public abstract string Name { get; }
    }

    public abstract class SingleValueEntity<T> : Entity
    {
        public abstract T Value { get; set; }
    }

    public abstract class MultipleDataEntity<T> : Entity
    {
        public abstract List<T> Values { get; }
    }
}
