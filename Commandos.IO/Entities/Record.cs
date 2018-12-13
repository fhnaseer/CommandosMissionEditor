namespace Commandos.IO.Entities
{
    public class Record : RecordValueBase
    {
        public string Name { get; set; }

        public RecordValueBase Value { get; set; }

        public override string ToString() => $"{Name} {Value.ToString()}";
    }
}
