namespace Sayı_Oyunu_2014
{
    partial class F_Initiate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Initiate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numHamleSayisi = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numBeklemeSuresi = new System.Windows.Forms.NumericUpDown();
            this.chkBeklemeSuresi = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMesajGonder = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.rtxtBaglantiBilgi = new System.Windows.Forms.RichTextBox();
            this.btnOyunAc = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHamleSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeklemeSuresi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numHamleSayisi);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.numBeklemeSuresi);
            this.groupBox1.Controls.Add(this.chkBeklemeSuresi);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // numHamleSayisi
            // 
            this.numHamleSayisi.Location = new System.Drawing.Point(165, 39);
            this.numHamleSayisi.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numHamleSayisi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.groupBox2.Controls.Add(this.btnGonder);
            this.groupBox2.Controls.Add(this.rtxtBaglantiBilgi);
            this.groupBox2.Controls.Add(this.btnOyunAc);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 307);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection";
            // 
            // txtMesajGonder
            // 
            this.txtMesajGonder.Location = new System.Drawing.Point(16, 252);
            this.txtMesajGonder.Name = "txtMesajGonder";
            this.txtMesajGonder.Size = new System.Drawing.Size(200, 20);
            this.txtMesajGonder.TabIndex = 5;
            this.txtMesajGonder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMesajGonder_KeyPress);
            // 
            // btnGonder
            // 
            this.btnGonder.BackColor = System.Drawing.Color.RosyBrown;
            this.btnGonder.Enabled = false;
            this.btnGonder.ForeColor = System.Drawing.Color.White;
            this.btnGonder.Location = new System.Drawing.Point(16, 278);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(200, 23);
            this.btnGonder.TabIndex = 4;
            this.btnGonder.Text = "Send Message";
            this.btnGonder.UseVisualStyleBackColor = false;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            this.btnGonder.MouseLeave += new System.EventHandler(this.btnOyunAc_MouseLeave);
            this.btnGonder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOyunAc_MouseMove);
            // 
            // rtxtBaglantiBilgi
            // 
            this.rtxtBaglantiBilgi.Location = new System.Drawing.Point(16, 48);
            this.rtxtBaglantiBilgi.Name = "rtxtBaglantiBilgi";
            this.rtxtBaglantiBilgi.ReadOnly = true;
            this.rtxtBaglantiBilgi.Size = new System.Drawing.Size(200, 198);
            this.rtxtBaglantiBilgi.TabIndex = 1;
            this.rtxtBaglantiBilgi.Text = "";
            this.rtxtBaglantiBilgi.TextChanged += new System.EventHandler(this.rtxtBaglantiBilgi_TextChanged);
            // 
            // btnOyunAc
            // 
            this.btnOyunAc.BackColor = System.Drawing.Color.RosyBrown;
            this.btnOyunAc.ForeColor = System.Drawing.Color.White;
            this.btnOyunAc.Location = new System.Drawing.Point(16, 19);
            this.btnOyunAc.Name = "btnOyunAc";
            this.btnOyunAc.Size = new System.Drawing.Size(200, 23);
            this.btnOyunAc.TabIndex = 0;
            this.btnOyunAc.Text = "Initiate Game";
            this.btnOyunAc.UseVisualStyleBackColor = false;
            this.btnOyunAc.Click += new System.EventHandler(this.btnOyunAc_Click);
            this.btnOyunAc.MouseLeave += new System.EventHandler(this.btnOyunAc_MouseLeave);
            this.btnOyunAc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOyunAc_MouseMove);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Simge durumunda küçültüldü.";
            this.notifyIcon1.BalloonTipTitle = "Oyun Açma Penceresi";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Sayı Oyunu 2014";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // F_Initiate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(257, 410);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "F_Initiate";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initiate Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_OyunAc_FormClosing);
            this.Resize += new System.EventHandler(this.F_OyunAc_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHamleSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeklemeSuresi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numBeklemeSuresi;
        private System.Windows.Forms.CheckBox chkBeklemeSuresi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numHamleSayisi;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnOyunAc;
        private System.Windows.Forms.RichTextBox rtxtBaglantiBilgi;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox txtMesajGonder;
    }
}