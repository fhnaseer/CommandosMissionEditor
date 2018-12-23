namespace Commandos.Model.Characters.Enemies.Actions
{
    public class CustomAction : EnemyAction
    {
        public override string ActionName => "Custom Action";

        public string ActionString { get; set; }
    }
}
