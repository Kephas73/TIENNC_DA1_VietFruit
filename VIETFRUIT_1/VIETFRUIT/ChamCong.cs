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
    public partial class frm_ChamCong : Form
    {
        ChamCong_BUS CC = new ChamCong_BUS();
        GioLam_MODEL G1 = new GioLam_MODEL();
        NhanVien_BUS NV = new NhanVien_BUS();
        public frm_ChamCong()
        {
            InitializeComponent();
        }

  
        void Danh_Sach_Nhan_Vien()
        {
            dtGV_NhanVien.DataSource = NV.DS_NhanVien();
           
        }

        private void frm_ChamCong_Load(object sender, EventArgs e)
        {
            Danh_Sach_Nhan_Vien();
            int i;
                for(i=1;i<13;i++)
                {
                    cmb_Thang.Items.Add(i.ToString());
                }
                for(i=2017;i<2101;i++)
                {
                    cmb_Nam.Items.Add(i.ToString());
                }
        }

        private void dtGV_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            txt_MaNhanVien.DataBindings.Clear();
            txt_MaNhanVien.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "MA_NHAN_VIEN");
            txt_HoTen.DataBindings.Clear();
            txt_HoTen.DataBindings.Add("Text",dtGV_NhanVien.DataSource,"TEN_NHAN_VIEN");
            cmb_GioiTinh.DataBindings.Clear();
            cmb_GioiTinh.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "GIOI_TINH");
            time_NgaySinh.DataBindings.Clear();
            time_NgaySinh.DataBindings.Add("VALUE", dtGV_NhanVien.DataSource, "NGAY_SINH");
            cmb_BoPhan.DataBindings.Clear();
            cmb_BoPhan.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "TEN_BO_PHAN");
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
                    if(dtGV_NhanVien.Rows.Count==0)
                    {
                        txt_MaNhanVien.Clear();
                        txt_HoTen.Clear();
                        cmb_GioiTinh.ResetText();
                        cmb_ChonMuc.ResetText();
                        time_NgaySinh.ResetText();
                    }
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

        private void bt_TaiLai_Click(object sender, EventArgs e)
        {
            
            Danh_Sach_Nhan_Vien();
            Dat_Lai_Cham_Cong(false);
            txt_MaGioLam.ResetText();
            txt_SoGioLam.Text="0";
            dtGV_NhanVien.Enabled = true;
            bt_XemChiTiet.Enabled = true;
            bt_Ghi.Enabled = true;
            foreach(DataGridViewRow dr in dtGV_GioLam.Rows)
            {
                dtGV_GioLam.Rows.Remove(dr);
                foreach(DataGridViewRow dr1 in dtGV_GioLam.Rows)
                {
                    dtGV_GioLam.Rows.Remove(dr1);
                }
            }
            group_GioLam.Enabled = false;
            txt_TongGio.Clear();
            
        }
        string Tang_Ma_Tu_Dong(string A)
        {
            string B = string.Format("{0:ddMMyyyy}", DateTime.Now);
            string ma = CC.Lay_Ma_Gio(A,B);
            if(ma=="")
            {
                return "00"+"-"+B + A;
            }
            else
            {
                string s = ma.Substring(0, 2);
                int i = int.Parse(s);
                i++;
                if (i < 10) return "0" + Convert.ToString(i) + "-" + B + A;
                else return Convert.ToString(i) + "-" + B + A;
            }

        }


        void Dat_Lai_Cham_Cong(bool TF)
        {
            bt_Ghi.Enabled = !TF;
            txt_SoGioLam.Enabled = TF;
            bt_LuuGioLam.Enabled = TF;
            time_ChamCong.Enabled = TF;
            

        }
        private void bt_Ghi_Click(object sender, EventArgs e)
        {

          
            txt_MaGioLam.Text = Tang_Ma_Tu_Dong(txt_MaNhanVien.Text);
            Dat_Lai_Cham_Cong(true);

            bt_XemChiTiet.Enabled = false;
            
            
        }

        public bool Kiem_Tra_Trung_Ngay(string A, string B )
        {
            DataTable tb = CC.Lay_Ngay(A);
            bool TF = false;
            if(tb.Rows.Count >0)
            {
                foreach(DataRow dr in tb.Rows)
                {
                    if(string.Compare(dr["NGAY_LAM"].ToString(),B)==0)
                    {
                        TF = true;
                    }
                }
            }
            return TF;    
        }


        private void bt_LuuGioLam_Click(object sender, EventArgs e)
        {
            try
            {
                string A = txt_MaGioLam.Text;
                string ma = A.Substring(A.Length - 5, 5);
                if (string.Compare(ma, txt_MaNhanVien.Text) != 0) 
                {
                    throw new Exception("Mã nhân viên không trùng khớp với mã giờ làm!");
                }
                if (Kiem_Tra_Trung_Ngay(txt_MaNhanVien.Text, (time_ChamCong.SelectionStart).ToString()) == true)
                {
                    throw new Exception("Ngày chấm công trùng với ngày đã chấm!");
                }
                if (txt_SoGioLam.Text == "" )
                {
                    throw new Exception("Chưa nhập số giờ làm!");
                }
       
                else
                {
                    G1.MA_NHAN_VIEN1 = txt_MaNhanVien.Text;
                    G1.MA_GIO_LAM1 = txt_MaGioLam.Text;
                    G1.NGAY_LAM1 = time_ChamCong.SelectionStart;
                    G1.GIO_LAM1 = float.Parse(txt_SoGioLam.Text);
                    CC.Them_GioLam(G1);
                    MessageBox.Show("Ghi giờ thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Dat_Lai_Cham_Cong(false);

                    txt_SoGioLam.Text = "0";
                    txt_MaGioLam.ResetText();
                    time_ChamCong.ResetText();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
           finally
            {
                Dat_Lai_Cham_Cong(false);
                txt_SoGioLam.Text = "0";
                bt_XemChiTiet.Enabled = true;
                txt_MaGioLam.Clear();
              
            }

            
        }

        private void bt_XemChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Thang.Text == "" || cmb_Nam.Text == "" || txt_MaNhanVien.Text == "")
                {
                    throw new Exception("Bạn chưa nhập đủ thông tin mã nhân viên, tháng, năm. Vui lòng nhập lại!");
                }
                else
                {
                    dtGV_GioLam.DataSource = CC.Danh_Sach_Ngay_Lam(txt_MaNhanVien.Text, cmb_Thang.Text, cmb_Nam.Text);
                    if (dtGV_GioLam.Rows.Count == 0)
                    {
                        throw new Exception("Không có thông tin ngày làm. Vui lòng thử lại!");
                    }
                    else
                    {
                        bt_Sua.Enabled = true;
                        bt_Luu.Enabled = false;
                        group_GioLam.Enabled = true;
                        txt_TongGio.Text = CC.Tong_Gio_Lam(txt_MaNhanVien.Text, cmb_Thang.Text, cmb_Nam.Text);
                        bt_Ghi.Enabled = false;
                    }
                   
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void dtGV_GioLam_SelectionChanged(object sender, EventArgs e)
        {
            txt_Gio.DataBindings.Clear();
            txt_Gio.DataBindings.Add("Text", dtGV_GioLam.DataSource, "GIO_LAM");
           
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            txt_Gio.Enabled = true;
            bt_Luu.Enabled = true;
            bt_Sua.Enabled = false;
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            
            try
            {
                string A =  dtGV_GioLam[0, dtGV_GioLam.SelectedRows[0].Index].Value.ToString();
                string ma = A.Substring(11 , 5);
                if (string.Compare(ma, txt_MaNhanVien.Text) != 0 || txt_Gio.Text=="")
                {
                    throw new Exception("Mã nhân viên không trùng khớp với mã giờ làm!");
                }
                if(txt_Gio.Text=="")
                {
                    throw new Exception("Chưa nhập giờ làm!");
                }
                else
                {
                  
                    G1.GIO_LAM1 = float.Parse(txt_Gio.Text);
                    G1.MA_GIO_LAM1 = dtGV_GioLam[0, dtGV_GioLam.SelectedRows[0].Index].Value.ToString();
                    G1.MA_NHAN_VIEN1 = txt_MaNhanVien.Text;
                    CC.Sua_Cham_Cong(G1);
                  
                   
                    MessageBox.Show("Sửa giờ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                dtGV_GioLam.DataSource = CC.Danh_Sach_Ngay_Lam(txt_MaNhanVien.Text, cmb_Thang.Text, cmb_Nam.Text);
                txt_TongGio.Text = CC.Tong_Gio_Lam(txt_MaNhanVien.Text, cmb_Thang.Text, cmb_Nam.Text);
                bt_Luu.Enabled = false;
                bt_Sua.Enabled = true;
                txt_Gio.Enabled = false;
            }

        }

        private void txt_SoGioLam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (txt_SoGioLam.Text.Length == 0 || txt_SoGioLam.Text.IndexOf('.') != -1)))) //Dấu chấm 
            {
                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_Gio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (txt_Gio.Text.Length == 0 || txt_Gio.Text.IndexOf('.') != -1)))) //Dấu chấm 
            {
                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_SoGioLam_TextChanged(object sender, EventArgs e)
        {
            if (txt_SoGioLam.Text != "")
            {
                if (float.Parse(txt_SoGioLam.Text) > 24)
                {
                    MessageBox.Show("Số giờ không vượt quá 24", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SoGioLam.ResetText();
                }
            }
        }

        private void txt_Gio_TextChanged(object sender, EventArgs e)
        {
            if (txt_Gio.Text != "")
            {
                if (float.Parse(txt_Gio.Text) > 24)
                {
                    MessageBox.Show("Số giờ không vượt quá 24", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Gio.ResetText();
                }
            }
        }

    
    }
}
