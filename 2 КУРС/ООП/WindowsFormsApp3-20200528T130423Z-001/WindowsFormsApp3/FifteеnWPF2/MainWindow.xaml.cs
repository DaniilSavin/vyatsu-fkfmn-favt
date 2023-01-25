using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using game;

namespace FifteenWPF2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DockPanel dockPanel;
        Menu menu;
        StatusBar info;
        UniformGrid gameGrid;
        GameLibrary1 game;
        DispatcherTimer timer1;
        int time;
        bool gameIsOn;
        int size;
        object sender; 
        RoutedEventArgs e;
        public MainWindow()
        {
            InitializeComponent();
            dockPanel = new DockPanel() { LastChildFill = true };
            AddChild(dockPanel);
            menu = new Menu();
            DockPanel menuDockPanel = new DockPanel() { HorizontalAlignment = HorizontalAlignment.Stretch };
            menu.Items.Add(new MenuItem() { Header = "Начать игру", FontSize = 16 });
            (menu.Items[0] as MenuItem).Click += StartEvent;
            menu.Items.Add(new MenuItem() { Header = "Изменить размер", FontSize = 16 });
            (menu.Items[1] as MenuItem).Click += ChangeSizeClick;
            KeyDown += UndoKeyDown;
            menu.Items.Add(new MenuItem()
            {
                Header = "Отменa",
                FontSize = 16,
                IsEnabled = false,
                HorizontalAlignment = HorizontalAlignment.Stretch
            });
            (menu.Items[2] as MenuItem).Click += UndoClick;
            info = new StatusBar();
            info.Items.Add(new StatusBarItem() { Content = "Счетчик: ", FontSize = 16 });
            info.Items.Add(new StatusBarItem() { Content = "0", FontSize = 16 });
            info.Items.Add(new Separator());
            info.Items.Add(new StatusBarItem() { Content = "Таймер: ", FontSize = 16 });
            info.Items.Add(new StatusBarItem() { Content = "0", FontSize = 16 });
            gameGrid = new UniformGrid();
            dockPanel.Children.Add(menu);
            DockPanel.SetDock(menu, Dock.Top);
            dockPanel.Children.Add(info);
            DockPanel.SetDock(info, Dock.Bottom);
            dockPanel.Children.Add(gameGrid);
            DockPanel.SetDock(gameGrid, Dock.Bottom);
            game = new GameLibrary1(4);
            gameIsOn = false;
            timer1 = new DispatcherTimer();
            timer1.Tick += TimerTick;
            timer1.Interval = TimeSpan.FromSeconds(1);
            time = 0;
            size = 4;
            ChangeGameField(size);
            Loaded += StartEvent;
          
        }

        private void ChangeSizeClick(object sender, RoutedEventArgs e)
        {
            ChangeSizeWindow window = new ChangeSizeWindow();
            window.ShowDialog();
            int _size = window.Size;
            if (_size != -1)
            {
                ChangeGameField(_size);
                game = new GameLibrary1(_size);
                StartGame(sender,e);
            }
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
                (info.Items[1] as StatusBarItem).Content = game.counter.ToString();
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

        private void StartEvent(object sender, RoutedEventArgs e)
        {
            StartGame(sender,e);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            time++;
            (info.Items[4] as StatusBarItem).Content = time.ToString();
        }

        private void ChangeGameField(int _size)
        {
            size = _size;
            gameGrid.Children.Clear();
            gameGrid.Columns = size;
            gameGrid.Rows = size;
            for (int i = 0; i < gameGrid.Rows; i++)
                for (int j = 0; j < gameGrid.Columns; j++)
                {
                    Button button = new Button()
                    {
                        Content = (i * gameGrid.Rows + j + 1).ToString(),
                        FontSize = 12,
                        Tag = i * gameGrid.Rows + j,
                        Focusable = false,
                        Margin = new Thickness(2, 2, 2, 2),
                    };
                    button.Click += ButtonClick;
                    gameGrid.Children.Add(button);
                }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
                int position = Convert.ToInt32(((Button)sender).Tag);
                game.Shift(position);
                RefreshButtonField();
                (info.Items[1] as StatusBarItem).Content = game.counter.ToString();
                if (game.counter > 0)
                    (menu.Items[2] as MenuItem).IsEnabled = true;
                if (game.Check())
                {
                    timer1.Stop();
                    MessageBoxResult result = MessageBox.Show("Начать новую игру?", "Победа!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        
                        time = 0;
                        timer1.Start();
                        StartGame(sender,e);
                        (info.Items[1] as StatusBarItem).Content = "0";
                        game.counter = 0;
                    }
                    else
                        Close();
                }
                
           
        }


            private Button GetButton(int index)
            {
                return (Button)gameGrid.Children[index];
            }

            private void RefreshButtonField()
            {
                for (int position = 0; position < size * size; position++)
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
    }
    }
