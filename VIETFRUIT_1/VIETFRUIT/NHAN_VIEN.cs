//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VIETFRUIT
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHAN_VIEN
    {
        public NHAN_VIEN()
        {
            this.GIO_LAM = new HashSet<GIO_LAM>();
            this.HOA_DON = new HashSet<HOA_DON>();
            this.TAI_KHOAN = new HashSet<TAI_KHOAN>();
        }
    
        public string MA_NHAN_VIEN { get; set; }
        public string TEN_NHAN_VIEN { get; set; }
        public string GIOI_TINH { get; set; }
        public System.DateTime NGAY_SINH { get; set; }
        public string TEN_BO_PHAN { get; set; }
        public string SO_DIEN_THOAI { get; set; }
        public string SCMND { get; set; }
        public string EMAIL { get; set; }
        public string DIA_CHI { get; set; }
        public Nullable<double> LUONG_CO_BAN { get; set; }
        public byte[] ANH { get; set; }
    
        public virtual ICollection<GIO_LAM> GIO_LAM { get; set; }
        public virtual ICollection<HOA_DON> HOA_DON { get; set; }
        public virtual ICollection<TAI_KHOAN> TAI_KHOAN { get; set; }
    }
}
