using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Commandos.Model.Characters.Enemies.Actions;
using Commandos.Model.Common;

namespace Commandos.Model.Map
{
    public class EnemyPatrol : MissionObject
    {
        public string Angle { get; set; }

        public string ColumnsCount { get; set; }

        public string RowsCount { get; set; }

        public string SoldiersFileName { get; set; }

        public string LeaderFileName { get; set; }

        private ObservableCollection<EnemyRoute> _routes;
        public ObservableCollection<EnemyRoute> Routes => _routes ?? (_routes = new ObservableCollection<EnemyRoute>());

        public string DefaultRoute { get; set; }

        public string EventRoute { get; set; }

        public override string ToString() => TokenId;

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
            return Equals(obj as EnemyPatrol);
        }

        /// <summary>
        /// Determines whether the specified EnemyPatrol is equal to the current EnemyPatrol.
        /// </summary>
        /// <param name="other">The EnemyPatrol to compare with the current EnemyPatrol.</param>
        /// <returns>true if the specified EnemyPatrol is equal to the current EnemyPatrol;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(EnemyPatrol other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return (Angle == other.Angle && ColumnsCount == other.ColumnsCount && RowsCount == other.RowsCount &&
                SoldiersFileName == other.SoldiersFileName && LeaderFileName == other.LeaderFileName &&
                Routes.Count == other.Routes.Count && Routes.SequenceEqual(other.Routes));
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
        /// Overrides equal operator for EnemyPatrol.
        /// </summary>
        /// <param name="left">Left EnemyPatrol.</param>
        /// <param name="right">Right EnemyPatrol</param>
        /// <returns>true if the left EnemyPatrol is equal to the right EnemyPatrol;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(EnemyPatrol left, EnemyPatrol right)
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
        /// Overrides not equal operator for EnemyPatrol.
        /// </summary>
        /// <param name="left">Left EnemyPatrol.</param>
        /// <param name="right">Right EnemyPatrol</param>
        /// <returns>true if the left EnemyPatrol is not equal to the right EnemyPatrol;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(EnemyPatrol left, EnemyPatrol right)
        {
            return !(left == right);
        }
        #endregion
    }
}
