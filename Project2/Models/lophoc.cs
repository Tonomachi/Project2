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
    
    public partial class lophoc
    {
        public string Malop { get; set; }
        public string MaGv { get; set; }
        public string MaSv { get; set; }
        public string Monhoc { get; set; }
    
        public virtual Giangvien Giangvien { get; set; }
        public virtual Sinhvien Sinhvien { get; set; }
    }
}
