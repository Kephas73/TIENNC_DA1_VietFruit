using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public class TrangThai_MODEL
    {

        string TEN_TAI_KHOAN;
        public string TEN_TAI_KHOAN1
        {
            get { return TEN_TAI_KHOAN; }
            set { TEN_TAI_KHOAN = value; }
        }

        string MA_CHUC_NANG;
        public string MA_CHUC_NANG1
        {
            get { return MA_CHUC_NANG; }
            set { MA_CHUC_NANG = value; }
        }

        bool TRANG_THAI;
        public bool TRANG_THAI1
        {
            get { return TRANG_THAI; }
            set { TRANG_THAI = value; }
        }
    }
}
