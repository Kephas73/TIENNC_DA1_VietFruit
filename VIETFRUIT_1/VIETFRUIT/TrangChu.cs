using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;


namespace VIETFRUIT
{
    public partial class frm_TrangChu : DevExpress.XtraEditors.XtraForm
    {
        public frm_TrangChu()
        {
          Thread H = new Thread(new ThreadStart(ManHinhCho));
          H.Start();
          Thread.Sleep(6000);
          InitializeComponent();
          H.Abort();

        }

//---------Hàm để điều khiển ẩn hiện---------------------------------------------------------------------
        public void QuanLyKho(bool TF)
        {
            rbPG_QuanLyKho.Enabled = TF;
        }
        public void ThuNgan(bool TF)
        {
            rbPG_ThuNgan.Enabled = TF;
        }
        public void ChuQuanLi(bool TF)
        {
            rbPG_ChuQuanLy.Enabled = TF;
        }
        public void ThongKe(bool TF)
        {
            rbPG_ThongKe.Enabled = TF;
        }
        public void KhachHangThanThiet(bool TF)
        {
            rbPG_KhachHangThanThiet.Enabled = TF;
        }
        public void ChamCong(bool TF)
        {
            bt_ChamCong.Enabled = TF;
        }
        public void PhanQuyen(bool TF)
        {
            barbtt_PhanQuyen.Enabled = TF;
        }
        public void DangXuat(bool TF)
        {
            barbtt_DangXuat.Enabled = TF;
        }
        public void DangNhap(bool TF)
        {
            barbtt_DangNhap.Enabled = TF;
        }
//--------------------------------------------------------------------------------------------
        private void ManHinhCho()
        {
            Application.Run(new frm_ManHinhCho());
        }
        // Kiểm tra xem trong Form Cha đã tồn tại Form Con này hay chưa, trả về hai giá trị true hoặc false
        private bool Kiem_tra_Form(string name)
        {
            bool check = false;
            foreach(Form frm in this.MdiChildren)//Kiểm tra tất cả các form con xem có trùng tên ko
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        //Hiển thị lại Form Con đã có chứ không làm mới lại lần nữa.
        private void Kich_Hoat_Form(string name)
        {
            foreach (Form frm in this.MdiChildren)//Kiểm tra tất cả các form con xem có trùng tên ko
            {
                if(frm.Name==name)
                {
                    frm.Activate();//Kích hoạt lại form đó, chứ không tạo mới form
                    break;
                }
            }
        }
       
        private void barbtt_KhoHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_SanPham"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_SanPham frm = new frm_SanPham(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_SanPham");//Gọi lại form đã có
            }

        }

        private void barbtt_KiemTra_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!Kiem_tra_Form("frm_KiemTra"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_KiemTra frm = new frm_KiemTra(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_KiemTra");//Gọi lại form đã có
            }
        }

        private void barbtt_LapHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_HoaDon"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_HoaDon frm = new frm_HoaDon(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_HoaDon");//Gọi lại form đã có
            }
        }

        private void barbtt_KháchHangThanThiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_KhachHang"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_SanPham frm = new frm_SanPham(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_KhachHang");//Gọi lại form đã có
            }
        }

        private void barbtt_QLNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barbtt_TinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_TinhLuong"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_TinhLuong frm = new frm_TinhLuong(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_TinhLuong");//Gọi lại form đã có
            }
        }

        private void barbtt_DoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_DoanhThu"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_DoanhThu frm = new frm_DoanhThu(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_DoanhThu");//Gọi lại form đã có
            }
        }

        private void barbtt_SPTon_Het_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barbtt_BieuDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_BieuDo"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_BieuDo frm = new frm_BieuDo(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_BieuDo");//Gọi lại form đã có
            }
        }

        private void navB_KhachHang_ItemChanged(object sender, EventArgs e)
        {
            if (!Kiem_tra_Form("frm_BieuDo"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_BieuDo frm = new frm_BieuDo(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_BieuDo");//Gọi lại form đã có
            }
        }

        private void barbtt_Thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

      
        private void frm_TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Hoi = MessageBox.Show("Bạn muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(Hoi==DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

        }

        private void barbtt_KháchHangThanThiet_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_KhachHang"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_KhachHang frm = new frm_KhachHang(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_KhachHang");//Gọi lại form đã có
            }
        }

        private void barbtt_QLNhanVien_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_NhanVien"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_NhanVien frm = new frm_NhanVien(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_NhanVien");//Gọi lại form đã có
            }
        }


        private void barbtt_DangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DangNhap f = new frm_DangNhap(this);
            f.ShowDialog();
        }

        private void barbtt_KhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_KhuyenMai"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_KhuyenMai frm = new frm_KhuyenMai(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_KhuyenMai");//Gọi lại form đã có
            }
        }


        private void bt_ChamCong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!Kiem_tra_Form("frm_ChamCong"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_ChamCong frm = new frm_ChamCong(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_ChamCong");//Gọi lại form đã có
            }
        }

        public void frm_Load_TrangChu()
        {
            QuanLyKho(false);

            ThuNgan(false);

            ChuQuanLi(false);

            ThongKe(false);

            KhachHangThanThiet(false);

            ChamCong(false);

            PhanQuyen(false);

            DangNhap(true);

            DangXuat(false);
        }
        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            frm_Load_TrangChu();
          
            
        }

        private void barbtt_DangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(tl==DialogResult.OK)
            {
                frm_Load_TrangChu();
                foreach(Form frm in this.MdiChildren)
                {
                    frm.Close();
                }
                TieuDe("...","...","...");
            }
        }
        public void TieuDe(string A, string B, string C)
        {
           
            bar_TieuDe.Caption = "CỬA HÀNG TRÁI CÂY VIETFRUIT --> XIN CHÀO TK: " + A + " --> " + B + " - " + C + "";
        }

        private void barbtt_DoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DoiMatKhau fm = new frm_DoiMatKhau();
            fm.ShowDialog();
        }

        private void barbtt_DangKi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DangKiTaiKhoan fm = new frm_DangKiTaiKhoan();
            fm.ShowDialog();
        }

        private void barbtt_PhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_tra_Form("frm_PhanQuyen"))//Nếu không có form Kho Hàng trong form Cha
            {
                frm_PhanQuyen frm = new frm_PhanQuyen(); //Tạo mới form
                frm.MdiParent = this;//form con nằm trong form cha
                frm.Show();//Hiển thị form
            }
            else
            {
                Kich_Hoat_Form("frm_PhanQuyen");//Gọi lại form đã có
            }
        }
      
   
     
    }
}