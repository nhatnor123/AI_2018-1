namespace Caro
{
    partial class frmCoCaro
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlayerVsPlayer = new DevComponents.DotNetBar.ButtonX();
            this.btnPlayerVsCom = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnChoiMoi = new DevComponents.DotNetBar.ButtonX();
            this.pnlBanCo = new System.Windows.Forms.Panel();
            this.tmChuChay = new System.Windows.Forms.Timer(this.components);
            this.lblChuoiChu = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ptbPvC = new System.Windows.Forms.PictureBox();
            this.ptbPvP = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUndo = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPvC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPvP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1210, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerToolStripMenuItem,
            this.playerVsComToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "New Game";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // playerVsPlayerToolStripMenuItem
            // 
            this.playerVsPlayerToolStripMenuItem.Name = "playerVsPlayerToolStripMenuItem";
            this.playerVsPlayerToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.playerVsPlayerToolStripMenuItem.Text = "Player vs Player";
            this.playerVsPlayerToolStripMenuItem.Click += new System.EventHandler(this.PvsP);
            // 
            // playerVsComToolStripMenuItem
            // 
            this.playerVsComToolStripMenuItem.Name = "playerVsComToolStripMenuItem";
            this.playerVsComToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.playerVsComToolStripMenuItem.Text = "Player  vs Com";
            this.playerVsComToolStripMenuItem.Click += new System.EventHandler(this.playerVsComToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnPlayerVsPlayer
            // 
            this.btnPlayerVsPlayer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPlayerVsPlayer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPlayerVsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerVsPlayer.Location = new System.Drawing.Point(11, 573);
            this.btnPlayerVsPlayer.Name = "btnPlayerVsPlayer";
            this.btnPlayerVsPlayer.Size = new System.Drawing.Size(187, 48);
            this.btnPlayerVsPlayer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPlayerVsPlayer.TabIndex = 3;
            this.btnPlayerVsPlayer.Text = "Player vs Player";
            this.btnPlayerVsPlayer.Click += new System.EventHandler(this.btnPlayerVsPlayer_Click);
            // 
            // btnPlayerVsCom
            // 
            this.btnPlayerVsCom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPlayerVsCom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPlayerVsCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerVsCom.Location = new System.Drawing.Point(12, 637);
            this.btnPlayerVsCom.Name = "btnPlayerVsCom";
            this.btnPlayerVsCom.Size = new System.Drawing.Size(187, 41);
            this.btnPlayerVsCom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPlayerVsCom.TabIndex = 4;
            this.btnPlayerVsCom.Text = "Player vs Com";
            this.btnPlayerVsCom.Click += new System.EventHandler(this.btnPlayerVsCom_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(12, 703);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(82, 39);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnChoiMoi
            // 
            this.btnChoiMoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChoiMoi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChoiMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoiMoi.Location = new System.Drawing.Point(124, 703);
            this.btnChoiMoi.Name = "btnChoiMoi";
            this.btnChoiMoi.Size = new System.Drawing.Size(75, 39);
            this.btnChoiMoi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChoiMoi.TabIndex = 6;
            this.btnChoiMoi.Text = "Chơi mới";
            this.btnChoiMoi.Click += new System.EventHandler(this.btnChoiMoi_Click);
            // 
            // pnlBanCo
            // 
            this.pnlBanCo.BackColor = System.Drawing.Color.Silver;
            this.pnlBanCo.Location = new System.Drawing.Point(337, 88);
            this.pnlBanCo.Name = "pnlBanCo";
            this.pnlBanCo.Size = new System.Drawing.Size(810, 746);
            this.pnlBanCo.TabIndex = 7;
            this.pnlBanCo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBanCo_Paint);
            this.pnlBanCo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBanCo_MouseClick);
            // 
            // tmChuChay
            // 
            this.tmChuChay.Interval = 1000;
            this.tmChuChay.Tick += new System.EventHandler(this.tmChuChay_Tick);
            // 
            // lblChuoiChu
            // 
            // 
            // 
            // 
            this.lblChuoiChu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblChuoiChu.Location = new System.Drawing.Point(0, 23);
            this.lblChuoiChu.Name = "lblChuoiChu";
            this.lblChuoiChu.Size = new System.Drawing.Size(186, 295);
            this.lblChuoiChu.TabIndex = 0;
            this.lblChuoiChu.Click += new System.EventHandler(this.lblChuoiChu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblChuoiChu);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 318);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Luật chơi :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(923, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = ".";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Caro.Properties.Resources.x;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(846, 40);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 28);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Caro.Properties.Resources.o;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(443, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 28);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // ptbPvC
            // 
            this.ptbPvC.BackColor = System.Drawing.SystemColors.Control;
            this.ptbPvC.Image = global::Caro.Properties.Resources.fingerLeft;
            this.ptbPvC.Location = new System.Drawing.Point(205, 637);
            this.ptbPvC.Name = "ptbPvC";
            this.ptbPvC.Size = new System.Drawing.Size(45, 48);
            this.ptbPvC.TabIndex = 9;
            this.ptbPvC.TabStop = false;
            // 
            // ptbPvP
            // 
            this.ptbPvP.BackColor = System.Drawing.SystemColors.Control;
            this.ptbPvP.Image = global::Caro.Properties.Resources.fingerLeft;
            this.ptbPvP.Location = new System.Drawing.Point(204, 573);
            this.ptbPvP.Name = "ptbPvP";
            this.ptbPvP.Size = new System.Drawing.Size(46, 48);
            this.ptbPvP.TabIndex = 8;
            this.ptbPvP.TabStop = false;
            this.ptbPvP.Click += new System.EventHandler(this.ptbPvP_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Caro.Properties.Resources.tic_tac_toe;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 167);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnUndo
            // 
            this.btnUndo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUndo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Location = new System.Drawing.Point(204, 45);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(102, 48);
            this.btnUndo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUndo.TabIndex = 14;
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Location = new System.Drawing.Point(205, 126);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(101, 46);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 15;
            this.buttonX2.Text = "Redo";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // frmCoCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 932);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ptbPvC);
            this.Controls.Add(this.ptbPvP);
            this.Controls.Add(this.pnlBanCo);
            this.Controls.Add(this.btnChoiMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnPlayerVsCom);
            this.Controls.Add(this.btnPlayerVsPlayer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCoCaro";
            this.Text = "Cờ Caro";
            this.Load += new System.EventHandler(this.frmCoCaro_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPvC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPvP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsComToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX btnPlayerVsPlayer;
        private DevComponents.DotNetBar.ButtonX btnPlayerVsCom;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnChoiMoi;
        private System.Windows.Forms.Panel pnlBanCo;
        private System.Windows.Forms.Timer tmChuChay;
        private DevComponents.DotNetBar.LabelX lblChuoiChu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox ptbPvP;
        private System.Windows.Forms.PictureBox ptbPvC;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnUndo;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}

