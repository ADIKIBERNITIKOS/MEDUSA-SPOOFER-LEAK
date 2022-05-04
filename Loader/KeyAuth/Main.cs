using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;
using Loader;
using Loader.Properties;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;

namespace KeyAuth
{
	// Token: 0x0200000C RID: 12
	public partial class Main : Form
	{
		// Token: 0x06000052 RID: 82
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x06000053 RID: 83 RVA: 0x00004C5A File Offset: 0x00004C5A
		public Main()
		{
			this.InitializeComponent();
			this.Initialize();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
		}

		// Token: 0x06000054 RID: 84
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000055 RID: 85
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000056 RID: 86 RVA: 0x00004C97 File Offset: 0x00004C97
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004CA0 File Offset: 0x00004CA0
		private void siticoneRoundedButton2_Click(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			dashboard dashboard = new dashboard
			{
				Dock = DockStyle.Fill,
				TopLevel = false,
				TopMost = true
			};
			dashboard.FormBorderStyle = FormBorderStyle.None;
			this.mainpanel.Controls.Add(dashboard);
			dashboard.Show();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004CF8 File Offset: 0x00004CF8
		private void timer1_Tick(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			this.time.Text = string.Format("{0}/{1}/{2} {3}:{4}:{5}", new object[]
			{
				now.Day,
				now.Month,
				now.Year,
				now.Hour,
				now.Minute,
				now.Second
			});
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004D80 File Offset: 0x00004D80
		private void siticoneRoundedButton4_Click(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			game game = new game
			{
				Dock = DockStyle.Fill,
				TopLevel = false,
				TopMost = true
			};
			game.FormBorderStyle = FormBorderStyle.None;
			this.mainpanel.Controls.Add(game);
			game.Show();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004DD8 File Offset: 0x00004DD8
		private void Main_Load(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			dashboard dashboard = new dashboard
			{
				Dock = DockStyle.Fill,
				TopLevel = false,
				TopMost = true
			};
			dashboard.FormBorderStyle = FormBorderStyle.None;
			this.mainpanel.Controls.Add(dashboard);
			dashboard.Show();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004E30 File Offset: 0x00004E30
		private void siticoneRoundedButton5_Click(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			systemspoof systemspoof = new systemspoof
			{
				Dock = DockStyle.Fill,
				TopLevel = false,
				TopMost = true
			};
			systemspoof.FormBorderStyle = FormBorderStyle.None;
			this.mainpanel.Controls.Add(systemspoof);
			systemspoof.Show();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004E86 File Offset: 0x00004E86
		private void siticonePanel4_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004EB0 File Offset: 0x00004EB0
		private void Initialize()
		{
			this.client = new DiscordRpcClient("853226287387901972");
			this.client.Logger = new ConsoleLogger
			{
				Level = 3
			};
			this.client.Initialize();
			this.client.SetPresence(new RichPresence
			{
				Details = "Cheap And Easy To Use Spoofer!",
				State = "discord.gg/NJ8GY4cuJG",
				Timestamps = new Timestamps
				{
					Start = new DateTime?(DateTime.UtcNow)
				},
				Assets = new Assets
				{
					LargeImageKey = "medusa",
					LargeImageText = "https://discord.gg/NJ8GY4cuJG",
					SmallImageKey = "logo"
				}
			});
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004F5D File Offset: 0x00004F5D
		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=xvFZjo5PgG0");
		}

		// Token: 0x04000019 RID: 25
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x0400001A RID: 26
		public const int HT_CAPTION = 2;

		// Token: 0x0400001B RID: 27
		private DiscordRpcClient client;
	}
}
