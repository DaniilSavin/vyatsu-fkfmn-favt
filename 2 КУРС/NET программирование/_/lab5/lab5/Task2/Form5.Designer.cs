namespace Task2
{
    partial class Form5
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
            this.DimLabel = new System.Windows.Forms.Label();
            this.DimTextBox = new System.Windows.Forms.TextBox();
            this.RecTextBox = new System.Windows.Forms.TextBox();
            this.RecLabel = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DimLabel
            // 
            this.DimLabel.AutoSize = true;
            this.DimLabel.Location = new System.Drawing.Point(2, 9);
            this.DimLabel.Name = "DimLabel";
            this.DimLabel.Size = new System.Drawing.Size(158, 13);
            this.DimLabel.TabIndex = 0;
            this.DimLabel.Text = "Размер квадрата(от 10 до 80)";
            // 
            // DimTextBox
            // 
            this.DimTextBox.Location = new System.Drawing.Point(32, 25);
            this.DimTextBox.Name = "DimTextBox";
            this.DimTextBox.Size = new System.Drawing.Size(100, 20);
            this.DimTextBox.TabIndex = 1;
            // 
            // RecTextBox
            // 
            this.RecTextBox.Location = new System.Drawing.Point(219, 25);
            this.RecTextBox.Name = "RecTextBox";
            this.RecTextBox.Size = new System.Drawing.Size(100, 20);
            this.RecTextBox.TabIndex = 3;
            // 
            // RecLabel
            // 
            this.RecLabel.AutoSize = true;
            this.RecLabel.Location = new System.Drawing.Point(231, 9);
            this.RecLabel.Name = "RecLabel";
            this.RecLabel.Size = new System.Drawing.Size(75, 13);
            this.RecLabel.TabIndex = 2;
            this.RecLabel.Text = "Вложенность";
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(124, 207);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 4;
            this.PlayButton.Text = "Сыграть";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 242);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.RecTextBox);
            this.Controls.Add(this.RecLabel);
            this.Controls.Add(this.DimTextBox);
            this.Controls.Add(this.DimLabel);
            this.Name = "Form5";
            this.Text = "Рекурсивный квадрат";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DimLabel;
        private System.Windows.Forms.TextBox DimTextBox;
        private System.Windows.Forms.TextBox RecTextBox;
        private System.Windows.Forms.Label RecLabel;
        private System.Windows.Forms.Button PlayButton;
    }
}