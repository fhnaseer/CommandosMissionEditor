namespace Commandos.Model.EnemyActions
{
    public class CustomAction : EnemyAction
    {
        public override string ActionName => "Custom Action";

        public string ActionString { get; set; }
    }
}
