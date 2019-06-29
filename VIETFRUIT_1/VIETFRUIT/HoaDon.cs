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
using DevExpress.XtraReports.UI;


namespace VIETFRUIT
{
    public partial class frm_HoaDon : Form
    {
        SanPham_BUS SP = new SanPham_BUS();
        NhanVien_BUS NV = new NhanVien_BUS();
        KhachHang_BUS KH = new KhachHang_BUS();
        KhachHang_MODEL KH1 = new KhachHang_MODEL();
        HoaDon_BUS HD = new HoaDon_BUS();
        ChiTietHoaDon_BUS CTHD = new ChiTietHoaDon_BUS();
        HoaDon_MODEL HD1 = new HoaDon_MODEL();
        ChiTietHoaDon_MODEL CTHD1 = new ChiTietHoaDon_MODEL();
        
        public frm_HoaDon()
        {
            InitializeComponent();
        }
        void Danh_Sach_San_Pham()
        {
            dtGV_SanPham.DataSource = SP.DS_SanPham();
          
        }
        void Danh_Sach_Nhan_Vien()
        {
            cmb_ThuNgan.DataSource = NV.DS_NhanVien_ThuNgan();
            cmb_ThuNgan.DisplayMember = "TEN_NHAN_VIEN";
            cmb_ThuNgan.ValueMember = "MA_NHAN_VIEN";
        }
        void Danh_Sach_Khach_Hang()
        {
            cmb_TenKH.DataSource = KH.DS_KhachHang();
            cmb_TenKH.DisplayMember = "HO_TEN";
            cmb_TenKH.ValueMember = "MA_KHACH_HANG";
            
        }
        public void Lay_Ma_Nhan_Vien(string A)
        {
            txt_MaNhanVien.Text = A;
        }
        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            Danh_Sach_San_Pham();
            
            Danh_Sach_Nhan_Vien();
            Danh_Sach_Khach_Hang();
            
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            dtGV_SanPham.DataSource = this.SP.Tim_Kiem_Ma(txt_TimKiem.Text);

        }

    

        private void txt_MaKH_TextChanged_1(object sender, EventArgs e)
        {
            cmb_TenKH.DataSource = this.KH.Tim_Kiem_Ma_Day_Du(txt_MaKH.Text);
            txt_DiemTichLuy.DataBindings.Clear();
            txt_DiemTichLuy.DataBindings.Add("Text", cmb_TenKH.DataSource, "DIEM_TICH_LUY");
        }

        private void check_KH_CheckedChanged(object sender, EventArgs e)
        {
            if(check_KH.Checked)
            {
                group_KhachHangTT.Enabled = true;

                float E = TongTien();
                if (E >= 50000 & E < 100000)
                {
                    txt_DiemNgay.Text = "5";
                }
                if (E >= 100000 & E < 200000)
                {
                    txt_DiemNgay.Text = "10";
                }
                if (E >= 200000)
                {
                    txt_DiemNgay.Text = "30";
                }

            }
            else
            {
                group_KhachHangTT.Enabled = false;
            }
        }

        string Tang_Ma_Tu_Dong()
        {
           
            string ma = HD.GetMa("SELECT TOP 1 MA_HOA_DON FROM HOA_DON ORDER BY MA_HOA_DON DESC");
            if (ma == "")
            {
                return "HD0001";
            }
            else
            {
                string s = ma.Substring(2, ma.Length - 2);
                int i = int.Parse(s);
                i++;
                if (i < 10) return "HD000" + Convert.ToString(i);
                else
                    if (i < 100) return "HD00" + Convert.ToString(i);
                    else if (i < 1000) return "HD0" + Convert.ToString(i);
                    else return "HD" + Convert.ToString(i);
            }
                    
        }
       float TongTien()
        {
            float TongTien = 0;
            for (int i = 0; i < listView_GioHang.Items.Count; i++)
            {
                float F = float.Parse(listView_GioHang.Items[i].SubItems[4].Text);
                TongTien = TongTien + F;
               
            }
            return TongTien;
        }

