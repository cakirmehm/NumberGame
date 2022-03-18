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
    public partial class F_Initiate : Form
    {

        private static F_Initiate fOyunAc;
        IPAddress ipAdrr;
        private Thread thr;
        TcpListener dinle;
        NetworkStream ag;
        StreamReader oku;
        StreamWriter yaz, tahtaYaz;
        Socket socket;
        public delegate void ricdegis(string text);

        List<Point> lstKullanilanNoktalar = new List<Point>();

        private string pattern = "";
        private static int hamleSayaci = 0;


        /// <summary>
        /// 
        /// </summary>
        public void vfnOkumayaBasla()
        {
            socket = dinle.AcceptSocket();
            ag = new NetworkStream(socket);
            oku = new StreamReader(ag);

            while (true)
            {
                try
                {
                    string yazi = pattern = oku.ReadLine();
                    vfnBilgiGirisi(yazi);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Client ile bağlantı koptu, oyun sonlandı.", "OYUN BİTTİ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }

            
        }

        /// <summary>
        /// Kendi IP adresini döndürür
        /// </summary>
        /// <returns></returns>
        public string getLocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
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
            }
            else
            {
                rtxtBaglantiBilgi.AppendText("\nClient: " + pYazi);
                vfnUpdate();
            }
                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static F_Initiate getInstance()
        {
            if (fOyunAc == null)
                fOyunAc = new F_Initiate();
            return fOyunAc;
        }

        /// <summary>
        /// 
        /// </summary>
        public F_Initiate()
        {
            InitializeComponent();
            fOyunAc = this;
        }

        private void btnOyunAc_MouseMove(object sender, MouseEventArgs e)
        {
            Button btnSender = sender as Button;
            btnSender.BackColor = Color.PapayaWhip;
            btnSender.ForeColor = Color.Red;
        }

        private void btnOyunAc_MouseLeave(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            btnSender.BackColor = Color.RosyBrown;
            btnSender.ForeColor = Color.White;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOyunAc_Click(object sender, EventArgs e)
        {
            
            vfnDinlemeyeBasla();
           
        }


        /// <summary>
        /// 
        /// </summary>
        private void vfnDinlemeyeBasla()
        {
            try
            {

                if (dinle == null)
                {
                    F_Main.getInstance().setCalismaModu(F_Main.CalismaModu.SERVER);

                    ipAdrr = IPAddress.Parse(getLocalIPAddress()); //IPAddress.Parse("127.0.0.1");
                    dinle = new TcpListener(ipAdrr, 7777);
                    dinle.Start();

                    thr = new Thread(new ThreadStart(vfnOkumayaBasla));
                    thr.Start();

                    
                    vfnBilgiGirisi("Dinleme başlatıldı...");
                    this.WindowState = FormWindowState.Minimized;
                    btnGonder.Enabled = true;
                }
                else
                {
                    vfnBilgiGirisi("Zaten dinliyorsun.");
                }
            }
            catch (Exception ex)
            {
                vfnBilgiGirisi("Dinleme başlatılamadı! " + ex.StackTrace.ToString());
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

            vfnSendMessage(txtMesajGonder.Text);
            rtxtBaglantiBilgi.AppendText("\nServer: " + txtMesajGonder.Text);
            txtMesajGonder.Text = "";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public void vfnSendMessage(string pMsg)
        {
            if (ag != null)
            {
                yaz = new StreamWriter(ag);
                yaz.WriteLine(pMsg);
                yaz.Flush();
            }
        }


        /// <summary>
        /// Her hamle sonrası Client'a tahtadaki veriler yollanır
        /// </summary>
        /// <param name="lstKonulanNoktalar"></param>
        public void vfnSend(Point konulanNokta, int num, int puan)
        {

            // ilk hamlede ekstradan asal bonus noktası ve tamkare bonus noktasını da yolla
            if (hamleSayaci == 0)
            {
                Point ptAsal = F_Main.getInstance().ptFnGetAsalBonusNokta();
                Point ptTamkare = F_Main.getInstance().ptFnGetTamkareBonusNokta();

                StringBuilder sb = new StringBuilder();
                sb.Append(konulanNokta.X + "-" + konulanNokta.Y + "-" + num + "-" + puan + "-" + ptAsal.X + "-" + ptAsal.Y + "-" + ptTamkare.X + "-" + ptTamkare.Y);

                try
                {
                    tahtaYaz = new StreamWriter(ag);
                    tahtaYaz.WriteLine(sb.ToString());
                    tahtaYaz.Flush();
                }
                catch
                {
                    F_Main.getInstance().setCalismaModu(F_Main.CalismaModu.CLIENT);
                    return;
                }

            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(konulanNokta.X + "-" + konulanNokta.Y + "-" + num + "-" + puan);


                try
                {
                    tahtaYaz = new StreamWriter(ag);
                    tahtaYaz.WriteLine(sb.ToString());
                    tahtaYaz.Flush();
                }
                catch
                {
                    F_Main.getInstance().setCalismaModu(F_Main.CalismaModu.CLIENT);
                    return;
                }
            }

            hamleSayaci++;
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

                    Point pt = new Point(int.Parse(splitted[0]), int.Parse(splitted[1]));
                    int num = int.Parse(splitted[2]);
                    int puan = int.Parse(splitted[3]);
                    F_Main.getInstance().vfnUpdateDgv(pt, num, puan);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void CloseConnection()
        {
            if (socket != null)
            {
                socket.Close();
            }

            if (dinle != null)
            {
                dinle.Stop();
            }

            if (thr != null)
            {
                thr.Abort();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_OyunAc_Resize(object sender, EventArgs e)
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
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        public void vfnBaglantiAc()
        {
            this.Show();
            vfnDinlemeyeBasla();
            
        }

        private void F_OyunAc_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

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