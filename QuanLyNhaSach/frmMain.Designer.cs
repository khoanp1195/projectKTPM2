
namespace QuanLyNhaSach
{
    partial class frnMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frnMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategoryProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThemHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimDMHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTimKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoKhoHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuiEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCapNhat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewCasade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewTH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewTV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTienIch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMayAnh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMayTinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.Times = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhMuc,
            this.mnuHoaDon,
            this.mnuTimKiem,
            this.mnuBaoCao,
            this.mnuGuiEmail,
            this.mnuAdmin,
            this.mnuSort,
            this.mnuTienIch,
            this.mnuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 39);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCategoryProduct,
            this.mnuHangHoa,
            this.toolStripMenuItem1,
            this.mnuKhachHang,
            this.mnuNhanVien});
            this.mnuDanhMuc.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.mnuDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("mnuDanhMuc.Image")));
            this.mnuDanhMuc.Margin = new System.Windows.Forms.Padding(2);
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Padding = new System.Windows.Forms.Padding(5);
            this.mnuDanhMuc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.mnuDanhMuc.Size = new System.Drawing.Size(103, 31);
            this.mnuDanhMuc.Text = "&Danh mục";
            this.mnuDanhMuc.ToolTipText = "Category";
            // 
            // mnuCategoryProduct
            // 
            this.mnuCategoryProduct.Image = ((System.Drawing.Image)(resources.GetObject("mnuCategoryProduct.Image")));
            this.mnuCategoryProduct.Name = "mnuCategoryProduct";
            this.mnuCategoryProduct.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuCategoryProduct.Size = new System.Drawing.Size(257, 22);
            this.mnuCategoryProduct.Text = "&Danh mục hàng hoá";
            this.mnuCategoryProduct.ToolTipText = "Category Product";
            this.mnuCategoryProduct.Click += new System.EventHandler(this.mnuCategoryProduct_Click);
            // 
            // mnuHangHoa
            // 
            this.mnuHangHoa.Image = ((System.Drawing.Image)(resources.GetObject("mnuHangHoa.Image")));
            this.mnuHangHoa.Margin = new System.Windows.Forms.Padding(2);
            this.mnuHangHoa.Name = "mnuHangHoa";
            this.mnuHangHoa.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.mnuHangHoa.Size = new System.Drawing.Size(257, 22);
            this.mnuHangHoa.Text = "&Hàng hoá";
            this.mnuHangHoa.ToolTipText = "Product";
            this.mnuHangHoa.Click += new System.EventHandler(this.mnuHangHoa_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(254, 6);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("mnuKhachHang.Image")));
            this.mnuKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.K)));
            this.mnuKhachHang.Size = new System.Drawing.Size(257, 22);
            this.mnuKhachHang.Text = "&Khách hàng";
            this.mnuKhachHang.ToolTipText = "Customer";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("mnuNhanVien.Image")));
            this.mnuNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.mnuNhanVien.Size = new System.Drawing.Size(257, 22);
            this.mnuNhanVien.Text = "&Nhân viên";
            this.mnuNhanVien.ToolTipText = "Employee";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuHoaDon
            // 
            this.mnuHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThemHoaDon,
            this.mnuQuanLyHoaDon});
            this.mnuHoaDon.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.mnuHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("mnuHoaDon.Image")));
            this.mnuHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.mnuHoaDon.Name = "mnuHoaDon";
            this.mnuHoaDon.Padding = new System.Windows.Forms.Padding(5);
            this.mnuHoaDon.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuHoaDon.Size = new System.Drawing.Size(93, 31);
            this.mnuHoaDon.Text = "&Hoá đơn";
            this.mnuHoaDon.ToolTipText = "Bill";
            // 
            // mnuThemHoaDon
            // 
            this.mnuThemHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("mnuThemHoaDon.Image")));
            this.mnuThemHoaDon.Name = "mnuThemHoaDon";
            this.mnuThemHoaDon.Size = new System.Drawing.Size(181, 22);
            this.mnuThemHoaDon.Text = "Thêm hoá đơn";
            this.mnuThemHoaDon.Click += new System.EventHandler(this.mnuThemHoaDon_Click);
            // 
            // mnuQuanLyHoaDon
            // 
            this.mnuQuanLyHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("mnuQuanLyHoaDon.Image")));
            this.mnuQuanLyHoaDon.Name = "mnuQuanLyHoaDon";
            this.mnuQuanLyHoaDon.Size = new System.Drawing.Size(181, 22);
            this.mnuQuanLyHoaDon.Text = "Quản lý hoá đơn";
            this.mnuQuanLyHoaDon.Click += new System.EventHandler(this.mnuQuanLyHoaDon_Click);
            // 
            // mnuTimKiem
            // 
            this.mnuTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuTimKiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimDMHangHoa,
            this.mnuTimHangHoa,
            this.toolStripMenuItem2,
            this.mnuTimKhachHang,
            this.mnuTimNhanVien});
            this.mnuTimKiem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.mnuTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("mnuTimKiem.Image")));
            this.mnuTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.mnuTimKiem.Name = "mnuTimKiem";
            this.mnuTimKiem.Padding = new System.Windows.Forms.Padding(5);
            this.mnuTimKiem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuTimKiem.Size = new System.Drawing.Size(101, 31);
            this.mnuTimKiem.Text = "&Tìm kiếm";
            this.mnuTimKiem.ToolTipText = "Search";
            // 
            // mnuTimDMHangHoa
            // 
            this.mnuTimDMHangHoa.Image = ((System.Drawing.Image)(resources.GetObject("mnuTimDMHangHoa.Image")));
            this.mnuTimDMHangHoa.Name = "mnuTimDMHangHoa";
            this.mnuTimDMHangHoa.Size = new System.Drawing.Size(230, 22);
            this.mnuTimDMHangHoa.Text = "Tìm danh mục hàng hoá";
            this.mnuTimDMHangHoa.Click += new System.EventHandler(this.mnuTimDMHangHoa_Click);
            // 
            // mnuTimHangHoa
            // 
            this.mnuTimHangHoa.Image = ((System.Drawing.Image)(resources.GetObject("mnuTimHangHoa.Image")));
            this.mnuTimHangHoa.Name = "mnuTimHangHoa";
            this.mnuTimHangHoa.Size = new System.Drawing.Size(230, 22);
            this.mnuTimHangHoa.Text = "Tìm hàng hoá";
            this.mnuTimHangHoa.Click += new System.EventHandler(this.mnuTimHangHoa_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(227, 6);
            // 
            // mnuTimKhachHang
            // 
            this.mnuTimKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("mnuTimKhachHang.Image")));
            this.mnuTimKhachHang.Name = "mnuTimKhachHang";
            this.mnuTimKhachHang.Size = new System.Drawing.Size(230, 22);
            this.mnuTimKhachHang.Text = "Tìm khách hàng";
            this.mnuTimKhachHang.Click += new System.EventHandler(this.mnuTimKhachHang_Click);
            // 
            // mnuTimNhanVien
            // 
            this.mnuTimNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("mnuTimNhanVien.Image")));
            this.mnuTimNhanVien.Name = "mnuTimNhanVien";
            this.mnuTimNhanVien.Size = new System.Drawing.Size(230, 22);
            this.mnuTimNhanVien.Text = "Tìm nhân viên";
            this.mnuTimNhanVien.Click += new System.EventHandler(this.mnuTimNhanVien_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoKhoHàngToolStripMenuItem});
            this.mnuBaoCao.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.mnuBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("mnuBaoCao.Image")));
            this.mnuBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Padding = new System.Windows.Forms.Padding(5);
            this.mnuBaoCao.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.mnuBaoCao.Size = new System.Drawing.Size(90, 31);
            this.mnuBaoCao.Text = "&Báo cáo";
            this.mnuBaoCao.ToolTipText = "Report";
            // 
            // báoCáoKhoHàngToolStripMenuItem
            // 
            this.báoCáoKhoHàngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("báoCáoKhoHàngToolStripMenuItem.Image")));
            this.báoCáoKhoHàngToolStripMenuItem.Name = "báoCáoKhoHàngToolStripMenuItem";
            this.báoCáoKhoHàngToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.báoCáoKhoHàngToolStripMenuItem.Text = "Báo cáo kho hàng";
            this.báoCáoKhoHàngToolStripMenuItem.Click += new System.EventHandler(this.mnuReportProduct);
            // 
            // mnuGuiEmail
            // 
            this.mnuGuiEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuGuiEmail.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.mnuGuiEmail.Image = ((System.Drawing.Image)(resources.GetObject("mnuGuiEmail.Image")));
            this.mnuGuiEmail.Margin = new System.Windows.Forms.Padding(2);
            this.mnuGuiEmail.Name = "mnuGuiEmail";
            this.mnuGuiEmail.Padding = new System.Windows.Forms.Padding(5);
            this.mnuGuiEmail.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuGuiEmail.Size = new System.Drawing.Size(101, 31);
            this.mnuGuiEmail.Text = "&Gửi email";
            this.mnuGuiEmail.ToolTipText = "Send Email";
            this.mnuGuiEmail.Click += new System.EventHandler(this.mnuGuiEmail_Click);
            // 
            // mnuAdmin
            // 
            this.mnuAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCapNhat,
            this.mnuDangXuat});
            this.mnuAdmin.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.mnuAdmin.Image = ((System.Drawing.Image)(resources.GetObject("mnuAdmin.Image")));
            this.mnuAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.mnuAdmin.Name = "mnuAdmin";
            this.mnuAdmin.Padding = new System.Windows.Forms.Padding(5);
            this.mnuAdmin.Size = new System.Drawing.Size(30, 31);
            this.mnuAdmin.ToolTipText = "About";
            // 
            // mnuCapNhat
            // 
            this.mnuCapNhat.Name = "mnuCapNhat";
            this.mnuCapNhat.Size = new System.Drawing.Size(68, 22);
            this.mnuCapNhat.Click += new System.EventHandler(this.mnuCapNhat_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(68, 22);
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuSort
            // 
            this.mnuSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewArrangeIcons,
            this.mnuViewCasade,
            this.mnuViewTH,
            this.mnuViewTV});
            this.mnuSort.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuSort.Image = ((System.Drawing.Image)(resources.GetObject("mnuSort.Image")));
            this.mnuSort.Margin = new System.Windows.Forms.Padding(2);
            this.mnuSort.Name = "mnuSort";
            this.mnuSort.Padding = new System.Windows.Forms.Padding(5);
            this.mnuSort.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.mnuSort.Size = new System.Drawing.Size(101, 31);
            this.mnuSort.Text = "&Tuỳ chỉnh";
            this.mnuSort.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.mnuSort.ToolTipText = "File";
            // 
            // mnuViewArrangeIcons
            // 
            this.mnuViewArrangeIcons.Name = "mnuViewArrangeIcons";
            this.mnuViewArrangeIcons.Size = new System.Drawing.Size(174, 22);
            this.mnuViewArrangeIcons.Text = "Arrange Icons";
            this.mnuViewArrangeIcons.Click += new System.EventHandler(this.mnuViewArrangeIcons_Click);
            // 
            // mnuViewCasade
            // 
            this.mnuViewCasade.Name = "mnuViewCasade";
            this.mnuViewCasade.Size = new System.Drawing.Size(174, 22);
            this.mnuViewCasade.Text = "Casede";
            this.mnuViewCasade.Click += new System.EventHandler(this.mnuViewCasade_Click);
            // 
            // mnuViewTH
            // 
            this.mnuViewTH.Name = "mnuViewTH";
            this.mnuViewTH.Size = new System.Drawing.Size(174, 22);
            this.mnuViewTH.Text = "Tile Horizontal";
            this.mnuViewTH.Click += new System.EventHandler(this.mnuViewTH_Click);
            // 
            // mnuViewTV
            // 
            this.mnuViewTV.Name = "mnuViewTV";
            this.mnuViewTV.Size = new System.Drawing.Size(174, 22);
            this.mnuViewTV.Text = "Tile Vertical";
            this.mnuViewTV.Click += new System.EventHandler(this.mnuViewTV_Click);
            // 
            // mnuTienIch
            // 
            this.mnuTienIch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuTienIch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMayAnh,
            this.mnuMayTinh});
            this.mnuTienIch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.mnuTienIch.Image = ((System.Drawing.Image)(resources.GetObject("mnuTienIch.Image")));
            this.mnuTienIch.Margin = new System.Windows.Forms.Padding(2);
            this.mnuTienIch.Name = "mnuTienIch";
            this.mnuTienIch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.mnuTienIch.Size = new System.Drawing.Size(89, 31);
            this.mnuTienIch.Text = "&Tiện ích";
            this.mnuTienIch.ToolTipText = "Extensions";
            // 
            // mnuMayAnh
            // 
            this.mnuMayAnh.Image = ((System.Drawing.Image)(resources.GetObject("mnuMayAnh.Image")));
            this.mnuMayAnh.Name = "mnuMayAnh";
            this.mnuMayAnh.Size = new System.Drawing.Size(134, 22);
            this.mnuMayAnh.Text = "Máy ảnh";
            this.mnuMayAnh.Click += new System.EventHandler(this.mnuMayAnh_Click);
            // 
            // mnuMayTinh
            // 
            this.mnuMayTinh.Image = ((System.Drawing.Image)(resources.GetObject("mnuMayTinh.Image")));
            this.mnuMayTinh.Name = "mnuMayTinh";
            this.mnuMayTinh.Size = new System.Drawing.Size(134, 22);
            this.mnuMayTinh.Text = "Máy tính";
            this.mnuMayTinh.Click += new System.EventHandler(this.mnuMayTinh_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuThoat.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.mnuThoat.Image = ((System.Drawing.Image)(resources.GetObject("mnuThoat.Image")));
            this.mnuThoat.Margin = new System.Windows.Forms.Padding(2);
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Padding = new System.Windows.Forms.Padding(5);
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(76, 31);
            this.mnuThoat.Text = "&Thoát";
            this.mnuThoat.ToolTipText = "Exit";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(12, 53);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 19);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(685, 53);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(38, 19);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "Time";
            // 
            // Times
            // 
            this.Times.Enabled = true;
            this.Times.Interval = 1000;
            this.Times.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(114, 28);
            // 
            // ToolStripExit
            // 
            this.ToolStripExit.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripExit.Image")));
            this.ToolStripExit.Name = "ToolStripExit";
            this.ToolStripExit.Size = new System.Drawing.Size(113, 24);
            this.ToolStripExit.Text = "Thoát";
            this.ToolStripExit.Click += new System.EventHandler(this.ToolStripExit_Click);
            // 
            // frnMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(846, 561);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frnMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình quản lý nhà sách";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frnMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSort;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuHangHoa;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiem;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuGuiEmail;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuAdmin;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer Times;
        private System.Windows.Forms.ToolStripMenuItem mnuCategoryProduct;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuTimDMHangHoa;
        private System.Windows.Forms.ToolStripMenuItem mnuTimHangHoa;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuTimNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuCapNhat;
        private System.Windows.Forms.ToolStripMenuItem mnuViewArrangeIcons;
        private System.Windows.Forms.ToolStripMenuItem mnuViewCasade;
        private System.Windows.Forms.ToolStripMenuItem mnuViewTH;
        private System.Windows.Forms.ToolStripMenuItem mnuViewTV;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripExit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuThemHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnuTienIch;
        private System.Windows.Forms.ToolStripMenuItem mnuMayAnh;
        private System.Windows.Forms.ToolStripMenuItem mnuMayTinh;
        private System.Windows.Forms.ToolStripMenuItem báoCáoKhoHàngToolStripMenuItem;
    }
}

