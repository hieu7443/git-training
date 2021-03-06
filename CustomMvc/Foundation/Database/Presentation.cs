//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomMvc.Foundation.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Presentation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Presentation()
        {
            this.ItemRenderings = new HashSet<ItemRendering>();
        }
    
        public System.Guid ID { get; set; }
        public System.Guid ItemID { get; set; }
        public System.Guid LayoutID { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Updated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemRendering> ItemRenderings { get; set; }
        public virtual Item Item { get; set; }
        public virtual Layout Layout { get; set; }
    }
}
