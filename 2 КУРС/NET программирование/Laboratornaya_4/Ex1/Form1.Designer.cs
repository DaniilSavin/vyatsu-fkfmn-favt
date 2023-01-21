namespace Ex1
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
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.ResultGroupBox = new System.Windows.Forms.GroupBox();
            this.YardRadioButton = new System.Windows.Forms.RadioButton();
            this.FootRadioButton = new System.Windows.Forms.RadioButton();
            this.InchRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ResultGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(170, 123);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(149, 30);
            this.ExecuteButton.TabIndex = 2;
            this.ExecuteButton.Text = "Перевести";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            this.ExecuteButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExecuteButton_KeyDown);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Enabled = false;
            this.ResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultTextBox.Location = new System.Drawing.Point(111, 17);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(100, 23);
            this.ResultTextBox.TabIndex = 4;
            this.ResultTextBox.Text = "0";
            this.ResultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ResultGroupBox
            // 
            this.ResultGroupBox.Controls.Add(this.YardRadioButton);
            this.ResultGroupBox.Controls.Add(this.FootRadioButton);
            this.ResultGroupBox.Controls.Add(this.InchRadioButton);
            this.ResultGroupBox.Controls.Add(this.ResultTextBox);
            this.ResultGroupBox.Location = new System.Drawing.Point(251, 12);
            this.ResultGroupBox.Name = "ResultGroupBox";
            this.ResultGroupBox.Size = new System.Drawing.Size(221, 105);
            this.ResultGroupBox.TabIndex = 9;
            this.ResultGroupBox.TabStop = false;
            this.ResultGroupBox.Text = "Результат ";
            // 
            // YardRadioButton
            // 
            this.YardRadioButton.AutoSize = true;
            this.YardRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YardRadioButton.Location = new System.Drawing.Point(7, 73);
            this.YardRadioButton.Name = "YardRadioButton";
            this.YardRadioButton.Size = new System.Drawing.Size(75, 21);
            this.YardRadioButton.TabIndex = 12;
            this.YardRadioButton.TabStop = true;
            this.YardRadioButton.Text = "в ярдах";
            this.YardRadioButton.UseVisualStyleBackColor = true;
            this.YardRadioButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // FootRadioButton
            // 
            this.FootRadioButton.AutoSize = true;
            this.FootRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FootRadioButton.Location = new System.Drawing.Point(6, 46);
            this.FootRadioButton.Name = "FootRadioButton";
            this.FootRadioButton.Size = new System.Drawing.Size(76, 21);
            this.FootRadioButton.TabIndex = 11;
            this.FootRadioButton.TabStop = true;
            this.FootRadioButton.Text = "в футах";
            this.FootRadioButton.UseVisualStyleBackColor = true;
            this.FootRadioButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // InchRadioButton
            // 
            this.InchRadioButton.AutoSize = true;
            this.InchRadioButton.Checked = true;
            this.InchRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InchRadioButton.Location = new System.Drawing.Point(6, 19);
            this.InchRadioButton.Name = "InchRadioButton";
            this.InchRadioButton.Size = new System.Drawing.Size(86, 21);
            this.InchRadioButton.TabIndex = 10;
            this.InchRadioButton.TabStop = true;
            this.InchRadioButton.Text = "в дюймах";
            this.InchRadioButton.UseVisualStyleBackColor = true;
            this.InchRadioButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 105);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные данные";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(115, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton3.Location = new System.Drawing.Point(3, 73);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(75, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "в ярдах";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(3, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "в футах";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(3, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "в дюймах";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 160);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ResultGroupBox);
            this.Controls.Add(this.ExecuteButton);
            this.Name = "Form1";
            this.Text = "Конвертер";
            this.ResultGroupBox.ResumeLayout(false);
            this.ResultGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.GroupBox ResultGroupBox;
        private System.Windows.Forms.RadioButton YardRadioButton;
        private System.Windows.Forms.RadioButton FootRadioButton;
        private System.Windows.Forms.RadioButton InchRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

