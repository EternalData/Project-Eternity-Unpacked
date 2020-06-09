using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Eternity.Properties
{
	// Token: 0x0200000D RID: 13
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public class Resources
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00002414 File Offset: 0x00000614
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600005D RID: 93 RVA: 0x0000AA48 File Offset: 0x00008C48
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Eternity.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600005E RID: 94 RVA: 0x0000AA80 File Offset: 0x00008C80
		// (set) Token: 0x0600005F RID: 95 RVA: 0x0000AA94 File Offset: 0x00008C94
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000060 RID: 96 RVA: 0x0000AAA8 File Offset: 0x00008CA8
		public static string code
		{
			get
			{
				return Resources.ResourceManager.GetString("code", Resources.resourceCulture);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000061 RID: 97 RVA: 0x0000AACC File Offset: 0x00008CCC
		public static byte[] Confuser_CLI
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("Confuser_CLI", Resources.resourceCulture);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000062 RID: 98 RVA: 0x0000AAF4 File Offset: 0x00008CF4
		public static byte[] Confuser_Core
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("Confuser_Core", Resources.resourceCulture);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000063 RID: 99 RVA: 0x0000AB1C File Offset: 0x00008D1C
		public static byte[] Confuser_DynCipher
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("Confuser_DynCipher", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000064 RID: 100 RVA: 0x0000AB44 File Offset: 0x00008D44
		public static byte[] Confuser_Protections
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("Confuser_Protections", Resources.resourceCulture);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000065 RID: 101 RVA: 0x0000AB6C File Offset: 0x00008D6C
		public static byte[] Confuser_Renamer
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("Confuser_Renamer", Resources.resourceCulture);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000066 RID: 102 RVA: 0x0000AB94 File Offset: 0x00008D94
		public static byte[] Confuser_Runtime
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("Confuser_Runtime", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000067 RID: 103 RVA: 0x0000ABBC File Offset: 0x00008DBC
		public static byte[] dnlib
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("dnlib", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000068 RID: 104 RVA: 0x0000ABE4 File Offset: 0x00008DE4
		public static byte[] GalaSoft_MvvmLight_Extras_WPF4
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("GalaSoft_MvvmLight_Extras_WPF4", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000069 RID: 105 RVA: 0x0000AC0C File Offset: 0x00008E0C
		public static byte[] GalaSoft_MvvmLight_WPF4
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("GalaSoft_MvvmLight_WPF4", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600006A RID: 106 RVA: 0x0000AC34 File Offset: 0x00008E34
		public static byte[] MessagingToolkit_QRCode
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("MessagingToolkit_QRCode", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600006B RID: 107 RVA: 0x0000AC5C File Offset: 0x00008E5C
		public static byte[] Microsoft_Practices_ServiceLocation
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("Microsoft_Practices_ServiceLocation", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600006C RID: 108 RVA: 0x0000AC84 File Offset: 0x00008E84
		public static byte[] Ookii_Dialogs_Wpf
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("Ookii_Dialogs_Wpf", Resources.resourceCulture);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000ACAC File Offset: 0x00008EAC
		public static byte[] proxy
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("proxy", Resources.resourceCulture);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000ACD4 File Offset: 0x00008ED4
		public static byte[] ReachFramework
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("ReachFramework", Resources.resourceCulture);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600006F RID: 111 RVA: 0x0000ACFC File Offset: 0x00008EFC
		public static byte[] Settings
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("Settings", Resources.resourceCulture);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000070 RID: 112 RVA: 0x0000AD24 File Offset: 0x00008F24
		public static byte[] System_Printing
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("System_Printing", Resources.resourceCulture);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000071 RID: 113 RVA: 0x0000AD4C File Offset: 0x00008F4C
		public static byte[] System_Windows_Interactivity
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("System_Windows_Interactivity", Resources.resourceCulture);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000072 RID: 114 RVA: 0x0000AD74 File Offset: 0x00008F74
		public static byte[] UIAutomationProvider
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("UIAutomationProvider", Resources.resourceCulture);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000073 RID: 115 RVA: 0x0000AD9C File Offset: 0x00008F9C
		public static byte[] UIAutomationTypes
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("UIAutomationTypes", Resources.resourceCulture);
			}
		}

		// Token: 0x0400006E RID: 110
		private static ResourceManager resourceMan;

		// Token: 0x0400006F RID: 111
		private static CultureInfo resourceCulture;
	}
}
