//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Commonlayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public string Email { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> datepurchased { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
