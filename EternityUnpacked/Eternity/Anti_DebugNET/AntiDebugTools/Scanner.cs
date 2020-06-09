using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Anti_DebugNET.AntiDebugTools
{
	// Token: 0x02000001 RID: 1
	internal class Scanner
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void ScanAndKill()
		{
			Scanner.Scan(true);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		private static int Scan(bool KillProcess)
		{
			int result = 0;
			if (Scanner.BadProcessnameList.Count == 0 && Scanner.BadWindowTextList.Count == 0)
			{
				Scanner.Init();
			}
			foreach (Process process in Process.GetProcesses())
			{
				if (Scanner.BadProcessnameList.Contains(process.ProcessName) || Scanner.BadWindowTextList.Contains(process.MainWindowTitle))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("BAD PROCESS FOUND: " + process.ProcessName);
					result = 1;
					if (KillProcess)
					{
						try
						{
							process.Kill();
						}
						catch (Win32Exception ex)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write("Win32Exception: " + ex.Message);
						}
						catch (NotSupportedException ex2)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write("NotSupportedException: " + ex2.Message);
						}
						catch (InvalidOperationException ex3)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write("InvalidOperationException: " + ex3.Message);
						}
					}
					return result;
				}
			}
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000021A8 File Offset: 0x000003A8
		private static int Init()
		{
			if (Scanner.BadProcessnameList.Count > 0 && Scanner.BadWindowTextList.Count > 0)
			{
				return 1;
			}
			Scanner.BadProcessnameList.Add("ollydbg");
			Scanner.BadProcessnameList.Add("ida");
			Scanner.BadProcessnameList.Add("ida64");
			Scanner.BadProcessnameList.Add("idag");
			Scanner.BadProcessnameList.Add("idag64");
			Scanner.BadProcessnameList.Add("idaw");
			Scanner.BadProcessnameList.Add("idaw64");
			Scanner.BadProcessnameList.Add("idaq");
			Scanner.BadProcessnameList.Add("idaq64");
			Scanner.BadProcessnameList.Add("idau");
			Scanner.BadProcessnameList.Add("idau64");
			Scanner.BadProcessnameList.Add("scylla");
			Scanner.BadProcessnameList.Add("scylla_x64");
			Scanner.BadProcessnameList.Add("scylla_x86");
			Scanner.BadProcessnameList.Add("protection_id");
			Scanner.BadProcessnameList.Add("x64dbg");
			Scanner.BadProcessnameList.Add("x32dbg");
			Scanner.BadProcessnameList.Add("windbg");
			Scanner.BadProcessnameList.Add("reshacker");
			Scanner.BadProcessnameList.Add("ImportREC");
			Scanner.BadProcessnameList.Add("IMMUNITYDEBUGGER");
			Scanner.BadProcessnameList.Add("MegaDumper");
			Scanner.BadWindowTextList.Add("OLLYDBG");
			Scanner.BadWindowTextList.Add("ida");
			Scanner.BadWindowTextList.Add("disassembly");
			Scanner.BadWindowTextList.Add("scylla");
			Scanner.BadWindowTextList.Add("Debug");
			Scanner.BadWindowTextList.Add("[CPU");
			Scanner.BadWindowTextList.Add("Immunity");
			Scanner.BadWindowTextList.Add("WinDbg");
			Scanner.BadWindowTextList.Add("x32dbg");
			Scanner.BadWindowTextList.Add("x64dbg");
			Scanner.BadWindowTextList.Add("Import reconstructor");
			Scanner.BadWindowTextList.Add("MegaDumper");
			Scanner.BadWindowTextList.Add("MegaDumper 1.0 by CodeCracker / SnD");
			return 0;
		}

		// Token: 0x04000001 RID: 1
		private static HashSet<string> BadProcessnameList = new HashSet<string>();

		// Token: 0x04000002 RID: 2
		private static HashSet<string> BadWindowTextList = new HashSet<string>();
	}
}
