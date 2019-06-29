namespace VIETFRUIT
{
    partial class frm_DoiMatKhau
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
            this.txt_TenTaiKhoan = new System.Windows.Forms.TextBox();
            this.txt_MatKhauCu = new System.Windows.Forms.TextBox();
            this.txt_MatKhauMoi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_ThayDoi = new DevExpress.XtraEditors.SimpleButton();
            this.bt_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đổi mật khẩu";
            // 
            // txt_TenTaiKhoan
            // 
            this.txt_TenTaiKhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TenTaiKhoan.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenTaiKhoan.Location = new System.Drawing.Point(141, 95);
            this.txt_TenTaiKhoan.MaxLength = 200;
            this.txt_TenTaiKhoan.Name = "txt_TenTaiKhoan";
            this.txt_TenTaiKhoan.Size = new System.Drawing.Size(169, 27);
            this.txt_TenTaiKhoan.TabIndex = 0;
            // 
            // txt_MatKhauCu
            // 
            this.txt_MatKhauCu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MatKhauCu.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MatKhauCu.Location = new System.Drawing.Point(141, 143);
            this.txt_MatKhauCu.MaxLength = 200;
            this.txt_MatKhauCu.Name = "txt_MatKhauCu";
            this.txt_MatKhauCu.PasswordChar = '*';
            this.txt_MatKhauCu.Size = new System.Drawing.Size(169, 27);
            this.txt_MatKhauCu.TabIndex = 1;
            // 
            // txt_MatKhauMoi
            // 
            this.txt_MatKhauMoi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MatKhauMoi.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MatKhauMoi.Location = new System.Drawing.Point(141, 189);
            this.txt_MatKhauMoi.MaxLength = 20;
            this.txt_MatKhauMoi.Name = "txt_MatKhauMoi";
            this.txt_MatKhauMoi.PasswordChar = '*';
            this.txt_MatKhauMoi.Size = new System.Drawing.Size(169, 27);
            this.txt_MatKhauMoi.TabIndex = 2;
            this.txt_MatKhauMoi.TextChanged += new System.EventHandler(this.txt_MatKhauMoi_TextChanged);
            this.txt_MatKhauMoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MatKhauMoi_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên Tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu cũ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu mới:";
            // 
            // bt_ThayDoi
            // 
            this.bt_ThayDoi.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_ThayDoi.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bt_ThayDoi.Appearance.Options.UseFont = true;
            this.bt_ThayDoi.Appearance.Options.UseForeColor = true;
            this.bt_ThayDoi.Location = new System.Drawing.Point(50, 265);
            this.bt_ThayDoi.Name = "bt_ThayDoi";
            this.bt_ThayDoi.Size = new System.Drawing.Size(85, 32);
            this.bt_ThayDoi.TabIndex = 3;
            this.bt_ThayDoi.Text = "Thay đổi";
            this.bt_ThayDoi.Click += new System.EventHandler(this.bt_ThayDoi_Click);
            // 
            // bt_Thoat
            // 
            this.bt_Thoat.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_Thoat.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bt_Thoat.Appearance.Options.UseFont = true;
            this.bt_Thoat.Appearance.Options.UseForeColor = true;
            this.bt_Thoat.Location = new System.Drawing.Point(182, 265);
            this.bt_Thoat.Name = "bt_Thoat";
            this.bt_Thoat.Size = new System.Drawing.Size(85, 32);
            this.bt_Thoat.TabIndex = 4;
            this.bt_Thoat.Text = "Thoát";
            this.bt_Thoat.Click += new System.EventHandler(this.bt_Thoat_Click);
            // 
            // frm_DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(322, 346);
            this.Controls.Add(this.bt_Thoat);
            this.Controls.Add(this.bt_ThayDoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_MatKhauMoi);
            this.Controls.Add(this.txt_MatKhauCu);
            this.Controls.Add(this.txt_TenTaiKhoan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoiMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TenTaiKhoan;
        private System.Windows.Forms.TextBox txt_MatKhauCu;
        private System.Windows.Forms.TextBox txt_MatKhauMoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton bt_ThayDoi;
        private DevExpress.XtraEditors.SimpleButton bt_Thoat;
    }
}