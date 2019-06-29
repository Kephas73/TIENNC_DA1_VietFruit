namespace VIETFRUIT
{
    partial class frm_DangNhap
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.bt_DangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.txt_TaiKhoan = new System.Windows.Forms.TextBox();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.chekB_Nho = new System.Windows.Forms.CheckBox();
            this.lb_ThongBao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(87, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(23, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(23, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu:";
            // 
            // bt_Thoat
            // 
            this.bt_Thoat.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_Thoat.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bt_Thoat.Appearance.Options.UseFont = true;
            this.bt_Thoat.Appearance.Options.UseForeColor = true;
            this.bt_Thoat.Location = new System.Drawing.Point(209, 257);
            this.bt_Thoat.Name = "bt_Thoat";
            this.bt_Thoat.Size = new System.Drawing.Size(85, 32);
            this.bt_Thoat.TabIndex = 4;
            this.bt_Thoat.Text = "Thoát";
            this.bt_Thoat.Click += new System.EventHandler(this.bt_Thoat_Click);
            // 
            // bt_DangNhap
            // 
            this.bt_DangNhap.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_DangNhap.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bt_DangNhap.Appearance.Options.UseFont = true;
            this.bt_DangNhap.Appearance.Options.UseForeColor = true;
            this.bt_DangNhap.Location = new System.Drawing.Point(93, 257);
            this.bt_DangNhap.Name = "bt_DangNhap";
            this.bt_DangNhap.Size = new System.Drawing.Size(85, 32);
            this.bt_DangNhap.TabIndex = 3;
            this.bt_DangNhap.Text = "Đăng nhập";
            this.bt_DangNhap.Click += new System.EventHandler(this.bt_DangNhap_Click);
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TaiKhoan.Location = new System.Drawing.Point(125, 95);
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(169, 27);
            this.txt_TaiKhoan.TabIndex = 0;
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MatKhau.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MatKhau.Location = new System.Drawing.Point(125, 140);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PasswordChar = '*';
            this.txt_MatKhau.Size = new System.Drawing.Size(169, 27);
            this.txt_MatKhau.TabIndex = 1;
            // 
            // chekB_Nho
            // 
            this.chekB_Nho.AutoSize = true;
            this.chekB_Nho.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chekB_Nho.Location = new System.Drawing.Point(125, 183);
            this.chekB_Nho.Name = "chekB_Nho";
            this.chekB_Nho.Size = new System.Drawing.Size(53, 20);
            this.chekB_Nho.TabIndex = 2;
            this.chekB_Nho.Text = "Nhớ";
            this.chekB_Nho.UseVisualStyleBackColor = true;
            // 
            // lb_ThongBao
            // 
            this.lb_ThongBao.AutoSize = true;
            this.lb_ThongBao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongBao.ForeColor = System.Drawing.Color.Red;
            this.lb_ThongBao.Location = new System.Drawing.Point(122, 206);
            this.lb_ThongBao.Name = "lb_ThongBao";
            this.lb_ThongBao.Size = new System.Drawing.Size(137, 16);
            this.lb_ThongBao.TabIndex = 6;
            this.lb_ThongBao.Text = "Vui lòng đăng nhập!";
            // 
            // frm_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(322, 315);
            this.Controls.Add(this.lb_ThongBao);
            this.Controls.Add(this.chekB_Nho);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.txt_TaiKhoan);
            this.Controls.Add(this.bt_DangNhap);
            this.Controls.Add(this.bt_Thoat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DangNhap";
            this.Load += new System.EventHandler(this.frm_DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton bt_Thoat;
        private DevExpress.XtraEditors.SimpleButton bt_DangNhap;
        private System.Windows.Forms.TextBox txt_TaiKhoan;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.CheckBox chekB_Nho;
        private System.Windows.Forms.Label lb_ThongBao;
    }
}