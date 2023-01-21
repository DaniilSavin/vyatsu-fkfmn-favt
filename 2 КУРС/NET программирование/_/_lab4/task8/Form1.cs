using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task8
{
    public partial class Form1 : Form
    {
        Random Rand;
        public Form1()
        {
            InitializeComponent();
            Rand = new Random();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Close();
            MessageBox.Show("Мы так и думали").ToString();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            var rPoint = this.PointToClient(Cursor.Position);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        
        }

        private void NoButton_LocationChanged(object sender, EventArgs e)
        {
           
        }

        private void NoButton_MouseMove(object sender, MouseEventArgs e)
        {
            
            /*int x1 = NoButton.Size.Width;
            int y1 = NoButton.Size.Height;
            int xb = NoButton.Location.X;
            int yb = NoButton.Location.Y;
            int n = Rand.Next(1, (ClientSize.Width-NoButton.Width));
            int m = Rand.Next(1, (ClientSize.Height-NoButton.Height));
            this.NoButton.Location = new Point(this.NoButton.Location.X, this.NoButton.Location.Y);
            NoButton.Location = new Point( n,  m);*/
            int x = Rand.Next(1, (ClientSize.Width - NoButton.Width));
            int y = Rand.Next(1, (ClientSize.Height - NoButton.Height));
            NoButton.Location = new Point(x, y);

        }

        private void NoButton_Enter(object sender, EventArgs e)
        {
            YesButton.Focus();
        }
    }
}
