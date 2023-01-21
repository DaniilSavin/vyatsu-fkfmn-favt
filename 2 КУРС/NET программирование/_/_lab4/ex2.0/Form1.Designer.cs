namespace ex2._0
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
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.CentiMTextBox = new System.Windows.Forms.TextBox();
            this.CentiMLabel = new System.Windows.Forms.Label();
            this.ResultGroupBox = new System.Windows.Forms.GroupBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.InchRadioButton = new System.Windows.Forms.RadioButton();
            this.FootRadioButton = new System.Windows.Forms.RadioButton();
            this.YardRadioButton = new System.Windows.Forms.RadioButton();
            this.ResultGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(296, 295);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(88, 27);
            this.ExecuteButton.TabIndex = 11;
            this.ExecuteButton.Text = "Перевести";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // CentiMTextBox
            // 
            this.CentiMTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CentiMTextBox.Location = new System.Drawing.Point(252, 75);
            this.CentiMTextBox.Name = "CentiMTextBox";
            this.CentiMTextBox.Size = new System.Drawing.Size(100, 23);
            this.CentiMTextBox.TabIndex = 10;
            this.CentiMTextBox.Text = "0";
            this.CentiMTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CentiMLabel
            // 
            this.CentiMLabel.AutoSize = true;
            this.CentiMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CentiMLabel.Location = new System.Drawing.Point(21, 75);
            this.CentiMLabel.Name = "CentiMLabel";
            this.CentiMLabel.Size = new System.Drawing.Size(205, 17);
            this.CentiMLabel.TabIndex = 9;
            this.CentiMLabel.Text = "Введите длину в сантиметрах";
            // 
            // ResultGroupBox
            // 
            this.ResultGroupBox.Controls.Add(this.YardRadioButton);
            this.ResultGroupBox.Controls.Add(this.FootRadioButton);
            this.ResultGroupBox.Controls.Add(this.InchRadioButton);
            this.ResultGroupBox.Controls.Add(this.ResultTextBox);
            this.ResultGroupBox.Location = new System.Drawing.Point(12, 130);
            this.ResultGroupBox.Name = "ResultGroupBox";
            this.ResultGroupBox.Size = new System.Drawing.Size(340, 131);
            this.ResultGroupBox.TabIndex = 18;
            this.ResultGroupBox.TabStop = false;
            this.ResultGroupBox.Text = "Результат";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Enabled = false;
            this.ResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultTextBox.Location = new System.Drawing.Point(240, 16);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(100, 22);
            this.ResultTextBox.TabIndex = 0;
            this.ResultTextBox.Text = "0";
            this.ResultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // InchRadioButton
            // 
            this.InchRadioButton.AutoSize = true;
            this.InchRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InchRadioButton.Location = new System.Drawing.Point(14, 47);
            this.InchRadioButton.Name = "InchRadioButton";
            this.InchRadioButton.Size = new System.Drawing.Size(86, 20);
            this.InchRadioButton.TabIndex = 1;
            this.InchRadioButton.TabStop = true;
            this.InchRadioButton.Text = "в дюймах";
            this.InchRadioButton.UseVisualStyleBackColor = true;
            this.InchRadioButton.CheckedChanged += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // FootRadioButton
            // 
            this.FootRadioButton.AutoSize = true;
            this.FootRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FootRadioButton.Location = new System.Drawing.Point(14, 73);
            this.FootRadioButton.Name = "FootRadioButton";
            this.FootRadioButton.Size = new System.Drawing.Size(77, 20);
            this.FootRadioButton.TabIndex = 2;
            this.FootRadioButton.TabStop = true;
            this.FootRadioButton.Text = "в футах";
            this.FootRadioButton.UseVisualStyleBackColor = true;
            this.FootRadioButton.CheckedChanged += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // YardRadioButton
            // 
            this.YardRadioButton.AutoSize = true;
            this.YardRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YardRadioButton.Location = new System.Drawing.Point(14, 99);
            this.YardRadioButton.Name = "YardRadioButton";
            this.YardRadioButton.Size = new System.Drawing.Size(74, 20);
            this.YardRadioButton.TabIndex = 3;
            this.YardRadioButton.TabStop = true;
            this.YardRadioButton.Text = "в ярдах";
            this.YardRadioButton.UseVisualStyleBackColor = true;
            this.YardRadioButton.CheckedChanged += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 334);
            this.Controls.Add(this.ResultGroupBox);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.CentiMTextBox);
            this.Controls.Add(this.CentiMLabel);
            this.Name = "MainForm";
            this.Text = "Конвертер";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResultGroupBox.ResumeLayout(false);
            this.ResultGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.TextBox CentiMTextBox;
        private System.Windows.Forms.Label CentiMLabel;
        private System.Windows.Forms.GroupBox ResultGroupBox;
        private System.Windows.Forms.RadioButton YardRadioButton;
        private System.Windows.Forms.RadioButton FootRadioButton;
        private System.Windows.Forms.RadioButton InchRadioButton;
        private System.Windows.Forms.TextBox ResultTextBox;
    }
}

