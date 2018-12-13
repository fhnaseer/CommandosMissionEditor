namespace Commandos.IO.Entities
{
    public enum TokenValueType
    {
        SingleValue,
        MultipleValues,
        MultipleList,
        MultipleRecords
    }

    public abstract class TokenBase
    {
        public string Name { get; set; }
    }
}
