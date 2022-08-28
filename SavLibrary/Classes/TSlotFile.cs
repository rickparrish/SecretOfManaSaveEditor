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
        public List<HeadGearType> HeadGear { 
            get {
                return TPlayerSaveData.Heads;
            }
        }
    }
}
