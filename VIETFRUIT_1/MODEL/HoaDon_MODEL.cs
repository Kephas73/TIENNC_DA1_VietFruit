using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class HoaDon_MODEL
    {
        string MA_HOA_DON;
        public string MA_HOA_DON1
        {
            get { return MA_HOA_DON; }
            set { MA_HOA_DON = value; }
        }

        string MA_NHAN_VIEN;
        public string MA_NHAN_VIEN1
        {
            get { return MA_NHAN_VIEN; }
            set { MA_NHAN_VIEN = value; }
        }

        string MA_KHACH_HANG;
        public string MA_KHACH_HANG1
        {
            get { return MA_KHACH_HANG; }
            set { MA_KHACH_HANG = value; }
        }

        DateTime NGAY_TAO;
        public DateTime NGAY_TAO1
        {
            get { return NGAY_TAO; }
            set { NGAY_TAO = value; }
        }

        float TONG_TIEN;

        public float TONG_TIEN1
        {
            get { return TONG_TIEN; }
            set { TONG_TIEN = value; }
        }
    }
}
