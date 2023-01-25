namespace zxczxc
{
    partial class SearchAddressForm
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
            this.StreetLab = new System.Windows.Forms.Label();
            this.HomeLab = new System.Windows.Forms.Label();
            this.FlatLab = new System.Windows.Forms.Label();
            this.StreetTextBox = new System.Windows.Forms.TextBox();
            this.ResultSearchLab = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.CloseBut = new System.Windows.Forms.Button();
            this.HouseTextBox = new System.Windows.Forms.NumericUpDown();
            this.FlatTextBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.HouseTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlatTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StreetLab
            // 
            this.StreetLab.AutoSize = true;
            this.StreetLab.Location = new System.Drawing.Point(27, 32);
            this.StreetLab.Name = "StreetLab";
            this.StreetLab.Size = new System.Drawing.Size(60, 20);
            this.StreetLab.TabIndex = 0;
            this.StreetLab.Text = "Улица:";
            // 
            // HomeLab
            // 
            this.HomeLab.AutoSize = true;
            this.HomeLab.Location = new System.Drawing.Point(27, 82);
            this.HomeLab.Name = "HomeLab";
            this.HomeLab.Size = new System.Drawing.Size(45, 20);
            this.HomeLab.TabIndex = 1;
            this.HomeLab.Text = "Дом:";
            // 
            // FlatLab
            // 
            this.FlatLab.AutoSize = true;
            this.FlatLab.Location = new System.Drawing.Point(27, 135);
            this.FlatLab.Name = "FlatLab";
            this.FlatLab.Size = new System.Drawing.Size(86, 20);
            this.FlatLab.TabIndex = 2;
            this.FlatLab.Text = "Квартира:";
            // 
            // StreetTextBox
            // 
            this.StreetTextBox.Location = new System.Drawing.Point(128, 29);
            this.StreetTextBox.Name = "StreetTextBox";
            this.StreetTextBox.Size = new System.Drawing.Size(154, 26);
            this.StreetTextBox.TabIndex = 3;
            // 
            // ResultSearchLab
            // 
            this.ResultSearchLab.AutoSize = true;
            this.ResultSearchLab.Location = new System.Drawing.Point(79, 221);
            this.ResultSearchLab.Name = "ResultSearchLab";
            this.ResultSearchLab.Size = new System.Drawing.Size(160, 20);
            this.ResultSearchLab.TabIndex = 7;
            this.ResultSearchLab.Text = "Результаты поиска:";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(100, 176);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(110, 32);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Location = new System.Drawing.Point(12, 245);
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
            this.CloseBut.Location = new System.Drawing.Point(100, 440);
            this.CloseBut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseBut.Name = "CloseBut";
            this.CloseBut.Size = new System.Drawing.Size(110, 35);
            this.CloseBut.TabIndex = 9;
            this.CloseBut.Text = "Закрыть";
            this.CloseBut.UseVisualStyleBackColor = true;
            this.CloseBut.Click += new System.EventHandler(this.CloseBut_Click);
            // 
            // HouseTextBox
            // 
            this.HouseTextBox.Location = new System.Drawing.Point(128, 82);
            this.HouseTextBox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.HouseTextBox.Name = "HouseTextBox";
            this.HouseTextBox.Size = new System.Drawing.Size(154, 26);
            this.HouseTextBox.TabIndex = 4;
            this.HouseTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FlatTextBox
            // 
            this.FlatTextBox.Location = new System.Drawing.Point(128, 133);
            this.FlatTextBox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.FlatTextBox.Name = "FlatTextBox";
            this.FlatTextBox.Size = new System.Drawing.Size(154, 26);
            this.FlatTextBox.TabIndex = 5;
            this.FlatTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SearchAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 479);
            this.Controls.Add(this.FlatTextBox);
            this.Controls.Add(this.HouseTextBox);
            this.Controls.Add(this.CloseBut);
            this.Controls.Add(this.ResultsTextBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ResultSearchLab);
            this.Controls.Add(this.StreetTextBox);
            this.Controls.Add(this.FlatLab);
            this.Controls.Add(this.HomeLab);
            this.Controls.Add(this.StreetLab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchAddressForm";
            this.Text = "Поиск по адресу";
            ((System.ComponentModel.ISupportInitialize)(this.HouseTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlatTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StreetLab;
        private System.Windows.Forms.Label HomeLab;
        private System.Windows.Forms.Label FlatLab;
        private System.Windows.Forms.TextBox StreetTextBox;
        private System.Windows.Forms.Label ResultSearchLab;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.Button CloseBut;
        private System.Windows.Forms.NumericUpDown HouseTextBox;
        private System.Windows.Forms.NumericUpDown FlatTextBox;
    }
}