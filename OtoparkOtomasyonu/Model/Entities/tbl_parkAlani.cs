//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OtoparkOtomasyonu.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_parkAlani
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_parkAlani()
        {
            this.tbl_kullanici = new HashSet<tbl_kullanici>();
            this.tbl_islemler = new HashSet<tbl_islemler>();
        }
    
        public int id { get; set; }
        public string otoparkAlanAdi { get; set; }
        public int kapasite { get; set; }
        public decimal saat_1_ucret { get; set; }
        public decimal saat_2_ucret { get; set; }
        public decimal saat_3_ucret { get; set; }
        public decimal saat_gunboyu_ucret { get; set; }
        public bool Durumu { get; set; }
        public int saat_1 { get; set; }
        public int saat_2 { get; set; }
        public int saat_3 { get; set; }
        public decimal kasa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_kullanici> tbl_kullanici { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_islemler> tbl_islemler { get; set; }
    }
}
