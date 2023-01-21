namespace _4._3
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
            this.growth = new System.Windows.Forms.Label();
            this.rost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vozrast = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.male = new System.Windows.Forms.RadioButton();
            this.female = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // growth
            // 
            this.growth.AutoSize = true;
            this.growth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.growth.Location = new System.Drawing.Point(12, 18);
            this.growth.Name = "growth";
            this.growth.Size = new System.Drawing.Size(142, 17);
            this.growth.TabIndex = 0;
            this.growth.Text = "Рост в сантиметрах:";
            // 
            // rost
            // 
            this.rost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rost.Location = new System.Drawing.Point(160, 15);
            this.rost.Name = "rost";
            this.rost.Size = new System.Drawing.Size(41, 23);
            this.rost.TabIndex = 1;
            this.rost.Text = "0";
            this.rost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rost.TextChanged += new System.EventHandler(this.rost_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Возраст в годах:";
            // 
            // vozrast
            // 
            this.vozrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vozrast.Location = new System.Drawing.Point(160, 46);
            this.vozrast.Name = "vozrast";
            this.vozrast.Size = new System.Drawing.Size(41, 23);
            this.vozrast.TabIndex = 3;
            this.vozrast.Text = "0";
            this.vozrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vozrast.TextChanged += new System.EventHandler(this.vozrast_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пол:";
            // 
            // male
            // 
            this.male.AutoSize = true;
            this.male.Checked = true;
            this.male.Location = new System.Drawing.Point(56, 76);
            this.male.Name = "male";
            this.male.Size = new System.Drawing.Size(71, 17);
            this.male.TabIndex = 5;
            this.male.TabStop = true;
            this.male.Text = "Мужской";
            this.male.UseVisualStyleBackColor = true;
            // 
            // female
            // 
            this.female.AutoSize = true;
            this.female.Location = new System.Drawing.Point(133, 76);
            this.female.Name = "female";
            this.female.Size = new System.Drawing.Size(72, 17);
            this.female.TabIndex = 6;
            this.female.Text = "Женский";
            this.female.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(58, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Посчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Идеальный вес:";
            // 
            // result
            // 
            this.result.Enabled = false;
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.result.Location = new System.Drawing.Point(156, 139);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(45, 23);
            this.result.TabIndex = 9;
            this.result.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 173);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.female);
            this.Controls.Add(this.male);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vozrast);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rost);
            this.Controls.Add(this.growth);
            this.Name = "Form1";
            this.Text = "Вес";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label growth;
        private System.Windows.Forms.TextBox rost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vozrast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton male;
        private System.Windows.Forms.RadioButton female;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox result;
    }
}

