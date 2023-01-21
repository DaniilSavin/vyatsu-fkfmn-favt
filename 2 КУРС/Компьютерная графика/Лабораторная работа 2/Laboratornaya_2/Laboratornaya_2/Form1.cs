using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratornaya_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
		}

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
			Graphics graphics = this.CreateGraphics();
			Pen mainPen = new Pen(Color.FromArgb(255, 165, 0));

			PointF Cycloid(float t, float l) 
			{ 
				float a = -0.1f;
				return new PointF((float)(a * (t - l * (Math.Sin(t)))), (float)(a * (1 - l * Math.Cos(t))));
			}

			void Draw(float k, float aMin, float aMax, float step, PointF center, float l)
			{
				PointF currentPoint = new PointF();
				float a = aMin;
				PointF prevPoint = new PointF();
				for (; a < aMax + step;)
				{
					a += step;
					PointF point = Cycloid(a, l);
					currentPoint = new PointF(point.X * k + center.X, point.Y * k + center.Y);
					if (prevPoint == PointF.Empty) prevPoint = currentPoint;
					graphics.DrawLine(mainPen, currentPoint, prevPoint);
					prevPoint = currentPoint;
				}
			}
			PointF _center = new PointF(ClientSize.Width / 2, ClientSize.Height / 2);
			Draw(25, 0, 100, (float)Math.PI / 16, new PointF(_center.X + 120, _center.Y), 3);
			Draw(25, 0, 100, (float)Math.PI / 16, new PointF(_center.X + 120, _center.Y + 50), 0.5f);
		}
	}
}
