namespace SecretOfManaSaveEditor.Forms {
    partial class CharacterSpiritsForm {
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
            this.pbGirl = new System.Windows.Forms.PictureBox();
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.pbBoy = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSalamandoLevel = new System.Windows.Forms.Label();
            this.pbSalamando = new System.Windows.Forms.ProgressBar();
            this.lblSalamandoProgress = new System.Windows.Forms.Label();
            this.lblGnomeProgress = new System.Windows.Forms.Label();
            this.pbGnome = new System.Windows.Forms.ProgressBar();
            this.lblGnomeLevel = new System.Windows.Forms.Label();
            this.lblLunaProgress = new System.Windows.Forms.Label();
            this.pbLuna = new System.Windows.Forms.ProgressBar();
            this.lblLunaLevel = new System.Windows.Forms.Label();
            this.lblUndineProgress = new System.Windows.Forms.Label();
            this.pbUndine = new System.Windows.Forms.ProgressBar();
            this.lblUndineLevel = new System.Windows.Forms.Label();
            this.lblSylphidProgress = new System.Windows.Forms.Label();
            this.pbSylphid = new System.Windows.Forms.ProgressBar();
            this.lblSylphidLevel = new System.Windows.Forms.Label();
            this.lblDryadProgress = new System.Windows.Forms.Label();
            this.pbDryad = new System.Windows.Forms.ProgressBar();
            this.lblDryadLevel = new System.Windows.Forms.Label();
            this.lblLuminaProgress = new System.Windows.Forms.Label();
            this.pbLumina = new System.Windows.Forms.ProgressBar();
            this.lblLuminaLevel = new System.Windows.Forms.Label();
            this.lblShadeProgress = new System.Windows.Forms.Label();
            this.pbShade = new System.Windows.Forms.ProgressBar();
            this.lblShadeLevel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGirl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoy)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGirl
            // 
            this.pbGirl.BackColor = System.Drawing.Color.Transparent;
            this.pbGirl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbGirl.Location = new System.Drawing.Point(711, 337);
            this.pbGirl.Name = "pbGirl";
            this.pbGirl.Size = new System.Drawing.Size(55, 54);
            this.pbGirl.TabIndex = 3;
            this.pbGirl.TabStop = false;
            this.pbGirl.Click += new System.EventHandler(this.pbGirl_Click);
            // 
            // pbSprite
            // 
            this.pbSprite.BackColor = System.Drawing.Color.Transparent;
            this.pbSprite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSprite.Location = new System.Drawing.Point(833, 337);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(55, 54);
            this.pbSprite.TabIndex = 5;
            this.pbSprite.TabStop = false;
            this.pbSprite.Click += new System.EventHandler(this.pbSprite_Click);
            // 
            // pbBoy
            // 
            this.pbBoy.BackColor = System.Drawing.Color.Transparent;
            this.pbBoy.Cursor = System.Windows.Forms.Cursors.No;
            this.pbBoy.Location = new System.Drawing.Point(772, 337);
            this.pbBoy.Name = "pbBoy";
            this.pbBoy.Size = new System.Drawing.Size(55, 54);
            this.pbBoy.TabIndex = 6;
            this.pbBoy.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(711, 394);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(177, 16);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSalamandoLevel
            // 
            this.lblSalamandoLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblSalamandoLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalamandoLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalamandoLevel.ForeColor = System.Drawing.Color.White;
            this.lblSalamandoLevel.Location = new System.Drawing.Point(92, 150);
            this.lblSalamandoLevel.Name = "lblSalamandoLevel";
            this.lblSalamandoLevel.Size = new System.Drawing.Size(60, 16);
            this.lblSalamandoLevel.TabIndex = 22;
            this.lblSalamandoLevel.Tag = "Salamando";
            this.lblSalamandoLevel.Text = "Level 0";
            this.lblSalamandoLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSalamandoLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // pbSalamando
            // 
            this.pbSalamando.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.pbSalamando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(191)))), ((int)(((byte)(41)))));
            this.pbSalamando.Location = new System.Drawing.Point(158, 151);
            this.pbSalamando.Name = "pbSalamando";
            this.pbSalamando.Size = new System.Drawing.Size(140, 15);
            this.pbSalamando.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbSalamando.TabIndex = 23;
            this.pbSalamando.Value = 50;
            // 
            // lblSalamandoProgress
            // 
            this.lblSalamandoProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblSalamandoProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalamandoProgress.ForeColor = System.Drawing.Color.White;
            this.lblSalamandoProgress.Location = new System.Drawing.Point(238, 132);
            this.lblSalamandoProgress.Name = "lblSalamandoProgress";
            this.lblSalamandoProgress.Size = new System.Drawing.Size(60, 16);
            this.lblSalamandoProgress.TabIndex = 24;
            this.lblSalamandoProgress.Text = "0%";
            this.lblSalamandoProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGnomeProgress
            // 
            this.lblGnomeProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblGnomeProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGnomeProgress.ForeColor = System.Drawing.Color.White;
            this.lblGnomeProgress.Location = new System.Drawing.Point(238, 51);
            this.lblGnomeProgress.Name = "lblGnomeProgress";
            this.lblGnomeProgress.Size = new System.Drawing.Size(60, 16);
            this.lblGnomeProgress.TabIndex = 27;
            this.lblGnomeProgress.Text = "0%";
            this.lblGnomeProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbGnome
            // 
            this.pbGnome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.pbGnome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(191)))), ((int)(((byte)(41)))));
            this.pbGnome.Location = new System.Drawing.Point(158, 70);
            this.pbGnome.Name = "pbGnome";
            this.pbGnome.Size = new System.Drawing.Size(140, 15);
            this.pbGnome.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbGnome.TabIndex = 26;
            this.pbGnome.Value = 50;
            // 
            // lblGnomeLevel
            // 
            this.lblGnomeLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblGnomeLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGnomeLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGnomeLevel.ForeColor = System.Drawing.Color.White;
            this.lblGnomeLevel.Location = new System.Drawing.Point(92, 69);
            this.lblGnomeLevel.Name = "lblGnomeLevel";
            this.lblGnomeLevel.Size = new System.Drawing.Size(60, 16);
            this.lblGnomeLevel.TabIndex = 25;
            this.lblGnomeLevel.Tag = "Gnome";
            this.lblGnomeLevel.Text = "Level 0";
            this.lblGnomeLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblGnomeLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // lblLunaProgress
            // 
            this.lblLunaProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblLunaProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunaProgress.ForeColor = System.Drawing.Color.White;
            this.lblLunaProgress.Location = new System.Drawing.Point(238, 210);
            this.lblLunaProgress.Name = "lblLunaProgress";
            this.lblLunaProgress.Size = new System.Drawing.Size(60, 16);
            this.lblLunaProgress.TabIndex = 30;
            this.lblLunaProgress.Text = "0%";
            this.lblLunaProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbLuna
            // 
            this.pbLuna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.pbLuna.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(191)))), ((int)(((byte)(41)))));
            this.pbLuna.Location = new System.Drawing.Point(158, 229);
            this.pbLuna.Name = "pbLuna";
            this.pbLuna.Size = new System.Drawing.Size(140, 15);
            this.pbLuna.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbLuna.TabIndex = 29;
            this.pbLuna.Value = 50;
            // 
            // lblLunaLevel
            // 
            this.lblLunaLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLunaLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLunaLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunaLevel.ForeColor = System.Drawing.Color.White;
            this.lblLunaLevel.Location = new System.Drawing.Point(92, 228);
            this.lblLunaLevel.Name = "lblLunaLevel";
            this.lblLunaLevel.Size = new System.Drawing.Size(60, 16);
            this.lblLunaLevel.TabIndex = 28;
            this.lblLunaLevel.Tag = "Luna";
            this.lblLunaLevel.Text = "Level 0";
            this.lblLunaLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblLunaLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // lblUndineProgress
            // 
            this.lblUndineProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblUndineProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUndineProgress.ForeColor = System.Drawing.Color.White;
            this.lblUndineProgress.Location = new System.Drawing.Point(537, 51);
            this.lblUndineProgress.Name = "lblUndineProgress";
            this.lblUndineProgress.Size = new System.Drawing.Size(60, 16);
            this.lblUndineProgress.TabIndex = 33;
            this.lblUndineProgress.Text = "0%";
            this.lblUndineProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbUndine
            // 
            this.pbUndine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.pbUndine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(191)))), ((int)(((byte)(41)))));
            this.pbUndine.Location = new System.Drawing.Point(457, 70);
            this.pbUndine.Name = "pbUndine";
            this.pbUndine.Size = new System.Drawing.Size(140, 15);
            this.pbUndine.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbUndine.TabIndex = 32;
            this.pbUndine.Value = 50;
            // 
            // lblUndineLevel
            // 
            this.lblUndineLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblUndineLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUndineLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUndineLevel.ForeColor = System.Drawing.Color.White;
            this.lblUndineLevel.Location = new System.Drawing.Point(391, 69);
            this.lblUndineLevel.Name = "lblUndineLevel";
            this.lblUndineLevel.Size = new System.Drawing.Size(60, 16);
            this.lblUndineLevel.TabIndex = 31;
            this.lblUndineLevel.Tag = "Undine";
            this.lblUndineLevel.Text = "Level 0";
            this.lblUndineLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblUndineLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // lblSylphidProgress
            // 
            this.lblSylphidProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblSylphidProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSylphidProgress.ForeColor = System.Drawing.Color.White;
            this.lblSylphidProgress.Location = new System.Drawing.Point(537, 132);
            this.lblSylphidProgress.Name = "lblSylphidProgress";
            this.lblSylphidProgress.Size = new System.Drawing.Size(60, 16);
            this.lblSylphidProgress.TabIndex = 36;
            this.lblSylphidProgress.Text = "0%";
            this.lblSylphidProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbSylphid
            // 
            this.pbSylphid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.pbSylphid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(191)))), ((int)(((byte)(41)))));
            this.pbSylphid.Location = new System.Drawing.Point(457, 151);
            this.pbSylphid.Name = "pbSylphid";
            this.pbSylphid.Size = new System.Drawing.Size(140, 15);
            this.pbSylphid.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbSylphid.TabIndex = 35;
            this.pbSylphid.Value = 50;
            // 
            // lblSylphidLevel
            // 
            this.lblSylphidLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblSylphidLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSylphidLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSylphidLevel.ForeColor = System.Drawing.Color.White;
            this.lblSylphidLevel.Location = new System.Drawing.Point(391, 150);
            this.lblSylphidLevel.Name = "lblSylphidLevel";
            this.lblSylphidLevel.Size = new System.Drawing.Size(60, 16);
            this.lblSylphidLevel.TabIndex = 34;
            this.lblSylphidLevel.Tag = "Sylphid";
            this.lblSylphidLevel.Text = "Level 0";
            this.lblSylphidLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSylphidLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // lblDryadProgress
            // 
            this.lblDryadProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblDryadProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDryadProgress.ForeColor = System.Drawing.Color.White;
            this.lblDryadProgress.Location = new System.Drawing.Point(537, 210);
            this.lblDryadProgress.Name = "lblDryadProgress";
            this.lblDryadProgress.Size = new System.Drawing.Size(60, 16);
            this.lblDryadProgress.TabIndex = 39;
            this.lblDryadProgress.Text = "0%";
            this.lblDryadProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbDryad
            // 
            this.pbDryad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.pbDryad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(191)))), ((int)(((byte)(41)))));
            this.pbDryad.Location = new System.Drawing.Point(457, 229);
            this.pbDryad.Name = "pbDryad";
            this.pbDryad.Size = new System.Drawing.Size(140, 15);
            this.pbDryad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDryad.TabIndex = 38;
            this.pbDryad.Value = 50;
            // 
            // lblDryadLevel
            // 
            this.lblDryadLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblDryadLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDryadLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDryadLevel.ForeColor = System.Drawing.Color.White;
            this.lblDryadLevel.Location = new System.Drawing.Point(391, 228);
            this.lblDryadLevel.Name = "lblDryadLevel";
            this.lblDryadLevel.Size = new System.Drawing.Size(60, 16);
            this.lblDryadLevel.TabIndex = 37;
            this.lblDryadLevel.Tag = "Dryad";
            this.lblDryadLevel.Text = "Level 0";
            this.lblDryadLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDryadLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // lblLuminaProgress
            // 
            this.lblLuminaProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblLuminaProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuminaProgress.ForeColor = System.Drawing.Color.White;
            this.lblLuminaProgress.Location = new System.Drawing.Point(537, 290);
            this.lblLuminaProgress.Name = "lblLuminaProgress";
            this.lblLuminaProgress.Size = new System.Drawing.Size(60, 16);
            this.lblLuminaProgress.TabIndex = 42;
            this.lblLuminaProgress.Text = "0%";
            this.lblLuminaProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbLumina
            // 
            this.pbLumina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.pbLumina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(191)))), ((int)(((byte)(41)))));
            this.pbLumina.Location = new System.Drawing.Point(457, 309);
            this.pbLumina.Name = "pbLumina";
            this.pbLumina.Size = new System.Drawing.Size(140, 15);
            this.pbLumina.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbLumina.TabIndex = 41;
            this.pbLumina.Value = 50;
            // 
            // lblLuminaLevel
            // 
            this.lblLuminaLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLuminaLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLuminaLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuminaLevel.ForeColor = System.Drawing.Color.White;
            this.lblLuminaLevel.Location = new System.Drawing.Point(391, 308);
            this.lblLuminaLevel.Name = "lblLuminaLevel";
            this.lblLuminaLevel.Size = new System.Drawing.Size(60, 16);
            this.lblLuminaLevel.TabIndex = 40;
            this.lblLuminaLevel.Tag = "Lumina";
            this.lblLuminaLevel.Text = "Level 0";
            this.lblLuminaLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblLuminaLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // lblShadeProgress
            // 
            this.lblShadeProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblShadeProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShadeProgress.ForeColor = System.Drawing.Color.White;
            this.lblShadeProgress.Location = new System.Drawing.Point(238, 290);
            this.lblShadeProgress.Name = "lblShadeProgress";
            this.lblShadeProgress.Size = new System.Drawing.Size(60, 16);
            this.lblShadeProgress.TabIndex = 45;
            this.lblShadeProgress.Text = "0%";
            this.lblShadeProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblShadeProgress.Visible = false;
            // 
            // pbShade
            // 
            this.pbShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(45)))));
            this.pbShade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(191)))), ((int)(((byte)(41)))));
            this.pbShade.Location = new System.Drawing.Point(158, 309);
            this.pbShade.Name = "pbShade";
            this.pbShade.Size = new System.Drawing.Size(140, 15);
            this.pbShade.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbShade.TabIndex = 44;
            this.pbShade.Value = 50;
            this.pbShade.Visible = false;
            // 
            // lblShadeLevel
            // 
            this.lblShadeLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblShadeLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShadeLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShadeLevel.ForeColor = System.Drawing.Color.White;
            this.lblShadeLevel.Location = new System.Drawing.Point(92, 308);
            this.lblShadeLevel.Name = "lblShadeLevel";
            this.lblShadeLevel.Size = new System.Drawing.Size(60, 16);
            this.lblShadeLevel.TabIndex = 43;
            this.lblShadeLevel.Tag = "Shade";
            this.lblShadeLevel.Text = "Level 0";
            this.lblShadeLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblShadeLevel.Visible = false;
            this.lblShadeLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // CharacterSpiritsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SecretOfManaSaveEditor.Properties.Resources.Spirits_Girl;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(924, 431);
            this.Controls.Add(this.lblShadeProgress);
            this.Controls.Add(this.pbShade);
            this.Controls.Add(this.lblShadeLevel);
            this.Controls.Add(this.lblLuminaProgress);
            this.Controls.Add(this.pbLumina);
            this.Controls.Add(this.lblLuminaLevel);
            this.Controls.Add(this.lblDryadProgress);
            this.Controls.Add(this.pbDryad);
            this.Controls.Add(this.lblDryadLevel);
            this.Controls.Add(this.lblSylphidProgress);
            this.Controls.Add(this.pbSylphid);
            this.Controls.Add(this.lblSylphidLevel);
            this.Controls.Add(this.lblUndineProgress);
            this.Controls.Add(this.pbUndine);
            this.Controls.Add(this.lblUndineLevel);
            this.Controls.Add(this.lblLunaProgress);
            this.Controls.Add(this.pbLuna);
            this.Controls.Add(this.lblLunaLevel);
            this.Controls.Add(this.lblGnomeProgress);
            this.Controls.Add(this.pbGnome);
            this.Controls.Add(this.lblGnomeLevel);
            this.Controls.Add(this.lblSalamandoProgress);
            this.Controls.Add(this.pbSalamando);
            this.Controls.Add(this.lblSalamandoLevel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbBoy);
            this.Controls.Add(this.pbSprite);
            this.Controls.Add(this.pbGirl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CharacterSpiritsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Character Spirits";
            ((System.ComponentModel.ISupportInitialize)(this.pbGirl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGirl;
        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.PictureBox pbBoy;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSalamandoLevel;
        private System.Windows.Forms.ProgressBar pbSalamando;
        private System.Windows.Forms.Label lblSalamandoProgress;
        private System.Windows.Forms.Label lblGnomeProgress;
        private System.Windows.Forms.ProgressBar pbGnome;
        private System.Windows.Forms.Label lblGnomeLevel;
        private System.Windows.Forms.Label lblLunaProgress;
        private System.Windows.Forms.ProgressBar pbLuna;
        private System.Windows.Forms.Label lblLunaLevel;
        private System.Windows.Forms.Label lblUndineProgress;
        private System.Windows.Forms.ProgressBar pbUndine;
        private System.Windows.Forms.Label lblUndineLevel;
        private System.Windows.Forms.Label lblSylphidProgress;
        private System.Windows.Forms.ProgressBar pbSylphid;
        private System.Windows.Forms.Label lblSylphidLevel;
        private System.Windows.Forms.Label lblDryadProgress;
        private System.Windows.Forms.ProgressBar pbDryad;
        private System.Windows.Forms.Label lblDryadLevel;
        private System.Windows.Forms.Label lblLuminaProgress;
        private System.Windows.Forms.ProgressBar pbLumina;
        private System.Windows.Forms.Label lblLuminaLevel;
        private System.Windows.Forms.Label lblShadeProgress;
        private System.Windows.Forms.ProgressBar pbShade;
        private System.Windows.Forms.Label lblShadeLevel;
    }
}