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
    
    public partial class Link
    {
        public System.Guid ID { get; set; }
        public System.Guid ItemID { get; set; }
        public string Url { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Updated { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
