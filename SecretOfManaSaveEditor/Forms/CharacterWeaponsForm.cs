using SavLibrary;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SecretOfManaSaveEditor.Forms {
    public partial class CharacterWeaponsForm : Form {

        private TSlotFile sav;
        private TCharacter character;
        private CharacterType characterType;

        public CharacterWeaponsForm(TSlotFile sav) {
            InitializeComponent();

            this.sav = sav;

            this.ClientSize = new Size(925, 430);

            UpdateDisplay(CharacterType.Boy);
        }

        private void CharacterWeaponsForm_Paint(object sender, PaintEventArgs e) {
            UpdateProgressText();
        }

        private void lblLevel_Click(object sender, EventArgs e) {
            var lbl = (Label)sender;
            var weapon = Enums.Parse<WeaponType>(lbl.Tag.ToString());

            int weaponLevel = sav.GetWeaponLevel(weapon);
            int weaponPower = sav.GetWeaponPower(weapon);
            if (weaponPower == 0) {
                if (MessageBox.Show($"You don't have the {lbl.Tag} yet.  Do you want to add it?", $"Edit {lbl.Tag}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }
            }

            if (Globals.InputNumber($"Enter a new {lbl.Tag} value\r\nEvery 100 is a new level", $"Edit {lbl.Tag}", character.GetWeaponExperience(weapon), 0, 899, out int newValue)) {
                character.SetWeaponExperience(weapon, newValue);
                if (newValue == 899) {
                    sav.SetWeaponLevel(weapon, 9);
                    sav.SetWeaponPower(weapon, 9);
                } else {
                    if (newValue / 100 > weaponLevel) {
                        sav.SetWeaponLevel(weapon, newValue / 100);
                    }
                    if (newValue / 100 > weaponPower) {
                        sav.SetWeaponPower(weapon, newValue / 100);
                    }
                }
                UpdateDisplay();
            }
        }

        private void lblName_Click(object sender, EventArgs e) {
            var lbl = (Label)sender;
            var weapon = Enums.Parse<WeaponType>(lbl.Tag.ToString());

            int weaponPower = sav.GetWeaponPower(weapon);
            if (weaponPower == 0) {
                if (MessageBox.Show($"You don't have the {lbl.Tag} yet.  Do you want to add it?", $"Edit {lbl.Tag}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }

                sav.SetWeaponPower(weapon, 1);
                sav.SetWeaponLevel(weapon, 1);
            }

            if (Globals.InputNumber($"Enter a new {lbl.Tag} level", $"Edit {lbl.Tag}", weaponPower, 0, 9, out int newValue)) {
                sav.SetWeaponLevel(weapon, newValue);

                // Raise weapon power if it is lower than the level
                if (newValue > weaponPower) {
                    sav.SetWeaponPower(weapon, newValue);
                }

                UpdateDisplay();
            }
        }

        private void pbBoy_Click(object sender, EventArgs e) {
            BackgroundImage = Properties.Resources.Weapons_Boy;
            UpdateDisplay(CharacterType.Boy);
        }

        private void pbGirl_Click(object sender, EventArgs e) {
            BackgroundImage = Properties.Resources.Weapons_Girl;
            UpdateDisplay(CharacterType.Girl);
        }

        private void pbSprite_Click(object sender, EventArgs e) {
            BackgroundImage = Properties.Resources.Weapons_Sprite;
            UpdateDisplay(CharacterType.Sprite);
        }

        private void picOrbs_Click(object sender, EventArgs e) {
            var pic = (PictureBox)sender;
            var weapon = Enums.Parse<WeaponType>(pic.Tag.ToString());

            int weaponPower = sav.GetWeaponPower(weapon);
            if (weaponPower == 0) {
                if (MessageBox.Show($"You don't have the {pic.Tag} yet.  Do you want to add it?", $"Edit {pic.Tag}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }

                sav.SetWeaponPower(weapon, 1);
                sav.SetWeaponLevel(weapon, 1);
            }

            if (Globals.InputNumber($"Enter a new {pic.Tag} orb count", $"Edit {pic.Tag}", weaponPower, 0, 9, out int newValue)) {
                sav.SetWeaponPower(weapon, newValue);

                // Drop weapon level if it exceeds the orb count
                int weaponLevel = sav.GetWeaponLevel(weapon);
                if (newValue < weaponLevel) {
                    sav.SetWeaponLevel(weapon, newValue);
                }

                UpdateDisplay();
            }
        }

        private void UpdateDisplay(CharacterType? newCharacterType = null) {
            if (newCharacterType.HasValue) {
                characterType = newCharacterType.Value;
            }

            character = sav.GetCharacter(characterType);

            foreach (WeaponType weapon in Enum.GetValues(typeof(WeaponType))) {
                var lblLevel = (Label)this.Controls.Find($"lbl{weapon}Level", false).Single();
                var lblName = (Label)this.Controls.Find($"lbl{weapon}Name", false).Single();
                var pb = (ProgressBar)this.Controls.Find($"pb{weapon}", false).Single();
                var pic = (PictureBox)this.Controls.Find($"pic{weapon}", false).Single();

                int weaponExperience = character.GetWeaponExperience(weapon);
                int weaponLevel = sav.GetWeaponLevel(weapon);
                int weaponPower = sav.GetWeaponPower(weapon);

                lblLevel.Text = (weaponPower == 0) ? "" : $"Lvl {weaponExperience / 100}";
                lblName.ForeColor = (weaponPower == 9) ? Color.FromArgb(255, 87, 84) : Color.White;
                lblName.Text = (weaponLevel == 0) ? $"{weapon} (Not Acquired)" : $"{Enums.WeaponTypeNames[weapon][weaponLevel - 1]} (Level {weaponLevel})";
                pb.Value = weaponExperience == 899 ? 100 : weaponExperience % 100;
                pic.Image = (Image)Properties.Resources.ResourceManager.GetObject($"Weapon_Orbs_{Math.Min(8, weaponPower)}");
            }
            UpdateProgressText();

            if (string.IsNullOrWhiteSpace(character.Name)) {
                switch (characterType) {
                    case CharacterType.Boy:
                        lblName.Text = "Randi";
                        break;
                    case CharacterType.Girl:
                        lblName.Text = "Primm";
                        break;
                    case CharacterType.Sprite:
                        lblName.Text = "Popoi";
                        break;
                }
            } else {
                lblName.Text = character.Name;
            }
        }

        private void UpdateProgressText() {
            character = sav.GetCharacter(characterType);

            foreach (WeaponType weapon in Enum.GetValues(typeof(WeaponType))) {
                var pb = (ProgressBar)this.Controls.Find($"pb{weapon}", false).Single();

                string label = character.GetWeaponExperience(weapon) == 899 ? "Max" : $"{pb.Value}%";
                Font font = new Font("Microsoft Sans Serif", (float)9.0, FontStyle.Bold);

                var g = pb.CreateGraphics();
                SizeF labelSize = g.MeasureString(label, font);
                g.DrawString(label, font, Brushes.White, new PointF(pb.Width - labelSize.Width - 8, -2));
            }
        }
    }
}
