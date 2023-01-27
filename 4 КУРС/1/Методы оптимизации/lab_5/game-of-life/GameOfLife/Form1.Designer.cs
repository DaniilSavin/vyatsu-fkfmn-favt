namespace GameOfLife
{
    partial class Form1
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
<<<<<<< HEAD
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RunCheckbox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DelayNud = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNud)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(876, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            // 
            // RunCheckbox
            // 
            this.RunCheckbox.AutoSize = true;
            this.RunCheckbox.Checked = true;
            this.RunCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RunCheckbox.Location = new System.Drawing.Point(209, 8);
            this.RunCheckbox.Name = "RunCheckbox";
            this.RunCheckbox.Size = new System.Drawing.Size(75, 17);
            this.RunCheckbox.TabIndex = 6;
            this.RunCheckbox.Text = "Start/Stop";
            this.RunCheckbox.UseVisualStyleBackColor = true;
            this.RunCheckbox.CheckedChanged += new System.EventHandler(this.RunCheckbox_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Delay (ms):";
            // 
            // DelayNud
            // 
            this.DelayNud.Location = new System.Drawing.Point(74, 7);
            this.DelayNud.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.DelayNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DelayNud.Name = "DelayNud";
            this.DelayNud.Size = new System.Drawing.Size(53, 20);
            this.DelayNud.TabIndex = 9;
            this.DelayNud.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DelayNud.ValueChanged += new System.EventHandler(this.DelayNud_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 15;
            this.button1.Text = "1-1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 16;
            this.button2.Text = "1-2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(371, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 20);
            this.button3.TabIndex = 17;
            this.button3.Text = "1-3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 18;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(452, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 20);
            this.button4.TabIndex = 19;
            this.button4.Text = "1-4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(533, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 20);
            this.button5.TabIndex = 20;
            this.button5.Text = "1-5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(614, 42);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 20);
            this.button6.TabIndex = 21;
            this.button6.Text = "2-1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(695, 42);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 20);
            this.button7.TabIndex = 22;
            this.button7.Text = "2-2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(776, 42);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 20);
            this.button8.TabIndex = 23;
            this.button8.Text = "2-3";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 592);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DelayNud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RunCheckbox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game of Life - C# Data Visualization";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

=======
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RunCheckbox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DelayNud = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNud)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(876, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            // 
            // RunCheckbox
            // 
            this.RunCheckbox.AutoSize = true;
            this.RunCheckbox.Checked = true;
            this.RunCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RunCheckbox.Location = new System.Drawing.Point(209, 8);
            this.RunCheckbox.Name = "RunCheckbox";
            this.RunCheckbox.Size = new System.Drawing.Size(75, 17);
            this.RunCheckbox.TabIndex = 6;
            this.RunCheckbox.Text = "Start/Stop";
            this.RunCheckbox.UseVisualStyleBackColor = true;
            this.RunCheckbox.CheckedChanged += new System.EventHandler(this.RunCheckbox_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Delay (ms):";
            // 
            // DelayNud
            // 
            this.DelayNud.Location = new System.Drawing.Point(74, 7);
            this.DelayNud.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.DelayNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DelayNud.Name = "DelayNud";
            this.DelayNud.Size = new System.Drawing.Size(53, 20);
            this.DelayNud.TabIndex = 9;
            this.DelayNud.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DelayNud.ValueChanged += new System.EventHandler(this.DelayNud_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 15;
            this.button1.Text = "1-1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 16;
            this.button2.Text = "1-2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(371, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 20);
            this.button3.TabIndex = 17;
            this.button3.Text = "1-3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 18;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(452, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 20);
            this.button4.TabIndex = 19;
            this.button4.Text = "1-4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(533, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 20);
            this.button5.TabIndex = 20;
            this.button5.Text = "1-5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(614, 42);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 20);
            this.button6.TabIndex = 21;
            this.button6.Text = "2-1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(695, 42);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 20);
            this.button7.TabIndex = 22;
            this.button7.Text = "2-2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(776, 42);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 20);
            this.button8.TabIndex = 23;
            this.button8.Text = "2-3";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 592);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DelayNud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RunCheckbox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game of Life - C# Data Visualization";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox RunCheckbox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown DelayNud;
<<<<<<< HEAD
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
=======
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
    }
}

