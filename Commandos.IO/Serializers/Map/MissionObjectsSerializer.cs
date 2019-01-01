using Commandos.IO.Entities;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public class MissionObjectsSerializer : RecordSerializerBase<MissionObjects>
    {
        public const string MissionObjects = ".BICHOS";

        public override string RecordName => MissionObjects;

        public override MissionObjects Serialize(Record record)
        {
            var missionObjects = new MissionObjects();
            var objectRecords = record.GetRecords();
            foreach (MultipleRecords multipleRecords in objectRecords)
            {
                if (SoldiersSerializer.IsSolder(multipleRecords))
                {
                    var enemySoldier = SoldiersSerializer.Serialize(multipleRecords);
                    if (enemySoldier != null)
                        missionObjects.Soldiers.Add(enemySoldier);
                }
                if (CommandosSerializer.IsCommado(multipleRecords))
                {
                    var commando = CommandosSerializer.Serialize(multipleRecords);
                    if (commando != null)
                        missionObjects.Commandos.Add(commando);
                }
            }
            return missionObjects;
        }

        public override string GetMultipleRecordString(MissionObjects input)
        {
            throw new System.NotImplementedException();
        }
    }
}
