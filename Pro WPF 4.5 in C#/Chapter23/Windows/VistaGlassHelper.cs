using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Windows
{
    public class VistaGlassHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Margins
        {
            public int cxLeftWidth;      // width of left border that retains its size
            public int cxRightWidth;     // width of right border that retains its size
            public int cyTopHeight;      // height of top border that retains its size
            public int cyBottomHeight;   // height of bottom border that retains its size
        }
                           
        
        public static Margins GetDpiAdjustedMargins(IntPtr windowHandle, int left, int right, int top, int bottom)
        {
            // Get System Dpi
            System.Drawing.Graphics desktop = System.Drawing.Graphics.FromHwnd(windowHandle);
            float DesktopDpiX = desktop.DpiX;
            float DesktopDpiY = desktop.DpiY;

            // Set Margins
            VistaGlassHelper.Margins margins = new VistaGlassHelper.Margins();

            // Note that the default desktop Dpi is 96dpi. The  margins are
            // adjusted for the system Dpi.
            margins.cxLeftWidth = Convert.ToInt32(left * (DesktopDpiX / 96));
            margins.cxRightWidth = Convert.ToInt32(right * (DesktopDpiX / 96));
            margins.cyTopHeight = Convert.ToInt32(top * (DesktopDpiX / 96));
            margins.cyBottomHeight = Convert.ToInt32(right * (DesktopDpiX / 96));

            return margins;
        }

        [DllImport("DwmApi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(
            IntPtr hwnd,
            ref Margins pMarInset);

        public static void ExtendGlass(Window win, int left, int right, int top, int bottom)
        {
            // Obtain the window handle for WPF application
            WindowInteropHelper windowInterop = new WindowInteropHelper(win);
            IntPtr windowHandle = windowInterop.Handle;
            HwndSource mainWindowSrc = HwndSource.FromHwnd(windowHandle);
            mainWindowSrc.CompositionTarget.BackgroundColor = Colors.Transparent;

            VistaGlassHelper.Margins margins =
                VistaGlassHelper.GetDpiAdjustedMargins(windowHandle, left, right, top, bottom);

            int returnVal = VistaGlassHelper.DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);

            if (returnVal < 0)
            {
                throw new NotSupportedException("Operation failed.");
            }
        }
    }
}
