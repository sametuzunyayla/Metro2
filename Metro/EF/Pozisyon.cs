//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Metro.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pozisyon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pozisyon()
        {
            this.Kullanici_Pozisyon_Iliskisi = new HashSet<Kullanici_Pozisyon_Iliskisi>();
            this.Pozisyon1 = new HashSet<Pozisyon>();
        }
    
        public int Id { get; set; }
        public string Ad { get; set; }
        public Nullable<int> Seviye { get; set; }
        public Nullable<int> UstPozisyonId { get; set; }
        public bool YoneticiMi { get; set; }
        public string Aciklama { get; set; }
        public Nullable<System.DateTime> OlusturmaTarihi { get; set; }
        public Nullable<System.DateTime> BitisTarihi { get; set; }
        public Nullable<bool> AktifMi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici_Pozisyon_Iliskisi> Kullanici_Pozisyon_Iliskisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pozisyon> Pozisyon1 { get; set; }
        public virtual Pozisyon Pozisyon2 { get; set; }
    }
}