namespace task3
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
            this.MFGroupBox = new System.Windows.Forms.GroupBox();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.PowerLabel = new System.Windows.Forms.Label();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.PowerTextBox = new System.Windows.Forms.TextBox();
            this.AgeTextBox = new System.Windows.Forms.TextBox();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.MFGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MFGroupBox
            // 
            this.MFGroupBox.Controls.Add(this.FemaleRadioButton);
            this.MFGroupBox.Controls.Add(this.MaleRadioButton);
            this.MFGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MFGroupBox.Location = new System.Drawing.Point(176, 47);
            this.MFGroupBox.Name = "MFGroupBox";
            this.MFGroupBox.Size = new System.Drawing.Size(200, 100);
            this.MFGroupBox.TabIndex = 0;
            this.MFGroupBox.TabStop = false;
            this.MFGroupBox.Text = "Выберите пол";
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Location = new System.Drawing.Point(5, 60);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(88, 20);
            this.FemaleRadioButton.TabIndex = 1;
            this.FemaleRadioButton.Text = "Женщина";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            this.FemaleRadioButton.CheckedChanged += new System.EventHandler(this.PowerTextBox_TextChanged);
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Checked = true;
            this.MaleRadioButton.Location = new System.Drawing.Point(7, 34);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(86, 20);
            this.MaleRadioButton.TabIndex = 0;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Мужчина";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            this.MaleRadioButton.CheckedChanged += new System.EventHandler(this.AgeTextBox_TextChanged);
            // 
            // PowerLabel
            // 
            this.PowerLabel.AutoSize = true;
            this.PowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PowerLabel.Location = new System.Drawing.Point(215, 184);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(235, 16);
            this.PowerLabel.TabIndex = 1;
            this.PowerLabel.Text = "Введите свой рост от 130 до 195 см";
            this.PowerLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AgeLabel.Location = new System.Drawing.Point(198, 216);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(252, 16);
            this.AgeLabel.TabIndex = 2;
            this.AgeLabel.Text = "Введите свой возраст от 15 до 60 лет";
            // 
            // PowerTextBox
            // 
            this.PowerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PowerTextBox.Location = new System.Drawing.Point(456, 181);
            this.PowerTextBox.Name = "PowerTextBox";
            this.PowerTextBox.Size = new System.Drawing.Size(100, 22);
            this.PowerTextBox.TabIndex = 3;
            this.PowerTextBox.Text = "0";
            this.PowerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PowerTextBox.TextChanged += new System.EventHandler(this.PowerTextBox_TextChanged);
            this.PowerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PowerTextBox_KeyDown);
            // 
            // AgeTextBox
            // 
            this.AgeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AgeTextBox.Location = new System.Drawing.Point(456, 213);
            this.AgeTextBox.Name = "AgeTextBox";
            this.AgeTextBox.Size = new System.Drawing.Size(100, 22);
            this.AgeTextBox.TabIndex = 4;
            this.AgeTextBox.Text = "0";
            this.AgeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AgeTextBox.TextChanged += new System.EventHandler(this.AgeTextBox_TextChanged);
            this.AgeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AgeTextBox_KeyDown);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLabel.Location = new System.Drawing.Point(321, 266);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(108, 16);
            this.ResultLabel.TabIndex = 5;
            this.ResultLabel.Text = "Идеальный вес";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Enabled = false;
            this.ResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultTextBox.Location = new System.Drawing.Point(456, 263);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(100, 22);
            this.ResultTextBox.TabIndex = 6;
            this.ResultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ResultTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResultTextBox_KeyDown);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(477, 439);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(100, 23);
            this.ExecuteButton.TabIndex = 7;
            this.ExecuteButton.Text = "Подсчитать";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 474);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.AgeTextBox);
            this.Controls.Add(this.PowerTextBox);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.PowerLabel);
            this.Controls.Add(this.MFGroupBox);
            this.Name = "MainForm";
            this.Text = "Идеальный вес";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MFGroupBox.ResumeLayout(false);
            this.MFGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MFGroupBox;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.Label PowerLabel;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.TextBox PowerTextBox;
        private System.Windows.Forms.TextBox AgeTextBox;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Button ExecuteButton;
     
    }

}