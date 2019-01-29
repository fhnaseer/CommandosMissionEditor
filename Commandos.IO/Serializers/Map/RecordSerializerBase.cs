using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Helpers;

namespace Commandos.IO.Serializers.Map
{
    public abstract class RecordSerializerBase<T>
    {
        public abstract T Serialize(Record record);

        public abstract string RecordName { get; }

        public abstract string GetMultipleRecordString(T input);

        public virtual Record Deserialize(T input)
        {
            var recordString = GetMultipleRecordString(input);
            var tokens = TokenParser.GetCleanedTokens(recordString);
            var multipleRecords = TokenParser.ParseTokens(tokens);
            return new Record(RecordName) { Data = multipleRecords };
        }

        public SerializerHelper SerializerHelper => SerializerHelper.Instance;

        public CameraSerializer CameraSerializer => SerializerHelper.CameraSerializer;

        public FicherosSerializer FicherosSerializer => SerializerHelper.FicherosSerializer;

        public MusicSerializer MusicSerializer => SerializerHelper.MusicSerializer;

        public WorldSerializer WorldSerializer => SerializerHelper.WorldSerializer;

        public PatrolsSerializer PatrolsSerializer => SerializerHelper.PatrolsSerializer;

        public MissionObjectsSerializer MissionObjectsSerializer => SerializerHelper.MissionObjectsSerializer;

        //public SoldiersSerializer SoldiersSerializer => SerializerHelper.SoldiersSerializer;
    }
}
