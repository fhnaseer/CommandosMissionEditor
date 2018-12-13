using System.Diagnostics.CodeAnalysis;

namespace Commandos.Model.Map
{
    public class Briefing
    {
        public string FileName { get; set; }

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
            return Equals(obj as Briefing);
        }

        /// <summary>
        /// Determines whether the specified Briefing is equal to the current Briefing.
        /// </summary>
        /// <param name="other">The Briefing to compare with the current Briefing.</param>
        /// <returns>true if the specified Briefing is equal to the current Briefing;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(Briefing other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return FileName == other.FileName;
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
        /// Overrides equal operator for Briefing.
        /// </summary>
        /// <param name="left">Left Briefing.</param>
        /// <param name="right">Right Briefing</param>
        /// <returns>true if the left Briefing is equal to the right Briefing;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(Briefing left, Briefing right)
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
        /// Overrides not equal operator for Briefing.
        /// </summary>
        /// <param name="left">Left Briefing.</param>
        /// <param name="right">Right Briefing</param>
        /// <returns>true if the left Briefing is not equal to the right Briefing;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(Briefing left, Briefing right)
        {
            return !(left == right);
        }
        #endregion
    }
}
