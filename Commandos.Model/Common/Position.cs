using System.Diagnostics.CodeAnalysis;

namespace Commandos.Model.Common
{
    public class Position
    {
        public Position()
            : this("0", "0", "0")
        { }

        public Position(string x, string y, string z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public string X { get; set; }

        public string Y { get; set; }

        public string Z { get; set; }

        #region Methods for Equality checks.
        // http://msdn.microsoft.com/en-us/library/dd183755.aspx
        // Why ExcludeFromCodeCoverage? This code is used in multiple places and is heavily unit-tested.
        // Code is taken from MSDN which uses additional null checks for better performance.
        // It make no sense in writing same unit-tests again and again (is left null, is right null, etc.) again and again.
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }

        /// <summary>
        /// Determines whether the specified Position is equal to the current Position.
        /// </summary>
        /// <param name="other">The Position to compare with the current Position.</param>
        /// <returns>true if the specified Position is equal to the current Position;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(Position other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return X == other.X && Y == other.Y && Z == other.Z;
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
        /// Overrides equal operator for Position.
        /// </summary>
        /// <param name="left">Left Position.</param>
        /// <param name="right">Right Position</param>
        /// <returns>true if the left Position is equal to the right Position;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(Position left, Position right)
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
        /// Overrides not equal operator for Position.
        /// </summary>
        /// <param name="left">Left Position.</param>
        /// <param name="right">Right Position</param>
        /// <returns>true if the left Position is not equal to the right Position;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
        #endregion
    }
}
