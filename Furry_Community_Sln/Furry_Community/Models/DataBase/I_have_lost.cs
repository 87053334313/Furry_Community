//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Furry_Community.Models.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class I_have_lost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public I_have_lost()
        {
            this.all_information = new HashSet<all_information>();
        }
    
        public int ID_I_have_lost { get; set; }
        public string advertisment { get; set; }
        public string support { get; set; }
        public Nullable<int> ssylka_id { get; set; }
        public byte[] photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<all_information> all_information { get; set; }
    }
}
