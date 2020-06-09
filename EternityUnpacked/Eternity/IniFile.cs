using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Eternity
{
	// Token: 0x02000006 RID: 6
	internal class IniFile
	{
		// Token: 0x06000018 RID: 24
		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

		// Token: 0x06000019 RID: 25
		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

		// Token: 0x0600001A RID: 26 RVA: 0x00003958 File Offset: 0x00001B58
		public IniFile(string IniPath = null)
		{
			this.Path = new FileInfo(IniPath ?? (this.EXE + ".ini")).FullName.ToString();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000039AC File Offset: 0x00001BAC
		public string Read(string Key, string Section = null)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			IniFile.GetPrivateProfileString(Section ?? this.EXE, Key, "", stringBuilder, 255, this.Path);
			return stringBuilder.ToString();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000039F0 File Offset: 0x00001BF0
		public void Write(string Key, string Value, string Section = null)
		{
			IniFile.WritePrivateProfileString(Section ?? this.EXE, Key, Value, this.Path);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003A18 File Offset: 0x00001C18
		public void DeleteKey(string Key, string Section = null)
		{
			this.Write(Key, null, Section ?? this.EXE);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003A38 File Offset: 0x00001C38
		public void DeleteSection(string Section = null)
		{
			this.Write(null, null, Section ?? this.EXE);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003A58 File Offset: 0x00001C58
		public bool KeyExists(string Key, string Section = null)
		{
			return this.Read(Key, Section).Length > 0;
		}

		// Token: 0x04000011 RID: 17
		private readonly string Path;

		// Token: 0x04000012 RID: 18
		private readonly string EXE = Assembly.GetExecutingAssembly().GetName().Name;
	}
}
