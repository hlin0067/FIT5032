//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project100207.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public string Doctor { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public string AspNetUsersId { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
