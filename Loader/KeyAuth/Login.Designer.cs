namespace KeyAuth
{
	// Token: 0x0200000D RID: 13
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006C RID: 108 RVA: 0x0000646C File Offset: 0x0000646C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00006494 File Offset: 0x00006494
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Login_Load_1);
            this.ResumeLayout(false);

		}

		// Token: 0x04000032 RID: 50
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000033 RID: 51
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x04000034 RID: 52
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;

		// Token: 0x04000035 RID: 53
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox2;

		// Token: 0x04000036 RID: 54
		private global::Siticone.UI.WinForms.SiticoneTransition siticoneTransition1;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000039 RID: 57
		private global::Siticone.UI.WinForms.SiticoneRoundedButton LoginBtn;

		// Token: 0x0400003A RID: 58
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm;

		// Token: 0x0400003B RID: 59
		private global::Siticone.UI.WinForms.SiticoneRoundedTextBox key;

		// Token: 0x0400003C RID: 60
		private global::Siticone.UI.WinForms.SiticoneRoundedTextBox password;

		// Token: 0x0400003D RID: 61
		private global::Siticone.UI.WinForms.SiticoneRoundedTextBox username;

		// Token: 0x0400003E RID: 62
		private global::Siticone.UI.WinForms.SiticoneRoundedButton RgstrBtn;
	}
}
