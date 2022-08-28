using System.Collections.Generic;

namespace SavLibrary {
    public class TScriptData {
        internal int StoryId;
        internal int MagManaFlg;
        internal int Bgm;
        internal int ManaCastleFlag;
        internal List<int> ScPlayedTalkEvent;
        internal List<int> ScUnplayedTalkEvent;
        internal List<int> ScVal;
        internal long FramieLanded;
        internal int FramieRideOffPosType;
        internal int FramieSubLv;
        internal int FramieMainLv;
        internal int FramieUse;
        internal int FramieDownFlg;
        internal int SaveDataLoadFlg;
        internal int RopeFlgRetNo;
        internal int RopeUse;
        internal int RopeFlgNo;
        internal int RopePosY;
        internal int RopePosX;
        internal string RopeMapFile;
        internal int ScHexValNum;
        internal int ScNumValNum;
        internal int ScAllValNum;
    }
}