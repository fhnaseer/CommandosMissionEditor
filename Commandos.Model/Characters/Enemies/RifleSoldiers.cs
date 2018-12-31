namespace Commandos.Model.Characters.Enemies
{
    public class Rifleman1German : EnemySoldier
    {
        public override string Name => "Rifleman 1 600 (German)";

        public override string Range => "600";

        public override string Trigger => "ALEMAN_fusil";

        public override string AnimationFileName => "ALEFUS.ANI";
    }

    public class Rifleman2German : EnemySoldier
    {
        public override string Name => "Rifleman 2 625 (German)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_fusil";

        public override string AnimationFileName => "ALEFUSDELGADO.ANI";
    }

    public class Rifleman3German : EnemySoldier
    {
        public override string Name => "Rifleman 3 650 (German)";

        public override string Range => "650";

        public override string Trigger => "ALEMAN_fusil";

        public override string AnimationFileName => "ALEFUSGORDO1.ANI";
    }

    public class Rifleman4German : EnemySoldier
    {
        public override string Name => "Rifleman 4 675 (German)";

        public override string Range => "675";

        public override string Trigger => "ALEMAN_fusil";

        public override string AnimationFileName => "ALEFUSGORDO2.ANI";
    }

    public class RiflemanArcticGerman : EnemySoldier
    {
        public override string Name => "Rifleman Arctic 600 (German)";

        public override string Range => "600";

        public override string Trigger => "ALEMAN_fusil";

        public override string AnimationFileName => "ALEICEF.ANI";
    }

    public class RiflemanJapanese : EnemySoldier
    {
        public override string Name => "Rifleman 600 (Japanese)";

        public override string Range => "600";

        public override string Trigger => "ALEMAN_fusil";

        public override string AnimationFileName => "JAPOFUS.ANI";
    }

    public class RiflemanBackpackJapanese : EnemySoldier
    {
        public override string Name => "Rifleman Backpack (Japanese)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_fusil";

        public override string AnimationFileName => "JAPOMOCHFUS.ANI";
    }
}
