//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnChuyenNganhBookingHotel.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class NguoiDung
    {
        public int nguoidung_id { get; set; }
        public string tennguoidung { get; set; }
        public string email { get; set; }
        public string matkhuaunguoidung { get; set; }
        public int quyen { get; set; }
    
        public virtual Quyen Quyen1 { get; set; }
    }
}
