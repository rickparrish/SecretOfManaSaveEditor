using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace SavLibrary {
    public static class Enums {
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

        public static string[] GetDescriptions<T>() {
            var result = new List<string>();

            foreach (var value in Enum.GetValues(typeof(T))) {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute attribute = fi.GetCustomAttribute<DescriptionAttribute>();
                result.Add(attribute?.Description ?? value.ToString());
            }

            return result.ToArray();
        }

        public static T Parse<T>(string type) {
            return (T)Enum.Parse(typeof(T), type);
        }
    }

    public enum ArmGearType {
        [Description("Faerie's Ring")]
        FaeriesRing = 43,
        [Description("Elbow Pad")]
        ElbowPad,
        [Description("Power Vambrace")]
        PowerVambrace,
        [Description("Cobra Bracelet")]
        CobraBracelet,
        [Description("Wolf's Band")]
        WolfsBand,
        [Description("Silver Band")]
        SilverBand,
        [Description("Golem Ring")]
        GolemRing,
        [Description("Frosty Ring")]
        FrostyRing,
        [Description("Ivy Amulet")]
        IvyAmulet,
        [Description("Gold Bracelet")]
        GoldBracelet,
        [Description("Shield Ring")]
        ShieldRing,
        [Description("Lazuli Vambrace")]
        LazuliVambrace,
        [Description("Guardian Ring")]
        GuardianRing,
        [Description("Vambrace")]
        Vambrace,
        [Description("Ninja Gloves")]
        NinjaGloves,
        [Description("Dragon Coil")]
        DragonCoil,
        [Description("Watcher Ring")]
        WatcherRing,
        [Description("Imp's Ring")]
        ImpsRing,
        [Description("Amulet Ring")]
        AmuletRing,
        [Description("Wristband")]
        Wristband,
    }

    public enum BodyGearType {
        [Description("Overalls")]
        Overalls = 22,
        [Description("Kung Fu Suit")]
        KungFuSuit,
        [Description("Minor Robe")]
        MinorRobe,
        [Description("Chain Vest")]
        ChainVest,
        [Description("Spiky Suit")]
        SpikySuit,
        [Description("Kung Fu Dress")]
        KungFuDress,
        [Description("Fancy Overalls")]
        FancyOveralls,
        [Description("Chest Guard")]
        ChestGuard,
        [Description("Golden Vest")]
        GoldenVest,
        [Description("Ruby Vest")]
        RubyVest,
        [Description("Tiger Suit")]
        TigerSuit,
        [Description("Tiger Two-Piece")]
        TigerTwoPiece,
        [Description("Magical Armour")]
        MagicalArmour,
        [Description("Tortoise Mail")]
        TortoiseMail,
        [Description("Flower Suit")]
        FlowerSuit,
        [Description("Battle Suit")]
        BattleSuit,
        [Description("Vestguard")]
        Vestguard,
        [Description("Vampire Cape")]
        VampireCape,
        [Description("Power Suit")]
        PowerSuit,
        [Description("Faerie Cloak")]
        FaerieCloak,
    }

    public enum CharacterType {
        Boy,
        Girl,
        Sprite,
    }

    public enum HeadGearType {
        [Description("Bandana")]
        Bandana = 1,
        [Description("Hair Ribbon")]
        HairRibbon,
        [Description("Rabite Cap")]
        RabiteCap,
        [Description("Head Gear")]
        HeadGear,
        [Description("Quill Cap")]
        QuillCap,
        [Description("Steel Cap")]
        SteelCap,
        [Description("Golden Tiara")]
        GoldenTiara,
        [Description("Raccoon Cap")]
        RaccoonCap,
        [Description("Quilted Hood")]
        QuiltedHood,
        [Description("Tiger Cap")]
        TigerCap,
        [Description("Circlet")]
        Circlet,
        [Description("Ruby Armet")]
        RubyArmet, // Not available in the game
        [Description("Unicorn Helm")]
        UnicornHelm,
        [Description("Dragon Helm")]
        DragonHelm,
        [Description("Duck Helm")]
        DuckHelm,
        [Description("Needle Helm")]
        NeedleHelm,
        [Description("Cockatrice Cap")]
        CockatriceCap,
        [Description("Amulet Helm")]
        AmuletHelm,
        [Description("Griffin Helm")]
        GriffinHelm,
        [Description("Faerie Crown")]
        FaerieCrown,
    }

    public enum ItemType {
        [Description("Candy")]
        Candy = 0,
        [Description("Chocolate")]
        Chocolate,
        [Description("Royal Jam")]
        RoyalJam,
        [Description("Faerie Walnut")]
        FaerieWalnut,
        [Description("Medical Herb")]
        MedicalHerb,
        [Description("Cup of Wishes")]
        CupOfWishes,
        [Description("Magic Rope")]
        MagicRope,
        [Description("Flammie Drum")]
        FlammieDrum,
        [Description("Moogle Belt")]
        MoogleBelt,
        [Description("Minor Mallet")]
        MinorMallet,
        [Description("Barrel")]
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
