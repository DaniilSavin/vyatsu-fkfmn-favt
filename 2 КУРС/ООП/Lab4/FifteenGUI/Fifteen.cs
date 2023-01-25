using System;
using System.Windows.Forms;
using ComponentLibrary;
using game;


namespace game1
{
    public partial class Fifteen : Form
    {
        GameLibrary1 game;
        
        public Fifteen()
        {
            InitializeComponent();
            game = new GameLibrary1(4);
            
        }
        private Button1 GetButton(int index)
        {
            switch (index)
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
                GetButton(position).Visible = (game.GetNumber(position) > 0);
            }
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
        private void button0_Click(object sender, EventArgs e)
        {
            int position = Convert.ToInt32(((Button1)sender).Tag);
            game.Shift(position);
            label1.Text = (game.counter).ToString();
            RefreshButtonField();
            if (game.Check())
            {
                gameTimer1.Stop();
                string s = gameTimer1.Timeinfo();
                DialogResult result = MessageBox.Show($"Ваше время: {s}. Начать новую игру?", "Победа!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    label1.Text = 0.ToString();
                    StartGame();
                    gameTimer1.Start();
                    game.counter = 0;
                }
                else
                    Close();
            }
        }
        private void FormGame15_Load(object sender, EventArgs e)
        {
            StartGame();
            gameTimer1.Start();
        }

        private void menu_start_Click(object sender, EventArgs e)
        {
            StartGame();
            gameTimer1.Start();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        bool f = false;

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

        private void button16_Click(object sender, EventArgs e)
        {
            CancelMove();
        }

        private void Fifteen_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.counter != -1 && e.KeyCode == Keys.Z && e.Control)
            {
                CancelMove();
            }
            if (game.counter == -1 && e.KeyCode == Keys.Z && e.Control)
            {
                if (f == false)
                {
                    game.gameCaretaker.states.Pop();
                    f = true;
                }
                MessageBox.Show("Ходов еще не было!");
                f = false;
                RestoreGameAfter0();
            }
        }
    }
}
