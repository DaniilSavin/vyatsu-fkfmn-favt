namespace task10
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
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.InputLabel = new System.Windows.Forms.Label();
            this.StringLabel = new System.Windows.Forms.Label();
            this.StringTextBox = new System.Windows.Forms.TextBox();
            this.StringButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputTextBox.Location = new System.Drawing.Point(155, 38);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(100, 22);
            this.InputTextBox.TabIndex = 0;
            this.InputTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputLabel.Location = new System.Drawing.Point(31, 41);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(118, 16);
            this.InputLabel.TabIndex = 1;
            this.InputLabel.Text = "Исходная строка";
            // 
            // StringLabel
            // 
            this.StringLabel.AutoSize = true;
            this.StringLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StringLabel.Location = new System.Drawing.Point(31, 82);
            this.StringLabel.Name = "StringLabel";
            this.StringLabel.Size = new System.Drawing.Size(119, 16);
            this.StringLabel.TabIndex = 3;
            this.StringLabel.Text = "Конечная строка";
            // 
            // StringTextBox
            // 
            this.StringTextBox.Enabled = false;
            this.StringTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StringTextBox.Location = new System.Drawing.Point(155, 79);
            this.StringTextBox.Name = "StringTextBox";
            this.StringTextBox.Size = new System.Drawing.Size(100, 22);
            this.StringTextBox.TabIndex = 2;
            this.StringTextBox.TextChanged += new System.EventHandler(this.StringTextBox_TextChanged);
            // 
            // StringButton
            // 
            this.StringButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StringButton.Location = new System.Drawing.Point(92, 138);
            this.StringButton.Name = "StringButton";
            this.StringButton.Size = new System.Drawing.Size(111, 23);
            this.StringButton.TabIndex = 4;
            this.StringButton.Text = "Реализовать";
            this.StringButton.UseVisualStyleBackColor = true;
            this.StringButton.Click += new System.EventHandler(this.StringButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 190);
            this.Controls.Add(this.StringButton);
            this.Controls.Add(this.StringLabel);
            this.Controls.Add(this.StringTextBox);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.InputTextBox);
            this.Name = "Form1";
            this.Text = "Different String";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.Label StringLabel;
        private System.Windows.Forms.TextBox StringTextBox;
        private System.Windows.Forms.Button StringButton;
    }
}

