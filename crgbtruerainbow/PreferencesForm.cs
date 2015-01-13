using System;
using System.Drawing;
using System.Windows.Forms;

namespace crgbtruerainbow
{
	class PreferencesForm : Form
	{
		#region Designer Code

		private Button btnCancel;
		private Button btnOK;
		private Button btnApply;
		private NumericUpDown numUPS;
		private GroupBox grpSpeed;
		private Label lblSpeedPerc;
		private Label label5;
		private Label label4;
		private TrackBar trkSpeed;
		private GroupBox grpLength;
		private Label lblLengthPerc;
		private Label label6;
		private Label label7;
		private TrackBar trkLength;
		private ComboBox cboKeymap;
		private Label label2;
		private Label label1;

		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.numUPS = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.grpSpeed = new System.Windows.Forms.GroupBox();
			this.lblSpeedPerc = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.trkSpeed = new System.Windows.Forms.TrackBar();
			this.grpLength = new System.Windows.Forms.GroupBox();
			this.lblLengthPerc = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.trkLength = new System.Windows.Forms.TrackBar();
			this.cboKeymap = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numUPS)).BeginInit();
			this.grpSpeed.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).BeginInit();
			this.grpLength.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkLength)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(166, 331);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(85, 331);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Enabled = false;
			this.btnApply.Location = new System.Drawing.Point(247, 331);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// numUPS
			// 
			this.numUPS.Location = new System.Drawing.Point(277, 168);
			this.numUPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numUPS.Name = "numUPS";
			this.numUPS.Size = new System.Drawing.Size(45, 20);
			this.numUPS.TabIndex = 3;
			this.numUPS.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.numUPS.ValueChanged += new System.EventHandler(this.numUPS_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(168, 170);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Updates per second";
			// 
			// grpSpeed
			// 
			this.grpSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpSpeed.Controls.Add(this.lblSpeedPerc);
			this.grpSpeed.Controls.Add(this.label5);
			this.grpSpeed.Controls.Add(this.label4);
			this.grpSpeed.Controls.Add(this.trkSpeed);
			this.grpSpeed.Location = new System.Drawing.Point(12, 12);
			this.grpSpeed.Name = "grpSpeed";
			this.grpSpeed.Size = new System.Drawing.Size(310, 72);
			this.grpSpeed.TabIndex = 15;
			this.grpSpeed.TabStop = false;
			this.grpSpeed.Text = "Speed";
			// 
			// lblSpeedPerc
			// 
			this.lblSpeedPerc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSpeedPerc.Location = new System.Drawing.Point(104, 51);
			this.lblSpeedPerc.Name = "lblSpeedPerc";
			this.lblSpeedPerc.Size = new System.Drawing.Size(103, 13);
			this.lblSpeedPerc.TabIndex = 23;
			this.lblSpeedPerc.Text = "100%";
			this.lblSpeedPerc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(277, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(27, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "Fast";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "Slow";
			// 
			// trkSpeed
			// 
			this.trkSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trkSpeed.LargeChange = 50;
			this.trkSpeed.Location = new System.Drawing.Point(6, 19);
			this.trkSpeed.Maximum = 1000;
			this.trkSpeed.Minimum = 1;
			this.trkSpeed.Name = "trkSpeed";
			this.trkSpeed.Size = new System.Drawing.Size(298, 45);
			this.trkSpeed.TabIndex = 19;
			this.trkSpeed.TickFrequency = 100;
			this.trkSpeed.Value = 100;
			this.trkSpeed.Scroll += new System.EventHandler(this.trkSpeed_Scroll);
			this.trkSpeed.ValueChanged += new System.EventHandler(this.trkSpeed_Scroll);
			// 
			// grpLength
			// 
			this.grpLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpLength.Controls.Add(this.lblLengthPerc);
			this.grpLength.Controls.Add(this.label6);
			this.grpLength.Controls.Add(this.label7);
			this.grpLength.Controls.Add(this.trkLength);
			this.grpLength.Location = new System.Drawing.Point(12, 90);
			this.grpLength.Name = "grpLength";
			this.grpLength.Size = new System.Drawing.Size(310, 72);
			this.grpLength.TabIndex = 16;
			this.grpLength.TabStop = false;
			this.grpLength.Text = "Length";
			// 
			// lblLengthPerc
			// 
			this.lblLengthPerc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLengthPerc.Location = new System.Drawing.Point(104, 51);
			this.lblLengthPerc.Name = "lblLengthPerc";
			this.lblLengthPerc.Size = new System.Drawing.Size(103, 13);
			this.lblLengthPerc.TabIndex = 18;
			this.lblLengthPerc.Text = "100%";
			this.lblLengthPerc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(273, 51);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Long";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 51);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Short";
			// 
			// trkLength
			// 
			this.trkLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trkLength.LargeChange = 50;
			this.trkLength.Location = new System.Drawing.Point(6, 19);
			this.trkLength.Maximum = 1000;
			this.trkLength.Minimum = 1;
			this.trkLength.Name = "trkLength";
			this.trkLength.Size = new System.Drawing.Size(298, 45);
			this.trkLength.TabIndex = 15;
			this.trkLength.TickFrequency = 100;
			this.trkLength.Value = 100;
			this.trkLength.Scroll += new System.EventHandler(this.trkLength_Scroll);
			this.trkLength.ValueChanged += new System.EventHandler(this.trkLength_Scroll);
			// 
			// cboKeymap
			// 
			this.cboKeymap.FormattingEnabled = true;
			this.cboKeymap.Items.AddRange(new object[] {
            "US",
            "UK"});
			this.cboKeymap.Location = new System.Drawing.Point(277, 194);
			this.cboKeymap.Name = "cboKeymap";
			this.cboKeymap.Size = new System.Drawing.Size(45, 21);
			this.cboKeymap.TabIndex = 17;
			this.cboKeymap.SelectedValueChanged += new System.EventHandler(this.cboKeymap_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(194, 197);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "Force key map";
			// 
			// PreferencesForm
			// 
			this.ClientSize = new System.Drawing.Size(334, 366);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cboKeymap);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numUPS);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.grpSpeed);
			this.Controls.Add(this.grpLength);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "PreferencesForm";
			this.Text = "Corsair RGB True Rainbow";
			((System.ComponentModel.ISupportInitialize)(this.numUPS)).EndInit();
			this.grpSpeed.ResumeLayout(false);
			this.grpSpeed.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).EndInit();
			this.grpLength.ResumeLayout(false);
			this.grpLength.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkLength)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public PreferencesForm()
		{
			InitializeComponent();

			cboKeymap.SelectedIndex = 0;
		}

		protected void SaveSettings()
		{
			RegSettings settings = TrueRainbow.GetSettings();

			// Send data to settings.
			settings.WaveLength = trkLength.Value;
			settings.WaveSpeed  = trkSpeed.Value;
			settings.UpdateRate = (int)numUPS.Value;
			settings.KeyMap     = cboKeymap.SelectedIndex;

			// Save and apply.
			settings.Save();
			TrueRainbow.ApplySettings();
		}

		protected void LoadSettings()
		{
			RegSettings settings = TrueRainbow.GetSettings();

			// Load settings.
			settings.Load();

			// Apply data to form controls.
			trkLength.Value         = settings.WaveLength;
			trkSpeed.Value          = settings.WaveSpeed;
			numUPS.Value            = settings.UpdateRate;
			cboKeymap.SelectedIndex = settings.KeyMap;

			// Lock apply button until we change some values.
			LockApply();
		}

		protected void UnlockApply()
		{
			if (btnApply != null)
				btnApply.Enabled = true;
		}

		protected void LockApply()
		{
			if (btnApply != null)
				btnApply.Enabled = false;
		}

		protected override void OnShown(EventArgs e)
		{
			// Refresh settings.
			LoadSettings();

			base.OnShown(e);
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			// Don't close the form, just hide it.
			e.Cancel = true;
			Hide();

			base.OnClosing(e);
		}

		private void trkSpeed_Scroll(object sender, EventArgs e)
		{
			UnlockApply();

			// Update percentage label.
			lblSpeedPerc.Text = trkSpeed.Value.ToString() + "%";
		}

		private void trkLength_Scroll(object sender, EventArgs e)
		{
			UnlockApply();

			// Update percentage label.
			lblLengthPerc.Text = trkLength.Value.ToString() + "%";
		}

		private void numUPS_ValueChanged(object sender, EventArgs e)
		{
			UnlockApply();
		}

		private void cboKeymap_SelectedValueChanged(object sender, EventArgs e)
		{
			UnlockApply();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			SaveSettings();
			Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			// Save and apply settings.
			SaveSettings();
			LockApply();
		}
	}
}
