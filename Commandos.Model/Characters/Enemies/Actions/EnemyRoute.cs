using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Commandos.Model.Characters.Enemies.Actions
{
    public class EnemyRoute
    {
        public string RouteName { get; set; }

        public string Speed { get; set; }

        public string ActionRepeatType { get; set; }

        private ObservableCollection<EnemyAction> _actions;
        public ObservableCollection<EnemyAction> Actions => _actions ?? (_actions = new ObservableCollection<EnemyAction>());

        public override string ToString() => RouteName;

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
            return Equals(obj as EnemyRoute);
        }

        /// <summary>
        /// Determines whether the specified EnemyActions is equal to the current EnemyActions.
        /// </summary>
        /// <param name="other">The EnemyActions to compare with the current EnemyActions.</param>
        /// <returns>true if the specified EnemyActions is equal to the current EnemyActions;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(EnemyRoute other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return RouteName == other.RouteName && Speed == other.Speed && ActionRepeatType == other.ActionRepeatType &&
                Actions.Count == other.Actions.Count && Actions.SequenceEqual(other.Actions);
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
        /// Overrides equal operator for EnemyActions.
        /// </summary>
        /// <param name="left">Left EnemyActions.</param>
        /// <param name="right">Right EnemyActions</param>
        /// <returns>true if the left EnemyActions is equal to the right EnemyActions;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(EnemyRoute left, EnemyRoute right)
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
        /// Overrides not equal operator for EnemyActions.
        /// </summary>
        /// <param name="left">Left EnemyActions.</param>
        /// <param name="right">Right EnemyActions</param>
        /// <returns>true if the left EnemyActions is not equal to the right EnemyActions;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(EnemyRoute left, EnemyRoute right)
        {
            return !(left == right);
        }
        #endregion
    }
}