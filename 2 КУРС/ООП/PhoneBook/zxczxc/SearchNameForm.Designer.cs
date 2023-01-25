namespace zxczxc
{
    partial class SearchNameForm
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
            this.LastNameLab = new System.Windows.Forms.Label();
            this.NameLab = new System.Windows.Forms.Label();
            this.MiddleLab = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PatronymicTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ResultSearchLab = new System.Windows.Forms.Label();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.CloseBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LastNameLab
            // 
            this.LastNameLab.AutoSize = true;
            this.LastNameLab.Location = new System.Drawing.Point(17, 21);
            this.LastNameLab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LastNameLab.Name = "LastNameLab";
            this.LastNameLab.Size = new System.Drawing.Size(85, 20);
            this.LastNameLab.TabIndex = 0;
            this.LastNameLab.Text = "Фамилия:";
            // 
            // NameLab
            // 
            this.NameLab.AutoSize = true;
            this.NameLab.Location = new System.Drawing.Point(17, 73);
            this.NameLab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NameLab.Name = "NameLab";
            this.NameLab.Size = new System.Drawing.Size(44, 20);
            this.NameLab.TabIndex = 1;
            this.NameLab.Text = "Имя:";
            // 
            // MiddleLab
            // 
            this.MiddleLab.AutoSize = true;
            this.MiddleLab.Location = new System.Drawing.Point(16, 120);
            this.MiddleLab.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MiddleLab.Name = "MiddleLab";
            this.MiddleLab.Size = new System.Drawing.Size(87, 20);
            this.MiddleLab.TabIndex = 2;
            this.MiddleLab.Text = "Отчество:";
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(170, 17);
            this.LastNameTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(156, 26);
            this.LastNameTextBox.TabIndex = 3;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(170, 70);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(156, 26);
            this.NameTextBox.TabIndex = 4;
            // 
            // PatronymicTextBox
            // 
            this.PatronymicTextBox.Location = new System.Drawing.Point(170, 120);
            this.PatronymicTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.PatronymicTextBox.Name = "PatronymicTextBox";
            this.PatronymicTextBox.Size = new System.Drawing.Size(156, 26);
            this.PatronymicTextBox.TabIndex = 5;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(105, 158);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(110, 32);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ResultSearchLab
            // 
            this.ResultSearchLab.AutoSize = true;
            this.ResultSearchLab.Location = new System.Drawing.Point(83, 194);
            this.ResultSearchLab.Name = "ResultSearchLab";
            this.ResultSearchLab.Size = new System.Drawing.Size(160, 20);
            this.ResultSearchLab.TabIndex = 7;
            this.ResultSearchLab.Text = "Результаты поиска:";
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Location = new System.Drawing.Point(20, 218);
            this.ResultsTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.ReadOnly = true;
            this.ResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultsTextBox.Size = new System.Drawing.Size(293, 187);
            this.ResultsTextBox.TabIndex = 8;
            // 
            // CloseBut
            // 
            this.CloseBut.Location = new System.Drawing.Point(105, 422);
            this.CloseBut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseBut.Name = "CloseBut";
            this.CloseBut.Size = new System.Drawing.Size(110, 35);
            this.CloseBut.TabIndex = 9;
            this.CloseBut.Text = "Закрыть";
            this.CloseBut.UseVisualStyleBackColor = true;
            this.CloseBut.Click += new System.EventHandler(this.CloseBut_Click);
            // 
            // SearchNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 470);
            this.Controls.Add(this.CloseBut);
            this.Controls.Add(this.ResultsTextBox);
            this.Controls.Add(this.ResultSearchLab);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.PatronymicTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.MiddleLab);
            this.Controls.Add(this.NameLab);
            this.Controls.Add(this.LastNameLab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchNameForm";
            this.Text = "Поиск абонента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LastNameLab;
        private System.Windows.Forms.Label NameLab;
        private System.Windows.Forms.Label MiddleLab;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PatronymicTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label ResultSearchLab;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.Button CloseBut;
    }
}