using Commandos.Model.Common;

namespace Commandos.Model.Characters.Enemies.Actions
{
    public class MoveAction : EnemyAction, IPosition
    {
        public override string ActionName => "Move";

        private Position _position;
        public Position Position
        {
            get => _position ?? (_position = new Position());
            set => _position = value;
        }

        public string MovementType { get; set; }

        public string Area { get; set; }

        public override string ToString() => $"{ActionName} {Position.ToString()} {MovementType} {Area}";
    }

    public class PauseAction : EnemyAction
    {
        public override string ActionName => "Pause";

        public string Time { get; set; }

        public override string ToString() => $"{ActionName} {Time}";
    }

    public class RotateAction : EnemyAction
    {
        public override string ActionName => "Rotate";

        public string Angle { get; set; }

        public override string ToString() => $"{ActionName} {Angle}";
    }

    public class EnterDoorAction : EnemyAction
    {
        public override string ActionName => "Enter Door";

        public string MovementType { get; set; }

        public string DoorName { get; set; }

        public override string ToString() => $"{ActionName} {DoorName} {MovementType}";
    }
}
