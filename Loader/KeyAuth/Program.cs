using System;
using System.Windows.Forms;

namespace KeyAuth
{
	// Token: 0x0200000E RID: 14
	internal static class Program
	{
		// Token: 0x0600006F RID: 111 RVA: 0x000074AB File Offset: 0x000074AB
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}
	}
}
