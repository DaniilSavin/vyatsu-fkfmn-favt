namespace WindowsFormsApp1
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
            this.Field = new System.Windows.Forms.Panel();
            this.Group = new System.Windows.Forms.Panel();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.RunBtn = new System.Windows.Forms.Button();
            this.NewBtn = new System.Windows.Forms.Button();
            this.StepBtn = new System.Windows.Forms.Button();
            this.LeftBtn = new System.Windows.Forms.Button();
            this.DownBtn = new System.Windows.Forms.Button();
            this.RightBtn = new System.Windows.Forms.Button();
            this.UpBtn = new System.Windows.Forms.Button();
            this.Algorithm = new System.Windows.Forms.ListBox();
            this.timerAlgorithm = new System.Windows.Forms.Timer(this.components);
            this.del = new System.Windows.Forms.Button();
            this.changePerson = new System.Windows.Forms.Button();
            this.Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // Field
            // 
            this.Field.AllowDrop = true;
            this.Field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Field.Location = new System.Drawing.Point(12, 12);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(393, 426);
            this.Field.TabIndex = 0;
            this.Field.DragDrop += new System.Windows.Forms.DragEventHandler(this.Field_DragDrop);
            this.Field.DragEnter += new System.Windows.Forms.DragEventHandler(this.Field_DragEnter);
            // 
            // Group
            // 
            this.Group.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Group.Controls.Add(this.changePerson);
            this.Group.Controls.Add(this.del);
            this.Group.Controls.Add(this.ClearBtn);
            this.Group.Controls.Add(this.RunBtn);
            this.Group.Controls.Add(this.NewBtn);
            this.Group.Controls.Add(this.StepBtn);
            this.Group.Controls.Add(this.LeftBtn);
            this.Group.Controls.Add(this.DownBtn);
            this.Group.Controls.Add(this.RightBtn);
            this.Group.Controls.Add(this.UpBtn);
            this.Group.Location = new System.Drawing.Point(411, 12);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(186, 426);
            this.Group.TabIndex = 1;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(4, 339);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(179, 23);
            this.ClearBtn.TabIndex = 7;
            this.ClearBtn.Text = "ClearBtn";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(4, 312);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(179, 23);
            this.RunBtn.TabIndex = 6;
            this.RunBtn.Text = "RunBtn";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // NewBtn
            // 
            this.NewBtn.Location = new System.Drawing.Point(4, 285);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(179, 23);
            this.NewBtn.TabIndex = 5;
            this.NewBtn.Text = "NewBtn";
            this.NewBtn.UseVisualStyleBackColor = true;
            this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // StepBtn
            // 
            this.StepBtn.Location = new System.Drawing.Point(4, 112);
            this.StepBtn.Name = "StepBtn";
            this.StepBtn.Size = new System.Drawing.Size(179, 23);
            this.StepBtn.TabIndex = 4;
            this.StepBtn.Text = "Step";
            this.StepBtn.UseVisualStyleBackColor = true;
            this.StepBtn.Click += new System.EventHandler(this.StepBtn_Click);
            // 
            // LeftBtn
            // 
            this.LeftBtn.Location = new System.Drawing.Point(4, 85);
            this.LeftBtn.Name = "LeftBtn";
            this.LeftBtn.Size = new System.Drawing.Size(179, 23);
            this.LeftBtn.TabIndex = 3;
            this.LeftBtn.Text = "LeftBtn";
            this.LeftBtn.UseVisualStyleBackColor = true;
            this.LeftBtn.Click += new System.EventHandler(this.LeftBtn_Click);
            // 
            // DownBtn
            // 
            this.DownBtn.Location = new System.Drawing.Point(4, 58);
            this.DownBtn.Name = "DownBtn";
            this.DownBtn.Size = new System.Drawing.Size(179, 23);
            this.DownBtn.TabIndex = 2;
            this.DownBtn.Text = "DownBtn";
            this.DownBtn.UseVisualStyleBackColor = true;
            this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
            // 
            // RightBtn
            // 
            this.RightBtn.Location = new System.Drawing.Point(4, 31);
            this.RightBtn.Name = "RightBtn";
            this.RightBtn.Size = new System.Drawing.Size(179, 23);
            this.RightBtn.TabIndex = 1;
            this.RightBtn.Text = "RightBtn";
            this.RightBtn.UseVisualStyleBackColor = true;
            this.RightBtn.Click += new System.EventHandler(this.RightBtn_Click);
            // 
            // UpBtn
            // 
            this.UpBtn.Location = new System.Drawing.Point(4, 4);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(179, 23);
            this.UpBtn.TabIndex = 0;
            this.UpBtn.Text = "UpBtn";
            this.UpBtn.UseVisualStyleBackColor = true;
            this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // Algorithm
            // 
            this.Algorithm.FormattingEnabled = true;
            this.Algorithm.Location = new System.Drawing.Point(603, 12);
            this.Algorithm.Name = "Algorithm";
            this.Algorithm.Size = new System.Drawing.Size(144, 420);
            this.Algorithm.TabIndex = 2;
            // 
            // timerAlgorithm
            // 
            this.timerAlgorithm.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // del
            // 
            this.del.Location = new System.Drawing.Point(4, 366);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(179, 23);
            this.del.TabIndex = 8;
            this.del.Text = "Delete";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.button1_Click);
            // 
            // changePerson
            // 
            this.changePerson.Location = new System.Drawing.Point(4, 394);
            this.changePerson.Name = "changePerson";
            this.changePerson.Size = new System.Drawing.Size(179, 23);
            this.changePerson.TabIndex = 9;
            this.changePerson.Text = "ChangePerson";
            this.changePerson.UseVisualStyleBackColor = true;
            this.changePerson.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.Algorithm);
            this.Controls.Add(this.Group);
            this.Controls.Add(this.Field);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Group.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Field;
        private System.Windows.Forms.Panel Group;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Button NewBtn;
        private System.Windows.Forms.Button StepBtn;
        private System.Windows.Forms.Button LeftBtn;
        private System.Windows.Forms.Button DownBtn;
        private System.Windows.Forms.Button RightBtn;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.ListBox Algorithm;
        private System.Windows.Forms.Timer timerAlgorithm;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Button changePerson;
    }
}

