using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private static List<string> convertIPToBinaryIP(string ipAddress)
        {

            string[] ipArr = ipAddress.Split('.');
            int[] ipA = { 1, 1, 1, 1 };
            for (int i = 0; i < ipArr.Length; i++)
            {
                try { ipA[i] = int.Parse(ipArr[i]); } catch { }

            }
            List<string> binaryIP = new List<string>();

            for (var i = 0; i < ipArr.Length; i++)
            {
                var binaryNo = Convert.ToString(ipA[i], 2);
                if (binaryNo.Length == 8)
                {
                    binaryIP.Add(binaryNo);
                    // binaryIP.push(binaryNo);
                }
                else
                {
                    var diffNo = 8 - binaryNo.Length;
                    var createBinary = "";
                    for (var j = 0; j < diffNo; j++)
                    {
                        createBinary += '0';
                    }
                    createBinary += binaryNo;
                    binaryIP.Add(createBinary);
                }
            }
            return binaryIP;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            subnetTb.Text = "";
            subnetTb.Enabled = false;
            if (ipAd1Tb.Text != "" && ipAd2Tb.Text != "")
            {
                try
                {
                    subnetTb.Enabled = false;
                    List<int> SubNet = new List<int>();
                    List<string> ip1 = new List<string>();
                    List<string> ip2 = new List<string>();
                    string subNet = "";

                    ip1 = convertIPToBinaryIP(ipAd1Tb.Text);
                    ip2 = convertIPToBinaryIP(ipAd2Tb.Text);

                    string ipAd1 = ""; string ipAd2 = "";
                    for (int i=0; i<ip1.Count; i++)
                    {
                        ipAd1 += ip1.ElementAt(i);
                        ipAd2 += ip2.ElementAt(i);
                        if (i<ip1.Count-1)
                        {
                            ipAd1 += "."; ipAd2 += ".";
                        }
                    }
                    bool flag = true;
                    for (int i=0; i< ipAd1.Length; i++)
                    {
                        if (ipAd1[i] == ipAd2[i] && ipAd1[i]!='.' && flag)
                        {
                            subNet += "1";
                            if (i == ipAd1.Length - 1)
                            {
                                SubNet.Add(Convert.ToInt32(subNet, 2));
                                subNet = "";
                            }
                        }
                        else
                        {
                            if (ipAd1[i]=='.' || i == ipAd1.Length-1)
                            {
                                
                                SubNet.Add(Convert.ToInt32(subNet, 2));
                                subNet = "";
                            }
                            else
                            {
                                subNet += "0";
                                flag = false;
                            }
                        }
                    }
                    if (SubNet[0] < 128)
                    {
                        SubNet[0] = 0;
                        SubNet[1] = 0;
                        SubNet[2] = 0;
                        SubNet[3] = 0;
                    }

                    for (int i=0; i<SubNet.Count; i++)
                    {
                        subnetTb.Text += SubNet.ElementAt(i).ToString();
                        if (i< SubNet.Count-1)
                        {
                            subnetTb.Text += "."; 
                        }
                        subnetTb.Enabled = true;
                    }
                    

                }
                catch { 
                    subnetTb.Text = "";
                    subnetTb.Enabled = false;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            subnetTb.Text = "";
            subnetTb.Enabled = false;
        }

        private void ipAd1Tb_TextChanged(object sender, EventArgs e)
        {
            subnetTb.Text = "";
            subnetTb.Enabled = false;
        }
    }
}