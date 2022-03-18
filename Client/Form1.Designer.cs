namespace Client
{
    partial class Form1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxtBaglantiBilgi = new System.Windows.Forms.RichTextBox();
            this.btnOyunAc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numHamleSayisi = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numBeklemeSuresi = new System.Windows.Forms.NumericUpDown();
            this.chkBeklemeSuresi = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHamleSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeklemeSuresi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxtBaglantiBilgi);
            this.groupBox2.Controls.Add(this.btnOyunAc);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 270);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bağlantı";
            // 
            // rtxtBaglantiBilgi
            // 
            this.rtxtBaglantiBilgi.Location = new System.Drawing.Point(16, 48);
            this.rtxtBaglantiBilgi.Name = "rtxtBaglantiBilgi";
            this.rtxtBaglantiBilgi.Size = new System.Drawing.Size(200, 211);
            this.rtxtBaglantiBilgi.TabIndex = 1;
            this.rtxtBaglantiBilgi.Text = "";
            // 
            // btnOyunAc
            // 
            this.btnOyunAc.BackColor = System.Drawing.Color.RosyBrown;
            this.btnOyunAc.ForeColor = System.Drawing.Color.White;
            this.btnOyunAc.Location = new System.Drawing.Point(16, 19);
            this.btnOyunAc.Name = "btnOyunAc";
            this.btnOyunAc.Size = new System.Drawing.Size(200, 23);
            this.btnOyunAc.TabIndex = 0;
            this.btnOyunAc.Text = "Oyun Aç";
            this.btnOyunAc.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numHamleSayisi);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.numBeklemeSuresi);
            this.groupBox1.Controls.Add(this.chkBeklemeSuresi);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 112);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ayarlar";
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
            this.checkBox1.Size = new System.Drawing.Size(133, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "El içindeki hamle sayısı";
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
            this.chkBeklemeSuresi.Size = new System.Drawing.Size(119, 17);
            this.chkBeklemeSuresi.TabIndex = 0;
            this.chkBeklemeSuresi.Text = "Bekleme Süresi (sn)";
            this.chkBeklemeSuresi.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 412);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHamleSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeklemeSuresi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtxtBaglantiBilgi;
        private System.Windows.Forms.Button btnOyunAc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numHamleSayisi;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numBeklemeSuresi;
        private System.Windows.Forms.CheckBox chkBeklemeSuresi;
    }
}

