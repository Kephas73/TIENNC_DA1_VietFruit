﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QL_VIETFRUIT_1Entities : DbContext
    {
        public QL_VIETFRUIT_1Entities()
            : base("name=QL_VIETFRUIT_1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CHI_TIET_HOA_DON> CHI_TIET_HOA_DON { get; set; }
        public DbSet<CHUC_NANG> CHUC_NANG { get; set; }
        public DbSet<GIO_LAM> GIO_LAM { get; set; }
        public DbSet<HOA_DON> HOA_DON { get; set; }
        public DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public DbSet<KHO_SAN_PHAM> KHO_SAN_PHAM { get; set; }
        public DbSet<NHAN_VIEN> NHAN_VIEN { get; set; }
        public DbSet<TAI_KHOAN> TAI_KHOAN { get; set; }
        public DbSet<TRANG_THAI> TRANG_THAI { get; set; }
    }
}
