
namespace zadanie_3
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
            this.ipAd1Lb = new System.Windows.Forms.Label();
            this.ipAd2Lb = new System.Windows.Forms.Label();
            this.ipAd1Tb = new System.Windows.Forms.TextBox();
            this.ipAd2Tb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.subnetLb = new System.Windows.Forms.Label();
            this.subnetTb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipAd1Lb
            // 
            this.ipAd1Lb.AutoSize = true;
            this.ipAd1Lb.Location = new System.Drawing.Point(6, 19);
            this.ipAd1Lb.Name = "ipAd1Lb";
            this.ipAd1Lb.Size = new System.Drawing.Size(81, 17);
            this.ipAd1Lb.TabIndex = 0;
            this.ipAd1Lb.Text = "IP-Адрес 1:";
            // 
            // ipAd2Lb
            // 
            this.ipAd2Lb.AutoSize = true;
            this.ipAd2Lb.Location = new System.Drawing.Point(6, 54);
            this.ipAd2Lb.Name = "ipAd2Lb";
            this.ipAd2Lb.Size = new System.Drawing.Size(81, 17);
            this.ipAd2Lb.TabIndex = 1;
            this.ipAd2Lb.Text = "IP-Адрес 2:";
            // 
            // ipAd1Tb
            // 
            this.ipAd1Tb.Location = new System.Drawing.Point(93, 16);
            this.ipAd1Tb.Name = "ipAd1Tb";
            this.ipAd1Tb.Size = new System.Drawing.Size(113, 23);
            this.ipAd1Tb.TabIndex = 2;
            this.ipAd1Tb.TextChanged += new System.EventHandler(this.ipAd1Tb_TextChanged);
            // 
            // ipAd2Tb
            // 
            this.ipAd2Tb.Location = new System.Drawing.Point(93, 51);
            this.ipAd2Tb.Name = "ipAd2Tb";
            this.ipAd2Tb.Size = new System.Drawing.Size(113, 23);
            this.ipAd2Tb.TabIndex = 3;
            this.ipAd2Tb.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(12, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // subnetLb
            // 
            this.subnetLb.AutoSize = true;
            this.subnetLb.Location = new System.Drawing.Point(34, 25);
            this.subnetLb.Name = "subnetLb";
            this.subnetLb.Size = new System.Drawing.Size(53, 17);
            this.subnetLb.TabIndex = 5;
            this.subnetLb.Text = "Маска:";
            // 
            // subnetTb
            // 
            this.subnetTb.Enabled = false;
            this.subnetTb.Location = new System.Drawing.Point(93, 22);
            this.subnetTb.Name = "subnetTb";
            this.subnetTb.Size = new System.Drawing.Size(113, 23);
            this.subnetTb.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ipAd1Lb);
            this.groupBox1.Controls.Add(this.ipAd2Lb);
            this.groupBox1.Controls.Add(this.ipAd1Tb);
            this.groupBox1.Controls.Add(this.ipAd2Tb);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 85);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.subnetTb);
            this.groupBox2.Controls.Add(this.subnetLb);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 64);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 216);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 255);
            this.MinimumSize = new System.Drawing.Size(260, 255);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ipAd1Lb;
        private System.Windows.Forms.Label ipAd2Lb;
        private System.Windows.Forms.TextBox ipAd1Tb;
        private System.Windows.Forms.TextBox ipAd2Tb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label subnetLb;
        private System.Windows.Forms.TextBox subnetTb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

