namespace SecretOfManaSaveEditor.Forms {
    partial class ArmourForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gbArmGear = new System.Windows.Forms.GroupBox();
            this.flpArmGear = new System.Windows.Forms.FlowLayoutPanel();
            this.gbBodyGear = new System.Windows.Forms.GroupBox();
            this.flpBodyGear = new System.Windows.Forms.FlowLayoutPanel();
            this.gbHeadGear = new System.Windows.Forms.GroupBox();
            this.flpHeadGear = new System.Windows.Forms.FlowLayoutPanel();
            this.gbArmGear.SuspendLayout();
            this.gbBodyGear.SuspendLayout();
            this.gbHeadGear.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbArmGear
            // 
            this.gbArmGear.Controls.Add(this.flpArmGear);
            this.gbArmGear.ForeColor = System.Drawing.Color.White;
            this.gbArmGear.Location = new System.Drawing.Point(12, 12);
            this.gbArmGear.Name = "gbArmGear";
            this.gbArmGear.Size = new System.Drawing.Size(150, 320);
            this.gbArmGear.TabIndex = 0;
            this.gbArmGear.TabStop = false;
            this.gbArmGear.Text = "Arm Gear";
            // 
            // flpArmGear
            // 
            this.flpArmGear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpArmGear.Location = new System.Drawing.Point(3, 16);
            this.flpArmGear.Name = "flpArmGear";
            this.flpArmGear.Size = new System.Drawing.Size(144, 301);
            this.flpArmGear.TabIndex = 0;
            // 
            // gbBodyGear
            // 
            this.gbBodyGear.Controls.Add(this.flpBodyGear);
            this.gbBodyGear.ForeColor = System.Drawing.Color.White;
            this.gbBodyGear.Location = new System.Drawing.Point(168, 12);
            this.gbBodyGear.Name = "gbBodyGear";
            this.gbBodyGear.Size = new System.Drawing.Size(150, 320);
            this.gbBodyGear.TabIndex = 1;
            this.gbBodyGear.TabStop = false;
            this.gbBodyGear.Text = "Body Gear";
            // 
            // flpBodyGear
            // 
            this.flpBodyGear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBodyGear.Location = new System.Drawing.Point(3, 16);
            this.flpBodyGear.Name = "flpBodyGear";
            this.flpBodyGear.Size = new System.Drawing.Size(144, 301);
            this.flpBodyGear.TabIndex = 0;
            // 
            // gbHeadGear
            // 
            this.gbHeadGear.Controls.Add(this.flpHeadGear);
            this.gbHeadGear.ForeColor = System.Drawing.Color.White;
            this.gbHeadGear.Location = new System.Drawing.Point(324, 12);
            this.gbHeadGear.Name = "gbHeadGear";
            this.gbHeadGear.Size = new System.Drawing.Size(150, 320);
            this.gbHeadGear.TabIndex = 2;
            this.gbHeadGear.TabStop = false;
            this.gbHeadGear.Text = "Head Gear";
            // 
            // flpHeadGear
            // 
            this.flpHeadGear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpHeadGear.Location = new System.Drawing.Point(3, 16);
            this.flpHeadGear.Name = "flpHeadGear";
            this.flpHeadGear.Size = new System.Drawing.Size(144, 301);
            this.flpHeadGear.TabIndex = 0;
            // 
            // ArmourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(487, 345);
            this.Controls.Add(this.gbHeadGear);
            this.Controls.Add(this.gbBodyGear);
            this.Controls.Add(this.gbArmGear);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ArmourForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Armour";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArmourForm_FormClosing);
            this.gbArmGear.ResumeLayout(false);
            this.gbBodyGear.ResumeLayout(false);
            this.gbHeadGear.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArmGear;
        private System.Windows.Forms.FlowLayoutPanel flpArmGear;
        private System.Windows.Forms.GroupBox gbBodyGear;
        private System.Windows.Forms.FlowLayoutPanel flpBodyGear;
        private System.Windows.Forms.GroupBox gbHeadGear;
        private System.Windows.Forms.FlowLayoutPanel flpHeadGear;
    }
}