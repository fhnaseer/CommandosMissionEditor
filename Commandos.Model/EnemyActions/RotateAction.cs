﻿namespace Commandos.Model.EnemyActions
{
    public class RotateAction : EnemyAction
    {
        public override string ActionName => "Rotate";

        public string Angle { get; set; }

        public override string ToString() => $"{ActionName} {Angle}";

        //#region Methods for Equality checks.
        //// http://msdn.microsoft.com/en-us/library/dd183755.aspx
        //// Why ExcludeFromCodeCoverage? This code is used in multiple places and is heavily unit-tested.
        //// Code is taken from MSDN which uses additional null checks for better performance.
        //// It make no sense in writing same unit-tests again and again (is left null, is right null, etc.) again and again.
        ///// <summary>
        ///// Determines whether the specified <see cref="Object" />, is equal to this instance.
        ///// </summary>
        ///// <param name="obj">The <see cref="Object" /> to compare with this instance.</param>
        ///// <returns>
        /////   <c>true</c> if the specified <see cref="Object" /> is equal to this instance; otherwise, <c>false</c>.
        ///// </returns>
        //[ExcludeFromCodeCoverage]
        //public override bool Equals(object obj)
        //{
        //    return Equals(obj as RotateAction);
        //}

        ///// <summary>
        ///// Determines whether the specified RotateAction is equal to the current RotateAction.
        ///// </summary>
        ///// <param name="other">The RotateAction to compare with the current RotateAction.</param>
        ///// <returns>true if the specified RotateAction is equal to the current RotateAction;
        ///// otherwise, false.</returns>
        //[ExcludeFromCodeCoverage]
        //internal bool Equals(RotateAction other)
        //{
        //    // If parameter is null, return false.
        //    if (other is null)
        //        return false;

        //    // Optimization for a common success case.
        //    if (ReferenceEquals(this, other))
        //        return true;

        //    return Angle == other.Angle;
        //}

        ///// <summary>
        ///// Returns a hash code for this instance.
        ///// </summary>
        ///// <returns>
        ///// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        ///// </returns>
        //[ExcludeFromCodeCoverage]
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        ///// <summary>
        ///// Overrides equal operator for RotateAction.
        ///// </summary>
        ///// <param name="left">Left RotateAction.</param>
        ///// <param name="right">Right RotateAction</param>
        ///// <returns>true if the left RotateAction is equal to the right RotateAction;
        ///// otherwise, false. </returns>
        //[ExcludeFromCodeCoverage]
        //public static bool operator ==(RotateAction left, RotateAction right)
        //{
        //    // Check for null on left side.
        //    if (left is null)
        //    {
        //        if (right is null)
        //        {
        //            // null == null = true.
        //            return true;
        //        }

        //        // Only the left side is null.
        //        return false;
        //    }
        //    // Equals handles case of null on right side.
        //    return left.Equals(right);
        //}

        ///// <summary>
        ///// Overrides not equal operator for RotateAction.
        ///// </summary>
        ///// <param name="left">Left RotateAction.</param>
        ///// <param name="right">Right RotateAction</param>
        ///// <returns>true if the left RotateAction is not equal to the right RotateAction;
        ///// otherwise, false. </returns>
        //[ExcludeFromCodeCoverage]
        //public static bool operator !=(RotateAction left, RotateAction right)
        //{
        //    return !(left == right);
        //}
        //#endregion
    }
}
