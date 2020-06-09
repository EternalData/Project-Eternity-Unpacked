using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Eramake;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace Eternity
{
	// Token: 0x02000007 RID: 7
	public class Login : MetroForm
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00003A7C File Offset: 0x00001C7C
		public Login()
		{
			this.InitializeComponent();
			this.Ryan-PяσTєCтσRαβγδεζηθικλqBμKξοπρqBστυφχψωRyan-PяσTєCтσR(this.metroStyleManager1);
			this.eurl = Program.eternityurl;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003ABC File Offset: 0x00001CBC
		private void Form2_Shown(object sender, EventArgs e)
		{
			try
			{
				if (!this.MyIni.KeyExists("Style", null))
				{
					this.MyIni.Write("Style", "0", null);
				}
				int style = Convert.ToInt32(this.MyIni.Read("Style", null));
				this.metroStyleManager1.Style = style;
				WebClient webClient = new WebClient();
				if (!webClient.DownloadString("https://pastebin.com/raw/mnLwNfdU").Contains(Program.version))
				{
					MessageBox.Show("New version is out! Check Eternity Discord server.", "New version!");
					Environment.Exit(0);
				}
				webClient.Dispose();
				if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Eternity.ini"))
				{
					string text = this.MyIni.Read("username", null);
					string text2 = this.MyIni.Read("pass", null);
					string text3 = eCryptography.Decrypt(text2);
					if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
					{
						string a;
						try
						{
							StreamReader streamReader = new StreamReader(WebRequest.Create(string.Concat(new string[]
							{
								this.eurl,
								"auth.php?username=",
								text,
								"&password=",
								text3,
								"&cpuid=",
								Program.GetCpuID()
							})).GetResponse().GetResponseStream());
							a = streamReader.ReadToEnd();
							streamReader.Dispose();
						}
						catch
						{
							StreamReader streamReader2 = new StreamReader(WebRequest.Create(string.Concat(new string[]
							{
								"http://projecteternity.000webhostapp.com/auth.php?username=",
								text,
								"&password=",
								text3,
								"&cpuid=12345"
							})).GetResponse().GetResponseStream());
							a = streamReader2.ReadToEnd();
							streamReader2.Dispose();
						}
						if (a == "true")
						{
							base.Hide();
							Main main = new Main(text, text3);
							main.Closed += delegate(object s, EventArgs args)
							{
								base.Close();
							};
							main.ShowDialog();
							main.Dispose();
							base.Close();
						}
					}
				}
				else
				{
					this.metroButton2.Enabled = false;
					this.Refresh();
					this.metroButton2.Enabled = true;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003D38 File Offset: 0x00001F38
		private void metroButton2_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtUsername.Text) && !string.IsNullOrEmpty(this.txtPassword.Text))
			{
				string text = this.txtUsername.Text;
				string text2 = this.txtPassword.Text;
				string a = "";
				try
				{
					StreamReader streamReader = new StreamReader(WebRequest.Create(string.Concat(new string[]
					{
						this.eurl,
						"auth.php?username=",
						text,
						"&password=",
						text2,
						"&cpuid=",
						Program.GetCpuID()
					})).GetResponse().GetResponseStream());
					a = streamReader.ReadToEnd();
					streamReader.Dispose();
				}
				catch
				{
					try
					{
						StreamReader streamReader2 = new StreamReader(WebRequest.Create(string.Concat(new string[]
						{
							this.eurl,
							"auth.php?username=",
							text,
							"&password=",
							text2,
							"&cpuid=12345"
						})).GetResponse().GetResponseStream());
						a = streamReader2.ReadToEnd();
						streamReader2.Dispose();
					}
					catch
					{
						MessageBox.Show("Unable to connect to server.");
						return;
					}
				}
				if (a == "true")
				{
					base.Hide();
					this.MyIni.Write("username", text, null);
					this.MyIni.Write("pass", eCryptography.Encrypt(text2), null);
					Main main = new Main(text, text2);
					main.Closed += delegate(object s, EventArgs args)
					{
						base.Close();
					};
					main.ShowDialog();
					main.Dispose();
					base.Close();
					return;
				}
				if (a == "time")
				{
					MessageBox.Show("Your license has expired.");
					return;
				}
				if (a == "invaliduser")
				{
					MessageBox.Show("Authorization failed.");
					return;
				}
				if (a == "nologininfo")
				{
					MessageBox.Show("Missing login info.");
				}
				return;
			}
			MessageBox.Show("Missing login info.");
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003F70 File Offset: 0x00002170
		private void Form2_Click(object sender, EventArgs e)
		{
			this.label1.Focus();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003F8C File Offset: 0x0000218C
		private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.metroButton2.PerformClick();
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003FB4 File Offset: 0x000021B4
		private void metroButton1_Click(object sender, EventArgs e)
		{
			base.Hide();
			Register register = new Register();
			register.ShowDialog();
			register.Dispose();
			base.Close();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003FE0 File Offset: 0x000021E0
		private void Login_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003FF0 File Offset: 0x000021F0
		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(1);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00004008 File Offset: 0x00002208
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004034 File Offset: 0x00002234
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Login));
			this.txtUsername = new MetroTextBox();
			this.label2 = new Label();
			this.label1 = new Label();
			this.metroButton2 = new MetroButton();
			this.txtPassword = new MetroTextBox();
			this.metroButton1 = new MetroButton();
			this.metroStyleManager1 = new MetroStyleManager(this.components);
			this.metroStyleManager1.BeginInit();
			base.SuspendLayout();
			this.txtUsername.CustomButton.Image = null;
			this.txtUsername.CustomButton.Location = new Point(122, 1);
			this.txtUsername.CustomButton.Margin = new Padding(2);
			this.txtUsername.CustomButton.Name = "";
			this.txtUsername.CustomButton.Size = new Size(18, 18);
			this.txtUsername.CustomButton.Style = 4;
			this.txtUsername.CustomButton.TabIndex = 1;
			this.txtUsername.CustomButton.Theme = 1;
			this.txtUsername.CustomButton.UseSelectable = true;
			this.txtUsername.CustomButton.Visible = false;
			this.txtUsername.FontSize = 2;
			this.txtUsername.Lines = new string[0];
			this.txtUsername.Location = new Point(40, 106);
			this.txtUsername.Margin = new Padding(2);
			this.txtUsername.MaxLength = 32767;
			this.txtUsername.Multiline = true;
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.PasswordChar = '\0';
			this.txtUsername.PromptText = "Username";
			this.txtUsername.ScrollBars = ScrollBars.None;
			this.txtUsername.SelectedText = "";
			this.txtUsername.SelectionLength = 0;
			this.txtUsername.SelectionStart = 0;
			this.txtUsername.ShortcutsEnabled = true;
			this.txtUsername.Size = new Size(176, 25);
			this.txtUsername.TabIndex = 2;
			this.txtUsername.TabStop = false;
			this.txtUsername.Theme = 2;
			this.txtUsername.UseSelectable = true;
			this.txtUsername.WaterMark = "Username";
			this.txtUsername.WaterMarkColor = Color.White;
			this.txtUsername.WaterMarkFont = new Font("Segoe UI Light", 10.8f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.Transparent;
			this.label2.Font = new Font("Segoe UI Light", 13f);
			this.label2.ForeColor = Color.White;
			this.label2.Location = new Point(36, 70);
			this.label2.Margin = new Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(54, 25);
			this.label2.TabIndex = 5;
			this.label2.Text = "Login";
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Segoe UI Light", 14f);
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(152, 239);
			this.label1.Margin = new Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(104, 25);
			this.label1.TabIndex = 8;
			this.label1.Text = "DziugsBugs";
			this.metroButton2.BackColor = Color.FromArgb(26, 32, 40);
			this.metroButton2.FontSize = 2;
			this.metroButton2.FontWeight = 0;
			this.metroButton2.Highlight = true;
			this.metroButton2.Location = new Point(72, 177);
			this.metroButton2.Margin = new Padding(2);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new Size(112, 36);
			this.metroButton2.TabIndex = 11;
			this.metroButton2.TabStop = false;
			this.metroButton2.Text = "Login";
			this.metroButton2.Theme = 2;
			this.metroButton2.UseSelectable = true;
			this.metroButton2.Click += this.metroButton2_Click;
			this.txtPassword.CustomButton.Image = null;
			this.txtPassword.CustomButton.Location = new Point(122, 1);
			this.txtPassword.CustomButton.Margin = new Padding(2);
			this.txtPassword.CustomButton.Name = "";
			this.txtPassword.CustomButton.Size = new Size(18, 18);
			this.txtPassword.CustomButton.Style = 4;
			this.txtPassword.CustomButton.TabIndex = 1;
			this.txtPassword.CustomButton.Theme = 1;
			this.txtPassword.CustomButton.UseSelectable = true;
			this.txtPassword.CustomButton.Visible = false;
			this.txtPassword.FontSize = 2;
			this.txtPassword.Lines = new string[0];
			this.txtPassword.Location = new Point(40, 136);
			this.txtPassword.Margin = new Padding(2);
			this.txtPassword.MaxLength = 32767;
			this.txtPassword.Multiline = true;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.PromptText = "Password";
			this.txtPassword.ScrollBars = ScrollBars.None;
			this.txtPassword.SelectedText = "";
			this.txtPassword.SelectionLength = 0;
			this.txtPassword.SelectionStart = 0;
			this.txtPassword.ShortcutsEnabled = true;
			this.txtPassword.Size = new Size(176, 25);
			this.txtPassword.TabIndex = 12;
			this.txtPassword.TabStop = false;
			this.txtPassword.Theme = 2;
			this.txtPassword.UseSelectable = true;
			this.txtPassword.WaterMark = "Password";
			this.txtPassword.WaterMarkColor = Color.White;
			this.txtPassword.WaterMarkFont = new Font("Segoe UI Light", 10.8f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.metroButton1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.metroButton1.BackColor = Color.FromArgb(26, 32, 40);
			this.metroButton1.FontWeight = 0;
			this.metroButton1.Highlight = true;
			this.metroButton1.Location = new Point(6, 245);
			this.metroButton1.Margin = new Padding(2);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new Size(47, 20);
			this.metroButton1.TabIndex = 13;
			this.metroButton1.TabStop = false;
			this.metroButton1.Text = "Register";
			this.metroButton1.Theme = 2;
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += this.metroButton1_Click;
			this.metroStyleManager1.Owner = this;
			this.metroStyleManager1.Theme = 2;
			base.AutoScaleDimensions = new SizeF(96f, 96f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			base.ClientSize = new Size(256, 269);
			base.Controls.Add(this.metroButton1);
			base.Controls.Add(this.txtPassword);
			base.Controls.Add(this.metroButton2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.txtUsername);
			base.HelpButton = true;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new Padding(2);
			base.MaximizeBox = false;
			base.Name = "Login";
			base.Padding = new Padding(16, 60, 16, 16);
			base.Resizable = false;
			base.Style = 0;
			this.Text = "Project Eternity";
			base.TextAlign = 1;
			base.Theme = 2;
			base.FormClosing += this.Login_FormClosing;
			base.Load += this.Login_Load;
			base.Shown += this.Form2_Shown;
			base.Click += this.Form2_Click;
			this.metroStyleManager1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00004B3C File Offset: 0x00002D3C
		void Ryan-PяσTєCтσRαβγδεζηθικλqBμKξοπρqBστυφχψωRyan-PяσTєCтσR(object A_1)
		{
			base.StyleManager = A_1;
		}

		// Token: 0x04000013 RID: 19
		private readonly IniFile MyIni = new IniFile("Eternity.ini");

		// Token: 0x04000014 RID: 20
		public string username;

		// Token: 0x04000015 RID: 21
		public string eurl;

		// Token: 0x04000016 RID: 22
		private IContainer components;

		// Token: 0x04000017 RID: 23
		private MetroTextBox txtUsername;

		// Token: 0x04000018 RID: 24
		private Label label2;

		// Token: 0x04000019 RID: 25
		private Label label1;

		// Token: 0x0400001A RID: 26
		private MetroButton metroButton2;

		// Token: 0x0400001B RID: 27
		private MetroTextBox txtPassword;

		// Token: 0x0400001C RID: 28
		private MetroButton metroButton1;

		// Token: 0x0400001D RID: 29
		private MetroStyleManager metroStyleManager1;
	}
}
