namespace Commandos.IO.Entities
{
    public class SingleValue : RecordValueBase
    {
        public string Value { get; set; }

        public override string ToString() => Value;
    }
}
