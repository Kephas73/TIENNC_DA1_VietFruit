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
    public partial class frm_PhanQuyen : Form
    {
        PhanQuyen_BUS PQ = new PhanQuyen_BUS();
        TrangThai_MODEL TT = new TrangThai_MODEL();
        public frm_PhanQuyen()
        {
            InitializeComponent();
        }

        public void Load_Nhan_Vien()
        {
            dtGV_TaiKhoan.DataSource = PQ.Tat_Ca_Tai_khoan();
            dtGV_TaiKhoan.ReadOnly = true;
        }
        private void frm_PhanQuyen_Load(object sender, EventArgs e)
        {
            Load_Nhan_Vien();
           
        }

        private void dtGV_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            txt_MaNhanVien.DataBindings.Clear();
            txt_MaNhanVien.DataBindings.Add("Text", dtGV_TaiKhoan.DataSource, "MA_NHAN_VIEN");
            txt_HoTen.DataBindings.Clear();
            txt_HoTen.DataBindings.Add("Text", dtGV_TaiKhoan.DataSource, "TEN_NHAN_VIEN");
            cmb_GioiTinh.DataBindings.Clear();
            cmb_GioiTinh.DataBindings.Add("Text", dtGV_TaiKhoan.DataSource, "GIOI_TINH");
            time_NgaySinh.DataBindings.Clear();
            time_NgaySinh.DataBindings.Add("Value", dtGV_TaiKhoan.DataSource, "NGAY_SINH");
            cmb_BoPhan.DataBindings.Clear();
            cmb_BoPhan.DataBindings.Add("Text", dtGV_TaiKhoan.DataSource, "TEN_BO_PHAN");
            txt_SoDT.DataBindings.Clear();
            txt_SoDT.DataBindings.Add("Text", dtGV_TaiKhoan.DataSource, "SO_DIEN_THOAI");
            txt_DiaChi.DataBindings.Clear();
            txt_DiaChi.DataBindings.Add("Text", dtGV_TaiKhoan.DataSource, "DIA_CHI");
            txt_TaiKhoan.DataBindings.Clear();
            txt_TaiKhoan.DataBindings.Add("Text", dtGV_TaiKhoan.DataSource, "TEN_TAI_KHOAN");
            txt_MatKhau.DataBindings.Clear();
            txt_MatKhau.DataBindings.Add("Text", dtGV_TaiKhoan.DataSource, "MAT_KHAU");
        }

        private void txt_TaiKhoan_TextChanged(object sender, EventArgs e)
        {
            dtGV_BangPhanQuyen.DataSource = PQ.Trang_Thai(txt_TaiKhoan.Text);
        }

        void Dat_Button(bool TF)
        {
            dtGV_TaiKhoan.Enabled = TF;
            bt_Sua.Enabled = TF;
            bt_TaiLai.Enabled = TF;
            bt_Tim.Enabled = TF;

            dtGV_BangPhanQuyen.Enabled = !TF;

            bt_Luu.Enabled = !TF;
            bt_Huy.Enabled = !TF;
        }
        private void bt_Sua_Click(object sender, EventArgs e)
        {
            Dat_Button(false);
           
            dtGV_BangPhanQuyen.Columns[0].ReadOnly = true;
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                
                TT.TEN_TAI_KHOAN1=txt_TaiKhoan.Text;
               
                for (int i = 0; i < dtGV_BangPhanQuyen.Rows.Count; i++)
                {
                    TT.MA_CHUC_NANG1 = PQ.Ma_Chuc_Nang(dtGV_BangPhanQuyen.Rows[i].Cells[0].Value.ToString());
                    bool c = bool.Parse(dtGV_BangPhanQuyen.Rows[i].Cells[1].Value.ToString());
                    TT.TRANG_THAI1 = c;

                    PQ.Cap_Nhat_Trang_Thai(TT);   
                }
                MessageBox.Show("Cập nhật phân quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                Dat_Button(true);
                Load_Nhan_Vien();
             
            }
        }

        private void bt_Huy_Click(object sender, EventArgs e)
        {
            Dat_Button(true);
            Load_Nhan_Vien();
            dtGV_BangPhanQuyen.DataSource = PQ.Trang_Thai(txt_TaiKhoan.Text);
        }

        private void bt_TaiLai_Click(object sender, EventArgs e)
        {
            Load_Nhan_Vien();
            Dat_Button(true);
            dtGV_BangPhanQuyen.DataSource = PQ.Trang_Thai(txt_TaiKhoan.Text);
            
        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            string A = txt_TiemKiem.Text;
            string B = cmb_ChonMuc.Text;
            try
            {
                if(A=="" || B=="")
                {
                    throw new Exception("Bạn chưa nhập thông tin tìm kiếm. Hãy nhập lại thông tin!");
                }
                else
                {
                    if(B=="Mã nhân viên")
                    {
                        dtGV_TaiKhoan.DataSource = PQ.Tim_Kiem_Theo_MaNV(A);
                    }
                    if(B=="Tên nhân viên")
                    {
                        dtGV_TaiKhoan.DataSource = PQ.Tim_Kiem_Theo_TenNV(A);
                    }
                    if(B=="Tên tài khoản")
                    {
                        dtGV_TaiKhoan.DataSource = PQ.Tim_Kiem_Theo_TenTK(A);
                    }
                }
                if (dtGV_TaiKhoan.Rows.Count == 0)
                {
                    txt_TaiKhoan.Clear();
                    txt_MaNhanVien.Clear();
                    txt_HoTen.Clear();
                    txt_MatKhau.Clear();
                    txt_DiaChi.Clear();
                    txt_SoDT.Clear();
                    time_NgaySinh.ResetText();
                    cmb_BoPhan.ResetText();
                    cmb_GioiTinh.ResetText();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txt_TiemKiem.ResetText();
                cmb_ChonMuc.ResetText();
               
            }
        }
    }
}
