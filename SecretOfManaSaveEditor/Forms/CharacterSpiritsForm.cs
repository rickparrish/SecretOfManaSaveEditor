using SavLibrary;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SecretOfManaSaveEditor.Forms {
    public partial class CharacterSpiritsForm : Form {

        private TSlotFile sav;
        private TCharacter character;
        private CharacterType characterType;

        public CharacterSpiritsForm(TSlotFile sav) {
            InitializeComponent();

            this.sav = sav;

            this.ClientSize = new Size(925, 430);

            UpdateDisplay(CharacterType.Girl);
        }

        private void lblLevel_Click(object sender, EventArgs e) {
            var lbl = (Label)sender;
            var spirit = Enums.Parse<SpiritType>(lbl.Tag.ToString());

            if (!sav.GetSpirit(spirit)) {
                if (MessageBox.Show($"You don't have {lbl.Tag}'s power yet.  Do you want to add it?", $"Edit {lbl.Tag}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }

                sav.SetSpirit(spirit, true);
            }

            if (Globals.InputNumber($"Enter a new {lbl.Tag} value\r\nEvery 100 is a new level", $"Edit {lbl.Tag}", character.GetMagicExperience(spirit), 0, 899, out int newValue)) {
                character.SetMagicExperience(spirit, newValue);
                UpdateDisplay();
            }
        }

        private void pbGirl_Click(object sender, EventArgs e) {
            BackgroundImage = Properties.Resources.Spirits_Girl;
            UpdateDisplay(CharacterType.Girl);
        }

        private void pbSprite_Click(object sender, EventArgs e) {
            BackgroundImage = Properties.Resources.Spirits_Sprite;
            UpdateDisplay(CharacterType.Sprite);
        }

        private void UpdateDisplay(CharacterType? newCharacterType = null) {
            if (newCharacterType.HasValue) {
                characterType = newCharacterType.Value;
            }

            character = sav.GetCharacter(characterType);

            foreach (SpiritType spirit in Enum.GetValues(typeof(SpiritType))) {
                var pb = (ProgressBar)this.Controls.Find($"pb{spirit}", false).Single();
                var lblLevel = (Label)this.Controls.Find($"lbl{spirit}Level", false).Single();
                var lblProgress = (Label)this.Controls.Find($"lbl{spirit}Progress", false).Single();

                lblLevel.Text = sav.GetSpirit(spirit) ? $"Level {character.GetMagicExperience(spirit) / 100}" : "N/A";
                if (character.GetMagicExperience(spirit) == 899) {
                    pb.Value = 100;
                    lblProgress.Text = $"Max";
                } else {
                    pb.Value = character.GetMagicExperience(spirit) % 100;
                    lblProgress.Text = $"{pb.Value}%";
                }
            }

            lblShadeLevel.Visible = characterType == CharacterType.Sprite;
            lblShadeProgress.Visible = characterType == CharacterType.Sprite;
            pbShade.Visible = characterType == CharacterType.Sprite;
            
            lblLuminaLevel.Visible = characterType == CharacterType.Girl;
            lblLuminaProgress.Visible = characterType == CharacterType.Girl;
            pbLumina.Visible = characterType == CharacterType.Girl;

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
