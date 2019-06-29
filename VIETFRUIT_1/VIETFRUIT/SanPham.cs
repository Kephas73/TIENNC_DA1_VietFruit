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
    public partial class frm_SanPham : Form
    {
        SanPham_BUS SP = new SanPham_BUS();
        KhoSanPham_MODEL SP1 = new KhoSanPham_MODEL();
        bool Trang_Thai = false;
        public frm_SanPham()
        {
            InitializeComponent();
        }
        void Danh_Sach_San_Pham()
        {
            dtGV_SanPham.DataSource = SP.DS_SanPham();
            dtGV_SanPham.ReadOnly = true;
        }
        private void bt_TaiLai_Click(object sender, EventArgs e)
        {
            Danh_Sach_San_Pham();
            Kich_Hoat(false);
            
            Kich_Hoat_Button(true);
            dtGV_SanPham.Enabled = true;
            
        }

        private void frm_SanPham_Load(object sender, EventArgs e)
        {

            Danh_Sach_San_Pham();
            Kich_Hoat(false);

        }

        private void dtGV_SanPham_SelectionChanged(object sender, EventArgs e)
        {
            txt_MaSP.DataBindings.Clear();
            txt_MaSP.DataBindings.Add("Text", dtGV_SanPham.DataSource, "MA_SAN_PHAM");
            txt_TenSP.DataBindings.Clear();
            txt_TenSP.DataBindings.Add("Text", dtGV_SanPham.DataSource, "TEN_SAN_PHAM");
            txt_KL.DataBindings.Clear();
            txt_KL.DataBindings.Add("Text", dtGV_SanPham.DataSource, "KHOI_LUONG_NHAP");
            txt_GiaNhap.DataBindings.Clear();
            txt_GiaNhap.DataBindings.Add("Text", dtGV_SanPham.DataSource, "GIA_NHAP_VAO");
            txt_GBan.DataBindings.Clear();
            txt_GBan.DataBindings.Add("Text", dtGV_SanPham.DataSource, "GIA_BAN_RA");
            time_DongGoi.DataBindings.Clear();
            time_DongGoi.DataBindings.Add("Value", dtGV_SanPham.DataSource, "NGAY_DONG_GOI");
            time_HetHan.DataBindings.Clear();
            time_HetHan.DataBindings.Add("Value", dtGV_SanPham.DataSource, "NGAY_HET_HAN");
            txt_NhaCC.DataBindings.Clear();
            txt_NhaCC.DataBindings.Add("Text", dtGV_SanPham.DataSource, "NHA_CUNG_CAP");
            txt_XuatXu.DataBindings.Clear();
            txt_XuatXu.DataBindings.Add("Text", dtGV_SanPham.DataSource, "NOI_XUAT_XU");
        }
        void Kich_Hoat(bool TF)
        {
            txt_TenSP.Enabled = TF;
            txt_KL.Enabled = TF;
            txt_GiaNhap.Enabled = TF;
            txt_GBan.Enabled = TF;
            time_DongGoi.Enabled = TF;
            time_HetHan.Enabled = TF;
            txt_NhaCC.Enabled = TF;
            txt_XuatXu.Enabled = TF;

            bt_Luu.Enabled = TF;
            bt_Huy.Enabled = TF;
        }
        void Dai_Lai()
        {
            txt_TenSP.ResetText();
            txt_KL.ResetText();
            txt_GiaNhap.ResetText();
            time_DongGoi.ResetText();
            time_HetHan.ResetText();
            txt_GBan.ResetText();
            txt_NhaCC.ResetText();
            txt_XuatXu.ResetText();
        }
        void Kich_Hoat_Button(bool TF)
        {
            bt_Sua.Enabled = TF;
            bt_Xoa.Enabled = TF;
            bt_Them.Enabled = TF;
        }
        string Tang_Ma_Tu_Dong()
        {      
       
              string ma = SP.GetMa("SELECT TOP 1 MA_SAN_PHAM FROM KHO_SAN_PHAM ORDER BY MA_SAN_PHAM DESC");
                if (ma == "")
                {
                    return "SP001";
                }
                else
                {
                    string s = ma.Substring(2, ma.Length - 2);
                    int i = int.Parse(s);
                    i++;
                    if (i < 10) return "SP00" + Convert.ToString(i);
                    else
                        if (i < 100) return "SP0" + Convert.ToString(i);
                        else return "SP" + Convert.ToString(i);
                }
          
        }
        private void bt_Them_Click(object sender, EventArgs e)
        {
            dtGV_SanPham.Enabled = false;
            Dai_Lai();
            txt_MaSP.Text = Tang_Ma_Tu_Dong();
            Kich_Hoat(true);
            Kich_Hoat_Button(false);
            Trang_Thai = true;
            bt_Tim.Enabled=false;
            bt_TaiLai.Enabled=false;
          
        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
           
            try
            {
                DialogResult tl = MessageBox.Show("Bạn muốn xóa sản phẩm " + txt_TenSP.Text.ToUpper() + " không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (tl == DialogResult.Yes)
                {
                    SP1.MA_SAN_PHAM1 = txt_MaSP.Text;
                    SP.Xoa_SanPham(SP1);
                    MessageBox.Show("Xóa sản phẩm " + txt_TenSP.Text.ToUpper() + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Danh_Sach_San_Pham();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message +Environment.NewLine +"CẢNH BÁO: Sản phẩm bạn muốn xóa hiện lưu trong hóa đơn. Cần xóa sản phẩm này trong hóa đơn trước khi xóa sản phẩm ngày vĩnh viễn. Xin lỗi vì sự bất tiện này!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {

                Danh_Sach_San_Pham();
                Kich_Hoat(false);

                Kich_Hoat_Button(true);
                dtGV_SanPham.Enabled = true;
            
            }
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            Kich_Hoat(true);
            Kich_Hoat_Button(false);
            Trang_Thai = false;
            dtGV_SanPham.Enabled = false;
            bt_Tim.Enabled = false;
            bt_TaiLai.Enabled = false;
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_MaSP.Text == "" || txt_TenSP.Text == "" || txt_KL.Text == "" || txt_GiaNhap.Text == "" || txt_GBan.Text == "" || txt_GBan.Text == "")
                {
                    throw new Exception("Bạn chưa nhập đầy đủ thông tin sản phẩm để thêm hoặc sửa!");
                }
                else
                {
                    SP1.MA_SAN_PHAM1 = txt_MaSP.Text;
                    SP1.TEN_SAN_PHAM1 = txt_TenSP.Text;
                    SP1.KHOI_LUONG_NHAP1 = float.Parse(txt_KL.Text);
                    SP1.GIA_NHAP_VAO1 = float.Parse(txt_GiaNhap.Text);
                    SP1.GIA_BAN_RA1 = float.Parse(txt_GBan.Text);
                    SP1.NGAY_DONG_GOI1 = DateTime.Parse(time_DongGoi.Text);
                    SP1.NGAY_HET_HAN1 = DateTime.Parse(time_HetHan.Text);
                    SP1.NHA_CUNG_CAP1 = txt_NhaCC.Text;
                    SP1.NOI_XUAT_XU1 = txt_XuatXu.Text;
                    SP1.ANH1 = "";
                    if (Trang_Thai == true)
                    {
                        SP.Them_SanPham(SP1);
                        MessageBox.Show("Thêm sản phẩm " + txt_TenSP.Text.ToUpper() + " thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);//ToUpper Hàm chuyển từ chữ Hoa sang chữ Thường.

                    }
                    else
                    {
                        SP.Sua_SanPham(SP1);
                        MessageBox.Show("Sửa sản phẩm " + txt_TenSP.Text.ToUpper() + " thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                Dai_Lai();
                Kich_Hoat_Button(true);
                dtGV_SanPham.Enabled = true;
                Danh_Sach_San_Pham();
                bt_Tim.Enabled = true;
                bt_TaiLai.Enabled = true;
            }

        }

        private void bt_Huy_Click(object sender, EventArgs e)
        {
            dtGV_SanPham.Enabled = true;
            Kich_Hoat_Button(true);
            Kich_Hoat(false);
            Dai_Lai();
            Danh_Sach_San_Pham();
            bt_Tim.Enabled = true;
            bt_TaiLai.Enabled = true;
        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            string A = cmb_ChonMuc.Text;
            string B = txt_Tim.Text;
            try
            {
                if (A == "" || B == "")
                {
                    throw new Exception("Bạn chưa nhập thông tin tìm kiếm. Hãy nhập lại thông tin!");
                }
                else
                {
                    if (A == "Tên sản phẩm")
                    {
                        dtGV_SanPham.DataSource = SP.Tim_Kiem_Ten(B);
                    }
                    if (A == "Mã sản phẩm")
                    {
                        dtGV_SanPham.DataSource = SP.Tim_Kiem_Ma(B);
                    }
                    if (A == "Nơi xuất xứ")
                    {
                        dtGV_SanPham.DataSource = SP.Tim_Kiem_XuatXu(B);
                    }
                }
                if (dtGV_SanPham.Rows.Count == 0)
                {
                    txt_MaSP.Clear();
                    txt_TenSP.Clear();
                    txt_GBan.Clear();
                    txt_GiaNhap.Clear();
                    txt_KL.Clear();
                    txt_NhaCC.Clear();
                    time_DongGoi.ResetText();
                    time_HetHan.ResetText();
                    txt_XuatXu.Clear();

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txt_Tim.ResetText();
                cmb_ChonMuc.ResetText();
            }
        }


        private void txt_TenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (/*char.IsLetter(e.KeyChar) || Ký tự Alphabe */char.IsSymbol(e.KeyChar) /*|| Ký tự đặc biệt char.IsWhiteSpace(e.KeyChar) */|| /*Khoảng cách*/  char.IsPunctuation(e.KeyChar) ) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập kí tự thường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_KL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/  char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_GiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/  char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_GBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/  char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void time_HetHan_ValueChanged(object sender, EventArgs e)
        {
            if(DateTime.Compare(time_DongGoi.Value,time_HetHan.Value)>0)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn ngày đóng gói!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                time_HetHan.ResetText();
            }

        }
    }

}



