using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public   class GioLam_MODEL
    {
        string MA_NHAN_VIEN;
        public string MA_NHAN_VIEN1
        {
            get { return MA_NHAN_VIEN; }
            set { MA_NHAN_VIEN = value; }
        }

        string MA_GIO_LAM;

        public string MA_GIO_LAM1
        {
            get { return MA_GIO_LAM; }
            set { MA_GIO_LAM = value; }
        }

        
        
        DateTime NGAY_LAM;
        public DateTime NGAY_LAM1
        {
            get { return NGAY_LAM; }
            set { NGAY_LAM = value; }
        }

        float GIO_LAM;
        public float GIO_LAM1
        {
            get { return GIO_LAM; }
            set { GIO_LAM = value; }
        }
    }
}
