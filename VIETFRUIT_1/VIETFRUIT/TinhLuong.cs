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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace VIETFRUIT
{
    public partial class frm_TinhLuong : Form
    {
        TinhLuong_BUS TL = new TinhLuong_BUS();
        NhanVien_BUS NV = new NhanVien_BUS();
        ChamCong_BUS CC = new ChamCong_BUS();
        public frm_TinhLuong()
        {
            InitializeComponent();
        }

        void Danh_Sach_Nhan_vien()

        {
            dtGV_NhanVien.DataSource = TL.DS_Luong();
        }

        private void frm_TinhLuong_Load(object sender, EventArgs e)
        {
            Danh_Sach_Nhan_vien();
            int i;
            for(i=1;i<13;i++)
            {
                cmb_ThangTT.Items.Add(i);
                
            }
            for(i=2017;i<2101;i++)
            {
                cmb_NamTT.Items.Add(i);
            }
                
        }

        private void dtGV_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            txt_MaNV.DataBindings.Clear();
            txt_MaNV.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "MA_NHAN_VIEN");
            txt_HoTen.DataBindings.Clear();
            txt_HoTen.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "TEN_NHAN_VIEN");
            cmb_GioiTinh.DataBindings.Clear();
            cmb_GioiTinh.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "GIOI_TINH");
            time_NgaySinh.DataBindings.Clear();
            time_NgaySinh.DataBindings.Add("Value", dtGV_NhanVien.DataSource, "NGAY_SINH");
            cmb_BoPhan.DataBindings.Clear();
            cmb_BoPhan.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "TEN_BO_PHAN");
            txt_LuongCoBan.DataBindings.Clear();
            txt_LuongCoBan.DataBindings.Add("Text", dtGV_NhanVien.DataSource, "LUONG_CO_BAN");

        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            string A = txt_TimKiem.Text;
            string B = cmb_ChonMuc.Text;
            try
            {

                if (A == "" || B == "")
                {
                    throw new Exception ("Bạn chưa nhập thông tin tìm kiếm. Hãy nhập lại thông tin!");
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
                }
                if(dtGV_NhanVien.Rows.Count==0)
                {
                    txt_MaNV.Clear();
                    txt_HoTen.Clear();
                    txt_LuongCoBan.Clear();
                    txt_TongGio.ResetText();
                    txt_TongLuong.Clear();
                    cmb_BoPhan.ResetText();
                    cmb_GioiTinh.ResetText();
                    txt_LuongCoBan.Clear();
                    txt_PhuCap.Text = "0";
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                txt_TimKiem.ResetText();
                cmb_ChonMuc.ResetText();
                txt_PhuCap.Text = "0";
                txt_TongLuong.ResetText();
                txt_TongGio.ResetText();
            }

        }

        float Tinh_Luong(float TongGio,float LuongCoBan,float PhuCap)
        {
            float T = TongGio*LuongCoBan+PhuCap;
            return T;
        }
        private void bt_TinhLuong_Click(object sender, EventArgs e)
        {
            string A=txt_MaNV.Text;
            string B=cmb_ThangTT.Text;
            string C=cmb_NamTT.Text;
            try
            {
                if (A == "" || B == "" | C == "")
                {
                    throw new Exception("Thông tin chưa đầy đủ để tính lương! Mời bạn nhập lại thông tin");
                }
                else
                {
                    txt_TongGio.Text = CC.Tong_Gio_Lam(A, B, C);
                    if (txt_TongGio.Text == "")
                    {
                        throw new Exception("Không có thông tin chấm công");
                    }
                    else
                    {

                        float TongGio = float.Parse(txt_TongGio.Text);
                        float LuongCoBan = float.Parse(txt_LuongCoBan.Text);
                        float PhuCap = float.Parse(txt_PhuCap.Text);
                        txt_TongLuong.Text = Tinh_Luong(TongGio, LuongCoBan, PhuCap).ToString(("#,##0 VNĐ"));
                        dtGV_GioLam.DataSource = CC.Danh_Sach_Ngay_Lam(A, B, C);
                        bt_Xuat_Excel.Enabled = true;
                    }
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            
        }


        //private void export2Excel(DataGridView g, string duongDan, string tenTap)
        //{
        //    app obj = new app();
        //    obj.Application.Workbooks.Add(Type.Missing);
        //    obj.Columns.ColumnWidth = 25;
        //    for (int i = 1; i < g.Columns.Count + 1; i++) 
        //    { 
        //        obj.Cells[1, i] = g.Columns[i - 1].HeaderText; 
        //    }
        //    for (int i = 0; i < g.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < g.Columns.Count; j++)
        //        {
        //            if (g.Rows[i].Cells[j].Value != null) 
        //            { 
        //                obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString(); 
        //            }
        //        }
        //    }
        //    obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
        //    obj.ActiveWorkbook.Saved = true;
        //}



        public void Export(DataGridView dt, string sheetName, string title)
        {


            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "18";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã giờ làm";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Ngày làm";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Số giờ";

            cl3.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "C3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = dt.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
        }
         private void bt_Xuat_Excel_Click(object sender, EventArgs e)
         {
             //XuatExcel excel = new XuatExcel();
             //// Lấy về nguồn dữ liệu cần Export là 1 DataTable
             //// DataTable này mỗi bạn lấy mỗi khác. 
             //// Ở đây tôi dùng BindingSouce có tên bs nên tôi ép kiểu như sau:
             //// Bạn nào gán trực tiếp vào DataGridView thì ép kiểu DataSource của
             //// DataGridView nhé 
             //DataTable dt = (DataTable)dtGV_NhanVien.DataSource;
             //excel.Export(dt, "Danh sach", "DANH SÁCH CÁC ĐƠN VỊ");

             Export(dtGV_GioLam, "Danh Sách", "DANH SÁCH CÁC ĐƠN VỊ");
             //export2Excel(dtGV_NhanVien, @"E:\", "AC");

         }

         private void bt_TaiLai_Click(object sender, EventArgs e)
         {
             Danh_Sach_Nhan_vien();
             txt_TongLuong.ResetText();
             txt_TongGio.ResetText();
             txt_PhuCap.Text = "0";
             bt_Xuat_Excel.Enabled = false;
             foreach (DataGridViewRow dr in dtGV_GioLam.Rows)
             {
                 dtGV_GioLam.Rows.Remove(dr);
                   foreach (DataGridViewRow dr1 in dtGV_GioLam.Rows)
                   {
                       dtGV_GioLam.Rows.Remove(dr1);
                   }
             }
         }

         private void txt_PhuCap_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (char.IsLetter(e.KeyChar) || /*Ký tự Alphabe*/ char.IsSymbol(e.KeyChar) || /*Ký tự đặc biệt*/ char.IsWhiteSpace(e.KeyChar) || /*Khoảng cách*/ char.IsPunctuation(e.KeyChar)) //Dấu chấm 
             {

                 e.Handled = true;
                 MessageBox.Show("Chỉ nhập được số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
         }
    }
}
     
  