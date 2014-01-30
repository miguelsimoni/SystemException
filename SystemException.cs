using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Diagnostics;
[assembly: AssemblyTitle("SystemException")]
[assembly: AssemblyDescription("System Exception Screen Saver [miguel.simoni@gmail.com]")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Miguel.Simoni")]
[assembly: AssemblyProduct("SystemException")]
[assembly: AssemblyCopyright("Copyright © Miguel.Simoni 2007")]
[assembly: AssemblyVersion("1.2.0.0")]

namespace SystemException
{
	public class mainForm : Form
	{
        private System.ComponentModel.IContainer components = null;
        private Label lblMessage;
        private Timer timer;

        private bool alpha = true;
        private int mouseX = 0;
        private int mouseY = 0;

		public mainForm()
		{
            this.components = new System.ComponentModel.Container();
            this.lblMessage = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            // lblMessage
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(385, 39);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "System Exception";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // timer
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);

            // mainForm
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(ClientSize.Width, ClientSize.Height);
            this.Controls.Add(this.lblMessage);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainForm";
            this.Opacity = 0.4;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

            lblMessage.Top = (this.Height - lblMessage.Height) / 2;
            lblMessage.Left = (this.Width - lblMessage.Width) / 2;
            mouseX = Cursor.Position.X;
            mouseY = Cursor.Position.Y;
            Cursor.Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(alpha)
                this.Opacity += 0.01;
            else
                this.Opacity -= 0.01;
            if(this.Opacity < 0.4 || this.Opacity > 0.8)
                alpha = !alpha;
            //int delta = 0;
            //Random sd = new Random();
            //if(sd.Next() % 2 == 0)
            //    delta = 1;
            //else
            //    delta = -1;
            //lblMessage.Left += delta;
            //if(sd.Next() % 2 == 0)
            //    delta = 1;
            //else
            //    delta = -1;
            //lblMessage.Top -= delta;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseX - e.X > 10 || mouseY - e.Y > 10)
                Application.Exit();
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            if(args.Length > 0)
            {
                string arg = args[0].ToLower().Trim().Substring(0, 2);
                switch(arg)
                {
                    case "/c":
                        Application.Run(new frmConfig());
                        break;
                    case "/p":
                        //
                        break;
                    case "/s":
                        Application.Run(new mainForm());
                        break;
                    case "/i":
                        Process.Start("Rundll32.exe", "shell32.dll, Control_RunDLL desk.cpl ,1");
                        break;
                    default:
                        Application.Run(new mainForm());
                        break;
                }
            }
            else
            {
                Application.Run(new mainForm());
            }
        }

	}

    public class frmConfig : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblVersion;

        public frmConfig()
        {
            this.components = new System.ComponentModel.Container();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSettings
            // 
            this.grpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSettings.Controls.Add(this.lblVersion);
            this.grpSettings.Location = new System.Drawing.Point(12, 12);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(270, 140);
            this.grpSettings.TabIndex = 0;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Exception Settings";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(144, 161);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(66, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(216, 161);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(6, 22);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version " + Application.ProductVersion;
            // 
            // frmConfig
            // 
            this.AcceptButton = this.btnAccept;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(294, 193);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("app.ico"));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.Opacity = 0.8;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Exception Configuration";
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }

}
