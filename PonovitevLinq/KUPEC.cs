//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PonovitevLinq
{
    using System;
    using System.Collections.Generic;
    
    public partial class KUPEC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KUPEC()
        {
            this.RAČUN = new HashSet<RAČUN>();
        }
    
        public int KUP_KODA { get; set; }
        public string KUP_PRIIMEK { get; set; }
        public string KUP_IME { get; set; }
        public string KUP_ZAČ { get; set; }
        public string KUP_PODROČJE { get; set; }
        public string KUP_TELEFON { get; set; }
        public Nullable<decimal> KUP_STANJE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAČUN> RAČUN { get; set; }
    }
}
