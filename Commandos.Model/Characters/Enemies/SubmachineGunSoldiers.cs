﻿namespace Commandos.Model.Characters.Enemies
{
    public class SubmachineGunnerGerman : EnemySoldier
    {
        public override string Name => "Submachine Gunner (German)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_Z";

        public override string AnimationFileName => "ALEMET";
    }

    public class SubmachineGunnerArcticGerman : EnemySoldier
    {
        public override string Name => "Arctic Submachine Gunner (German)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_Z";

        public override string AnimationFileName => "ALEICEZ";
    }
}
