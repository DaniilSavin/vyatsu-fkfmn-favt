namespace Task2
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DayLabel = new System.Windows.Forms.Label();
            this.DayTextBox = new System.Windows.Forms.TextBox();
            this.MonthTextBox = new System.Windows.Forms.TextBox();
            this.MonthLabel = new System.Windows.Forms.Label();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.YearLabel = new System.Windows.Forms.Label();
            this.DigitTextBox = new System.Windows.Forms.TextBox();
            this.DigitLabel = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DayLabel
            // 
            this.DayLabel.AutoSize = true;
            this.DayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DayLabel.Location = new System.Drawing.Point(4, 66);
            this.DayLabel.Name = "DayLabel";
            this.DayLabel.Size = new System.Drawing.Size(98, 16);
            this.DayLabel.TabIndex = 0;
            this.DayLabel.Text = "Введите день";
            // 
            // DayTextBox
            // 
            this.DayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DayTextBox.Location = new System.Drawing.Point(135, 66);
            this.DayTextBox.Name = "DayTextBox";
            this.DayTextBox.Size = new System.Drawing.Size(100, 22);
            this.DayTextBox.TabIndex = 1;
            this.DayTextBox.TextChanged += new System.EventHandler(this.DayTextBox_TextChanged);
            // 
            // MonthTextBox
            // 
            this.MonthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MonthTextBox.Location = new System.Drawing.Point(135, 92);
            this.MonthTextBox.Name = "MonthTextBox";
            this.MonthTextBox.Size = new System.Drawing.Size(100, 22);
            this.MonthTextBox.TabIndex = 3;
            this.MonthTextBox.TextChanged += new System.EventHandler(this.MonthTextBox_TextChanged);
            // 
            // MonthLabel
            // 
            this.MonthLabel.AutoSize = true;
            this.MonthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MonthLabel.Location = new System.Drawing.Point(4, 92);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Size = new System.Drawing.Size(106, 16);
            this.MonthLabel.TabIndex = 2;
            this.MonthLabel.Text = "Введите месяц";
            // 
            // YearTextBox
            // 
            this.YearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearTextBox.Location = new System.Drawing.Point(135, 118);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(100, 22);
            this.YearTextBox.TabIndex = 5;
            this.YearTextBox.TextChanged += new System.EventHandler(this.YearTextBox_TextChanged);
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearLabel.Location = new System.Drawing.Point(4, 118);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(89, 16);
            this.YearLabel.TabIndex = 4;
            this.YearLabel.Text = "Введите год";
            // 
            // DigitTextBox
            // 
            this.DigitTextBox.Enabled = false;
            this.DigitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DigitTextBox.Location = new System.Drawing.Point(135, 144);
            this.DigitTextBox.Name = "DigitTextBox";
            this.DigitTextBox.Size = new System.Drawing.Size(100, 22);
            this.DigitTextBox.TabIndex = 7;
            // 
            // DigitLabel
            // 
            this.DigitLabel.AutoSize = true;
            this.DigitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DigitLabel.Location = new System.Drawing.Point(4, 144);
            this.DigitLabel.Name = "DigitLabel";
            this.DigitLabel.Size = new System.Drawing.Size(125, 16);
            this.DigitLabel.TabIndex = 6;
            this.DigitLabel.Text = "Цифровой корень";
            // 
            // PlayButton
            // 
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayButton.Location = new System.Drawing.Point(256, 213);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 8;
            this.PlayButton.Text = "Сыграть";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 266);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.DigitTextBox);
            this.Controls.Add(this.DigitLabel);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.MonthTextBox);
            this.Controls.Add(this.MonthLabel);
            this.Controls.Add(this.DayTextBox);
            this.Controls.Add(this.DayLabel);
            this.Name = "Form3";
            this.Text = "Корень из цифр";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DayLabel;
        private System.Windows.Forms.TextBox DayTextBox;
        private System.Windows.Forms.TextBox MonthTextBox;
        private System.Windows.Forms.Label MonthLabel;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.TextBox DigitTextBox;
        private System.Windows.Forms.Label DigitLabel;
        private System.Windows.Forms.Button PlayButton;
    }
}