using System;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace Eternity
{
	// Token: 0x0200000A RID: 10
	internal static class Program
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00009504 File Offset: 0x00007704
		[STAThread]
		private static void BorlandsProtector_βbw_Ryan-Protector()
		{
			bool flag;
			Program.mutex = new Mutex(true, "Eternity", ref flag);
			Program.SetProcessDPIAware();
			Program.eternityurl = new WebClient().DownloadString("https://pastebin.com/raw/QHwvdMHz");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}

		// Token: 0x0600004F RID: 79
		[DllImport("user32.dll")]
		private static extern bool SetProcessDPIAware();

		// Token: 0x06000050 RID: 80 RVA: 0x00009590 File Offset: 0x00007790
		public static string GetCpuID()
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			string result = "";
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					result = ((ManagementObject)enumerator.Current)["ProcessorId"].ToString();
				}
			}
			managementObjectSearcher.Dispose();
			return result;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002FD4 File Offset: 0x000011D4
		public static bool IsAdministrator()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		// Token: 0x0400005E RID: 94
		private static Mutex mutex = null;

		// Token: 0x0400005F RID: 95
		public static string version = "2.7.0.0";

		// Token: 0x04000060 RID: 96
		public static string eternityurl;
	}
}
