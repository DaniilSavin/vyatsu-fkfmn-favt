using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentLibrary
{
    public partial class GameTimer: UserControl
    {
        DateTime date1 = new DateTime(0, 0);
        public GameTimer()
        {
            InitializeComponent();
        }
        public void Start()
        {
            date1 = new DateTime(0, 0);
            display.Text = "00:00:00";
            timer.Start();
        }
        public void Stop()
        {
            timer.Enabled = false;
            timer.Stop();
        }
        private void timer_Tick_1(object sender, EventArgs e)
        {

            date1 = date1.AddMilliseconds (1);
            display.Text = date1.ToString("mm:ss:ff");
        }
        public string Timeinfo()
        {
            return display.Text;
        }
    }
}
