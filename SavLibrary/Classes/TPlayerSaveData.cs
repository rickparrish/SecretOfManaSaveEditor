using System.Collections.Generic;

namespace SavLibrary {
    public class TPlayerSaveData {
        internal int playTime;
        internal List<int> itemShortcut;
        internal List<int> db_arm;
        internal List<int> db_armor;
        internal List<int> db_head;
        internal List<int> db_weapon;
        internal List<int> db_monsters;
        internal List<int> db_characters;
        internal List<byte> isJoinParty;
        internal List<int> magicPower;
        internal List<int> weaponPower;
        internal List<int> weaponLevel;
        internal List<int> Items;
        internal List<int> ArmsRngCmd;
        internal List<int> BodiesRngCmd;
        internal List<int> HeadsRngCmd;
        internal List<ArmGearType> Arms;
        internal List<BodyGearType> Bodies;
        internal List<HeadGearType> Heads;
        internal List<TCharacter> Characters;
        internal int currrentMap;
        internal int money;
        internal int manaEnergyBall_forView;
        internal int manaEnergyBall;
        internal int manaEnergy;
    }
}