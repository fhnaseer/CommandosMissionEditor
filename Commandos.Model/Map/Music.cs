using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Commandos.Model.Common;

namespace Commandos.Model.Map
{
    public class Music
    {
        private ObservableCollection<BackgroundMusic> _backgroundMusics;
        public ObservableCollection<BackgroundMusic> BackgroundMusics => _backgroundMusics ?? (_backgroundMusics = new ObservableCollection<BackgroundMusic>());

        public string StartingMusicEnvironment { get; set; }


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
            return Equals(obj as Music);
        }

        /// <summary>
        /// Determines whether the specified Music is equal to the current Music.
        /// </summary>
        /// <param name="other">The Music to compare with the current Music.</param>
        /// <returns>true if the specified Music is equal to the current Music;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(Music other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return StartingMusicEnvironment == other.StartingMusicEnvironment &&
                BackgroundMusics.Count == other.BackgroundMusics.Count &&
                BackgroundMusics.SequenceEqual(other.BackgroundMusics);
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
        /// Overrides equal operator for Music.
        /// </summary>
        /// <param name="left">Left Music.</param>
        /// <param name="right">Right Music</param>
        /// <returns>true if the left Music is equal to the right Music;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(Music left, Music right)
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
        /// Overrides not equal operator for Music.
        /// </summary>
        /// <param name="left">Left Music.</param>
        /// <param name="right">Right Music</param>
        /// <returns>true if the left Music is not equal to the right Music;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(Music left, Music right)
        {
            return !(left == right);
        }
        #endregion
    }
}
