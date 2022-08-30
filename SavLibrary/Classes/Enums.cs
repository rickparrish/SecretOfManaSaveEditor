using System;
using System.Collections.Generic;

namespace SavLibrary {
    public static class Enums {
        public static T Parse<T>(string type) {
            return (T)Enum.Parse(typeof(T), type);
        }

        public static Dictionary<WeaponType, string[]> WeaponTypeNames = new Dictionary<WeaponType, string[]>() {
            { WeaponType.Axe, new string[] { "Watt's Axe", "Lode Axe", "Stout Axe", "Battle Axe", "Pyrite Axe", "Were-Buster", "Great Axe", "Gigas Axe", "Doom Axe", } },
            { WeaponType.Boomerang, new string[] { "Boomerang", "Chakram", "Lode Boomerang", "Rising Sun", "Titan Boomerang", "Cobra Shuttle", "Frizbar", "Shuriken", "Ninja Star", } },
            { WeaponType.Bow, new string[] { "Chobin's Bow", "Iron Bow", "Long Bow", "Great Bow", "Silver Bow", "Elfin Bow", "Wing Bow", "Doom Bow", "Garuda Buster", } },
            { WeaponType.Gloves, new string[] { "Spiked Knuckles", "Power Glove", "Moogle Claws", "Chakra Hand", "Heavy Glove", "Hyper-Fist", "Griffin Claws", "Dragon Claws", "Aura Glove", } },
            { WeaponType.Javelin, new string[] { "Pole Dart", "Javelin", "Light Trident", "Trident", "Silver Pilum", "Imp's Fork", "Elf's Harpoon", "Dragon Dart", "Valkyrian", } },
            { WeaponType.Spear, new string[] { "Spear", "Heavy Spear", "Sprite's Spear", "Partisan", "Halberd", "Oceanid Spear", "Gigas Lance", "Dragon Lance", "Daedalus Lance", } },
            { WeaponType.Sword, new string[] { "Rusty Sword", "Rapier", "Herald's Sword", "Orihalcum Blade", "Excalibur", "Masamune", "Gigas Sword", "Dragon Buster", "Mana Sword", } },
            { WeaponType.Whip, new string[] { "Leather Whip", "Black Whip", "Backhand Whip", "Chain Whip", "Silver Whip", "Steel Whip", "Hammer Whip", "Nimbus Whip", "Gigas Whip", } },
        };
    }

    public enum ArmGearType {
        FaeriesRing = 43,
        ElbowPad,
        PowerVambrace,
        CobraBracelet,
        WolfsBand,
        SilverBand,
        GolemRing,
        FrostyRing,
        IvyAmulet,
        GoldBracelet,
        ShieldRing,
        LazuliVambrace,
        GuardianRing,
        Vambrace,
        NinjaGloves,
        DragonCoil,
        WatcherRing,
        ImpsRing,
        AmuletRing,
        Wristband,
    }

    public enum BodyGearType {
        Overalls = 22,
        KungFuSuit,
        MinorRobe,
        ChainVest,
        SpikySuit,
        KungFuDress,
        FancyOveralls,
        ChestGuard,
        GoldenVest,
        RubyVest,
        TigerSuit,
        TigerTwoPiece,
        MagicalArmour,
        TortoiseMail,
        FlowerSuit,
        BattleSuit,
        Vestguard,
        VampireCape,
        PowerSuit,
        FaerieCloak,
    }

    public enum CharacterType {
        Boy,
        Girl,
        Sprite,
    }

    public enum HeadGearType {
        Bandana = 1,
        HairRibbon,
        RabiteCap,
        HeadGear,
        QuillCap,
        SteelCap,
        GoldenTiara,
        RaccoonCap,
        QuiltedHood,
        TigerCap,
        Circlet,
        RubyArmet, // Not available in the game
        UnicornHelm,
        DragonHelm,
        DuckHelm,
        NeedleHelm,
        CockatriceCap,
        AmuletHelm,
        GriffinHelm,
        FaerieCrown,
    }

    public enum ItemType {
        Candy = 0,
        Chocolate,
        RoyalJam,
        FaerieWalnut,
        MedicalHerb,
        CupOfWishes,
        MagicRope,
        FlammieDrum,
        MoogleBelt,
        MinorMallet,
        Barrel,
        // TODOY Unknown,
    }

    public enum ManaSeedType {
        Water = 128,
        Earth = 64,
        Wind = 32,
        Fire = 16,
        Light = 8,
        Darkness = 4,
        Moon = 2,
        Wood = 1,
    }

    public enum SpiritType {
        Gnome = 0,
        Undine,
        Salamando,
        Sylphid,
        Luna,
        Dryad,
        Shade,
        Lumina,
    }

    public enum WeaponType {
        Sword = 0,
        Spear,
        Gloves,
        Javelin,
        Boomerang,
        Bow,
        Whip,
        Axe,
    }
}
