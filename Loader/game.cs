using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using KeyAuth;
using Loader.Properties;
using Siticone.UI.WinForms;

namespace Loader
{
	// Token: 0x02000010 RID: 16
	public partial class game : Form
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00007EF4 File Offset: 0x00007EF4
		public game()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00007F10 File Offset: 0x00007F10
		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			if (Directory.Exists(folderPath + "\\DigitalEntitlements"))
			{
				Directory.Delete(folderPath + "\\DigitalEntitlements", true);
			}
			if (Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\crashes"))
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\crashes", true);
			}
			if (Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\logs"))
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\logs", true);
			}
			if (Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\data\\cache"))
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\data\\cache", true);
			}
			if (Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\data\\server-cache"))
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\data\\server-cache-priv", true);
			}
			if (Directory.Exists(folderPath2 + "\\CitizenFX"))
			{
				Directory.Delete(folderPath2 + "\\CitizenFX", true);
			}
			WebClient webClient = new WebClient();
			string tempPath = Path.GetTempPath();
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/931203518612766742/946734107889655828/music.wav", tempPath + this.uaregae + ".mp3");
			new SoundPlayer(tempPath + this.uaregae + ".mp3").Play();
			MessageBox.Show("[+] Successfully Cleaned", "Medusa Spoofer - FiveM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			string processName = "Fivem";
			string processName2 = "Steam";
			bool flag = Process.GetProcessesByName(processName).FirstOrDefault<Process>() != null;
			Process process = Process.GetProcessesByName(processName2).FirstOrDefault<Process>();
			if (process != null)
			{
				process.CloseMainWindow();
				process.Kill();
				process.WaitForExit();
				process.Dispose();
			}
			if (flag)
			{
				MessageBox.Show("[-] FiveM is running, close it!", "Medusa Spoofer - FiveM", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000080B0 File Offset: 0x000080B0
		private static void bruh()
		{
			try
			{
				Process process = new Process();
				process.StartInfo.Arguments = "netsh advfirewall firewall delete rule name = fivem_b2545_gtaprocess.exe";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				process.WaitForExit();
				MessageBox.Show("Enabled");
			}
			catch
			{
				MessageBox.Show("[-] You aren't running the app!", "Medusa Spoofer - FiveM", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00008138 File Offset: 0x00008138
		private void siticoneRoundedButton2_Click(object sender, EventArgs e)
		{
			new WebClient();
			string tempPath = Path.GetTempPath();
			byte[] bytes = Login.KeyAuthApp.download("738975");
			File.WriteAllBytes(tempPath + this.uaregae + ".bat", bytes);
			Process.Start(tempPath + this.uaregae + ".bat");
			Thread.Sleep(2500);
			this.bruhmoment();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000819D File Offset: 0x0000819D
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[game.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000081D8 File Offset: 0x000081D8
		private void siticoneRoundedButton3_Click(object sender, EventArgs e)
		{
			new WebClient();
			string tempPath = Path.GetTempPath();
			byte[] bytes = Login.KeyAuthApp.download("730543");
			File.WriteAllBytes(tempPath + this.uaregae + ".bat", bytes);
			Process.Start(tempPath + this.uaregae + ".bat");
			Thread.Sleep(2500);
			this.bruhmoment();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00008240 File Offset: 0x00008240
		public void bruhmoment()
		{
			string tempPath = Path.GetTempPath();
			if (Process.GetProcessesByName(this.uaregae + ".bat").Length == 0)
			{
				File.Delete(tempPath + this.uaregae + ".bat");
				MessageBox.Show("[+] Spoofed Game", "Medusa Spoofer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			Thread.Sleep(5000);
			this.bruhmoment();
		}

		// Token: 0x0400004C RID: 76
		public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

		// Token: 0x0400004D RID: 77
		public static string specificFolder = Path.Combine(game.folder, "DigitalEntitlements");

		// Token: 0x0400004E RID: 78
		public static string Delete = game.specificFolder;

		// Token: 0x0400004F RID: 79
		public static Random random = new Random();

		// Token: 0x04000050 RID: 80
		private string uaregae = game.RandomString(5);
	}
}
