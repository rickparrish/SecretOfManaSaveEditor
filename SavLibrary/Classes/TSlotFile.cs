// TODOY Maybe have Get and Set methods when a List is involved, to ensure
//       the counts don't change (or for gear, that they stay within acceptable lengths)
using System.Collections.Generic;

namespace SavLibrary {
    public class TSlotFile {
        internal TSerializableGameSettingData TSerializableGameSettingData;
        internal TScriptData TScriptData;
        internal TPlayerSaveData TPlayerSaveData;

        public List<ArmGearType> ArmGear { 
            get {
                return TPlayerSaveData.Arms;
            }
        }
        public List<BodyGearType> BodyGear {
            get {
                return TPlayerSaveData.Bodies;
            }
        }

        public List<TCharacter> Characters {
            get {
                return TPlayerSaveData.Characters;
            }
        }

        public bool GirlJoinedParty {
            get {
                return TPlayerSaveData.isJoinParty[(int)CharacterType.Girl] != 0;
            }
            set {
                TPlayerSaveData.isJoinParty[(int)CharacterType.Girl] = 1;
            }
        }

        public List<HeadGearType> HeadGear { 
            get {
                return TPlayerSaveData.Heads;
            }
        }

        public List<int> Items {
            get {
                return TPlayerSaveData.Items;
            }
        }

        // TODOY Would be better handled as an array instead of a bitmask, or with Get and Set functions
        public int ManaSeeds {
            get {
                return TPlayerSaveData.manaEnergyBall_forView;
            }
            set {
                TPlayerSaveData.manaEnergyBall_forView = value;
                TPlayerSaveData.manaEnergyBall = value;
                TPlayerSaveData.manaEnergy = value;
            }
        }

        public int Money {
            get {
                return TPlayerSaveData.money;
            }
            set {
                TPlayerSaveData.money = value;
            }
        }

        public bool SpriteJoinedParty {
            get {
                return TPlayerSaveData.isJoinParty[(int)CharacterType.Sprite] != 0;
            }
            set {
                TPlayerSaveData.isJoinParty[(int)CharacterType.Sprite] = 1;
            }
        }

        /// <summary>
        /// How many times have the weapons been forged by Watts
        /// </summary>
        public List<int> WeaponLevel {
            get {
                return TPlayerSaveData.weaponLevel;
            }
        }

        /// <summary>
        /// How many orbs have been collected for the weapons
        /// </summary>
        public List<int> WeaponPower {
            get {
                return TPlayerSaveData.weaponPower;
            }
        }
    }
}
