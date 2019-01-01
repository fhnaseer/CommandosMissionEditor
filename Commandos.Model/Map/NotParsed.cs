using System.Diagnostics.CodeAnalysis;

namespace Commandos.Model.Map
{
    public abstract class NotParsed
    {
        protected NotParsed(object multipleRecords)
        {
            MultipleRecords = multipleRecords;
        }

        public object MultipleRecords { get; set; }

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
            return Equals(obj as NotParsed);
        }

        /// <summary>
        /// Determines whether the specified NotParsed is equal to the current NotParsed.
        /// </summary>
        /// <param name="other">The NotParsed to compare with the current NotParsed.</param>
        /// <returns>true if the specified NotParsed is equal to the current NotParsed;
        /// otherwise, false.</returns>
        [ExcludeFromCodeCoverage]
        internal bool Equals(NotParsed other)
        {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            return true;
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
        /// Overrides equal operator for NotParsed.
        /// </summary>
        /// <param name="left">Left NotParsed.</param>
        /// <param name="right">Right NotParsed</param>
        /// <returns>true if the left NotParsed is equal to the right NotParsed;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator ==(NotParsed left, NotParsed right)
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
        /// Overrides not equal operator for NotParsed.
        /// </summary>
        /// <param name="left">Left NotParsed.</param>
        /// <param name="right">Right NotParsed</param>
        /// <returns>true if the left NotParsed is not equal to the right NotParsed;
        /// otherwise, false. </returns>
        [ExcludeFromCodeCoverage]
        public static bool operator !=(NotParsed left, NotParsed right)
        {
            return !(left == right);
        }
        #endregion
    }
}
