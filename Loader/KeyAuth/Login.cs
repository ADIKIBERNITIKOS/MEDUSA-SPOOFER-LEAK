using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Protection;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;

namespace KeyAuth
{
	// Token: 0x0200000D RID: 13
	public partial class Login : Form
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00005E30 File Offset: 0x00005E30
		public Login()
		{
			this.InitializeComponent();
			new Thread(new ThreadStart(this.antihacking)).Start();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00005E54 File Offset: 0x00005E54
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005E5C File Offset: 0x00005E5C
		private void antihacking()
		{
			Login.ProtectionProperties protectionProperties = new Login.ProtectionProperties();
			protectionProperties.AntiDebug = true;
			protectionProperties.AntiDump = true;
			protectionProperties.AntiProcess = true;
			if (protectionProperties.AntiDebug)
			{
				Debug.Initialize();
			}
			if (protectionProperties.AntiDump)
			{
				Dump.Initialize();
			}
			if (protectionProperties.AntiProcess)
			{
				ProcessCheck.Initialize();
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005EAC File Offset: 0x00005EAC
		private void Login_Load(object sender, EventArgs e)
		{
			Login.KeyAuthApp.init();
			Task<string> stringAsync = new HttpClient().GetStringAsync("https://api.ipify.org");
			if (Login.KeyAuthApp.checkblack())
			{
				string body = JsonConvert.SerializeObject(new
				{
					username = "Medusa Logs",
					embeds = new <>f__AnonymousType1<string, int, <>f__AnonymousType2<string, string, bool>[]>[]
					{
						new
						{
							title = "Medusa Spoofer - Blacklisted User Tried To Join",
							color = 255,
							fields = new <>f__AnonymousType2<string, string, bool>[]
							{
								new
								{
									name = "PC Name:",
									value = (Environment.MachineName ?? ""),
									inline = false
								},
								new
								{
									name = "IP:",
									value = string.Format("{0}", stringAsync),
									inline = false
								},
								new
								{
									name = "HWID:",
									value = (this.ReturnHWID() ?? ""),
									inline = false
								}
							}
						}
					}
				});
				Login.KeyAuthApp.webhook("KLD9srISka", "", body, "application/json");
				MessageBox.Show("You are blacklisted", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(0);
private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
			if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\login.json"))
			{
				Login.Information information = JsonConvert.DeserializeObject<Login.Information>(File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\login.json"));
				this.username.Text = information.username;
				this.password.Text = information.password;
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00005FFC File Offset: 0x00005FFC
		public string ReturnHWID()
		{
			return WindowsIdentity.GetCurrent().User.Value;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00006010 File Offset: 0x00006010
		private void LoginBtn_Click(object sender, EventArgs e)
		{
			if (this.username.Text == "")
			{
				MessageBox.Show("Username wasn't applied", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (this.password.Text == "")
			{
				MessageBox.Show("Password wasn't applied", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Login.KeyAuthApp.login(this.username.Text, this.password.Text);
			if (Login.KeyAuthApp.response.success)
			{
				string body = JsonConvert.SerializeObject(new
				{
					username = "Medusa Logs",
					embeds = new <>f__AnonymousType1<string, int, <>f__AnonymousType2<string, string, bool>[]>[]
					{
						new
						{
							title = "Medusa Spoofer - Login",
							color = 3066993,
							fields = new <>f__AnonymousType2<string, string, bool>[]
							{
								new
								{
									name = "Username:",
									value = Login.KeyAuthApp.user_data.username,
									inline = false
								},
								new
								{
									name = "IP:",
									value = Login.KeyAuthApp.user_data.ip,
									inline = false
								},
								new
								{
									name = "HWID:",
									value = Login.KeyAuthApp.user_data.hwid,
									inline = false
								}
							}
						}
					}
				});
				Login.KeyAuthApp.webhook("KLD9srISka", "", body, "application/json");
				File.WriteAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\login.json", JsonConvert.SerializeObject(new Login.Information
				{
					username = this.username.Text,
					password = this.password.Text
				}));
				MessageBox.Show("Welcome Back, " + this.username.Text, "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				new Main().Show();
				base.Hide();
				return;
			}
			MessageBox.Show(Login.KeyAuthApp.response.message ?? "", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000061EC File Offset: 0x000061EC
		private void RgstrBtn_Click(object sender, EventArgs e)
		{
			if (this.username.Text == "")
			{
				MessageBox.Show("Username wasn't applied", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (this.password.Text == "")
			{
				MessageBox.Show("Password wasn't applied", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (this.key.Text == "")
			{
				MessageBox.Show("Key wasn't applied", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Login.KeyAuthApp.register(this.username.Text, this.password.Text, this.key.Text);
			if (Login.KeyAuthApp.response.success)
			{
				string body = JsonConvert.SerializeObject(new
				{
					username = "Medusa Logs",
					embeds = new <>f__AnonymousType1<string, int, <>f__AnonymousType2<string, string, bool>[]>[]
					{
						new
						{
							title = "Medusa Spoofer - Account Created",
							color = 3066993,
							fields = new <>f__AnonymousType2<string, string, bool>[]
							{
								new
								{
									name = "Username:",
									value = Login.KeyAuthApp.user_data.username,
									inline = false
								},
								new
								{
									name = "Key Used:",
									value = this.key.Text,
									inline = false
								},
								new
								{
									name = "IP:",
									value = Login.KeyAuthApp.user_data.ip,
									inline = false
								},
								new
								{
									name = "HWID:",
									value = Login.KeyAuthApp.user_data.hwid,
									inline = false
								}
							}
						}
					}
				});
				Login.KeyAuthApp.webhook("KLD9srISka", "", body, "application/json");
				MessageBox.Show("Account Created! Welcome " + this.username.Text, "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				new Main().Show();
				base.Hide();
				return;
			}
			MessageBox.Show(Login.KeyAuthApp.response.message ?? "", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000063CC File Offset: 0x000063CC
		private void LicBtn_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.license(this.key.Text);
			if (Login.KeyAuthApp.response.success)
			{
				new Main().Show();
				base.Hide();
				return;
			}
			MessageBox.Show(Login.KeyAuthApp.response.message ?? "", "Project Medusa", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00006436 File Offset: 0x00006436
		private void username_Enter(object sender, EventArgs e)
		{
			this.username.Text = "";
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00006448 File Offset: 0x00006448
		private void password_Enter(object sender, EventArgs e)
		{
			this.password.Text = "";
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000645A File Offset: 0x0000645A
		private void key_Enter(object sender, EventArgs e)
		{
			this.key.Text = "";
		}

		// Token: 0x0400002D RID: 45
		private static string name = "FlashSpoofer";

		// Token: 0x0400002E RID: 46
		private static string ownerid = "zmeLwnIJQo";

		// Token: 0x0400002F RID: 47
		private static string secret = "0cb632390d671ebe38ac5542d0a6856a6d16efbe5b856686260572fe9f744993";

		// Token: 0x04000030 RID: 48
		private static string version = "1.0";

		// Token: 0x04000031 RID: 49
		public static api KeyAuthApp = new api(Login.name, Login.ownerid, Login.secret, Login.version);

		// Token: 0x0200001C RID: 28
		private class Information
		{
			// Token: 0x17000040 RID: 64
			// (get) Token: 0x06000106 RID: 262 RVA: 0x0000A842 File Offset: 0x0000A842
			// (set) Token: 0x06000107 RID: 263 RVA: 0x0000A84A File Offset: 0x0000A84A
			public string username { get; set; }

			// Token: 0x17000041 RID: 65
			// (get) Token: 0x06000108 RID: 264 RVA: 0x0000A853 File Offset: 0x0000A853
			// (set) Token: 0x06000109 RID: 265 RVA: 0x0000A85B File Offset: 0x0000A85B
			public string password { get; set; }
		}

		// Token: 0x0200001D RID: 29
		internal class ProtectionProperties
		{
			// Token: 0x17000042 RID: 66
			// (get) Token: 0x0600010B RID: 267 RVA: 0x0000A86C File Offset: 0x0000A86C
			// (set) Token: 0x0600010C RID: 268 RVA: 0x0000A874 File Offset: 0x0000A874
			public bool AntiDebug { get; set; }

			// Token: 0x17000043 RID: 67
			// (get) Token: 0x0600010D RID: 269 RVA: 0x0000A87D File Offset: 0x0000A87D
			// (set) Token: 0x0600010E RID: 270 RVA: 0x0000A885 File Offset: 0x0000A885
			public bool AntiDump { get; set; }

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x0600010F RID: 271 RVA: 0x0000A88E File Offset: 0x0000A88E
			// (set) Token: 0x06000110 RID: 272 RVA: 0x0000A896 File Offset: 0x0000A896
			public bool AntiProcess { get; set; }
		}
	}
}
