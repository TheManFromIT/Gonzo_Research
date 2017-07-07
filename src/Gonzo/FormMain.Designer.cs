namespace Gonzo
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.butPingTest = new System.Windows.Forms.Button();
            this.butListNeworks = new System.Windows.Forms.Button();
            this.butLoadOUIDB = new System.Windows.Forms.Button();
            this.tailvewLog = new TheManFromIT.Components.TailViewer();
            this.lstvewNetworks = new System.Windows.Forms.ListView();
            this.colhedSSID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spltcontMain = new System.Windows.Forms.SplitContainer();
            this.txtMaliciousBSSID = new System.Windows.Forms.TextBox();
            this.spltcontLists = new System.Windows.Forms.SplitContainer();
            this.lstvewNetworkList = new System.Windows.Forms.ListView();
            this.colhedChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhedStrength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhedMac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhedNetworkSSID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhedManufacturer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.spltcontMain)).BeginInit();
            this.spltcontMain.Panel1.SuspendLayout();
            this.spltcontMain.Panel2.SuspendLayout();
            this.spltcontMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcontLists)).BeginInit();
            this.spltcontLists.Panel1.SuspendLayout();
            this.spltcontLists.Panel2.SuspendLayout();
            this.spltcontLists.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Malicious BSSID:";
            // 
            // butPingTest
            // 
            this.butPingTest.Location = new System.Drawing.Point(311, 15);
            this.butPingTest.Name = "butPingTest";
            this.butPingTest.Size = new System.Drawing.Size(126, 29);
            this.butPingTest.TabIndex = 3;
            this.butPingTest.Text = "Ping Test";
            this.butPingTest.UseVisualStyleBackColor = true;
            this.butPingTest.Click += new System.EventHandler(this.HandlePingTest);
            // 
            // butListNeworks
            // 
            this.butListNeworks.Location = new System.Drawing.Point(443, 15);
            this.butListNeworks.Name = "butListNeworks";
            this.butListNeworks.Size = new System.Drawing.Size(132, 30);
            this.butListNeworks.TabIndex = 5;
            this.butListNeworks.Text = "List Networks";
            this.butListNeworks.UseVisualStyleBackColor = true;
            this.butListNeworks.Click += new System.EventHandler(this.butListNeworks_Click);
            // 
            // butLoadOUIDB
            // 
            this.butLoadOUIDB.Location = new System.Drawing.Point(684, 14);
            this.butLoadOUIDB.Name = "butLoadOUIDB";
            this.butLoadOUIDB.Size = new System.Drawing.Size(132, 30);
            this.butLoadOUIDB.TabIndex = 7;
            this.butLoadOUIDB.Text = "Test OUI DB";
            this.butLoadOUIDB.UseVisualStyleBackColor = true;
            this.butLoadOUIDB.Click += new System.EventHandler(this.butLoadOUIDB_Click);
            // 
            // tailvewLog
            // 
            this.tailvewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tailvewLog.Location = new System.Drawing.Point(0, 0);
            this.tailvewLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tailvewLog.Name = "tailvewLog";
            this.tailvewLog.Size = new System.Drawing.Size(646, 479);
            this.tailvewLog.TabIndex = 4;
            this.tailvewLog.Target = "";
            // 
            // lstvewNetworks
            // 
            this.lstvewNetworks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhedSSID});
            this.lstvewNetworks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvewNetworks.Enabled = false;
            this.lstvewNetworks.Location = new System.Drawing.Point(0, 0);
            this.lstvewNetworks.Name = "lstvewNetworks";
            this.lstvewNetworks.Size = new System.Drawing.Size(587, 236);
            this.lstvewNetworks.TabIndex = 8;
            this.lstvewNetworks.UseCompatibleStateImageBehavior = false;
            this.lstvewNetworks.View = System.Windows.Forms.View.Details;
            // 
            // colhedSSID
            // 
            this.colhedSSID.Text = "SSID";
            this.colhedSSID.Width = 157;
            // 
            // spltcontMain
            // 
            this.spltcontMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spltcontMain.Location = new System.Drawing.Point(1, 51);
            this.spltcontMain.Name = "spltcontMain";
            // 
            // spltcontMain.Panel1
            // 
            this.spltcontMain.Panel1.Controls.Add(this.spltcontLists);
            // 
            // spltcontMain.Panel2
            // 
            this.spltcontMain.Panel2.Controls.Add(this.tailvewLog);
            this.spltcontMain.Size = new System.Drawing.Size(1237, 479);
            this.spltcontMain.SplitterDistance = 587;
            this.spltcontMain.TabIndex = 9;
            // 
            // txtMaliciousBSSID
            // 
            this.txtMaliciousBSSID.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Gonzo.Properties.Settings.Default, "MaliciousBSSID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMaliciousBSSID.Location = new System.Drawing.Point(150, 16);
            this.txtMaliciousBSSID.Name = "txtMaliciousBSSID";
            this.txtMaliciousBSSID.Size = new System.Drawing.Size(155, 26);
            this.txtMaliciousBSSID.TabIndex = 1;
            this.txtMaliciousBSSID.Text = global::Gonzo.Properties.Settings.Default.MaliciousBSSID;
            this.txtMaliciousBSSID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // spltcontLists
            // 
            this.spltcontLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltcontLists.Location = new System.Drawing.Point(0, 0);
            this.spltcontLists.Name = "spltcontLists";
            this.spltcontLists.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltcontLists.Panel1
            // 
            this.spltcontLists.Panel1.Controls.Add(this.lstvewNetworkList);
            // 
            // spltcontLists.Panel2
            // 
            this.spltcontLists.Panel2.Controls.Add(this.lstvewNetworks);
            this.spltcontLists.Size = new System.Drawing.Size(587, 479);
            this.spltcontLists.SplitterDistance = 239;
            this.spltcontLists.TabIndex = 9;
            // 
            // lstvewNetworkList
            // 
            this.lstvewNetworkList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhedChannel,
            this.colhedStrength,
            this.colhedMac,
            this.colhedNetworkSSID,
            this.colhedManufacturer});
            this.lstvewNetworkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvewNetworkList.FullRowSelect = true;
            this.lstvewNetworkList.Location = new System.Drawing.Point(0, 0);
            this.lstvewNetworkList.Name = "lstvewNetworkList";
            this.lstvewNetworkList.Size = new System.Drawing.Size(587, 239);
            this.lstvewNetworkList.TabIndex = 9;
            this.lstvewNetworkList.UseCompatibleStateImageBehavior = false;
            this.lstvewNetworkList.View = System.Windows.Forms.View.Details;
            // 
            // colhedChannel
            // 
            this.colhedChannel.Text = "Channel";
            this.colhedChannel.Width = 80;
            // 
            // colhedStrength
            // 
            this.colhedStrength.Text = "Strength";
            this.colhedStrength.Width = 124;
            // 
            // colhedMac
            // 
            this.colhedMac.Text = "Mac";
            this.colhedMac.Width = 228;
            // 
            // colhedNetworkSSID
            // 
            this.colhedNetworkSSID.Text = "SSID";
            this.colhedNetworkSSID.Width = 215;
            // 
            // colhedManufacturer
            // 
            this.colhedManufacturer.Text = "Manufacturer";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 542);
            this.Controls.Add(this.spltcontMain);
            this.Controls.Add(this.butLoadOUIDB);
            this.Controls.Add(this.butListNeworks);
            this.Controls.Add(this.butPingTest);
            this.Controls.Add(this.txtMaliciousBSSID);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Gonzo Network Alarm";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.spltcontMain.Panel1.ResumeLayout(false);
            this.spltcontMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcontMain)).EndInit();
            this.spltcontMain.ResumeLayout(false);
            this.spltcontLists.Panel1.ResumeLayout(false);
            this.spltcontLists.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcontLists)).EndInit();
            this.spltcontLists.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaliciousBSSID;
        private System.Windows.Forms.Button butPingTest;
        private TheManFromIT.Components.TailViewer tailvewLog;
        private System.Windows.Forms.Button butListNeworks;
        private System.Windows.Forms.Button butLoadOUIDB;
        private System.Windows.Forms.ListView lstvewNetworks;
        private System.Windows.Forms.ColumnHeader colhedSSID;
        private System.Windows.Forms.SplitContainer spltcontMain;
        private System.Windows.Forms.SplitContainer spltcontLists;
        private System.Windows.Forms.ListView lstvewNetworkList;
        private System.Windows.Forms.ColumnHeader colhedChannel;
        private System.Windows.Forms.ColumnHeader colhedStrength;
        private System.Windows.Forms.ColumnHeader colhedMac;
        private System.Windows.Forms.ColumnHeader colhedNetworkSSID;
        private System.Windows.Forms.ColumnHeader colhedManufacturer;
    }
}

