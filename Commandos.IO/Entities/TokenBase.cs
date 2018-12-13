namespace Commandos.IO.Entities
{
    public enum TokenValueType
    {
        SingleValue,
        MultipleRecords,
        MultipleList,
        MultipleListRecords,
        MultipleValues,
        MixedValues
    }

    public abstract class TokenBase
    {
        public string Name { get; set; }
    }
}
