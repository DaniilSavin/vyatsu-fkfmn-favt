using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratornaya_1
{
    public partial class Form1 : Form
    {
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			int x0 = this.ClientSize.Width / 2;
			int y0 = this.ClientSize.Height / 2;
			int x1, y1, x2, y2;
			double x, y;
			const double xMin = -Math.PI * 2;
			const double xMax = Math.PI * 2;
			const double step = 0.01;
			Graphics Graph;
			Pen MyPen = new Pen(Color.FromArgb(255, 165, 0));	
			Graph = this.CreateGraphics();
			Brush brush = new SolidBrush(Color.White);
			int offset = 20;
			int k = 50;

			void DrawArrow(int _x, int _y, int turn)
			{
				if (turn == 0)
				{
					Graph.DrawLine(MyPen, _x, _y, _x + 10, _y + 5);
					Graph.DrawLine(MyPen, _x, _y, _x + 10, _y - 5);
				}
				else
				if (turn == 180)
				{
					Graph.DrawLine(MyPen, _x, _y, _x - 10, _y + 5);
					Graph.DrawLine(MyPen, _x, _y, _x - 10, _y - 5);
				}
				else
				if (turn == 90)
				{
					Graph.DrawLine(MyPen, _x + 5, _y + 10 - 2, _x, _y - 2);
					Graph.DrawLine(MyPen, _x - 5, _y + 10 - 2, _x, _y - 2);
				}
				else
				if (turn == 270)
				{
					Graph.DrawLine(MyPen, _x + 5, _y - 10 - 2, _x, _y);
					Graph.DrawLine(MyPen, _x - 5, _y - 10 - 2, _x, _y);
				}

			}

			DrawArrow(offset, ClientSize.Height / 2, 0);
			DrawArrow(ClientSize.Width / 2, offset, 90);
			DrawArrow(ClientSize.Width - offset, ClientSize.Height / 2, 180);
			DrawArrow(ClientSize.Width / 2, ClientSize.Height - offset, 270);

			Graph.DrawLine(MyPen, offset, ClientSize.Height / 2, ClientSize.Width - offset, ClientSize.Height / 2);
			Graph.DrawLine(MyPen, ClientSize.Width / 2, offset, ClientSize.Width / 2, ClientSize.Height - offset);
			double pi = 0.5;
			for (int i = ClientSize.Width / 2 + (int)Math.PI * k / 2; i < ClientSize.Width - offset; i += (int)Math.PI * k / 2)
			{
				Graph.DrawLine(MyPen, i, ClientSize.Height / 2 - 5, i, ClientSize.Height / 2 + 5);
				Graph.DrawString(pi.ToString() + "π", new Font("Comic Sans MS", 10), brush, i - 5, (ClientSize.Height / 2) + 5);
				pi += 0.5;
			}
			pi = -0.5;
			for (int i = ClientSize.Width / 2 - (int)Math.PI * k / 2; i > offset; i -= (int)Math.PI * k / 2)
			{
				Graph.DrawLine(MyPen, i, ClientSize.Height / 2 - 5, i, ClientSize.Height / 2 + 5);
				Graph.DrawString(pi.ToString() + "π", new Font("Comic Sans MS", 10), brush, i - 5, (ClientSize.Height / 2) + 5);
				pi -= 0.5;
			}
			pi = 1;
			for (int i = ClientSize.Height / 2 - k; i > offset; i -= k)
			{
				Graph.DrawLine(MyPen, ClientSize.Width / 2 + 5, i, ClientSize.Width / 2 - 5, i);
				Graph.DrawString(pi.ToString(), new Font("Comic Sans MS", 10), brush, (ClientSize.Width / 2) + 5, i);
				pi += 1;
			}
			pi = -1;
			for (int i = ClientSize.Height / 2 + k; i < ClientSize.Height - offset; i += k)
			{
				Graph.DrawLine(MyPen, ClientSize.Width / 2 + 5, i, ClientSize.Width / 2 - 5, i);
				Graph.DrawString(pi.ToString(), new Font("Comic Sans MS", 10), brush, (ClientSize.Width / 2) + 5, i);
				pi -= 1;
			}


			x = xMin;
			y = 1 - Math.Sin(x-1);
			
			x1 = (int)(x0 + x * k);
			y1 = (int)(y0 - y * k);
			while (x < xMax)
			{
				x = x + step;			
				y = 1 - Math.Sin(x-1);
				x2 = (int)(x0 + x * k);
				y2 = (int)(y0 - y * k);				
				Graph.DrawLine(MyPen, x1, y1, x2, y2);
				x1 = x2;
				y1 = y2;
			}
		}
	}
}
