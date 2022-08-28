using System.Collections.Generic;

namespace SavLibrary {
    public class TSerializableSettingData {
        internal byte configDeviceInput;
        internal List<int> configMouse;
        internal List<int> configKeyboard;
        internal List<int> configResolution;
        internal int configCommand3;
        internal int configCommand2;
        internal int configCommand1;
        internal int configCommand0;
        internal byte isControllerVibration;
        internal int itemLimit;
        internal byte isDisplayMinimap;
        internal int textLang;
        internal byte soundSourceType;
        internal int voiceVolume;
        internal int sfxVolume;
        internal int bgmVolume;
    }
}