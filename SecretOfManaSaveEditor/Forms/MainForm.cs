using SavLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SecretOfManaSaveEditor.Forms {
    public partial class MainForm : Form {
        private bool didBackup = false;
        private TSlotFile sav;

        public MainForm() {
            InitializeComponent();
        }

        private void AddBestArmour() {
            sav.SetArmGear(new ArmGearType[] { ArmGearType.FaeriesRing, ArmGearType.FaeriesRing, ArmGearType.FaeriesRing });
            sav.SetBodyGear(new BodyGearType[] { BodyGearType.PowerSuit, BodyGearType.FaerieCloak, BodyGearType.FaerieCloak });
            sav.SetHeadGear(new HeadGearType[] { HeadGearType.GriffinHelm, HeadGearType.FaerieCrown, HeadGearType.FaerieCrown });
        }

        private void lblSaveEditor_Click(object sender, EventArgs e) {
            using (var form = new AchievementForm(sav)) {
                form.ShowDialog();
                Save();
            }
        }

        private bool LoadFile() {
            using (var dialog = new OpenFileDialog()) {
                dialog.CheckFileExists = true;
                if (Debugger.IsAttached) {
                    dialog.Filter = "SAV files (*.sav)|*.sav|All files (*.*)|*.*";
                    dialog.InitialDirectory = @"C:\Users\Rick\OneDrive\Game Saves\_Secret of Mana Editor Saves";
                } else {
                    dialog.Filter = "SAV files (slot_*.sav)|slot_*.sav|All files (*.*)|*.*";
                    dialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"My Games\Secret of Mana");
                }
                dialog.Multiselect = false;
                dialog.Title = "Select the save file you would like to edit";

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.Text = $"Secret of Mana 3D Remake - Save Editor - {Path.GetFileName(dialog.FileName)}";
                    lblFilename.Text = dialog.FileName;

                    sav = SavConvert.DeserializeFile<TSlotFile>(dialog.FileName);
                    didBackup = false;

                    return true;
                }
            }

            return false;
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            if (!LoadFile()) {
                Application.Exit();
            }
        }

        private void pbArmour_Click(object sender, EventArgs e) {
            using (var form = new ArmourForm(sav)) {
                form.ShowDialog();
                Save();
            }
        }

        private void pbItems_Click(object sender, EventArgs e) {
            using (var form = new ItemsForm(sav)) {
                form.ShowDialog();
                Save();
            }
        }

        private void pbSpirits_Click(object sender, EventArgs e) {
            using (var form = new CharacterSpiritsForm(sav)) {
                form.ShowDialog();
                Save();
            }
        }

        private void pbStats_Click(object sender, EventArgs e) {
            using (var form = new CharacterStatsForm(sav)) {
                form.ShowDialog();
                Save();
            }
        }

        private void pbWeapons_Click(object sender, EventArgs e) {
            using (var form = new CharacterWeaponsForm(sav)) {
                form.ShowDialog();
                Save();
            }
        }

        private void lblFilename_Click(object sender, EventArgs e) {
            LoadFile();
        }

        private void pbGear_Click(object sender, EventArgs e) {
            cmsPresets.Show(Cursor.Position);
        }

        private void Save() {
            // Backup the original save file, if we haven't done that yet this session
            if (!didBackup) {
                if (!Debugger.IsAttached) {
                    File.Copy(lblFilename.Text, $"{lblFilename.Text}-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.bak");
                }
                didBackup = true;
            }

            SavConvert.SerializeFile(lblFilename.Text, sav);
        }

        private void tsmiMaximum_Click(object sender, EventArgs e) {
            string prompt = "" +
                "Using this preset will make the following changes:\r\n" +
                " - Add the Girl and Sprite to the party\r\n" +
                " - Set all party members to level 99\r\n" +
                " - Give 9,999,999 gold\r\n" +
                " - Give all items (99 for multiple-carry items)\r\n" +
                " - Add all 8 weapons and level them to 9 for each party member\r\n" +
                "   - Sword will be level 7 or 8 depending on if you've visited Watts yet\r\n" +
                " - Synchronize with 7 of 8 mana seeds\r\n" +
                "   - You must manually acquire the Earth seed to restore Sprite's memory\r\n" +
                " - Add all 8 spirits and level them to 8.99 for each party member\r\n" +
                " - Add best armour to inventory (must equip manually afterwards)\r\n" +
                "\r\n" +
                "This is currently untested and may break your game if you receive some items too early\r\n" +
                "\r\n" +
                "Are you sure you want to continue?";
            if (MessageBox.Show(prompt, "Confirm Maximum Cheating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                sav.GirlJoinedParty = true;
                sav.SpriteJoinedParty = true;

                UpgradeCharactersToLevel99();

                sav.Money = 9999999;

                foreach (ItemType item in Enum.GetValues(typeof(ItemType))) {
                    sav.SetItemCount(item, item.GetMax());
                }

                foreach (WeaponType weapon in Enum.GetValues(typeof(WeaponType))) {
                    int level = 9;
                    int experience = 899;

                    // If we haven't visited Watts yet, then set the sword to level 7 so he upgrades it to level 8
                    // If we have visited Watts, then we can set the sword to level 8
                    // Setting the sword to level 9 locks it to the boy, so we don't max that one out
                    if (weapon == WeaponType.Sword) {
                        bool seenWatts = sav.GetAchievement_Characters()[8]; // 8 = Watts
                        level = seenWatts ? 8 : 7;
                        experience = seenWatts ? 800 : 700;
                    }

                    sav.SetWeaponLevel(weapon, level);
                    sav.SetWeaponPower(weapon, 9);
                    sav.GetCharacter(CharacterType.Boy).SetWeaponExperience(weapon, experience);
                    sav.GetCharacter(CharacterType.Girl).SetWeaponExperience(weapon, experience);
                    sav.GetCharacter(CharacterType.Sprite).SetWeaponExperience(weapon, experience);
                }

                foreach (ManaSeedType manaSeed in Enum.GetValues(typeof(ManaSeedType))) {
                    // Skip giving the Earth seed, because Sprite won't get his memory back
                    if (manaSeed != ManaSeedType.Earth) {
                        sav.SetManaSeed(manaSeed, true);
                    }
                }

                foreach (SpiritType spirit in Enum.GetValues(typeof(SpiritType))) {
                    sav.SetSpirit(spirit, true);
                    sav.GetCharacter(CharacterType.Girl).SetMagicExperience(spirit, 899);
                    sav.GetCharacter(CharacterType.Sprite).SetMagicExperience(spirit, 899);
                }

                AddBestArmour();
                Save();
            }
        }

        private void tsmiMinimum_Click(object sender, EventArgs e) {
            string prompt = "" +
                "Using this preset will make the following changes:\r\n" +
                " - Increase the weapon level for current party member(s) to each weapon's current max\r\n" +
                " - Increase the spirit level for current party member(s) to the current mana seed count\r\n" +
                "\r\n" +
                "Are you sure you want to continue?";
            if (MessageBox.Show(prompt, "Confirm Maximum Cheating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                UpgradeAcquiredWeapons();
                UpgradeAcquiredSpirits();
                Save();
            }
        }

        private void tsmiModerate_Click(object sender, EventArgs e) {
            string prompt = "" +
                "Using this preset will make the following changes:\r\n" +
                " - Set current party member(s) to level 99\r\n" +
                " - Give 9,999,999 gold\r\n" +
                " - Give 99 of the multiple-carry items\r\n" +
                " - Increase the weapon level for current party member(s) to each weapon's current max\r\n" +
                " - Increase the spirit level for current party member(s) to the current mana seed count\r\n" +
                " - Add best armour to inventory (must equip manually afterwards)\r\n" +
                "\r\n" +
                "Are you sure you want to continue?";
            if (MessageBox.Show(prompt, "Confirm Maximum Cheating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                UpgradeCharactersToLevel99();

                sav.Money = 9999999;

                foreach (ItemType item in Enum.GetValues(typeof(ItemType))) {
                    sav.SetItemCount(item, item.GetMax());
                }

                UpgradeAcquiredWeapons();
                UpgradeAcquiredSpirits();
                AddBestArmour();
                Save();
            }
        }

        private void UpgradeCharactersToLevel99() {
            sav.GetCharacter(CharacterType.Boy).Experience = 9999999;
            if (sav.GirlJoinedParty) {
                sav.GetCharacter(CharacterType.Girl).Experience = 9999999;
            }
            if (sav.SpriteJoinedParty) {
                sav.GetCharacter(CharacterType.Sprite).Experience = 9999999;
            }
        }

        private void UpgradeAcquiredSpirits() {
            foreach (SpiritType spirit in Enum.GetValues(typeof(SpiritType))) {
                if (sav.GetSpirit(spirit)) {
                    int experience = sav.ManaSeedCount == 8 ? 899 : sav.ManaSeedCount * 100;
                    if (sav.GirlJoinedParty) {
                        sav.GetCharacter(CharacterType.Girl).SetMagicExperience(spirit, experience);
                    }
                    if (sav.SpriteJoinedParty) {
                        sav.GetCharacter(CharacterType.Sprite).SetMagicExperience(spirit, experience);
                    }
                }
            }
        }

        private void UpgradeAcquiredWeapons() {
            foreach (WeaponType weapon in Enum.GetValues(typeof(WeaponType))) {
                int orbs = sav.GetWeaponPower(weapon);
                if (orbs > 0) {
                    int experience = orbs == 9 ? 899 : orbs * 100;
                    sav.SetWeaponLevel(weapon, orbs);
                    sav.GetCharacter(CharacterType.Boy).SetWeaponExperience(weapon, experience);
                    if (sav.GirlJoinedParty) {
                        sav.GetCharacter(CharacterType.Girl).SetWeaponExperience(weapon, experience);
                    }
                    if (sav.SpriteJoinedParty) {
                        sav.GetCharacter(CharacterType.Sprite).SetWeaponExperience(weapon, experience);
                    }
                }
            }
        }
    }
}
