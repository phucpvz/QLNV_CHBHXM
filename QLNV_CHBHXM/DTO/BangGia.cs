//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNV_CHBHXM.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class BangGia
    {
        public int MaDG { get; set; }
        public int MaDV { get; set; }
        public int MaLX { get; set; }
        public int DonGia { get; set; }
        public string TrangThai { get; set; }
    
        public virtual DichVu DichVu { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
    }
}
