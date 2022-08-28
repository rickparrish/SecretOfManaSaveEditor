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
    }
}
