using System.Diagnostics.CodeAnalysis;
using Commandos.Model.Common;

namespace Commandos.Model
{
    public enum CameraDirection
    {
        Zero,
        One,
        Two,
        Three
    }

    public class Camera
    {
        public CameraDirection CameraDirection { get; set; }

        public Position Position { get; set; }

        public string Escape { get; set; }

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
            return Equals(obj as Camera);
        }

        /// <summary>
        /// Determines whether the specified Camera is equal to the current Camera.
        /// </summary>
        /// <param name="other">The Camera to compare with the current Camera.</param>
        /// <returns>true if the specified Camera is equal to the current Camera;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(Camera other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return CameraDirection == other.CameraDirection &&
                Position == other.Position &&
                Escape == other.Escape;
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
        /// Overrides equal operator for Camera.
        /// </summary>
        /// <param name="left">Left Camera.</param>
        /// <param name="right">Right Camera</param>
        /// <returns>true if the left Camera is equal to the right Camera;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(Camera left, Camera right)
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
        /// Overrides not equal operator for Camera.
        /// </summary>
        /// <param name="left">Left Camera.</param>
        /// <param name="right">Right Camera</param>
        /// <returns>true if the left Camera is not equal to the right Camera;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(Camera left, Camera right)
        {
            return !(left == right);
        }
        #endregion
    }
}
