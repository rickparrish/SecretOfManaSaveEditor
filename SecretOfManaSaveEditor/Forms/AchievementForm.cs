using SavLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SecretOfManaSaveEditor.Forms {
    public partial class AchievementForm : Form {
        private bool killedDreadSlime;
        private TSlotFile sav;

        public AchievementForm(TSlotFile sav) {
            InitializeComponent();

            this.sav = sav;

            // The Dread Slime is the second to last boss in the game, and the last boss you can kill and still leave the Mana Fortress
            // If the player has killed this boss, then they've pretty much completed the game, so we'll enable the checkboxes to allow
            // the player to tick off things they missed
            // index 112 is dread slime (and 113 is doom's wall and 114 = wall face and 120=jabberwocky)
            killedDreadSlime = sav.GetAchievement_Monsters()[112];

            AddCheckBoxes(flpArmGear, sav.GetAchievement_ArmGear(), Enums.GetDescriptions<ArmGearType>(false), 2);
            AddCheckBoxes(flpBodyGear, sav.GetAchievement_BodyGear(), Enums.GetDescriptions<BodyGearType>(false), 2);
            AddCheckBoxes(flpHeadGear, sav.GetAchievement_HeadGear(), Enums.GetDescriptions<HeadGearType>(false), 2);
            AddCheckBoxes(flpMonsters, sav.GetAchievement_Monsters(), null, 3);
        }

        private void AddCheckBoxes(FlowLayoutPanel panel, bool[] items, string[] itemNames, int width) {
            for (int i = 0; i < items.Length; i++) {
                var chk = new CheckBox() {
                    AutoSize = true,
                    Checked = items[i],
                    Cursor = killedDreadSlime ? Cursors.Hand : Cursors.No,
                    Font = new Font(FontFamily.GenericMonospace, 9, FontStyle.Bold),
                    ForeColor = items[i] ? Color.LightGreen : Color.Red,
                    Text = (i + 1).ToString().PadLeft(width, '0'),
                };
                chk.Click += CheckBox_Click;
                panel.Controls.Add(chk);

                if (itemNames != null) {
                    toolTip1.SetToolTip(chk, itemNames[i]);
                }
            }
        }

        private void CheckBox_Click(object sender, EventArgs e) {
            var chk = (CheckBox)sender;
            int index = int.Parse(chk.Text) - 1;

            if (killedDreadSlime) {
                switch (chk.Parent.Tag.ToString()) {
                    case "ArmGear":
                        sav.SetAchievement_ArmGear(index, chk.Checked);
                        break;
                    case "BodyGear":
                        sav.SetAchievement_BodyGear(index, chk.Checked);
                        break;
                    case "HeadGear":
                        sav.SetAchievement_HeadGear(index, chk.Checked);
                        break;
                    case "Monsters":
                        sav.SetAchievement_Monsters(index, chk.Checked);
                        break;
                    default:
                        throw new NotImplementedException($"Unexpected FlowLayoutPanel.Tag: {chk.Parent.Tag}");
                }

                chk.ForeColor = chk.Checked ? Color.LightGreen : Color.Red;
            } else {
                chk.Checked = !chk.Checked;
                MessageBox.Show("Sorry, you must kill the Dread Slime before you can click these checkboxes and edit these achievements", "Checkboxes Disabled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
