using Commandos.Model.Common;

namespace Commandos.Model.Characters.Enemies.Actions
{
    public class MoveAction : EnemyAction
    {
        public override string ActionName => "Move";

        private Position _position;
        public Position Position => _position ?? (_position = new Position());

        public MovementType MovementType { get; set; }
    }

    public class PauseAction : EnemyAction
    {
        public override string ActionName => "Pause";

        public double Time { get; set; }
    }

    public class TurnAction : EnemyAction
    {
        public override string ActionName => "Turn";

        public double Angle { get; set; }
    }
}
