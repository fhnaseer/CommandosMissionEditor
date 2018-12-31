using System.Diagnostics.CodeAnalysis;

namespace Commandos.Model.EnemyActions
{
    public class EnemyAction
    {
        public virtual string ActionName { get; }

        public override string ToString() => ActionName;

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
            return Equals(obj as EnemyAction);
        }

        /// <summary>
        /// Determines whether the specified EnemyAction is equal to the current EnemyAction.
        /// </summary>
        /// <param name="other">The EnemyAction to compare with the current EnemyAction.</param>
        /// <returns>true if the specified EnemyAction is equal to the current EnemyAction;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(EnemyAction other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return ToString() == other.ToString();
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
        /// Overrides equal operator for EnemyAction.
        /// </summary>
        /// <param name="left">Left EnemyAction.</param>
        /// <param name="right">Right EnemyAction</param>
        /// <returns>true if the left EnemyAction is equal to the right EnemyAction;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(EnemyAction left, EnemyAction right)
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
        /// Overrides not equal operator for EnemyAction.
        /// </summary>
        /// <param name="left">Left EnemyAction.</param>
        /// <param name="right">Right EnemyAction</param>
        /// <returns>true if the left EnemyAction is not equal to the right EnemyAction;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(EnemyAction left, EnemyAction right)
        {
            return !(left == right);
        }
        #endregion
    }
}
