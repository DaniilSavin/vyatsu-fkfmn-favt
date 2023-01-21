namespace _5._2
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.daytb = new System.Windows.Forms.TextBox();
            this.monthtb = new System.Windows.Forms.TextBox();
            this.yeartb = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ans = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите вашу дату рождения(DD/MM/YYYY):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(119, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Нахождение цифрового корня.";
            // 
            // daytb
            // 
            this.daytb.Location = new System.Drawing.Point(321, 46);
            this.daytb.Name = "daytb";
            this.daytb.Size = new System.Drawing.Size(33, 20);
            this.daytb.TabIndex = 2;
            // 
            // monthtb
            // 
            this.monthtb.Location = new System.Drawing.Point(360, 46);
            this.monthtb.Name = "monthtb";
            this.monthtb.Size = new System.Drawing.Size(35, 20);
            this.monthtb.TabIndex = 3;
            // 
            // yeartb
            // 
            this.yeartb.Location = new System.Drawing.Point(401, 46);
            this.yeartb.Name = "yeartb";
            this.yeartb.Size = new System.Drawing.Size(48, 20);
            this.yeartb.TabIndex = 4;
            this.yeartb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yeartb_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // ans
            // 
            this.ans.AutoSize = true;
            this.ans.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ans.Location = new System.Drawing.Point(12, 78);
            this.ans.Name = "ans";
            this.ans.Size = new System.Drawing.Size(52, 17);
            this.ans.TabIndex = 6;
            this.ans.Text = "Ответ:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Найти!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 148);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ans);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.yeartb);
            this.Controls.Add(this.monthtb);
            this.Controls.Add(this.daytb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Задание 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox daytb;
        private System.Windows.Forms.TextBox monthtb;
        private System.Windows.Forms.TextBox yeartb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label ans;
        private System.Windows.Forms.Button button1;
    }
}