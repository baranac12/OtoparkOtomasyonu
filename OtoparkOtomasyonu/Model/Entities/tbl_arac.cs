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
    
    public partial class tbl_arac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_arac()
        {
            this.tbl_islemler = new HashSet<tbl_islemler>();
        }
    
        public int id { get; set; }
        public Nullable<int> musteriId { get; set; }
        public string plaka { get; set; }
        public int MarkaId { get; set; }
        public string Model { get; set; }
    
        public virtual tbl_marka tbl_marka { get; set; }
        public virtual tbl_musteri tbl_musteri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_islemler> tbl_islemler { get; set; }
    }
}
