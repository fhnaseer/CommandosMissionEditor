using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Commandos.Model.Characters.Enemies;

namespace Commandos.Model.Map
{
    public class World
    {
        public string GscFileName { get; set; }

        public Administration Administration { get; set; } = new Administration(null);

        public MissionObjects MissionObjects { get; set; } = new MissionObjects();

        private ObservableCollection<EnemyPatrol> _patrols;
        public ObservableCollection<EnemyPatrol> Patrols => _patrols ?? (_patrols = new ObservableCollection<EnemyPatrol>());

        public SpecialAreas SpecialAreas { get; set; } = new SpecialAreas(null);

        public SoundAreas SoundAreas { get; set; } = new SoundAreas(null);

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
            return Equals(obj as World);
        }

        /// <summary>
        /// Determines whether the specified World is equal to the current World.
        /// </summary>
        /// <param name="other">The World to compare with the current World.</param>
        /// <returns>true if the specified World is equal to the current World;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(World other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return GscFileName == other.GscFileName &&
                Administration == other.Administration &&
                MissionObjects == other.MissionObjects &&
                SpecialAreas == other.SpecialAreas &&
                SoundAreas == other.SoundAreas &&
                Patrols.Count == other.Patrols.Count && Patrols.SequenceEqual(other.Patrols);
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
        /// Overrides equal operator for World.
        /// </summary>
        /// <param name="left">Left World.</param>
        /// <param name="right">Right World</param>
        /// <returns>true if the left World is equal to the right World;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(World left, World right)
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
        /// Overrides not equal operator for World.
        /// </summary>
        /// <param name="left">Left World.</param>
        /// <param name="right">Right World</param>
        /// <returns>true if the left World is not equal to the right World;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(World left, World right)
        {
            return !(left == right);
        }
        #endregion
    }
}
