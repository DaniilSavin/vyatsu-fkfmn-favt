using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Task4._8
{
    public partial class Form2 : Form
    {
        Graphics Graph;
        SolidBrush Brush;
        Pen _Pen;        
        Random rnd = new Random();

        int count = 1;
        int _shapeType = 1;
        public int TimerInterval
        {
            get { return timer1.Interval; }
            set { timer1.Interval = value; }
        }
        public int countOfShapes
        {
            get { return count; }
            set { count = value; }
        }
        public int shapeType
        {
            get { return _shapeType; }
            set { _shapeType = value; }
        }
        public bool TimerEnable
        {
            get { return timer1.Enabled; }
            set { timer1.Enabled = value; }
        }

        public Form2()
        {            
            InitializeComponent();
            Graph = CreateGraphics();
            Brush = new SolidBrush(Color.Aqua);
            _Pen = new Pen(Color.White, 1);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_DoubleClick(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
            switch (_shapeType)
                {
                    case 1:
                    for (int i = 0; i < count; i++)
                    {
                        Rectangle rectangle = new Rectangle(rnd.Next(0, Form1.ActiveForm.Width), rnd.Next(0, Form1.ActiveForm.Height), rnd.Next(0, 100), rnd.Next(0, 100));
                        Graph.DrawRectangle(_Pen, rectangle);
                    }
                    break;
                    case 2:
                        for (int i = 0; i < count; i++)
                        {

                            int x = rnd.Next(0, Form1.ActiveForm.Width);
                            int y = rnd.Next(0, Form1.ActiveForm.Height);
                            int w = rnd.Next(0, 100);
                            int h = rnd.Next(0, 100);
                            Graph.FillEllipse(Brush, x, y, w, h);
                            Graph.DrawEllipse(_Pen, x, y, w, h);
                        }
                    break;
                    case 3:
                    for (int i = 0; i < count; i++)
                    {
                        if (rnd.Next(0, 3) == 1)
                        {
                            Rectangle rectangle = new Rectangle(rnd.Next(0, Form1.ActiveForm.Width), rnd.Next(0, Form1.ActiveForm.Height), rnd.Next(0, 100), rnd.Next(0, 100));
                            Graph.DrawRectangle(_Pen, rectangle);
                        }
                        else
                        {
                            int x = rnd.Next(0, Form1.ActiveForm.Width);
                            int y = rnd.Next(0, Form1.ActiveForm.Height);
                            int w = rnd.Next(0, 100);
                            int h = rnd.Next(0, 100);
                            Graph.FillEllipse(Brush, x, y, w, h);
                            Graph.DrawEllipse(_Pen, x, y, w, h);
                        }
                    }
                        break;
                }
           
        }
    }
}
