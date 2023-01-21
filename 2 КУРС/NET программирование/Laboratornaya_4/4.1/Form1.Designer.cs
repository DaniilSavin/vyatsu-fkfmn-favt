namespace _4._1
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
            this.label3 = new System.Windows.Forms.Label();
            this.dayleft = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.daytextbox = new System.Windows.Forms.TextBox();
            this.monthtextbox = new System.Windows.Forms.TextBox();
            this.yeartextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Любая дата(DD/MM/YY):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Дней прошло:";
            // 
            // dayleft
            // 
            this.dayleft.Enabled = false;
            this.dayleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dayleft.Location = new System.Drawing.Point(228, 52);
            this.dayleft.Name = "dayleft";
            this.dayleft.Size = new System.Drawing.Size(128, 23);
            this.dayleft.TabIndex = 7;
            this.dayleft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(259, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Подсчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // daytextbox
            // 
            this.daytextbox.Location = new System.Drawing.Point(228, 18);
            this.daytextbox.Name = "daytextbox";
            this.daytextbox.Size = new System.Drawing.Size(31, 20);
            this.daytextbox.TabIndex = 9;
            this.daytextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // monthtextbox
            // 
            this.monthtextbox.Location = new System.Drawing.Point(265, 18);
            this.monthtextbox.Name = "monthtextbox";
            this.monthtextbox.Size = new System.Drawing.Size(33, 20);
            this.monthtextbox.TabIndex = 10;
            this.monthtextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // yeartextbox
            // 
            this.yeartextbox.Location = new System.Drawing.Point(305, 18);
            this.yeartextbox.Name = "yeartextbox";
            this.yeartextbox.Size = new System.Drawing.Size(51, 20);
            this.yeartextbox.TabIndex = 11;
            this.yeartextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 107);
            this.Controls.Add(this.yeartextbox);
            this.Controls.Add(this.monthtextbox);
            this.Controls.Add(this.daytextbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dayleft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Дни";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dayleft;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox daytextbox;
        private System.Windows.Forms.TextBox monthtextbox;
        private System.Windows.Forms.TextBox yeartextbox;
    }
}

