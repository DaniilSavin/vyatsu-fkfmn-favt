namespace _4._4
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
            this.level = new System.Windows.Forms.Label();
            this.level_low = new System.Windows.Forms.RadioButton();
            this.level_med = new System.Windows.Forms.RadioButton();
            this.level_hard = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.level.Location = new System.Drawing.Point(12, 19);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(141, 17);
            this.level.TabIndex = 0;
            this.level.Text = "Уровень сложности:";
            // 
            // level_low
            // 
            this.level_low.AutoSize = true;
            this.level_low.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.level_low.Location = new System.Drawing.Point(15, 48);
            this.level_low.Name = "level_low";
            this.level_low.Size = new System.Drawing.Size(72, 21);
            this.level_low.TabIndex = 1;
            this.level_low.TabStop = true;
            this.level_low.Text = "Легкий";
            this.level_low.UseVisualStyleBackColor = true;
            // 
            // level_med
            // 
            this.level_med.AutoSize = true;
            this.level_med.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.level_med.Location = new System.Drawing.Point(15, 71);
            this.level_med.Name = "level_med";
            this.level_med.Size = new System.Drawing.Size(83, 21);
            this.level_med.TabIndex = 2;
            this.level_med.TabStop = true;
            this.level_med.Text = "Средний";
            this.level_med.UseVisualStyleBackColor = true;
            // 
            // level_hard
            // 
            this.level_hard.AutoSize = true;
            this.level_hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.level_hard.Location = new System.Drawing.Point(15, 94);
            this.level_hard.Name = "level_hard";
            this.level_hard.Size = new System.Drawing.Size(86, 21);
            this.level_hard.TabIndex = 3;
            this.level_hard.TabStop = true;
            this.level_hard.Text = "Тяжелый";
            this.level_hard.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(492, 285);
            this.Controls.Add(this.level_hard);
            this.Controls.Add(this.level_med);
            this.Controls.Add(this.level_low);
            this.Controls.Add(this.level);
            this.Name = "Form1";
            this.Text = "Нажмите Enter, чтобы начать!";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label level;
        private System.Windows.Forms.RadioButton level_low;
        private System.Windows.Forms.RadioButton level_med;
        private System.Windows.Forms.RadioButton level_hard;
    }
}

