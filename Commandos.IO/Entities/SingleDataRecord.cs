namespace Commandos.IO.Entities
{
    public class SingleDataRecord : RecordData
    {
        public SingleDataRecord() { }

        public SingleDataRecord(string data) => Data = data;

        public string Data { get; set; }

        public override string ToString() => Data;
    }
}
