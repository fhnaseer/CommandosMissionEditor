namespace Commandos.IO.Entities
{
    public class SingleValue : RecordValueBase
    {
        public SingleValue() { }

        public SingleValue(string data) => Value = data;

        public string Value { get; set; }

        public override string ToString() => Value;
    }
}
