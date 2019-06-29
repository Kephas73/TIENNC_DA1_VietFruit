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

namespace VIETFRUIT
{
    public partial class frm_KhuyenMai : Form
    {
        KhachHang_BUS KH = new KhachHang_BUS();
        public frm_KhuyenMai()
        {
            InitializeComponent();
        }
        void Danh_Sach_Khach_Hang()
        {
            dtGV_KhachHang.DataSource = KH.DS_KhachHang();
            dtGV_KhachHang.ReadOnly = true;
        }

        private void frm_KhuyenMai_Load(object sender, EventArgs e)
        {
            Danh_Sach_Khach_Hang();
        }

        private void dtGV_KhachHang_SelectionChanged(object sender, EventArgs e)
        {
            txt_MaKH.DataBindings.Clear();
            txt_MaKH.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "MA_KHACH_HANG");
            txt_HoTen.DataBindings.Clear();
            txt_HoTen.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "HO_TEN");
            txt_DiaChi.DataBindings.Clear();
            txt_DiaChi.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "DIA_CHI");
            txt_Email.DataBindings.Clear();
            txt_Email.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "EMAIL");
            txt_DiemTichLuy.DataBindings.Clear();
            txt_DiemTichLuy.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "DIEM_TICH_LUY");
            cmb_GioiTinh.DataBindings.Clear();
            cmb_GioiTinh.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "GIOI_TINH");
            txt_SCMND.DataBindings.Clear();
            txt_SCMND.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "SCMND");
            time_NgaySinh.DataBindings.Clear();
            time_NgaySinh.DataBindings.Add("Value", dtGV_KhachHang.DataSource, "NGAY_SINH");
            txt_SoDT.DataBindings.Clear();
            txt_SoDT.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "SO_DIEN_THOAI");
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

            if (cmb_ChonMuc.Text == "Điểm tích lũy")
            {
                txt_TimDiem.Enabled = true;
            }
            else
            {
                txt_TimDiem.Enabled = false;
            }

        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            string A = txt_TimKiem.Text;
            string B = cmb_ChonMuc.Text;
            try
            {
                if (B == "Điểm tích lũy")
                {
                    if (txt_TimDiem.Text == "")
                    {
                        throw new Exception("Bạn chưa nhập điểm tích lũy!");
                    }
                    else
                    {
                        dtGV_KhachHang.DataSource = KH.Lay_Diem_Tich_Luy(int.Parse(txt_TimDiem.Text));
                    }
                    if (dtGV_KhachHang.Rows.Count == 0)
                    {
                        txt_MaKH.Clear();
                        txt_DiaChi.Clear();
                        txt_Email.Clear();
                        txt_DiemTichLuy.Clear();
                        cmb_GioiTinh.ResetText();
                        txt_SCMND.Clear();
                        time_NgaySinh.ResetText();
                        txt_SoDT.Clear();
                        txt_HoTen.Clear();

                    }
                }
                else
                {

                    if (A == "" || B == "")
                    {
                        throw new Exception("Bạn chưa nhập thông tin tìm kiếm. Hãy nhập lại thông tin!");
                    }

                    else
                    {
                        if (B == "Tên khách hàng")
                        {
                            dtGV_KhachHang.DataSource = KH.Tim_Kiem_Ten(A);
                        }
                        if (B == "Mã khách hàng")
                        {
                            dtGV_KhachHang.DataSource = KH.Tim_Kiem_Ma(A);
                        }

                        if (dtGV_KhachHang.Rows.Count == 0)
                        {
                            txt_MaKH.Clear();
                            txt_DiaChi.Clear();
                            txt_Email.Clear();
                            txt_DiemTichLuy.Clear();
                            cmb_GioiTinh.ResetText();
                            txt_SCMND.Clear();
                            time_NgaySinh.ResetText();
                            txt_SoDT.Clear();
                            txt_HoTen.Clear();

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txt_TimKiem.ResetText();
                cmb_ChonMuc.ResetText();
                txt_TimKiem.ResetText();
            }
        }

        private void bt_TaiLai_Click(object sender, EventArgs e)
        {
            Danh_Sach_Khach_Hang();
        }

        private void dtGV_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
