using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Commandos.Model.Characters;
using Commandos.Model.Characters.Commandos;

namespace Commandos.Model.Map
{
    public class MissionObjects
    {
        private ObservableCollection<Commando> _commandos;
        public ObservableCollection<Commando> Commandos => _commandos ?? (_commandos = new ObservableCollection<Commando>());

        private ObservableCollection<EnemyCharacter> _soldiers;
        public ObservableCollection<EnemyCharacter> Soldiers => _soldiers ?? (_soldiers = new ObservableCollection<EnemyCharacter>());

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
            return Equals(obj as MissionObjects);
        }

        /// <summary>
        /// Determines whether the specified MissionObjects is equal to the current MissionObjects.
        /// </summary>
        /// <param name="other">The MissionObjects to compare with the current MissionObjects.</param>
        /// <returns>true if the specified MissionObjects is equal to the current MissionObjects;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(MissionObjects other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return Commandos.Count == other.Commandos.Count && Commandos.SequenceEqual(other.Commandos) &&
                Soldiers.Count == other.Soldiers.Count && Soldiers.SequenceEqual(other.Soldiers);
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
        /// Overrides equal operator for MissionObjects.
        /// </summary>
        /// <param name="left">Left MissionObjects.</param>
        /// <param name="right">Right MissionObjects</param>
        /// <returns>true if the left MissionObjects is equal to the right MissionObjects;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(MissionObjects left, MissionObjects right)
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
        /// Overrides not equal operator for MissionObjects.
        /// </summary>
        /// <param name="left">Left MissionObjects.</param>
        /// <param name="right">Right MissionObjects</param>
        /// <returns>true if the left MissionObjects is not equal to the right MissionObjects;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(MissionObjects left, MissionObjects right)
        {
            return !(left == right);
        }
        #endregion
    }
}
