namespace SecretOfManaSaveEditor.Forms {
    partial class MainForm {
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
            this.components = new System.ComponentModel.Container();
            this.lblSaveEditor = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.pbItems = new System.Windows.Forms.PictureBox();
            this.pbArmour = new System.Windows.Forms.PictureBox();
            this.pbStats = new System.Windows.Forms.PictureBox();
            this.pbWeapons = new System.Windows.Forms.PictureBox();
            this.pbSpirits = new System.Windows.Forms.PictureBox();
            this.pbGear = new System.Windows.Forms.PictureBox();
            this.cmsPresets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMinimum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModerate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaximum = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArmour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpirits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGear)).BeginInit();
            this.cmsPresets.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSaveEditor
            // 
            this.lblSaveEditor.AutoSize = true;
            this.lblSaveEditor.BackColor = System.Drawing.Color.Transparent;
            this.lblSaveEditor.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveEditor.ForeColor = System.Drawing.Color.White;
            this.lblSaveEditor.Location = new System.Drawing.Point(12, 159);
            this.lblSaveEditor.Name = "lblSaveEditor";
            this.lblSaveEditor.Size = new System.Drawing.Size(206, 38);
            this.lblSaveEditor.TabIndex = 0;
            this.lblSaveEditor.Text = "Save Editor";
            this.lblSaveEditor.Click += new System.EventHandler(this.lblSaveEditor_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.BackColor = System.Drawing.Color.Transparent;
            this.lblFilename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilename.ForeColor = System.Drawing.Color.White;
            this.lblFilename.Location = new System.Drawing.Point(12, 359);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(49, 13);
            this.lblFilename.TabIndex = 1;
            this.lblFilename.Text = "Filename";
            this.lblFilename.Click += new System.EventHandler(this.lblFilename_Click);
            // 
            // pbItems
            // 
            this.pbItems.BackColor = System.Drawing.Color.Transparent;
            this.pbItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItems.Image = global::SecretOfManaSaveEditor.Properties.Resources.Icon_Items;
            this.pbItems.Location = new System.Drawing.Point(7, 233);
            this.pbItems.Name = "pbItems";
            this.pbItems.Size = new System.Drawing.Size(100, 100);
            this.pbItems.TabIndex = 2;
            this.pbItems.TabStop = false;
            this.pbItems.Click += new System.EventHandler(this.pbItems_Click);
            // 
            // pbArmour
            // 
            this.pbArmour.BackColor = System.Drawing.Color.Transparent;
            this.pbArmour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbArmour.Image = global::SecretOfManaSaveEditor.Properties.Resources.Icon_Armour;
            this.pbArmour.Location = new System.Drawing.Point(162, 233);
            this.pbArmour.Name = "pbArmour";
            this.pbArmour.Size = new System.Drawing.Size(100, 100);
            this.pbArmour.TabIndex = 3;
            this.pbArmour.TabStop = false;
            this.pbArmour.Click += new System.EventHandler(this.pbArmour_Click);
            // 
            // pbStats
            // 
            this.pbStats.BackColor = System.Drawing.Color.Transparent;
            this.pbStats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStats.Image = global::SecretOfManaSaveEditor.Properties.Resources.Icon_Stats;
            this.pbStats.Location = new System.Drawing.Point(317, 233);
            this.pbStats.Name = "pbStats";
            this.pbStats.Size = new System.Drawing.Size(100, 100);
            this.pbStats.TabIndex = 4;
            this.pbStats.TabStop = false;
            this.pbStats.Click += new System.EventHandler(this.pbStats_Click);
            // 
            // pbWeapons
            // 
            this.pbWeapons.BackColor = System.Drawing.Color.Transparent;
            this.pbWeapons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbWeapons.Image = global::SecretOfManaSaveEditor.Properties.Resources.Icon_Weapons;
            this.pbWeapons.Location = new System.Drawing.Point(472, 233);
            this.pbWeapons.Name = "pbWeapons";
            this.pbWeapons.Size = new System.Drawing.Size(100, 100);
            this.pbWeapons.TabIndex = 5;
            this.pbWeapons.TabStop = false;
            this.pbWeapons.Click += new System.EventHandler(this.pbWeapons_Click);
            // 
            // pbSpirits
            // 
            this.pbSpirits.BackColor = System.Drawing.Color.Transparent;
            this.pbSpirits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSpirits.Image = global::SecretOfManaSaveEditor.Properties.Resources.Icon_Spirits;
            this.pbSpirits.Location = new System.Drawing.Point(627, 233);
            this.pbSpirits.Name = "pbSpirits";
            this.pbSpirits.Size = new System.Drawing.Size(100, 100);
            this.pbSpirits.TabIndex = 6;
            this.pbSpirits.TabStop = false;
            this.pbSpirits.Click += new System.EventHandler(this.pbSpirits_Click);
            // 
            // pbGear
            // 
            this.pbGear.BackColor = System.Drawing.Color.Transparent;
            this.pbGear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbGear.Image = global::SecretOfManaSaveEditor.Properties.Resources.Icon_Gear;
            this.pbGear.Location = new System.Drawing.Point(782, 233);
            this.pbGear.Name = "pbGear";
            this.pbGear.Size = new System.Drawing.Size(100, 100);
            this.pbGear.TabIndex = 7;
            this.pbGear.TabStop = false;
            this.pbGear.Click += new System.EventHandler(this.pbGear_Click);
            // 
            // cmsPresets
            // 
            this.cmsPresets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMinimum,
            this.tsmiModerate,
            this.tsmiMaximum});
            this.cmsPresets.Name = "cmsPresets";
            this.cmsPresets.Size = new System.Drawing.Size(181, 70);
            // 
            // tsmiMinimum
            // 
            this.tsmiMinimum.Name = "tsmiMinimum";
            this.tsmiMinimum.Size = new System.Drawing.Size(180, 22);
            this.tsmiMinimum.Text = "Minimum Cheating";
            this.tsmiMinimum.Click += new System.EventHandler(this.tsmiMinimum_Click);
            // 
            // tsmiModerate
            // 
            this.tsmiModerate.Name = "tsmiModerate";
            this.tsmiModerate.Size = new System.Drawing.Size(180, 22);
            this.tsmiModerate.Text = "Moderate Cheating";
            this.tsmiModerate.Click += new System.EventHandler(this.tsmiModerate_Click);
            // 
            // tsmiMaximum
            // 
            this.tsmiMaximum.Name = "tsmiMaximum";
            this.tsmiMaximum.Size = new System.Drawing.Size(180, 22);
            this.tsmiMaximum.Text = "Maximum Cheating";
            this.tsmiMaximum.Click += new System.EventHandler(this.tsmiMaximum_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SecretOfManaSaveEditor.Properties.Resources.Header;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(894, 377);
            this.Controls.Add(this.pbGear);
            this.Controls.Add(this.pbSpirits);
            this.Controls.Add(this.pbWeapons);
            this.Controls.Add(this.pbStats);
            this.Controls.Add(this.pbArmour);
            this.Controls.Add(this.pbItems);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.lblSaveEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secret of Mana 3D Remake - Save Editor";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArmour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpirits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGear)).EndInit();
            this.cmsPresets.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSaveEditor;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.PictureBox pbItems;
        private System.Windows.Forms.PictureBox pbArmour;
        private System.Windows.Forms.PictureBox pbStats;
        private System.Windows.Forms.PictureBox pbWeapons;
        private System.Windows.Forms.PictureBox pbSpirits;
        private System.Windows.Forms.PictureBox pbGear;
        private System.Windows.Forms.ContextMenuStrip cmsPresets;
        private System.Windows.Forms.ToolStripMenuItem tsmiMinimum;
        private System.Windows.Forms.ToolStripMenuItem tsmiModerate;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaximum;
    }
}