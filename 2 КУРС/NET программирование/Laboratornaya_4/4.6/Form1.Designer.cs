namespace _4._6
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pryamoug_radbut = new System.Windows.Forms.RadioButton();
            this.ellips_radbut = new System.Windows.Forms.RadioButton();
            this.pr_el_rb = new System.Windows.Forms.RadioButton();
            this.one_rb = new System.Windows.Forms.RadioButton();
            this.two_rb = new System.Windows.Forms.RadioButton();
            this.low_speed_rb = new System.Windows.Forms.RadioButton();
            this.med_speed_rb = new System.Windows.Forms.RadioButton();
            this.fast_speed_rb = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pr_el_rb);
            this.groupBox1.Controls.Add(this.ellips_radbut);
            this.groupBox1.Controls.Add(this.pryamoug_radbut);
            this.groupBox1.Location = new System.Drawing.Point(13, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид  фигуры";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.two_rb);
            this.groupBox2.Controls.Add(this.one_rb);
            this.groupBox2.Location = new System.Drawing.Point(243, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 137);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Количество одновременно отображаемых фигур";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fast_speed_rb);
            this.groupBox3.Controls.Add(this.med_speed_rb);
            this.groupBox3.Controls.Add(this.low_speed_rb);
            this.groupBox3.Location = new System.Drawing.Point(479, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 137);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cкорость смены картинки";
            // 
            // pryamoug_radbut
            // 
            this.pryamoug_radbut.AutoSize = true;
            this.pryamoug_radbut.Location = new System.Drawing.Point(6, 19);
            this.pryamoug_radbut.Name = "pryamoug_radbut";
            this.pryamoug_radbut.Size = new System.Drawing.Size(105, 17);
            this.pryamoug_radbut.TabIndex = 3;
            this.pryamoug_radbut.TabStop = true;
            this.pryamoug_radbut.Text = "Прямоугольник";
            this.pryamoug_radbut.UseVisualStyleBackColor = true;
            this.pryamoug_radbut.CheckedChanged += new System.EventHandler(this.pryamoug_radbut_CheckedChanged);
            // 
            // ellips_radbut
            // 
            this.ellips_radbut.AutoSize = true;
            this.ellips_radbut.Location = new System.Drawing.Point(6, 42);
            this.ellips_radbut.Name = "ellips_radbut";
            this.ellips_radbut.Size = new System.Drawing.Size(62, 17);
            this.ellips_radbut.TabIndex = 4;
            this.ellips_radbut.TabStop = true;
            this.ellips_radbut.Text = "Эллипс";
            this.ellips_radbut.UseVisualStyleBackColor = true;
            this.ellips_radbut.CheckedChanged += new System.EventHandler(this.ellips_radbut_CheckedChanged);
            // 
            // pr_el_rb
            // 
            this.pr_el_rb.Location = new System.Drawing.Point(6, 64);
            this.pr_el_rb.Name = "pr_el_rb";
            this.pr_el_rb.Size = new System.Drawing.Size(112, 64);
            this.pr_el_rb.TabIndex = 5;
            this.pr_el_rb.TabStop = true;
            this.pr_el_rb.Text = "Прямоугольники и эллипсы в произвольном порядке";
            this.pr_el_rb.UseVisualStyleBackColor = true;
            this.pr_el_rb.CheckedChanged += new System.EventHandler(this.pr_el_rb_CheckedChanged);
            // 
            // one_rb
            // 
            this.one_rb.AutoSize = true;
            this.one_rb.Location = new System.Drawing.Point(15, 42);
            this.one_rb.Name = "one_rb";
            this.one_rb.Size = new System.Drawing.Size(51, 17);
            this.one_rb.TabIndex = 0;
            this.one_rb.TabStop = true;
            this.one_rb.Text = "Одна";
            this.one_rb.UseVisualStyleBackColor = true;
            this.one_rb.CheckedChanged += new System.EventHandler(this.one_rb_CheckedChanged);
            // 
            // two_rb
            // 
            this.two_rb.AutoSize = true;
            this.two_rb.Location = new System.Drawing.Point(15, 82);
            this.two_rb.Name = "two_rb";
            this.two_rb.Size = new System.Drawing.Size(46, 17);
            this.two_rb.TabIndex = 1;
            this.two_rb.TabStop = true;
            this.two_rb.Text = "Две";
            this.two_rb.UseVisualStyleBackColor = true;
            this.two_rb.CheckedChanged += new System.EventHandler(this.two_rb_CheckedChanged);
            // 
            // low_speed_rb
            // 
            this.low_speed_rb.AutoSize = true;
            this.low_speed_rb.Location = new System.Drawing.Point(19, 29);
            this.low_speed_rb.Name = "low_speed_rb";
            this.low_speed_rb.Size = new System.Drawing.Size(82, 17);
            this.low_speed_rb.TabIndex = 2;
            this.low_speed_rb.TabStop = true;
            this.low_speed_rb.Text = "Медленная";
            this.low_speed_rb.UseVisualStyleBackColor = true;
            this.low_speed_rb.CheckedChanged += new System.EventHandler(this.low_speed_rb_CheckedChanged);
            // 
            // med_speed_rb
            // 
            this.med_speed_rb.AutoSize = true;
            this.med_speed_rb.Location = new System.Drawing.Point(19, 64);
            this.med_speed_rb.Name = "med_speed_rb";
            this.med_speed_rb.Size = new System.Drawing.Size(68, 17);
            this.med_speed_rb.TabIndex = 3;
            this.med_speed_rb.TabStop = true;
            this.med_speed_rb.Text = "Средняя";
            this.med_speed_rb.UseVisualStyleBackColor = true;
            this.med_speed_rb.CheckedChanged += new System.EventHandler(this.med_speed_rb_CheckedChanged);
            // 
            // fast_speed_rb
            // 
            this.fast_speed_rb.AutoSize = true;
            this.fast_speed_rb.Location = new System.Drawing.Point(19, 98);
            this.fast_speed_rb.Name = "fast_speed_rb";
            this.fast_speed_rb.Size = new System.Drawing.Size(69, 17);
            this.fast_speed_rb.TabIndex = 4;
            this.fast_speed_rb.TabStop = true;
            this.fast_speed_rb.Text = "Быстрая";
            this.fast_speed_rb.UseVisualStyleBackColor = true;
            this.fast_speed_rb.CheckedChanged += new System.EventHandler(this.fast_speed_rb_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(151, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Создатель _не_найдено. При двойном клике по форме появится заставка. ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 205);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Заставка";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton pr_el_rb;
        private System.Windows.Forms.RadioButton ellips_radbut;
        private System.Windows.Forms.RadioButton pryamoug_radbut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton two_rb;
        private System.Windows.Forms.RadioButton one_rb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton fast_speed_rb;
        private System.Windows.Forms.RadioButton med_speed_rb;
        private System.Windows.Forms.RadioButton low_speed_rb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

