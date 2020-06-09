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
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000075 RID: 117 RVA: 0x0000ADD8 File Offset: 0x00008FD8
		[ApplicationScopedSetting]
		[SpecialSetting(SpecialSetting.ConnectionString)]
		[DebuggerNonUserCode]
		public string Setting
		{
			get
			{
				return (string)this["Setting"];
			}
		}
	}
}
