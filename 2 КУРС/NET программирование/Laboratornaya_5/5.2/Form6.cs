using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._2
{
    public partial class Form6 : Form
    {
        private const string DIGITS = "12345678";//Цифры
        private const string LETTERS = "abcdefgh";//Буквы
        private Bitmap desk;//Доска
        private int sqsize = 40;//Размер клетки
        //Кисти для рисования клеток и текста
        private Brush[] brushes = new Brush[3] { Brushes.Brown, Brushes.Yellow, Brushes.Black };
        //Перо для границ доски
        private Pen pen = new Pen(Color.Black, 2) { Alignment = PenAlignment.Inset };
        //Шрифт
        private System.Drawing.Font f = new Font("Arial", 17f);
        Graphics Graph;
        public Form6()
        {
            InitializeComponent();

            desk = new Bitmap(2000, 2000);//Размер заведомо больше требуемого

            DrawDesk(desk, sqsize, brushes[0], brushes[1], pen, f, brushes[2]);
            this.Paint += Form1_Paint;


        void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (desk != null) e.Graphics.DrawImage(desk, 0, 0);
        }
    }
    }
}
