namespace KeyAuth
{
	// Token: 0x0200000C RID: 12
	public partial class Main : global::System.Windows.Forms.Form
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00004F6A File Offset: 0x00004F6A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004F90 File Offset: 0x00004F90
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Siticone.UI.AnimatorNS.Animation animation = new global::Siticone.UI.AnimatorNS.Animation();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KeyAuth.Main));
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneControlBox1 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.siticoneControlBox2 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.siticoneTransition1 = new global::Siticone.UI.WinForms.SiticoneTransition();
			this.label1 = new global::System.Windows.Forms.Label();
			this.siticonePanel3 = new global::Siticone.UI.WinForms.SiticonePanel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.siticoneRoundedButton5 = new global::Siticone.UI.WinForms.SiticoneRoundedButton();
			this.siticoneRoundedButton4 = new global::Siticone.UI.WinForms.SiticoneRoundedButton();
			this.siticoneRoundedButton2 = new global::Siticone.UI.WinForms.SiticoneRoundedButton();
			this.siticonePanel4 = new global::Siticone.UI.WinForms.SiticonePanel();
			this.time = new global::Siticone.UI.WinForms.SiticoneLabel();
			this.mainpanel = new global::Siticone.UI.WinForms.SiticonePanel();
			this.siticoneShadowForm = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.siticonePanel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.siticonePanel4.SuspendLayout();
			base.SuspendLayout();
			this.siticoneDragControl1.TargetControl = this;
			this.siticoneControlBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.siticoneControlBox1.BorderRadius = 10;
			this.siticoneTransition1.SetDecoration(this.siticoneControlBox1, 0);
			this.siticoneControlBox1.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.siticoneControlBox1.HoveredState.FillColor = global::System.Drawing.Color.FromArgb(232, 17, 35);
			this.siticoneControlBox1.HoveredState.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.Location = new global::System.Drawing.Point(760, 4);
			this.siticoneControlBox1.Name = "siticoneControlBox1";
			this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.Size = new global::System.Drawing.Size(45, 29);
			this.siticoneControlBox1.TabIndex = 1;
			this.siticoneControlBox1.Click += new global::System.EventHandler(this.siticoneControlBox1_Click);
			this.siticoneControlBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.siticoneControlBox2.BorderRadius = 10;
			this.siticoneControlBox2.ControlBoxType = 0;
			this.siticoneTransition1.SetDecoration(this.siticoneControlBox2, 0);
			this.siticoneControlBox2.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.siticoneControlBox2.HoveredState.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox2.Location = new global::System.Drawing.Point(715, 4);
			this.siticoneControlBox2.Name = "siticoneControlBox2";
			this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.Size = new global::System.Drawing.Size(45, 29);
			this.siticoneControlBox2.TabIndex = 2;
			this.siticoneTransition1.AnimationType = 1;
			this.siticoneTransition1.Cursor = null;
			animation.AnimateOnlyDifferences = true;
			animation.BlindCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.BlindCoeff");
			animation.LeafCoeff = 0f;
			animation.MaxTime = 1f;
			animation.MinTime = 0f;
			animation.MosaicCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.MosaicCoeff");
			animation.MosaicShift = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.MosaicShift");
			animation.MosaicSize = 0;
			animation.Padding = new global::System.Windows.Forms.Padding(50);
			animation.RotateCoeff = 1f;
			animation.RotateLimit = 0f;
			animation.ScaleCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.ScaleCoeff");
			animation.SlideCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.SlideCoeff");
			animation.TimeCoeff = 0f;
			animation.TransparencyCoeff = 1f;
			this.siticoneTransition1.DefaultAnimation = animation;
			this.label1.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label1, 0);
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Light", 10f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(-1, 136);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(0, 19);
			this.label1.TabIndex = 22;
			this.siticonePanel3.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.siticonePanel3.BorderColor = global::System.Drawing.Color.White;
			this.siticonePanel3.Controls.Add(this.label2);
			this.siticonePanel3.Controls.Add(this.pictureBox1);
			this.siticonePanel3.Controls.Add(this.siticoneRoundedButton5);
			this.siticonePanel3.Controls.Add(this.siticoneRoundedButton4);
			this.siticonePanel3.Controls.Add(this.siticoneRoundedButton2);
			this.siticoneTransition1.SetDecoration(this.siticonePanel3, 0);
			this.siticonePanel3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.siticonePanel3.Location = new global::System.Drawing.Point(0, 36);
			this.siticonePanel3.Name = "siticonePanel3";
			this.siticonePanel3.ShadowDecoration.Parent = this.siticonePanel3;
			this.siticonePanel3.Size = new global::System.Drawing.Size(219, 389);
			this.siticonePanel3.TabIndex = 42;
			this.label2.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label2, 0);
			this.label2.Font = new global::System.Drawing.Font("Microsoft YaHei", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(23, 361);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(175, 19);
			this.label2.TabIndex = 46;
			this.label2.Text = "Made By Project Medusa";
			this.siticoneTransition1.SetDecoration(this.pictureBox1, 0);
			this.pictureBox1.Image = global::Loader.Properties.Resources.ProjectMedusa_removebg_preview;
			this.pictureBox1.Location = new global::System.Drawing.Point(-22, 210);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(266, 145);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 45;
			this.pictureBox1.TabStop = false;
			this.siticoneRoundedButton5.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneRoundedButton5.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.siticoneRoundedButton5.CheckedState.Parent = this.siticoneRoundedButton5;
			this.siticoneRoundedButton5.CustomImages.Parent = this.siticoneRoundedButton5;
			this.siticoneTransition1.SetDecoration(this.siticoneRoundedButton5, 0);
			this.siticoneRoundedButton5.FillColor = global::System.Drawing.Color.White;
			this.siticoneRoundedButton5.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.siticoneRoundedButton5.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneRoundedButton5.HoveredState.Parent = this.siticoneRoundedButton5;
			this.siticoneRoundedButton5.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneRoundedButton5.Image");
			this.siticoneRoundedButton5.ImageOffset = new global::System.Drawing.Point(-8, 0);
			this.siticoneRoundedButton5.ImageSize = new global::System.Drawing.Size(30, 30);
			this.siticoneRoundedButton5.Location = new global::System.Drawing.Point(12, 108);
			this.siticoneRoundedButton5.Name = "siticoneRoundedButton5";
			this.siticoneRoundedButton5.ShadowDecoration.Parent = this.siticoneRoundedButton5;
			this.siticoneRoundedButton5.Size = new global::System.Drawing.Size(199, 45);
			this.siticoneRoundedButton5.TabIndex = 42;
			this.siticoneRoundedButton5.Text = "System Spoofer";
			this.siticoneRoundedButton5.UseTransparentBackground = true;
			this.siticoneRoundedButton5.Click += new global::System.EventHandler(this.siticoneRoundedButton5_Click);
			this.siticoneRoundedButton4.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneRoundedButton4.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.siticoneRoundedButton4.CheckedState.Parent = this.siticoneRoundedButton4;
			this.siticoneRoundedButton4.CustomImages.Parent = this.siticoneRoundedButton4;
			this.siticoneTransition1.SetDecoration(this.siticoneRoundedButton4, 0);
			this.siticoneRoundedButton4.FillColor = global::System.Drawing.Color.White;
			this.siticoneRoundedButton4.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.siticoneRoundedButton4.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneRoundedButton4.HoveredState.Parent = this.siticoneRoundedButton4;
			this.siticoneRoundedButton4.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneRoundedButton4.Image");
			this.siticoneRoundedButton4.ImageOffset = new global::System.Drawing.Point(-10, 0);
			this.siticoneRoundedButton4.ImageSize = new global::System.Drawing.Size(25, 25);
			this.siticoneRoundedButton4.Location = new global::System.Drawing.Point(12, 57);
			this.siticoneRoundedButton4.Name = "siticoneRoundedButton4";
			this.siticoneRoundedButton4.ShadowDecoration.Parent = this.siticoneRoundedButton4;
			this.siticoneRoundedButton4.Size = new global::System.Drawing.Size(199, 45);
			this.siticoneRoundedButton4.TabIndex = 41;
			this.siticoneRoundedButton4.Text = "Game Spoofer";
			this.siticoneRoundedButton4.UseTransparentBackground = true;
			this.siticoneRoundedButton4.Click += new global::System.EventHandler(this.siticoneRoundedButton4_Click);
			this.siticoneRoundedButton2.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneRoundedButton2.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.siticoneRoundedButton2.CheckedState.Parent = this.siticoneRoundedButton2;
			this.siticoneRoundedButton2.CustomImages.Parent = this.siticoneRoundedButton2;
			this.siticoneTransition1.SetDecoration(this.siticoneRoundedButton2, 0);
			this.siticoneRoundedButton2.FillColor = global::System.Drawing.Color.White;
			this.siticoneRoundedButton2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.siticoneRoundedButton2.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneRoundedButton2.HoveredState.Parent = this.siticoneRoundedButton2;
			this.siticoneRoundedButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneRoundedButton2.Image");
			this.siticoneRoundedButton2.ImageOffset = new global::System.Drawing.Point(-15, 0);
			this.siticoneRoundedButton2.ImageSize = new global::System.Drawing.Size(25, 25);
			this.siticoneRoundedButton2.Location = new global::System.Drawing.Point(12, 6);
			this.siticoneRoundedButton2.Name = "siticoneRoundedButton2";
			this.siticoneRoundedButton2.ShadowDecoration.Parent = this.siticoneRoundedButton2;
			this.siticoneRoundedButton2.Size = new global::System.Drawing.Size(199, 45);
			this.siticoneRoundedButton2.TabIndex = 0;
			this.siticoneRoundedButton2.Text = "Dashboard";
			this.siticoneRoundedButton2.UseTransparentBackground = true;
			this.siticoneRoundedButton2.Click += new global::System.EventHandler(this.siticoneRoundedButton2_Click);
			this.siticonePanel4.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.siticonePanel4.BorderColor = global::System.Drawing.Color.White;
			this.siticonePanel4.Controls.Add(this.time);
			this.siticoneTransition1.SetDecoration(this.siticonePanel4, 0);
			this.siticonePanel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.siticonePanel4.Location = new global::System.Drawing.Point(0, 0);
			this.siticonePanel4.Name = "siticonePanel4";
			this.siticonePanel4.ShadowDecoration.Parent = this.siticonePanel4;
			this.siticonePanel4.Size = new global::System.Drawing.Size(809, 36);
			this.siticonePanel4.TabIndex = 0;
			this.siticonePanel4.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.siticonePanel4_MouseDown);
			this.time.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneTransition1.SetDecoration(this.time, 0);
			this.time.Font = new global::System.Drawing.Font("Yu Gothic UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.time.ForeColor = global::System.Drawing.Color.White;
			this.time.Location = new global::System.Drawing.Point(12, 7);
			this.time.Name = "time";
			this.time.Size = new global::System.Drawing.Size(68, 23);
			this.time.TabIndex = 0;
			this.time.Text = "Loading...";
			this.siticoneTransition1.SetDecoration(this.mainpanel, 0);
			this.mainpanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.mainpanel.Location = new global::System.Drawing.Point(219, 36);
			this.mainpanel.Name = "mainpanel";
			this.mainpanel.ShadowDecoration.Parent = this.mainpanel;
			this.mainpanel.Size = new global::System.Drawing.Size(590, 389);
			this.mainpanel.TabIndex = 43;
			this.timer1.Enabled = true;
			this.timer1.Interval = 5;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = global::System.Windows.Forms.AutoValidate.Disable;
			this.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			base.ClientSize = new global::System.Drawing.Size(809, 425);
			base.Controls.Add(this.mainpanel);
			base.Controls.Add(this.siticonePanel3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.siticoneControlBox2);
			base.Controls.Add(this.siticoneControlBox1);
			base.Controls.Add(this.siticonePanel4);
			this.siticoneTransition1.SetDecoration(this, 1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Main";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Loader";
			base.TransparencyKey = global::System.Drawing.Color.Maroon;
			base.Load += new global::System.EventHandler(this.Main_Load);
			this.siticonePanel3.ResumeLayout(false);
			this.siticonePanel3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.siticonePanel4.ResumeLayout(false);
			this.siticonePanel4.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400001C RID: 28
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400001D RID: 29
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x0400001E RID: 30
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;

		// Token: 0x0400001F RID: 31
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox2;

		// Token: 0x04000020 RID: 32
		private global::Siticone.UI.WinForms.SiticoneTransition siticoneTransition1;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000022 RID: 34
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x04000024 RID: 36
		private global::Siticone.UI.WinForms.SiticonePanel siticonePanel3;

		// Token: 0x04000025 RID: 37
		private global::Siticone.UI.WinForms.SiticonePanel siticonePanel4;

		// Token: 0x04000026 RID: 38
		private global::Siticone.UI.WinForms.SiticonePanel mainpanel;

		// Token: 0x04000027 RID: 39
		private global::Siticone.UI.WinForms.SiticoneRoundedButton siticoneRoundedButton2;

		// Token: 0x04000028 RID: 40
		private global::Siticone.UI.WinForms.SiticoneLabel time;

		// Token: 0x04000029 RID: 41
		private global::Siticone.UI.WinForms.SiticoneRoundedButton siticoneRoundedButton4;

		// Token: 0x0400002A RID: 42
		private global::Siticone.UI.WinForms.SiticoneRoundedButton siticoneRoundedButton5;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Label label2;
	}
}
