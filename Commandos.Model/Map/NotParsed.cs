namespace Commandos.Model.Map
{
    public abstract class NotParsed
    {
        protected NotParsed(object multipleRecords)
        {
            MultipleRecords = multipleRecords;
        }

        public object MultipleRecords { get; set; }
    }
}
