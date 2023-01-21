namespace task1
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
            this.ResultGroupBox = new System.Windows.Forms.GroupBox();
            this.YardRadioButton = new System.Windows.Forms.RadioButton();
            this.FootRadioButton = new System.Windows.Forms.RadioButton();
            this.InchRadioButton = new System.Windows.Forms.RadioButton();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.InputGroupBox = new System.Windows.Forms.GroupBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.YardInRadioButton = new System.Windows.Forms.RadioButton();
            this.FootInRadioButton = new System.Windows.Forms.RadioButton();
            this.InchInRadioButton = new System.Windows.Forms.RadioButton();
            this.ResultGroupBox.SuspendLayout();
            this.InputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultGroupBox
            // 
            this.ResultGroupBox.Controls.Add(this.YardRadioButton);
            this.ResultGroupBox.Controls.Add(this.FootRadioButton);
            this.ResultGroupBox.Controls.Add(this.InchRadioButton);
            this.ResultGroupBox.Controls.Add(this.ResultTextBox);
            this.ResultGroupBox.Location = new System.Drawing.Point(433, 68);
            this.ResultGroupBox.Name = "ResultGroupBox";
            this.ResultGroupBox.Size = new System.Drawing.Size(347, 131);
            this.ResultGroupBox.TabIndex = 22;
            this.ResultGroupBox.TabStop = false;
            this.ResultGroupBox.Text = "Результат";
            this.ResultGroupBox.Enter += new System.EventHandler(this.ResultGroupBox_Enter);
            // 
            // YardRadioButton
            // 
            this.YardRadioButton.AutoSize = true;
            this.YardRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YardRadioButton.Location = new System.Drawing.Point(14, 99);
            this.YardRadioButton.Name = "YardRadioButton";
            this.YardRadioButton.Size = new System.Drawing.Size(74, 20);
            this.YardRadioButton.TabIndex = 3;
            this.YardRadioButton.Text = "в ярдах";
            this.YardRadioButton.UseVisualStyleBackColor = true;
            this.YardRadioButton.CheckedChanged += new System.EventHandler(this.ExecuteButton_Click);
            this.YardRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YardRadioButton_KeyDown);
            // 
            // FootRadioButton
            // 
            this.FootRadioButton.AutoSize = true;
            this.FootRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FootRadioButton.Location = new System.Drawing.Point(14, 73);
            this.FootRadioButton.Name = "FootRadioButton";
            this.FootRadioButton.Size = new System.Drawing.Size(77, 20);
            this.FootRadioButton.TabIndex = 2;
            this.FootRadioButton.Text = "в футах";
            this.FootRadioButton.UseVisualStyleBackColor = true;
            this.FootRadioButton.CheckedChanged += new System.EventHandler(this.ExecuteButton_Click);
            this.FootRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FootRadioButton_KeyDown);
            // 
            // InchRadioButton
            // 
            this.InchRadioButton.AutoSize = true;
            this.InchRadioButton.Checked = true;
            this.InchRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InchRadioButton.Location = new System.Drawing.Point(14, 47);
            this.InchRadioButton.Name = "InchRadioButton";
            this.InchRadioButton.Size = new System.Drawing.Size(86, 20);
            this.InchRadioButton.TabIndex = 1;
            this.InchRadioButton.TabStop = true;
            this.InchRadioButton.Text = "в дюймах";
            this.InchRadioButton.UseVisualStyleBackColor = true;
            this.InchRadioButton.CheckedChanged += new System.EventHandler(this.ExecuteButton_Click);
            this.InchRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InchRadioButton_KeyDown);
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
            this.ResultTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InchRadioButton_KeyDown);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(347, 205);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(88, 27);
            this.ExecuteButton.TabIndex = 21;
            this.ExecuteButton.Text = "Перевести";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // InputGroupBox
            // 
            this.InputGroupBox.Controls.Add(this.InputTextBox);
            this.InputGroupBox.Controls.Add(this.YardInRadioButton);
            this.InputGroupBox.Controls.Add(this.FootInRadioButton);
            this.InputGroupBox.Controls.Add(this.InchInRadioButton);
            this.InputGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputGroupBox.Location = new System.Drawing.Point(31, 68);
            this.InputGroupBox.Name = "InputGroupBox";
            this.InputGroupBox.Size = new System.Drawing.Size(324, 131);
            this.InputGroupBox.TabIndex = 23;
            this.InputGroupBox.TabStop = false;
            this.InputGroupBox.Text = "Исходные данные";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputTextBox.Location = new System.Drawing.Point(201, 16);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(100, 22);
            this.InputTextBox.TabIndex = 7;
            this.InputTextBox.Text = "0";
            this.InputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            this.InputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputTextBox_KeyDown);
            // 
            // YardInRadioButton
            // 
            this.YardInRadioButton.AutoSize = true;
            this.YardInRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YardInRadioButton.Location = new System.Drawing.Point(6, 99);
            this.YardInRadioButton.Name = "YardInRadioButton";
            this.YardInRadioButton.Size = new System.Drawing.Size(74, 20);
            this.YardInRadioButton.TabIndex = 6;
            this.YardInRadioButton.Text = "в ярдах";
            this.YardInRadioButton.UseVisualStyleBackColor = true;
            this.YardInRadioButton.CheckedChanged += new System.EventHandler(this.ExecuteButton_Click);
            this.YardInRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YardInRadioButton_KeyDown);
            // 
            // FootInRadioButton
            // 
            this.FootInRadioButton.AutoSize = true;
            this.FootInRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FootInRadioButton.Location = new System.Drawing.Point(6, 73);
            this.FootInRadioButton.Name = "FootInRadioButton";
            this.FootInRadioButton.Size = new System.Drawing.Size(77, 20);
            this.FootInRadioButton.TabIndex = 5;
            this.FootInRadioButton.Text = "в футах";
            this.FootInRadioButton.UseVisualStyleBackColor = true;
            this.FootInRadioButton.CheckedChanged += new System.EventHandler(this.ExecuteButton_Click);
            this.FootInRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FootInRadioButton_KeyDown);
            // 
            // InchInRadioButton
            // 
            this.InchInRadioButton.AutoSize = true;
            this.InchInRadioButton.Checked = true;
            this.InchInRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InchInRadioButton.Location = new System.Drawing.Point(6, 47);
            this.InchInRadioButton.Name = "InchInRadioButton";
            this.InchInRadioButton.Size = new System.Drawing.Size(86, 20);
            this.InchInRadioButton.TabIndex = 4;
            this.InchInRadioButton.TabStop = true;
            this.InchInRadioButton.Text = "в дюймах";
            this.InchInRadioButton.UseVisualStyleBackColor = true;
            this.InchInRadioButton.CheckedChanged += new System.EventHandler(this.ExecuteButton_Click);
            this.InchInRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InchInRadioButton_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 266);
            this.Controls.Add(this.InputGroupBox);
            this.Controls.Add(this.ResultGroupBox);
            this.Controls.Add(this.ExecuteButton);
            this.Name = "Form1";
            this.Text = "Конвертор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResultGroupBox.ResumeLayout(false);
            this.ResultGroupBox.PerformLayout();
            this.InputGroupBox.ResumeLayout(false);
            this.InputGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ResultGroupBox;
        private System.Windows.Forms.RadioButton YardRadioButton;
        private System.Windows.Forms.RadioButton FootRadioButton;
        private System.Windows.Forms.RadioButton InchRadioButton;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.GroupBox InputGroupBox;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.RadioButton YardInRadioButton;
        private System.Windows.Forms.RadioButton FootInRadioButton;
        private System.Windows.Forms.RadioButton InchInRadioButton;
    }
}

