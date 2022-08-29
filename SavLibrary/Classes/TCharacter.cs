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

        public int Experience {
            get {
                return EXP;
            }
            set {
                EXP = value;
            }
        }

        public int GetMagicExperience(SpiritType spirit) {
            return magicEXP[(int)spirit];
        }

        public int GetWeaponExperience(WeaponType weapon) {
            return weaponEXP[(int)weapon];
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

        public void SetMagicExperience(SpiritType spirit, int experience) {
            magicEXP[(int)spirit] = experience;
        }

        public void SetWeaponExperience(WeaponType weapon, int experience) {
            weaponEXP[(int)weapon] = experience;
        }
    }
}