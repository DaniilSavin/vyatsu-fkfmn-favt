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
using System.Xml;

namespace zxczxc
{
    public partial class Form1 : Form
    {
        private List<Note> PhoneNote;
        private int current;
        bool flag1 = false;
        public Form1()
        {
            InitializeComponent();
            PhoneNote = new List<Note>();
            current = -1;
			openFileDialog1.Filter = "Codelobster Document (*.xml) |*.xml|Текстовый документ (*.txt) |*.txt";
			saveFileDialog1.Filter = "Codelobster Document (*.xml) |*.xml|Текстовый документ (*.txt) |*.txt";
		}
        private void PrintElement()
        {
            if (current >= 0 && current < PhoneNote.Count)
            {    // если есть что выводить
                 // MyRecord - запись списка PhoneNote номер current
                Note MyRecord = PhoneNote[current];
                // записываем в соответствующие элементы на форме 
                // поля из записи MyRecord 
                  
                    LastNameTextBox.Text = MyRecord.LastName;
                    NameTextBox.Text = MyRecord.Name;
                    PatronymicTextBox.Text = MyRecord.Patronymic;
                    PhoneMaskedTextBox.Text = MyRecord.Phone;
                    StreetTextBox.Text = MyRecord.Street;
                    HouseNumericUpDown.Value = MyRecord.House;
                    FlatNumericUpDown.Value = MyRecord.Flat;
                
            }
            else // если current равно -1, т. е. список пуст
            {   // очистить поля формы 
                LastNameTextBox.Text = "";
                NameTextBox.Text = "";
                PatronymicTextBox.Text = "";
                PhoneMaskedTextBox.Text = "";
                StreetTextBox.Text = "";
                HouseNumericUpDown.Value = 1;
                FlatNumericUpDown.Value = 1;
            }
            // обновление строки состояния
            NumberToolStripStatusLabel.Text = (current + 1).ToString();
            QuantityToolStripStatusLabel.Text = PhoneNote.Count.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)  //кнопка добавить
        {
            Note MyRecord = new Note();
            //AddForm _AddForm = new AddForm(MyRecord);
            AddForm _AddForm = new AddForm(MyRecord, AddOrEdit.Add);
            _AddForm.ShowDialog();
            if (_AddForm.MyRecord.House != 0 && _AddForm.MyRecord.Flat != 0)
            {
                bool flag = false;
                foreach (Note item in PhoneNote)
                {
                    if (item.Equals(_AddForm.MyRecord))
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    flag1 = true;
                    current = PhoneNote.Count;
                    PhoneNote.Add(_AddForm.MyRecord);
                    PrintElement();

                }
                else
                {
                    MessageBox.Show("Такая запись уже есть.");
                    AddForm.flag = false;
                }
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (current != -1 && NumberToolStripStatusLabel.Text!="1")
            {
                current--;      // уменьшаем номер текущей записи на 1
                PrintElement();     // выводим элемент с номером current
            }
            else
            {
                MessageBox.Show("Предыдущей записи не существует!", "Ошибка");
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count != current + 1)
            {
                current++;
                PrintElement();
            }
            else
            {
                MessageBox.Show("Следующей записи не существует!", "Ошибка");
            }
        }

        private void saveFileDialog1_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK ) // Если в диалоговом окне нажали ОК
            {
                if (saveFileDialog1.FilterIndex == 2)
                {
                    
                    try         // обработчик исключительных ситуаций
                    {
                        // используя sw (экземпляр класса StreamWriter),
                        // создаем файл с заданным в диалоговом окне именем
                        using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                        {
                            // проходим по всем элементам списка
                            foreach (Note MyRecord in PhoneNote)
                            {
                                // записываем каждое поле в отдельной строке
                                sw.WriteLine(MyRecord.LastName);
                                sw.WriteLine(MyRecord.Name);
                                sw.WriteLine(MyRecord.Patronymic);
                                sw.WriteLine(MyRecord.Street);
                                sw.WriteLine(MyRecord.House);
                                sw.WriteLine(MyRecord.Flat);
                                sw.WriteLine(MyRecord.Phone);
                            }
                        }
                    }
                    catch (Exception ex)    // перехватываем ошибку
                    {
                        // выводим информацию об ошибке
                        MessageBox.Show("Не удалось сохранить данные! Ошибка: " + ex.Message);
                    }

                }
                else
                {
                    //создание xml документа со строкой <?xml version="1.0" encoding="utf-8"?>
                    XmlTextWriter textWritter = new XmlTextWriter(saveFileDialog1.FileName, Encoding.UTF8);
                    textWritter.WriteStartDocument();//запись заголовка документа
                    textWritter.WriteStartElement("Notes");//создание головы
                    textWritter.WriteEndElement();//закрываем голову
                    textWritter.Close();//закрываем документ

                    XmlDocument document = new XmlDocument();//открываем документ  
                    document.Load(saveFileDialog1.FileName);//загружаем из xml файла

                    int i = 0;
                    foreach (Note x in PhoneNote)
                    {
                        //Создаём XML-запись
                        XmlElement element = document.CreateElement("Note");
                        document.DocumentElement.AppendChild(element); // указываем родителя
                        XmlAttribute attribute = document.CreateAttribute("id"); // создаём атрибут
                        attribute.Value = i.ToString(); // устанавливаем значение атрибута
                        element.Attributes.Append(attribute); // добавляем атрибут

                        //Добавляем в запись данные
                        XmlNode lastnameElem = document.CreateElement("Lastname"); // даём имя
                        lastnameElem.InnerText = x.LastName; // и значение
                        element.AppendChild(lastnameElem); // и указываем кому принадлежит


                        XmlNode nameElem = document.CreateElement("Name"); // даём имя
                        nameElem.InnerText = x.Name; // и значение
                        element.AppendChild(nameElem); // и указываем кому принадлежит

                        XmlNode PatronymicElem = document.CreateElement("Patronymic"); // даём имя
                        PatronymicElem.InnerText = x.Patronymic; // и значение
                        element.AppendChild(PatronymicElem); // и указываем кому принадлежит

                        XmlNode StreetElem = document.CreateElement("Street"); // даём имя
                        StreetElem.InnerText = x.Street; // и значение
                        element.AppendChild(StreetElem); // и указываем кому принадлежит


                        XmlNode HouseElem = document.CreateElement("House"); // даём имя
                        HouseElem.InnerText = x.House.ToString(); // и значение
                        element.AppendChild(HouseElem); // и указываем кому принадлежит


                        XmlNode FlatElem = document.CreateElement("Flat"); // даём имя
                        FlatElem.InnerText = x.Flat.ToString(); // и значение
                        element.AppendChild(FlatElem); // и указываем кому принадлежит

                        XmlNode PhoneElem = document.CreateElement("Phone"); // даём имя
                        PhoneElem.InnerText = x.Phone; // и значение
                        element.AppendChild(PhoneElem); // и указываем кому принадлежит
                        i++;
                    }
                    document.Save(saveFileDialog1.FileName);
                }
				AddForm.flag = false;

			}

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Note MyRecord;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // если в диалоговом окне нажали ОК
            {
                if (openFileDialog1.FilterIndex==2)
                {
                    Note MyRecord;
                    //if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    // если в диалоговом окне нажали ОК
                    {
                        try // обработчик исключительных ситуаций
                        {
                            // считываем из указанного в диалоговом окне файла
                            using (StreamReader sr = new StreamReader(openFileDialog1.FileName))

                            {
                                // пока не дошли до конца файла
                                while (!sr.EndOfStream)
                                {
                                    //выделяем место под запись
                                    MyRecord = new Note();
                                    // считываем значения полей записи из файла
                                    MyRecord.LastName = sr.ReadLine();
                                    MyRecord.Name = sr.ReadLine();
                                    MyRecord.Patronymic = sr.ReadLine();
                                    MyRecord.Street = sr.ReadLine();
                                    MyRecord.House = ushort.Parse(sr.ReadLine());
                                    MyRecord.Flat = ushort.Parse(sr.ReadLine());
                                    MyRecord.Phone = sr.ReadLine();
                                    //добавляем запись в список
                                    PhoneNote.Add(MyRecord);
                                }
                            }
                            // если список пуст, то current устанавливаем в -1,
                            // иначе текущей является первая с начала запись (номер 0)
                            if (PhoneNote.Count == 0) current = -1;
                            else current = 0;
                            // выводим текущий элемент
                            PrintElement();
                        }
                        catch (Exception ex) // если произошла ошибка
                        {
                            // выводим сообщение об ошибке
                            MessageBox.Show(" При открытии файла произошла ошибка: " + ex.Message);

                        }
                    }
                }
                else
                {

                    try
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(openFileDialog1.FileName);
                        XmlElement xRoot = xDoc.DocumentElement;
                        flag1 = true;
                        foreach (XmlElement xnode in xRoot)
                        {
                            Note node = new Note();
                            foreach (XmlNode cnode in xnode.ChildNodes)
                            {
                                if (cnode.Name == "Lastname") node.LastName = cnode.InnerText;
                                if (cnode.Name == "Name") node.Name = cnode.InnerText;
                                if (cnode.Name == "Patronymic") node.Patronymic = cnode.InnerText;
                                if (cnode.Name == "Street") node.Street = cnode.InnerText;
                                if (cnode.Name == "House") node.House = ushort.Parse(cnode.InnerText);
                                if (cnode.Name == "Flat") node.Flat = ushort.Parse(cnode.InnerText);
                                if (cnode.Name == "Phone") node.Phone = cnode.InnerText;
                            }
                            PhoneNote.Add(node);
                        }
                        current++;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("xml файла не существует");
                    }

                    PrintElement();
                }
            }
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AddForm.flag == true)
            {
                DialogResult dr = MessageBox.Show("Сохранить изменения?", "", MessageBoxButtons.YesNo);

                switch (dr)
                {
                    case DialogResult.Yes:
                        saveFileDialog1_Click(sender,e);
                        AddForm.flag = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

		private void LastNameTextBox_TextChanged(object sender, EventArgs e) {
			
		}

		private void NameTextBox_TextChanged(object sender, EventArgs e) {
			
		}

		private void PatronymicTextBox_TextChanged(object sender, EventArgs e) {
			
		}

		private void StreetTextBox_TextChanged(object sender, EventArgs e) {
			
		}

        private void поискПоФИОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag1)
            {
                SearchNameForm _Search = new SearchNameForm(PhoneNote);
                _Search.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не открывали файл, или не добавляли абонента.");
            }

        }

        private void поискПоНомеруТелефонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag1)
            {
                SearchPhoneForm _Search = new SearchPhoneForm(PhoneNote);
                _Search.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не открывали файл, или не добавляли абонента.");
            }
        }

        private void поискПоАдресуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag1)
            {
                SearchAddressForm _Search = new SearchAddressForm(PhoneNote);
                _Search.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не открывали файл, или не добавляли абонента.");
            }
        }

        private void поФамилииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)    // если список не пуст
            {
                // сортировка списка по фамилии
                PhoneNote.Sort(new CompareByLastName());
                current = 0;        // задаем номер текущего элемента
                PrintElement(); // вывод текущего элемента

            }

        }

        private void поToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new CompareByFlat());
                current = 0;
                PrintElement();
            }

        }

        private void поИмениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)    // если список не пуст
            {
                // сортировка списка по фамилии
                PhoneNote.Sort(new CompareByName());
                current = 0;        // задаем номер текущего элемента
                PrintElement(); // вывод текущего элемента

            }
        }

        private void поОтчествуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)    // если список не пуст
            {
                // сортировка списка по фамилии
                PhoneNote.Sort(new CompareByPatronymic());
                current = 0;        // задаем номер текущего элемента
                PrintElement(); // вывод текущего элемента

            }
        }

        private void поУлицеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)    // если список не пуст
            {
                // сортировка списка по фамилии
                PhoneNote.Sort(new CompareByStreet());
                current = 0;        // задаем номер текущего элемента
                PrintElement(); // вывод текущего элемента

            }
        }

        private void поДомуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new CompareByHouse());
                current = 0;
                PrintElement();
            }
        }

        private void поТелефонуToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поВозрастаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new CompareByPhone());
                current = 0;
                PrintElement();
            }
        }

        private void поУбываниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort(new CompareByPhone2());
                current = 0;
                PrintElement();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                // создаем запись - экземпляр класса Note
                Note MyRecord = new Note();
                // определяем поля записи
                // (берем значения из соответствующих компонентов на форме)
                MyRecord.LastName = LastNameTextBox.Text;
                MyRecord.Name = NameTextBox.Text;
                MyRecord.Patronymic = PatronymicTextBox.Text;
                MyRecord.Phone = PhoneMaskedTextBox.Text;
                MyRecord.Street = StreetTextBox.Text;
                MyRecord.House = (ushort)HouseNumericUpDown.Value;
                MyRecord.Flat = (ushort)FlatNumericUpDown.Value;
                // создаем экземпляр формы и открываем эту форму
                AddForm _AddForm = new AddForm(MyRecord, AddOrEdit.Edit);
                _AddForm.ShowDialog();
                // изменяем текущую запись
                PhoneNote[current] = _AddForm.MyRecord;
            }
            PrintElement();

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count != 0)
                PhoneNote.RemoveAt(current);
            if (current != 0)
                current--;
            PrintElement();
        }
    }
    class CompareByLastName : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return string.Compare(x.LastName, y.LastName);
        }
    }

    class CompareByFlat : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return x.Flat.CompareTo(y.Flat);
        }
    }
    class CompareByName : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
    class CompareByPatronymic : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return string.Compare(x.Patronymic, y.Patronymic);
        }
    }
    class CompareByStreet : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return string.Compare(x.Street, y.Street);
        }
    }
    class CompareByHouse : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return x.House.CompareTo(y.House);
        }
    }
    class CompareByPhone : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return x.Phone.CompareTo(y.Phone);
        }
    }
    class CompareByPhone2 : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return x.Phone.CompareTo(y.Phone)*-1;
        }
    }
    public enum AddOrEdit
    {
        Add,
        Edit
    }


}
