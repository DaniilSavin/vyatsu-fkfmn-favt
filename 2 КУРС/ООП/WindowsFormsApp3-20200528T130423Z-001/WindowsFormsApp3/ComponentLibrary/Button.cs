using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentLibrary
{
    public partial class Button1 : UserControl
    {
        private StringFormat SF = new StringFormat();
        private bool click = false;
        private bool MouseEntered = false;
        public Button1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(91, 65);
            BackColor = Color.Red;
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);
            Rectangle rect = new Rectangle(0,0,Width-1,Height-1);
            graph.DrawRectangle(new Pen(BackColor), rect);
            graph.FillRectangle(new SolidBrush(BackColor), rect);
            graph.DrawString(base.Text, Font, new SolidBrush(ForeColor), rect, SF);
            if (MouseEntered)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(60, Color.White)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.White)), rect);
            }

        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            click = true;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
            Invalidate();
        }
    }
}
