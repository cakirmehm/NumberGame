using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sayı_Oyunu_2014
{
    public partial class F_Splash : Form
    {


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static F_Splash getInsance()
        {
            if (fsplash == null)
                fsplash = new F_Splash();
            return fsplash;
        }



        /// <summary>
        /// 
        /// </summary>
        public F_Splash()
        {
            InitializeComponent();
            vfnKolayOrtaZorPanelAyarla();
        }


        /// <summary>
        /// 
        /// </summary>
        private void vfnKolayOrtaZorPanelAyarla()
        {
            foreach (Control cnt in pnlKolayOrtaZor.Controls)
            {
                if (cnt is Button)
                {
                    Button btn = cnt as Button;
                    btn.Click += new EventHandler(btn_Click);
                }
            }

            btn_Click(button1, new EventArgs());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_Click(object sender, EventArgs e)
        {
            foreach (Control cnt in pnlKolayOrtaZor.Controls)
            {
                if (cnt is Button)
                {
                    Button btn = cnt as Button;
                    btn.BackColor = Color.RosyBrown;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font(btn.Font, FontStyle.Regular);
                }
            }


            Button btnSender = sender as Button;
            btnSender.BackColor = Color.MistyRose;
            btnSender.ForeColor = Color.Brown;
            btnSender.Font = new Font(btnSender.Font, FontStyle.Bold);

            // Kolay
            if (btnSender.Name == "button1")
            {
                F_Main.getInstance().setZorlukDerecesi(F_Main.Zorluk.KOLAY);
            }
                // Orta 
            else if (btnSender.Name == "button2")
            {
                F_Main.getInstance().setZorlukDerecesi(F_Main.Zorluk.ORTA);
            }
                // Zor
            else if (btnSender.Name == "button3")
            {
                F_Main.getInstance().setZorlukDerecesi(F_Main.Zorluk.ZOR);
            }

        }

        private void btnTekKisilik_MouseMove(object sender, MouseEventArgs e)
        {
            Button btnSender = sender as Button;
            btnSender.BackColor = Color.MistyRose;
            btnSender.ForeColor = Color.Brown;

            if (btnSender.Name.Contains("Bilgisayar"))
            {
                pnlKolayOrtaZor.Visible = true;
            }
            else
            {
                pnlKolayOrtaZor.Visible = false;
            }
        }

        private void btnTekKisilik_MouseLeave(object sender, EventArgs e)
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
        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHakkinda_Click(object sender, EventArgs e)
        {
            this.Width = 740;
            label1.Text = "About";
            string text = "Number Game ©"  + "\n\n";
            text += "v. 1.0" + "\n";
            text += "Mehmet Cakir";
            rtxtSplash.Text = text;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNasilOynanir_Click(object sender, EventArgs e)
        {
            this.Width = 740;
            StringBuilder sb = new StringBuilder();

            label1.Text = "How to play?";
            sb.AppendLine("Moves:");
            sb.AppendLine(">>> 3 step North");
            sb.AppendLine(">>> 3 step South");
            sb.AppendLine(">>> 3 step East");
            sb.AppendLine(">>> 3 step West");
            sb.AppendLine(">> 2 step NW");
            sb.AppendLine(">> 2 step SW");
            sb.AppendLine(">> 2 step NE");
            sb.AppendLine(">> 2 step SE");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Target: Get the maximum score with the maximum number tour.");


            rtxtSplash.Text = sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTekKisilik_Click(object sender, EventArgs e)
        {
            F_Main.getInstance().setOyunModu(F_Main.OyunModu.SINGLE_PLAYER);
            F_Main.getInstance().Show();
            this.Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKarsilikli_Click(object sender, EventArgs e)
        {
            F_Main.getInstance().setOyunModu(F_Main.OyunModu.MULTI_PLAYER);
            F_Main.getInstance().Show();
            
            this.Hide();
        }


        /// <summary>
        /// Bilgisayara karşı oyna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBilgisayaraKarsi_Click(object sender, EventArgs e)
        {
            F_Main.getInstance().setOyunModu(F_Main.OyunModu.CPU);
            F_Main.getInstance().Show();
            this.Hide();
        }

       
        
    }
}