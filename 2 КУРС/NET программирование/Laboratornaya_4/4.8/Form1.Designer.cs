namespace _4._8
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
            this.button_yes = new System.Windows.Forms.Button();
            this.button_no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(61, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "ВЫ ДОВОЛЬНЫ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(122, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "СВОЕЙ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(75, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 46);
            this.label3.TabIndex = 2;
            this.label3.Text = "ЗАРПЛАТОЙ?";
            // 
            // button_yes
            // 
            this.button_yes.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_yes.Location = new System.Drawing.Point(110, 165);
            this.button_yes.Name = "button_yes";
            this.button_yes.Size = new System.Drawing.Size(69, 35);
            this.button_yes.TabIndex = 3;
            this.button_yes.Text = "ДА";
            this.button_yes.UseVisualStyleBackColor = true;
            this.button_yes.Click += new System.EventHandler(this.button_yes_Click);
            // 
            // button_no
            // 
            this.button_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_no.Location = new System.Drawing.Point(236, 165);
            this.button_no.Name = "button_no";
            this.button_no.Size = new System.Drawing.Size(66, 35);
            this.button_no.TabIndex = 4;
            this.button_no.Text = "НЕТ";
            this.button_no.UseVisualStyleBackColor = true;
            this.button_no.Click += new System.EventHandler(this.button_no_Click);
            this.button_no.Enter += new System.EventHandler(this.button_no_Enter);
            this.button_no.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_no_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 239);
            this.Controls.Add(this.button_no);
            this.Controls.Add(this.button_yes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Вопрос работодателя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_yes;
        private System.Windows.Forms.Button button_no;
    }
}

