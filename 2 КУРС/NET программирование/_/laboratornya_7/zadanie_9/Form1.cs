using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace zadanie_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string catalog = textBox2.Text;
            string fileName = textBox1.Text;
            bool t = false;
            
            if (catalog == "" || catalog == " ")
            {
                MessageBox.Show("Неверно указан путь", "Информация");
                Application.Exit();
            }
            if (fileName == "" || fileName == " ")
            {
                MessageBox.Show("Не указано или неверно указано имя", "Информация");
                Application.Exit();
            }
            if (radioButton1.Checked)
            {
                foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName, SearchOption.AllDirectories))
                {
                    FileInfo FI;
                    try
                    {
                        FI = new FileInfo(findedFile);
                        t = true;
                        MessageBox.Show("Имя файла: "+FI.Name + "\nПолный путь до файла: " + FI.FullName + "\nВес файла: " + FI.Length + "_байт" + "\n\nСоздан: " + FI.CreationTime, "Информация о вашем файле");
                    }
                    catch
                    {
                        MessageBox.Show("Не найдено.", "Информация о вашем файле");
                        continue;
                    }
                }
                if (t == false)
                    MessageBox.Show("Не найдено", "Информация о вашем файле");
            }
            else
            if (radioButton2.Checked)
            {
                foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName, SearchOption.TopDirectoryOnly))
                {
                    FileInfo FI;
                    try
                    {
                        FI = new FileInfo(findedFile);
                        t = true;
                        MessageBox.Show("Имя файла: " + FI.Name + "\nПолный путь до файла: " + FI.FullName + "\nВес файла: " + FI.Length + " байт" + "\n\nСоздан: " + FI.CreationTime, "Информация о вашем файле");
                    }
                    catch
                    {
                        MessageBox.Show("Не найдено.", "Информация о вашем файле");
                        continue;
                    }
                }
                if (t == false)
                    MessageBox.Show("Не найдено.", "Информация о вашем файле");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
