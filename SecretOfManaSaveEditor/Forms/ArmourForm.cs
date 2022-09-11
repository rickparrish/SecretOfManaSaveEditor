using SavLibrary;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SecretOfManaSaveEditor.Forms {
    public partial class ArmourForm : Form {

        private TSlotFile sav;

        public ArmourForm(TSlotFile sav) {
            InitializeComponent();

            this.sav = sav;

            AddComboBoxes(flpArmGear, sav.GetArmGear().Select(x => (int)x).ToArray(), Enums.GetDescriptionsAndValues<ArmGearType>(true));
            AddComboBoxes(flpBodyGear, sav.GetBodyGear().Select(x => (int)x).ToArray(), Enums.GetDescriptionsAndValues<BodyGearType>(true));
            AddComboBoxes(flpHeadGear, sav.GetHeadGear().Select(x => (int)x).ToArray(), Enums.GetDescriptionsAndValues<HeadGearType>(true));
        }

        private void AddComboBoxes(FlowLayoutPanel panel, int[] ownedItems, Dictionary<int, string> allItems) {
            // Can hold up to 11 of each armour type
            for (int i = 0; i < 11; i++) {
                // Create new BindingSource containing the keys and values of the armour type, and also add a "Nothing" option to the top of the list
                var bindingSource = new BindingSource(allItems, null);
                bindingSource.Insert(0, new KeyValuePair<int, string>(-1, "Nothing"));

                // Create the ComboBox and bind it to the binding source
                var cbo = new ComboBox() {
                    DataSource = bindingSource,
                    DisplayMember = "Value",
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    ValueMember = "Key",
                };

                // Set the position within the binding source if we own the gear in this combo box
                if (i < ownedItems.Length) {
                    var ownedItem = allItems.Single(x => x.Key == ownedItems[i]);
                    bindingSource.Position = bindingSource.IndexOf(ownedItem);
                } else {
                    bindingSource.Position = 0;
                }
                
                // Add to the form and set the width to fill the flow layout panel
                panel.Controls.Add(cbo);
                cbo.Width = cbo.Parent.Width - (cbo.Left * 2);
            }
        }

        private void ArmourForm_FormClosing(object sender, FormClosingEventArgs e) {
            var armGear = new List<ArmGearType>();
            var bodyGear = new List<BodyGearType>();
            var headGear = new List<HeadGearType>();

            for (int i = 0; i < 11; i++) {
                int armId = (int)((ComboBox)flpArmGear.Controls[i]).SelectedValue;
                if (armId > 0) {
                    armGear.Add((ArmGearType)armId);
                }

                int bodyId = (int)((ComboBox)flpBodyGear.Controls[i]).SelectedValue;
                if (bodyId > 0) {
                    bodyGear.Add((BodyGearType)bodyId);
                }

                int headId = (int)((ComboBox)flpHeadGear.Controls[i]).SelectedValue;
                if (headId > 0) {
                    headGear.Add((HeadGearType)headId);
                }
            }

            sav.SetArmGear(armGear.ToArray());
            sav.SetBodyGear(bodyGear.ToArray());
            sav.SetHeadGear(headGear.ToArray());
        }
    }
}
