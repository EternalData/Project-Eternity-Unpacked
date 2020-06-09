using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace Eternity
{
	// Token: 0x02000005 RID: 5
	public class Info : MetroForm
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00003170 File Offset: 0x00001370
		public Info()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000319C File Offset: 0x0000139C
		private void Info_Load(object sender, EventArgs e)
		{
			if (!this.MyIni.KeyExists("Style", null))
			{
				this.MyIni.Write("Style", "0", null);
			}
			int style = Convert.ToInt32(this.MyIni.Read("Style", null));
			this.metroStyleManager1.Style = style;
			this.label6.Text = "v" + Program.version;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003210 File Offset: 0x00001410
		private void label4_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/6KJrJwY");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003228 File Offset: 0x00001428
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003254 File Offset: 0x00001454
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Info));
			this.metroStyleManager1 = new MetroStyleManager(this.components);
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.metroStyleManager1.BeginInit();
			base.SuspendLayout();
			this.metroStyleManager1.Owner = null;
			this.label1.Anchor = AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Segoe UI Light", 14.8f);
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(172, 60);
			this.label1.Name = "label1";
			this.label1.Size = new Size(135, 35);
			this.label1.TabIndex = 3;
			this.label1.Text = "Information";
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.Transparent;
			this.label2.Font = new Font("Segoe UI Light", 12.8f);
			this.label2.ForeColor = Color.White;
			this.label2.Location = new Point(23, 135);
			this.label2.Name = "label2";
			this.label2.Size = new Size(94, 30);
			this.label2.TabIndex = 4;
			this.label2.Text = "Creator: ";
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.Transparent;
			this.label3.Font = new Font("Segoe UI Light", 12.8f);
			this.label3.ForeColor = Color.White;
			this.label3.Location = new Point(123, 135);
			this.label3.Name = "label3";
			this.label3.Size = new Size(143, 30);
			this.label3.TabIndex = 5;
			this.label3.Text = ".Eternity#8641";
			this.label4.AutoSize = true;
			this.label4.BackColor = Color.Transparent;
			this.label4.Font = new Font("Segoe UI Light", 12.8f, FontStyle.Underline);
			this.label4.ForeColor = SystemColors.Highlight;
			this.label4.Location = new Point(195, 178);
			this.label4.Name = "label4";
			this.label4.Size = new Size(257, 30);
			this.label4.TabIndex = 7;
			this.label4.Text = "https://discord.gg/6KJrJwY";
			this.label4.Click += this.label4_Click;
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.Transparent;
			this.label5.Font = new Font("Segoe UI Light", 12.8f);
			this.label5.ForeColor = Color.White;
			this.label5.Location = new Point(23, 178);
			this.label5.Name = "label5";
			this.label5.Size = new Size(165, 30);
			this.label5.TabIndex = 6;
			this.label5.Text = "Official Discord: ";
			this.label6.AutoSize = true;
			this.label6.BackColor = Color.Transparent;
			this.label6.Font = new Font("Segoe UI Light", 12.8f);
			this.label6.ForeColor = Color.White;
			this.label6.Location = new Point(115, 220);
			this.label6.Name = "label6";
			this.label6.Size = new Size(82, 30);
			this.label6.TabIndex = 9;
			this.label6.Text = "v0.0.0.0";
			this.label7.AutoSize = true;
			this.label7.BackColor = Color.Transparent;
			this.label7.Font = new Font("Segoe UI Light", 12.8f);
			this.label7.ForeColor = Color.White;
			this.label7.Location = new Point(23, 220);
			this.label7.Name = "label7";
			this.label7.Size = new Size(85, 30);
			this.label7.TabIndex = 8;
			this.label7.Text = "Version:";
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(489, 281);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new Padding(3, 2, 3, 2);
			base.MaximizeBox = false;
			base.Name = "Info";
			base.Padding = new Padding(20, 74, 20, 20);
			base.Resizable = false;
			this.Text = "Project Eternity";
			base.TextAlign = 1;
			base.Theme = 2;
			base.Load += this.Info_Load;
			this.metroStyleManager1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000007 RID: 7
		private readonly IniFile MyIni = new IniFile("Eternity.ini");

		// Token: 0x04000008 RID: 8
		private IContainer components;

		// Token: 0x04000009 RID: 9
		private MetroStyleManager metroStyleManager1;

		// Token: 0x0400000A RID: 10
		private Label label1;

		// Token: 0x0400000B RID: 11
		private Label label2;

		// Token: 0x0400000C RID: 12
		private Label label3;

		// Token: 0x0400000D RID: 13
		private Label label4;

		// Token: 0x0400000E RID: 14
		private Label label5;

		// Token: 0x0400000F RID: 15
		private Label label6;

		// Token: 0x04000010 RID: 16
		private Label label7;
	}
}
