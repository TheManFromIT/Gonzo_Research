using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TheManFromIT.Components
{
    public partial class TailViewer : UserControl
    {

        protected delegate void InvokeAppend(String Line);
        protected delegate void InvokeClear();

        public TailViewer()
        {
            InitializeComponent();

            lstLines.ScrollAlwaysVisible = true;
        
        }

        public void Clear()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new InvokeClear(Clear));

            }
            else
            {
                lstLines.Items.Clear();
            }

        }

        public void Append(String Output)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new InvokeAppend(Append), new Object[] { Output });
            }
            else
            {
                Boolean autoScroll = false;

                autoScroll = lstLines.IsVerticalMaximum;

                lstLines.Items.AddRange(Output.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));

                lstLines.ScrollToMaximum();
            }

        }

        public virtual String Target { get { return tolstrplblTarget.Text; } set { tolstrplblTarget.Text = value; } }

        public virtual EnhancedListBox List { get { return lstLines; } }

        protected virtual void HandleClearButtonClick(object sender, EventArgs e)
        {
            Clear();
        }

    }

}
