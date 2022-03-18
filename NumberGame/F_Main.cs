using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sayı_Oyunu_2014
{
    public partial class F_Main : Form
    {
        
        public static F_Main getInstance()
        {
            if (frm1 == null)
                frm1 = new F_Main();
            return frm1;
        }

        private static int  Puan = 0, blgPuan = 0;
        private static int  Numara = 1;
        private const int   SIZE = 15;
        private int         ptCounter = 2;
  
        private List<Point> lstBosNoktalar = new List<Point>();
        private List<Point> lstKonulanNoktalar = new List<Point>();
        private List<Point> lstGidilecekNoktalar = new List<Point>();
        private Point ptEnSonKonulanNokta = new Point(7,7);
        private Point ptAsalBonusNokta = new Point();
        private Point ptTamkareBonusNokta = new Point();

        private int avatar1Index = 0, avatar2Index = 1;

        public delegate void dlgAciklama(string pTxt);


        //private static bool blnArtiBirHamleServer = false, blnArtiBirHamleClient = false;
        // LigthGreen
        // LightSalmon
        private Color clrGidilecekYerlerinRengi = Color.LightGreen;

        public enum OyunModu
        {
            SINGLE_PLAYER = 0,
            CPU = 1,
            MULTI_PLAYER = 2
        };


        public enum CalismaModu
        {
            SERVER = 0,
            CLIENT
        };

        public enum Zorluk
        {
            KOLAY = 0,
            ORTA,
            ZOR
        };

        private CalismaModu ServerOrClient;
        private Zorluk ZorlukDerecesi;
        private OyunModu oyunModu;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public F_Main()
        {
            InitializeComponent();
            frm1 = this;
            vfnTahtayiOlustur();

            vfnAvatar1Yerlestir();

            
        }


        /// <summary>
        /// 
        /// </summary>
        private void vfnAvatar1Yerlestir()
        {
            pbxAvatar1.Location = new Point(gbxPuanin.Location.X, pbxAvatar1.Location.Y);
            Random rndm = new Random();
            avatar1Index = rndm.Next(imgList.Images.Count);
            pbxAvatar1.Image = imgList.Images[avatar1Index];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="om"></param>
        public void setOyunModu(OyunModu om)
        {
            oyunModu = om;

            switch (oyunModu)
            {
                case OyunModu.SINGLE_PLAYER:
                    setTekKisilikOyunModu();
                    break;
                case OyunModu.CPU:
                    setBilgisayaraKarsiOyunModu();
                    break;
                case OyunModu.MULTI_PLAYER:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cm"></param>
        public void setCalismaModu(CalismaModu cm)
        {
            ServerOrClient = cm;

            if (ServerOrClient == CalismaModu.SERVER)
            {

                this.Text =  "Number Game (SERVER) ";
                
            }
            else
            {

               if (oyunModu == OyunModu.MULTI_PLAYER)
                    this.Text = "Number Game (CLIENT) ";

            }

         
            
        }

        public List<Point> getKonulanNoktalar()
        {
            return lstKonulanNoktalar;
        }



        /// <summary>
        /// 
        /// </summary>
        private void vfnTahtayiOlustur()
        {
            dataGridView1.Rows.Clear();   
            for (int i = 0; i < SIZE; i++)
            {
                dataGridView1.Rows.Add();
            }

            // Puanlamaların olduğu noktaları stillendirme
            vfnIslevKutulariniYerlestir();

            // Asal bonus
            vfnAsalBonus();
            
            // Tamkare bonus
            vfnTamKare();


            vfnSeciliYap(7, 7);
            lstKonulanNoktalar.Add(new Point(7, 7));
            
        }


        /// <summary>
        /// 
        /// </summary>
        private void vfnIslevKutulariniYerlestir()
        {
            // Yıldız (ortaya)
            vfnYildizKoy(7, 7);

            // +1 hamle hakkı
            vnfArtiBir(0, 0);
            vnfArtiBir(14, 0);
            vnfArtiBir(4, 4);
            vnfArtiBir(10, 4);
            vnfArtiBir(4, 10);
            vnfArtiBir(10, 10);
            vnfArtiBir(0, 14);
            vnfArtiBir(14, 14);

            // Puan x3 
            vfnCarpiUc(2, 2);
            vfnCarpiUc(12, 2);
            vfnCarpiUc(2, 12);
            vfnCarpiUc(12, 12);
            vfnCarpiUc(2, 7);
            vfnCarpiUc(7, 2);
            vfnCarpiUc(12, 7);
            vfnCarpiUc(7, 12);


            // Puan x2 
            vfnCarpiIki(7, 0);
            vfnCarpiIki(0, 7);
            vfnCarpiIki(14, 7);
            vfnCarpiIki(7, 14);
            vfnCarpiIki(5, 0);
            vfnCarpiIki(9, 0);
            vfnCarpiIki(5, 14);
            vfnCarpiIki(9, 14);
            vfnCarpiIki(14, 5);
            vfnCarpiIki(14, 9);
            vfnCarpiIki(0, 5);
            vfnCarpiIki(0, 9);



            // Puan / 2
            vfnBoluIki(6, 1);
            vfnBoluIki(1, 6);
            vfnBoluIki(8, 1);
            vfnBoluIki(1, 8);
            vfnBoluIki(13, 6);
            vfnBoluIki(6, 13);
            vfnBoluIki(13, 8);
            vfnBoluIki(8, 13);
            vfnBoluIki(2, 0);
            vfnBoluIki(12, 0);
            vfnBoluIki(0, 2);
            vfnBoluIki(14, 2);
            vfnBoluIki(12, 14);
            vfnBoluIki(14, 12);
            vfnBoluIki(0, 12);
            vfnBoluIki(2, 14);


            // Puan / 3
            vfnBoluUc(1, 1);
            vfnBoluUc(13, 1);
            vfnBoluUc(1, 13);
            vfnBoluUc(13, 13);


            // Puan x 0
            vfnCarpiSifir(3, 3);
            vfnCarpiSifir(11, 3);
            vfnCarpiSifir(3, 11);
            vfnCarpiSifir(11, 11);

        }


        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCol"></param>
        /// <param name="iRow"></param>
        private void vfnSeciliYap(int iCol, int iRow)
        {

            dataGridView1[iCol, iRow].Selected = true;
            dataGridView1_CellClick(this, new DataGridViewCellEventArgs(iCol, iRow));
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void vfnTamKare()
        {
            
            Random rnd = new Random();
            int randomIndex = rnd.Next(lstBosNoktalar.Count);
            int randomCol = lstBosNoktalar[randomIndex].X;
            int randomRow = lstBosNoktalar[randomIndex].Y;
            ptTamkareBonusNokta = new Point(randomCol, randomRow);

            dataGridView1[randomCol, randomRow].Value = "T";
            dataGridView1[randomCol, randomRow].Style.ForeColor = Color.Brown;
        }


        /// <summary>
        /// 
        /// </summary>
        private void vfnAsalBonus()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    bool bln1 = (i == 4 && j == 7);
                    bool bln2 = (i == 7 && j == 10);
                    bool bln3 = (i == 10 && j == 7);
                    bool bln4 = (i == 7 && j == 4);
                    bool bln5 = (i == 5 && j == 5);
                    bool bln6 = (i == 9 && j == 9);
                    bool bln7 = (i == 5 && j == 9);
                    bool bln8 = (i == 9 && j == 5);


                    if (dataGridView1[j, i].Value == null && 
                        !bln1 &&
                        !bln2 &&
                        !bln3 &&
                        !bln4 &&
                        !bln5 &&
                        !bln6 &&
                        !bln7 &&
                        !bln8)
                    {
                        lstBosNoktalar.Add(new Point(dataGridView1[j, i].ColumnIndex, dataGridView1[j, i].RowIndex));
                    }

                    
                }
            }

    
            Random rnd = new Random();
            int randomIndex = rnd.Next(lstBosNoktalar.Count);
            int randomCol = lstBosNoktalar[randomIndex].X;
            int randomRow = lstBosNoktalar[randomIndex].Y;
            ptAsalBonusNokta = new Point(randomCol, randomRow);

            dataGridView1[ randomCol, randomRow].Value = "A";
            dataGridView1[randomCol, randomRow].Style.ForeColor = Color.Brown;

            lstBosNoktalar.Remove(lstBosNoktalar[randomIndex]);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        private void vfnCarpiSifir(int iCol, int iRow)
        {
            dataGridView1[iCol, iRow].Style.BackColor = Color.LightGray;
            dataGridView1[iCol, iRow].Style.ForeColor = Color.White;
            dataGridView1[iCol, iRow].Value = "x0";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        private void vfnBoluUc(int iCol, int iRow)
        {
            dataGridView1[iCol, iRow].Style.BackColor = Color.LightGray;
            dataGridView1[iCol, iRow].Style.ForeColor = Color.White;
            dataGridView1[iCol, iRow].Value = "/3";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        private void vfnBoluIki(int iCol, int iRow)
        {
            dataGridView1[iCol, iRow].Style.BackColor = Color.LightGray;
            dataGridView1[iCol, iRow].Style.ForeColor = Color.White;
            dataGridView1[iCol, iRow].Value = "/2";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        private void vfnCarpiUc(int iCol, int iRow)
        {
            
            dataGridView1[iCol, iRow].Style.BackColor = Color.Bisque;
            dataGridView1[iCol, iRow].Style.ForeColor = Color.White;
            dataGridView1[iCol, iRow].Value = "x3";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        private void vfnCarpiIki(int iCol, int iRow)
        {
            dataGridView1[iCol, iRow].Style.BackColor = Color.Bisque;
            dataGridView1[iCol, iRow].Style.ForeColor = Color.White;
            dataGridView1[iCol, iRow].Value = "x2";
        }

        /// <summary>
        /// 
        /// </summary>
        private void vfnYildizKoy(int iCol, int iRow)
        {
            dataGridView1[iCol, iRow].Value = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCol"></param>
        /// <param name="iRow"></param>
        private void vnfArtiBir(int iCol, int iRow)
        {
            dataGridView1[iCol, iRow].Style.BackColor = Color.MistyRose;
            dataGridView1[iCol, iRow].Style.ForeColor = Color.White;
            dataGridView1[iCol, iRow].Value = "+H";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("w: " + this.Width + ", h: " + this.Height);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (false == blnFnSiraBendeMi())
            {
                if (true == blnFnBilgisayarModu())
                {
                    vfnGidilecekNoktalariTemizle();
                    lstGidilecekNoktalar.Clear();
                    vfnGidilecekYollariBelirle(ptEnSonKonulanNokta.X, ptEnSonKonulanNokta.Y);

                    // Gidilecek noktaları göster
                    foreach (Point pt in lstGidilecekNoktalar)
                    {
                        dataGridView1[pt.X, pt.Y].Style.BackColor = clrGidilecekYerlerinRengi;
                    }

                    // Eğer gidilecek nokta kalmadıysa oyun sonlanır
                    if (lstGidilecekNoktalar.Count == 0)
                    {
                        if (blnFnTekKisilikMod())
                        {
                            vfnOyunBitti();
                        }
                        else
                        {
                            vfnOyunBittiMultiplayer();
                        }

                    }

                } // else (Bilgisayar Modunda değilse)
                else
                {
                    lblAciklama.Text = "Oynama sırası rakipte.";
                    return;
                }
            }
            else
            {


                int iCol = e.ColumnIndex;
                int iRow = e.RowIndex;
                string strExVal = "";

                // Tıklanan yer gidilecek nokta içinde ise
                if (blnFnGidilecekYerIcindeMi(iCol, iRow))
                {
                    // Puan olarak ekle
                    Numara = Numara + 1;
                    int hucredenKazanilanPuan = iFnHucredenAlinanPuan(iCol, iRow);
                    Puan = Puan + hucredenKazanilanPuan;

                    if (null != dataGridView1[iCol, iRow].Value)
                        strExVal = dataGridView1[iCol, iRow].Value.ToString();

                    dataGridView1[iCol, iRow].Value = Numara;
                    dataGridView1[iCol, iRow].Style.ForeColor = Color.Black;

                    lblAciklama.Text = "Score : " + hucredenKazanilanPuan;

                    // Puan göster
                    lblPuan1.Text = Puan.ToString();

                   

                    ptEnSonKonulanNokta.X = iCol;
                    ptEnSonKonulanNokta.Y = iRow;

                    lstKonulanNoktalar.Add(ptEnSonKonulanNokta);


                    // SERVER isek
                    if (ServerOrClient == CalismaModu.SERVER)
                    {

                        F_Initiate.getInstance().vfnSend(ptEnSonKonulanNokta, Numara, Puan);
                        vfnSiraRakipte();
                    }
                    // CLIENT isek
                    else
                    {
                        F_Connect.getInstance().vfnSend(ptEnSonKonulanNokta, Numara, Puan);
                        vfnSiraRakipte();
                    }
                }

                if (false == blnFnBilgisayarModu())
                {

                    // Gidilecek noktaları ve stilleri temizle
                    // Tabii eğer için x2 x3 falan varsa onlar kalsın
                    vfnGidilecekNoktalariTemizle();


                    if (dataGridView1[iCol, iRow].Value != null)
                    {
                        string val = dataGridView1[iCol, iRow].Value.ToString();
                        int iVal = -1;

                        try
                        {
                            iVal = int.Parse(val);

                            // Son numarada isek 
                            if (iVal == Numara)
                            {
                                // gidilebiliecek yolları göster
                                vfnGidilecekYollariBelirle(iCol, iRow);

                                // Eğer gidilecek nokta kalmadıysa oyun sonlanır
                                if (lstGidilecekNoktalar.Count == 0)
                                {
                                    if (blnFnTekKisilikMod())
                                    {
                                        vfnOyunBitti();
                                    }
                                    else
                                    {
                                        vfnOyunBittiMultiplayer();
                                    }

                                }
                            }
                        }
                        catch
                        {
                            // parse edemiyorsak işlev kutularını tıklamışız demektir
                            // ekrana bilgi bastırılabilir

                            switch (val)
                            {
                                case "+H":
                                    lblAciklama.Text = "+100 points.";
                                    break;
                                case "x2":
                                    lblAciklama.Text = "[Number in the Cell] x 2 points.";
                                    break;
                                case "x3":
                                    lblAciklama.Text = "[Number in the Cell] x 3 points.";
                                    break;
                                case "/2":
                                    lblAciklama.Text = "[Number in the Cell] / 2 points.";
                                    break;
                                case "/3":
                                    lblAciklama.Text = "[Number in the Cell] /3 points.";
                                    break;
                                case "A":
                                    lblAciklama.Text = "If [Number in the Cell] is prime, +500 points.";
                                    break;
                                case "T":
                                    lblAciklama.Text = "If [Number in the Cell] is square number, +500 points.";
                                    break;
                                case "x0":
                                    lblAciklama.Text = "No points";
                                    break;
                                default:
                                    break;
                            } // end of switch


                        }
                    }
                    // boş hücre tıklandıysa
                    else
                    {
                        lblAciklama.Text = "Hit SPACE to go last location.";
                    }





                    // Gidilecek noktaları göster
                    foreach (Point pt in lstGidilecekNoktalar)
                    {
                        dataGridView1[pt.X, pt.Y].Style.BackColor = clrGidilecekYerlerinRengi;
                    }
 
                }


            

               

            }// end of else (oynama sırası)
            
        }


        /// <summary>
        /// 
        /// </summary>
        private void vfnOyunBittiMultiplayer()
        {
            

            int rakipPuan = int.Parse(lblPuan2.Text);
            string strPrompt = "";

            if (Puan > rakipPuan)
                strPrompt = "Congratulations ! You Win.. : " + Puan + " - " + rakipPuan;
            else if (Puan < rakipPuan)
                strPrompt = "You lost! : " + Puan +" - " + rakipPuan;
            else
                strPrompt = "It is a tie!";

            MessageBox.Show(strPrompt, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult dr = MessageBox.Show("Open a new game?", "New Game", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                // Yeni Oyun aç
                vfnYeniOyunAc();
            }
            else
            {
                return;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void vfnOyunBitti()
        {

            MessageBox.Show("Game over. Your score: " + Puan);
            DialogResult dr = MessageBox.Show("Open a new game?", "New Game", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                // Yeni Oyun aç
                vfnYeniOyunAc();
            }
            else
            {
                return;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void vfnYeniOyunAc()
        {
            
           

            // Tahtayı yeniden oluştur
            vfnTahtayiOlustur();

            vfnGidilecekNoktalariTemizle();

            // Bellekteki verileri sil
            lstBosNoktalar.Clear();
            lstGidilecekNoktalar.Clear();
            lstKonulanNoktalar.Clear();

            Puan = 0;
            blgPuan = 0;
            Numara = 1;
            ptCounter = 2;

            ptEnSonKonulanNokta.X = 7;
            ptEnSonKonulanNokta.Y = 7;

            vfnSeciliYap(7, 7);
            
        }



        /// <summary>
        /// 
        /// </summary>
        private void vfnGidilecekNoktalariTemizle()
        {
            foreach (Point pt in lstGidilecekNoktalar)
            {
                if (dataGridView1[pt.X, pt.Y].Value == null)
                    dataGridView1[pt.X, pt.Y].Style.BackColor = Color.White;
                else
                {
                    string val = dataGridView1[pt.X, pt.Y].Value.ToString();
                    int iVal = -1;

                    try
                    {
                        // Parse etmeyi dene
                        iVal = int.Parse(val);

                        // oluyorsa sayıdır, arka plan white , foreground black
                        dataGridView1[pt.X, pt.Y].Style.BackColor = Color.White;
                        dataGridView1[pt.X, pt.Y].Style.ForeColor = Color.Black;
                    }
                    catch
                    {
                        // olmuyorsa işlev kutusudur
                        switch (val)
                        {
                            case "+H":
                                vnfArtiBir(pt.X, pt.Y);
                                break;
                            case "x2":
                                vfnCarpiIki(pt.X, pt.Y);
                                break;
                            case "x3":
                                vfnCarpiUc(pt.X, pt.Y);
                                break;
                            case "/2":
                                vfnBoluIki(pt.X, pt.Y);
                                break;
                            case "/3":
                                vfnBoluUc(pt.X, pt.Y);
                                break;
                            case "x0":
                                vfnCarpiSifir(pt.X, pt.Y);
                                break;
                            case "A":
                                dataGridView1[pt.X, pt.Y].Style.BackColor = Color.White;
                                break;
                            case "T":
                                dataGridView1[pt.X, pt.Y].Style.BackColor = Color.White;
                                break;
                            default:
                                break;
                        } // end of switch
                    } // end of catch
                } // end of if-else
            } // end of foreach

            // gidilebilecek noktaları listeden sil
            lstGidilecekNoktalar.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCol"></param>
        /// <param name="iRow"></param>
        /// <returns></returns>
        private int iFnHucredenAlinanPuan(int iCol, int iRow)
        {

            if (dataGridView1[iCol, iRow].Value != null)
            {

                string val = dataGridView1[iCol, iRow].Value.ToString();

                switch (val)
                {
                    case "+H":
                        return Numara + 100;
                    case "x2":
                        return Numara* 2;
                    case "x3":
                        return Numara* 3;
                    case "/2":
                        return  Numara / 2;
                    case "/3":
                        return  Numara / 3;
                    case "x0":
                        return 0;
                        break;
                    case "A":
                        if (blnFnAsalMi(Numara))
                            return 500;
                        return Numara;
                    case "T":
                        if (blnFnTamkareMi(Numara))
                            return 500;
                        return Numara;
                    default:
                        return Numara;
                }
            }
            else
                return Numara;
  
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Numara"></param>
        /// <returns></returns>
        private bool blnFnTamkareMi(int num)
        {
            double karekok = Math.Sqrt(num * 1.0);
            if (karekok * 10 % 10 == 0)
                return true;
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Numara"></param>
        /// <returns></returns>
        private bool blnFnAsalMi(int num)
        {
            bool retBln = true;

            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                    retBln = false;
            }


            return retBln;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCol"></param>
        /// <param name="iRow"></param>
        /// <returns></returns>
        private bool blnFnGidilecekYerIcindeMi(int iCol, int iRow)
        {
            foreach (Point pt in lstGidilecekNoktalar)
            {
                if (pt.X == iCol && pt.Y == iRow)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCol"></param>
        /// <param name="iRow"></param>
        private void vfnGidilecekYollariBelirle(int iCol, int iRow)
        {
            vfnGidilecekNoktalariBelirle(iCol - 3, iRow);
            vfnGidilecekNoktalariBelirle(iCol + 3, iRow);
            vfnGidilecekNoktalariBelirle(iCol + 2, iRow + 2);
            vfnGidilecekNoktalariBelirle(iCol + 2, iRow - 2);
            vfnGidilecekNoktalariBelirle(iCol - 2, iRow + 2);
            vfnGidilecekNoktalariBelirle(iCol - 2, iRow - 2);
            vfnGidilecekNoktalariBelirle(iCol, iRow - 3);
            vfnGidilecekNoktalariBelirle(iCol, iRow + 3);

        }

        private void vfnGidilecekNoktalariBelirle(int iCol, int iRow)
        {

            int val = -1;

            // burda hata verirse sayı olmayan değerlere ulaştık demektir
            try
            {
                val = int.Parse(dataGridView1[iCol, iRow].Value.ToString());
            }
            catch
            {

                if (iRow >= 0 && iCol >= 0 && iRow < SIZE && iCol < SIZE)
                    lstGidilecekNoktalar.Add(new Point(iCol, iRow));

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCol"></param>
        /// <param name="iRow"></param>
        /// <returns></returns>
        private void vfnGidilecekNoktalariBelirle(int iCol, int iRow, ref List<Point> refList)
        {
            int val = -1;

            // burda hata verirse sayı olmayan değerlere ulaştık demektir
            try
            {
                val = int.Parse(dataGridView1[iCol, iRow].Value.ToString());
            }
            catch
            {

                if (iRow >= 0 && iCol >= 0 && iRow < SIZE && iCol < SIZE)
                    refList.Add(new Point(iCol, iRow));

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                vfnSeciliYap(ptEnSonKonulanNokta.X, ptEnSonKonulanNokta.Y);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOyunAc1_MouseMove(object sender, MouseEventArgs e)
        {
            Button btnSender = sender as Button;
            btnSender.BackColor = Color.PapayaWhip;
            btnSender.ForeColor = Color.Brown;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOyunAc1_MouseLeave(object sender, EventArgs e)
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
        private void btnOyunAc1_Click(object sender, EventArgs e)
        {
            F_Initiate.getInstance().Show();
        }


        private void btnBaglan1_Click(object sender, EventArgs e)
        {
            F_Connect.getInstance().Show();
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="noktalar"></param>
        public void vfnUpdateDgv(Point nokta, int num, int rakipPuan)
        {
            int i = nokta.X;
            int j = nokta.Y;

            Numara = num;
            int iRakipExPuan = int.Parse(lblPuan2.Text);
            lblPuan2.Text = rakipPuan.ToString();

            ptEnSonKonulanNokta = nokta;

            // Gidilecek nokta listesi temizleniyor
            vfnGidilecekNoktalariTemizle();

            // Bulunduğumuz nokta seçili halde
            dataGridView1[i, j].Selected = true;

            // Gidilecek noktalar listeye ekleniyor
            vfnGidilecekYollariBelirle(i, j);

            // Gidilecek noktalar yeşil renkte gösteriliyor
            foreach (Point pt in lstGidilecekNoktalar)
            {
                dataGridView1[pt.X, pt.Y].Style.BackColor = clrGidilecekYerlerinRengi;
            }

            // Güncelle
            dataGridView1[i, j].Value = Numara;
            dataGridView1[i, j].Style.BackColor = Color.White;
            dataGridView1[i, j].Style.ForeColor = Color.Black;

            lblAciklama.Text = "Opponent's score: " + (rakipPuan - iRakipExPuan);

            // Güncellemeler bitti, hamle sırası senin
            vfnSiraSende();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            F_Initiate.getInstance().CloseConnection();
            F_Connect.getInstance().CloseConnection();

            F_Initiate.getInstance().Dispose();
            F_Connect.getInstance().Dispose();

            Application.Exit();
        }



        /// <summary>
        /// 
        /// </summary>
        public void setTekKisilikOyunModu()
        {
            pbxSagOk.Visible = false;
            gbxRakibininPuani.Visible = false;
            panel1.Visible = false;
            pbxAvatar2.Visible = false;
            pnlOynamaSirasi.Visible = false;
        }


        /// <summary>
        /// 
        /// </summary>
        public void setBilgisayaraKarsiOyunModu()
        {
            pbxSolOk.Visible =  true;
            pbxSagOk.Visible = false;
            gbxRakibininPuani.Visible = true;
            gbxRakibininPuani.Text = "CPU (" + ZorlukDerecesi.ToString() + ")";
            panel1.Visible = false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool blnFnTekKisilikMod()
        {
            return (oyunModu == OyunModu.SINGLE_PLAYER);
        }

        public bool blnFnBilgisayarModu()
        {
            return (oyunModu == OyunModu.CPU);
        }

        public bool blnFnKarsilikliOyunModu()
        {
            return (oyunModu == OyunModu.MULTI_PLAYER);
        }



        /// <summary>
        /// 
        /// </summary>
        public void vfnSiraRakipte()
        {
            if (!blnFnTekKisilikMod())
            {
                pbxSagOk.Visible = true;
                pbxSolOk.Visible = false;
                lblOynamaSirasi.Text = "Opponent's turn...";


                // bilgisayar modunda isek, bilgisayar hamle yapar
                if (blnFnBilgisayarModu())
                {

                    System.Threading.Thread.Sleep(500);
                    int iCol = 0, iRow= 0 ;
                    

                    // lstGidilecekNoktalar'ı ve hücre stillerini temizle
                    vfnGidilecekNoktalariTemizle();
                    lstGidilecekNoktalar.Clear();

                    // lstGidilecekNoktalar'a noktalar ekleniyor
                    vfnGidilecekYollariBelirle(ptEnSonKonulanNokta.X, ptEnSonKonulanNokta.Y);


                    // Eğer gidilecek nokta kalmadıysa oyun sonlanır
                    if (lstGidilecekNoktalar.Count == 0)
                    {
                        if (blnFnTekKisilikMod())
                        {
                            vfnOyunBitti();
                        }
                        else
                        {
                            vfnOyunBittiMultiplayer();
                        }

                    }

                    if (ZorlukDerecesi == Zorluk.KOLAY)
                    {
                        // O noktalar arasından rastgele bir nokta seçiliyor
                        Random rnd = new Random();
                        int rndSec = rnd.Next(lstGidilecekNoktalar.Count);
                        if (lstGidilecekNoktalar.Count > 0)
                        {
                            iCol = lstGidilecekNoktalar[rndSec].X;
                            iRow = lstGidilecekNoktalar[rndSec].Y;
                        }
                    }
                    else if (ZorlukDerecesi == Zorluk.ORTA)
                    {
                        vfnEnUygunHucreyiSec(lstGidilecekNoktalar, ref iCol, ref iRow);
                    }
                    else if (ZorlukDerecesi == Zorluk.ZOR)
                    {
                        vfnEnUygunHucreyiSecV2(lstGidilecekNoktalar, ref iCol, ref iRow);
                    }


                   
                    // Puan olarak ekle
                    Numara = Numara + 1;
                    int hucredenKazanilanPuan = iFnHucredenAlinanPuan(iCol, iRow);
                    blgPuan = blgPuan + hucredenKazanilanPuan;

                    dataGridView1[iCol, iRow].Value = Numara;
                    dataGridView1[iCol, iRow].Style.ForeColor = Color.Black;

                    lblAciklama.Text = "CPU's score : " + hucredenKazanilanPuan;

                    // Puan göster
                    lblPuan2.Text = blgPuan.ToString();


                    // En son konulan nokta güncelle
                    ptEnSonKonulanNokta.X = iCol;
                    ptEnSonKonulanNokta.Y = iRow;
                    lstKonulanNoktalar.Add(ptEnSonKonulanNokta);


                    // Eğer gidilecek nokta kalmadıysa oyun sonlanır
                    if (lstGidilecekNoktalar.Count == 0)
                    {
                        if (blnFnTekKisilikMod())
                        {
                            vfnOyunBitti();
                        }
                        else
                        {
                            vfnOyunBittiMultiplayer();
                        }

                    }



                    vfnSeciliYap(iCol, iRow);

                    

                    // Sıra 1. oyuncuya geçti
                    vfnSiraSende();
                }
            }
        }

       


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstGidilecekNoktalar"></param>
        /// <param name="iCol"></param>
        /// <param name="iRow"></param>
        private void vfnEnUygunHucreyiSec(List<Point> pLstGidilecekNoktalar, ref int iCol, ref int iRow)
        {
            List<int> puanListesi = new List<int>();

            foreach (Point pt in pLstGidilecekNoktalar)
            {
                puanListesi.Add(iFnHucredenAlinanPuan(pt.X, pt.Y));
            }

            // Maksimum puanlı indexi bul
            int index = getMaximumIndex(puanListesi);

            if (pLstGidilecekNoktalar.Count > 0)
            {
                iCol = pLstGidilecekNoktalar[index].X;
                iRow = pLstGidilecekNoktalar[index].Y;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="puanListesi"></param>
        /// <returns></returns>
        private int getMaximumIndex(List<int> puanListesi)
        {
            int max = -1000, maxIdx = 0;

            for (int i = 0; i < puanListesi.Count; i++)
            {
                if (puanListesi[i] > max)
                {
                    max = puanListesi[i];
                    maxIdx = i;
                }
            }
            return maxIdx;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstGidilecekNoktalar"></param>
        /// <param name="iCol"></param>
        /// <param name="iRow"></param>
        private void vfnEnUygunHucreyiSecV2(List<Point> pLstGidilecekNoktalar, ref int iCol, ref int iRow)
        {
            List<int> puanListesi = new List<int>();

            foreach (Point pt in pLstGidilecekNoktalar)
            {
                int birSonrakiHucreMaxPuan = ifnHucreEtrafindakiMaxPuan(pt.X, pt.Y);
                puanListesi.Add(iFnHucredenAlinanPuan(pt.X, pt.Y) - birSonrakiHucreMaxPuan);
            }

            // Maksimum puanlı indexi bul
            int index = getMaximumIndex(puanListesi);

            if (pLstGidilecekNoktalar.Count > 0)
            {
                iCol = pLstGidilecekNoktalar[index].X;
                iRow = pLstGidilecekNoktalar[index].Y;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private int ifnHucreEtrafindakiMaxPuan(int pX, int pY)
        {
            int retMax = 0;
            List<int> puanListesi = new List<int>();



            List<Point> lstHucreEtrafindaGidilebilecekNoktalar = new List<Point>();

            // x,y hücresinin etrafındaki yollar belirleniyor, listeye ekleniyor
            vfnGidilecekNoktalariBelirle(pX - 3, pY, ref lstHucreEtrafindaGidilebilecekNoktalar);
            vfnGidilecekNoktalariBelirle(pX + 3, pY, ref lstHucreEtrafindaGidilebilecekNoktalar);
            vfnGidilecekNoktalariBelirle(pX + 2, pY + 2, ref lstHucreEtrafindaGidilebilecekNoktalar);
            vfnGidilecekNoktalariBelirle(pX + 2, pY - 2, ref lstHucreEtrafindaGidilebilecekNoktalar);
            vfnGidilecekNoktalariBelirle(pX - 2, pY + 2, ref lstHucreEtrafindaGidilebilecekNoktalar);
            vfnGidilecekNoktalariBelirle(pX - 2, pY - 2, ref lstHucreEtrafindaGidilebilecekNoktalar);
            vfnGidilecekNoktalariBelirle(pX , pY - 3, ref lstHucreEtrafindaGidilebilecekNoktalar);
            vfnGidilecekNoktalariBelirle(pX , pY + 3, ref lstHucreEtrafindaGidilebilecekNoktalar);

            // liste içerisinden olası puanlar hesaplanıp puan listesine ekleniyor
            foreach (Point pt in lstHucreEtrafindaGidilebilecekNoktalar)
            {
                puanListesi.Add(iFnHucredenAlinanPuan(pt.X, pt.Y));
            }

            puanListesi.Sort();
            if (puanListesi.Count > 0)
                retMax = puanListesi[puanListesi.Count - 1];
            return retMax;
            
        }

        /// <summary>
        /// 
        /// </summary>
        public void vfnSiraSende()
        {
            pbxSolOk.Visible = true;
            pbxSagOk.Visible = false;
            lblOynamaSirasi.Text = "Your turn...";

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool blnFnSiraBendeMi()
        {
            if (blnFnTekKisilikMod())
                return true;
            return (pbxSolOk.Visible);
        }


        /// <summary>
        /// 
        /// </summary>
        public void vfnDisableDgv()
        {
            dataGridView1.Enabled = false;
            lblAciklama.Text = "Plase open a new game or join an opened game.";
        }

        /// <summary>
        /// 
        /// </summary>
        public void vfnEnableDgv()
        {
            dataGridView1.Enabled = true;
            lblAciklama.Text = "Game is started.";
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point ptFnGetAsalBonusNokta()
        {
            return ptAsalBonusNokta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point ptFnGetTamkareBonusNokta()
        {
            return ptTamkareBonusNokta;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        public void vfnAsalBonusYerlestir(Point pt)
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value != null)
                    {
                        if (dataGridView1[j, i].Value.ToString() == "A" ||
                            dataGridView1[j, i].Value.ToString() == "T")
                        {
                            dataGridView1[j, i].Value = null;
                        }
                    }
                }
            }
            
            
            dataGridView1[pt.X, pt.Y].Value = "A";
            dataGridView1[pt.X, pt.Y]. Style.ForeColor = Color.Brown;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tamkarePoint"></param>
        public void vfnTamkareBonusYerlestir(Point tamkarePoint)
        {
            dataGridView1[tamkarePoint.X, tamkarePoint.Y].Value = "T";
            dataGridView1[tamkarePoint.X, tamkarePoint.Y].Style.ForeColor = Color.Brown;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTxt"></param>
        public void setAciklama(string pTxt)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new dlgAciklama(setAciklama), pTxt);
                return;
            }

            lblAciklama.Text = pTxt;
            return;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="zorluk"></param>
        public void setZorlukDerecesi(Zorluk zorluk)
        {
            ZorlukDerecesi = zorluk;

            switch (ZorlukDerecesi)
            {
                case Zorluk.KOLAY:
                    pbxAvatar2.Image = imgList.Images[3];
                    break;
                case Zorluk.ORTA:
                    pbxAvatar2.Image = imgList.Images[48];
                    break;
                case Zorluk.ZOR:
                    pbxAvatar2.Image = imgList.Images[33];
                    break;
                default:
                    break;
            }

            
        }


  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxAvatar1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                avatar1Index = (avatar1Index + 1) % imgList.Images.Count;
                pbxAvatar1.Image = imgList.Images[avatar1Index];
            }
            else if (e.Button == MouseButtons.Right)
            {
                avatar1Index = (avatar1Index - 1 + imgList.Images.Count) % imgList.Images.Count;
                pbxAvatar1.Image = imgList.Images[avatar1Index];
            }


            if (oyunModu == OyunModu.MULTI_PLAYER)
            {

                // Server isek, Client'a avatar index'ini yolla
                if (ServerOrClient == CalismaModu.SERVER)
                {
                    F_Initiate.getInstance().vfnSendMessage("avidx:" + avatar1Index);
                }
                // Client isek, server'a avatar index'ini yolla
                else
                {
                    F_Connect.getInstance().vfnSendMessage("avidx:" + avatar1Index);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxAvatar2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                avatar2Index = (avatar2Index + 1) % imgList.Images.Count;
                pbxAvatar2.Image = imgList.Images[avatar2Index];
            }
            else if (e.Button == MouseButtons.Right)
            {
                avatar2Index = (avatar2Index - 1 + imgList.Images.Count) % imgList.Images.Count;
                pbxAvatar2.Image = imgList.Images[avatar2Index];
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxAvatar1_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pbxSender = sender as PictureBox;
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxAvatar1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pbxSender = sender as PictureBox;
            this.Cursor = Cursors.Arrow;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="rakipAvatarIndex"></param>
        public void vfnUpdateAvatar(int rakipAvatarIndex)
        {
            if (rakipAvatarIndex < 0)
                rakipAvatarIndex *= -1;
            avatar2Index = (rakipAvatarIndex % imgList.Images.Count);
            pbxAvatar2.Image = imgList.Images[avatar2Index];
        }
    }
}
