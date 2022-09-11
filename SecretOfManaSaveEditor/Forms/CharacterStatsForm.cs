using Microsoft.VisualBasic;
using SavLibrary;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SecretOfManaSaveEditor.Forms {
    public partial class CharacterStatsForm : Form {

        private TSlotFile sav;
        private TCharacter character;
        private CharacterType characterType;

        public CharacterStatsForm(TSlotFile sav) {
            InitializeComponent();

            this.sav = sav;

            this.ClientSize = new Size(925, 455);

            UpdateDisplay(CharacterType.Boy);
        }

        private void lblEXP_Click(object sender, EventArgs e) {
            if (Globals.InputNumber("Enter a new EXP value", "Edit EXP", character.Experience, 0, 9999999, out int newValue)) {
                character.Experience = newValue;
                UpdateDisplay();
            }
        }

        private void lblLevel_Click(object sender, EventArgs e) {
            if (Globals.InputNumber("Enter a new Level value", "Edit Level", character.Level.Number, 1, 99, out int newValue)) {
                SavLibrary.Level level = ExperienceFaq.GetLevel(characterType, newValue);
                character.Experience = level.Experience;
                UpdateDisplay();
            }
        }

        private void lblMoney_Click(object sender, EventArgs e) {
            if (Globals.InputNumber("Enter a new Money value", "Edit Money", sav.Money, 0, 9999999, out int newValue)) {
                sav.Money = newValue;
                UpdateDisplay();
            }
        }

        private void lblName_Click(object sender, EventArgs e) {
            string newName = Interaction.InputBox($"Enter a new Name (max 8 characters)", "Edit Name", character.Name);
            if (!string.IsNullOrWhiteSpace(newName)) {
                if (newName.Length <= 8) {
                    character.Name = newName;
                    UpdateDisplay();
                } else {
                    MessageBox.Show($"Sorry, new name must be less than or equal to 8 characters and you entered {newName.Length}", "Edit Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pbBoy_Click(object sender, EventArgs e) {
            BackgroundImage = Properties.Resources.Stats_Boy;
            UpdateDisplay(CharacterType.Boy);
        }

        private void pbManaSeed_Click(object sender, EventArgs e) {
            var pb = (PictureBox)sender;
            var manaSeed = Enums.Parse<ManaSeedType>(pb.Tag.ToString());

            sav.SetManaSeed(manaSeed, !sav.GetManaSeed(manaSeed));
            UpdateDisplay();
        }

        private void pbGirl_Click(object sender, EventArgs e) {
            if (!sav.GirlJoinedParty) {
                if (MessageBox.Show($"Primm isn't a member of your party.  Do you want to add her?", $"Edit Primm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }

                sav.GirlJoinedParty = true;
                sav.SetWeaponPower(WeaponType.Gloves, 1);
            }

            BackgroundImage = Properties.Resources.Stats_Girl;
            UpdateDisplay(CharacterType.Girl);
        }

        private void pbSprite_Click(object sender, EventArgs e) {
            if (!sav.SpriteJoinedParty) {
                if (MessageBox.Show($"Popoi isn't a member of your party.  Do you want to add them?", $"Edit Popoi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }

                sav.SpriteJoinedParty = true;
                sav.SetWeaponPower(WeaponType.Boomerang, 1);
            }

            BackgroundImage = Properties.Resources.Stats_Sprite;
            UpdateDisplay(CharacterType.Sprite);
        }

        private void UpdateDisplay(CharacterType? newCharacterType = null) {
            if (newCharacterType.HasValue) {
                characterType = newCharacterType.Value;
            }

            character = sav.GetCharacter(characterType);

            lblLevel.Text = character.Level.Number.ToString();
            lblEXP.Text = character.Experience.ToString("N0");

            Level nextLevel = character.NextLevel;
            if (nextLevel == null) {
                lblNextLevelIn.Text = "N/A";
                pbNextLevelIn.Maximum = 1;
                pbNextLevelIn.Value = 1;
            } else {
                lblNextLevelIn.Text = (character.ExperienceForNextLevel - character.Experience).ToString("N0");
                pbNextLevelIn.Maximum = character.ExperienceForNextLevel - character.Level.Experience;
                pbNextLevelIn.Value = character.Experience - character.Level.Experience;
            }

            lblHP.Text = $"{character.HitPoints}/{character.Level.HitPoints}";
            pbHP.Maximum = character.Level.HitPoints;
            pbHP.Value = character.HitPoints;

            if (characterType == CharacterType.Boy) {
                pbMP.Visible = false;
                lblMP.Visible = false;
            } else {
                pbMP.Maximum = character.Level.ManaPoints;
                pbMP.Value = character.ManaPoints;
                pbMP.Visible = true;

                lblMP.Text = $"{character.ManaPoints}/{character.Level.ManaPoints}";
                lblMP.Visible = true;
            }

            lblMoney.Text = $"{sav.Money:N0} GP";

            foreach (ManaSeedType manaSeed in Enum.GetValues(typeof(ManaSeedType))) {
                var pb = (PictureBox)this.Controls.Find($"pb{manaSeed}", false).Single();

                pb.Image = sav.GetManaSeed(manaSeed) ? null : (Image)Properties.Resources.Mana_Seed_Blank;
            }

            lblStrength.Text = character.Level.Strength.ToString();
            lblAgility.Text = character.Level.Agility.ToString();
            lblConstitution.Text = character.Level.Constitution.ToString();
            lblIntelligence.Text = character.Level.Intelligence.ToString();
            lblWisdom.Text = character.Level.Wisdom.ToString();

            lblAttack.Text = $"{character.Level.Strength} + Weapon Power"; // TODO Get equipped weapon power and add value to Strength
            lblHit.Text = $"{character.Level.Hit} %";
            lblDefense.Text = character.Level.Defense.ToString();
            lblEvade.Text = $"{character.Level.Evade} %";
            lblMagicDefense.Text = character.Level.MagicDefense.ToString();

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
    }
}
