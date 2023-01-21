namespace ex1
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
            this.CentiMLabel = new System.Windows.Forms.Label();
            this.CentiMTextBox = new System.Windows.Forms.TextBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.InchLabel = new System.Windows.Forms.Label();
            this.InchTextBox = new System.Windows.Forms.TextBox();
            this.YardLabel = new System.Windows.Forms.Label();
            this.FootLabel = new System.Windows.Forms.Label();
            this.YardTextBox = new System.Windows.Forms.TextBox();
            this.FootTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CentiMLabel
            // 
            this.CentiMLabel.AutoSize = true;
            this.CentiMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CentiMLabel.Location = new System.Drawing.Point(76, 58);
            this.CentiMLabel.Name = "CentiMLabel";
            this.CentiMLabel.Size = new System.Drawing.Size(205, 17);
            this.CentiMLabel.TabIndex = 0;
            this.CentiMLabel.Text = "Введите длину в сантиметрах";
            this.CentiMLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // CentiMTextBox
            // 
            this.CentiMTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CentiMTextBox.Location = new System.Drawing.Point(368, 58);
            this.CentiMTextBox.Name = "CentiMTextBox";
            this.CentiMTextBox.Size = new System.Drawing.Size(100, 23);
            this.CentiMTextBox.TabIndex = 1;
            this.CentiMTextBox.Text = "0";
            this.CentiMTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CentiMTextBox.TextChanged += new System.EventHandler(this.CentiMTextBox_TextChanged);
            this.CentiMTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CentiMTextBox_KeyDown);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(392, 283);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(88, 27);
            this.ExecuteButton.TabIndex = 2;
            this.ExecuteButton.Text = "Перевести";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // InchLabel
            // 
            this.InchLabel.AutoSize = true;
            this.InchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InchLabel.Location = new System.Drawing.Point(76, 111);
            this.InchLabel.Name = "InchLabel";
            this.InchLabel.Size = new System.Drawing.Size(115, 17);
            this.InchLabel.TabIndex = 3;
            this.InchLabel.Text = "Длина в дюймах";
            // 
            // InchTextBox
            // 
            this.InchTextBox.Enabled = false;
            this.InchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.InchTextBox.Location = new System.Drawing.Point(368, 111);
            this.InchTextBox.Name = "InchTextBox";
            this.InchTextBox.Size = new System.Drawing.Size(100, 23);
            this.InchTextBox.TabIndex = 4;
            this.InchTextBox.Text = "0";
            this.InchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.InchTextBox.TextChanged += new System.EventHandler(this.InchTextBox_TextChanged);
            // 
            // YardLabel
            // 
            this.YardLabel.AutoSize = true;
            this.YardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.YardLabel.Location = new System.Drawing.Point(77, 205);
            this.YardLabel.Name = "YardLabel";
            this.YardLabel.Size = new System.Drawing.Size(104, 17);
            this.YardLabel.TabIndex = 5;
            this.YardLabel.Text = "Длина в ярдах";
            this.YardLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // FootLabel
            // 
            this.FootLabel.AutoSize = true;
            this.FootLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FootLabel.Location = new System.Drawing.Point(77, 162);
            this.FootLabel.Name = "FootLabel";
            this.FootLabel.Size = new System.Drawing.Size(103, 16);
            this.FootLabel.TabIndex = 6;
            this.FootLabel.Text = "Длина в футах";
            this.FootLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // YardTextBox
            // 
            this.YardTextBox.Enabled = false;
            this.YardTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YardTextBox.Location = new System.Drawing.Point(368, 200);
            this.YardTextBox.Name = "YardTextBox";
            this.YardTextBox.Size = new System.Drawing.Size(100, 22);
            this.YardTextBox.TabIndex = 7;
            this.YardTextBox.Text = "0";
            this.YardTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FootTextBox
            // 
            this.FootTextBox.Enabled = false;
            this.FootTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FootTextBox.Location = new System.Drawing.Point(368, 156);
            this.FootTextBox.Name = "FootTextBox";
            this.FootTextBox.Size = new System.Drawing.Size(100, 22);
            this.FootTextBox.TabIndex = 8;
            this.FootTextBox.Text = "0";
            this.FootTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FootTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 324);
            this.Controls.Add(this.FootTextBox);
            this.Controls.Add(this.YardTextBox);
            this.Controls.Add(this.FootLabel);
            this.Controls.Add(this.YardLabel);
            this.Controls.Add(this.InchTextBox);
            this.Controls.Add(this.InchLabel);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.CentiMTextBox);
            this.Controls.Add(this.CentiMLabel);
            this.Name = "MainForm";
            this.Text = "Конвертер";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CentiMLabel;
        private System.Windows.Forms.TextBox CentiMTextBox;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Label InchLabel;
        private System.Windows.Forms.TextBox InchTextBox;
        private System.Windows.Forms.Label YardLabel;
        private System.Windows.Forms.Label FootLabel;
        private System.Windows.Forms.TextBox YardTextBox;
        private System.Windows.Forms.TextBox FootTextBox;
    }
}

