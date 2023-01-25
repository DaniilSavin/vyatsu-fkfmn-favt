namespace WindowsFormsApp3
{
    partial class NewSize
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
        this.tipLabel = new System.Windows.Forms.Label();
        this.sizeUpDown = new System.Windows.Forms.NumericUpDown();
        this.confirmButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).BeginInit();
        this.SuspendLayout();
        // 
        // tipLabel
        // 
        this.tipLabel.AutoSize = true;
        this.tipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.tipLabel.Location = new System.Drawing.Point(13, 13);
        this.tipLabel.Name = "tipLabel";
        this.tipLabel.Size = new System.Drawing.Size(273, 29);
        this.tipLabel.TabIndex = 0;
        this.tipLabel.Text = "Введите размер поля:";
        // 
        // sizeUpDown
        // 
        this.sizeUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.sizeUpDown.Location = new System.Drawing.Point(293, 11);
        this.sizeUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
        this.sizeUpDown.Name = "sizeUpDown";
        this.sizeUpDown.Size = new System.Drawing.Size(138, 35);
        this.sizeUpDown.TabIndex = 1;
        this.sizeUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
        // 
        // confirmButton
        // 
        this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.confirmButton.Location = new System.Drawing.Point(173, 69);
        this.confirmButton.Name = "confirmButton";
        this.confirmButton.Size = new System.Drawing.Size(95, 45);
        this.confirmButton.TabIndex = 2;
        this.confirmButton.Text = "ОК";
        this.confirmButton.UseVisualStyleBackColor = true;
        // 
        // ChangeSizeForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(443, 126);
        this.Controls.Add(this.confirmButton);
        this.Controls.Add(this.sizeUpDown);
        this.Controls.Add(this.tipLabel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ChangeSizeForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Размер поля";
        ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label tipLabel;
    private System.Windows.Forms.NumericUpDown sizeUpDown;
    private System.Windows.Forms.Button confirmButton;
}
}