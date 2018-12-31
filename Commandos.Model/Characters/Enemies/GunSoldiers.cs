namespace Commandos.Model.Characters.Enemies
{
    public class OfficerAssistantGerman : EnemySoldier
    {
        public override string Name => "Officer Assistant (German)";

        public override string Range => "600";

        public override string Trigger => "ALEMAN_fusil";

        public override string AnimationFileName => "OFICINISTA";
    }

    public class GunSoldier1German : EnemySoldier
    {
        public override string Name => "Gun Soldier 1 600 (German)";

        public override string Range => "600";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "ALEPISTDELGADO";
    }

    public class GunSoldier2German : EnemySoldier
    {
        public override string Name => "Gun Soldier 2 625 (German)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "ALEPISTGORDO1";
    }

    public class GunSoldier3German : EnemySoldier
    {
        public override string Name => "Gun Soldier 3 650 (German)";

        public override string Range => "650";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "ALEPISTGORDO2";
    }

    public class GunSoldier4German : EnemySoldier
    {
        public override string Name => "Gun Soldier 4 675 (German)";

        public override string Range => "675";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "ALEPISTGORDO3";
    }

    public class GunSoldierTorchGerman : EnemySoldier
    {
        public override string Name => "Gun Soldier Torch (German)";

        public override string Range => "600";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "ALEPISTLINTERNERO";
    }

    public class JailerGerman : EnemySoldier
    {
        public override string Name => "Jailer (German)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "CARCELEROALE";
    }

    public class SniperGunGerman : EnemySoldier
    {
        public override string Name => "Sniper (German)";

        public override string Range => "800";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "ALEPISTFRANCO";
    }

    public class CannonierJapanese : EnemySoldier
    {
        public override string Name => "Cannonier (Japanese)";

        public override string Range => "600";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "JAPOCANONIERO";
    }

    public class GunSoldierJapanese : EnemySoldier
    {
        public override string Name => "Soldier (Japanese)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_fusil";

        public override string AnimationFileName => "JAPO";
    }

    public class GunSoldierBackpackJapanese : EnemySoldier
    {
        public override string Name => "Soldier Backpack (Japanese)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "JAPOMOCH";
    }

    public class JailerGunJapanese : EnemySoldier
    {
        public override string Name => "Jailer (Japanese)";

        public override string Range => "675";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "CARCELEROKWAI";
    }

    public class PilotJapanese : EnemySoldier
    {
        public override string Name => "Pilot (Japanese)";

        public override string Range => "675";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "JAPOPILOTO";
    }

    public class SailorBlueJapanese : EnemySoldier
    {
        public override string Name => "Pilot Blue (Japanese)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "JAPOINFMAR";
    }

    public class SailorWhiteJapanese : EnemySoldier
    {
        public override string Name => "Pilot White (Japanese)";

        public override string Range => "625";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "JAPOMARINERO";
    }

    // TODO:,
    public class ScoutJapanese : EnemySoldier
    {
        public override string Name => "Scout (Japanese)";

        public override string Range => "650";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "JAPOVIGIA";
    }

    public class TorturerJapanese : EnemySoldier
    {
        public override string Name => "Torturer (Japanese)";

        public override string Range => "650";

        public override string Trigger => "ALEMAN_pistola";

        public override string AnimationFileName => "JAPOTORTURADOR";
    }
}
