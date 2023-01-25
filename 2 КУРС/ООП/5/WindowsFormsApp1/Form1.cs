using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    enum direction : byte { Up, Right, Down, Left };    
    public partial class Form1 : Form
    {
        bool ctrl = false;
        int AlgStep = 0;
        int k = -1;
        Cockroach currentCockroach;//рабочий Таракан - активный Таракан, который будет выполнять алгоритм
        PictureBox workpb;//рабочее поле PictureBox - поле на котрой будет рабочий Таракан
        List<Cockroach> LC;//Список для хранения созданных Тараканов
        List<PictureBox> PB;//Список для хранения созданных объектов PictureBox
        List<Cockroach> selectedCockroach;
        List<PictureBox> selectedWorkpb;
        public Form1()
        {
            InitializeComponent();
            LC = new List<Cockroach>();
            PB = new List<PictureBox>();
            selectedCockroach = new List<Cockroach>();
            selectedWorkpb = new List<PictureBox>();
            KeyPreview = true;
        }
        public void RePaint(PictureBox p, Cockroach workCockroach)
        {
            p.Bounds = new Rectangle(workCockroach.X, workCockroach.Y, workCockroach.Image.Width, workCockroach.Image.Height);//создание новых границ изображения для PictureBox
            p.Image = workCockroach.Image;
        }
        public void Show(PictureBox p, Panel owner, Cockroach workCockroach)
        {
            workCockroach.X = (owner.Width - workCockroach.Image.Width) / 2;
            workCockroach.Y = (owner.Height - workCockroach.Image.Height) / 2;
            RePaint(p, workCockroach);
            owner.Controls.Add(p);// добавляем PictureBox к элементу Panel
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = selectedCockroach.Count.ToString();
            if (AlgStep == Algorithm.Items.Count) //конец алгоритма
            {
                timerAlgorithm.Enabled = false;
            }
            else//выполнение команды из списка
            {
                string s = (string)Algorithm.Items[AlgStep];
                Algorithm.SetSelected(AlgStep, true);
                if (s == "Step")
                {
                    for (int i = 0; i < selectedCockroach.Count; i++)
                    {
                        selectedCockroach[i].Step();
                        RePaint(selectedWorkpb[i], selectedCockroach[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < selectedCockroach.Count; i++)
                    {
                        selectedCockroach[i].ChangeTrend(s[0]);
                        RePaint(selectedWorkpb[i], selectedCockroach[i]);
                    }
                }

                AlgStep++;
            }
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void IMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                k = PB.IndexOf(sender as PictureBox);//запоминаем номер нажатого компонента
                PictureBox workpb = sender as PictureBox;//объявляет его рабочим
                currentCockroach = LC[k];//по найденному номеру находим Таракана в списке
                if (ctrl)
                {
                    if (!selectedCockroach.Contains(currentCockroach))
                    selectedCockroach.Add(currentCockroach);
                    if (!(selectedWorkpb.Contains(workpb)))
                        selectedWorkpb.Add(workpb);
                }
                else
                {
                    selectedCockroach.Clear();
                    selectedCockroach.Add(currentCockroach);
                    selectedWorkpb.Clear();
                    selectedWorkpb.Add(workpb);
                }
            }
        }
        private void IMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox picture = sender as PictureBox;
                picture.Tag = new Point(e.X, e.Y);//запоминаем координаты мыши на момент начала перетаскивания
                picture.DoDragDrop(sender, DragDropEffects.Move);//начинаем перетаскивание ЧЕГО и с КАКИМ ЭФФЕКТОМ
            }
        }
        public Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);

                bitmap = new Bitmap(image);

            }
            return bitmap;
        }
        private void NewBtn_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = ConvertToBitmap("cockroach1.jpg");
            currentCockroach = new Cockroach(bitmap);
            PictureBox p = new PictureBox();
            Show(p, Field, currentCockroach);
            p.MouseMove += new MouseEventHandler(IMouseMove);
            p.MouseDown += new MouseEventHandler(IMouseDown);
            PB.Add(p);
            LC.Add(currentCockroach);
            workpb = p;
        }

        private void Field_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void Field_DragDrop(object sender, DragEventArgs e)
        {
            //извлекаем PictureBox
            PictureBox picture = (PictureBox)e.Data.GetData(typeof(PictureBox));
            Panel panel = sender as Panel;
            //получаем клиентские координаты в момент отпускания кнопки
            Point pointDrop = panel.PointToClient(new Point(e.X, e.Y));
            //извлекаем клиентские координаты мыши в момент начала перетскивания
            Point pointDrag = (Point)picture.Tag;
            //вычисляем и устанавливаем Location для PictureBox в Panel
            picture.Location = pointDrop;
            //устанавливаем координаты для X и Y для рабочего таракана
            currentCockroach.X = picture.Location.X;
            currentCockroach.Y = picture.Location.Y;
            picture.Parent = panel;
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void DownBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void StepBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            AlgStep = 0;
            timerAlgorithm.Enabled = true;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Clear();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                ctrl = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                ctrl = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PB[k].Visible = false;
                PB.RemoveAt(k);
                LC.RemoveAt(k);
            }
            catch (Exception)
            {
            }          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                    }
                }

                Bitmap bitmap = ConvertToBitmap(filePath);
                PB[k].Image = (bitmap);
                LC[k].Image = (bitmap);
            }
            catch (Exception)
            {
            }
        }
    }
}
