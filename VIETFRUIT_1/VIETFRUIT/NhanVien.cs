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
    public partial class frm_NhanVien : Form
    {
        NhanVien_BUS NV = new NhanVien_BUS();
        NhanVien_MODEL NV1 = new NhanVien_MODEL();
        bool Trang_Thai = false;
        public frm_NhanVien()
        {
            InitializeComponent();
        }
        void Danh_Sach_Nhan_Vien()
        {
            dtGV_NhanVien.DataSource = NV.DS_NhanVien();
            dtGV_NhanVien.ReadOnly = true;
        }
        private void bt_TaiLai_Click(object sender, EventArgs e)
        {
            Danh_Sach_Nhan_Vien();

            KichHoat(false);

            Kich_Hoat_Button(true);
            dtGV_NhanVien.Enabled = true;
        }
        void KichHoat(bool TF)
        {
            txt_HoTen.Enabled = TF;
            cmb_GioiTinh.Enabled = TF;
            time_NgaySinh.Enabled = TF;
            cmb_BoPhan.Enabled = TF;
            txt_SoDT.Enabled = TF;
            txt_SoCMND.Enabled = TF;
            txt_Email.Enabled = TF;
            txt_DiaChi.Enabled = TF;
            txt_Luong.Enabled = TF;

            bt_Luu.Enabled = TF;
            bt_Huy.Enabled = TF;
        }
        void Dat_Lai()
        {
            txt_HoTen.ResetText();
            time_NgaySinh.ResetText();
            txt_SoDT.ResetText();
            txt_SoCMND.ResetText();
            txt_Email.ResetText();
            txt_DiaChi.ResetText();
            txt_Luong.ResetText();
        }
        void Kich_Hoat_Button(bool TF)
        {
            bt_Them.Enabled = TF;
            bt_Sua.Enabled = TF;
            bt_Xoa.Enabled = TF;
        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
        
            Danh_Sach_Nhan_Vien();
            KichHoat(false);
            
        }




        private void dtGV_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            txt_Ma.DataBindings.Clear();
            txt_Ma.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "MA_NHAN_VIEN");
            txt_HoTen.DataBindings.Clear();
            txt_HoTen.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "TEN_NHAN_VIEN");
            cmb_GioiTinh.DataBindings.Clear();
            cmb_GioiTinh.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "GIOI_TINH");
            time_NgaySinh.DataBindings.Clear();
            time_NgaySinh.DataBindings.Add("Value", dtGV_NhanVien.DataSource, "NGAY_SINH");
            cmb_BoPhan.DataBindings.Clear();
            cmb_BoPhan.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "TEN_BO_PHAN");
            txt_SoDT.DataBindings.Clear();
            txt_SoDT.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "SO_DIEN_THOAI");
            txt_SoCMND.DataBindings.Clear();
            txt_SoCMND.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "SCMND");
            txt_Email.DataBindings.Clear();
            txt_Email.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "EMAIL");
            txt_DiaChi.DataBindings.Clear();
            txt_DiaChi.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "DIA_CHI");
            txt_Luong.DataBindings.Clear();
            txt_Luong.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "LUONG_CO_BAN");
        }
        string Tang_Ma_Tu_Dong()
        {
            string ma = NV.GetMa("SELECT TOP 1 MA_NHAN_VIEN FROM NHAN_VIEN ORDER BY MA_NHAN_VIEN DESC");
            if (ma == "")
            {
                return "NV001";
            }
            else
            {
                string s = ma.Substring(2, ma.Length - 2);
                int i = int.Parse(s);
                i++;
                if (i < 10) return "NV00" + Convert.ToString(i);
                else
                    if (i < 100) return "NV0" + Convert.ToString(i);
                    else return "NV" + Convert.ToString(i);
            }
        }

 
        private void bt_Sua_Click(object sender, EventArgs e)
        {
            KichHoat(true);
            Kich_Hoat_Button(false);
            dtGV_NhanVien.Enabled = false;
            Trang_Thai = false;
            bt_Tim.Enabled = false;
            bt_TaiLai.Enabled = false;
        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult tl = MessageBox.Show("Bạn muốn xóa nhân viên có tên " + txt_HoTen.Text.ToUpper() + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (tl == DialogResult.Yes)
                {
                    NV1.MA_NHAN_VIEN1 = txt_Ma.Text;
                    NV.Xoa_NhanVien(NV1);
                    MessageBox.Show("Xóa nhân viên có tên: " + txt_HoTen.Text.ToUpper() + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Danh_Sach_Nhan_Vien();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message + Environment.NewLine +"CẢNH BÁO: Nhân viên bạn muốn xóa có liên quan đến nhiều thông tin khác của hệ thống. Bạn phải xóa thông tin nhân viên trong hóa đơn, chấm công,tính lương,.. trước khi xóa vĩnh viễn thông tin nhân viên này. Xin lỗi về sự bất tiện này!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                Danh_Sach_Nhan_Vien();
                KichHoat(false);
                Kich_Hoat_Button(true);
                dtGV_NhanVien.Enabled = true;
            }
        }

        private void bt_Huy_Click(object sender, EventArgs e)
        {
            dtGV_NhanVien.Enabled = true;
            Kich_Hoat_Button(true);
            KichHoat(false);
            Dat_Lai();
            Danh_Sach_Nhan_Vien();
            bt_Tim.Enabled = true;
            bt_TaiLai.Enabled = true;
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Ma.Text == "" || txt_HoTen.Text == "" || txt_Luong.Text == "" || cmb_BoPhan.Text == "" || cmb_GioiTinh.Text == "" || time_NgaySinh.Text == "" || txt_SoCMND.Text == "" || txt_DiaChi.Text == "")
                {
                    throw new Exception("Bạn chưa nhập đầy đủ thông tin sản phẩm để thêm hoặc sửa!");
                }
                else
                {
                    NV1.MA_NHAN_VIEN1 = txt_Ma.Text;
                    NV1.TEN_NHAN_VIEN1 = txt_HoTen.Text;
                    NV1.GIOI_TINH1 = cmb_GioiTinh.Text;
                    NV1.NGAY_SINH1 = DateTime.Parse(time_NgaySinh.Text);
                    NV1.TEN_BO_PHAN1 = cmb_BoPhan.Text;
                    NV1.SO_DIEN_THOAI1 = txt_SoDT.Text;
                    NV1.SCMND1 = txt_SoCMND.Text;
                    NV1.EMAIL1 = txt_Email.Text;
                    NV1.DIA_CHI1 = txt_DiaChi.Text;
                    NV1.LUONG_CO_BAN1 = float.Parse(txt_Luong.Text);
                    NV1.ANH1 = "";
                    if (Trang_Thai == true)
                    {
                        NV.Them_NhanVien(NV1);
                        MessageBox.Show("Bạn đã thêm nhân viên có tên " + txt_HoTen.Text.ToUpper() + " thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        NV.Sua_NhanVien(NV1);
                        MessageBox.Show("Bạn đã sửa thông tin nhân viên " + txt_HoTen.Text.ToUpper() + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                Kich_Hoat_Button(true);
                KichHoat(false);
                Dat_Lai();
                dtGV_NhanVien.Enabled = true;
                Danh_Sach_Nhan_Vien();
                bt_Tim.Enabled = true;
                bt_TaiLai.Enabled = true;
            }
        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            string A = txt_TiemKiem.Text;
            string B = cmb_ChonMuc.Text;
            try
            {
                if (A == "" || B == "")
                {
                    throw new Exception("Bạn chưa nhập thông tin tìm kiếm. Hãy nhập lại thông tin!");
                }
                else
                {
                    if (B == "Mã nhân viên")
                    {
                        dtGV_NhanVien.DataSource = NV.Tim_Kiem_Ma(A);
                    }
                    if (B == "Tên nhân viên")
                    {
                        dtGV_NhanVien.DataSource = NV.Tim_Kiem_Ten(A);
                    }
                    if (B == "Địa chỉ")
                    {
                        dtGV_NhanVien.DataSource = NV.Tim_Kiem_DiaChi(A);
                    }
                }
                if(dtGV_NhanVien.Rows.Count==0)
                {

                    txt_Ma.Clear();
                    txt_HoTen.Clear();
                    txt_DiaChi.Clear();
                    txt_Luong.Clear();
                    txt_Email.Clear();
                    txt_SoDT.Clear();
                    txt_SoCMND.Clear();
                    time_NgaySinh.ResetText();
                    cmb_GioiTinh.ResetText();
                    cmb_BoPhan.ResetText();
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

        private void txt_HoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (/*char.IsLetter(e.KeyChar) || Ký tự Alphabe */char.IsSymbol(e.KeyChar) /*|| Ký tự đặc biệt char.IsWhiteSpace(e.KeyChar) */|| /*Khoảng cách*/  char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập kí tự thường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_SoDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_SoCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_Luong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void bt_Them_Click_1(object sender, EventArgs e)
        {
            txt_Ma.Text = Tang_Ma_Tu_Dong();
            KichHoat(true);
            Kich_Hoat_Button(false);
            dtGV_NhanVien.Enabled = false;
            Dat_Lai();
            Trang_Thai = true;
            bt_Tim.Enabled = false;
            bt_TaiLai.Enabled = false;
        }



    }
}
