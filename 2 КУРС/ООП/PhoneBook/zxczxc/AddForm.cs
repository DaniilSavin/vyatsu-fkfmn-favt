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

namespace zxczxc
{
    public partial class AddForm : Form
    {
        public Note MyRecord;
        public static bool flag = false;
		public static bool fl = false;
        public AddForm(Note _MyRecord, AddOrEdit MyType)
        {
            InitializeComponent();
            MyRecord = _MyRecord;
			// если форма открыта для добавления
			if (MyType == AddOrEdit.Add)
			{
				Text = "Добавление абонента";
				AddButton.Text = "Добавить";
			}
			else    // если форма открыта для изменения записи
			{
				Text = "Изменение абонента";
				AddButton.Text = "Изменить";
				// определяем значение компонентов на форме
				LastNameTextBox.Text = MyRecord.LastName;
				NameTextBox.Text = MyRecord.Name;
				PatronymicTextBox.Text = MyRecord.Patronymic;
				PhoneMaskedTextBox.Text = MyRecord.Phone;
				StreetTextBox.Text = MyRecord.Street;
				HouseNumericUpDown.Value = MyRecord.House;
				FlatNumericUpDown.Value = MyRecord.Flat;
			}

		}

		private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
			if (fl) {
				MyRecord.LastName = LastNameTextBox.Text;
				MyRecord.Name = NameTextBox.Text;
				MyRecord.Patronymic = PatronymicTextBox.Text;
				MyRecord.Phone = PhoneMaskedTextBox.Text;
				MyRecord.Street = StreetTextBox.Text;
				MyRecord.House = (ushort)HouseNumericUpDown.Value;
				MyRecord.Flat = (ushort)FlatNumericUpDown.Value;
				flag = true;
				Close();        // закрываем форму
			} else {
				MessageBox.Show("Вы не заполнили поля.");
			}

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           

        }

		private void LastNameTextBox_TextChanged(object sender, EventArgs e) {
			fl = true;
		}

		private void NameTextBox_TextChanged(object sender, EventArgs e) {
			fl = true;
		}

		private void PatronymicTextBox_TextChanged(object sender, EventArgs e) {
			fl = true;
		}

		private void StreetTextBox_TextChanged(object sender, EventArgs e) {
			fl = true;
		}
	}
}
