namespace Commandos.Model.Map
{
    public class World
    {
        public string GscFileName { get; set; }

        public Administration Administration { get; set; }

        public MissionObjects MissionObjects { get; set; }

        public Patrols Patrols { get; set; }

        public SpecialAreas SpecialAreas { get; set; }

        public SoundAreas SoundAreas { get; set; }
    }
}
