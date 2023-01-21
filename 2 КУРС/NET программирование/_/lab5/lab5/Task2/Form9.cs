using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form9 : Form
    {
        int n = 9, r = 80;
        int[,] penc, brc;
        Form1 form1 = new Form1();
        void create(int x, int y, int count, int r)
        {
            Graphics Graph = CreateGraphics();
            Pen myPen = new Pen(Color.FromArgb(penc[count - 1, 0], penc[count - 1, 1], penc[count - 1, 2]), 5);
            SolidBrush mybr = new SolidBrush(Color.FromArgb(brc[count - 1, 0], brc[count - 1, 1], brc[count - 1, 2]));
            int pr = r / 2;
            Graph.DrawEllipse(myPen, x - pr, y - pr, r, r);
            Graph.FillEllipse(mybr, x - pr, y - pr, r, r);
            if (count < n && r / 2 > 0)
            {
                create(x - 2 * r, y, count + 1, r * 4 / 9);
                create(x + 2 * r, y, count + 1, r * 4 / 9);
                create(x, y - 2 * r, count + 1, r * 4 / 9);
                create(x, y + 2 * r, count + 1, r * 4 / 9);
            }
        }

        private void Form9_Shown(object sender, EventArgs e)
        {
            Random Rand = new Random();
            penc = new int[n, 3];
            brc = new int[n, 3];
            for (int i = 0; i < n; i++)
            {
                penc[i, 0] = Rand.Next(0, 256);
                penc[i, 1] = Rand.Next(0, 256);
                penc[i, 2] = Rand.Next(0, 256);
                brc[i, 0] = Rand.Next(0, 256);
                brc[i, 1] = Rand.Next(0, 256);
                brc[i, 2] = Rand.Next(0, 256);
            }
            create(this.ClientSize.Width / 2, this.ClientSize.Height / 2, 1, r);
        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
