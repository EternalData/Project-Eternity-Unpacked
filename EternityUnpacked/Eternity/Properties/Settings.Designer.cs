using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Eternity.Properties
{
	// Token: 0x0200000E RID: 14
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.3.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000074 RID: 116 RVA: 0x0000ADC4 File Offset: 0x00008FC4
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000070 RID: 112
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
