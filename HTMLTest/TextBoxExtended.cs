using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SignatureGeneratorProgram
{
    class TextBoxExtended : TextBox
    {
        private bool shouldHighLight = false;
        private string mWatermark;

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        private const int WM_NCPAINT = 0x85;

        private static class NativeMethods
        {
            internal const uint EM_SETwatermarkBANNER = 0x1501;

            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);
        }

        public string watermark
        {
            get
            {
                return mWatermark;
            }
            set
            {
                mWatermark = value;
                Updatewatermark();
            }
        }

        private void Updatewatermark()
        {
            if (IsHandleCreated && mWatermark != null)
            {
                NativeMethods.SendMessage(Handle, NativeMethods.EM_SETwatermarkBANNER, (IntPtr)1, mWatermark);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Updatewatermark();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCPAINT && shouldHighLight)
            {
                drawRedBorder();
            }
        }        

        public void highlight()
        {
            shouldHighLight = true;

            if (shouldHighLight)
            {
                drawRedBorder();
            }
        }

        public void noHighlight()
        {
            shouldHighLight = false;
        }

        private void drawRedBorder()
        {
            var dc = GetWindowDC(Handle);

            using (Graphics g = Graphics.FromHdc(dc))
            {
                g.DrawRectangle(Pens.Red, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}
