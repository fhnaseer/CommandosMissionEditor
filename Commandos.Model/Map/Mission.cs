using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Commandos.Model.Characters;

namespace Commandos.Model.Map
{
    public class Mission
    {
        public string MsbFileName { get; set; }

        public string BasFileName { get; set; }

        private Camera _camera;
        public Camera Camera
        {
            get => _camera ?? (_camera = new Camera());
            set => _camera = value;
        }

        private Briefing _briefing;
        public Briefing Briefing
        {
            get => _briefing ?? (_briefing = new Briefing());
            set => _briefing = value;
        }

        private Music _music;
        public Music Music
        {
            get => _music ?? (_music = new Music());
            set => _music = value;
        }

        private Ficheros _ficheros;
        public Ficheros Ficheros
        {
            get => _ficheros ?? (_ficheros = new Ficheros());
            set => _ficheros = value;
        }

        private Abilities _abilities;
        public Abilities Abilities
        {
            get => _abilities ?? (_abilities = new Abilities(null));
            set => _abilities = value;
        }

        private World _world;
        public World World
        {
            get => _world ?? (_world = new World());
            set => _world = value;
        }

        public ObservableCollection<EnemyCharacter> GetEnemies()
        {
            var enemies = new ObservableCollection<EnemyCharacter>();
            foreach (var patrol in World.Patrols)
                enemies.Add(patrol);
            foreach (var soldier in World.MissionObjects.Soldiers)
                enemies.Add(soldier);
            return enemies;
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
            return Equals(obj as Mission);
        }

        /// <summary>
        /// Determines whether the specified Mission is equal to the current Mission.
        /// </summary>
        /// <param name="other">The Mission to compare with the current Mission.</param>
        /// <returns>true if the specified Mission is equal to the current Mission;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(Mission other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return MsbFileName == other.MsbFileName &&
                BasFileName == other.BasFileName &&
                Camera == other.Camera &&
                Briefing == other.Briefing &&
                Music == other.Music &&
                Ficheros == other.Ficheros &&
                World == other.World;
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
        /// Overrides equal operator for Mission.
        /// </summary>
        /// <param name="left">Left Mission.</param>
        /// <param name="right">Right Mission</param>
        /// <returns>true if the left Mission is equal to the right Mission;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(Mission left, Mission right)
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
        /// Overrides not equal operator for Mission.
        /// </summary>
        /// <param name="left">Left Mission.</param>
        /// <param name="right">Right Mission</param>
        /// <returns>true if the left Mission is not equal to the right Mission;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(Mission left, Mission right)
        {
            return !(left == right);
        }
        #endregion
    }
}
