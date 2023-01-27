using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ip1Tb.Text!="" && ip2Tb.Text != "" && subnetTb.Text!="")
            {
                try
                {
                    int[] ipAdres1 = new int[4];
                    int[] ipAdres2 = new int[4];
                    int[] maska = new int[4];

                    string[] str = ip1Tb.Text.Split('.');
                    string[] ipAd = new string[4];

                    StringBuilder ip = new StringBuilder();
                    for (int i = 0; i < str.Length; i++)
                    {
                        ipAdres1[i] = int.Parse(str[i]);
                        //ip.Append(Convert.ToString(ipAdres1[i], 2));
                    }
                    Array.Clear(str, 0, str.Length);

                    str = ip2Tb.Text.Split('.');
                    for (int i = 0; i < str.Length; i++)
                    {
                        ipAdres2[i] = int.Parse(str[i]);
                        //ip.Append(Convert.ToString(ipAdres1[i], 2));
                    }
                    Array.Clear(str, 0, str.Length);

                    str = subnetTb.Text.Split('.');
                    for (int i = 0; i < str.Length; i++)
                    {
                        maska[i] = int.Parse(str[i]);
                    }

                    int[] Tmpip1 = new int[4];
                    int[] Tmpip2 = new int[4];
                    bool a = true;
                    for (int i = 0; i < ipAdres1.Length; i++)
                    {
                        Tmpip1[i] = ipAdres1[i] & maska[i];
                        Tmpip2[i] = ipAdres2[i] & maska[i];
                        if (Tmpip1[i] != Tmpip2[i])
                        {
                            a = false;
                        }
                    }
                    if (a)
                    {
                        ansLb.Text = "Принадлежат одной подсети.";
                    }
                    else
                    {
                        ansLb.Text = "Не принадлежат одной подсети.";
                    }
                }
                catch { ansLb.Text = "Ошибка."; }
            }
        }

        private void ip1Tb_TextChanged(object sender, EventArgs e)
        {
            ansLb.Text = "";
        }

        private void ip2Tb_TextChanged(object sender, EventArgs e)
        {
            ansLb.Text = "";
        }

        private void subnetTb_TextChanged(object sender, EventArgs e)
        {
            ansLb.Text = "";
        }
    }
}