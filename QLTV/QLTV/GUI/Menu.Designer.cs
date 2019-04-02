namespace QLTV.GUI
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTheLoai1 = new System.Windows.Forms.Button();
            this.btnSangTac = new System.Windows.Forms.Button();
            this.btnTacGia = new System.Windows.Forms.Button();
            this.btnPhanLoai = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnSach = new System.Windows.Forms.Button();
            this.btnNguoiMuon = new System.Windows.Forms.Button();
            this.btnMuonSach = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnTheLoai1);
            this.panel1.Controls.Add(this.btnSangTac);
            this.panel1.Controls.Add(this.btnTacGia);
            this.panel1.Controls.Add(this.btnPhanLoai);
            this.panel1.Controls.Add(this.btnNhanVien);
            this.panel1.Controls.Add(this.btnSach);
            this.panel1.Controls.Add(this.btnNguoiMuon);
            this.panel1.Controls.Add(this.btnMuonSach);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 0;
            // 
            // btnTheLoai1
            // 
            this.btnTheLoai1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheLoai1.ForeColor = System.Drawing.Color.Red;
            this.btnTheLoai1.Image = global::QLTV.Properties.Resources.Thể_loại_2;
            this.btnTheLoai1.Location = new System.Drawing.Point(59, 283);
            this.btnTheLoai1.Name = "btnTheLoai1";
            this.btnTheLoai1.Size = new System.Drawing.Size(143, 112);
            this.btnTheLoai1.TabIndex = 8;
            this.btnTheLoai1.Text = "Thể Loại";
            this.btnTheLoai1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTheLoai1.UseVisualStyleBackColor = true;
            this.btnTheLoai1.Click += new System.EventHandler(this.btnTheLoai1_Click);
            // 
            // btnSangTac
            // 
            this.btnSangTac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSangTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSangTac.ForeColor = System.Drawing.Color.Red;
            this.btnSangTac.Image = global::QLTV.Properties.Resources.Sáng_tác;
            this.btnSangTac.Location = new System.Drawing.Point(559, 283);
            this.btnSangTac.Name = "btnSangTac";
            this.btnSangTac.Size = new System.Drawing.Size(144, 112);
            this.btnSangTac.TabIndex = 7;
            this.btnSangTac.Text = "Sáng Tác";
            this.btnSangTac.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSangTac.UseVisualStyleBackColor = false;
            this.btnSangTac.Click += new System.EventHandler(this.btnSangTac_Click);
            // 
            // btnTacGia
            // 
            this.btnTacGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTacGia.BackgroundImage = global::QLTV.Properties.Resources.Tác_giả1;
            this.btnTacGia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTacGia.ForeColor = System.Drawing.Color.Red;
            this.btnTacGia.Location = new System.Drawing.Point(559, 147);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(144, 113);
            this.btnTacGia.TabIndex = 6;
            this.btnTacGia.Text = "Tác Giả";
            this.btnTacGia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTacGia.UseVisualStyleBackColor = false;
            this.btnTacGia.Click += new System.EventHandler(this.btnTacGia_Click);
            // 
            // btnPhanLoai
            // 
            this.btnPhanLoai.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnPhanLoai.BackgroundImage = global::QLTV.Properties.Resources.Phân_loại;
            this.btnPhanLoai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPhanLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanLoai.ForeColor = System.Drawing.Color.Red;
            this.btnPhanLoai.Location = new System.Drawing.Point(559, 14);
            this.btnPhanLoai.Name = "btnPhanLoai";
            this.btnPhanLoai.Size = new System.Drawing.Size(144, 106);
            this.btnPhanLoai.TabIndex = 5;
            this.btnPhanLoai.Text = "Phân Loại";
            this.btnPhanLoai.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPhanLoai.UseVisualStyleBackColor = false;
            this.btnPhanLoai.Click += new System.EventHandler(this.btnPhanLoai_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.Image = global::QLTV.Properties.Resources.NV1;
            this.btnNhanVien.Location = new System.Drawing.Point(311, 241);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(130, 107);
            this.btnNhanVien.TabIndex = 4;
            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnSach
            // 
            this.btnSach.BackColor = System.Drawing.Color.White;
            this.btnSach.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSach.BackgroundImage")));
            this.btnSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSach.ForeColor = System.Drawing.Color.Black;
            this.btnSach.Location = new System.Drawing.Point(311, 84);
            this.btnSach.Name = "btnSach";
            this.btnSach.Size = new System.Drawing.Size(130, 114);
            this.btnSach.TabIndex = 3;
            this.btnSach.Text = "Sách";
            this.btnSach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSach.UseVisualStyleBackColor = false;
            this.btnSach.Click += new System.EventHandler(this.btnSach_Click);
            // 
            // btnNguoiMuon
            // 
            this.btnNguoiMuon.BackColor = System.Drawing.Color.MintCream;
            this.btnNguoiMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNguoiMuon.ForeColor = System.Drawing.Color.Red;
            this.btnNguoiMuon.Image = global::QLTV.Properties.Resources.Người_mượn;
            this.btnNguoiMuon.Location = new System.Drawing.Point(59, 147);
            this.btnNguoiMuon.Name = "btnNguoiMuon";
            this.btnNguoiMuon.Size = new System.Drawing.Size(143, 113);
            this.btnNguoiMuon.TabIndex = 1;
            this.btnNguoiMuon.Text = "Người Mượn";
            this.btnNguoiMuon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNguoiMuon.UseVisualStyleBackColor = false;
            this.btnNguoiMuon.Click += new System.EventHandler(this.btnNguoiMuon_Click);
            // 
            // btnMuonSach
            // 
            this.btnMuonSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMuonSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuonSach.ForeColor = System.Drawing.Color.Red;
            this.btnMuonSach.Image = global::QLTV.Properties.Resources.Mượn_sách2;
            this.btnMuonSach.Location = new System.Drawing.Point(59, 14);
            this.btnMuonSach.Name = "btnMuonSach";
            this.btnMuonSach.Size = new System.Drawing.Size(143, 106);
            this.btnMuonSach.TabIndex = 0;
            this.btnMuonSach.Text = "Mượn Sách";
            this.btnMuonSach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMuonSach.UseVisualStyleBackColor = false;
            this.btnMuonSach.Click += new System.EventHandler(this.btnMuonSach_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSangTac;
        private System.Windows.Forms.Button btnTacGia;
        private System.Windows.Forms.Button btnPhanLoai;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnSach;
        private System.Windows.Forms.Button btnTheLoai;
        private System.Windows.Forms.Button btnNguoiMuon;
        private System.Windows.Forms.Button btnMuonSach;
        private System.Windows.Forms.Button btnTheLoai1;
    }
}