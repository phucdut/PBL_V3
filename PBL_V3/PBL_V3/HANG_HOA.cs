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
    
    public partial class HANG_HOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANG_HOA()
        {
            this.CHI_TIET_HD_BAN_HANG = new HashSet<CHI_TIET_HD_BAN_HANG>();
        }
    
        public int Ma_Hang_Hoa { get; set; }
        public string Ten_Hang_Hoa { get; set; }
        public Nullable<int> Ma_Loai_Hang_Hoa { get; set; }
        public byte[] Hinh_Anh { get; set; }
        public Nullable<decimal> Gia_Hang_Hoa { get; set; }
        public Nullable<int> Tinh_Trang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_HD_BAN_HANG> CHI_TIET_HD_BAN_HANG { get; set; }
        public virtual LOAI_HANG_HOA LOAI_HANG_HOA { get; set; }
    }
}
