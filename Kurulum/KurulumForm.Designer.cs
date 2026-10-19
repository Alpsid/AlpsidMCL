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
            this.lblBaslik          = new System.Windows.Forms.Label();
            this.lblYolInfo         = new System.Windows.Forms.Label();
            this.progressBarYukleme = new System.Windows.Forms.ProgressBar();
            this.lblDurumYukleme    = new System.Windows.Forms.Label();
            this.btnYukle           = new System.Windows.Forms.Button();
            this.btnKaldir          = new System.Windows.Forms.Button();
            this.lblPreDownloadDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize  = true;
            this.lblBaslik.Font      = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.lblBaslik.Location  = new System.Drawing.Point(25, 25);
            this.lblBaslik.Name      = "lblBaslik";
            this.lblBaslik.Size      = new System.Drawing.Size(270, 30);
            this.lblBaslik.TabIndex  = 0;
            this.lblBaslik.Text      = "AlpsidMCL Kurulumu";
            // 
            // lblYolInfo
            // 
            this.lblYolInfo.AutoSize  = true;
            this.lblYolInfo.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblYolInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblYolInfo.Location  = new System.Drawing.Point(25, 75);
            this.lblYolInfo.Name      = "lblYolInfo";
            this.lblYolInfo.Size      = new System.Drawing.Size(350, 19);
            this.lblYolInfo.TabIndex  = 1;
            this.lblYolInfo.Text      = "Kurulum Dizini: AppData\\Roaming\\AlpsidMCL";
            // 
            // progressBarYukleme
            // 
            this.progressBarYukleme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.progressBarYukleme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.progressBarYukleme.Location  = new System.Drawing.Point(25, 230);
            this.progressBarYukleme.Name      = "progressBarYukleme";
            this.progressBarYukleme.Size      = new System.Drawing.Size(480, 25);
            this.progressBarYukleme.TabIndex  = 2;
            // 
            // lblDurumYukleme
            // 
            this.lblDurumYukleme.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDurumYukleme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.lblDurumYukleme.Location  = new System.Drawing.Point(25, 200);
            this.lblDurumYukleme.Name      = "lblDurumYukleme";
            this.lblDurumYukleme.Size      = new System.Drawing.Size(480, 20);
            this.lblDurumYukleme.TabIndex  = 3;
            this.lblDurumYukleme.Text      = "Hazır. Kurulumu başlatmak için 'Kur ve Hazırla' butonuna tıklayın.";
            // 
            // btnYukle  (Kur butonu)
            // 
            this.btnYukle.BackColor                  = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.btnYukle.FlatAppearance.BorderSize  = 0;
            this.btnYukle.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnYukle.Font                       = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnYukle.ForeColor                  = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnYukle.Location                   = new System.Drawing.Point(340, 280);
            this.btnYukle.Name                       = "btnYukle";
            this.btnYukle.Size                       = new System.Drawing.Size(165, 35);
            this.btnYukle.TabIndex                   = 4;
            this.btnYukle.Text                       = "Kur ve Hazırla";
            this.btnYukle.UseVisualStyleBackColor     = false;
            // 
            // btnKaldir  (Kaldır butonu — başlangıçta gizli)
            // 
            this.btnKaldir.BackColor                  = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(139)))), ((int)(((byte)(168)))));
            this.btnKaldir.FlatAppearance.BorderSize  = 0;
            this.btnKaldir.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaldir.Font                       = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnKaldir.ForeColor                  = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnKaldir.Location                   = new System.Drawing.Point(340, 280);
            this.btnKaldir.Name                       = "btnKaldir";
            this.btnKaldir.Size                       = new System.Drawing.Size(165, 35);
            this.btnKaldir.TabIndex                   = 5;
            this.btnKaldir.Text                       = "Kaldır";
            this.btnKaldir.UseVisualStyleBackColor     = false;
            this.btnKaldir.Visible                    = false;
            // 
            // lblPreDownloadDesc
            // 
            this.lblPreDownloadDesc.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPreDownloadDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblPreDownloadDesc.Location  = new System.Drawing.Point(25, 110);
            this.lblPreDownloadDesc.Name      = "lblPreDownloadDesc";
            this.lblPreDownloadDesc.Size      = new System.Drawing.Size(480, 80);
            this.lblPreDownloadDesc.TabIndex  = 6;
            this.lblPreDownloadDesc.Text      =
                "Bu işlem:\r\n" +
                "1. Gerekirse .NET 8 Masaüstü Çalışma Zamanı indirir.\r\n" +
                "2. Launcher dosyalarını %appdata%\\AlpsidMCL dizinine kopyalar.\r\n" +
                "3. Masaüstüne AlpsidMCL kısayolu oluşturur.\r\n" +
                "4. Minecraft 1.20.1 sürümünü %appdata%\\AlpsidMCL\\versions klasörüne indirir.";
            // 
            // KurulumForm
            // 
            this.AcceptButton        = this.btnYukle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize          = new System.Drawing.Size(534, 341);
            this.Controls.Add(this.lblPreDownloadDesc);
            this.Controls.Add(this.btnKaldir);
            this.Controls.Add(this.btnYukle);
            this.Controls.Add(this.lblDurumYukleme);
            this.Controls.Add(this.progressBarYukleme);
            this.Controls.Add(this.lblYolInfo);
            this.Controls.Add(this.lblBaslik);
            this.Font            = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Name            = "KurulumForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "AlpsidMCL Kurulum Sihirbazı";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label       lblBaslik;
        private System.Windows.Forms.Label       lblYolInfo;
        private System.Windows.Forms.ProgressBar progressBarYukleme;
        private System.Windows.Forms.Label       lblDurumYukleme;
        private System.Windows.Forms.Button      btnYukle;
        private System.Windows.Forms.Button      btnKaldir;
        private System.Windows.Forms.Label       lblPreDownloadDesc;
    }
}