       bool Kiem_Tra_Trung_San_Pham(string A)
       {
           bool TF = false;
           for (int i = 0; i < listView_GioHang.Items.Count; i++)
           {
               if (A == listView_GioHang.Items[i].SubItems[0].Text)
               {
                   TF = true;
               }
         
           }
           return TF;

       }
        private void bt_Them_Click(object sender, EventArgs e)
        {
            try
            {
                
                ListViewItem item = new ListViewItem();
                if (txt_KhoiLuong.Text == ""|| txt_MaHoaDon.Text==""||  txt_MaNhanVien.Text.Length !=5 || cmb_ThuNgan.Text=="")
                {
                    throw new Exception("Bạn chưa có mã hóa đơn."+Environment.NewLine+"Thông tin nhân viên còn thiếu."+Environment.NewLine+"Bạn chưa nhập khối lượng."+Environment.NewLine+"Vui lòng nhập đầy đủ thông tin!");
                   
                }
                else
                {
                    if (HD.Lay_Khoi_Luong(dtGV_SanPham[0, dtGV_SanPham.SelectedRows[0].Index].Value.ToString()) == 0)
                    {
                        throw new Exception("Kho sản phẩm đã hết hàng. Xin lỗi về sự bất tiện này!");
                    }
                    else
                    {
                        if (HD.Lay_Khoi_Luong(dtGV_SanPham[0, dtGV_SanPham.SelectedRows[0].Index].Value.ToString()) < float.Parse(txt_KhoiLuong.Text))
                        {
                            throw new Exception("Kho sản phẩm không đủ hàng. Xin lỗi về bất tiện này!");
                        }
                        else
                        {
                            if (listView_GioHang.Items.Count == 0)
                            {
                                item.Text = dtGV_SanPham[0, dtGV_SanPham.SelectedRows[0].Index].Value.ToString();
                                item.SubItems.Add(dtGV_SanPham[1, dtGV_SanPham.SelectedRows[0].Index].Value.ToString());
                                item.SubItems.Add(txt_KhoiLuong.Text);
                                item.SubItems.Add(dtGV_SanPham[4, dtGV_SanPham.SelectedRows[0].Index].Value.ToString());
                                float A = float.Parse(txt_KhoiLuong.Text);
                                float B = float.Parse(dtGV_SanPham[4, dtGV_SanPham.SelectedRows[0].Index].Value.ToString());
                                float ThanhTien = A * B;
                                item.SubItems.Add(ThanhTien.ToString());
                                listView_GioHang.Items.Add(item);
                            }
                            else
                            {
                                string C = dtGV_SanPham[0, dtGV_SanPham.SelectedRows[0].Index].Value.ToString();
                                if (Kiem_Tra_Trung_San_Pham(C) == true)
                                {
                                    for (int i = 0; i < listView_GioHang.Items.Count; i++)
                                    {
                                        if (listView_GioHang.Items[i].Text == C)
                                        {
                                            listView_GioHang.Items[i].SubItems[2].Text = (float.Parse(listView_GioHang.Items[i].SubItems[2].Text) + float.Parse(txt_KhoiLuong.Text)).ToString();
                                            listView_GioHang.Items[i].SubItems[4].Text = (float.Parse(listView_GioHang.Items[i].SubItems[2].Text) * float.Parse(dtGV_SanPham[4, dtGV_SanPham.SelectedRows[0].Index].Value.ToString())).ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    item.Text = dtGV_SanPham[0, dtGV_SanPham.SelectedRows[0].Index].Value.ToString();
                                    item.SubItems.Add(dtGV_SanPham[1, dtGV_SanPham.SelectedRows[0].Index].Value.ToString());
                                    item.SubItems.Add(txt_KhoiLuong.Text);
                                    item.SubItems.Add(dtGV_SanPham[4, dtGV_SanPham.SelectedRows[0].Index].Value.ToString());
                                    float A = float.Parse(txt_KhoiLuong.Text);
                                    float B = float.Parse(dtGV_SanPham[4, dtGV_SanPham.SelectedRows[0].Index].Value.ToString());
                                    float ThanhTien = A * B;
                                    item.SubItems.Add(ThanhTien.ToString());
                                    listView_GioHang.Items.Add(item);
                                }
                            }

                            txt_TongTien.Text = TongTien().ToString(("#,##0 VNĐ"));

                            if (check_KH.Checked)
                            {
                                float E = TongTien();
                                if (E >= 50000 & E < 100000)
                                {
                                    txt_DiemNgay.Text = "5";
                                }
                                if (E >= 100000 & E < 200000)
                                {
                                    txt_DiemNgay.Text = "10";
                                }
                                if (E >= 200000)
                                {
                                    txt_DiemNgay.Text = "30";
                                }
                                int I = int.Parse(txt_DiemTichLuy.Text);
                                int G = int.Parse(txt_DiemNgay.Text);
                                int H = I + G;
                                txt_TongDiem.Text = H.ToString();
                                

                            }
                        }
                    }
                    
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show("CẢNH BÁO:"+Environment.NewLine+Ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                txt_KhoiLuong.ResetText();
                if(listView_GioHang.Items.Count>0)
                {
                    bt_ThanhToan.Enabled = true;
                    bt_Xoa.Enabled = true;
                }
              
            }
                
        }

        private void bt_HoaDonMoi_Click(object sender, EventArgs e)
        {
            txt_MaHoaDon.Text = Tang_Ma_Tu_Dong();
            txt_MaNhanVien.Text = "NV";
            txt_MaKH.Text = "KH";
            check_KH.Checked = false;
            txt_KhoiLuong.ResetText();
            Danh_Sach_San_Pham();
            txt_GiamGia.Text = "0";
            txt_TongTien.Text = "0";
            txt_TienMat.Text = "0";
            txt_DiemTichLuy.Text = "0";
            txt_DiemNgay.Text = "0";
            txt_TongDiem.ResetText();
            txt_TienThua.ResetText();
            bt_Them.Enabled = true;
            bt_HoaDonMoi.Enabled = false;
           foreach(ListViewItem item in listView_GioHang.Items)
           {
               listView_GioHang.Items.Remove(item);
               
           }

        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView_GioHang.SelectedItems.Count == 0)
                {
                    throw new Exception("Không có sản phẩm trong giỏ hàng!");
                }
                else
                {
                    foreach (ListViewItem item in listView_GioHang.SelectedItems)
                    {
                        listView_GioHang.Items.Remove(item);
                                      
                     }
                     txt_TongTien.Text = TongTien().ToString();
                }
                    
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (listView_GioHang.Items.Count == 0)
                {
                    txt_TongTien.Text = "0";
                    bt_ThanhToan.Enabled = false;
                    bt_Xoa.Enabled = false;
                }
            }
        }

        float Thanh_Toan()
        {
            float A = float.Parse(txt_TienMat.Text);
            float B = TongTien();
            float D = float.Parse(txt_GiamGia.Text);
            D = D / 100;
            float E = B * D;
            B = B - E;
            float C=0;
            
            if(A>=B)
            {
                 C = A - B;
            }
            return C;
        }


        private void bt_ThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_MaNhanVien.Text.Length != 5 || cmb_ThuNgan.Text == "" ||  txt_TongTien.Text == "0" || txt_TienMat.Text == "" || txt_GiamGia.Text == "")
                {
                    throw new Exception("Thanh toán không thành công" + Environment.NewLine + "Thông tin nhân viên còn thiếu." + Environment.NewLine + "Thông tin thanh toán không đủ.");
                }
                else
                {
                    
                    HD1.MA_HOA_DON1 = txt_MaHoaDon.Text;
                    HD1.MA_NHAN_VIEN1 = txt_MaNhanVien.Text;
                    HD1.NGAY_TAO1 = DateTime.Parse(time_NgayTao.Text);
                    HD1.TONG_TIEN1 = TongTien();
                    CTHD1.MA_HOA_DON1 = txt_MaHoaDon.Text;
                    float A = float.Parse(txt_TienMat.Text);
                    float B = TongTien();
                   
                    if (A< B)
                    {
                        throw new Exception("Số tiền không đủ để thanh toán!");
                    }
                    else
                    {
                         txt_TienThua.Text = Thanh_Toan().ToString(("#,##0 VNĐ"));
                        if (check_KH.Checked)
                        {
                            if(txt_MaKH.Text.Length != 5 || cmb_TenKH.Text == "" )
                            {
                                throw new Exception("Bạn chưa nhập đủ thông tin khách hàng!");
                            }
                            else
                            {
                            HD1.MA_KHACH_HANG1 = txt_MaKH.Text;

                            KH1.DIEM_TICH_LUY1 = int.Parse(txt_TongDiem.Text);
                            KH1.MA_KHACH_HANG1 = txt_MaKH.Text;
                            HD.Them_HoaDon(HD1);
                            KH.Sua_DiemKhachHang(KH1);
                            }
                        }
                        else
                        {
                            HD.Them_HoaDon_KhongMaKH(HD1);
                        }
                        for (int i = 0; i < listView_GioHang.Items.Count; i++)
                        {


                            CTHD1.MA_SAN_PHAM1 = listView_GioHang.Items[i].SubItems[0].Text;
                            CTHD1.KHOI_LUONG1 = float.Parse(listView_GioHang.Items[i].SubItems[2].Text);
                            CTHD1.DON_GIA1 = float.Parse(listView_GioHang.Items[i].SubItems[3].Text);
                            CTHD1.THANH_TIEN1 = float.Parse(listView_GioHang.Items[i].SubItems[4].Text);

                            CTHD.Them_ChiTietHoaDon(CTHD1);
                        }


                        MessageBox.Show("Hóa đơn " + txt_MaHoaDon.Text + " đã thanh toán!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        bt_ThanhToan.Enabled = false;
                        bt_Xoa.Enabled = false;
                        bt_Them.Enabled = false;
                        bt_XuatHoaDon.Enabled = true;
                        bt_HoaDonMoi.Enabled = true;
                    }
   
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
      
        }




        private void txt_MaNhanVien_TextChanged(object sender, EventArgs e)
        {
            cmb_ThuNgan.DataSource = this.NV.Tim_Kiem_Ma_Day_Du(txt_MaNhanVien.Text);
        }

        private void txt_TimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_KhoiLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (txt_KhoiLuong.Text.Length == 0 || txt_KhoiLuong.Text.IndexOf('.') != -1)))) //Dấu chấm 
            {
                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_TienMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar)) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_GiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (txt_GiamGia.Text.Length == 0 || txt_GiamGia.Text.IndexOf('.') != -1)))) //Dấu chấm 
            {

                e.Handled = true;
                MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_DiemTichLuy_TextChanged(object sender, EventArgs e)
        {
            int a = int.Parse(txt_DiemNgay.Text);
            int b = int.Parse(txt_DiemTichLuy.Text);
            txt_TongDiem.Text = (a + b).ToString();
        }

        private void txt_GiamGia_TextChanged(object sender, EventArgs e)
        {
            if (txt_GiamGia.Text != "")
            {
                float a = float.Parse(txt_GiamGia.Text);
                if (a > 100)
                {
                    MessageBox.Show("Giảm giá không đúng.(Giảm giá < 100%)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_GiamGia.ResetText();
                }
            }
        }

        private void bt_XuatHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                Report_HoaDon RP = new Report_HoaDon();
                RP.lb_SoHoaDon.Text = txt_MaHoaDon.Text;
                RP.rpLB_GiamGia.Text = txt_GiamGia.Text;
                RP.rpLB_ThuNgan.Text = cmb_ThuNgan.Text;
                RP.rpLB_TienKhach.Text = txt_TienMat.Text;
                RP.rpLB_TienThoi.Text = txt_TienThua.Text;
                RP.rpLB_TongTien.Text = txt_TongTien.Text;
                RP.rpLB_Giio.Text = DateTime.Now.ToLongTimeString();
                if(check_KH.Checked)
                {
                    RP.rpLB_KhachHang.Text = cmb_TenKH.Text;
                    RP.rpLB_DiemNgay.Text = txt_DiemNgay.Text;
                }
                else
                {
                    RP.rpLB_KhachHang.Text = "";
                    RP.rpLB_DiemNgay.Text = "0";
                }
                RP.DataSource = HD.Xuat_Hoa_Don(txt_MaHoaDon.Text);
                ReportPrintTool tool = new ReportPrintTool(RP);
                tool.ShowPreview();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                bt_XuatHoaDon.Enabled = false;
            }
        }

   
    }
}
