namespace task2
{
    partial class MainForm
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
            this.DayLabel = new System.Windows.Forms.Label();
            this.MouthLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.FullDaysLabel = new System.Windows.Forms.Label();
            this.DayTextBox = new System.Windows.Forms.TextBox();
            this.MonthTextBox = new System.Windows.Forms.TextBox();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DayLabel
            // 
            this.DayLabel.AutoSize = true;
            this.DayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DayLabel.Location = new System.Drawing.Point(22, 62);
            this.DayLabel.Name = "DayLabel";
            this.DayLabel.Size = new System.Drawing.Size(101, 16);
            this.DayLabel.TabIndex = 0;
            this.DayLabel.Text = " Введите день";
            // 
            // MouthLabel
            // 
            this.MouthLabel.AutoSize = true;
            this.MouthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MouthLabel.Location = new System.Drawing.Point(22, 96);
            this.MouthLabel.Name = "MouthLabel";
            this.MouthLabel.Size = new System.Drawing.Size(106, 16);
            this.MouthLabel.TabIndex = 1;
            this.MouthLabel.Text = "Введите месяц";
            this.MouthLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearLabel.Location = new System.Drawing.Point(22, 125);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(160, 16);
            this.YearLabel.TabIndex = 2;
            this.YearLabel.Text = "Введите год (1900-2019)";
            // 
            // FullDaysLabel
            // 
            this.FullDaysLabel.AutoSize = true;
            this.FullDaysLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullDaysLabel.Location = new System.Drawing.Point(22, 164);
            this.FullDaysLabel.Name = "FullDaysLabel";
            this.FullDaysLabel.Size = new System.Drawing.Size(171, 16);
            this.FullDaysLabel.TabIndex = 3;
            this.FullDaysLabel.Text = "Количество полных дней";
            this.FullDaysLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // DayTextBox
            // 
            this.DayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DayTextBox.Location = new System.Drawing.Point(209, 56);
            this.DayTextBox.Name = "DayTextBox";
            this.DayTextBox.Size = new System.Drawing.Size(100, 22);
            this.DayTextBox.TabIndex = 4;
            this.DayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DayTextBox.TextChanged += new System.EventHandler(this.DayTextBox_TextChanged);
            // 
            // MonthTextBox
            // 
            this.MonthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MonthTextBox.Location = new System.Drawing.Point(209, 93);
            this.MonthTextBox.Name = "MonthTextBox";
            this.MonthTextBox.Size = new System.Drawing.Size(100, 22);
            this.MonthTextBox.TabIndex = 5;
            this.MonthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonthTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // YearTextBox
            // 
            this.YearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearTextBox.Location = new System.Drawing.Point(209, 125);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(100, 22);
            this.YearTextBox.TabIndex = 6;
            this.YearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.YearTextBox.TextChanged += new System.EventHandler(this.YearTextBox_TextChanged);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Enabled = false;
            this.ResultTextBox.Location = new System.Drawing.Point(209, 160);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(100, 20);
            this.ResultTextBox.TabIndex = 7;
            this.ResultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ResultTextBox.TextChanged += new System.EventHandler(this.ResultTextBox_TextChanged);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(326, 193);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(98, 23);
            this.ExecuteButton.TabIndex = 8;
            this.ExecuteButton.Text = "Подсчитать";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 218);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.MonthTextBox);
            this.Controls.Add(this.DayTextBox);
            this.Controls.Add(this.FullDaysLabel);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.MouthLabel);
            this.Controls.Add(this.DayLabel);
            this.Name = "MainForm";
            this.Text = "Полные дни";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DayLabel;
        private System.Windows.Forms.Label MouthLabel;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label FullDaysLabel;
        private System.Windows.Forms.TextBox DayTextBox;
        private System.Windows.Forms.TextBox MonthTextBox;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Button ExecuteButton;
    }
}

