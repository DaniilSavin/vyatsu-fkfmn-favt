namespace task_5
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
            this.ALabel = new System.Windows.Forms.Label();
            this.BLabel = new System.Windows.Forms.Label();
            this.CLabel = new System.Windows.Forms.Label();
            this.Result1Label = new System.Windows.Forms.Label();
            this.ATextBox = new System.Windows.Forms.TextBox();
            this.BTextBox = new System.Windows.Forms.TextBox();
            this.CTextBox = new System.Windows.Forms.TextBox();
            this.Result1TextBox = new System.Windows.Forms.TextBox();
            this.Result2Label = new System.Windows.Forms.Label();
            this.Result2TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(428, 392);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(96, 23);
            this.ExecuteButton.TabIndex = 0;
            this.ExecuteButton.Text = "Подсчитать";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // ALabel
            // 
            this.ALabel.AutoSize = true;
            this.ALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ALabel.Location = new System.Drawing.Point(163, 161);
            this.ALabel.Name = "ALabel";
            this.ALabel.Size = new System.Drawing.Size(170, 16);
            this.ALabel.TabIndex = 1;
            this.ALabel.Text = "Введите коэффициент a";
            // 
            // BLabel
            // 
            this.BLabel.AutoSize = true;
            this.BLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BLabel.Location = new System.Drawing.Point(163, 208);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(170, 16);
            this.BLabel.TabIndex = 2;
            this.BLabel.Text = "Введите коэффициент b";
            // 
            // CLabel
            // 
            this.CLabel.AutoSize = true;
            this.CLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CLabel.Location = new System.Drawing.Point(163, 240);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(169, 16);
            this.CLabel.TabIndex = 3;
            this.CLabel.Text = "Введите коэффициент c";
            // 
            // Result1Label
            // 
            this.Result1Label.AutoSize = true;
            this.Result1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Result1Label.Location = new System.Drawing.Point(163, 285);
            this.Result1Label.Name = "Result1Label";
            this.Result1Label.Size = new System.Drawing.Size(65, 16);
            this.Result1Label.TabIndex = 4;
            this.Result1Label.Text = "Корень 1";
            // 
            // ATextBox
            // 
            this.ATextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ATextBox.Location = new System.Drawing.Point(350, 155);
            this.ATextBox.Name = "ATextBox";
            this.ATextBox.Size = new System.Drawing.Size(100, 22);
            this.ATextBox.TabIndex = 5;
            this.ATextBox.Text = "0";
            this.ATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ATextBox.TextChanged += new System.EventHandler(this.ATextBox_TextChanged);
            // 
            // BTextBox
            // 
            this.BTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTextBox.Location = new System.Drawing.Point(350, 202);
            this.BTextBox.Name = "BTextBox";
            this.BTextBox.Size = new System.Drawing.Size(100, 22);
            this.BTextBox.TabIndex = 6;
            this.BTextBox.Text = "0";
            this.BTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BTextBox.TextChanged += new System.EventHandler(this.BTextBox_TextChanged);
            // 
            // CTextBox
            // 
            this.CTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CTextBox.Location = new System.Drawing.Point(350, 234);
            this.CTextBox.Name = "CTextBox";
            this.CTextBox.Size = new System.Drawing.Size(100, 22);
            this.CTextBox.TabIndex = 7;
            this.CTextBox.Text = "0";
            this.CTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CTextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Result1TextBox
            // 
            this.Result1TextBox.Enabled = false;
            this.Result1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Result1TextBox.Location = new System.Drawing.Point(350, 279);
            this.Result1TextBox.Name = "Result1TextBox";
            this.Result1TextBox.Size = new System.Drawing.Size(100, 22);
            this.Result1TextBox.TabIndex = 8;
            this.Result1TextBox.TextChanged += new System.EventHandler(this.Result1TextBox_TextChanged);
            // 
            // Result2Label
            // 
            this.Result2Label.AutoSize = true;
            this.Result2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Result2Label.Location = new System.Drawing.Point(163, 320);
            this.Result2Label.Name = "Result2Label";
            this.Result2Label.Size = new System.Drawing.Size(159, 16);
            this.Result2Label.TabIndex = 9;
            this.Result2Label.Text = "Корень 2 (при наличии)";
            // 
            // Result2TextBox
            // 
            this.Result2TextBox.Enabled = false;
            this.Result2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Result2TextBox.Location = new System.Drawing.Point(350, 314);
            this.Result2TextBox.Name = "Result2TextBox";
            this.Result2TextBox.Size = new System.Drawing.Size(100, 22);
            this.Result2TextBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Result2TextBox);
            this.Controls.Add(this.Result2Label);
            this.Controls.Add(this.Result1TextBox);
            this.Controls.Add(this.CTextBox);
            this.Controls.Add(this.BTextBox);
            this.Controls.Add(this.ATextBox);
            this.Controls.Add(this.Result1Label);
            this.Controls.Add(this.CLabel);
            this.Controls.Add(this.BLabel);
            this.Controls.Add(this.ALabel);
            this.Controls.Add(this.ExecuteButton);
            this.Name = "Form1";
            this.Text = "Корни уравнения";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Label ALabel;
        private System.Windows.Forms.Label BLabel;
        private System.Windows.Forms.Label CLabel;
        private System.Windows.Forms.Label Result1Label;
        private System.Windows.Forms.TextBox ATextBox;
        private System.Windows.Forms.TextBox BTextBox;
        private System.Windows.Forms.TextBox CTextBox;
        private System.Windows.Forms.TextBox Result1TextBox;
        private System.Windows.Forms.Label Result2Label;
        private System.Windows.Forms.TextBox Result2TextBox;
    }
}

