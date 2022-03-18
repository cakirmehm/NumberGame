namespace Sayı_Oyunu_2014
{
    partial class F_Connect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Connect));
            this.gbxAyarlar = new System.Windows.Forms.GroupBox();
            this.numHamleSayisi = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numBeklemeSuresi = new System.Windows.Forms.NumericUpDown();
            this.chkBeklemeSuresi = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMesajGonder = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.rtxtBaglantiBilgi = new System.Windows.Forms.RichTextBox();
            this.btnBaglan = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.gbxAyarlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHamleSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeklemeSuresi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAyarlar
            // 
            this.gbxAyarlar.Controls.Add(this.numHamleSayisi);
            this.gbxAyarlar.Controls.Add(this.checkBox1);
            this.gbxAyarlar.Controls.Add(this.numBeklemeSuresi);
            this.gbxAyarlar.Controls.Add(this.chkBeklemeSuresi);
            this.gbxAyarlar.Enabled = false;
            this.gbxAyarlar.Location = new System.Drawing.Point(12, 12);
            this.gbxAyarlar.Name = "gbxAyarlar";
            this.gbxAyarlar.Size = new System.Drawing.Size(231, 78);
            this.gbxAyarlar.TabIndex = 0;
            this.gbxAyarlar.TabStop = false;
            this.gbxAyarlar.Text = "Settings";
            // 
            // numHamleSayisi
            // 
            this.numHamleSayisi.Location = new System.Drawing.Point(165, 39);
            this.numHamleSayisi.Name = "numHamleSayisi";
            this.numHamleSayisi.Size = new System.Drawing.Size(51, 20);
            this.numHamleSayisi.TabIndex = 3;
            this.numHamleSayisi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Num. of Sequential Play";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numBeklemeSuresi
            // 
            this.numBeklemeSuresi.Location = new System.Drawing.Point(165, 16);
            this.numBeklemeSuresi.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numBeklemeSuresi.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBeklemeSuresi.Name = "numBeklemeSuresi";
            this.numBeklemeSuresi.Size = new System.Drawing.Size(51, 20);
            this.numBeklemeSuresi.TabIndex = 1;
            this.numBeklemeSuresi.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // chkBeklemeSuresi
            // 
            this.chkBeklemeSuresi.AutoSize = true;
            this.chkBeklemeSuresi.Location = new System.Drawing.Point(16, 19);
            this.chkBeklemeSuresi.Name = "chkBeklemeSuresi";
            this.chkBeklemeSuresi.Size = new System.Drawing.Size(117, 17);
            this.chkBeklemeSuresi.TabIndex = 0;
            this.chkBeklemeSuresi.Text = "Wait Duration (sec)";
            this.chkBeklemeSuresi.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMesajGonder);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.btnGonder);
            this.groupBox2.Controls.Add(this.rtxtBaglantiBilgi);
            this.groupBox2.Controls.Add(this.btnBaglan);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 304);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection";
            // 
            // txtMesajGonder
            // 
            this.txtMesajGonder.Location = new System.Drawing.Point(16, 249);
            this.txtMesajGonder.Name = "txtMesajGonder";
            this.txtMesajGonder.Size = new System.Drawing.Size(200, 20);
            this.txtMesajGonder.TabIndex = 6;
            this.txtMesajGonder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMesajGonder_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 26);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "127.0.0.1";
            // 
            // btnGonder
            // 
            this.btnGonder.BackColor = System.Drawing.Color.RosyBrown;
            this.btnGonder.ForeColor = System.Drawing.Color.White;
            this.btnGonder.Location = new System.Drawing.Point(16, 275);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(200, 23);
            this.btnGonder.TabIndex = 3;
            this.btnGonder.Text = "Send Message";
            this.btnGonder.UseVisualStyleBackColor = false;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            this.btnGonder.MouseLeave += new System.EventHandler(this.btnOyunAc_MouseLeave);
            this.btnGonder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOyunAc_MouseMove);
            // 
            // rtxtBaglantiBilgi
            // 
            this.rtxtBaglantiBilgi.Location = new System.Drawing.Point(16, 79);
            this.rtxtBaglantiBilgi.Name = "rtxtBaglantiBilgi";
            this.rtxtBaglantiBilgi.ReadOnly = true;
            this.rtxtBaglantiBilgi.Size = new System.Drawing.Size(200, 164);
            this.rtxtBaglantiBilgi.TabIndex = 1;
            this.rtxtBaglantiBilgi.Text = "";
            this.rtxtBaglantiBilgi.TextChanged += new System.EventHandler(this.rtxtBaglantiBilgi_TextChanged);
            // 
            // btnBaglan
            // 
            this.btnBaglan.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBaglan.ForeColor = System.Drawing.Color.White;
            this.btnBaglan.Location = new System.Drawing.Point(16, 50);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(200, 23);
            this.btnBaglan.TabIndex = 0;
            this.btnBaglan.Text = "Connect to Server";
            this.btnBaglan.UseVisualStyleBackColor = false;
            this.btnBaglan.Click += new System.EventHandler(this.btnBaglan_Click);
            this.btnBaglan.MouseLeave += new System.EventHandler(this.btnOyunAc_MouseLeave);
            this.btnBaglan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOyunAc_MouseMove);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Simge durumunda küçültüldü.";
            this.notifyIcon1.BalloonTipTitle = "Oyuna Bağlanma Penceresi";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Sayı Oyunu 2014";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // F_Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(257, 410);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxAyarlar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "F_Connect";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Baglan_FormClosing);
            this.Load += new System.EventHandler(this.F_Baglan_Load);
            this.Resize += new System.EventHandler(this.F_Baglan_Resize);
            this.gbxAyarlar.ResumeLayout(false);
            this.gbxAyarlar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHamleSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeklemeSuresi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAyarlar;
        private System.Windows.Forms.NumericUpDown numBeklemeSuresi;
        private System.Windows.Forms.CheckBox chkBeklemeSuresi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numHamleSayisi;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnBaglan;
        private System.Windows.Forms.RichTextBox rtxtBaglantiBilgi;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtMesajGonder;
    }
}