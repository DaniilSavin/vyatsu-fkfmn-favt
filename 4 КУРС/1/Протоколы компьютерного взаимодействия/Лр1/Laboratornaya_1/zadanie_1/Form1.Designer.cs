namespace zadanie_1
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
            this.ipTb = new System.Windows.Forms.TextBox();
            this.iplab = new System.Windows.Forms.Label();
            this.mask = new System.Windows.Forms.Label();
            this.maskTb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.calcBt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.macTb = new System.Windows.Forms.TextBox();
            this.maxHtb = new System.Windows.Forms.TextBox();
            this.ipAdHostTb = new System.Windows.Forms.TextBox();
            this.ipAdNetTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipTb
            // 
            this.ipTb.Location = new System.Drawing.Point(135, 23);
            this.ipTb.Margin = new System.Windows.Forms.Padding(4);
            this.ipTb.Name = "ipTb";
            this.ipTb.Size = new System.Drawing.Size(132, 23);
            this.ipTb.TabIndex = 0;
            this.ipTb.TextChanged += new System.EventHandler(this.ipTb_TextChanged);
            // 
            // iplab
            // 
            this.iplab.AutoSize = true;
            this.iplab.Location = new System.Drawing.Point(59, 23);
            this.iplab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iplab.Name = "iplab";
            this.iplab.Size = new System.Drawing.Size(68, 17);
            this.iplab.TabIndex = 1;
            this.iplab.Text = "IP-адрес:";
            // 
            // mask
            // 
            this.mask.AutoSize = true;
            this.mask.Location = new System.Drawing.Point(74, 57);
            this.mask.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mask.Name = "mask";
            this.mask.Size = new System.Drawing.Size(53, 17);
            this.mask.TabIndex = 2;
            this.mask.Text = "Маска:";
            // 
            // maskTb
            // 
            this.maskTb.Location = new System.Drawing.Point(135, 54);
            this.maskTb.Margin = new System.Windows.Forms.Padding(4);
            this.maskTb.Name = "maskTb";
            this.maskTb.Size = new System.Drawing.Size(132, 23);
            this.maskTb.TabIndex = 3;
            this.maskTb.TextChanged += new System.EventHandler(this.maskTb_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.iplab);
            this.groupBox1.Controls.Add(this.maskTb);
            this.groupBox1.Controls.Add(this.ipTb);
            this.groupBox1.Controls.Add(this.mask);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // calcBt
            // 
            this.calcBt.AutoSize = true;
            this.calcBt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calcBt.Location = new System.Drawing.Point(13, 109);
            this.calcBt.Name = "calcBt";
            this.calcBt.Size = new System.Drawing.Size(281, 31);
            this.calcBt.TabIndex = 5;
            this.calcBt.Text = "Calculate";
            this.calcBt.UseVisualStyleBackColor = true;
            this.calcBt.Click += new System.EventHandler(this.calcBt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.macTb);
            this.groupBox2.Controls.Add(this.maxHtb);
            this.groupBox2.Controls.Add(this.ipAdHostTb);
            this.groupBox2.Controls.Add(this.ipAdNetTb);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 143);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // macTb
            // 
            this.macTb.Enabled = false;
            this.macTb.Location = new System.Drawing.Point(134, 109);
            this.macTb.Margin = new System.Windows.Forms.Padding(4);
            this.macTb.Name = "macTb";
            this.macTb.Size = new System.Drawing.Size(132, 23);
            this.macTb.TabIndex = 9;
            // 
            // maxHtb
            // 
            this.maxHtb.Enabled = false;
            this.maxHtb.Location = new System.Drawing.Point(134, 78);
            this.maxHtb.Margin = new System.Windows.Forms.Padding(4);
            this.maxHtb.Name = "maxHtb";
            this.maxHtb.Size = new System.Drawing.Size(132, 23);
            this.maxHtb.TabIndex = 8;
            // 
            // ipAdHostTb
            // 
            this.ipAdHostTb.Enabled = false;
            this.ipAdHostTb.Location = new System.Drawing.Point(134, 47);
            this.ipAdHostTb.Margin = new System.Windows.Forms.Padding(4);
            this.ipAdHostTb.Name = "ipAdHostTb";
            this.ipAdHostTb.Size = new System.Drawing.Size(132, 23);
            this.ipAdHostTb.TabIndex = 7;
            // 
            // ipAdNetTb
            // 
            this.ipAdNetTb.Enabled = false;
            this.ipAdNetTb.Location = new System.Drawing.Point(134, 16);
            this.ipAdNetTb.Margin = new System.Windows.Forms.Padding(4);
            this.ipAdNetTb.Name = "ipAdNetTb";
            this.ipAdNetTb.Size = new System.Drawing.Size(132, 23);
            this.ipAdNetTb.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Broadcast-адрес:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Число хостов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP-адрес узла:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP-адрес сети:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 298);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.calcBt);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 337);
            this.MinimumSize = new System.Drawing.Size(320, 337);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipTb;
        private System.Windows.Forms.Label iplab;
        private System.Windows.Forms.Label mask;
        private System.Windows.Forms.TextBox maskTb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button calcBt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox macTb;
        private System.Windows.Forms.TextBox maxHtb;
        private System.Windows.Forms.TextBox ipAdHostTb;
        private System.Windows.Forms.TextBox ipAdNetTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

