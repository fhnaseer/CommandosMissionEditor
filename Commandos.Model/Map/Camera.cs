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

        public Escape Escape { get; set; }
    }
}
