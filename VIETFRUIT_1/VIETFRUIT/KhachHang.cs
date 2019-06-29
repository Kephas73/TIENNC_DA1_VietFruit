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
    public partial class frm_KhachHang : Form
    {
        KhachHang_BUS KH = new KhachHang_BUS();
        KhachHang_MODEL KH1 = new KhachHang_MODEL();
        bool Trang_Thai = false;
        public frm_KhachHang()
        {
            InitializeComponent();
        }

        void Danh_Sach_Khach_Hang()
        {
            dtGV_KhachHang.DataSource = KH.DS_KhachHang();
            dtGV_KhachHang.ReadOnly = true;

          
        }
        private void bt_TaiLai_Click(object sender, EventArgs e)
        {
            Danh_Sach_Khach_Hang();
            Kich_Hoat(false);
            Kich_Hoat_Button(true);
            dtGV_KhachHang.Enabled = true;
        }
        
        void Kich_Hoat(bool TF)
        {
            txt_Hoten.Enabled = TF;
            cmb_GioiTinh.Enabled = TF;
            time_NgaySinh.Enabled = TF;
            txt_SDT.Enabled = TF;
            txt_SCMND.Enabled = TF;
            txt_DiemTichLuy.Enabled = TF;
            txt_Email.Enabled = TF;
            txt_DiaChi.Enabled = TF;

            bt_Luu.Enabled = TF;
            bt_Huy.Enabled = TF;
        }
        void Dat_Lai()
        {
            txt_Hoten.ResetText();
            txt_SDT.ResetText();
            txt_SCMND.ResetText();
            time_NgaySinh.ResetText();
            txt_DiemTichLuy.ResetText();
            txt_Email.ResetText();
            txt_DiaChi.ResetText();
        }
        void Kich_Hoat_Button(bool TF)
        {
            bt_Them.Enabled = TF;
            bt_Xoa.Enabled = TF;
            bt_Sua.Enabled = TF;
        }
        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
          
            Danh_Sach_Khach_Hang();
            Kich_Hoat(false);
        }

        private void dtGV_KhachHang_SelectionChanged(object sender, EventArgs e)
        {
            txt_MaKH.DataBindings.Clear();
            txt_MaKH.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "MA_KHACH_HANG");
            txt_Hoten.DataBindings.Clear();
            txt_Hoten.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "HO_TEN");
            cmb_GioiTinh.DataBindings.Clear();
            cmb_GioiTinh.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "GIOI_TINH");
            time_NgaySinh.DataBindings.Clear();
            time_NgaySinh.DataBindings.Add("Value",dtGV_KhachHang.DataSource,"NGAY_SINH");
            txt_SDT.DataBindings.Clear();
            txt_SDT.DataBindings.Add("Text",dtGV_KhachHang.DataSource,"SO_DIEN_THOAI");
            txt_SCMND.DataBindings.Clear();
            txt_SCMND.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "SCMND");
            txt_DiemTichLuy.DataBindings.Clear();
            txt_DiemTichLuy.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "DIEM_TICH_LUY");
            txt_Email.DataBindings.Clear();
            txt_Email.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "EMAIL");
            txt_DiaChi.DataBindings.Clear();
            txt_DiaChi.DataBindings.Add("Text", dtGV_KhachHang.DataSource, "DIA_CHI");

        }

        string Tang_Ma_Tu_Dong()
        {
            string ma = KH.GetMa("SELECT TOP 1 MA_KHACH_HANG FROM KHACH_HANG ORDER BY MA_KHACH_HANG DESC");
            if (ma == "")
            {
                return "KH001";
            }
            else
            {
                string s = ma.Substring(2, ma.Length - 2);
                int i = int.Parse(s);
                i++;
                if (i < 10) return "KH00" + Convert.ToString(i);
                else
                    if (i < 100) return "KH0" + Convert.ToString(i);
                    else return "KH" + Convert.ToString(i);
            }
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
            dtGV_KhachHang.Enabled = false;
            Kich_Hoat(true);
            Dat_Lai();
            Kich_Hoat_Button(false);
            txt_MaKH.Text = Tang_Ma_Tu_Dong();
            Trang_Thai=true;
            bt_Tim.Enabled = false;
            bt_TaiLai.Enabled = false;
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            dtGV_KhachHang.Enabled = false;
            Kich_Hoat(true);
            Kich_Hoat_Button(false);
            Trang_Thai = false;
            bt_Tim.Enabled = false;
            bt_TaiLai.Enabled = false;
            
        }

        private void bt_Huy_Click(object sender, EventArgs e)
        {
            Kich_Hoat(false);
            dtGV_KhachHang.Enabled = true;
            Kich_Hoat_Button(true);
            Dat_Lai();
            Danh_Sach_Khach_Hang();
            bt_Tim.Enabled = true;
            bt_TaiLai.Enabled = true;
        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn muốn xóa khách hàng có tên là "+ txt_Hoten.Text.ToUpper() +" không","Cảnh báo!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            try
            {
                if (tl == DialogResult.Yes)
                {
                    KH1.MA_KHACH_HANG1 = txt_MaKH.Text;
                    KH.Xoa_KhachHang(KH1);
                    MessageBox.Show("Xóa khách hàng " + txt_Hoten.Text.ToUpper() + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Danh_Sach_Khach_Hang();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message + Environment.NewLine + "CẢNH BÁO: Thông tin khách hàng bạn muốn xóa liên quan đến thông tin hóa đơn. Cần xóa thông tin khách hàng trong hóa đơn trước khi xóa vĩnh viễn thông tin khách hàng này. Xin lỗi vì sự bất tiện này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Danh_Sach_Khach_Hang();
                Kich_Hoat(false);
                Kich_Hoat_Button(true);
                dtGV_KhachHang.Enabled = true;
            }
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_MaKH.Text == "" || txt_Hoten.Text == "" || txt_SDT.Text == "" || txt_DiemTichLuy.Text == "" || cmb_GioiTinh.Text == "" || txt_SDT.Text == "")
                {
                    throw new Exception("Bạn chưa nhập đầy đủ thông tin sản phẩm để thêm hoặc sửa!");
                }
                else
                {
                    KH1.MA_KHACH_HANG1 = txt_MaKH.Text;
                    KH1.HO_TEN1 = txt_Hoten.Text;
                    KH1.GIOI_TINH1 = cmb_GioiTinh.Text;
                    KH1.NGAY_SINH1 = DateTime.Parse(time_NgaySinh.Text);
                    KH1.SO_DIEN_THOAI1 = txt_SDT.Text;
                    KH1.SCMND1 = txt_SCMND.Text;
                    KH1.DIEM_TICH_LUY1 = int.Parse(txt_DiemTichLuy.Text);
                    KH1.EMAIL1 = txt_Email.Text;
                    KH1.DIA_CHI1 = txt_DiaChi.Text;
                    KH1.ANH1 = "";
                    if (Trang_Thai == true)
                    {
                        KH.Them_KhachHang(KH1);
                        MessageBox.Show("Bạn đã thêm khách hàng có tên " + txt_Hoten.Text.ToUpper() + " thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        KH.Sua_KhachHang(KH1);
                        MessageBox.Show("Bạn đã sửa thông  tin khách hàng có tên " + txt_Hoten.Text.ToUpper() + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                Kich_Hoat(false);
                Dat_Lai();
                Kich_Hoat_Button(true);
                dtGV_KhachHang.Enabled = true;
                Danh_Sach_Khach_Hang();
                bt_Tim.Enabled = true;
                bt_TaiLai.Enabled = true;
            }
           
        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            string A = txt_TimKiem.Text;
            string B = cmb_ChonMuc.Text;
            try
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
                    if (B == "Địa chỉ")
                    {
                        dtGV_KhachHang.DataSource = KH.Tim_Kiem_DiaChi(A);
                    }
                }
                if(dtGV_KhachHang.Rows.Count==0)
                {
                    txt_MaKH.Clear();
                    txt_Hoten.Clear();
                    txt_DiaChi.Clear();
                    txt_Email.Clear();
                    txt_DiemTichLuy.Clear();
                    txt_SCMND.Clear();
                    txt_SDT.Clear();
                    cmb_GioiTinh.ResetText();
                    time_NgaySinh.ResetText();
                }
               
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                txt_TimKiem.ResetText();
                cmb_ChonMuc.ResetText();
            }
        }

        private void txt_Hoten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (/*char.IsLetter(e.KeyChar) || Ký tự Alphabe */char.IsSymbol(e.KeyChar) /*|| Ký tự đặc biệt char.IsWhiteSpace(e.KeyChar) */|| /*Khoảng cách*/  char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập kí tự thường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_SCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_DiemTichLuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
         


    }
}
