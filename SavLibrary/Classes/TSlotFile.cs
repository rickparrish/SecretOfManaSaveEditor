using System;
using System.Linq;

namespace SavLibrary {
    public class TSlotFile {
        internal TSerializableGameSettingData TSerializableGameSettingData;
        internal TScriptData TScriptData;
        internal TPlayerSaveData TPlayerSaveData;

        public bool[] GetAchievement_ArmGear() {
            return TPlayerSaveData.db_arm.Select(x => x != 0).ToArray();
        }

        public bool[] GetAchievement_BodyGear() {
            return TPlayerSaveData.db_armor.Select(x => x != 0).ToArray();
        }

        public bool[] GetAchievement_Characters() {
            return TPlayerSaveData.db_characters.Select(x => x != 0).ToArray();
        }

        public bool[] GetAchievement_HeadGear() {
            return TPlayerSaveData.db_head.Select(x => x != 0).ToArray();
        }

        public bool[] GetAchievement_Monsters() {
            return TPlayerSaveData.db_monsters.Select(x => x != 0).ToArray();
        }

        public bool[] GetAchievement_Weapons() {
            return TPlayerSaveData.db_weapon.Select(x => x != 0).ToArray();
        }

        public ArmGearType[] GetArmGear() {
            return TPlayerSaveData.Arms.ToArray();
        }

        public BodyGearType[] GetBodyGear() {
            return TPlayerSaveData.Bodies.ToArray();
        }

        public TCharacter GetCharacter(CharacterType character) {
            return TPlayerSaveData.Characters[(int)character];
        }

        public HeadGearType[] GetHeadGear() {
            return TPlayerSaveData.Heads.ToArray();
        }

        public int GetItemCount(ItemType item) {
            return TPlayerSaveData.Items[(int)item];
        }

        public bool GetManaSeed(ManaSeedType manaSeed) {
            return (TPlayerSaveData.manaEnergyBall_forView & (byte)manaSeed) == (byte)manaSeed;
        }

        public bool GetSpirit(SpiritType spirit) {
            return TPlayerSaveData.magicPower[(int)spirit] != 0;
        }

        public int GetWeaponLevel(WeaponType weapon) {
            return TPlayerSaveData.weaponLevel[(int)weapon];
        }

        public int GetWeaponPower(WeaponType weapon) {
            return TPlayerSaveData.weaponPower[(int)weapon];
        }

        public bool GirlJoinedParty {
            get {
                return TPlayerSaveData.isJoinParty[(int)CharacterType.Girl] != 0;
            }
            set {
                TPlayerSaveData.isJoinParty[(int)CharacterType.Girl] = value ? (byte)1 : (byte)0;
            }
        }

        public int ManaSeedCount {
            get {
                int result = 0;

                foreach (ManaSeedType manaSeed in Enum.GetValues(typeof(ManaSeedType))) {
                    if (GetManaSeed(manaSeed)) {
                        result += 1;
                    }
                }

                return result;
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

        public void SetArmGear(ArmGearType[] armGear) {
            if (armGear.Length > 11) {
                throw new ArgumentOutOfRangeException(nameof(armGear), "Arm Gear cannot contain more than 11 items");
            }
            TPlayerSaveData.Arms.Clear();
            TPlayerSaveData.Arms.AddRange(armGear);
        }

        public void SetBodyGear(BodyGearType[] bodyGear) {
            if (bodyGear.Length > 11) {
                throw new ArgumentOutOfRangeException(nameof(bodyGear), "Body Gear cannot contain more than 11 items");
            }
            TPlayerSaveData.Bodies.Clear();
            TPlayerSaveData.Bodies.AddRange(bodyGear);
        }

        public void SetHeadGear(HeadGearType[] headGear) {
            if (headGear.Length > 11) {
                throw new ArgumentOutOfRangeException(nameof(headGear), "Head Gear cannot contain more than 11 items");
            }
            TPlayerSaveData.Heads.Clear();
            TPlayerSaveData.Heads.AddRange(headGear);
        }

        public void SetItemCount(ItemType item, int count) {
            TPlayerSaveData.Items[(int)item] = count;
        }

        public void SetManaSeed(ManaSeedType manaSeed, bool synchronized) {
            int value = TPlayerSaveData.manaEnergyBall_forView;

            if (synchronized) {
                value |= (byte)manaSeed;
            } else {
                value |= (byte)manaSeed;
                value -= (byte)manaSeed;
            }

            TPlayerSaveData.manaEnergyBall_forView = value;
            TPlayerSaveData.manaEnergyBall = value;
            TPlayerSaveData.manaEnergy = value;
        }

        public void SetSpirit(SpiritType spirit, bool met) {
            TPlayerSaveData.magicPower[(int)spirit] = met ? 1 : 0;
        }

        public void SetWeaponLevel(WeaponType weapon, int level) {
            TPlayerSaveData.weaponLevel[(int)weapon] = level;
        }

        public void SetWeaponPower(WeaponType weapon, int power) {
            TPlayerSaveData.weaponPower[(int)weapon] = power;
        }

        public bool SpriteJoinedParty {
            get {
                return TPlayerSaveData.isJoinParty[(int)CharacterType.Sprite] != 0;
            }
            set {
                TPlayerSaveData.isJoinParty[(int)CharacterType.Sprite] = value ? (byte)1 : (byte)0;
            }
        }
    }
}
