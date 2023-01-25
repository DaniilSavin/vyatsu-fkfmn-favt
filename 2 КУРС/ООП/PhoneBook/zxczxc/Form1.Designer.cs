namespace zxczxc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PatronymicTextBox = new System.Windows.Forms.TextBox();
            this.StreetTextBox = new System.Windows.Forms.TextBox();
            this.HouseNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FlatNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PhoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Quantity_ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.QuantityToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Number_ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.NumberToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.абонентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ADD_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискПоФИОToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискПоНомеруТелефонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискПоАдресуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поФамилииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поИмениToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поОтчествуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поУлицеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поДомуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поТелефонуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поВозрастаниюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поУбываниюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.HouseNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlatNumericUpDown)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Enabled = false;
            this.LastNameTextBox.Location = new System.Drawing.Point(144, 56);
            this.LastNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(148, 26);
            this.LastNameTextBox.TabIndex = 0;
            this.LastNameTextBox.TextChanged += new System.EventHandler(this.LastNameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фамилия";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 205);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Улица";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 252);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Дом";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 299);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Квартира";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 348);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Телефон";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Enabled = false;
            this.NameTextBox.Location = new System.Drawing.Point(144, 109);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(148, 26);
            this.NameTextBox.TabIndex = 8;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // PatronymicTextBox
            // 
            this.PatronymicTextBox.Enabled = false;
            this.PatronymicTextBox.Location = new System.Drawing.Point(144, 156);
            this.PatronymicTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PatronymicTextBox.Name = "PatronymicTextBox";
            this.PatronymicTextBox.Size = new System.Drawing.Size(148, 26);
            this.PatronymicTextBox.TabIndex = 9;
            this.PatronymicTextBox.TextChanged += new System.EventHandler(this.PatronymicTextBox_TextChanged);
            // 
            // StreetTextBox
            // 
            this.StreetTextBox.Enabled = false;
            this.StreetTextBox.Location = new System.Drawing.Point(144, 205);
            this.StreetTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StreetTextBox.Name = "StreetTextBox";
            this.StreetTextBox.Size = new System.Drawing.Size(148, 26);
            this.StreetTextBox.TabIndex = 10;
            this.StreetTextBox.TextChanged += new System.EventHandler(this.StreetTextBox_TextChanged);
            // 
            // HouseNumericUpDown
            // 
            this.HouseNumericUpDown.Enabled = false;
            this.HouseNumericUpDown.Location = new System.Drawing.Point(144, 250);
            this.HouseNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HouseNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.HouseNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HouseNumericUpDown.Name = "HouseNumericUpDown";
            this.HouseNumericUpDown.Size = new System.Drawing.Size(148, 26);
            this.HouseNumericUpDown.TabIndex = 14;
            this.HouseNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FlatNumericUpDown
            // 
            this.FlatNumericUpDown.Enabled = false;
            this.FlatNumericUpDown.Location = new System.Drawing.Point(144, 296);
            this.FlatNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FlatNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.FlatNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FlatNumericUpDown.Name = "FlatNumericUpDown";
            this.FlatNumericUpDown.Size = new System.Drawing.Size(148, 26);
            this.FlatNumericUpDown.TabIndex = 15;
            this.FlatNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PreviousButton
            // 
            this.PreviousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousButton.Location = new System.Drawing.Point(103, 391);
            this.PreviousButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(48, 29);
            this.PreviousButton.TabIndex = 16;
            this.PreviousButton.Text = "<";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(158, 391);
            this.NextButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(47, 29);
            this.NextButton.TabIndex = 17;
            this.NextButton.Text = ">";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PhoneMaskedTextBox
            // 
            this.PhoneMaskedTextBox.Enabled = false;
            this.PhoneMaskedTextBox.Location = new System.Drawing.Point(144, 348);
            this.PhoneMaskedTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PhoneMaskedTextBox.Mask = "(999) 000-000";
            this.PhoneMaskedTextBox.Name = "PhoneMaskedTextBox";
            this.PhoneMaskedTextBox.Size = new System.Drawing.Size(148, 26);
            this.PhoneMaskedTextBox.TabIndex = 18;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Quantity_ToolStripStatusLabel,
            this.QuantityToolStripStatusLabel,
            this.Number_ToolStripStatusLabel,
            this.NumberToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 446);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(341, 24);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Quantity_ToolStripStatusLabel
            // 
            this.Quantity_ToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Quantity_ToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.Quantity_ToolStripStatusLabel.Name = "Quantity_ToolStripStatusLabel";
            this.Quantity_ToolStripStatusLabel.Size = new System.Drawing.Size(123, 19);
            this.Quantity_ToolStripStatusLabel.Text = "Количество записей";
            // 
            // QuantityToolStripStatusLabel
            // 
            this.QuantityToolStripStatusLabel.AutoSize = false;
            this.QuantityToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.QuantityToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.QuantityToolStripStatusLabel.Name = "QuantityToolStripStatusLabel";
            this.QuantityToolStripStatusLabel.Size = new System.Drawing.Size(30, 19);
            this.QuantityToolStripStatusLabel.Text = "0";
            // 
            // Number_ToolStripStatusLabel
            // 
            this.Number_ToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Number_ToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.Number_ToolStripStatusLabel.Name = "Number_ToolStripStatusLabel";
            this.Number_ToolStripStatusLabel.Size = new System.Drawing.Size(90, 19);
            this.Number_ToolStripStatusLabel.Text = "Номер записи";
            // 
            // NumberToolStripStatusLabel
            // 
            this.NumberToolStripStatusLabel.AutoSize = false;
            this.NumberToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.NumberToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.NumberToolStripStatusLabel.Name = "NumberToolStripStatusLabel";
            this.NumberToolStripStatusLabel.Size = new System.Drawing.Size(30, 19);
            this.NumberToolStripStatusLabel.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.абонентToolStripMenuItem,
            this.файлToolStripMenuItem,
            this.поискToolStripMenuItem,
            this.сортировкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(341, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // абонентToolStripMenuItem
            // 
            this.абонентToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ADD_toolStripMenuItem1,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.абонентToolStripMenuItem.Name = "абонентToolStripMenuItem";
            this.абонентToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.абонентToolStripMenuItem.Text = "Абонент";
            // 
            // ADD_toolStripMenuItem1
            // 
            this.ADD_toolStripMenuItem1.Name = "ADD_toolStripMenuItem1";
            this.ADD_toolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.ADD_toolStripMenuItem1.Text = "Добавить";
            this.ADD_toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.save});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // open
            // 
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(133, 22);
            this.open.Text = "Открыть";
            this.open.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // save
            // 
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(133, 22);
            this.save.Text = "Сохранить";
            this.save.Click += new System.EventHandler(this.saveFileDialog1_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискПоФИОToolStripMenuItem,
            this.поискПоНомеруТелефонаToolStripMenuItem,
            this.поискПоАдресуToolStripMenuItem});
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.поискToolStripMenuItem.Text = "Поиск";
            // 
            // поискПоФИОToolStripMenuItem
            // 
            this.поискПоФИОToolStripMenuItem.Name = "поискПоФИОToolStripMenuItem";
            this.поискПоФИОToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.поискПоФИОToolStripMenuItem.Text = "Поиск по ФИО";
            this.поискПоФИОToolStripMenuItem.Click += new System.EventHandler(this.поискПоФИОToolStripMenuItem_Click);
            // 
            // поискПоНомеруТелефонаToolStripMenuItem
            // 
            this.поискПоНомеруТелефонаToolStripMenuItem.Name = "поискПоНомеруТелефонаToolStripMenuItem";
            this.поискПоНомеруТелефонаToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.поискПоНомеруТелефонаToolStripMenuItem.Text = "Поиск по номеру телефона";
            this.поискПоНомеруТелефонаToolStripMenuItem.Click += new System.EventHandler(this.поискПоНомеруТелефонаToolStripMenuItem_Click);
            // 
            // поискПоАдресуToolStripMenuItem
            // 
            this.поискПоАдресуToolStripMenuItem.Name = "поискПоАдресуToolStripMenuItem";
            this.поискПоАдресуToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.поискПоАдресуToolStripMenuItem.Text = "Поиск по адресу";
            this.поискПоАдресуToolStripMenuItem.Click += new System.EventHandler(this.поискПоАдресуToolStripMenuItem_Click);
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поФамилииToolStripMenuItem,
            this.поToolStripMenuItem,
            this.поИмениToolStripMenuItem,
            this.поОтчествуToolStripMenuItem,
            this.поУлицеToolStripMenuItem,
            this.поДомуToolStripMenuItem,
            this.поТелефонуToolStripMenuItem});
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            // 
            // поФамилииToolStripMenuItem
            // 
            this.поФамилииToolStripMenuItem.Name = "поФамилииToolStripMenuItem";
            this.поФамилииToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поФамилииToolStripMenuItem.Text = "По фамилии";
            this.поФамилииToolStripMenuItem.Click += new System.EventHandler(this.поФамилииToolStripMenuItem_Click);
            // 
            // поToolStripMenuItem
            // 
            this.поToolStripMenuItem.Name = "поToolStripMenuItem";
            this.поToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поToolStripMenuItem.Text = "По квартире ";
            this.поToolStripMenuItem.Click += new System.EventHandler(this.поToolStripMenuItem_Click);
            // 
            // поИмениToolStripMenuItem
            // 
            this.поИмениToolStripMenuItem.Name = "поИмениToolStripMenuItem";
            this.поИмениToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поИмениToolStripMenuItem.Text = "По имени";
            this.поИмениToolStripMenuItem.Click += new System.EventHandler(this.поИмениToolStripMenuItem_Click);
            // 
            // поОтчествуToolStripMenuItem
            // 
            this.поОтчествуToolStripMenuItem.Name = "поОтчествуToolStripMenuItem";
            this.поОтчествуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поОтчествуToolStripMenuItem.Text = "По отчеству";
            this.поОтчествуToolStripMenuItem.Click += new System.EventHandler(this.поОтчествуToolStripMenuItem_Click);
            // 
            // поУлицеToolStripMenuItem
            // 
            this.поУлицеToolStripMenuItem.Name = "поУлицеToolStripMenuItem";
            this.поУлицеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поУлицеToolStripMenuItem.Text = "По улице";
            this.поУлицеToolStripMenuItem.Click += new System.EventHandler(this.поУлицеToolStripMenuItem_Click);
            // 
            // поДомуToolStripMenuItem
            // 
            this.поДомуToolStripMenuItem.Name = "поДомуToolStripMenuItem";
            this.поДомуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поДомуToolStripMenuItem.Text = "По дому";
            this.поДомуToolStripMenuItem.Click += new System.EventHandler(this.поДомуToolStripMenuItem_Click);
            // 
            // поТелефонуToolStripMenuItem
            // 
            this.поТелефонуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поВозрастаниюToolStripMenuItem,
            this.поУбываниюToolStripMenuItem});
            this.поТелефонуToolStripMenuItem.Name = "поТелефонуToolStripMenuItem";
            this.поТелефонуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поТелефонуToolStripMenuItem.Text = "По телефону";
            this.поТелефонуToolStripMenuItem.Click += new System.EventHandler(this.поТелефонуToolStripMenuItem_Click);
            // 
            // поВозрастаниюToolStripMenuItem
            // 
            this.поВозрастаниюToolStripMenuItem.Name = "поВозрастаниюToolStripMenuItem";
            this.поВозрастаниюToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поВозрастаниюToolStripMenuItem.Text = "По возрастанию";
            this.поВозрастаниюToolStripMenuItem.Click += new System.EventHandler(this.поВозрастаниюToolStripMenuItem_Click);
            // 
            // поУбываниюToolStripMenuItem
            // 
            this.поУбываниюToolStripMenuItem.Name = "поУбываниюToolStripMenuItem";
            this.поУбываниюToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поУбываниюToolStripMenuItem.Text = "По убыванию";
            this.поУбываниюToolStripMenuItem.Click += new System.EventHandler(this.поУбываниюToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 470);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.PhoneMaskedTextBox);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.FlatNumericUpDown);
            this.Controls.Add(this.HouseNumericUpDown);
            this.Controls.Add(this.StreetTextBox);
            this.Controls.Add(this.PatronymicTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LastNameTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(357, 509);
            this.MinimumSize = new System.Drawing.Size(357, 509);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Телефонный справочник";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.HouseNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlatNumericUpDown)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PatronymicTextBox;
        private System.Windows.Forms.TextBox StreetTextBox;
        private System.Windows.Forms.NumericUpDown HouseNumericUpDown;
        private System.Windows.Forms.NumericUpDown FlatNumericUpDown;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.MaskedTextBox PhoneMaskedTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Quantity_ToolStripStatusLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem абонентToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel QuantityToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel Number_ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel NumberToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem ADD_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem open;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem поискПоФИОToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискПоНомеруТелефонаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискПоАдресуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поФамилииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поИмениToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поОтчествуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поУлицеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поДомуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поТелефонуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поВозрастаниюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поУбываниюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}

