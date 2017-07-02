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
            this.txtMaliciousBSSID = new System.Windows.Forms.TextBox();
            this.butPingTest = new System.Windows.Forms.Button();
            this.tailvewLog = new TheManFromIT.Components.TailViewer();
            this.butListNeworks = new System.Windows.Forms.Button();
            this.butLoadOUIDB = new System.Windows.Forms.Button();
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
            // tailvewLog
            // 
            this.tailvewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tailvewLog.Location = new System.Drawing.Point(16, 44);
            this.tailvewLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tailvewLog.Name = "tailvewLog";
            this.tailvewLog.Size = new System.Drawing.Size(799, 289);
            this.tailvewLog.TabIndex = 4;
            this.tailvewLog.Target = "";
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
            this.butLoadOUIDB.Location = new System.Drawing.Point(581, 14);
            this.butLoadOUIDB.Name = "butLoadOUIDB";
            this.butLoadOUIDB.Size = new System.Drawing.Size(132, 30);
            this.butLoadOUIDB.TabIndex = 7;
            this.butLoadOUIDB.Text = "Load OUI DB";
            this.butLoadOUIDB.UseVisualStyleBackColor = true;
            this.butLoadOUIDB.Click += new System.EventHandler(this.butLoadOUIDB_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 356);
            this.Controls.Add(this.butLoadOUIDB);
            this.Controls.Add(this.butListNeworks);
            this.Controls.Add(this.tailvewLog);
            this.Controls.Add(this.butPingTest);
            this.Controls.Add(this.txtMaliciousBSSID);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Gonzo Network Alarm";
            this.Load += new System.EventHandler(this.FormMain_Load);
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
    }
}

