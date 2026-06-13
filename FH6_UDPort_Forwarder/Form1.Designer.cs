namespace FH6_UDPort_Forwarder {
    partial class Form1 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtForzaPort = new TextBox();
            txtNewPort = new TextBox();
            btnAddPort = new Button();
            lstPorts = new ListBox();
            btnAddExe = new Button();
            lstExes = new ListBox();
            btnStart = new Button();
            btnStop = new Button();
            rtbLog = new RichTextBox();
            lblForza = new Label();
            lblNewPort = new Label();
            lblLog = new Label();
            lblGameExe = new Label();
            txtGameExe = new TextBox();
            chkAutoWatch = new CheckBox();
            gameWatcherTimer = new System.Windows.Forms.Timer(components);
            btnHelp = new Button();
            SuspendLayout();
            // 
            // txtForzaPort
            // 
            txtForzaPort.BackColor = Color.FromArgb(30, 30, 35);
            txtForzaPort.BorderStyle = BorderStyle.FixedSingle;
            txtForzaPort.ForeColor = Color.White;
            txtForzaPort.Location = new Point(140, 18);
            txtForzaPort.Name = "txtForzaPort";
            txtForzaPort.Size = new Size(100, 25);
            txtForzaPort.TabIndex = 1;
            txtForzaPort.TextAlign = HorizontalAlignment.Center;
            // 
            // txtNewPort
            // 
            txtNewPort.BackColor = Color.FromArgb(30, 30, 35);
            txtNewPort.BorderStyle = BorderStyle.FixedSingle;
            txtNewPort.ForeColor = Color.White;
            txtNewPort.Location = new Point(140, 58);
            txtNewPort.Name = "txtNewPort";
            txtNewPort.Size = new Size(100, 25);
            txtNewPort.TabIndex = 3;
            txtNewPort.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddPort
            // 
            btnAddPort.BackColor = Color.FromArgb(30, 30, 35);
            btnAddPort.Cursor = Cursors.Hand;
            btnAddPort.FlatAppearance.BorderColor = Color.FromArgb(255, 136, 0);
            btnAddPort.FlatStyle = FlatStyle.Flat;
            btnAddPort.ForeColor = Color.FromArgb(255, 136, 0);
            btnAddPort.Location = new Point(250, 56);
            btnAddPort.Name = "btnAddPort";
            btnAddPort.Size = new Size(60, 27);
            btnAddPort.TabIndex = 4;
            btnAddPort.Text = "Add";
            btnAddPort.UseVisualStyleBackColor = false;
            btnAddPort.Click += BtnAddPort_Click;
            // 
            // lstPorts
            // 
            lstPorts.BackColor = Color.FromArgb(20, 20, 24);
            lstPorts.BorderStyle = BorderStyle.None;
            lstPorts.ForeColor = Color.White;
            lstPorts.FormattingEnabled = true;
            lstPorts.ItemHeight = 17;
            lstPorts.Location = new Point(20, 95);
            lstPorts.Name = "lstPorts";
            lstPorts.Size = new Size(360, 68);
            lstPorts.TabIndex = 5;
            // 
            // btnAddExe
            // 
            btnAddExe.BackColor = Color.FromArgb(30, 30, 35);
            btnAddExe.Cursor = Cursors.Hand;
            btnAddExe.FlatAppearance.BorderColor = Color.FromArgb(255, 136, 0);
            btnAddExe.FlatStyle = FlatStyle.Flat;
            btnAddExe.ForeColor = Color.FromArgb(255, 136, 0);
            btnAddExe.Location = new Point(20, 185);
            btnAddExe.Name = "btnAddExe";
            btnAddExe.Size = new Size(360, 32);
            btnAddExe.TabIndex = 6;
            btnAddExe.Text = "Select App to Open Together";
            btnAddExe.UseVisualStyleBackColor = false;
            btnAddExe.Click += BtnAddExe_Click;
            // 
            // lstExes
            // 
            lstExes.BackColor = Color.FromArgb(20, 20, 24);
            lstExes.BorderStyle = BorderStyle.None;
            lstExes.ForeColor = Color.White;
            lstExes.FormattingEnabled = true;
            lstExes.ItemHeight = 17;
            lstExes.Location = new Point(20, 230);
            lstExes.Name = "lstExes";
            lstExes.Size = new Size(360, 85);
            lstExes.TabIndex = 7;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(0, 200, 83);
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStart.ForeColor = Color.Black;
            btnStart.Location = new Point(20, 405);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(170, 45);
            btnStart.TabIndex = 8;
            btnStart.Text = "START ROUTING";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(213, 0, 0);
            btnStop.Cursor = Cursors.Hand;
            btnStop.Enabled = false;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(210, 405);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(170, 45);
            btnStop.TabIndex = 9;
            btnStop.Text = "STOP";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += BtnStop_Click;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.FromArgb(10, 10, 12);
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Font = new Font("Consolas", 9.75F);
            rtbLog.ForeColor = Color.FromArgb(255, 136, 0);
            rtbLog.Location = new Point(20, 485);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(360, 160);
            rtbLog.TabIndex = 11;
            rtbLog.Text = "";
            // 
            // lblForza
            // 
            lblForza.AutoSize = true;
            lblForza.ForeColor = Color.FromArgb(255, 136, 0);
            lblForza.Location = new Point(20, 22);
            lblForza.Name = "lblForza";
            lblForza.Size = new Size(104, 17);
            lblForza.TabIndex = 0;
            lblForza.Text = "Forza Main Port:";
            // 
            // lblNewPort
            // 
            lblNewPort.AutoSize = true;
            lblNewPort.ForeColor = Color.FromArgb(255, 136, 0);
            lblNewPort.Location = new Point(20, 62);
            lblNewPort.Name = "lblNewPort";
            lblNewPort.Size = new Size(120, 17);
            lblNewPort.TabIndex = 2;
            lblNewPort.Text = "Target Port to Add:";
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.ForeColor = Color.Gray;
            lblLog.Location = new Point(20, 465);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(90, 17);
            lblLog.TabIndex = 10;
            lblLog.Text = "System Logs...";
            // 
            // lblGameExe
            // 
            lblGameExe.AutoSize = true;
            lblGameExe.ForeColor = Color.Gray;
            lblGameExe.Location = new Point(20, 335);
            lblGameExe.Name = "lblGameExe";
            lblGameExe.Size = new Size(133, 17);
            lblGameExe.TabIndex = 12;
            lblGameExe.Text = "Game Process Name:";
            // 
            // txtGameExe
            // 
            txtGameExe.BackColor = Color.FromArgb(30, 30, 35);
            txtGameExe.BorderStyle = BorderStyle.FixedSingle;
            txtGameExe.ForeColor = Color.White;
            txtGameExe.Location = new Point(155, 332);
            txtGameExe.Name = "txtGameExe";
            txtGameExe.Size = new Size(225, 25);
            txtGameExe.TabIndex = 13;
            // 
            // chkAutoWatch
            // 
            chkAutoWatch.AutoSize = true;
            chkAutoWatch.ForeColor = Color.FromArgb(255, 136, 0);
            chkAutoWatch.Location = new Point(20, 365);
            chkAutoWatch.Name = "chkAutoWatch";
            chkAutoWatch.Size = new Size(268, 21);
            chkAutoWatch.TabIndex = 14;
            chkAutoWatch.Text = "Auto-Start/Stop Routing when Game runs";
            chkAutoWatch.UseVisualStyleBackColor = true;
            // 
            // gameWatcherTimer
            // 
            gameWatcherTimer.Enabled = true;
            gameWatcherTimer.Interval = 3000;
            gameWatcherTimer.Tick += GameWatcherTimer_Tick;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.FromArgb(30, 30, 35);
            btnHelp.Cursor = Cursors.Hand;
            btnHelp.FlatAppearance.BorderColor = Color.FromArgb(255, 136, 0);
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.ForeColor = Color.FromArgb(255, 136, 0);
            btnHelp.Location = new Point(260, 16);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(120, 27);
            btnHelp.TabIndex = 15;
            btnHelp.Text = "Auto-Start Guide";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += BtnHelp_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 22);
            ClientSize = new Size(404, 671);
            Controls.Add(btnHelp);
            Controls.Add(chkAutoWatch);
            Controls.Add(txtGameExe);
            Controls.Add(lblGameExe);
            Controls.Add(rtbLog);
            Controls.Add(lblLog);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lstExes);
            Controls.Add(btnAddExe);
            Controls.Add(lstPorts);
            Controls.Add(btnAddPort);
            Controls.Add(txtNewPort);
            Controls.Add(lblNewPort);
            Controls.Add(txtForzaPort);
            Controls.Add(lblForza);
            Font = new Font("Segoe UI", 9.75F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Forza Telemetry Router";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblForza;
        private System.Windows.Forms.TextBox txtForzaPort;
        private System.Windows.Forms.Label lblNewPort;
        private System.Windows.Forms.TextBox txtNewPort;
        private System.Windows.Forms.Button btnAddPort;
        private System.Windows.Forms.ListBox lstPorts;
        private System.Windows.Forms.Button btnAddExe;
        private System.Windows.Forms.ListBox lstExes;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lblGameExe;
        private System.Windows.Forms.TextBox txtGameExe;
        private System.Windows.Forms.CheckBox chkAutoWatch;
        private System.Windows.Forms.Timer gameWatcherTimer;
        private System.Windows.Forms.Button btnHelp;
    }
}