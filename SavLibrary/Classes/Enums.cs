using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        public static string[] GetDescriptions<T>(bool sortByOrderAttribute) {
            return typeof(T).GetFields()
                            .Where(x => x.IsStatic)
                            .OrderBy(x => sortByOrderAttribute ? x.GetCustomAttribute<OrderAttribute>().Order : (int)x.GetValue(null))
                            .Select(x => x.GetCustomAttribute<DescriptionAttribute>().Description)
                            .ToArray();
        }

        public static Dictionary<int, string> GetDescriptionsAndValues<T>(bool sortByOrderAttribute) {
            return typeof(T).GetFields()
                            .Where(x => x.IsStatic)
                            .OrderBy(x => sortByOrderAttribute ? x.GetCustomAttribute<OrderAttribute>().Order : (int)x.GetValue(null))
                            .ToDictionary(x => (int)x.GetValue(null), x => x.GetCustomAttribute<DescriptionAttribute>().Description);
        }

        public static T Parse<T>(string type) {
            return (T)Enum.Parse(typeof(T), type);
        }
    }

    public enum ArmGearType {
        [Order(19), Description("Faerie's Ring")]
        FaeriesRing = 43,
        [Order(1), Description("Elbow Pad")]
        ElbowPad,
        [Order(2), Description("Power Vambrace")]
        PowerVambrace,
        [Order(3), Description("Cobra Bracelet")]
        CobraBracelet,
        [Order(4), Description("Wolf's Band")]
        WolfsBand,
        [Order(5), Description("Silver Band")]
        SilverBand,
        [Order(6), Description("Golem Ring")]
        GolemRing,
        [Order(7), Description("Frosty Ring")]
        FrostyRing,
        [Order(8), Description("Ivy Amulet")]
        IvyAmulet,
        [Order(9), Description("Gold Bracelet")]
        GoldBracelet,
        [Order(10), Description("Shield Ring")]
        ShieldRing,
        [Order(11), Description("Lazuli Vambrace")]
        LazuliVambrace,
        [Order(12), Description("Guardian Ring")]
        GuardianRing,
        [Order(13), Description("Vambrace")]
        Vambrace,
        [Order(14), Description("Ninja Gloves")]
        NinjaGloves,
        [Order(15), Description("Dragon Coil")]
        DragonCoil,
        [Order(16), Description("Watcher Ring")]
        WatcherRing,
        [Order(17), Description("Imp's Ring")]
        ImpsRing,
        [Order(18), Description("Amulet Ring")]
        AmuletRing,
        [Order(0), Description("Wristband")]
        Wristband,
    }

    public enum BodyGearType {
        [Order, Description("Overalls")]
        Overalls = 22,
        [Order, Description("Kung Fu Suit")]
        KungFuSuit,
        [Order, Description("Minor Robe")]
        MinorRobe,
        [Order, Description("Chain Vest")]
        ChainVest,
        [Order, Description("Spiky Suit")]
        SpikySuit,
        [Order, Description("Kung Fu Dress")]
        KungFuDress,
        [Order, Description("Fancy Overalls")]
        FancyOveralls,
        [Order, Description("Chest Guard")]
        ChestGuard,
        [Order, Description("Golden Vest")]
        GoldenVest,
        [Order, Description("Ruby Vest")]
        RubyVest,
        [Order, Description("Tiger Suit")]
        TigerSuit,
        [Order, Description("Tiger Two-Piece")]
        TigerTwoPiece,
        [Order, Description("Magical Armour")]
        MagicalArmour,
        [Order, Description("Tortoise Mail")]
        TortoiseMail,
        [Order, Description("Flower Suit")]
        FlowerSuit,
        [Order, Description("Battle Suit")]
        BattleSuit,
        [Order, Description("Vestguard")]
        Vestguard,
        [Order, Description("Vampire Cape")]
        VampireCape,
        [Order, Description("Power Suit")]
        PowerSuit,
        [Order, Description("Faerie Cloak")]
        FaerieCloak,
    }

    public enum CharacterType {
        Boy,
        Girl,
        Sprite,
    }

    public enum HeadGearType {
        [Order, Description("Bandana")]
        Bandana = 1,
        [Order, Description("Hair Ribbon")]
        HairRibbon,
        [Order, Description("Rabite Cap")]
        RabiteCap,
        [Order, Description("Head Gear")]
        HeadGear,
        [Order, Description("Quill Cap")]
        QuillCap,
        [Order, Description("Steel Cap")]
        SteelCap,
        [Order, Description("Golden Tiara")]
        GoldenTiara,
        [Order, Description("Raccoon Cap")]
        RaccoonCap,
        [Order, Description("Quilted Hood")]
        QuiltedHood,
        [Order, Description("Tiger Cap")]
        TigerCap,
        [Order, Description("Circlet")]
        Circlet,
        [Order, Description("Ruby Armet")]
        RubyArmet, // Not available in the game
        [Order, Description("Unicorn Helm")]
        UnicornHelm,
        [Order, Description("Dragon Helm")]
        DragonHelm,
        [Order, Description("Duck Helm")]
        DuckHelm,
        [Order, Description("Needle Helm")]
        NeedleHelm,
        [Order, Description("Cockatrice Cap")]
        CockatriceCap,
        [Order, Description("Amulet Helm")]
        AmuletHelm,
        [Order, Description("Griffin Helm")]
        GriffinHelm,
        [Order, Description("Faerie Crown")]
        FaerieCrown,
    }

    public enum ItemType {
        [Order, Description("Candy")]
        Candy = 0,
        [Order, Description("Chocolate")]
        Chocolate,
        [Order, Description("Royal Jam")]
        RoyalJam,
        [Order, Description("Faerie Walnut")]
        FaerieWalnut,
        [Order, Description("Medical Herb")]
        MedicalHerb,
        [Order, Description("Cup of Wishes")]
        CupOfWishes,
        [Order, Description("Magic Rope")]
        MagicRope,
        [Order, Description("Flammie Drum")]
        FlammieDrum,
        [Order, Description("Moogle Belt")]
        MoogleBelt,
        [Order, Description("Minor Mallet")]
        MinorMallet,
        [Order, Description("Barrel")]
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
        Gloves = 0,
        Sword,
        Axe,
        Spear,
        Whip,
        Bow,
        Boomerang,
        Javelin,
    }
}
