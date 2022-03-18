using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace Sayı_Oyunu_2014
{
    public partial class F_Connect : Form
    {

        private static F_Connect fBaglan;
        private static F_Main fForm1;

        Thread thr;
        TcpClient baglantiKur;
        NetworkStream ag;
        StreamReader oku;
        StreamWriter yaz, tahtaYaz;
        public delegate void ricdegis(string text);

        private string pattern = "";
        List<Point> lstKullanilanNoktalar = new List<Point>();
        private Point ptAsalBonus = new Point();
        private Point ptTamkareBonus = new Point();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static F_Connect getInstance()
        {
            if (fBaglan == null)
                fBaglan = new F_Connect();
            return fBaglan;
        }

        /// <summary>
        /// 
        /// </summary>
        public F_Connect()
        {
            InitializeComponent();
            fBaglan = this;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOyunAc_MouseMove(object sender, MouseEventArgs e)
        {
            Button btnSender = sender as Button;
            btnSender.BackColor = Color.PapayaWhip;
            btnSender.ForeColor = Color.Red;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOyunAc_MouseLeave(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            btnSender.BackColor = Color.RosyBrown;
            btnSender.ForeColor = Color.White;
        }

        /// <summary>
        /// 
        /// </summary>
        public void vfnOkumayaBasla()
        {
            ag = baglantiKur.GetStream();
            oku = new StreamReader(ag);

            while (true)
            {
                try
                {
                    string yazi = pattern = oku.ReadLine();
                    vfnBilgiGirisi(yazi);
                    vfnUpdate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Server ile bağlantı koptu, oyun sonlandı.", "OYUN BİTTİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Form1.getInstance().setAciklama("Bağlantı koptu, oyun sonlandı.");
                    return;
                }
            }

           
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="yazi"></param>
        private void vfnBilgiGirisi(string pYazi)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ricdegis(vfnBilgiGirisi), pYazi);
                return;
            }

            rtxtBaglantiBilgi.AppendText("\nServer: " + pYazi);

           
        }


        /// <summary>
        /// 
        /// </summary>
        public void vfnBaglantiKur()
        {
            try
            {
                if (baglantiKur == null)
                {
                    fForm1 = F_Main.getInstance();
                    fForm1.setCalismaModu(F_Main.CalismaModu.CLIENT);
                    IPAddress ipAddr = IPAddress.Parse(comboBox1.Text);
                    
                    baglantiKur = new TcpClient(ipAddr.ToString(), 7777);
                    thr = new Thread(new ThreadStart(vfnOkumayaBasla));
                    thr.Start();
                    vfnBilgiGirisi(ipAddr + " ile bağlantı kuruldu.");
                    F_Main.getInstance().vfnSiraRakipte();
                    this.WindowState = FormWindowState.Minimized;
                    btnGonder.Enabled = true;
                   

                }
                else
                {
                    vfnBilgiGirisi("Zaten bağlısınız.");
 
                }
            }
            catch (Exception ex)
            {

                vfnBilgiGirisi("Server ile bağlantı kurulurken sıkıntılar oluştu: \n" + ex.StackTrace.ToString());
                return;
            }

            
        }

 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBaglan_Click(object sender, EventArgs e)
        {
            IPAddress ipAdress;
            if (IPAddress.TryParse(comboBox1.Text, out ipAdress))
            {
                // IP adresi doğru
                vfnBaglantiKur();
                StreamWriter sw = new StreamWriter("ip.txt",true);
                sw.WriteLine(ipAdress.ToString());
                sw.Close();
            }
            else
            {
                // IP hatalı
                MessageBox.Show("IP formatı yanlış");
 
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGonder_Click(object sender, EventArgs e)
        {

            string[] splitted = txtMesajGonder.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            if (splitted.Length >= 4)
            {
                MessageBox.Show("Hile yasak beyler.");
                return;
            }

            vfnServeraGonder(txtMesajGonder.Text);
            //vfnSend(lstKullanilanNoktalar);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void vfnServeraGonder(string pTxt)
        {
        
            vfnSendMessage(pTxt);
            rtxtBaglantiBilgi.AppendText("\nClient: " + pTxt);
            txtMesajGonder.Text = "";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTxt"></param>
        public void vfnSendMessage(string pTxt)
        {
            if (ag != null)
            {
                yaz = new StreamWriter(ag);
                yaz.WriteLine(pTxt);
                yaz.Flush();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            //vfnUpdate();
        }




       

        public void CloseConnection()
        {
            if (baglantiKur != null)
                baglantiKur.Close();
        }

        public void vfnSend(Point konulanNokta, int num, int rakipPuan)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(konulanNokta.X + "-" + konulanNokta.Y + "-" + num + "-" + rakipPuan);


            try
            {
                tahtaYaz = new StreamWriter(ag);
                tahtaYaz.WriteLine(sb.ToString());
                tahtaYaz.Flush();
            }
            catch
            {
                //MessageBox.Show("F_OyunAc::send() -- Bağlantı yok");
                F_Main.getInstance().setCalismaModu(F_Main.CalismaModu.CLIENT);
                return;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void vfnUpdate()
        {
            if (pattern.Contains("avidx:"))
            {
                string[] splitted = pattern.Split(new string[] { "avidx:" }, StringSplitOptions.RemoveEmptyEntries);
                int rakipAvatarIndex = 0;

                try
                {
                    rakipAvatarIndex = int.Parse(splitted[0]);
                    F_Main.getInstance().vfnUpdateAvatar(rakipAvatarIndex);
                }
                catch
                {
                    rakipAvatarIndex = 0;
                }
            }
            else
            {


                string[] splitted = pattern.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                if (splitted.Length == 4)
                {

                    int num = int.Parse(splitted[2]);
                    int rakipPuan = int.Parse(splitted[3]);

                    Point pt = new Point(int.Parse(splitted[0]), int.Parse(splitted[1]));
                    F_Main.getInstance().vfnUpdateDgv(pt, num, rakipPuan);

                }
                // ilk seferde asal ve tamkare bonus noktaları da gönderildi çünkü
                else if (splitted.Length == 8)
                {
                    int num = int.Parse(splitted[2]);
                    int rakipPuan = int.Parse(splitted[3]);
                    Point pt = new Point(int.Parse(splitted[0]), int.Parse(splitted[1]));
                    Point asalPoint = new Point(int.Parse(splitted[4]), int.Parse(splitted[5]));
                    Point tamkarePoint = new Point(int.Parse(splitted[6]), int.Parse(splitted[7]));

                    F_Main.getInstance().vfnUpdateDgv(pt, num, rakipPuan);
                    F_Main.getInstance().vfnAsalBonusYerlestir(asalPoint);
                    F_Main.getInstance().vfnTamkareBonusYerlestir(tamkarePoint);


                }


            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void F_Baglan_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_Baglan_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("ip.txt");
            if (null != sr)
            {

                foreach (string line in sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (false == comboBox1.Items.Contains(line))
                        comboBox1.Items.Add(line);
                }

                sr.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_Baglan_FormClosing(object sender, FormClosingEventArgs e)
        {

            notifyIcon1.Visible = false;
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMesajGonder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnGonder_Click(sender, e);
            }
        }

        private void rtxtBaglantiBilgi_TextChanged(object sender, EventArgs e)
        {
            rtxtBaglantiBilgi.ScrollToCaret();
        }



        
    }
}