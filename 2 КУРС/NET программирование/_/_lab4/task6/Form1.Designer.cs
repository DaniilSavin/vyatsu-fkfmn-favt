namespace task6
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
            if (disposing && (components != null))
            {
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
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FigureGroupBox = new System.Windows.Forms.GroupBox();
            this.RandomRadioButton = new System.Windows.Forms.RadioButton();
            this.EllipseRadioButton = new System.Windows.Forms.RadioButton();
            this.RectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.CountGroupBox1 = new System.Windows.Forms.GroupBox();
            this.TwoRadioButton = new System.Windows.Forms.RadioButton();
            this.OneRadioButton = new System.Windows.Forms.RadioButton();
            this.SpeedGroupBox = new System.Windows.Forms.GroupBox();
            this.FastRadioButton = new System.Windows.Forms.RadioButton();
            this.MediumRadioButton = new System.Windows.Forms.RadioButton();
            this.SlowRadioButton = new System.Windows.Forms.RadioButton();
            this.FigureGroupBox.SuspendLayout();
            this.CountGroupBox1.SuspendLayout();
            this.SpeedGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(219, 66);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(266, 55);
            this.label.TabIndex = 0;
            this.label.Text = "Создатель";
            this.label.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(51, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "При двойном щелчке мыши появится заставка";
            // 
            // FigureGroupBox
            // 
            this.FigureGroupBox.Controls.Add(this.RandomRadioButton);
            this.FigureGroupBox.Controls.Add(this.EllipseRadioButton);
            this.FigureGroupBox.Controls.Add(this.RectangleRadioButton);
            this.FigureGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FigureGroupBox.Location = new System.Drawing.Point(57, 255);
            this.FigureGroupBox.Name = "FigureGroupBox";
            this.FigureGroupBox.Size = new System.Drawing.Size(169, 137);
            this.FigureGroupBox.TabIndex = 2;
            this.FigureGroupBox.TabStop = false;
            this.FigureGroupBox.Text = "Вид отображаемой фигуры";
            // 
            // RandomRadioButton
            // 
            this.RandomRadioButton.AutoSize = true;
            this.RandomRadioButton.Location = new System.Drawing.Point(6, 87);
            this.RandomRadioButton.Name = "RandomRadioButton";
            this.RandomRadioButton.Size = new System.Drawing.Size(115, 20);
            this.RandomRadioButton.TabIndex = 2;
            this.RandomRadioButton.Text = "Произвольно";
            this.RandomRadioButton.UseVisualStyleBackColor = true;
            // 
            // EllipseRadioButton
            // 
            this.EllipseRadioButton.AutoSize = true;
            this.EllipseRadioButton.Location = new System.Drawing.Point(6, 64);
            this.EllipseRadioButton.Name = "EllipseRadioButton";
            this.EllipseRadioButton.Size = new System.Drawing.Size(84, 20);
            this.EllipseRadioButton.TabIndex = 1;
            this.EllipseRadioButton.Text = "Эллипсы";
            this.EllipseRadioButton.UseVisualStyleBackColor = true;
            // 
            // RectangleRadioButton
            // 
            this.RectangleRadioButton.AllowDrop = true;
            this.RectangleRadioButton.AutoSize = true;
            this.RectangleRadioButton.CausesValidation = false;
            this.RectangleRadioButton.Checked = true;
            this.RectangleRadioButton.Location = new System.Drawing.Point(6, 41);
            this.RectangleRadioButton.Name = "RectangleRadioButton";
            this.RectangleRadioButton.Size = new System.Drawing.Size(136, 20);
            this.RectangleRadioButton.TabIndex = 0;
            this.RectangleRadioButton.TabStop = true;
            this.RectangleRadioButton.Text = "Прямоугольники";
            this.RectangleRadioButton.UseVisualStyleBackColor = true;
            // 
            // CountGroupBox1
            // 
            this.CountGroupBox1.Controls.Add(this.TwoRadioButton);
            this.CountGroupBox1.Controls.Add(this.OneRadioButton);
            this.CountGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountGroupBox1.Location = new System.Drawing.Point(268, 255);
            this.CountGroupBox1.Name = "CountGroupBox1";
            this.CountGroupBox1.Size = new System.Drawing.Size(169, 137);
            this.CountGroupBox1.TabIndex = 3;
            this.CountGroupBox1.TabStop = false;
            this.CountGroupBox1.Text = "Количество фигур";
            this.CountGroupBox1.Enter += new System.EventHandler(this.CountGroupBox1_Enter);
            // 
            // TwoRadioButton
            // 
            this.TwoRadioButton.AutoSize = true;
            this.TwoRadioButton.Location = new System.Drawing.Point(6, 64);
            this.TwoRadioButton.Name = "TwoRadioButton";
            this.TwoRadioButton.Size = new System.Drawing.Size(51, 20);
            this.TwoRadioButton.TabIndex = 2;
            this.TwoRadioButton.Text = "Две";
            this.TwoRadioButton.UseVisualStyleBackColor = true;
            this.TwoRadioButton.CheckedChanged += new System.EventHandler(this.Form1_Load);
            // 
            // OneRadioButton
            // 
            this.OneRadioButton.AutoSize = true;
            this.OneRadioButton.Checked = true;
            this.OneRadioButton.Location = new System.Drawing.Point(6, 41);
            this.OneRadioButton.Name = "OneRadioButton";
            this.OneRadioButton.Size = new System.Drawing.Size(60, 20);
            this.OneRadioButton.TabIndex = 0;
            this.OneRadioButton.TabStop = true;
            this.OneRadioButton.Text = "Одна";
            this.OneRadioButton.UseVisualStyleBackColor = true;
            this.OneRadioButton.CheckedChanged += new System.EventHandler(this.Form1_Load);
            // 
            // SpeedGroupBox
            // 
            this.SpeedGroupBox.Controls.Add(this.FastRadioButton);
            this.SpeedGroupBox.Controls.Add(this.MediumRadioButton);
            this.SpeedGroupBox.Controls.Add(this.SlowRadioButton);
            this.SpeedGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpeedGroupBox.Location = new System.Drawing.Point(471, 255);
            this.SpeedGroupBox.Name = "SpeedGroupBox";
            this.SpeedGroupBox.Size = new System.Drawing.Size(169, 137);
            this.SpeedGroupBox.TabIndex = 4;
            this.SpeedGroupBox.TabStop = false;
            this.SpeedGroupBox.Text = "Скорость смены картинки";
            // 
            // FastRadioButton
            // 
            this.FastRadioButton.AutoSize = true;
            this.FastRadioButton.Location = new System.Drawing.Point(6, 87);
            this.FastRadioButton.Name = "FastRadioButton";
            this.FastRadioButton.Size = new System.Drawing.Size(81, 20);
            this.FastRadioButton.TabIndex = 2;
            this.FastRadioButton.Text = "Быстрая";
            this.FastRadioButton.UseVisualStyleBackColor = true;
            // 
            // MediumRadioButton
            // 
            this.MediumRadioButton.AutoSize = true;
            this.MediumRadioButton.Location = new System.Drawing.Point(6, 64);
            this.MediumRadioButton.Name = "MediumRadioButton";
            this.MediumRadioButton.Size = new System.Drawing.Size(81, 20);
            this.MediumRadioButton.TabIndex = 1;
            this.MediumRadioButton.Text = "Средняя";
            this.MediumRadioButton.UseVisualStyleBackColor = true;
            // 
            // SlowRadioButton
            // 
            this.SlowRadioButton.AutoSize = true;
            this.SlowRadioButton.Checked = true;
            this.SlowRadioButton.Location = new System.Drawing.Point(6, 41);
            this.SlowRadioButton.Name = "SlowRadioButton";
            this.SlowRadioButton.Size = new System.Drawing.Size(100, 20);
            this.SlowRadioButton.TabIndex = 0;
            this.SlowRadioButton.TabStop = true;
            this.SlowRadioButton.Text = "Медленная";
            this.SlowRadioButton.UseVisualStyleBackColor = true;
            this.SlowRadioButton.CheckedChanged += new System.EventHandler(this.SlowRadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SpeedGroupBox);
            this.Controls.Add(this.CountGroupBox1);
            this.Controls.Add(this.FigureGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Name = "Form1";
            this.Text = "Создатель";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.FigureGroupBox.ResumeLayout(false);
            this.FigureGroupBox.PerformLayout();
            this.CountGroupBox1.ResumeLayout(false);
            this.CountGroupBox1.PerformLayout();
            this.SpeedGroupBox.ResumeLayout(false);
            this.SpeedGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox FigureGroupBox;
        private System.Windows.Forms.GroupBox CountGroupBox1;
        private System.Windows.Forms.GroupBox SpeedGroupBox;
        public System.Windows.Forms.RadioButton RectangleRadioButton;
        public System.Windows.Forms.RadioButton RandomRadioButton;
        public System.Windows.Forms.RadioButton EllipseRadioButton;
        public System.Windows.Forms.RadioButton TwoRadioButton;
        public System.Windows.Forms.RadioButton OneRadioButton;
        public System.Windows.Forms.RadioButton FastRadioButton;
        public System.Windows.Forms.RadioButton MediumRadioButton;
        public System.Windows.Forms.RadioButton SlowRadioButton;
    }
}

