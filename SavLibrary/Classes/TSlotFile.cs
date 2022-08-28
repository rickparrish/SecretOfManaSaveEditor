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

        public int GetItemCount(ItemType item) {
            return TPlayerSaveData.Items[(int)item];
        }

        public bool GirlJoinedParty {
            get {
                return TPlayerSaveData.isJoinParty[(int)CharacterType.Girl] != 0;
            }
            set {
                TPlayerSaveData.isJoinParty[(int)CharacterType.Girl] = value ? (byte)1 : (byte)0;
            }
        }

        public List<HeadGearType> HeadGear { 
            get {
                return TPlayerSaveData.Heads;
            }
        }

        // TODOY Would be better handled as an array instead of a bitmask, or with Get and Set functions
        public int ManaSeedCount {
            get {
                // From: https://stackoverflow.com/a/12171691/342378
                int count = 0;
                int value = ManaSeeds;
                while (value != 0) {
                    count += 1;
                    value &= value - 1;
                }
                return count;
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

        public void SetItemCount(ItemType item, int count) {
            TPlayerSaveData.Items[(int)item] = count;
        }

        public List<int> Spirits {
            get {
                return TPlayerSaveData.magicPower;
            }
        }

        public bool SpriteJoinedParty {
            get {
                return TPlayerSaveData.isJoinParty[(int)CharacterType.Sprite] != 0;
            }
            set {
                TPlayerSaveData.isJoinParty[(int)CharacterType.Sprite] = value ? (byte)1 : (byte)0;
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
