using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using KeyAuth;
using Siticone.UI.WinForms;

namespace Loader
{
	// Token: 0x0200000F RID: 15
	public partial class dashboard : Form
	{
		// Token: 0x06000070 RID: 112 RVA: 0x000074C2 File Offset: 0x000074C2
		public dashboard()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000074D0 File Offset: 0x000074D0
		public DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			result = result.AddSeconds((double)unixtime).ToLocalTime();
			return result;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00007504 File Offset: 0x00007504
		private void dashboard_Load(object sender, EventArgs e)
		{
			this.key.Text = "Username: " + Login.KeyAuthApp.user_data.username;
			this.expiry.Text = "Expiry: " + this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry)).ToString();
			this.subscription.Text = "Subscription: " + Login.KeyAuthApp.user_data.subscriptions[0].subscription;
			this.label3.Text = "Customers Online " + Login.KeyAuthApp.app_data.numOnlineUsers;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000075CA File Offset: 0x000075CA
		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/projectmedusa");
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000075D7 File Offset: 0x000075D7
		private void siticoneRoundedButton3_Click(object sender, EventArgs e)
		{
			Process.Start("https://shoppy.gg/@Spinayy");
		}

        private void dashboard_Load_1(object sender, EventArgs e)
        {

        }
    }
}
