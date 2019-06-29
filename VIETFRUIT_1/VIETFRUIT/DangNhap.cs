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
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace VIETFRUIT
{
    public partial class frm_DangNhap : Form
    {
        TaiKhoan_BUS TK = new TaiKhoan_BUS();
         frm_TrangChu TrangChu;
        
        public frm_DangNhap( frm_TrangChu TC = null)
        {
           
            InitializeComponent();
            TrangChu = TC;
            
        }  


        void KiemTra_NhanVien(string A)
        {
           
            DataTable b = TK.Danh_Sach_Chuc_Nang(A);
            if (b.Rows.Count > 0)
            {
                foreach (DataRow dr in b.Rows)
                {
                    bool c = bool.Parse(dr["TRANG_THAI"].ToString());
                    if (dr["TEN_CHUC_NANG"].ToString() == "Nhân viên" && c == true)
                    {
                        TrangChu.ChamCong(true);
                    }
                    if (dr["TEN_CHUC_NANG"].ToString() == "Nhân viên" && c == false)
                    {
                        TrangChu.ChamCong(false);
                    }
                }
            }
        }
        void KiemTra_QLKho(string A)
        {
            
            DataTable b = TK.Danh_Sach_Chuc_Nang(A);
            if (b.Rows.Count > 0)
            {
                foreach (DataRow dr in b.Rows)
                {
                    bool c = bool.Parse(dr["TRANG_THAI"].ToString());
                    if (dr["TEN_CHUC_NANG"].ToString() == "QL kho" && c == true)
                    {
                        TrangChu.QuanLyKho(true);
                    }
                    if (dr["TEN_CHUC_NANG"].ToString() == "QL kho" && c == false)
                    {
                        TrangChu.QuanLyKho(false);
                    }
                }
            }
        }
        void KiemTra_ThuNgan(string A)
        {
            
            DataTable b = TK.Danh_Sach_Chuc_Nang(A);
            if (b.Rows.Count > 0)
            {
                foreach (DataRow dr in b.Rows)
                {
                    bool c = bool.Parse(dr["TRANG_THAI"].ToString());
                    if (dr["TEN_CHUC_NANG"].ToString() == "Thu ngân" && c == true)
                    {
                        TrangChu.ThuNgan(true);
                        TrangChu.KhachHangThanThiet(true);
                    }
                    if (dr["TEN_CHUC_NANG"].ToString() == "Thu ngân" && c == false)
                    {
                        TrangChu.ThuNgan(false);
                        TrangChu.KhachHangThanThiet(false);
                    }
                }
            }
        }
        void KiemTra_ChuQL(string A)
        {
            
            DataTable b = TK.Danh_Sach_Chuc_Nang(A);
            if (b.Rows.Count > 0)
            {
                foreach (DataRow dr in b.Rows)
                {
                    bool c = bool.Parse(dr["TRANG_THAI"].ToString());
                    if (dr["TEN_CHUC_NANG"].ToString() == "Chủ QL" && c == true)
                    {
                        TrangChu.ChuQuanLi(true);
                        TrangChu.PhanQuyen(true);
                    }
                    if (dr["TEN_CHUC_NANG"].ToString() == "Chủ QL" && c == false)
                    {
                        TrangChu.ChuQuanLi(false);
                        TrangChu.PhanQuyen(false);
                    }
                }
            }
        }
        void KiemTra_ThongKe(string A)
        {
            
            DataTable b = TK.Danh_Sach_Chuc_Nang(A);
            if (b.Rows.Count > 0)
            {
                foreach (DataRow dr in b.Rows)
                {
                    bool c = bool.Parse(dr["TRANG_THAI"].ToString());
                    if (dr["TEN_CHUC_NANG"].ToString() == "Thống kê" && c == true)
                    {
                        TrangChu.ThongKe(true);
                    }
                    if (dr["TEN_CHUC_NANG"].ToString() == "Thống kê" && c == false)
                    {
                        TrangChu.ThongKe(false);
                    }
                }
            }
        }
//----------------------------------- chọn Project Solution > Properties > Add ---------------------------
        public void Doc_DN()
        {
            if (Properties.Settings.Default.Nho == Convert.ToString("true"))
            {
                txt_TaiKhoan.Text = Properties.Settings.Default.TK;
                txt_MatKhau.Text = Properties.Settings.Default.MK;
                chekB_Nho.Checked = true;
             }
             else
             {
                txt_TaiKhoan.Text = "";
                txt_MatKhau.Text = "";
                chekB_Nho.Checked = false;
            }
        }
        public void Luu_DN()
        {
            if (chekB_Nho.Checked)
            {
                Properties.Settings.Default.TK = this.txt_TaiKhoan.Text;
                Properties.Settings.Default.MK = this.txt_MatKhau.Text;
                Properties.Settings.Default.Nho = Convert.ToString( "true");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.TK = this.txt_TaiKhoan.Text;
                Properties.Settings.Default.MK = "";
                Properties.Settings.Default.Nho = Convert.ToString( "false");
                Properties.Settings.Default.Save();
            }
        }

        void Chay()
        {
            SplashScreenManager.ShowForm(this, typeof(ManHinhCho1cs), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("");
            for(int i=0; i<100;i++)
            {
                Thread.Sleep(20);
            }
            SplashScreenManager.CloseForm();
        }
//--------https://khanhn.wordpress.com/2016/10/13/rememberme-trong-windows-forms-voi-c/--------- Nguồn.
        private void bt_DangNhap_Click(object sender, EventArgs e)
        {
            DataTable tb = TK.Dang_Nhap(txt_TaiKhoan.Text, txt_MatKhau.Text);
            DataTable tb1 = TK.Thong_Tin_Tai_Khoan(txt_TaiKhoan.Text);
            
            string A = txt_TaiKhoan.Text;
          
            
            try
            {
                if (txt_TaiKhoan.Text == "" || txt_MatKhau.Text == "")
                {
                    throw new Exception("Bạn chưa điền đầy đủ thông tin đăng nhập. Mời đăng nhập lại!");
                   
                }
                else
                {
                    if(tb.Rows.Count>0)
                    {
                        KiemTra_NhanVien(A);
                        KiemTra_QLKho(A);
                        KiemTra_ThuNgan(A);
                        KiemTra_ChuQL(A);
                        KiemTra_ThongKe(A);


                      
                        lb_ThongBao.Text = "Đăng nhập thành công!";


                        Chay();
                       
                        this.Hide();
                        TrangChu.DangXuat(true);
                        TrangChu.DangNhap(false);
                        TrangChu.TieuDe(A,tb1.Rows[0][0].ToString(),tb1.Rows[0][1].ToString());
                        Luu_DN();
                       
                       
                        
                    }
                    else
                    {
                        lb_ThongBao.Text = "Thông tin đăng nhập sai!";
                    }
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                
                txt_TaiKhoan.ResetText();
                txt_MatKhau.ResetText();

            }
        }

        private void bt_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn muốn thoát đăng nhập!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(tl==DialogResult.OK)
                {
                    this.Close();
                }
        }
      
     

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            Doc_DN();
        }
    }
}
