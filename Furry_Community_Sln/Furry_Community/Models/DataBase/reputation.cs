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
    
    public partial class reputation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reputation()
        {
            this.it_is_me = new HashSet<it_is_me>();
        }
    
        public int ID_reputation { get; set; }
        public string acheivements { get; set; }
        public Nullable<int> id_role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<it_is_me> it_is_me { get; set; }
        public virtual role_love_of_animal role_love_of_animal { get; set; }
    }
}
