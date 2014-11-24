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
    
    public partial class User
    {
        public User()
        {
            this.Products = new HashSet<Product>();
            this.CreditCards = new HashSet<CreditCard>();
            this.Commissions = new HashSet<Commission>();
            this.Roles = new HashSet<Role>();
        }
    
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal ContactNo { get; set; }
        public string Email { get; set; }
        public string Residence { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public Nullable<bool> HandlesDeliveres { get; set; }
        public Nullable<decimal> AccountNumber { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<Commission> Commissions { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
