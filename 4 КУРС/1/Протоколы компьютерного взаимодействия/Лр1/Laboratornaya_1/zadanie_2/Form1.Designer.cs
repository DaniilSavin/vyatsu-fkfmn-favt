namespace zadanie_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ip1Tb = new System.Windows.Forms.TextBox();
            this.ip2Tb = new System.Windows.Forms.TextBox();
            this.subnetTb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ansLb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP-Адрес 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP-Адрес 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Маска:";
            // 
            // ip1Tb
            // 
            this.ip1Tb.Location = new System.Drawing.Point(101, 12);
            this.ip1Tb.Name = "ip1Tb";
            this.ip1Tb.Size = new System.Drawing.Size(143, 23);
            this.ip1Tb.TabIndex = 3;
            this.ip1Tb.TextChanged += new System.EventHandler(this.ip1Tb_TextChanged);
            // 
            // ip2Tb
            // 
            this.ip2Tb.Location = new System.Drawing.Point(101, 41);
            this.ip2Tb.Name = "ip2Tb";
            this.ip2Tb.Size = new System.Drawing.Size(143, 23);
            this.ip2Tb.TabIndex = 4;
            this.ip2Tb.TextChanged += new System.EventHandler(this.ip2Tb_TextChanged);
            // 
            // subnetTb
            // 
            this.subnetTb.Location = new System.Drawing.Point(101, 70);
            this.subnetTb.Name = "subnetTb";
            this.subnetTb.Size = new System.Drawing.Size(143, 23);
            this.subnetTb.TabIndex = 5;
            this.subnetTb.TextChanged += new System.EventHandler(this.subnetTb_TextChanged);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(16, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Проверить!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ansLb
            // 
            this.ansLb.AutoSize = true;
            this.ansLb.Location = new System.Drawing.Point(13, 150);
            this.ansLb.Name = "ansLb";
            this.ansLb.Size = new System.Drawing.Size(0, 17);
            this.ansLb.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 195);
            this.Controls.Add(this.ansLb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.subnetTb);
            this.Controls.Add(this.ip2Tb);
            this.Controls.Add(this.ip1Tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 234);
            this.MinimumSize = new System.Drawing.Size(270, 234);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ip1Tb;
        private System.Windows.Forms.TextBox ip2Tb;
        private System.Windows.Forms.TextBox subnetTb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ansLb;
    }
}

