namespace Commandos.Model.EnemyActions
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

    public class DiveInAction : EnemyAction
    {
        public override string ActionName => "Dive In";
    }

    public class DiveOutAction : EnemyAction
    {
        public override string ActionName => "Dive Out";
    }
}
