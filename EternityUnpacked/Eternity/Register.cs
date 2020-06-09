using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Eramake;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace Eternity
{
	// Token: 0x0200000C RID: 12
	public class Register : MetroForm
	{
		// Token: 0x06000056 RID: 86 RVA: 0x0000965C File Offset: 0x0000785C
		public Register()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00009688 File Offset: 0x00007888
		private void Register_Load(object sender, EventArgs e)
		{
			this.eurl = Program.eternityurl;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000096A0 File Offset: 0x000078A0
		private void metroButton2_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.txtUsername.Text) || string.IsNullOrEmpty(this.txtPassword.Text) || string.IsNullOrEmpty(this.txtConfPass.Text))
			{
				MessageBox.Show("Some fields are empty.", "Info");
				return;
			}
			if (!(this.txtPassword.Text == this.txtConfPass.Text) || this.txtUsername.Text.Length > 20 || this.txtPassword.Text.Length > 30)
			{
				MessageBox.Show("Some fields aren't correct or too long.", "Info");
				return;
			}
			string text;
			try
			{
				StreamReader streamReader = new StreamReader(WebRequest.Create(string.Concat(new string[]
				{
					this.eurl,
					"register.php?key=",
					this.txtKey.Text,
					"&username=",
					this.txtUsername.Text,
					"&password=",
					this.txtPassword.Text,
					"&cpuid=",
					Program.GetCpuID()
				})).GetResponse().GetResponseStream());
				text = streamReader.ReadToEnd();
				streamReader.Dispose();
			}
			catch
			{
				StreamReader streamReader2 = new StreamReader(WebRequest.Create(string.Concat(new string[]
				{
					this.eurl,
					"register.php?key=",
					this.txtKey.Text,
					"&username=",
					this.txtUsername.Text,
					"&password=",
					this.txtPassword.Text,
					"&cpuid=12345"
				})).GetResponse().GetResponseStream());
				text = streamReader2.ReadToEnd();
				streamReader2.Dispose();
			}
			if (text == "success")
			{
				MessageBox.Show("Register successful!");
				base.Hide();
				this.myini.Write("username", this.txtUsername.Text, null);
				this.myini.Write("password", eCryptography.Encrypt(this.txtPassword.Text), null);
				Login login = new Login();
				login.ShowDialog();
				login.Dispose();
				base.Close();
				return;
			}
			MessageBox.Show(text);
			base.Hide();
			Login login2 = new Login();
			login2.ShowDialog();
			login2.Dispose();
			base.Close();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00009964 File Offset: 0x00007B64
		private void metroButton1_Click(object sender, EventArgs e)
		{
			base.Hide();
			Login login = new Login();
			login.ShowDialog();
			login.Dispose();
			base.Close();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00009990 File Offset: 0x00007B90
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000099BC File Offset: 0x00007BBC
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Register));
			this.label2 = new Label();
			this.txtKey = new MetroTextBox();
			this.metroButton2 = new MetroButton();
			this.label1 = new Label();
			this.txtUsername = new MetroTextBox();
			this.txtPassword = new MetroTextBox();
			this.txtConfPass = new MetroTextBox();
			this.metroButton1 = new MetroButton();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.Transparent;
			this.label2.Font = new Font("Segoe UI Light", 13f);
			this.label2.ForeColor = Color.White;
			this.label2.Location = new Point(34, 64);
			this.label2.Margin = new Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(72, 25);
			this.label2.TabIndex = 6;
			this.label2.Text = "Register";
			this.txtKey.CustomButton.Image = null;
			this.txtKey.CustomButton.Location = new Point(106, 1);
			this.txtKey.CustomButton.Margin = new Padding(2, 2, 2, 2);
			this.txtKey.CustomButton.Name = "";
			this.txtKey.CustomButton.Size = new Size(17, 19);
			this.txtKey.CustomButton.Style = 4;
			this.txtKey.CustomButton.TabIndex = 1;
			this.txtKey.CustomButton.Theme = 1;
			this.txtKey.CustomButton.UseSelectable = true;
			this.txtKey.CustomButton.Visible = false;
			this.txtKey.FontSize = 2;
			this.txtKey.Lines = new string[0];
			this.txtKey.Location = new Point(38, 96);
			this.txtKey.Margin = new Padding(2, 2, 2, 2);
			this.txtKey.MaxLength = 32767;
			this.txtKey.Multiline = true;
			this.txtKey.Name = "txtKey";
			this.txtKey.PasswordChar = '\0';
			this.txtKey.PromptText = "Private key";
			this.txtKey.ScrollBars = ScrollBars.None;
			this.txtKey.SelectedText = "";
			this.txtKey.SelectionLength = 0;
			this.txtKey.SelectionStart = 0;
			this.txtKey.ShortcutsEnabled = true;
			this.txtKey.Size = new Size(165, 25);
			this.txtKey.Style = 4;
			this.txtKey.TabIndex = 7;
			this.txtKey.TabStop = false;
			this.txtKey.Theme = 2;
			this.txtKey.UseSelectable = true;
			this.txtKey.Visible = false;
			this.txtKey.WaterMark = "Private key";
			this.txtKey.WaterMarkColor = Color.White;
			this.txtKey.WaterMarkFont = new Font("Segoe UI Light", 10.8f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.metroButton2.BackColor = Color.FromArgb(26, 32, 40);
			this.metroButton2.FontSize = 2;
			this.metroButton2.FontWeight = 0;
			this.metroButton2.Highlight = true;
			this.metroButton2.Location = new Point(68, 223);
			this.metroButton2.Margin = new Padding(2, 2, 2, 2);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new Size(105, 37);
			this.metroButton2.Style = 4;
			this.metroButton2.TabIndex = 12;
			this.metroButton2.TabStop = false;
			this.metroButton2.Text = "Register";
			this.metroButton2.Theme = 2;
			this.metroButton2.UseSelectable = true;
			this.metroButton2.Click += this.metroButton2_Click;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Segoe UI Light", 14f);
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(146, 263);
			this.label1.Margin = new Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(104, 25);
			this.label1.TabIndex = 13;
			this.label1.Text = "DziugsBugs";
			this.txtUsername.CustomButton.Image = null;
			this.txtUsername.CustomButton.Location = new Point(106, 1);
			this.txtUsername.CustomButton.Margin = new Padding(2, 2, 2, 2);
			this.txtUsername.CustomButton.Name = "";
			this.txtUsername.CustomButton.Size = new Size(17, 19);
			this.txtUsername.CustomButton.Style = 4;
			this.txtUsername.CustomButton.TabIndex = 1;
			this.txtUsername.CustomButton.Theme = 1;
			this.txtUsername.CustomButton.UseSelectable = true;
			this.txtUsername.CustomButton.Visible = false;
			this.txtUsername.FontSize = 2;
			this.txtUsername.Lines = new string[0];
			this.txtUsername.Location = new Point(38, 126);
			this.txtUsername.Margin = new Padding(2, 2, 2, 2);
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
			this.txtUsername.Size = new Size(165, 25);
			this.txtUsername.Style = 4;
			this.txtUsername.TabIndex = 14;
			this.txtUsername.TabStop = false;
			this.txtUsername.Theme = 2;
			this.txtUsername.UseSelectable = true;
			this.txtUsername.WaterMark = "Username";
			this.txtUsername.WaterMarkColor = Color.White;
			this.txtUsername.WaterMarkFont = new Font("Segoe UI Light", 10.8f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtPassword.CustomButton.Image = null;
			this.txtPassword.CustomButton.Location = new Point(106, 1);
			this.txtPassword.CustomButton.Margin = new Padding(2, 2, 2, 2);
			this.txtPassword.CustomButton.Name = "";
			this.txtPassword.CustomButton.Size = new Size(17, 19);
			this.txtPassword.CustomButton.Style = 4;
			this.txtPassword.CustomButton.TabIndex = 1;
			this.txtPassword.CustomButton.Theme = 1;
			this.txtPassword.CustomButton.UseSelectable = true;
			this.txtPassword.CustomButton.Visible = false;
			this.txtPassword.FontSize = 2;
			this.txtPassword.Lines = new string[0];
			this.txtPassword.Location = new Point(38, 156);
			this.txtPassword.Margin = new Padding(2, 2, 2, 2);
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
			this.txtPassword.Size = new Size(165, 25);
			this.txtPassword.Style = 4;
			this.txtPassword.TabIndex = 15;
			this.txtPassword.TabStop = false;
			this.txtPassword.Theme = 2;
			this.txtPassword.UseSelectable = true;
			this.txtPassword.WaterMark = "Password";
			this.txtPassword.WaterMarkColor = Color.White;
			this.txtPassword.WaterMarkFont = new Font("Segoe UI Light", 10.8f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtConfPass.CustomButton.Image = null;
			this.txtConfPass.CustomButton.Location = new Point(106, 1);
			this.txtConfPass.CustomButton.Margin = new Padding(2, 2, 2, 2);
			this.txtConfPass.CustomButton.Name = "";
			this.txtConfPass.CustomButton.Size = new Size(17, 19);
			this.txtConfPass.CustomButton.Style = 4;
			this.txtConfPass.CustomButton.TabIndex = 1;
			this.txtConfPass.CustomButton.Theme = 1;
			this.txtConfPass.CustomButton.UseSelectable = true;
			this.txtConfPass.CustomButton.Visible = false;
			this.txtConfPass.FontSize = 2;
			this.txtConfPass.Lines = new string[0];
			this.txtConfPass.Location = new Point(38, 186);
			this.txtConfPass.Margin = new Padding(2, 2, 2, 2);
			this.txtConfPass.MaxLength = 32767;
			this.txtConfPass.Multiline = true;
			this.txtConfPass.Name = "txtConfPass";
			this.txtConfPass.PasswordChar = '*';
			this.txtConfPass.PromptText = "Repeat Password";
			this.txtConfPass.ScrollBars = ScrollBars.None;
			this.txtConfPass.SelectedText = "";
			this.txtConfPass.SelectionLength = 0;
			this.txtConfPass.SelectionStart = 0;
			this.txtConfPass.ShortcutsEnabled = true;
			this.txtConfPass.Size = new Size(165, 25);
			this.txtConfPass.Style = 4;
			this.txtConfPass.TabIndex = 16;
			this.txtConfPass.TabStop = false;
			this.txtConfPass.Theme = 2;
			this.txtConfPass.UseSelectable = true;
			this.txtConfPass.WaterMark = "Repeat Password";
			this.txtConfPass.WaterMarkColor = Color.White;
			this.txtConfPass.WaterMarkFont = new Font("Segoe UI Light", 10.8f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.metroButton1.BackColor = Color.FromArgb(26, 32, 40);
			this.metroButton1.FontWeight = 0;
			this.metroButton1.Highlight = true;
			this.metroButton1.Location = new Point(3, 268);
			this.metroButton1.Margin = new Padding(2, 2, 2, 2);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new Size(40, 20);
			this.metroButton1.TabIndex = 17;
			this.metroButton1.TabStop = false;
			this.metroButton1.Text = "Login";
			this.metroButton1.Theme = 2;
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += this.metroButton1_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(240, 291);
			base.Controls.Add(this.metroButton1);
			base.Controls.Add(this.txtConfPass);
			base.Controls.Add(this.txtPassword);
			base.Controls.Add(this.txtUsername);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.metroButton2);
			base.Controls.Add(this.txtKey);
			base.Controls.Add(this.label2);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new Padding(2, 2, 2, 2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Register";
			base.Padding = new Padding(15, 49, 15, 16);
			base.Resizable = false;
			this.Text = "Project Eternity";
			base.TextAlign = 1;
			base.Theme = 2;
			base.Load += this.Register_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000063 RID: 99
		private IniFile myini = new IniFile("Eternity.ini");

		// Token: 0x04000064 RID: 100
		private string eurl;

		// Token: 0x04000065 RID: 101
		private IContainer components;

		// Token: 0x04000066 RID: 102
		private Label label2;

		// Token: 0x04000067 RID: 103
		private MetroTextBox txtKey;

		// Token: 0x04000068 RID: 104
		private MetroButton metroButton2;

		// Token: 0x04000069 RID: 105
		private Label label1;

		// Token: 0x0400006A RID: 106
		private MetroTextBox txtUsername;

		// Token: 0x0400006B RID: 107
		private MetroTextBox txtPassword;

		// Token: 0x0400006C RID: 108
		private MetroTextBox txtConfPass;

		// Token: 0x0400006D RID: 109
		private MetroButton metroButton1;
	}
}
