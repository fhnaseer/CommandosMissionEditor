namespace Commandos.Model.Characters.Enemies.Actions
{
    public class EnemyAction
    {
        public virtual string ActionName { get; }

        public override string ToString() => ActionName;
    }
}
