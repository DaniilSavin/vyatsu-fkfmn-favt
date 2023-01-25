namespace zxczxc
{
    partial class SearchPhoneForm
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
            this.NumLab = new System.Windows.Forms.Label();
            this.NumTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SearchBut = new System.Windows.Forms.Button();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.CloseBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NumLab
            // 
            this.NumLab.AutoSize = true;
            this.NumLab.Location = new System.Drawing.Point(14, 41);
            this.NumLab.Name = "NumLab";
            this.NumLab.Size = new System.Drawing.Size(146, 20);
            this.NumLab.TabIndex = 0;
            this.NumLab.Text = "Номер телефона:";
            // 
            // NumTextBox
            // 
            this.NumTextBox.Location = new System.Drawing.Point(171, 41);
            this.NumTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumTextBox.Mask = "(999) 000-000";
            this.NumTextBox.Name = "NumTextBox";
            this.NumTextBox.Size = new System.Drawing.Size(164, 26);
            this.NumTextBox.TabIndex = 1;
            // 
            // SearchBut
            // 
            this.SearchBut.Location = new System.Drawing.Point(137, 74);
            this.SearchBut.Name = "SearchBut";
            this.SearchBut.Size = new System.Drawing.Size(95, 31);
            this.SearchBut.TabIndex = 2;
            this.SearchBut.Text = "Найти";
            this.SearchBut.UseVisualStyleBackColor = true;
            this.SearchBut.Click += new System.EventHandler(this.SearchBut_Click);
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Location = new System.Drawing.Point(40, 144);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.ReadOnly = true;
            this.ResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultsTextBox.Size = new System.Drawing.Size(295, 222);
            this.ResultsTextBox.TabIndex = 3;
            // 
            // CloseBut
            // 
            this.CloseBut.Location = new System.Drawing.Point(137, 391);
            this.CloseBut.Name = "CloseBut";
            this.CloseBut.Size = new System.Drawing.Size(95, 29);
            this.CloseBut.TabIndex = 4;
            this.CloseBut.Text = "Закрыть";
            this.CloseBut.UseVisualStyleBackColor = true;
            this.CloseBut.Click += new System.EventHandler(this.CloseBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Результаты поиска:";
            // 
            // SearchPhoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 444);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseBut);
            this.Controls.Add(this.ResultsTextBox);
            this.Controls.Add(this.SearchBut);
            this.Controls.Add(this.NumTextBox);
            this.Controls.Add(this.NumLab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchPhoneForm";
            this.Text = "Поиск по номеру телефона";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumLab;
        private System.Windows.Forms.MaskedTextBox NumTextBox;
        private System.Windows.Forms.Button SearchBut;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.Button CloseBut;
        private System.Windows.Forms.Label label1;
    }
}