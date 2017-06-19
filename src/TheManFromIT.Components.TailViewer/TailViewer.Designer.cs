namespace TheManFromIT.Components
{
    partial class TailViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstLines = new TheManFromIT.Components.EnhancedListBox();
            this.tolstrpcontViewer = new System.Windows.Forms.ToolStripContainer();
            this.tolstrpViewer = new System.Windows.Forms.ToolStrip();
            this.tolstrpbutClear = new System.Windows.Forms.ToolStripButton();
            this.tolstrplblTarget = new System.Windows.Forms.ToolStripLabel();
            this.tolstrpcontViewer.ContentPanel.SuspendLayout();
            this.tolstrpcontViewer.TopToolStripPanel.SuspendLayout();
            this.tolstrpcontViewer.SuspendLayout();
            this.tolstrpViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstLines
            // 
            this.lstLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLines.FormattingEnabled = true;
            this.lstLines.HorizontalScrollbar = true;
            this.lstLines.Location = new System.Drawing.Point(0, 0);
            this.lstLines.Name = "lstLines";
            this.lstLines.Size = new System.Drawing.Size(714, 290);
            this.lstLines.TabIndex = 0;
            // 
            // tolstrpcontViewer
            // 
            // 
            // tolstrpcontViewer.ContentPanel
            // 
            this.tolstrpcontViewer.ContentPanel.AutoScroll = true;
            this.tolstrpcontViewer.ContentPanel.Controls.Add(this.lstLines);
            this.tolstrpcontViewer.ContentPanel.Size = new System.Drawing.Size(714, 292);
            this.tolstrpcontViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tolstrpcontViewer.Location = new System.Drawing.Point(0, 0);
            this.tolstrpcontViewer.Name = "tolstrpcontViewer";
            this.tolstrpcontViewer.Size = new System.Drawing.Size(714, 317);
            this.tolstrpcontViewer.TabIndex = 1;
            this.tolstrpcontViewer.Text = "toolStripContainer1";
            // 
            // tolstrpcontViewer.TopToolStripPanel
            // 
            this.tolstrpcontViewer.TopToolStripPanel.Controls.Add(this.tolstrpViewer);
            // 
            // tolstrpViewer
            // 
            this.tolstrpViewer.Dock = System.Windows.Forms.DockStyle.None;
            this.tolstrpViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolstrpbutClear});
            this.tolstrpViewer.Location = new System.Drawing.Point(3, 0);
            this.tolstrpViewer.Name = "tolstrpViewer";
            this.tolstrpViewer.Size = new System.Drawing.Size(66, 25);
            this.tolstrpViewer.TabIndex = 1;
            this.tolstrpViewer.Text = "toolStrip1";
            // 
            // tolstrpbutClear
            // 
            this.tolstrpbutClear.Image = global::TheManFromIT.Components.Properties.Resources.Clear;
            this.tolstrpbutClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolstrpbutClear.Name = "tolstrpbutClear";
            this.tolstrpbutClear.Size = new System.Drawing.Size(54, 22);
            this.tolstrpbutClear.Text = "Clear";
            this.tolstrpbutClear.ToolTipText = "Clear View";
            this.tolstrpbutClear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // tolstrplblTarget
            // 
            this.tolstrplblTarget.Name = "tolstrplblTarget";
            this.tolstrplblTarget.Size = new System.Drawing.Size(0, 22);
            // 
            // TailViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tolstrpcontViewer);
            this.Name = "TailViewer";
            this.Size = new System.Drawing.Size(714, 317);
            this.tolstrpcontViewer.ContentPanel.ResumeLayout(false);
            this.tolstrpcontViewer.TopToolStripPanel.ResumeLayout(false);
            this.tolstrpcontViewer.TopToolStripPanel.PerformLayout();
            this.tolstrpcontViewer.ResumeLayout(false);
            this.tolstrpcontViewer.PerformLayout();
            this.tolstrpViewer.ResumeLayout(false);
            this.tolstrpViewer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TheManFromIT.Components.EnhancedListBox lstLines;
        private System.Windows.Forms.ToolStripContainer tolstrpcontViewer;
        private System.Windows.Forms.ToolStripLabel tolstrplblTarget;
        private System.Windows.Forms.ToolStrip tolstrpViewer;
        private System.Windows.Forms.ToolStripButton tolstrpbutClear;
    }
}
