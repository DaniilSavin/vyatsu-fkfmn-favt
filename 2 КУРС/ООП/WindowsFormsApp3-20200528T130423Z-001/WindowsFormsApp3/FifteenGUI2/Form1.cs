using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using game;

namespace FifteenGUI2
{
    public partial class MainForm : Form
    {
        //TableLayoutPanel tablelyoutpanel1, tablelayoutpanel2;
        MenuStrip menu;
        StatusStrip info;
        GameLibrary1 game;
        int size;
        public MainForm()
        {
            InitializeComponent();
           /* tablelyoutpanel1 = new TableLayoutPanel()
            {
                Parent = this,
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
            };*/
           // tablelyoutpanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
           // tablelyoutpanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
           // tablelyoutpanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
            menu = new MenuStrip();
            menu.Items.Add("");
            menu.Items.Add("");
            menu.Items.Add("");
            menu.Items[2].Enabled = false;
            menu.Items[2].Alignment = ToolStripItemAlignment.Right;
            info = new StatusStrip();
          //  tablelayoutpanel2 = new TableLayoutPanel();
          //  tablelayoutpanel2.Dock = DockStyle.Fill;
          //  tablelyoutpanel1.Controls.Add(menu, 0, 0);
          //  tablelyoutpanel1.Controls.Add(tablelayoutpanel2, 0, 1);
          //  tablelyoutpanel1.Controls.Add(info, 0, 2);
            //NewField(4);
            game = new GameLibrary1(4);
            
        }

        private void NewField(int _size)
        {
            size = _size;
           // tablelayoutpanel2.RowCount = size;
           // tablelayoutpanel2.ColumnCount = size;
           // tablelayoutpanel2.RowStyles.Clear();
           // tablelayoutpanel2.ColumnStyles.Clear();
          /*  for (int i = 0; i < tablelayoutpanel2.RowCount; i++)
                tablelayoutpanel2.RowStyles.Add(new RowStyle(SizeType.Percent, (float)100 / tablelayoutpanel2.RowCount));
            for (int i = 0; i < tablelayoutpanel2.ColumnCount; i++)
                tablelayoutpanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)100 / tablelayoutpanel2.ColumnCount));
            tablelayoutpanel2.Controls.Clear();
            for (int i = 0; i < tablelayoutpanel2.RowCount; i++)
                for (int j = 0; j < tablelayoutpanel2.ColumnCount; j++)
                {
                    Button button = new Button()
                    {
                        Text = (i * tablelayoutpanel2.RowCount + j + 1).ToString(),
                        Font = new Font("Arial", 12),
                        Dock = DockStyle.Fill,
                        Tag = i * tablelayoutpanel2.RowCount + j,
                        TabStop = false,
                    };
                    button.Click += ButtonClick;
                    tablelayoutpanel2.Controls.Add(button, j, i);
                }*/
         
        }
        DateTime date1 = new DateTime(0, 0);
        private void ButtonClick(object sender, EventArgs e)
        {
            label1.Text = "0";
            int position = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(position);
            label1.Text = (game.counter).ToString();
            RefreshButtonField();
            if (game.Check())
            {
                timer1.Enabled = false;
                DialogResult result = MessageBox.Show("Начать новую игру?", "Победа!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    label1.Text = 0.ToString();
                    StartGame();
                    date1 = new DateTime(0, 0);
                    timer1.Enabled = true;
                    game.counter = 0;
                }
                else
                    Close();
            }
        }
        private Button GetButton(int index)
        {
            switch(index)
            {
                case 0:
                    return button0;
                case 1:
                    return button1;
                case 2:
                    return button2;
                case 3:
                    return button3;
                case 4:
                    return button4;
                case 5:
                    return button5;
                case 6:
                    return button6;
                case 7:
                    return button7;
                case 8:
                    return button8;
                case 9:
                    return button9;
                case 10:
                    return button10;
                case 11:
                    return button11;
                case 12:
                    return button12;
                case 13:
                    return button13;
                case 14:
                    return button14;
                case 15:
                    return button15;
                default:
                    return null;
            }
        }
        private void RefreshButtonField()
        {
            for (int position = 0; position < 16; position++)
            {
                GetButton(position).Text = game.GetNumber(position).ToString();
                if (game.GetNumber(position) == 0)
                    GetButton(position).Hide();
                else
                    GetButton(position).Show();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            date1 = date1.AddSeconds(1);
            label2.Text = date1.ToString("mm:ss");
        }

        private void изменитьРазмерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            NewSize form = new NewSize();
            form.ShowDialog();
            int _size = form.Size;
            if (_size != -1)
            {
                NewField(_size);
                game = new GameLibrary1(_size);
                StartGame();
            }
            timer1.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartGame();
            date1 = new DateTime(0, 0);
            timer1.Enabled = true;
            game.counter = 0;
        }

        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
            date1 = new DateTime(0, 0);
            timer1.Enabled = true;
            game.counter = 0;
        }

        private void StartGame()
        {
            game.start();
            for (int i = 0; i < 100; i++)
                game.ShiftRandom();
            game.gameCaretaker.states.Clear();
            game.counter = 0;
            game.moves = 0;
            GameLibrary.GameMemento state = new GameLibrary.GameMemento(game.field, game.x0, game.y0, game.counter);
            game.gameCaretaker.Save(state);

            RefreshButtonField();
        }
        private void RestoreGameAfter0()
        {
            game.gameCaretaker.states.Clear();
            game.counter = 0;
            game.moves = 0;
            GameLibrary.GameMemento state = new GameLibrary.GameMemento(game.field, game.x0, game.y0, game.counter);
            game.gameCaretaker.Save(state);
            RefreshButtonField();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CancelMove();
        }

        bool f = false;

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.counter != -1 && e.KeyCode == Keys.Z && e.Control)
            {

                CancelMove();
            }
        }

        private void CancelMove()
        {
            if (f == false)
            {
                game.gameCaretaker.states.Pop();
                f = true;
            }
            if (game.counter != -1)
            {
                game.Cancel();
                RefreshButtonField();

                label1.Text = game.counter.ToString();
                game.counter--;

            }
            else
            {
                MessageBox.Show("Ходов еще не было!");
                f = false;
                RestoreGameAfter0();
            }
        }
    }
}
