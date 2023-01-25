using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using game;

namespace FifteenWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLibrary1 game;
        DispatcherTimer timer1;
        int time;
        public MainWindow()
        {
            InitializeComponent();
            game = new GameLibrary1(4);
            time = 0;
            timer1 = new DispatcherTimer();
            timer1.Tick += TimerTick;
            timer1.Interval = TimeSpan.FromSeconds(1);
            KeyDown += UndoKeyDown;

        }
        private Button GetButton(int index)
        {
            Button[] buttons = new Button[] 
            { 
                button0, 
                button1, 
                button2, 
                button3, 
                button4, 
                button5, 
                button6, 
                button7, 
                button8, 
                button9, 
                button10,
                button11,
                button12,
                button13,
                button14,
                button15
            };
            return buttons[index];
        }
        private void RefreshButtonField()
        {
            for (int position = 0; position < 16; position++)
            {
                GetButton(position).Content = game.GetNumber(position).ToString();
                if (game.GetNumber(position) == 0)
                    GetButton(position).Visibility = Visibility.Hidden;
                else
                    GetButton(position).Visibility = Visibility.Visible;
            }
        }
        private void StartGame(object sender, RoutedEventArgs e)
        {
            time = 0;
            timer1.Start();
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
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(position);
            CountOfMoves.Content = (game.counter).ToString();
            RefreshButtonField();
            if (game.Check())
            {
                timer1.Stop();
                MessageBoxResult result = MessageBox.Show("Начать новую игру?", "Победа!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    object s = sender; ;
                    RoutedEventArgs e1 = e;
                    time = 0;
                    timer1.Start();
                    StartGame(s, e1);
                    CountOfMoves.Content = "0";
                    game.counter = 0;
                }
                else
                    Close();
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            time++;
            CountOfTime.Content = time.ToString();
        }
        bool f = false;
        private void GameUndo()
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

                CountOfMoves.Content = game.counter.ToString();
                game.counter--;

            }
            else
            {
                MessageBox.Show("Ходов еще не было!");
                f = false;
                RestoreGameAfter0();
            }
        }

        private void UndoClick(object sender, RoutedEventArgs e)
        {
            GameUndo();
        }

        private void UndoKeyDown(object sender, KeyEventArgs e)
        {
            if (game.counter != -1 && e.Key == Key.Z && Keyboard.Modifiers == ModifierKeys.Control)
            {
                GameUndo();
               
            }
            
        }
    }
}