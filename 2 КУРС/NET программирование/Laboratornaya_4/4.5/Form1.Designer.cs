namespace _4._5
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
            this.components = new System.ComponentModel.Container();
            this.a = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.b = new System.Windows.Forms.TextBox();
            this.c = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.x_1 = new System.Windows.Forms.Label();
            this.x_2 = new System.Windows.Forms.Label();
            this.x1 = new System.Windows.Forms.TextBox();
            this.x2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(37, 38);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(43, 20);
            this.a.TabIndex = 0;
            this.a.Text = "0";
            this.a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.a.KeyDown += new System.Windows.Forms.KeyEventHandler(this.a_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(116, 38);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(43, 20);
            this.b.TabIndex = 2;
            this.b.Text = "0";
            this.b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.b.KeyDown += new System.Windows.Forms.KeyEventHandler(this.b_KeyDown);
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(193, 38);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(43, 20);
            this.c.TabIndex = 3;
            this.c.Text = "0";
            this.c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "a=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(91, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "b=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(169, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "c=";
            // 
            // x_1
            // 
            this.x_1.AutoSize = true;
            this.x_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x_1.Location = new System.Drawing.Point(39, 86);
            this.x_1.Name = "x_1";
            this.x_1.Size = new System.Drawing.Size(30, 17);
            this.x_1.TabIndex = 7;
            this.x_1.Text = "x1=";
            // 
            // x_2
            // 
            this.x_2.AutoSize = true;
            this.x_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x_2.Location = new System.Drawing.Point(162, 86);
            this.x_2.Name = "x_2";
            this.x_2.Size = new System.Drawing.Size(30, 17);
            this.x_2.TabIndex = 8;
            this.x_2.Text = "x2=";
            // 
            // x1
            // 
            this.x1.Enabled = false;
            this.x1.Location = new System.Drawing.Point(75, 85);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(43, 20);
            this.x1.TabIndex = 9;
            this.x1.Text = "0";
            this.x1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // x2
            // 
            this.x2.Enabled = false;
            this.x2.Location = new System.Drawing.Point(191, 86);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(43, 20);
            this.x2.TabIndex = 10;
            this.x2.Text = "0";
            this.x2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(84, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Посчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(11, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(47, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Уравнение ax^2+bx+c=0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 162);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.x_2);
            this.Controls.Add(this.x_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c);
            this.Controls.Add(this.b);
            this.Controls.Add(this.a);
            this.Name = "Form1";
            this.Text = "Корни";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox a;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox b;
        private System.Windows.Forms.TextBox c;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label x_1;
        private System.Windows.Forms.Label x_2;
        private System.Windows.Forms.TextBox x1;
        private System.Windows.Forms.TextBox x2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

