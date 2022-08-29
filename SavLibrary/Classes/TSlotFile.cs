namespace SavLibrary {
    public class TSlotFile {
        internal TSerializableGameSettingData TSerializableGameSettingData;
        internal TScriptData TScriptData;
        internal TPlayerSaveData TPlayerSaveData;

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

        public void SetArmGear(ArmGearType[] armGear) {
            TPlayerSaveData.Arms.Clear();
            TPlayerSaveData.Arms.AddRange(armGear);
        }

        public void SetBodyGear(BodyGearType[] bodyGear) {
            TPlayerSaveData.Bodies.Clear();
            TPlayerSaveData.Bodies.AddRange(bodyGear);
        }

        public void SetHeadGear(HeadGearType[] headGear) {
            TPlayerSaveData.Heads.Clear();
            TPlayerSaveData.Heads.AddRange(headGear);
        }

        public void SetItemCount(ItemType item, int count) {
            TPlayerSaveData.Items[(int)item] = count;
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
