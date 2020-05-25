using Commandos.IO.Entities;

namespace Commandos.IO.Serializers.Helpers
{
    internal class TokenMetadata
    {
        public TokenMetadata(int nameIndex, int startIndex, int endIndex, string[] originalTokens)
        {
            NameIndex = nameIndex;
            StartIndex = startIndex;
            EndIndex = endIndex;
            Tokens = originalTokens[NameIndex..(endIndex + 1)];
            if (originalTokens[startIndex] == "[")
            {
                RecordDataType = RecordDataType.MultipleRecords;
                DataTokens = originalTokens[(startIndex + 1)..endIndex];
            }
            else if (originalTokens[startIndex] == "(")
            {
                RecordDataType = RecordDataType.MixedDataRecord;
                DataTokens = originalTokens[(startIndex + 1)..endIndex];
            }
            else
            {
                RecordDataType = RecordDataType.SingleDataRecord;
                DataTokens = originalTokens[startIndex..(startIndex + 1)];
            }
        }

        public int NameIndex { get; }

        public int StartIndex { get; }

        public int EndIndex { get; }

        public string[] Tokens { get; }

        public string[] DataTokens { get; }

        public RecordDataType RecordDataType { get; }

        public string Name => Tokens[0];
    }
}
