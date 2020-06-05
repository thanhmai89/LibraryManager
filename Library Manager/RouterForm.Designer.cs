namespace Library_Manager
{
    partial class RouterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouterForm));
            this.imgBook = new System.Windows.Forms.PictureBox();
            this.imgUser = new System.Windows.Forms.PictureBox();
            this.imgBorrow = new System.Windows.Forms.PictureBox();
            this.imgData = new System.Windows.Forms.PictureBox();
            this.toolTipBook = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipUser = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipBorrow = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipData = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tácVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thẻThưViệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuMượnSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dữLiệuHệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiệnÍchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.lblAccount = new System.Windows.Forms.ToolStripLabel();
            this.lblTimeSys = new System.Windows.Forms.ToolStripLabel();
            this.timeSystem = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBorrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgBook
            // 
            this.imgBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBook.Image = ((System.Drawing.Image)(resources.GetObject("imgBook.Image")));
            this.imgBook.Location = new System.Drawing.Point(30, 30);
            this.imgBook.Name = "imgBook";
            this.imgBook.Size = new System.Drawing.Size(180, 180);
            this.imgBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBook.TabIndex = 0;
            this.imgBook.TabStop = false;
            this.imgBook.Tag = "BookForm";
            this.imgBook.Click += new System.EventHandler(this.imgGoToForm_Click);
            // 
            // imgUser
            // 
            this.imgUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgUser.Image = ((System.Drawing.Image)(resources.GetObject("imgUser.Image")));
            this.imgUser.Location = new System.Drawing.Point(240, 30);
            this.imgUser.Name = "imgUser";
            this.imgUser.Size = new System.Drawing.Size(180, 180);
            this.imgUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgUser.TabIndex = 1;
            this.imgUser.TabStop = false;
            this.imgUser.Tag = "StudentForm";
            this.imgUser.Click += new System.EventHandler(this.imgGoToForm_Click);
            // 
            // imgBorrow
            // 
            this.imgBorrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBorrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBorrow.Image = ((System.Drawing.Image)(resources.GetObject("imgBorrow.Image")));
            this.imgBorrow.Location = new System.Drawing.Point(30, 240);
            this.imgBorrow.Name = "imgBorrow";
            this.imgBorrow.Size = new System.Drawing.Size(180, 180);
            this.imgBorrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBorrow.TabIndex = 2;
            this.imgBorrow.TabStop = false;
            this.imgBorrow.Tag = "BorrowForm";
            this.imgBorrow.Click += new System.EventHandler(this.imgGoToForm_Click);
            // 
            // imgData
            // 
            this.imgData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgData.Image = ((System.Drawing.Image)(resources.GetObject("imgData.Image")));
            this.imgData.Location = new System.Drawing.Point(240, 240);
            this.imgData.Name = "imgData";
            this.imgData.Size = new System.Drawing.Size(180, 180);
            this.imgData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgData.TabIndex = 3;
            this.imgData.TabStop = false;
            this.imgData.Tag = "DataForm";
            this.imgData.Click += new System.EventHandler(this.imgGoToForm_Click);
            // 
            // toolTipBook
            // 
            this.toolTipBook.AutomaticDelay = 100;
            this.toolTipBook.AutoPopDelay = 10000;
            this.toolTipBook.InitialDelay = 100;
            this.toolTipBook.ReshowDelay = 20;
            // 
            // toolTipUser
            // 
            this.toolTipUser.AutomaticDelay = 100;
            this.toolTipUser.AutoPopDelay = 10000;
            this.toolTipUser.InitialDelay = 100;
            this.toolTipUser.ReshowDelay = 20;
            // 
            // toolTipBorrow
            // 
            this.toolTipBorrow.AutomaticDelay = 100;
            this.toolTipBorrow.AutoPopDelay = 10000;
            this.toolTipBorrow.InitialDelay = 100;
            this.toolTipBorrow.ReshowDelay = 20;
            // 
            // toolTipData
            // 
            this.toolTipData.AutomaticDelay = 100;
            this.toolTipData.AutoPopDelay = 10000;
            this.toolTipData.InitialDelay = 100;
            this.toolTipData.ReshowDelay = 20;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.tácVụToolStripMenuItem,
            this.tiệnÍchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(451, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // tácVụToolStripMenuItem
            // 
            this.tácVụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sáchToolStripMenuItem,
            this.thẻThưViệnToolStripMenuItem,
            this.phiếuMượnSáchToolStripMenuItem,
            this.dữLiệuHệThốngToolStripMenuItem});
            this.tácVụToolStripMenuItem.Name = "tácVụToolStripMenuItem";
            this.tácVụToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.tácVụToolStripMenuItem.Text = "Tác vụ";
            // 
            // sáchToolStripMenuItem
            // 
            this.sáchToolStripMenuItem.Name = "sáchToolStripMenuItem";
            this.sáchToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.sáchToolStripMenuItem.Text = "Sách";
            this.sáchToolStripMenuItem.Click += new System.EventHandler(this.sáchToolStripMenuItem_Click);
            // 
            // thẻThưViệnToolStripMenuItem
            // 
            this.thẻThưViệnToolStripMenuItem.Name = "thẻThưViệnToolStripMenuItem";
            this.thẻThưViệnToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.thẻThưViệnToolStripMenuItem.Text = "Thẻ thư viện";
            this.thẻThưViệnToolStripMenuItem.Click += new System.EventHandler(this.thẻThưViệnToolStripMenuItem_Click);
            // 
            // phiếuMượnSáchToolStripMenuItem
            // 
            this.phiếuMượnSáchToolStripMenuItem.Name = "phiếuMượnSáchToolStripMenuItem";
            this.phiếuMượnSáchToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.phiếuMượnSáchToolStripMenuItem.Text = "Phiếu mượn sách";
            this.phiếuMượnSáchToolStripMenuItem.Click += new System.EventHandler(this.phiếuMượnSáchToolStripMenuItem_Click);
            // 
            // dữLiệuHệThốngToolStripMenuItem
            // 
            this.dữLiệuHệThốngToolStripMenuItem.Name = "dữLiệuHệThốngToolStripMenuItem";
            this.dữLiệuHệThốngToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.dữLiệuHệThốngToolStripMenuItem.Text = "Dữ liệu hệ thống";
            this.dữLiệuHệThốngToolStripMenuItem.Click += new System.EventHandler(this.dữLiệuHệThốngToolStripMenuItem_Click);
            // 
            // tiệnÍchToolStripMenuItem
            // 
            this.tiệnÍchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinToolStripMenuItem});
            this.tiệnÍchToolStripMenuItem.Name = "tiệnÍchToolStripMenuItem";
            this.tiệnÍchToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.tiệnÍchToolStripMenuItem.Text = "Tiện ích";
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thôngTinToolStripMenuItem.Text = "Thông tin";
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Silver;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAccount,
            this.lblTimeSys});
            this.toolStrip2.Location = new System.Drawing.Point(0, 429);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(451, 25);
            this.toolStrip2.TabIndex = 37;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // lblAccount
            // 
            this.lblAccount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(65, 22);
            this.lblAccount.Text = "lblAccount";
            // 
            // lblTimeSys
            // 
            this.lblTimeSys.Name = "lblTimeSys";
            this.lblTimeSys.Size = new System.Drawing.Size(47, 22);
            this.lblTimeSys.Text = "lblTime";
            // 
            // timeSystem
            // 
            this.timeSystem.Enabled = true;
            this.timeSystem.Interval = 1000;
            this.timeSystem.Tick += new System.EventHandler(this.timeSystem_Tick);
            // 
            // RouterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 454);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.imgData);
            this.Controls.Add(this.imgBorrow);
            this.Controls.Add(this.imgUser);
            this.Controls.Add(this.imgBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RouterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn tác vụ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RouterForm_FormClosing);
            this.Load += new System.EventHandler(this.RouterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBorrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBook;
        private System.Windows.Forms.PictureBox imgUser;
        private System.Windows.Forms.PictureBox imgBorrow;
        private System.Windows.Forms.PictureBox imgData;
        private System.Windows.Forms.ToolTip toolTipBook;
        private System.Windows.Forms.ToolTip toolTipUser;
        private System.Windows.Forms.ToolTip toolTipBorrow;
        private System.Windows.Forms.ToolTip toolTipData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tácVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thẻThưViệnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuMượnSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dữLiệuHệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiệnÍchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel lblAccount;
        private System.Windows.Forms.ToolStripLabel lblTimeSys;
        private System.Windows.Forms.Timer timeSystem;
    }
}