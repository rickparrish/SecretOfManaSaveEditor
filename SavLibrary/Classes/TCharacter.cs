// TODOY Maybe have Get and Set methods when a List is involved, to ensure
//       the counts don't change (or for gear, that they stay within acceptable lengths)
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

        public List<int> MagicExperience {
            get {
                return magicEXP;
            }
        }

        public List<int> WeaponExperience { 
            get {
                return weaponEXP;
            }
        }
    }
}