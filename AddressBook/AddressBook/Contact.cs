//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AddressBook
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int Contact_Id { get; set; }
        public string Contact_Name { get; set; }
        public string Contact_Address { get; set; }
        public string Contact_Gender { get; set; }
        public string Contact_Email { get; set; }
        public string Contact_Phone { get; set; }
        public System.DateTime Contact_Birthdate { get; set; }
        public string Contact_NationalId { get; set; }
        public string Contact_Category { get; set; }
        public int Contact_UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}