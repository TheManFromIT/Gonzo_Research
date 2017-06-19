using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TheManFromIT.Components
{
    internal class Win32
    {

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetScrollInfo(IntPtr hwnd, ScrollBarDirection fnBar, ref SCROLLINFO lpsi);

        [DllImport("User32.Dll")]
        private static extern bool SendMessage(IntPtr hWnd, int Msg, ScrollBarCommands wParam, int lParam);
        public const int SB_LINEDOWN = 1;

        public const int WM_HSCROLL = 0x114;
        public const int WM_VSCROLL = 0x115;

        [StructLayout(LayoutKind.Sequential)]
        public struct SCROLLINFO
        {
            public uint cbSize;
            public ScrollInfoMask fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        public enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }

        public enum ScrollInfoMask
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
        }

        public enum ScrollBarCommands
        {
            SB_LINEUP = 0,
            SB_LINELEFT = 0,
            SB_LINEDOWN = 1,
            SB_LINERIGHT = 1,
            SB_PAGEUP = 2,
            SB_PAGELEFT = 2,
            SB_PAGEDOWN = 3,
            SB_PAGERIGHT = 3,
            SB_THUMBPOSITION = 4,
            SB_THUMBTRACK = 5,
            SB_TOP = 6,
            SB_LEFT = 6,
            SB_BOTTOM = 7,
            SB_RIGHT = 7,
            SB_ENDSCROLL = 8
        }
        public static void ScrollToBottom(Control Control)
        {
            SendMessage(Control.Handle, WM_VSCROLL, ScrollBarCommands.SB_BOTTOM, 0);
        }

        public static void ScrollToTop(Control Control)
        {
            SendMessage(Control.Handle, WM_VSCROLL, ScrollBarCommands.SB_TOP, 0);
        }

    }
}
