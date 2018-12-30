namespace Commandos.Model.Characters.Enemies
{
    public abstract class EnemySoldier : EnemyCharacter
    {
        public abstract string Name { get; }

        public abstract string Range { get; }

        public abstract string Trigger { get; }

        public abstract string AnimationFileName { get; }

        public override string ToString() => $"{Name} {TokenId} {Position.ToString()}";
    }
}
