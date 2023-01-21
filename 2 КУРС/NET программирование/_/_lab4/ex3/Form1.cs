using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex3
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        DateTime Seconds;
        
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StopButton.Enabled = true;
            StartButton.Enabled = false;
            Seconds = new DateTime();
            timer1.Enabled = true;
            TimeLabel.Text = Seconds.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Seconds=Seconds.AddSeconds(1); 
            TimeLabel.Text = Seconds.ToLongTimeString();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = true;
            StopButton.Enabled = false;
            timer1.Enabled = false;
        }

        private void TimeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
