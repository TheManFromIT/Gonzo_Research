using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace TheManFromIT.Components
{
    public class EnhancedListBox : ListBox
    {
        [Category("Action")]
        public event ScrollEventHandler VerticalScrolled = null;

        protected Boolean BaseVScrolledToMax = false;

        protected override void WndProc(ref System.Windows.Forms.Message msg)
        {

            if (msg.Msg == Win32.WM_VSCROLL)
            {

                Win32.SCROLLINFO si = new Win32.SCROLLINFO();
                si.fMask = Win32.ScrollInfoMask.SIF_ALL;
                si.cbSize = (uint)Marshal.SizeOf(si);
                Win32.GetScrollInfo(msg.HWnd, Win32.ScrollBarDirection.SB_VERT, ref si);

                if (msg.WParam.ToInt32() == (long)Win32.ScrollBarCommands.SB_ENDSCROLL)
                {
                    BaseVScrolledToMax = ((si.nPos + si.nPage) > si.nMax);

                    if (VerticalScrolled != null)
                    {

                        ScrollEventArgs sargs = new ScrollEventArgs(
                            ScrollEventType.EndScroll,
                            si.nPos);
                        VerticalScrolled(this, sargs);

                    }
                }
            }
            base.WndProc(ref msg);
        }

        public void ScrollToMaximum()
        {
            Win32.ScrollToBottom(this);
        }

        public Boolean IsVerticalMaximum { get { return BaseVScrolledToMax; } }
    }
}
