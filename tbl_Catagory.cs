//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoCrud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_Catagory
    {
        public long CategoryId { get; set; }
        [Required]
        [Display(Name="UserName")]
        [StringLength(20,ErrorMessage ="Name Not Exceed")]
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string Gendar { get; set; }
        public Nullable<long> CityId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    
        public virtual tbl_Cities tbl_Cities { get; set; }
    }
}