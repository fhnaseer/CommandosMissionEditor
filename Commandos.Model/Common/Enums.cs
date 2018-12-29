namespace Commandos.Model.Common
{
    public enum MovementType
    {
        Walk,
        Crawl,
        Run
    }

    public enum ActionRepeatType
    {
        Loop,
        Stopped,
        BackAndForth
    }

    public enum CharacterType
    {
        Commando,
        Soldier,
        EnemyPatrol
    }

#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum SoldierTypes
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        BlueMechanic,
        Mechanic,
        BlueSoldierNoWeapon,
        UnderwearSoldier,
        TowelSoldier,
        Worker,
        OfficerAssistant,
        GunSoldier1,
        GunSoldier2,
        GunSoldier3,
        GunSoldier4,
        GunSoldierFlashlight,
        JailerGun,
        Rifleman1,
        Rifleman2,
        Rifleman3,
        Rifleman4,
        ArcticRifleman,
        SniperGunOnly,
        SubMachineGunner,
        ArcticSubMachineGunner,

        Lieutenant,
        LieutenantFlashlight,
        ArcticLieutenant,
        Torturer,
        Officer,
        ArcticOfficer,
        Admiral,
        SSOfficer,
        FieldMarshall1,
        FieldMarshall2,
        FieldMarshall3,
        Grenadier,
        MedicGun,
        MedicRifle,
        MedicSubMachineGun,
        Sniper,
        SniperNoAimTime,
        ArcticSniper,
        ArcticSniperNoAimTime,
        SSSubMachinGunner,
    }
}
