using System.Collections.Generic;

namespace Commandos.Model.Common
{
    public enum CameraDirection
    {
        Zero,
        One,
        Two,
        Three
    }

    public static class ItemCollections
    {
        public static IList<string> GetEnvironments()
        {
            return new List<string> { "EXTERIOR", "INTERIOR", "AGUA" };
        }

        public static IList<CameraDirection> GetCameraDirections()
        {
            return new List<CameraDirection> { CameraDirection.Zero, CameraDirection.One, CameraDirection.Two, CameraDirection.Three };
        }
    }
}
