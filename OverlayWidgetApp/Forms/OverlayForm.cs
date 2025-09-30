using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using OverlayWidgetApp.Services;
using SkiaSharp;


namespace OverlayWidgetApp
{
    public partial class OverlayForm : Form
    {
        private SKBitmap _skBitmap;
        private Bitmap _gdiBitmap;

        public OverlayForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            TopMost = true;
            StartPosition = FormStartPosition.Manual;

            Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.2);
            Height = 35;
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width - 125, 0);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80000 | 0x20 | 0x80 | 0x8000000;
                return cp;
            }
        }

        private void RenderOverlay(string displayText)
        {
            _skBitmap = new SKBitmap(Width, Height, SKColorType.Bgra8888, SKAlphaType.Premul);
            using var canvas = new SKCanvas(_skBitmap);
            canvas.Clear(SKColors.Transparent);

            using var typeface = SKTypeface.FromFamilyName("Albertus", SKFontStyle.Bold);
            float fontSize = 14f;

            var font = new SKFont(typeface, fontSize);

            using var paint = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.White,
            };

            using var outline = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.Black,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 2
            };

            using var blob = SKTextBlob.Create(displayText, font);
            var bounds = blob.Bounds;


            float x = (Width - bounds.Width) / 2 - bounds.Left;
            float y = (Height - bounds.Height) / 2 - bounds.Top;

            canvas.DrawText(blob, x, y, outline);
            canvas.DrawText(blob, x, y, paint);

            ApplyBitmap(_skBitmap);
        }

        private void ApplyBitmap(SKBitmap skBitmap)
        {
            using var image = SKImage.FromBitmap(skBitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            _gdiBitmap = new Bitmap(new MemoryStream(data.ToArray()));

            IntPtr screenDC = GetDC(IntPtr.Zero);
            IntPtr memDC = CreateCompatibleDC(screenDC);
            IntPtr hBitmap = _gdiBitmap.GetHbitmap(Color.FromArgb(0));
            IntPtr oldBitmap = SelectObject(memDC, hBitmap);

            SIZE size = new SIZE(_gdiBitmap.Width, _gdiBitmap.Height);
            POINT source = new POINT(0, 0);
            POINT topPos = new POINT(Left, Top);

            BLENDFUNCTION blend = new BLENDFUNCTION
            {
                BlendOp = 0,
                BlendFlags = 0,
                SourceConstantAlpha = 255,
                AlphaFormat = 1
            };

            UpdateLayeredWindow(Handle, screenDC, ref topPos, ref size, memDC, ref source, 0, ref blend, 2);

            SelectObject(memDC, oldBitmap);
            DeleteObject(hBitmap);
            DeleteDC(memDC);
            ReleaseDC(IntPtr.Zero, screenDC);
        }

        #region Native Methods
        [DllImport("user32.dll", SetLastError = true)] static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);
        [DllImport("user32.dll")] static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")] static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll")] static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")] static extern bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")] static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("gdi32.dll")] static extern bool DeleteObject(IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)] struct POINT { public int X, Y; public POINT(int x, int y) { X = x; Y = y; } }
        [StructLayout(LayoutKind.Sequential)] struct SIZE { public int cx, cy; public SIZE(int cx, int cy) { this.cx = cx; this.cy = cy; } }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct BLENDFUNCTION
        {
            public byte BlendOp, BlendFlags, SourceConstantAlpha, AlphaFormat;
        }
        #endregion
        public void Start(DateTime date)
        {
            string start = date.ToString("HH:mm");
            string end = "";

            if (date.TimeOfDay < TimeSpan.FromHours(7))
            {
                end = new DateTime(date.Date.Year, date.Date.Month, date.Date.Day, 15, 0, 0).ToString("HH:mm");
            }
            else
            {
                end = date.AddHours(8).ToString("HH:mm");
            }

            string displayText = $"Start: {start}  |  Koniec: {end}";
            RenderOverlay(displayText);
        }
    }
}