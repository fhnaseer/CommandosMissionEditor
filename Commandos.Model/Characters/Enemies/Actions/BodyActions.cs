namespace Commandos.Model.Characters.Enemies.Actions
{
    public class LieDownAction : EnemyAction
    {
        public override string ActionName => "Lie Down";
    }

    public class GetUpAction : EnemyAction
    {
        public override string ActionName => " Get Up";
    }

    public class KneelDownAction : EnemyAction
    {
        public override string ActionName => "Kneel Down";
    }

    public class DiveUnderwaterAction : EnemyAction
    {
        public override string ActionName => "Dive Underwater";
    }

    public class ComeOutOfWaterAction : EnemyAction
    {
        public override string ActionName => "Come out of Water";
    }
}
