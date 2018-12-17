namespace Commandos.IO.Entities
{
    public class Record : RecordValueBase
    {
        public Record()
        {
        }

        public Record(string name) => Name = name;

        public string Name { get; set; }

        public RecordValueBase Value { get; set; }

        public override string ToString() => $"{Name} {Value.ToString()}";
    }
}
