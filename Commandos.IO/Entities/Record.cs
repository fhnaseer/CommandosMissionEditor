namespace Commandos.IO.Entities
{
    public class Record : RecordData
    {
        public Record()
        {
        }

        public Record(string name) => Name = name;

        public string Name { get; set; }

        public RecordData Data { get; set; }

        public override string ToString() => $"{Name} {Data.ToString()}";
    }
}
