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
    public partial class frm_DoiMatKhau : Form
    {
        TaiKhoan_BUS TK = new TaiKhoan_BUS();
        TaiKhoan_MODEL TK1 = new TaiKhoan_MODEL();
        public frm_DoiMatKhau()
        {
            InitializeComponent();
        }

   
        private void bt_ThayDoi_Click(object sender, EventArgs e)
        {
            string A = txt_TenTaiKhoan.Text;
            string B = txt_MatKhauCu.Text;
            string C = txt_MatKhauMoi.Text;
            TK1.TEN_TAI_KHOAN1 = A;
            TK1.MAT_KHAU1 = C;
            DataTable tb = TK.Dang_Nhap(A,B);
            
            try
            {
                if (txt_TenTaiKhoan.Text == "" || txt_MatKhauCu.Text == ""  || txt_MatKhauMoi.Text =="")
                {
                    throw new Exception("Bạn chưa điền đầy đủ thông tin để đổi mật khẩu. Mời điền lại thông tin lại!");

                }
                else
                {
                    if(tb.Rows.Count>0)
                    {
                        TK.Doi_Mat_Khau(TK1);
                        MessageBox.Show("Đổi mật khẩu thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception("Thông tin tài khoản, mật khẩu không chính xác!");
                    }
                }

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txt_TenTaiKhoan.ResetText();
                txt_MatKhauCu.ResetText();
                txt_MatKhauMoi.ResetText();
               
            }
        }

        private void txt_MatKhauMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (/*char.IsLetter(e.KeyChar) || *//*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar) /* */) //Dấu chấm 
            {
                
                e.Handled = true;
                MessageBox.Show("Chỉ nhập kí tự thường","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }




        }
        public bool Unicode(string A)
        {
            const int Kitu = 128;
            return A.ToCharArray().Any(c => c > Kitu);
            
        }
        private void txt_MatKhauMoi_TextChanged(object sender, EventArgs e)
        {
            if(Unicode(txt_MatKhauMoi.Text)==true)
            {
                MessageBox.Show("Không chứ dấu tiếng việt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MatKhauMoi.ResetText();
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
