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

namespace organiser
{
    public partial class form1 : Form
    {
        string FileName;
        public form1()
        {
            InitializeComponent();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        void add_value()
        {
            listBox1.Items.Add(RecordTextBox.Text);
            string[] full_file = File.ReadAllLines(FileName);
            List<string> l = new List<string>();
            l.AddRange(full_file);
            l.Insert(find_num_of_string() + 1, RecordTextBox.Text);
            File.WriteAllLines(FileName, l.ToArray());
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            //определение выбранного компонента ListBox
            string s = "listBox" + (OrgTabControl.SelectedIndex + 1);
            ListBox CurrentListBox = (ListBox)Controls.Find(s, true)[0];
            //добавление записи на текущий ListBox
            bool fl = false;
            for (int i = 0; i < CurrentListBox.Items.Count; i++)
            {
                if (CurrentListBox.Items[i].ToString() == RecordTextBox.Text)
                {
                    //CurrentListBox.Items.Add(RecordTextBox.Text);
                    fl = true;
                }
            }
            if (!fl)
            {
                CurrentListBox.Items.Add(RecordTextBox.Text);
            }
            //очистка окна ввода
            RecordTextBox.Text = "";
            //add_value();
            

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            //определение выбранного компонента ListBox
            string s = "listBox" + (OrgTabControl.SelectedIndex + 1);
            ListBox CurrentListBox = (ListBox)Controls.Find(s, true)[0];
            //запись в окно редактирования выбранного значения
            RecordTextBox.Text = (string)CurrentListBox.SelectedItem;

        }

        private void form1_Load(object sender, EventArgs e)
        {
            FileName = dateTimePicker1.Text + "org";
            try
            {
                using (StreamReader fs = new StreamReader(FileName))
                {
                    fs.Close();
                    LoadFromFile(FileName);
                }
            }
            catch
            {
                File.Create(FileName).Close();
                //form1_Load(sender, e);
            }




        }
        private void SaveToFile(string FileName)
        {
            try
            {

                using (StreamWriter sw = new StreamWriter(FileName))

                {
                    for (int i = 1; i <= 3; i++)
                    {

                        ListBox CurListBox = (ListBox)Controls.Find("listBox" + i, true)[0];
                        //записываем в файл кол во строк списка
                        //sw.WriteLine(CurListBox.Items.Count.ToString());
                        //записываем в файл все записи из списка
                        for (int j = 0; j < CurListBox.Items.Count; j++)
                            sw.WriteLine(CurListBox.Items[j]);
                        //очищаем список записей текущего ListBox
                        CurListBox.Items.Clear();
                    }
                    sw.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении!");
            }
        }

        private void LoadFromFile(string FileName)
        {
            switch (OrgTabControl.SelectedIndex)
            {
                case 0:
                    try
                    {
                        using (StreamReader sw = File.OpenText(FileName))
                        {
                            // for (int i = 1; i <= 3; i++)
                            {
                                //ListBox CurListBox = (ListBox)Controls.Find("listBox" + i, true)[0];

                                // Считываем строки в массив
                                string[] allLines = File.ReadAllLines(FileName, Encoding.GetEncoding(1251));
                                // Добавляем каждую строку
                                foreach (string line in allLines)
                                    listBox1.Items.Add(line);

                            }
                            sw.Close();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при открытии!");
                    }
                    break;
                case 1:
                    try
                    {
                        using (StreamReader sw = File.OpenText(FileName))
                        {
                            {

                                // Считываем строки в массив
                                string[] allLines = File.ReadAllLines(FileName, Encoding.GetEncoding(1251));
                                // Добавляем каждую строку
                                foreach (string line in allLines)
                                    listBox2.Items.Add(line);

                            }
                            sw.Close();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при открытии!");
                    }
                    break;
                case 2:
                    try
                    {
                        using (StreamReader sw = File.OpenText(FileName))
                        {
                            // for (int i = 1; i <= 3; i++)
                            {
                                //ListBox CurListBox = (ListBox)Controls.Find("listBox" + i, true)[0];

                                // Считываем строки в массив
                                string[] allLines = File.ReadAllLines(FileName, Encoding.GetEncoding(1251));
                                // Добавляем каждую строку
                                foreach (string line in allLines)
                                    listBox3.Items.Add(line);

                            }
                            sw.Close();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при открытии!");
                    }
                    break;
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SaveToFile(FileName);
            FileName = dateTimePicker1.Text + "org";
            LoadFromFile(FileName);

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            SaveToFile(FileName);
            Application.Exit();
        }
        int find_num_of_string()
        {
            try
            {
                int stoflag1 = 0;
                using (StreamReader sr = new StreamReader(FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string st = sr.ReadLine();
                        if (st == listBox1.Items[listBox1.SelectedIndex].ToString())
                        {
                            break;
                        }
                        stoflag1++;
                    }
                    sr.Close();
                }
                return stoflag1;
            }
            catch
            {
                //MessageBox.Show("error");
            }
            return -1;
        }
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            string[] readText = File.ReadAllLines(FileName);
            int c = find_num_of_string();
            listBox1.Items[listBox1.SelectedIndex] = RecordTextBox.Text;
            readText[c] = RecordTextBox.Text.ToString();
            File.WriteAllLines(FileName, readText);
        }

        void delete_value()
        {
            string FileNameO = "out.txt";
            switch (OrgTabControl.SelectedIndex)
            {
               case 0:    
                    File.Create(FileNameO).Close();
                    using (StreamReader sr = new StreamReader(FileName))
                    {
                        using (StreamWriter sw = new StreamWriter(FileNameO))
                        {
                            var str = File.ReadAllLines(FileName);
                            foreach (var s in str.Distinct())
                            {
                                sw.WriteLine(s);
                            }

                            sw.Close();
                        }
                        sr.Close();
                    }

                    listBox1.Items.Clear();
                    
                    break;
                case 1:
                   // string FileNameO = "out.txt";
                    File.Create(FileNameO).Close();
                    using (StreamReader sr = new StreamReader(FileName))
                    {
                        using (StreamWriter sw = new StreamWriter(FileNameO))
                        {
                            var str = File.ReadAllLines(FileName);
                            foreach (var s in str.Distinct())
                            {
                                sw.WriteLine(s);
                            }

                            sw.Close();
                        }
                        sr.Close();
                    }

                    listBox2.Items.Clear();
                   // LoadFromFile(FileNameO);
                    break;
                case 2:
                    // string FileNameO = "out.txt";
                    File.Create(FileNameO).Close();
                    using (StreamReader sr = new StreamReader(FileName))
                    {
                        using (StreamWriter sw = new StreamWriter(FileNameO))
                        {
                            var str = File.ReadAllLines(FileName);
                            foreach (var s in str.Distinct())
                            {
                                sw.WriteLine(s);
                            }

                            sw.Close();
                        }
                        sr.Close();
                    }

                    listBox3.Items.Clear();
                    //LoadFromFile(FileNameO);
                    break;
                    
            }
            LoadFromFile(FileNameO);

        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            delete_value();
           // listBox1.Items.RemoveAt(listBox1.SelectedIndex);

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OrgTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFromFile(FileName);
        }

        private void AddButton_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void RecordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            AddButton_Click(sender, e);
        }
    }
}

