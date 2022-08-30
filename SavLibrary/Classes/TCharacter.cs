using System;
using System.Collections.Generic;
using System.Numerics;

namespace SavLibrary {
    public class TCharacter {
        internal int manaSwordTimer;
        internal int costumeID;
        internal byte defaultName;
        internal List<int> magicTimer;
        internal List<int> chrAiLevel;
        internal List<int> equips;
        internal int actionType;
        internal BigInteger pos;
        internal List<int> magicEXP;
        internal List<int> weaponEXP;
        internal int nextEXP;
        internal int EXP;
        internal int currentDamageCharge;
        internal int currentMP;
        internal int currentHP;
        internal string name;
        internal List<int> fl_s;
        internal int battleStatusFlag;
        internal int statusFlag;
        internal int level;

        public TCharacter(CharacterType characterType) {
            this.CharacterType = characterType;
        }

        // Can't be a property, or a hidden backing field will be created and picked up by Reflection when serializing/deserializing
        public CharacterType CharacterType;

        public int Experience {
            get {
                return EXP;
            }
            set {
                EXP = value;

                // Also set the amount of experience required to move to the next level
                // Thresholds are the same for boy, girl, and sprite, so not a problem that we hardcoded to Boy below
                Level level = ExperienceFaq.GetLevelByExperience(CharacterType, value);
                if (level.Number == 99) {
                    nextEXP = 9999999;
                } else {
                    level = ExperienceFaq.GetLevel(CharacterType, level.Number + 1);
                    nextEXP = level.Experience;
                }
            }
        }

        public int ExperienceForNextLevel {
            get {
                return nextEXP;
            }
        }

        public int GetMagicExperience(SpiritType spirit) {
            return magicEXP[(int)spirit];
        }

        public int GetWeaponExperience(WeaponType weapon) {
            return weaponEXP[(int)weapon];
        }

        public int HitPoints {
            get {
                return currentHP;
            }
        }

        public Level Level {
            get {
                return ExperienceFaq.GetLevelByExperience(CharacterType, Experience);
            }
        }

        public int ManaPoints {
            get {
                return currentMP;
            }
        }

        public string Name {
            get {
                return name;
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentNullException(nameof(value), "Name cannot be null or whitespace");
                }
                if (value.Length > 8) {
                    throw new ArgumentOutOfRangeException(nameof(value), "Name cannot be longer than 8 characters");
                }
                name = value;
            }
        }

        public Level NextLevel {
            get {
                return Level.Number == 99 ? null : ExperienceFaq.GetLevel(CharacterType, Level.Number + 1);
            }
        }

        public void SetMagicExperience(SpiritType spirit, int experience) {
            magicEXP[(int)spirit] = experience;
        }

        public void SetWeaponExperience(WeaponType weapon, int experience) {
            weaponEXP[(int)weapon] = experience;
        }
    }
}