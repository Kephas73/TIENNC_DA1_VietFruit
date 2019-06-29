using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using MODEL;

namespace VIETFRUIT
{
    public partial class frm_DangKiTaiKhoan : Form
    {
        NhanVien_BUS NV = new NhanVien_BUS();
        TaiKhoan_BUS TK = new TaiKhoan_BUS();
        TaiKhoan_MODEL TK1 = new TaiKhoan_MODEL();
        PhanQuyen_BUS PQ = new PhanQuyen_BUS();
        TrangThai_MODEL TT = new TrangThai_MODEL();
        public frm_DangKiTaiKhoan()
        {
            InitializeComponent();
        }

        void Danh_Sach_Nhan_Vien()
        {
            cmb_MaNhanVien.DataSource = NV.DS_NhanVien();
            cmb_MaNhanVien.DisplayMember = "MA_NHAN_VIEN";
        }

        private void frm_DangKiTaiKhoan_Load(object sender, EventArgs e)
        {
            Danh_Sach_Nhan_Vien();
        }

        private void cmb_MaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_NhanVien.DataBindings.Clear();
            txt_NhanVien.DataBindings.Add("Text", cmb_MaNhanVien.DataSource, "TEN_NHAN_VIEN");
            time_NgaySinh.DataBindings.Clear();
            time_NgaySinh.DataBindings.Add("Value", cmb_MaNhanVien.DataSource, "NGAY_SINH");
        }

        public void Lap_Bang_Trang_Thai_Ban_Dau(string A)
        {
            DataTable tb = PQ.Danh_Sach_Chuc_Nang();

            TT.TEN_TAI_KHOAN1 = A;
            TT.TRANG_THAI1 = false;
          foreach(DataRow dr in tb.Rows)
          {
              
              TT.MA_CHUC_NANG1 = dr["MA_CHUC_NANG"].ToString();
              PQ.Them_Trang_Thai(TT);
          }
        }
        private void bt_DangKi_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmb_MaNhanVien.Text=="" || txt_NhanVien.Text=="" || txt_TaiKhoan.Text=="" || txt_MatKhau1.Text=="" || txt_MatKhau2.Text=="")
                {
                    throw new Exception("Bạn chưa điền đầy đủ thông tin đăng kí tài khoản");
                }
                else
                {
                    TK1.MA_NHAN_VIEN1 = cmb_MaNhanVien.Text;
                    TK1.TEN_TAI_KHOAN1 = txt_TaiKhoan.Text;
                    if(txt_MatKhau1.Text == txt_MatKhau2.Text)
                    {
                        TK1.MAT_KHAU1 = txt_MatKhau2.Text;
                    }
                    else
                    {
                        throw new Exception("Mật khẩu không trùng khớp!");
                    }
                    DataTable tb = TK.Danh_Sach_Tai_Khoan(txt_TaiKhoan.Text);
                    if( tb.Rows.Count > 0 )
                    {
                       
                        throw new Exception(" Tên tài khoản đã tồn tại, mời bạn nhập tài khoản mới!");
                    }
                    else
                    {
                       
                        TK.Them_Tai_Khoan(TK1);
                        Lap_Bang_Trang_Thai_Ban_Dau(txt_TaiKhoan.Text);
                        MessageBox.Show("Đăng kí tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                cmb_MaNhanVien.ResetText();
                txt_NhanVien.ResetText();
                time_NgaySinh.ResetText();
                txt_TaiKhoan.ResetText();
                txt_MatKhau1.ResetText();
                txt_MatKhau2.ResetText();
               
            }
        }

        private void txt_TaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (/*char.IsLetter(e.KeyChar) || *//*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar) /* */) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập kí tự thường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool Unicode(string A)
        {
            const int Kitu = 128;
            return A.ToCharArray().Any(c => c > Kitu);

        }
        private void txt_TaiKhoan_TextChanged(object sender, EventArgs e)
        {
            DataTable tb = TK.Danh_Sach_Tai_Khoan(txt_TaiKhoan.Text);
            if (tb.Rows.Count > 0)
            {
                lb_ThongBao.ForeColor = Color.Red;
                lb_ThongBao.Text = "Tên đăng nhập đã tồn tại!";
            }
            else
            {
                lb_ThongBao.ForeColor = Color.Green;
                lb_ThongBao.Text = "Tên đăng nhập hợp lệ!";
            }
            if(txt_TaiKhoan.Text=="")
            {
                lb_ThongBao.ForeColor = Color.Black;
                lb_ThongBao.Text = "...";
            }

            if (Unicode(txt_TaiKhoan.Text) == true)
            {
                MessageBox.Show("Không chứ dấu tiếng việt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TaiKhoan.ResetText();
            }

        }

        private void txt_MatKhau2_TextChanged(object sender, EventArgs e)
        {
            if(string.Compare(txt_MatKhau2.Text,txt_MatKhau1.Text)==0)
            {
                lb_ThongBao2.ForeColor = Color.Green;
                lb_ThongBao2.Text = "Mật khẩu trùng khớp!";
            }
            else
            {
                lb_ThongBao2.ForeColor = Color.Red;
                lb_ThongBao2.Text = "Mật khẩu không trùng khớp!";
            }
            if(txt_MatKhau2.Text=="")
            {
                lb_ThongBao2.ForeColor = Color.Black;
                lb_ThongBao2.Text = "...";
            }
            if (Unicode(txt_MatKhau2.Text) == true)
            {
                MessageBox.Show("Không chứ dấu tiếng việt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MatKhau2.ResetText();
            }
        }

        private void txt_MatKhau1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (/*char.IsLetter(e.KeyChar) || *//*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar) /* */) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập kí tự thường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_MatKhau1_TextChanged(object sender, EventArgs e)
        {
            if (Unicode( txt_MatKhau1.Text) == true)
            {
                MessageBox.Show("Không chứ dấu tiếng việt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MatKhau1.ResetText();
            }
        }

        private void txt_MatKhau2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (/*char.IsLetter(e.KeyChar) || *//*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar) /* */) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập kí tự thường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(tl==DialogResult.OK)
            {
                this.Close();
            }
        }

    }
}
