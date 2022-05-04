namespace Loader
{
	// Token: 0x0200000F RID: 15
	public partial class dashboard : global::System.Windows.Forms.Form
	{
		// Token: 0x06000075 RID: 117 RVA: 0x000075E4 File Offset: 0x000075E4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00007604 File Offset: 0x00007604
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // dashboard
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "dashboard";
            this.Load += new System.EventHandler(this.dashboard_Load_1);
            this.ResumeLayout(false);

		}

		// Token: 0x0400003F RID: 63
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000040 RID: 64
		private global::Siticone.UI.WinForms.SiticonePanel siticonePanel2;

		// Token: 0x04000041 RID: 65
		private global::Siticone.UI.WinForms.SiticoneRoundedButton siticoneRoundedButton3;

		// Token: 0x04000042 RID: 66
		private global::Siticone.UI.WinForms.SiticoneRoundedButton siticoneRoundedButton1;

		// Token: 0x04000043 RID: 67
		private global::Siticone.UI.WinForms.SiticonePanel siticonePanel1;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.FontDialog fontDialog1;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.Label subscription;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.Label expiry;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.Label key;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.Timer timer1;
	}
}
