namespace Commandos.IO.Entities
{
    public enum TokenValueType
    {
        SingleValue,
        MultipleValues,
        MultipleList,
        MultipleListRecords,
        MultipleRecords
    }

    public abstract class TokenBase
    {
        public string Name { get; set; }
    }
}
