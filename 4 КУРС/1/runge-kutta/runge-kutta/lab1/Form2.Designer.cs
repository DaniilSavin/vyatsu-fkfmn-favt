
namespace lab1
{
	partial class Form2
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
			this.zedGraph = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zedGraph
			// 
			this.zedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedGraph.Location = new System.Drawing.Point(0, 0);
			this.zedGraph.Name = "zedGraph";
			this.zedGraph.ScrollGrace = 0;
			this.zedGraph.ScrollMaxX = 0;
			this.zedGraph.ScrollMaxY = 0;
			this.zedGraph.ScrollMaxY2 = 0;
			this.zedGraph.ScrollMinX = 0;
			this.zedGraph.ScrollMinY = 0;
			this.zedGraph.ScrollMinY2 = 0;
			this.zedGraph.Size = new System.Drawing.Size(592, 471);
			this.zedGraph.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 471);
			this.Controls.Add(this.zedGraph);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.ResumeLayout(false);

		}

		#endregion

		private ZedGraph.ZedGraphControl zedGraph;
	}
}