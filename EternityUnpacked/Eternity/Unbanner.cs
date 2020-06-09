using System;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Eternity
{
	// Token: 0x02000004 RID: 4
	internal class Unbanner
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002FD4 File Offset: 0x000011D4
		public static bool IsAdministrator()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002FF8 File Offset: 0x000011F8
		public static void Start()
		{
			if (!Unbanner.IsAdministrator())
			{
				MessageBox.Show("To use unbanner, run Eternity as Administrator.", "Info");
			}
			try
			{
				string value = Guid.NewGuid().ToString();
				RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("MachineGUID", value);
			}
			catch
			{
				MessageBox.Show("Failed to change MachineGUID");
			}
			try
			{
				RegistryKey registryKey;
				for (;;)
				{
					registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
					if (!Unbanner.IsDigitsOnly(registryKey.GetSubKeyNames()[0]))
					{
						break;
					}
					registryKey.DeleteSubKey(registryKey.GetSubKeyNames()[0]);
				}
				registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft", RegistryKeyPermissionCheck.ReadWriteSubTree);
				while (Unbanner.IsDigitsOnly(registryKey.GetSubKeyNames()[0]))
				{
					registryKey.DeleteSubKey(registryKey.GetSubKeyNames()[0]);
				}
			}
			catch
			{
			}
			MessageBox.Show("MachineGUID changed and numbers deleted. Now change MACs manually");
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003124 File Offset: 0x00001324
		private static bool IsDigitsOnly(string str)
		{
			foreach (char c in str)
			{
				if (c < '0' || c > '9')
				{
					return false;
				}
			}
			return true;
		}
	}
}
