using SavLibrary;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SecretOfManaSaveEditor.Forms {
    public partial class ItemsForm : Form {
        private TSlotFile sav;

        public ItemsForm(TSlotFile sav) {
            InitializeComponent();

            this.sav = sav;

            this.ClientSize = new Size(500, 500);

            UpdateDisplay();
        }

        private void lblCount_Click(object sender, EventArgs e) {
            var lbl = (Label)sender;

            string enumName = lbl.Tag.ToString().Replace(" ", "");
            ItemType item = Enums.Parse<ItemType>(enumName);
            
            if (Globals.InputNumber($"Enter a new {lbl.Tag} count", $"Edit {lbl.Tag}", sav.GetItemCount(item), 0, item.GetMax(), out byte newValue)) {
                sav.SetItemCount(item, newValue);
                UpdateDisplay();
            }
        }

        private void UpdateDisplay() {
            foreach (ItemType item in Enum.GetValues(typeof(ItemType))) {
                var lbl = (Label)this.Controls.Find($"lbl{item}", false).Single();

                lbl.Text = sav.GetItemCount(item).ToString();
            }
        }
    }
}
