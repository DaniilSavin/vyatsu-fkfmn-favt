namespace task11
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
            this.StringButton = new System.Windows.Forms.Button();
            this.StringLabel = new System.Windows.Forms.Label();
            this.StringTextBox = new System.Windows.Forms.TextBox();
            this.InputLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StringButton
            // 
            this.StringButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StringButton.Location = new System.Drawing.Point(83, 130);
            this.StringButton.Name = "StringButton";
            this.StringButton.Size = new System.Drawing.Size(111, 23);
            this.StringButton.TabIndex = 9;
            this.StringButton.Text = "Реализовать";
            this.StringButton.UseVisualStyleBackColor = true;
            this.StringButton.Click += new System.EventHandler(this.StringButton_Click);
            // 
            // StringLabel
            // 
            this.StringLabel.AutoSize = true;
            this.StringLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StringLabel.Location = new System.Drawing.Point(22, 74);
            this.StringLabel.Name = "StringLabel";
            this.StringLabel.Size = new System.Drawing.Size(119, 16);
            this.StringLabel.TabIndex = 8;
            this.StringLabel.Text = "Конечная строка";
            // 
            // StringTextBox
            // 
            this.StringTextBox.Enabled = false;
            this.StringTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StringTextBox.Location = new System.Drawing.Point(146, 71);
            this.StringTextBox.Name = "StringTextBox";
            this.StringTextBox.Size = new System.Drawing.Size(100, 22);
            this.StringTextBox.TabIndex = 7;
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputLabel.Location = new System.Drawing.Point(22, 33);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(118, 16);
            this.InputLabel.TabIndex = 6;
            this.InputLabel.Text = "Исходная строка";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputTextBox.Location = new System.Drawing.Point(146, 30);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(100, 22);
            this.InputTextBox.TabIndex = 5;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 189);
            this.Controls.Add(this.StringButton);
            this.Controls.Add(this.StringLabel);
            this.Controls.Add(this.StringTextBox);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.InputTextBox);
            this.Name = "Form1";
            this.Text = "DeleteString";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StringButton;
        private System.Windows.Forms.Label StringLabel;
        private System.Windows.Forms.TextBox StringTextBox;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.TextBox InputTextBox;
    }
}

