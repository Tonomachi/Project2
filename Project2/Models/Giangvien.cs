//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Giangvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giangvien()
        {
            this.lophocs = new HashSet<lophoc>();
        }
    
        public string MaGv { get; set; }
        public string HoGv { get; set; }
        public string TenGv { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Bangcap { get; set; }
        public string Nganh { get; set; }
        public Nullable<System.DateTime> Namsinh { get; set; }
        public string Tentruong { get; set; }
    
        public virtual Nganhhoc1 Nganhhoc1 { get; set; }
        public virtual Truong Truong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lophoc> lophocs { get; set; }
    }
}
