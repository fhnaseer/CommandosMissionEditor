namespace Commandos.Model
{
    public class Camera : SingleValueEntity<int>
    {
        public override string Name => ".CAMARA";

        public override int Value { get; set; }
    }
}
