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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblSurumEtiketi = new System.Windows.Forms.Label();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlMcNews = new System.Windows.Forms.Panel();
            this.lblMcNewsBody = new System.Windows.Forms.Label();
            this.lblMcNewsTitle = new System.Windows.Forms.Label();
            this.lblMcNewsWarning = new System.Windows.Forms.Label();
            this.pnlLauncherNews = new System.Windows.Forms.Panel();
            this.lblLauncherNewsBody = new System.Windows.Forms.Label();
            this.lblLauncherNewsTitle = new System.Windows.Forms.Label();
            this.lblLauncherNewsWarning = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.lblSurum = new System.Windows.Forms.Label();
            this.cmbSurumler = new System.Windows.Forms.ComboBox();
            this.lblRam = new System.Windows.Forms.Label();
            this.cmbRam = new System.Windows.Forms.ComboBox();
            this.btnAlpsidMods = new System.Windows.Forms.Button();
            this.btnOyna = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnFolder = new System.Windows.Forms.Button();
            this.pnlSettingsMenu = new System.Windows.Forms.Panel();
            this.pnlSettingsTopBar = new System.Windows.Forms.Panel();
            this.lblSettingsTitle = new System.Windows.Forms.Label();
            this.btnCloseSettingsMenu = new System.Windows.Forms.Button();
            this.pnlSettingsContent = new System.Windows.Forms.Panel();
            this.grpVersionFilters = new System.Windows.Forms.GroupBox();
            this.chkShowSnapshots = new System.Windows.Forms.CheckBox();
            this.chkShowBetas = new System.Windows.Forms.CheckBox();
            this.chkShowAlphas = new System.Windows.Forms.CheckBox();
            this.grpWindowSettings = new System.Windows.Forms.GroupBox();
            this.chkResizableWindow = new System.Windows.Forms.CheckBox();
            this.lblWindowSizeHint = new System.Windows.Forms.Label();
            this.grpBackupSettings = new System.Windows.Forms.GroupBox();
            this.chkEnableBackup = new System.Windows.Forms.CheckBox();
            this.lblMaxBackupSize = new System.Windows.Forms.Label();
            this.cmbMaxBackupSize = new System.Windows.Forms.ComboBox();
            this.lblBackupRetention = new System.Windows.Forms.Label();
            this.cmbBackupRetention = new System.Windows.Forms.ComboBox();
            this.lblBackupFrequency = new System.Windows.Forms.Label();
            this.cmbBackupFrequency = new System.Windows.Forms.ComboBox();
            this.btnBackupNow = new System.Windows.Forms.Button();
            this.pnlModsMenu = new System.Windows.Forms.Panel();
            this.pnlModsTopBar = new System.Windows.Forms.Panel();
            this.btnNavHome = new System.Windows.Forms.Button();
            this.btnNavMods = new System.Windows.Forms.Button();
            this.btnNavResourcePacks = new System.Windows.Forms.Button();
            this.btnNavShaders = new System.Windows.Forms.Button();
            this.cmbSortMods = new System.Windows.Forms.ComboBox();
            this.txtModSearch = new System.Windows.Forms.TextBox();
            this.btnCloseModsMenu = new System.Windows.Forms.Button();
            this.pnlModsLeft = new System.Windows.Forms.Panel();
            this.btnCreateModpack = new System.Windows.Forms.Button();
            this.lblRecentModpacksTitle = new System.Windows.Forms.Label();
            this.lstRecentModpacks = new System.Windows.Forms.ListBox();
            this.pnlModsContent = new System.Windows.Forms.Panel();
            this.lblModsContentPlaceholder = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.grpModType = new System.Windows.Forms.GroupBox();
            this.rdbNeoForge = new System.Windows.Forms.RadioButton();
            this.rdbForge = new System.Windows.Forms.RadioButton();
            this.rdbVanilla = new System.Windows.Forms.RadioButton();
            this.pnlCenter.SuspendLayout();
            this.pnlMcNews.SuspendLayout();
            this.pnlLauncherNews.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.grpModType.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(20, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(36, 36);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 7;
            this.picLogo.TabStop = false;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.lblBaslik.Location = new System.Drawing.Point(62, 14);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(275, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "ALPSID MC LAUNCHER";
            // 
            // lblSurumEtiketi
            // 
            this.lblSurumEtiketi.AutoSize = true;
            this.lblSurumEtiketi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSurumEtiketi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblSurumEtiketi.Location = new System.Drawing.Point(342, 27);
            this.lblSurumEtiketi.Name = "lblSurumEtiketi";
            this.lblSurumEtiketi.Size = new System.Drawing.Size(43, 15);
            this.lblSurumEtiketi.TabIndex = 1;
            this.lblSurumEtiketi.Text = "v1.0.6";
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlSettingsMenu);
            this.pnlCenter.Controls.Add(this.pnlModsMenu);
            this.pnlCenter.Controls.Add(this.pnlMcNews);
            this.pnlCenter.Controls.Add(this.pnlLauncherNews);
            this.pnlCenter.Location = new System.Drawing.Point(20, 60);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(900, 370);
            this.pnlCenter.TabIndex = 2;
            // 
            // pnlSettingsMenu
            // 
            this.pnlSettingsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.pnlSettingsMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettingsMenu.Controls.Add(this.pnlSettingsContent);
            this.pnlSettingsMenu.Controls.Add(this.pnlSettingsTopBar);
            this.pnlSettingsMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSettingsMenu.Name = "pnlSettingsMenu";
            this.pnlSettingsMenu.Size = new System.Drawing.Size(900, 365);
            this.pnlSettingsMenu.TabIndex = 3;
            this.pnlSettingsMenu.Visible = false;
            // 
            // pnlSettingsTopBar
            // 
            this.pnlSettingsTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.pnlSettingsTopBar.Controls.Add(this.lblSettingsTitle);
            this.pnlSettingsTopBar.Controls.Add(this.btnCloseSettingsMenu);
            this.pnlSettingsTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettingsTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSettingsTopBar.Name = "pnlSettingsTopBar";
            this.pnlSettingsTopBar.Size = new System.Drawing.Size(898, 48);
            this.pnlSettingsTopBar.TabIndex = 0;
            // 
            // lblSettingsTitle
            // 
            this.lblSettingsTitle.AutoSize = true;
            this.lblSettingsTitle.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.lblSettingsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(175)))));
            this.lblSettingsTitle.Location = new System.Drawing.Point(15, 13);
            this.lblSettingsTitle.Name = "lblSettingsTitle";
            this.lblSettingsTitle.Size = new System.Drawing.Size(185, 21);
            this.lblSettingsTitle.TabIndex = 0;
            this.lblSettingsTitle.Text = "⚙️ LAUNCHER AYARLARI";
            // 
            // btnCloseSettingsMenu
            // 
            this.btnCloseSettingsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseSettingsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(139)))), ((int)(((byte)(168)))));
            this.btnCloseSettingsMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseSettingsMenu.FlatAppearance.BorderSize = 0;
            this.btnCloseSettingsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSettingsMenu.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.btnCloseSettingsMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnCloseSettingsMenu.Location = new System.Drawing.Point(800, 8);
            this.btnCloseSettingsMenu.Name = "btnCloseSettingsMenu";
            this.btnCloseSettingsMenu.Size = new System.Drawing.Size(88, 32);
            this.btnCloseSettingsMenu.TabIndex = 1;
            this.btnCloseSettingsMenu.Text = "✕ Kapat";
            this.btnCloseSettingsMenu.UseVisualStyleBackColor = false;
            // 
            // pnlSettingsContent
            // 
            this.pnlSettingsContent.AutoScroll = true;
            this.pnlSettingsContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.pnlSettingsContent.Controls.Add(this.grpBackupSettings);
            this.pnlSettingsContent.Controls.Add(this.grpWindowSettings);
            this.pnlSettingsContent.Controls.Add(this.grpVersionFilters);
            this.pnlSettingsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettingsContent.Location = new System.Drawing.Point(0, 48);
            this.pnlSettingsContent.Name = "pnlSettingsContent";
            this.pnlSettingsContent.Padding = new System.Windows.Forms.Padding(15);
            this.pnlSettingsContent.Size = new System.Drawing.Size(898, 315);
            this.pnlSettingsContent.TabIndex = 1;
            // 
            // grpVersionFilters
            // 
            this.grpVersionFilters.Controls.Add(this.chkShowAlphas);
            this.grpVersionFilters.Controls.Add(this.chkShowBetas);
            this.grpVersionFilters.Controls.Add(this.chkShowSnapshots);
            this.grpVersionFilters.Font = new System.Drawing.Font("Segoe UI Bold", 10F);
            this.grpVersionFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.grpVersionFilters.Location = new System.Drawing.Point(15, 10);
            this.grpVersionFilters.Name = "grpVersionFilters";
            this.grpVersionFilters.Size = new System.Drawing.Size(415, 120);
            this.grpVersionFilters.TabIndex = 0;
            this.grpVersionFilters.TabStop = false;
            this.grpVersionFilters.Text = "🕹️ Sürüm Görünürlük Ayarları";
            // 
            // chkShowSnapshots
            // 
            this.chkShowSnapshots.AutoSize = true;
            this.chkShowSnapshots.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.chkShowSnapshots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.chkShowSnapshots.Location = new System.Drawing.Point(20, 28);
            this.chkShowSnapshots.Name = "chkShowSnapshots";
            this.chkShowSnapshots.Size = new System.Drawing.Size(217, 21);
            this.chkShowSnapshots.TabIndex = 0;
            this.chkShowSnapshots.Text = "Snapshot Sürümlerini Göster";
            this.chkShowSnapshots.UseVisualStyleBackColor = true;
            // 
            // chkShowBetas
            // 
            this.chkShowBetas.AutoSize = true;
            this.chkShowBetas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.chkShowBetas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.chkShowBetas.Location = new System.Drawing.Point(20, 56);
            this.chkShowBetas.Name = "chkShowBetas";
            this.chkShowBetas.Size = new System.Drawing.Size(232, 21);
            this.chkShowBetas.TabIndex = 1;
            this.chkShowBetas.Text = "Eski Beta (b) Sürümlerini Göster";
            this.chkShowBetas.UseVisualStyleBackColor = true;
            // 
            // chkShowAlphas
            // 
            this.chkShowAlphas.AutoSize = true;
            this.chkShowAlphas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.chkShowAlphas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.chkShowAlphas.Location = new System.Drawing.Point(20, 84);
            this.chkShowAlphas.Name = "chkShowAlphas";
            this.chkShowAlphas.Size = new System.Drawing.Size(240, 21);
            this.chkShowAlphas.TabIndex = 2;
            this.chkShowAlphas.Text = "Eski Alpha (a) Sürümlerini Göster";
            this.chkShowAlphas.UseVisualStyleBackColor = true;
            // 
            // grpWindowSettings
            // 
            this.grpWindowSettings.Controls.Add(this.lblWindowSizeHint);
            this.grpWindowSettings.Controls.Add(this.chkResizableWindow);
            this.grpWindowSettings.Font = new System.Drawing.Font("Segoe UI Bold", 10F);
            this.grpWindowSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.grpWindowSettings.Location = new System.Drawing.Point(15, 140);
            this.grpWindowSettings.Name = "grpWindowSettings";
            this.grpWindowSettings.Size = new System.Drawing.Size(415, 155);
            this.grpWindowSettings.TabIndex = 1;
            this.grpWindowSettings.TabStop = false;
            this.grpWindowSettings.Text = "📐 Pencere Boyutlandırma";
            // 
            // chkResizableWindow
            // 
            this.chkResizableWindow.AutoSize = true;
            this.chkResizableWindow.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.chkResizableWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.chkResizableWindow.Location = new System.Drawing.Point(20, 32);
            this.chkResizableWindow.Name = "chkResizableWindow";
            this.chkResizableWindow.Size = new System.Drawing.Size(256, 21);
            this.chkResizableWindow.TabIndex = 0;
            this.chkResizableWindow.Text = "Pencere Boyutlandırmayı Aktif Et";
            this.chkResizableWindow.UseVisualStyleBackColor = true;
            // 
            // lblWindowSizeHint
            // 
            this.lblWindowSizeHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblWindowSizeHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblWindowSizeHint.Location = new System.Drawing.Point(20, 62);
            this.lblWindowSizeHint.Name = "lblWindowSizeHint";
            this.lblWindowSizeHint.Size = new System.Drawing.Size(375, 75);
            this.lblWindowSizeHint.TabIndex = 1;
            this.lblWindowSizeHint.Text = "Bu seçenek işaretlendiğinde launcher penceresi kenarlarından çekilerek serbestçe büyütülüp küçültülebilir ve tam ekran yapılabilir. Kapatıldığında sabit boyutuna kilitlenir.";
            // 
            // grpBackupSettings
            // 
            this.grpBackupSettings.Controls.Add(this.btnBackupNow);
            this.grpBackupSettings.Controls.Add(this.cmbBackupFrequency);
            this.grpBackupSettings.Controls.Add(this.lblBackupFrequency);
            this.grpBackupSettings.Controls.Add(this.cmbBackupRetention);
            this.grpBackupSettings.Controls.Add(this.lblBackupRetention);
            this.grpBackupSettings.Controls.Add(this.cmbMaxBackupSize);
            this.grpBackupSettings.Controls.Add(this.lblMaxBackupSize);
            this.grpBackupSettings.Controls.Add(this.chkEnableBackup);
            this.grpBackupSettings.Font = new System.Drawing.Font("Segoe UI Bold", 10F);
            this.grpBackupSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(175)))));
            this.grpBackupSettings.Location = new System.Drawing.Point(445, 10);
            this.grpBackupSettings.Name = "grpBackupSettings";
            this.grpBackupSettings.Size = new System.Drawing.Size(435, 285);
            this.grpBackupSettings.TabIndex = 2;
            this.grpBackupSettings.TabStop = false;
            this.grpBackupSettings.Text = "💾 Otomatik Yedekleme Sistemi";
            // 
            // chkEnableBackup
            // 
            this.chkEnableBackup.AutoSize = true;
            this.chkEnableBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.chkEnableBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.chkEnableBackup.Location = new System.Drawing.Point(20, 28);
            this.chkEnableBackup.Name = "chkEnableBackup";
            this.chkEnableBackup.Size = new System.Drawing.Size(268, 21);
            this.chkEnableBackup.TabIndex = 0;
            this.chkEnableBackup.Text = "Dünya ve Ayar Yedeklemesini Aç";
            this.chkEnableBackup.UseVisualStyleBackColor = true;
            // 
            // lblMaxBackupSize
            // 
            this.lblMaxBackupSize.AutoSize = true;
            this.lblMaxBackupSize.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblMaxBackupSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblMaxBackupSize.Location = new System.Drawing.Point(20, 65);
            this.lblMaxBackupSize.Name = "lblMaxBackupSize";
            this.lblMaxBackupSize.Size = new System.Drawing.Size(175, 15);
            this.lblMaxBackupSize.TabIndex = 1;
            this.lblMaxBackupSize.Text = "Maksimum Yedek Depolama:";
            // 
            // cmbMaxBackupSize
            // 
            this.cmbMaxBackupSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.cmbMaxBackupSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaxBackupSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMaxBackupSize.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.cmbMaxBackupSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.cmbMaxBackupSize.FormattingEnabled = true;
            this.cmbMaxBackupSize.Items.AddRange(new object[] { "500 MB", "1 GB", "2 GB", "5 GB", "10 GB" });
            this.cmbMaxBackupSize.Location = new System.Drawing.Point(220, 62);
            this.cmbMaxBackupSize.Name = "cmbMaxBackupSize";
            this.cmbMaxBackupSize.Size = new System.Drawing.Size(190, 23);
            this.cmbMaxBackupSize.TabIndex = 2;
            // 
            // lblBackupRetention
            // 
            this.lblBackupRetention.AutoSize = true;
            this.lblBackupRetention.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblBackupRetention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblBackupRetention.Location = new System.Drawing.Point(20, 105);
            this.lblBackupRetention.Name = "lblBackupRetention";
            this.lblBackupRetention.Size = new System.Drawing.Size(155, 15);
            this.lblBackupRetention.TabIndex = 3;
            this.lblBackupRetention.Text = "Maksimum Saklama Süresi:";
            // 
            // cmbBackupRetention
            // 
            this.cmbBackupRetention.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.cmbBackupRetention.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackupRetention.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBackupRetention.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.cmbBackupRetention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.cmbBackupRetention.FormattingEnabled = true;
            this.cmbBackupRetention.Items.AddRange(new object[] { "3 Gün", "7 Gün", "14 Gün", "30 Gün", "Süresiz" });
            this.cmbBackupRetention.Location = new System.Drawing.Point(220, 102);
            this.cmbBackupRetention.Name = "cmbBackupRetention";
            this.cmbBackupRetention.Size = new System.Drawing.Size(190, 23);
            this.cmbBackupRetention.TabIndex = 4;
            // 
            // lblBackupFrequency
            // 
            this.lblBackupFrequency.AutoSize = true;
            this.lblBackupFrequency.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblBackupFrequency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblBackupFrequency.Location = new System.Drawing.Point(20, 145);
            this.lblBackupFrequency.Name = "lblBackupFrequency";
            this.lblBackupFrequency.Size = new System.Drawing.Size(110, 15);
            this.lblBackupFrequency.TabIndex = 5;
            this.lblBackupFrequency.Text = "Yedekleme Sıklığı:";
            // 
            // cmbBackupFrequency
            // 
            this.cmbBackupFrequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.cmbBackupFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackupFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBackupFrequency.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.cmbBackupFrequency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.cmbBackupFrequency.FormattingEnabled = true;
            this.cmbBackupFrequency.Items.AddRange(new object[] { "Her Oyundan Çıkışta", "Günde 1 Kez", "Haftada 1 Kez", "Yalnızca Manuel" });
            this.cmbBackupFrequency.Location = new System.Drawing.Point(220, 142);
            this.cmbBackupFrequency.Name = "cmbBackupFrequency";
            this.cmbBackupFrequency.Size = new System.Drawing.Size(190, 23);
            this.cmbBackupFrequency.TabIndex = 6;
            // 
            // btnBackupNow
            // 
            this.btnBackupNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.btnBackupNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackupNow.FlatAppearance.BorderSize = 0;
            this.btnBackupNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupNow.Font = new System.Drawing.Font("Segoe UI Black", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBackupNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnBackupNow.Location = new System.Drawing.Point(20, 195);
            this.btnBackupNow.Name = "btnBackupNow";
            this.btnBackupNow.Size = new System.Drawing.Size(390, 36);
            this.btnBackupNow.TabIndex = 7;
            this.btnBackupNow.Text = "⚡ Şimdi Manuel Yedek Al";
            this.btnBackupNow.UseVisualStyleBackColor = false;
            // 
            // pnlModsMenu
            // 
            this.pnlModsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.pnlModsMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModsMenu.Controls.Add(this.pnlModsContent);
            this.pnlModsMenu.Controls.Add(this.pnlModsLeft);
            this.pnlModsMenu.Controls.Add(this.pnlModsTopBar);
            this.pnlModsMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlModsMenu.Name = "pnlModsMenu";
            this.pnlModsMenu.Size = new System.Drawing.Size(900, 365);
            this.pnlModsMenu.TabIndex = 2;
            this.pnlModsMenu.Visible = false;
            // 
            // pnlModsTopBar
            // 
            this.pnlModsTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.pnlModsTopBar.Controls.Add(this.btnNavHome);
            this.pnlModsTopBar.Controls.Add(this.btnNavMods);
            this.pnlModsTopBar.Controls.Add(this.btnNavResourcePacks);
            this.pnlModsTopBar.Controls.Add(this.btnNavShaders);
            this.pnlModsTopBar.Controls.Add(this.cmbSortMods);
            this.pnlModsTopBar.Controls.Add(this.txtModSearch);
            this.pnlModsTopBar.Controls.Add(this.btnCloseModsMenu);
            this.pnlModsTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModsTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlModsTopBar.Name = "pnlModsTopBar";
            this.pnlModsTopBar.Size = new System.Drawing.Size(898, 48);
            this.pnlModsTopBar.TabIndex = 0;
            // 
            // btnNavHome
            // 
            this.btnNavHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.btnNavHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavHome.FlatAppearance.BorderSize = 0;
            this.btnNavHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavHome.Font = new System.Drawing.Font("Segoe UI Bold", 9.5F);
            this.btnNavHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(224)))), ((int)(((byte)(220)))));
            this.btnNavHome.Location = new System.Drawing.Point(12, 8);
            this.btnNavHome.Name = "btnNavHome";
            this.btnNavHome.Size = new System.Drawing.Size(85, 32);
            this.btnNavHome.TabIndex = 0;
            this.btnNavHome.Text = "🏠 Home";
            this.btnNavHome.UseVisualStyleBackColor = false;
            // 
            // btnNavMods
            // 
            this.btnNavMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnNavMods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavMods.FlatAppearance.BorderSize = 0;
            this.btnNavMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMods.Font = new System.Drawing.Font("Segoe UI Bold", 9.5F);
            this.btnNavMods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.btnNavMods.Location = new System.Drawing.Point(103, 8);
            this.btnNavMods.Name = "btnNavMods";
            this.btnNavMods.Size = new System.Drawing.Size(80, 32);
            this.btnNavMods.TabIndex = 1;
            this.btnNavMods.Text = "🧩 Mods";
            this.btnNavMods.UseVisualStyleBackColor = false;
            // 
            // btnNavResourcePacks
            // 
            this.btnNavResourcePacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnNavResourcePacks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavResourcePacks.FlatAppearance.BorderSize = 0;
            this.btnNavResourcePacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavResourcePacks.Font = new System.Drawing.Font("Segoe UI Bold", 9.5F);
            this.btnNavResourcePacks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.btnNavResourcePacks.Location = new System.Drawing.Point(189, 8);
            this.btnNavResourcePacks.Name = "btnNavResourcePacks";
            this.btnNavResourcePacks.Size = new System.Drawing.Size(145, 32);
            this.btnNavResourcePacks.TabIndex = 2;
            this.btnNavResourcePacks.Text = "🎨 Resource Packs";
            this.btnNavResourcePacks.UseVisualStyleBackColor = false;
            // 
            // btnNavShaders
            // 
            this.btnNavShaders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnNavShaders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavShaders.FlatAppearance.BorderSize = 0;
            this.btnNavShaders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavShaders.Font = new System.Drawing.Font("Segoe UI Bold", 9.5F);
            this.btnNavShaders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.btnNavShaders.Location = new System.Drawing.Point(340, 8);
            this.btnNavShaders.Name = "btnNavShaders";
            this.btnNavShaders.Size = new System.Drawing.Size(95, 32);
            this.btnNavShaders.TabIndex = 3;
            this.btnNavShaders.Text = "✨ Shaders";
            this.btnNavShaders.UseVisualStyleBackColor = false;
            // 
            // cmbSortMods
            // 
            this.cmbSortMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.cmbSortMods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortMods.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.cmbSortMods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.cmbSortMods.FormattingEnabled = true;
            this.cmbSortMods.Items.AddRange(new object[] { "🔥 Popülerliğe Göre", "⬇️ İndirme Sayısına Göre", "⭐ En Yeni Eklenenler", "🔤 İsim (A-Z)" });
            this.cmbSortMods.Location = new System.Drawing.Point(442, 13);
            this.cmbSortMods.Name = "cmbSortMods";
            this.cmbSortMods.Size = new System.Drawing.Size(160, 21);
            this.cmbSortMods.TabIndex = 4;
            // 
            // txtModSearch
            // 
            this.txtModSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.txtModSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.txtModSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.txtModSearch.Location = new System.Drawing.Point(608, 12);
            this.txtModSearch.Name = "txtModSearch";
            this.txtModSearch.PlaceholderText = "🔍 Mod / Paket Ara...";
            this.txtModSearch.Size = new System.Drawing.Size(185, 23);
            this.txtModSearch.TabIndex = 5;
            // 
            // btnCloseModsMenu
            // 
            this.btnCloseModsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseModsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(139)))), ((int)(((byte)(168)))));
            this.btnCloseModsMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseModsMenu.FlatAppearance.BorderSize = 0;
            this.btnCloseModsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseModsMenu.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.btnCloseModsMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnCloseModsMenu.Location = new System.Drawing.Point(800, 8);
            this.btnCloseModsMenu.Name = "btnCloseModsMenu";
            this.btnCloseModsMenu.Size = new System.Drawing.Size(88, 32);
            this.btnCloseModsMenu.TabIndex = 6;
            this.btnCloseModsMenu.Text = "✕ Kapat";
            this.btnCloseModsMenu.UseVisualStyleBackColor = false;
            // 
            // pnlModsLeft
            // 
            this.pnlModsLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.pnlModsLeft.Controls.Add(this.lstRecentModpacks);
            this.pnlModsLeft.Controls.Add(this.lblRecentModpacksTitle);
            this.pnlModsLeft.Controls.Add(this.btnCreateModpack);
            this.pnlModsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlModsLeft.Location = new System.Drawing.Point(0, 48);
            this.pnlModsLeft.Name = "pnlModsLeft";
            this.pnlModsLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlModsLeft.Size = new System.Drawing.Size(195, 315);
            this.pnlModsLeft.TabIndex = 1;
            // 
            // btnCreateModpack
            // 
            this.btnCreateModpack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.btnCreateModpack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateModpack.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateModpack.FlatAppearance.BorderSize = 0;
            this.btnCreateModpack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateModpack.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.btnCreateModpack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnCreateModpack.Location = new System.Drawing.Point(10, 10);
            this.btnCreateModpack.Name = "btnCreateModpack";
            this.btnCreateModpack.Size = new System.Drawing.Size(175, 38);
            this.btnCreateModpack.TabIndex = 0;
            this.btnCreateModpack.Text = "➕ Mod Paketi Oluştur";
            this.btnCreateModpack.UseVisualStyleBackColor = false;
            // 
            // lblRecentModpacksTitle
            // 
            this.lblRecentModpacksTitle.AutoSize = true;
            this.lblRecentModpacksTitle.Font = new System.Drawing.Font("Segoe UI Bold", 8.5F);
            this.lblRecentModpacksTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(175)))));
            this.lblRecentModpacksTitle.Location = new System.Drawing.Point(10, 58);
            this.lblRecentModpacksTitle.Name = "lblRecentModpacksTitle";
            this.lblRecentModpacksTitle.Size = new System.Drawing.Size(155, 15);
            this.lblRecentModpacksTitle.TabIndex = 1;
            this.lblRecentModpacksTitle.Text = "⏱️ Son Oynanan 5 Paket:";
            // 
            // lstRecentModpacks
            // 
            this.lstRecentModpacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.lstRecentModpacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRecentModpacks.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lstRecentModpacks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.lstRecentModpacks.FormattingEnabled = true;
            this.lstRecentModpacks.ItemHeight = 15;
            this.lstRecentModpacks.Location = new System.Drawing.Point(10, 80);
            this.lstRecentModpacks.Name = "lstRecentModpacks";
            this.lstRecentModpacks.Size = new System.Drawing.Size(175, 220);
            this.lstRecentModpacks.TabIndex = 2;
            // 
            // pnlModsContent
            // 
            this.pnlModsContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.pnlModsContent.Controls.Add(this.lblModsContentPlaceholder);
            this.pnlModsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModsContent.Location = new System.Drawing.Point(195, 48);
            this.pnlModsContent.Name = "pnlModsContent";
            this.pnlModsContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlModsContent.Size = new System.Drawing.Size(703, 315);
            this.pnlModsContent.TabIndex = 2;
            this.pnlModsContent.TabIndex = 2;
            // 
            // lblModsContentPlaceholder
            // 
            this.lblModsContentPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModsContentPlaceholder.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblModsContentPlaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblModsContentPlaceholder.Location = new System.Drawing.Point(20, 20);
            this.lblModsContentPlaceholder.Name = "lblModsContentPlaceholder";
            this.lblModsContentPlaceholder.Size = new System.Drawing.Size(598, 275);
            this.lblModsContentPlaceholder.TabIndex = 0;
            this.lblModsContentPlaceholder.Text = "📁 Tüm Mod Paketleri (Home)\r\n\r\nHenüz kayıtlı özel bir mod paketiniz yok.\r\nSoldaki \"➕ Yeni Mod Paketi Oluştur\" butonuna basarak ilk mod paketinizi hazırlayabilirsiniz.\r\n\r\nSonraki adımda buraya arama, modları doğrudan listeleme ve tek tıkla yükleme entegrasyonu gelecektir.";
            // 
            // pnlMcNews
            // 
            this.pnlMcNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.pnlMcNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMcNews.Controls.Add(this.lblMcNewsWarning);
            this.pnlMcNews.Controls.Add(this.lblMcNewsBody);
            this.pnlMcNews.Controls.Add(this.lblMcNewsTitle);
            this.pnlMcNews.Location = new System.Drawing.Point(0, 0);
            this.pnlMcNews.Name = "pnlMcNews";
            this.pnlMcNews.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMcNews.Size = new System.Drawing.Size(580, 365);
            this.pnlMcNews.TabIndex = 0;
            // 
            // lblMcNewsTitle
            // 
            this.lblMcNewsTitle.AutoSize = true;
            this.lblMcNewsTitle.Font = new System.Drawing.Font("Segoe UI Black", 13F, System.Drawing.FontStyle.Bold);
            this.lblMcNewsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(175)))));
            this.lblMcNewsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblMcNewsTitle.Name = "lblMcNewsTitle";
            this.lblMcNewsTitle.Size = new System.Drawing.Size(370, 25);
            this.lblMcNewsTitle.TabIndex = 0;
            this.lblMcNewsTitle.Text = "⚔️ MINECRAFT SON SÜRÜM YENİLİKLERİ";
            // 
            // lblMcNewsBody
            // 
            this.lblMcNewsBody.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMcNewsBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.lblMcNewsBody.Location = new System.Drawing.Point(15, 50);
            this.lblMcNewsBody.Name = "lblMcNewsBody";
            this.lblMcNewsBody.Size = new System.Drawing.Size(545, 275);
            this.lblMcNewsBody.TabIndex = 1;
            this.lblMcNewsBody.Text = "🌲 Minecraft 26.3 Wilderness Bound Güncellemesi devrede!\r\n\r\n" +
                "• Alacalı Orman Biyomu (Dappled Forest): Kavak ağaçlarıyla dolu yepyeni keşif ormanı.\r\n" +
                "• Kavak Ağaçları & Ahşap Seti: Devrilmiş gövdeler, kırmızı ve sarı kavak yaprakları.\r\n" +
                "• Terk Edilmiş Kamplar & Kaşif Haritaları: Gizli sandıklar ve haritalarla macera.\r\n" +
                "• Saman Yataklar & Minderler: Yıldızların altında kamp kurup hikaye paylaşma imkanı.\r\n" +
                "• Yeni Basamak & Merdivenler: Yün ve beton basamaklar ile mimari tasarım çeşitliliği.\r\n" +
                "• Raf Mantarları ve Kırmızı Çalılar ile zenginleşen vahşi doğa ekosistemi.\r\n\r\n" +
                "💡 Not: Yüklü olan sürümleri internetsiz oynayabilir veya yeni sürümleri seçerek indirebilirsiniz!";
            // 
            // lblMcNewsWarning
            // 
            this.lblMcNewsWarning.AutoSize = true;
            this.lblMcNewsWarning.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMcNewsWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(139)))), ((int)(((byte)(168)))));
            this.lblMcNewsWarning.Location = new System.Drawing.Point(15, 332);
            this.lblMcNewsWarning.Name = "lblMcNewsWarning";
            this.lblMcNewsWarning.Size = new System.Drawing.Size(217, 15);
            this.lblMcNewsWarning.TabIndex = 2;
            this.lblMcNewsWarning.Text = "⚠️ Veri Alınamadı, İnternet Bağlantısı Yok";
            this.lblMcNewsWarning.Visible = false;
            // 
            // pnlLauncherNews
            // 
            this.pnlLauncherNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.pnlLauncherNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLauncherNews.Controls.Add(this.lblLauncherNewsWarning);
            this.pnlLauncherNews.Controls.Add(this.lblLauncherNewsBody);
            this.pnlLauncherNews.Controls.Add(this.lblLauncherNewsTitle);
            this.pnlLauncherNews.Location = new System.Drawing.Point(595, 0);
            this.pnlLauncherNews.Name = "pnlLauncherNews";
            this.pnlLauncherNews.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLauncherNews.Size = new System.Drawing.Size(305, 365);
            this.pnlLauncherNews.TabIndex = 1;
            // 
            // lblLauncherNewsTitle
            // 
            this.lblLauncherNewsTitle.AutoSize = true;
            this.lblLauncherNewsTitle.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.lblLauncherNewsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.lblLauncherNewsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblLauncherNewsTitle.Name = "lblLauncherNewsTitle";
            this.lblLauncherNewsTitle.Size = new System.Drawing.Size(220, 21);
            this.lblLauncherNewsTitle.TabIndex = 0;
            this.lblLauncherNewsTitle.Text = "📢 LAUNCHER DUYURULARI";
            // 
            // lblLauncherNewsBody
            // 
            this.lblLauncherNewsBody.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLauncherNewsBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblLauncherNewsBody.Location = new System.Drawing.Point(15, 55);
            this.lblLauncherNewsBody.Name = "lblLauncherNewsBody";
            this.lblLauncherNewsBody.Size = new System.Drawing.Size(270, 265);
            this.lblLauncherNewsBody.TabIndex = 1;
            this.lblLauncherNewsBody.Text = "🚀 Güncellemeler Denetleniyor...\r\n\r\n" +
                "• Otomatik Güncelleme: Yeni bir sürüm geldiğinde launcher açılışta haber verir.\r\n\r\n" +
                "• Bağımsız Depolama: Orijinal .minecraft klasörüne dokunulmaz (%appdata%\\AlpsidMCL).\r\n\r\n" +
                "• Otomatik Ayar Kaydı: Kullanıcı adı ve ayarlarınız artık hafızada tutuluyor.\r\n\r\n" +
                "• Yakında: Özel mod paketi ve profil oluşturma sistemi!";
            // 
            // lblLauncherNewsWarning
            // 
            this.lblLauncherNewsWarning.AutoSize = true;
            this.lblLauncherNewsWarning.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLauncherNewsWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(139)))), ((int)(((byte)(168)))));
            this.lblLauncherNewsWarning.Location = new System.Drawing.Point(15, 332);
            this.lblLauncherNewsWarning.Name = "lblLauncherNewsWarning";
            this.lblLauncherNewsWarning.Size = new System.Drawing.Size(217, 15);
            this.lblLauncherNewsWarning.TabIndex = 2;
            this.lblLauncherNewsWarning.Text = "⚠️ Veri Alınamadı, İnternet Bağlantısı Yok";
            this.lblLauncherNewsWarning.Visible = false;
            // 
            // lblDurum
            // 
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDurum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.lblDurum.Location = new System.Drawing.Point(20, 440);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(900, 20);
            this.lblDurum.TabIndex = 3;
            this.lblDurum.Text = "Hazır.";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.progressBar1.Location = new System.Drawing.Point(20, 465);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(900, 8);
            this.progressBar1.TabIndex = 4;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.lblKullaniciAdi);
            this.pnlBottom.Controls.Add(this.txtKullaniciAdi);
            this.pnlBottom.Controls.Add(this.lblSurum);
            this.pnlBottom.Controls.Add(this.cmbSurumler);
            this.pnlBottom.Controls.Add(this.lblRam);
            this.pnlBottom.Controls.Add(this.cmbRam);
            this.pnlBottom.Controls.Add(this.btnAlpsidMods);
            this.pnlBottom.Controls.Add(this.btnOyna);
            this.pnlBottom.Controls.Add(this.btnSettings);
            this.pnlBottom.Controls.Add(this.btnFolder);
            this.pnlBottom.Location = new System.Drawing.Point(20, 485);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(900, 75);
            this.pnlBottom.TabIndex = 5;
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblKullaniciAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblKullaniciAdi.Location = new System.Drawing.Point(20, 12);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(76, 15);
            this.lblKullaniciAdi.TabIndex = 0;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.txtKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.txtKullaniciAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(224)))), ((int)(((byte)(220)))));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(20, 32);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(200, 27);
            this.txtKullaniciAdi.TabIndex = 1;
            this.txtKullaniciAdi.Text = "Oyuncu";
            // 
            // lblSurum
            // 
            this.lblSurum.AutoSize = true;
            this.lblSurum.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSurum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblSurum.Location = new System.Drawing.Point(240, 12);
            this.lblSurum.Name = "lblSurum";
            this.lblSurum.Size = new System.Drawing.Size(103, 15);
            this.lblSurum.TabIndex = 2;
            this.lblSurum.Text = "Minecraft Sürümü:";
            // 
            // cmbSurumler
            // 
            this.cmbSurumler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.cmbSurumler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSurumler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSurumler.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.cmbSurumler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.cmbSurumler.FormattingEnabled = true;
            this.cmbSurumler.Location = new System.Drawing.Point(240, 32);
            this.cmbSurumler.Name = "cmbSurumler";
            this.cmbSurumler.Size = new System.Drawing.Size(220, 27);
            this.cmbSurumler.TabIndex = 3;
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblRam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(173)))), ((int)(((byte)(200)))));
            this.lblRam.Location = new System.Drawing.Point(480, 12);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(35, 15);
            this.lblRam.TabIndex = 4;
            this.lblRam.Text = "RAM:";
            // 
            // cmbRam
            // 
            this.cmbRam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.cmbRam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRam.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.cmbRam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.cmbRam.FormattingEnabled = true;
            this.cmbRam.Location = new System.Drawing.Point(480, 32);
            this.cmbRam.Name = "cmbRam";
            this.cmbRam.Size = new System.Drawing.Size(120, 27);
            this.cmbRam.TabIndex = 5;
            // 
            // btnAlpsidMods
            // 
            this.btnAlpsidMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(166)))), ((int)(((byte)(247)))));
            this.btnAlpsidMods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlpsidMods.FlatAppearance.BorderSize = 0;
            this.btnAlpsidMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlpsidMods.Font = new System.Drawing.Font("Segoe UI Black", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAlpsidMods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnAlpsidMods.Location = new System.Drawing.Point(615, 15);
            this.btnAlpsidMods.Name = "btnAlpsidMods";
            this.btnAlpsidMods.Size = new System.Drawing.Size(65, 45);
            this.btnAlpsidMods.TabIndex = 6;
            this.btnAlpsidMods.Text = "📦\nMods";
            this.btnAlpsidMods.UseVisualStyleBackColor = false;
            // 
            // btnOyna
            // 
            this.btnOyna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(227)))), ((int)(((byte)(161)))));
            this.btnOyna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOyna.FlatAppearance.BorderSize = 0;
            this.btnOyna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOyna.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold);
            this.btnOyna.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnOyna.Location = new System.Drawing.Point(688, 15);
            this.btnOyna.Name = "btnOyna";
            this.btnOyna.Size = new System.Drawing.Size(120, 45);
            this.btnOyna.TabIndex = 7;
            this.btnOyna.Text = "🎮 OYNA";
            this.btnOyna.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(214)))), ((int)(((byte)(244)))));
            this.btnSettings.Location = new System.Drawing.Point(816, 15);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(34, 45);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "⚙️";
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnFolder
            // 
            this.btnFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(68)))));
            this.btnFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolder.FlatAppearance.BorderSize = 0;
            this.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolder.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.btnFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(175)))));
            this.btnFolder.Location = new System.Drawing.Point(854, 15);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(34, 45);
            this.btnFolder.TabIndex = 9;
            this.btnFolder.Text = "📁";
            this.btnFolder.UseVisualStyleBackColor = false;
            // 
            // grpModType (Geçici Olarak Gizlendi - Mod Paketi Sisteminde Kullanılacak)
            // 
            this.grpModType.Controls.Add(this.rdbNeoForge);
            this.grpModType.Controls.Add(this.rdbForge);
            this.grpModType.Controls.Add(this.rdbVanilla);
            this.grpModType.Location = new System.Drawing.Point(0, 0);
            this.grpModType.Name = "grpModType";
            this.grpModType.Size = new System.Drawing.Size(10, 10);
            this.grpModType.TabIndex = 6;
            this.grpModType.TabStop = false;
            this.grpModType.Visible = false;
            // 
            // rdbNeoForge
            // 
            this.rdbNeoForge.AutoSize = true;
            this.rdbNeoForge.Location = new System.Drawing.Point(0, 0);
            this.rdbNeoForge.Name = "rdbNeoForge";
            this.rdbNeoForge.Size = new System.Drawing.Size(85, 19);
            this.rdbNeoForge.TabIndex = 2;
            this.rdbNeoForge.Text = "NeoForge";
            // 
            // rdbForge
            // 
            this.rdbForge.AutoSize = true;
            this.rdbForge.Location = new System.Drawing.Point(0, 0);
            this.rdbForge.Name = "rdbForge";
            this.rdbForge.Size = new System.Drawing.Size(55, 19);
            this.rdbForge.TabIndex = 1;
            this.rdbForge.Text = "Forge";
            // 
            // rdbVanilla
            // 
            this.rdbVanilla.AutoSize = true;
            this.rdbVanilla.Checked = true;
            this.rdbVanilla.Location = new System.Drawing.Point(0, 0);
            this.rdbVanilla.Name = "rdbVanilla";
            this.rdbVanilla.Size = new System.Drawing.Size(59, 19);
            this.rdbVanilla.TabIndex = 0;
            this.rdbVanilla.TabStop = true;
            this.rdbVanilla.Text = "Vanilla";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnOyna;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.lblSurumEtiketi);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.grpModType);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alpsid Mc Launcher";
            this.pnlCenter.ResumeLayout(false);
            this.pnlMcNews.ResumeLayout(false);
            this.pnlMcNews.PerformLayout();
            this.pnlLauncherNews.ResumeLayout(false);
            this.pnlLauncherNews.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlModsMenu.ResumeLayout(false);
            this.pnlModsTopBar.ResumeLayout(false);
            this.pnlModsTopBar.PerformLayout();
            this.pnlModsLeft.ResumeLayout(false);
            this.pnlModsLeft.PerformLayout();
            this.pnlModsContent.ResumeLayout(false);
            this.pnlSettingsMenu.ResumeLayout(false);
            this.pnlSettingsTopBar.ResumeLayout(false);
            this.pnlSettingsTopBar.PerformLayout();
            this.pnlSettingsContent.ResumeLayout(false);
            this.grpVersionFilters.ResumeLayout(false);
            this.grpVersionFilters.PerformLayout();
            this.grpWindowSettings.ResumeLayout(false);
            this.grpWindowSettings.PerformLayout();
            this.grpBackupSettings.ResumeLayout(false);
            this.grpBackupSettings.PerformLayout();
            this.grpModType.ResumeLayout(false);
            this.grpModType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblSurumEtiketi;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlSettingsMenu;
        private System.Windows.Forms.Panel pnlSettingsTopBar;
        private System.Windows.Forms.Label lblSettingsTitle;
        private System.Windows.Forms.Button btnCloseSettingsMenu;
        private System.Windows.Forms.Panel pnlSettingsContent;
        private System.Windows.Forms.GroupBox grpVersionFilters;
        private System.Windows.Forms.CheckBox chkShowSnapshots;
        private System.Windows.Forms.CheckBox chkShowBetas;
        private System.Windows.Forms.CheckBox chkShowAlphas;
        private System.Windows.Forms.GroupBox grpWindowSettings;
        private System.Windows.Forms.CheckBox chkResizableWindow;
        private System.Windows.Forms.Label lblWindowSizeHint;
        private System.Windows.Forms.GroupBox grpBackupSettings;
        private System.Windows.Forms.CheckBox chkEnableBackup;
        private System.Windows.Forms.Label lblMaxBackupSize;
        private System.Windows.Forms.ComboBox cmbMaxBackupSize;
        private System.Windows.Forms.Label lblBackupRetention;
        private System.Windows.Forms.ComboBox cmbBackupRetention;
        private System.Windows.Forms.Label lblBackupFrequency;
        private System.Windows.Forms.ComboBox cmbBackupFrequency;
        private System.Windows.Forms.Button btnBackupNow;
        private System.Windows.Forms.Panel pnlModsMenu;
        private System.Windows.Forms.Panel pnlModsTopBar;
        private System.Windows.Forms.Button btnNavHome;
        private System.Windows.Forms.Button btnNavMods;
        private System.Windows.Forms.Button btnNavResourcePacks;
        private System.Windows.Forms.Button btnNavShaders;
        private System.Windows.Forms.ComboBox cmbSortMods;
        private System.Windows.Forms.TextBox txtModSearch;
        private System.Windows.Forms.Button btnCloseModsMenu;
        private System.Windows.Forms.Panel pnlModsLeft;
        private System.Windows.Forms.Button btnCreateModpack;
        private System.Windows.Forms.Label lblRecentModpacksTitle;
        private System.Windows.Forms.ListBox lstRecentModpacks;
        private System.Windows.Forms.Panel pnlModsContent;
        private System.Windows.Forms.Label lblModsContentPlaceholder;
        private System.Windows.Forms.Panel pnlMcNews;
        private System.Windows.Forms.Label lblMcNewsTitle;
        private System.Windows.Forms.Label lblMcNewsBody;
        private System.Windows.Forms.Label lblMcNewsWarning;
        private System.Windows.Forms.Panel pnlLauncherNews;
        private System.Windows.Forms.Label lblLauncherNewsTitle;
        private System.Windows.Forms.Label lblLauncherNewsBody;
        private System.Windows.Forms.Label lblLauncherNewsWarning;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label lblSurum;
        private System.Windows.Forms.ComboBox cmbSurumler;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.ComboBox cmbRam;
        private System.Windows.Forms.Button btnAlpsidMods;
        private System.Windows.Forms.Button btnOyna;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox grpModType;
        private System.Windows.Forms.RadioButton rdbNeoForge;
        private System.Windows.Forms.RadioButton rdbForge;
        private System.Windows.Forms.RadioButton rdbVanilla;
    }
}
