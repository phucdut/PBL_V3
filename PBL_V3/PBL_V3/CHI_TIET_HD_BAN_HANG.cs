//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBL_V3
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHI_TIET_HD_BAN_HANG
    {
        public int Ma_CTHD { get; set; }
        public Nullable<int> Ma_Hoa_Don { get; set; }
        public Nullable<int> Ma_Hang_Hoa { get; set; }
        public Nullable<int> So_Luong { get; set; }
    
        public virtual HANG_HOA HANG_HOA { get; set; }
        public virtual HOA_DON_BAN_HANG HOA_DON_BAN_HANG { get; set; }
    }
}
