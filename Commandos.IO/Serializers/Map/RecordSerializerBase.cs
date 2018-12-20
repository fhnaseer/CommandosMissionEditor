using System;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;

namespace Commandos.IO.Serializers.Map
{
    public abstract class RecordSerializerBase<T>
    {
        public abstract T Serialize(MultipleRecords multipleRecords);

        public abstract string RecordName { get; }

        public abstract string GetMultipleRecordString(T input);

        public virtual Record Deserialize(T input)
        {
            var recordString = GetMultipleRecordString(input);
            var tokens = recordString.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var multipleRecords = TokenParser.ParseTokens(tokens);
            return new Record(RecordName) { Data = multipleRecords };
        }
    }
}
