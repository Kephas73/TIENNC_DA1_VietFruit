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
    public partial class frm_KiemTra : Form
    {
        SanPham_BUS SP = new SanPham_BUS();
        KhoSanPham_MODEL SP1 = new KhoSanPham_MODEL();
        public frm_KiemTra()
        {
            InitializeComponent();
        }

        private void bt_KiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                //-----------Nếu DateTime.Compare trả lại giá trị nhỏ hơn 0 tức là thời gian t1 nhỏ hơn t2; nếu giá trị trả lại lớn hơn 0 thì thời gian t1 lớn hơn t2
                if ( DateTime.Compare(time_TuNgay.Value,time_ToiNgay.Value) >0  || cmb_ChonMuc.Text == "")
                { 
                    throw new Exception ("Bạn chưa nhập đủ thông tin tìm kiếm. Lưu ý: Từ ngày < Tới ngày");
                }
                else
                {
                    if (cmb_ChonMuc.Text == "Hạn sử dụng")
                    {
                        dtGV_SanPham.DataSource = SP.Kiem_Tra_Het_Han(time_TuNgay.Value, time_ToiNgay.Value);
                     
                    }
                }
                
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Lỗi: " +Ex.Message+"","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    
            }
         
        }
    }
}
