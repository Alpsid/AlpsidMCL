namespace Kurulum
{
    partial class KurulumForm
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
            this.lblYolInfo = new System.Windows.Forms.Label();
            this.pnlInfoCard = new System.Windows.Forms.Panel();
            this.lblPreDownloadDesc = new System.Windows.Forms.Label();
            this.progressBarYukleme = new System.Windows.Forms.ProgressBar();
            this.lblDurumYukleme = new System.Windows.Forms.Label();
            this.btnYukle = new System.Windows.Forms.Button();
            this.btnKaldir = new System.Windows.Forms.Button();
            this.pnlInfoCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.lblBaslik.Location = new System.Drawing.Point(30, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(262, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "AlpsidMCL Kurulumu";
            // 
            // lblYolInfo
            // 
            this.lblYolInfo.AutoSize = true;
            this.lblYolInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblYolInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblYolInfo.Location = new System.Drawing.Point(30, 58);
            this.lblYolInfo.Name = "lblYolInfo";
            this.lblYolInfo.Size = new System.Drawing.Size(306, 17);
            this.lblYolInfo.TabIndex = 1;
            this.lblYolInfo.Text = "Kurulum Dizini: AppData\\Roaming\\AlpsidMCL";
            // 
            // pnlInfoCard
            // 
            this.pnlInfoCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.pnlInfoCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfoCard.Controls.Add(this.lblPreDownloadDesc);
            this.pnlInfoCard.Location = new System.Drawing.Point(30, 90);
            this.pnlInfoCard.Name = "pnlInfoCard";
            this.pnlInfoCard.Padding = new System.Windows.Forms.Padding(15);
            this.pnlInfoCard.Size = new System.Drawing.Size(560, 160);
            this.pnlInfoCard.TabIndex = 2;
            // 
            // lblPreDownloadDesc
            // 
            this.lblPreDownloadDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreDownloadDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPreDownloadDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.lblPreDownloadDesc.Location = new System.Drawing.Point(15, 15);
            this.lblPreDownloadDesc.Name = "lblPreDownloadDesc";
            this.lblPreDownloadDesc.Size = new System.Drawing.Size(528, 128);
            this.lblPreDownloadDesc.TabIndex = 0;
            this.lblPreDownloadDesc.Text = "Bu kurulum işlemi şunları gerçekleştirir:\r\n\r\n" +
                "• Gerekirse .NET 8 Masaüstü Çalışma Zamanı otomatik indirilir ve kurulur.\r\n" +
                "• Launcher dosyaları %appdata%\\AlpsidMCL dizinine güvenle yerleştirilir.\r\n" +
                "• Masaüstünüze doğrudan AlpsidMCL kısayolu oluşturulur.\r\n" +
                "• Minecraft 1.20.1 temel kütüphaneleri arka planda önceden hazırlanır.";
            // 
            // lblDurumYukleme
            // 
            this.lblDurumYukleme.AutoEllipsis = true;
            this.lblDurumYukleme.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDurumYukleme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.lblDurumYukleme.Location = new System.Drawing.Point(30, 265);
            this.lblDurumYukleme.Name = "lblDurumYukleme";
            this.lblDurumYukleme.Size = new System.Drawing.Size(560, 25);
            this.lblDurumYukleme.TabIndex = 3;
            this.lblDurumYukleme.Text = "Hazır. Kurulumu başlatmak için 'Kur ve Hazırla' butonuna tıklayın.";
            // 
            // progressBarYukleme
            // 
            this.progressBarYukleme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.progressBarYukleme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.progressBarYukleme.Location = new System.Drawing.Point(30, 295);
            this.progressBarYukleme.Name = "progressBarYukleme";
            this.progressBarYukleme.Size = new System.Drawing.Size(560, 20);
            this.progressBarYukleme.TabIndex = 4;
            // 
            // btnYukle
            // 
            this.btnYukle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.btnYukle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYukle.FlatAppearance.BorderSize = 0;
            this.btnYukle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYukle.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnYukle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnYukle.Location = new System.Drawing.Point(400, 335);
            this.btnYukle.Name = "btnYukle";
            this.btnYukle.Size = new System.Drawing.Size(190, 42);
            this.btnYukle.TabIndex = 5;
            this.btnYukle.Text = "Kur ve Hazırla";
            this.btnYukle.UseVisualStyleBackColor = false;
            // 
            // btnKaldir
            // 
            this.btnKaldir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(139)))), ((int)(((byte)(168)))));
            this.btnKaldir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaldir.FlatAppearance.BorderSize = 0;
            this.btnKaldir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaldir.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnKaldir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnKaldir.Location = new System.Drawing.Point(400, 335);
            this.btnKaldir.Name = "btnKaldir";
            this.btnKaldir.Size = new System.Drawing.Size(190, 42);
            this.btnKaldir.TabIndex = 6;
            this.btnKaldir.Text = "Kaldır";
            this.btnKaldir.UseVisualStyleBackColor = false;
            this.btnKaldir.Visible = false;
            // 
            // KurulumForm
            // 
            this.AcceptButton = this.btnYukle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(620, 400);
            this.Controls.Add(this.btnKaldir);
            this.Controls.Add(this.btnYukle);
            this.Controls.Add(this.progressBarYukleme);
            this.Controls.Add(this.lblDurumYukleme);
            this.Controls.Add(this.pnlInfoCard);
            this.Controls.Add(this.lblYolInfo);
            this.Controls.Add(this.lblBaslik);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "KurulumForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlpsidMCL Kurulum Sihirbazı";
            this.pnlInfoCard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblYolInfo;
        private System.Windows.Forms.Panel pnlInfoCard;
        private System.Windows.Forms.Label lblPreDownloadDesc;
        private System.Windows.Forms.ProgressBar progressBarYukleme;
        private System.Windows.Forms.Label lblDurumYukleme;
        private System.Windows.Forms.Button btnYukle;
        private System.Windows.Forms.Button btnKaldir;
    }
}
