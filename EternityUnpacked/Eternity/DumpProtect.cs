using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Eternity
{
	// Token: 0x02000003 RID: 3
	internal class DumpProtect
	{
		// Token: 0x06000009 RID: 9
		[DllImport("kernel32.dll")]
		private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

		// Token: 0x0600000A RID: 10
		[DllImport("kernel32.dll")]
		private static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);

		// Token: 0x0600000B RID: 11 RVA: 0x00002D2C File Offset: 0x00000F2C
		private static void EraseSection(IntPtr address, int size)
		{
			IntPtr intPtr = (IntPtr)size;
			IntPtr flNewProtect = 0;
			DumpProtect.VirtualProtect(address, intPtr, (IntPtr)64, ref flNewProtect);
			DumpProtect.ZeroMemory(address, intPtr);
			IntPtr intPtr2 = 0;
			DumpProtect.VirtualProtect(address, intPtr, flNewProtect, ref intPtr2);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002D78 File Offset: 0x00000F78
		public static void AntiDump()
		{
			IntPtr baseAddress = Process.GetCurrentProcess().MainModule.BaseAddress;
			int num = Marshal.ReadInt32((IntPtr)(baseAddress.ToInt64() + 60L));
			short num2 = Marshal.ReadInt16((IntPtr)(baseAddress.ToInt64() + (long)num + 6L));
			DumpProtect.EraseSection(baseAddress, 30);
			for (int i = 0; i < DumpProtect.peheaderdwords.Length; i++)
			{
				DumpProtect.EraseSection((IntPtr)(baseAddress.ToInt64() + (long)num + (long)DumpProtect.peheaderdwords[i]), 4);
			}
			for (int j = 0; j < DumpProtect.peheaderwords.Length; j++)
			{
				DumpProtect.EraseSection((IntPtr)(baseAddress.ToInt64() + (long)num + (long)DumpProtect.peheaderwords[j]), 2);
			}
			for (int k = 0; k < DumpProtect.peheaderbytes.Length; k++)
			{
				DumpProtect.EraseSection((IntPtr)(baseAddress.ToInt64() + (long)num + (long)DumpProtect.peheaderbytes[k]), 1);
			}
			int l = 0;
			int num3 = 0;
			while (l <= (int)num2)
			{
				if (num3 == 0)
				{
					DumpProtect.EraseSection((IntPtr)(baseAddress.ToInt64() + (long)num + 250L + (long)(40 * l) + 32L), 2);
				}
				DumpProtect.EraseSection((IntPtr)(baseAddress.ToInt64() + (long)num + 250L + (long)(40 * l) + (long)DumpProtect.sectiontabledwords[num3]), 4);
				num3++;
				if (num3 == DumpProtect.sectiontabledwords.Length)
				{
					l++;
					num3 = 0;
				}
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002F50 File Offset: 0x00001150
		// Note: this type is marked as 'beforefieldinit'.
		static DumpProtect()
		{
			int[] array = new int[7];
			RuntimeHelpers.InitializeArray(array, ldtoken().Handle);
			DumpProtect.sectiontabledwords = array;
			DumpProtect.peheaderbytes = new int[]
			{
				26,
				27
			};
			int[] array2 = new int[12];
			RuntimeHelpers.InitializeArray(array2, ldtoken().Handle);
			DumpProtect.peheaderwords = array2;
			int[] array3 = new int[27];
			RuntimeHelpers.InitializeArray(array3, ldtoken().Handle);
			DumpProtect.peheaderdwords = array3;
		}

		// Token: 0x04000003 RID: 3
		private static int[] sectiontabledwords;

		// Token: 0x04000004 RID: 4
		private static int[] peheaderbytes;

		// Token: 0x04000005 RID: 5
		private static int[] peheaderwords;

		// Token: 0x04000006 RID: 6
		private static int[] peheaderdwords;
	}
}
