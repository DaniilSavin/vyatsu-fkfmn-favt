using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3._1
{
    public partial class Form1 : Form
    {
        string keyvalue;
        string язык;
        string английские_буквы = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
        string русские_буквы = "ЙЦУКЕНГШЩЗФЫВАПРОЛДЯЧСМИТЬБЮХЪЭЖЁйцукенгшщзфывапролдячсмитьбюхъэжё";
        string какая_буква;
        string цифры = "1234567890";
        string знаки = ",;'][/.!@#$%^&*()_+-!№;%:?*";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) 
        {
           

           keyvalue = e.KeyValue.ToString();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (1)
            {
                case 1:
                    int i=0;
                    do
                    {
                        if (e.KeyChar == цифры[i])
                        {
                            язык = "Цифра\n";
                            
                            goto case 3;
                        }
                        i++;
                    }
                    while (i<цифры.Length);
                    i = 0;
                    do
                    {
                        if (e.KeyChar == знаки[i])
                        {
                            язык = "Знак\n";
                            

                            goto case 3;
                        }
                        i++;
                    } while (i<знаки.Length);
                    i = 0;
                    do
                    { 
                        if (e.KeyChar == русские_буквы[i])
                        {
                            язык = "Кириллица\n";
                            
                            goto case 3;
                        }
                        
                        i++;

                    } while (i < русские_буквы.Length);
                    goto case 2;
 
                case 2:
                    i = 0;
                    do
                    {
                        if (e.KeyChar == английские_буквы[i])
                        {
                            
                            язык = "Латиница\n";
                            goto case 3;
                        }
                        i++;
                    }
                    while (i < английские_буквы.Length);
                    goto case 3;
                    
                case 3:
                    if (i <= 32 && язык == "Кириллица\n")
                    {
                        какая_буква = "Заглавная буква\n";
                    }
                    else
                    {
                        if (язык != "Цифра\n" && язык != "Знак\n" && i >= 32)
                        {
                            какая_буква = "Строчная буква\n";
                        }
                    }
                    if (i < 26 && язык == "Латиница\n")
                    {
                        какая_буква = "Заглавная буква\n";
                    }
                    else
                    {
                        if (язык != "Цифра\n" && язык != "Знак\n" && i >= 26)
                        {
                            какая_буква = "Строчная буква\n";
                        }
                    }
                    MessageBox.Show(" Вы нажали символ: " + e.KeyChar.ToString()+ "\n Вы нажали клавишу: " + keyvalue + "\n " + язык + " " + какая_буква,"Информация:");
                    i = 0;
                    break;
            }
        }
        
    }
}
