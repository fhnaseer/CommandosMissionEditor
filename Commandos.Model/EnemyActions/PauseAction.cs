using System.Diagnostics.CodeAnalysis;

namespace Commandos.Model.EnemyActions
{
    public class PauseAction : EnemyAction
    {
        public override string ActionName => "Pause";

        public string Time { get; set; }

        public override string ToString() => $"{ActionName} {Time}";

        #region Methods for Equality checks.
        // http://msdn.microsoft.com/en-us/library/dd183755.aspx
        // Why ExcludeFromCodeCoverage? This code is used in multiple places and is heavily unit-tested.
        // Code is taken from MSDN which uses additional null checks for better performance.
        // It make no sense in writing same unit-tests again and again (is left null, is right null, etc.) again and again.
        /// <summary>
        /// Determines whether the specified <see cref="PauseAction" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="PauseAction" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="PauseAction" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            return Equals(obj as PauseAction);
        }

        /// <summary>
        /// Determines whether the specified PauseAction is equal to the current PauseAction.
        /// </summary>
        /// <param name="other">The PauseAction to compare with the current PauseAction.</param>
        /// <returns>true if the specified PauseAction is equal to the current PauseAction;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(PauseAction other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return Time == other.Time;
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
        /// Overrides equal operator for PauseAction.
        /// </summary>
        /// <param name="left">Left PauseAction.</param>
        /// <param name="right">Right PauseAction</param>
        /// <returns>true if the left PauseAction is equal to the right PauseAction;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(PauseAction left, PauseAction right)
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
        /// Overrides not equal operator for PauseAction.
        /// </summary>
        /// <param name="left">Left PauseAction.</param>
        /// <param name="right">Right PauseAction</param>
        /// <returns>true if the left PauseAction is not equal to the right PauseAction;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(PauseAction left, PauseAction right)
        {
            return !(left == right);
        }
        #endregion
    }
}
