using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static List<string> convertIPToBinaryIP(string ipAddress)
        {
            string[] ipArr = ipAddress.Split('.');
            int[] ipA = {1,1,1,1};
            for (int i=0; i<ipArr.Length; i++)
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
        private static string reverse(string str)
        {
            string res = "";
            for (int i=0; i<str.Length; i++)
            {
                if (str[i]=='0')
                {
                    res += '1';
                }
                else
                {
                    res += '0';
                }

            }
            return res;
        }

        private static Dictionary<string, uint> Fill(Dictionary<string, uint> dC)
        {
            dC.Add("128.0.0.0", 2147483648);
            dC.Add("192.0.0.0", 1073741824);
            dC.Add("224.0.0.0", 536870912);
            dC.Add("240.0.0.0", 268435456);

            dC.Add("248.0.0.0", 134217728);
            dC.Add("252.0.0.0", 67108864);
            dC.Add("254.0.0.0", 33554432);
            dC.Add("255.0.0.0", 16777216);

            dC.Add("255.128.0.0", 8388608);
            dC.Add("255.192.0.0", 4194304);
            dC.Add("255.224.0.0", 2097152);
            dC.Add("255.240.0.0", 1048576);

            dC.Add("255.248.0.0", 524288);
            dC.Add("255.252.0.0", 262144);
            dC.Add("255.254.0.0", 131072);
            dC.Add("255.255.0.0", 65536);

            dC.Add("255.255.128.0", 32768);
            dC.Add("255.255.192.0", 16384);
            dC.Add("255.255.224.0", 8192);
            dC.Add("255.255.240.0", 4096);

            dC.Add("255.255.248.0", 2048);
            dC.Add("255.255.252.0", 1024);
            dC.Add("255.255.254.0", 512);
            dC.Add("255.255.255.0", 256);

            dC.Add("255.255.255.128", 128);
            dC.Add("255.255.255.192", 64);
            dC.Add("255.255.255.224", 32);
            dC.Add("255.255.255.240", 16);

            dC.Add("255.255.255.248", 8);
            dC.Add("255.255.255.252", 4);
            dC.Add("255.255.255.254", 2);
            dC.Add("255.255.255.255", 1);

            return dC;
        }

        private void calcBt_Click(object sender, EventArgs e)
        {
             ipAdNetTb.Text = "";
            ipAdHostTb.Text = "";
             maxHtb.Text = "";
            macTb.Text = "";

            if (ipTb.Text != "" && maskTb.Text != "" )
            {
                ipAdNetTb.Text = "";
                ipAdHostTb.Text = "";
                maxHtb.Text = "";
                macTb.Text = "";

                Dictionary<string, uint> dC = new Dictionary<string, uint>();
                dC = Fill(dC);

                int[] ipAdres=new int [4];
                int[] maska = new int[4];

                string[] str = ipTb.Text.Split('.');
                string[] ipAd = new string[4];
                StringBuilder ip = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                {
                    try
                    {
                        ipAdres[i] = int.Parse(str[i]);
                        ip.Append(Convert.ToString(ipAdres[i], 2));
                    }
                    catch
                    {
                        ipAdNetTb.Enabled = false; ipAdNetTb.Text = "";
                        ipAdHostTb.Enabled = false; ipAdHostTb.Text = "";
                        maxHtb.Enabled = false; maxHtb.Text = "";
                        macTb.Enabled = false; macTb.Text = "";
                    }

                }

                Array.Clear(str, 0, str.Length);
                str = maskTb.Text.Split('.');

                for (int i = 0; i < str.Length; i++)
                {
                    try { maska[i] = int.Parse(str[i]); }
                    catch
                    {
                        ipAdNetTb.Enabled = false; ipAdNetTb.Text = "";
                        ipAdHostTb.Enabled = false; ipAdHostTb.Text = "";
                        maxHtb.Enabled = false; maxHtb.Text = "";
                        macTb.Enabled = false; macTb.Text = "";
                    }

                }
                int[] hostAd = new int[4];
                int[] hostAd2 = new int[4];
                //IP1
                int[] invMask = new int[4];
                List<string> maskaBin = convertIPToBinaryIP(maskTb.Text.ToString());
                for (int i=0; i< maskaBin.Count; i++)
                {
                    invMask[i] = int.Parse(Convert.ToInt32(reverse(maskaBin.ElementAt(i)), 2).ToString());
                }

                

                for (int i = 0; i < ipAdres.Length; i++)
                {
                    hostAd[i] = ipAdres[i] & maska[i];
                    ipAdNetTb.Text += hostAd[i].ToString();
                    hostAd2[i] =  invMask[i] & ipAdres[i];
                    
                    ipAdHostTb.Text += (hostAd2[i]).ToString();

                    if (i < ipAdres.Length - 1)
                    {
                        ipAdNetTb.Text += ".";
                        ipAdHostTb.Text += ".";
                    }
                }
                //

                //Broadcast
                List<string> sub = convertIPToBinaryIP(maskTb.Text);
                string[] subNet = new string[4];
                int[] sn =  new int[4];
                bool cancel = false;
                for (int i = 0; i < subNet.Length; i++)
                {
                    try
                    {
                        subNet[i] = reverse(sub.ElementAt(i));
                        sn[i] = int.Parse(Convert.ToInt32(subNet[i], 2).ToString());
                    }
                    catch {
                        ipAdNetTb.Enabled = false; ipAdNetTb.Text = "";
                        ipAdHostTb.Enabled = false; ipAdHostTb.Text = "";
                        maxHtb.Enabled = false; maxHtb.Text = "";
                        macTb.Enabled = false; macTb.Text = "";
                        cancel = true;
                    }

                }

                if (!cancel)
                {
                    int[] MAC = new int[4];
                    for (int i = 0; i < hostAd.Length; i++)
                    {
                        MAC[i] = hostAd[i] | sn[i];
                        macTb.Text += MAC[i].ToString();
                        if (i < ipAdres.Length - 1)
                        {
                            macTb.Text += ".";
                        }
                    }

                    //
                }

                //Max Hosts
                try
                {
                    uint hosts = dC[maskTb.Text];
                    maxHtb.Text = (hosts - 2).ToString();

                    ipAdNetTb.Enabled = true;
                    ipAdHostTb.Enabled = true;
                    maxHtb.Enabled = true;
                    macTb.Enabled = true;
                }
                catch { maxHtb.Text = "Неверная маска"; }
            }
        }

        private void ipTb_TextChanged(object sender, EventArgs e)
        {
            ipAdNetTb.Enabled = false; ipAdNetTb.Text = "";
            ipAdHostTb.Enabled = false; ipAdHostTb.Text = "";
            maxHtb.Enabled = false; maxHtb.Text = "";
            macTb.Enabled = false; macTb.Text = "";
        }

        private void maskTb_TextChanged(object sender, EventArgs e)
        {
            ipAdNetTb.Enabled = false; ipAdNetTb.Text = "";
            ipAdHostTb.Enabled = false; ipAdHostTb.Text = "";
            maxHtb.Enabled = false; maxHtb.Text = "";
            macTb.Enabled = false; macTb.Text = "";
        }
    }
}