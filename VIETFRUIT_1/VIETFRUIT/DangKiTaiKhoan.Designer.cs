namespace VIETFRUIT
{
    partial class frm_DangKiTaiKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NhanVien = new System.Windows.Forms.TextBox();
            this.cmb_MaNhanVien = new System.Windows.Forms.ComboBox();
            this.txt_TaiKhoan = new System.Windows.Forms.TextBox();
            this.txt_MatKhau1 = new System.Windows.Forms.TextBox();
            this.txt_MatKhau2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_DangKi = new DevExpress.XtraEditors.SimpleButton();
            this.bt_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.time_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_ThongBao = new System.Windows.Forms.Label();
            this.lb_ThongBao2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng kí tài khoản mới";
            // 
            // txt_NhanVien
            // 
            this.txt_NhanVien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_NhanVien.Enabled = false;
            this.txt_NhanVien.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NhanVien.Location = new System.Drawing.Point(164, 147);
            this.txt_NhanVien.Name = "txt_NhanVien";
            this.txt_NhanVien.Size = new System.Drawing.Size(191, 27);
            this.txt_NhanVien.TabIndex = 1;
            // 
            // cmb_MaNhanVien
            // 
            this.cmb_MaNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_MaNhanVien.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_MaNhanVien.FormattingEnabled = true;
            this.cmb_MaNhanVien.Location = new System.Drawing.Point(164, 95);
            this.cmb_MaNhanVien.Name = "cmb_MaNhanVien";
            this.cmb_MaNhanVien.Size = new System.Drawing.Size(191, 27);
            this.cmb_MaNhanVien.TabIndex = 0;
            this.cmb_MaNhanVien.SelectedIndexChanged += new System.EventHandler(this.cmb_MaNhanVien_SelectedIndexChanged);
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TaiKhoan.Location = new System.Drawing.Point(164, 247);
            this.txt_TaiKhoan.MaxLength = 20;
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(191, 27);
            this.txt_TaiKhoan.TabIndex = 3;
            this.txt_TaiKhoan.TextChanged += new System.EventHandler(this.txt_TaiKhoan_TextChanged);
            this.txt_TaiKhoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_TaiKhoan_KeyPress);
            // 
            // txt_MatKhau1
            // 
            this.txt_MatKhau1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MatKhau1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MatKhau1.Location = new System.Drawing.Point(164, 305);
            this.txt_MatKhau1.MaxLength = 20;
            this.txt_MatKhau1.Name = "txt_MatKhau1";
            this.txt_MatKhau1.PasswordChar = '*';
            this.txt_MatKhau1.Size = new System.Drawing.Size(191, 27);
            this.txt_MatKhau1.TabIndex = 4;
            this.txt_MatKhau1.TextChanged += new System.EventHandler(this.txt_MatKhau1_TextChanged);
            this.txt_MatKhau1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MatKhau1_KeyPress);
            // 
            // txt_MatKhau2
            // 
            this.txt_MatKhau2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MatKhau2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MatKhau2.Location = new System.Drawing.Point(164, 354);
            this.txt_MatKhau2.MaxLength = 20;
            this.txt_MatKhau2.Name = "txt_MatKhau2";
            this.txt_MatKhau2.PasswordChar = '*';
            this.txt_MatKhau2.Size = new System.Drawing.Size(191, 27);
            this.txt_MatKhau2.TabIndex = 5;
            this.txt_MatKhau2.TextChanged += new System.EventHandler(this.txt_MatKhau2_TextChanged);
            this.txt_MatKhau2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MatKhau2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(23, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(23, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên nhân viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(23, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tài khoản:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(23, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mật khẩu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(23, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Nhập lại mật khẩu:";
            // 
            // bt_DangKi
            // 
            this.bt_DangKi.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_DangKi.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bt_DangKi.Appearance.Options.UseFont = true;
            this.bt_DangKi.Appearance.Options.UseForeColor = true;
            this.bt_DangKi.Location = new System.Drawing.Point(66, 419);
            this.bt_DangKi.Name = "bt_DangKi";
            this.bt_DangKi.Size = new System.Drawing.Size(85, 32);
            this.bt_DangKi.TabIndex = 6;
            this.bt_DangKi.Text = "Đăng kí";
            this.bt_DangKi.Click += new System.EventHandler(this.bt_DangKi_Click);
            // 
            // bt_Thoat
            // 
            this.bt_Thoat.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_Thoat.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bt_Thoat.Appearance.Options.UseFont = true;
            this.bt_Thoat.Appearance.Options.UseForeColor = true;
            this.bt_Thoat.Location = new System.Drawing.Point(221, 419);
            this.bt_Thoat.Name = "bt_Thoat";
            this.bt_Thoat.Size = new System.Drawing.Size(85, 32);
            this.bt_Thoat.TabIndex = 7;
            this.bt_Thoat.Text = "Thoát";
            this.bt_Thoat.Click += new System.EventHandler(this.bt_Thoat_Click);
            // 
            // time_NgaySinh
            // 
            this.time_NgaySinh.CalendarFont = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_NgaySinh.Enabled = false;
            this.time_NgaySinh.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_NgaySinh.Location = new System.Drawing.Point(164, 197);
            this.time_NgaySinh.Name = "time_NgaySinh";
            this.time_NgaySinh.Size = new System.Drawing.Size(191, 27);
            this.time_NgaySinh.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(23, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ngày sinh:";
            // 
            // lb_ThongBao
            // 
            this.lb_ThongBao.AutoSize = true;
            this.lb_ThongBao.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongBao.ForeColor = System.Drawing.Color.Black;
            this.lb_ThongBao.Location = new System.Drawing.Point(161, 277);
            this.lb_ThongBao.Name = "lb_ThongBao";
            this.lb_ThongBao.Size = new System.Drawing.Size(20, 17);
            this.lb_ThongBao.TabIndex = 7;
            this.lb_ThongBao.Text = "...";
            // 
            // lb_ThongBao2
            // 
            this.lb_ThongBao2.AutoSize = true;
            this.lb_ThongBao2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongBao2.ForeColor = System.Drawing.Color.Black;
            this.lb_ThongBao2.Location = new System.Drawing.Point(161, 384);
            this.lb_ThongBao2.Name = "lb_ThongBao2";
            this.lb_ThongBao2.Size = new System.Drawing.Size(20, 17);
            this.lb_ThongBao2.TabIndex = 8;
            this.lb_ThongBao2.Text = "...";
            // 
            // frm_DangKiTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(367, 498);
            this.Controls.Add(this.lb_ThongBao2);
            this.Controls.Add(this.lb_ThongBao);
            this.Controls.Add(this.time_NgaySinh);
            this.Controls.Add(this.bt_Thoat);
            this.Controls.Add(this.bt_DangKi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_MaNhanVien);
            this.Controls.Add(this.txt_MatKhau2);
            this.Controls.Add(this.txt_MatKhau1);
            this.Controls.Add(this.txt_TaiKhoan);
            this.Controls.Add(this.txt_NhanVien);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DangKiTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "...";
            this.Load += new System.EventHandler(this.frm_DangKiTaiKhoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NhanVien;
        private System.Windows.Forms.ComboBox cmb_MaNhanVien;
        private System.Windows.Forms.TextBox txt_TaiKhoan;
        private System.Windows.Forms.TextBox txt_MatKhau1;
        private System.Windows.Forms.TextBox txt_MatKhau2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton bt_DangKi;
        private DevExpress.XtraEditors.SimpleButton bt_Thoat;
        private System.Windows.Forms.DateTimePicker time_NgaySinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_ThongBao;
        private System.Windows.Forms.Label lb_ThongBao2;
    }
}