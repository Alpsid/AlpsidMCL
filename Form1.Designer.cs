namespace Minecraft_launcher
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.lblRam = new System.Windows.Forms.Label();
            this.cmbRam = new System.Windows.Forms.ComboBox();
            this.lblSurum = new System.Windows.Forms.Label();
            this.cmbSurumler = new System.Windows.Forms.ComboBox();
            this.grpModType = new System.Windows.Forms.GroupBox();
            this.rdbNeoForge = new System.Windows.Forms.RadioButton();
            this.rdbForge = new System.Windows.Forms.RadioButton();
            this.rdbVanilla = new System.Windows.Forms.RadioButton();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblServerDesc = new System.Windows.Forms.Label();
            this.lblServerTitle = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnOyna = new System.Windows.Forms.Button();
            this.grpModType.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.lblBaslik.Location = new System.Drawing.Point(20, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(340, 37);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "ALPSID MC LAUNCHER";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblKullaniciAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.lblKullaniciAdi.Location = new System.Drawing.Point(30, 80);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(92, 19);
            this.lblKullaniciAdi.TabIndex = 1;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.txtKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtKullaniciAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(224)))), ((int)(((byte)(220)))));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(30, 105);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(240, 27);
            this.txtKullaniciAdi.TabIndex = 2;
            this.txtKullaniciAdi.Text = "Oyuncu";
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblRam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.lblRam.Location = new System.Drawing.Point(30, 150);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(102, 19);
            this.lblRam.TabIndex = 3;
            this.lblRam.Text = "Ayrılacak RAM:";
            // 
            // cmbRam
            // 
            this.cmbRam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.cmbRam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.cmbRam.FormattingEnabled = true;
            this.cmbRam.Location = new System.Drawing.Point(30, 175);
            this.cmbRam.Name = "cmbRam";
            this.cmbRam.Size = new System.Drawing.Size(240, 25);
            this.cmbRam.TabIndex = 4;
            // 
            // lblSurum
            // 
            this.lblSurum.AutoSize = true;
            this.lblSurum.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblSurum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.lblSurum.Location = new System.Drawing.Point(30, 220);
            this.lblSurum.Name = "lblSurum";
            this.lblSurum.Size = new System.Drawing.Size(126, 19);
            this.lblSurum.TabIndex = 5;
            this.lblSurum.Text = "Minecraft Sürümü:";
            // 
            // cmbSurumler
            // 
            this.cmbSurumler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.cmbSurumler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSurumler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSurumler.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSurumler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.cmbSurumler.FormattingEnabled = true;
            this.cmbSurumler.Location = new System.Drawing.Point(30, 245);
            this.cmbSurumler.Name = "cmbSurumler";
            this.cmbSurumler.Size = new System.Drawing.Size(240, 25);
            this.cmbSurumler.TabIndex = 6;
            // 
            // grpModType
            // 
            this.grpModType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.grpModType.Controls.Add(this.rdbNeoForge);
            this.grpModType.Controls.Add(this.rdbForge);
            this.grpModType.Controls.Add(this.rdbVanilla);
            this.grpModType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpModType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpModType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.grpModType.Location = new System.Drawing.Point(30, 290);
            this.grpModType.Name = "grpModType";
            this.grpModType.Size = new System.Drawing.Size(240, 120);
            this.grpModType.TabIndex = 7;
            this.grpModType.TabStop = false;
            this.grpModType.Text = "Mod Yükleyici Tipi";
            // 
            // rdbNeoForge
            // 
            this.rdbNeoForge.AutoSize = true;
            this.rdbNeoForge.Location = new System.Drawing.Point(20, 85);
            this.rdbNeoForge.Name = "rdbNeoForge";
            this.rdbNeoForge.Size = new System.Drawing.Size(87, 23);
            this.rdbNeoForge.TabIndex = 2;
            this.rdbNeoForge.Text = "NeoForge";
            this.rdbNeoForge.UseVisualStyleBackColor = true;
            // 
            // rdbForge
            // 
            this.rdbForge.AutoSize = true;
            this.rdbForge.Location = new System.Drawing.Point(20, 55);
            this.rdbForge.Name = "rdbForge";
            this.rdbForge.Size = new System.Drawing.Size(63, 23);
            this.rdbForge.TabIndex = 1;
            this.rdbForge.Text = "Forge";
            this.rdbForge.UseVisualStyleBackColor = true;
            // 
            // rdbVanilla
            // 
            this.rdbVanilla.AutoSize = true;
            this.rdbVanilla.Checked = true;
            this.rdbVanilla.Location = new System.Drawing.Point(20, 25);
            this.rdbVanilla.Name = "rdbVanilla";
            this.rdbVanilla.Size = new System.Drawing.Size(107, 23);
            this.rdbVanilla.TabIndex = 0;
            this.rdbVanilla.TabStop = true;
            this.rdbVanilla.Text = "Saf / Vanilla";
            this.rdbVanilla.UseVisualStyleBackColor = true;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.lblServerDesc);
            this.pnlRight.Controls.Add(this.lblServerTitle);
            this.pnlRight.Location = new System.Drawing.Point(300, 80);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(510, 330);
            this.pnlRight.TabIndex = 8;
            // 
            // lblServerDesc
            // 
            this.lblServerDesc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblServerDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblServerDesc.Location = new System.Drawing.Point(20, 60);
            this.lblServerDesc.Name = "lblServerDesc";
            this.lblServerDesc.Size = new System.Drawing.Size(468, 246);
            this.lblServerDesc.TabIndex = 1;
            this.lblServerDesc.Text = "Minecraft başlatıldığında doğrudan Ana Menü açılacaktır.\r\n\r\nSürüm ve mod yükleyi" +
    "ci seçimini yaptıktan sonra OYNA butonuna basarak oyunu başlatabilirsiniz.\r\n\r\nMo" +
    "d paketi kurulumu otomatik gerçekleştirilir.";
            // 
            // lblServerTitle
            // 
            this.lblServerTitle.AutoSize = true;
            this.lblServerTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblServerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.lblServerTitle.Location = new System.Drawing.Point(20, 20);
            this.lblServerTitle.Name = "lblServerTitle";
            this.lblServerTitle.Size = new System.Drawing.Size(155, 25);
            this.lblServerTitle.TabIndex = 0;
            this.lblServerTitle.Text = "OYUN BİLGİSİ";
            // 
            // lblDurum
            // 
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblDurum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.lblDurum.Location = new System.Drawing.Point(30, 425);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(780, 23);
            this.lblDurum.TabIndex = 9;
            this.lblDurum.Text = "Başlatılıyor...";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.progressBar1.Location = new System.Drawing.Point(30, 455);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(600, 35);
            this.progressBar1.TabIndex = 10;
            // 
            // btnOyna
            // 
            this.btnOyna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.btnOyna.FlatAppearance.BorderSize = 0;
            this.btnOyna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOyna.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold);
            this.btnOyna.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnOyna.Location = new System.Drawing.Point(645, 455);
            this.btnOyna.Name = "btnOyna";
            this.btnOyna.Size = new System.Drawing.Size(165, 35);
            this.btnOyna.TabIndex = 11;
            this.btnOyna.Text = "OYNA";
            this.btnOyna.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnOyna;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(834, 511);
            this.Controls.Add(this.btnOyna);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.grpModType);
            this.Controls.Add(this.cmbSurumler);
            this.Controls.Add(this.lblSurum);
            this.Controls.Add(this.cmbRam);
            this.Controls.Add(this.lblRam);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.lblBaslik);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alpsid Mc Launcher";
            this.grpModType.ResumeLayout(false);
            this.grpModType.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.ComboBox cmbRam;
        private System.Windows.Forms.Label lblSurum;
        private System.Windows.Forms.ComboBox cmbSurumler;
        private System.Windows.Forms.GroupBox grpModType;
        private System.Windows.Forms.RadioButton rdbNeoForge;
        private System.Windows.Forms.RadioButton rdbForge;
        private System.Windows.Forms.RadioButton rdbVanilla;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblServerDesc;
        private System.Windows.Forms.Label lblServerTitle;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnOyna;
    }
}
