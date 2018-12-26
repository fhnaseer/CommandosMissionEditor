using System.Diagnostics.CodeAnalysis;
using Commandos.Model.Common;

namespace Commandos.Model.Characters.Enemies.Actions
{
    public class MoveAction : EnemyAction
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

        public override string ToString()
        {
            return $"{ActionName} {Position.ToString()}";
        }

        #region Methods for Equality checks.
        // http://msdn.microsoft.com/en-us/library/dd183755.aspx
        // Why ExcludeFromCodeCoverage? This code is used in multiple places and is heavily unit-tested.
        // Code is taken from MSDN which uses additional null checks for better performance.
        // It make no sense in writing same unit-tests again and again (is left null, is right null, etc.) again and again.
        /// <summary>
        /// Determines whether the specified <see cref="Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            return Equals(obj as MoveAction);
        }

        /// <summary>
        /// Determines whether the specified MoveAction is equal to the current MoveAction.
        /// </summary>
        /// <param name="other">The MoveAction to compare with the current MoveAction.</param>
        /// <returns>true if the specified MoveAction is equal to the current MoveAction;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(MoveAction other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return (Area == other.Area && MovementType == other.MovementType && Position == other.Position);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Overrides equal operator for MoveAction.
        /// </summary>
        /// <param name="left">Left MoveAction.</param>
        /// <param name="right">Right MoveAction</param>
        /// <returns>true if the left MoveAction is equal to the right MoveAction;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(MoveAction left, MoveAction right)
        {
            // Check for null on left side.
            if (left is null)
            {
                if (right is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return left.Equals(right);
        }

        /// <summary>
        /// Overrides not equal operator for MoveAction.
        /// </summary>
        /// <param name="left">Left MoveAction.</param>
        /// <param name="right">Right MoveAction</param>
        /// <returns>true if the left MoveAction is not equal to the right MoveAction;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(MoveAction left, MoveAction right)
        {
            return !(left == right);
        }
        #endregion
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
