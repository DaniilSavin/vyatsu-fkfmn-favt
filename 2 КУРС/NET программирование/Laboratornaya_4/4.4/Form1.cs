using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4._4
{
    public partial class Form1 : Form
    {
        string TargetString = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        int CurrentIndex;
        const int MaxCount = 10;
        int count = 0;
        Graphics Graph;
        int count_of_mistake = 0;
        Font MyFont = new Font("Arial", 32);
        Random Rand = new Random();
        DateTime start;

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar == 13) && (count == 0) &&level_low.Checked)
            {                                                      //если нажат Enter и символы еще не выводились
                start = DateTime.Now;                                 //запоминаем время начала
                                                                        //определяем номер символа в строке
                CurrentIndex = Rand.Next(TargetString.Length);
                                                                       //отображаем этот символ на форме
                Graph.DrawString(TargetString.Substring(CurrentIndex, 1), MyFont, Brushes.Black, 160, 75);
                if (TargetString[CurrentIndex]!= e.KeyChar)
                {
                    count_of_mistake++;
                }
                                                                                  //увеличиваем количество выведенных символов
                count++;
                                                                                       //изменяем заголовок
                Text = "Нажми правильную клавишу!";
            }
            else if ((count > 0) && (e.KeyChar == TargetString[CurrentIndex]))
            {                                                                    //если проверка началась и введен правильный символ
                if (count == MaxCount)                                           //если проверка закончилась
                {
                                                                                 //определяем количество секунд с начала проверки
                    int time = DateTime.Now.Subtract(start).Seconds;
                                                                               //выводим сообщение
                    MessageBox.Show("Время выполнения = " + time.ToString() + " секунд\n"+"Кол-во ошибок: "+count_of_mistake);
                    Close();                                                    //закрываем форму
                }
                else                                                       //введен не последний символ
                {
                    //очищаем форму цветом формы
                    count_of_mistake++;
                    Graph.Clear(BackColor);
                                                                            //определяем номер символа в строке
                    CurrentIndex = Rand.Next(TargetString.Length);
                                                                             //отображаем этот символ на форме
                    Graph.DrawString(TargetString[CurrentIndex].ToString(), MyFont, Brushes.Black, 160, 75);
                    //увеличиваем количество выведенных символов count++;
                    count++;
                }
            }
                                                                    //если введен неверный символ,
                                                                       //воспроизводим звуковой сигнал
            else System.Media.SystemSounds.Hand.Play();

        }
    }
}
