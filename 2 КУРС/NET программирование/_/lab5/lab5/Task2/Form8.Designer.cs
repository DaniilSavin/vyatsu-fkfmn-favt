namespace Task2
{
    partial class Form8
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.DrawButton = new System.Windows.Forms.Button();
            this.RecTextBox = new System.Windows.Forms.TextBox();
            this.RecLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.FallButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeLabel.Location = new System.Drawing.Point(9, 15);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(203, 16);
            this.SizeLabel.TabIndex = 0;
            this.SizeLabel.Text = "Размер снежинки (от 1 до 200)";
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeTextBox.Location = new System.Drawing.Point(216, 12);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(100, 22);
            this.SizeTextBox.TabIndex = 1;
            // 
            // DrawButton
            // 
            this.DrawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawButton.Location = new System.Drawing.Point(73, 114);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(103, 23);
            this.DrawButton.TabIndex = 2;
            this.DrawButton.Text = "Нарисовать";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // RecTextBox
            // 
            this.RecTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecTextBox.Location = new System.Drawing.Point(216, 57);
            this.RecTextBox.Name = "RecTextBox";
            this.RecTextBox.Size = new System.Drawing.Size(100, 22);
            this.RecTextBox.TabIndex = 4;
            this.RecTextBox.TextChanged += new System.EventHandler(this.SizeTextBox_TextChanged);
            // 
            // RecLabel
            // 
            this.RecLabel.AutoSize = true;
            this.RecLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecLabel.Location = new System.Drawing.Point(9, 63);
            this.RecLabel.Name = "RecLabel";
            this.RecLabel.Size = new System.Drawing.Size(167, 16);
            this.RecLabel.TabIndex = 3;
            this.RecLabel.Text = "Вложенность (от 1 до 20)";
            this.RecLabel.Click += new System.EventHandler(this.SizeLabel_Click);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.Location = new System.Drawing.Point(499, 15);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(103, 23);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "Возврат";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // FallButton
            // 
            this.FallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FallButton.Location = new System.Drawing.Point(499, 453);
            this.FallButton.Name = "FallButton";
            this.FallButton.Size = new System.Drawing.Size(103, 23);
            this.FallButton.TabIndex = 6;
            this.FallButton.Text = "Имитация";
            this.FallButton.UseVisualStyleBackColor = true;
            this.FallButton.Click += new System.EventHandler(this.FallButton_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 488);
            this.Controls.Add(this.FallButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.RecTextBox);
            this.Controls.Add(this.RecLabel);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.SizeTextBox);
            this.Controls.Add(this.SizeLabel);
            this.Name = "Form8";
            this.Text = "Снежинка";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form8_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.TextBox RecTextBox;
        private System.Windows.Forms.Label RecLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button FallButton;
    }
}