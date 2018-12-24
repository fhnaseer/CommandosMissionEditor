namespace Commandos.Model.Characters.Enemies.Actions
{
    public abstract class EnemyAction
    {
        public abstract string ActionName { get; }

        public override string ToString() => ActionName;
    }
}
